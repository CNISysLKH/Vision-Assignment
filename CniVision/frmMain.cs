using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Drawing.Imaging;

using Cognex.VisionPro;
using Cognex.VisionPro.FGGigE;
using Cognex.VisionPro.Display;

using CniVision.IO;

namespace CniVision
{
    public partial class frmMain : Form
    {
        private SynchronizationContext syncContext = null;

        #region 변수

        #region 카메라 관련 변수
        private CniCamera[] cameras = null;         // 카메라 배열 변수
        private bool[] cameraAcqState = null;       // 카메라 촬영 상태 배열 변수
        private ICogImage[] images = null;          // 이미지 배열 변후

        //private CniMerge mergeTool = null;          // 병합 클래스 변수
        private CniToolProcess toolProcess = null;  // 툴 클래스 변수

        private static int? _iCameraNum = null;     // 카메라의 개수 (무조건 초기 카메라 개수 확인 시 한 번만 선언)
        #endregion

        #region 검사 관련 변수
        private static bool bToolProcessState = false;// 검사 유무

        private static int iTrigCount = 0;          // 트리거 카운트
        private static int iTactTime = 0;           // 택 타임
        private static int iDataCount = 0;          // 찾은 데이터 개수

        private Task tCheckAllAcquired;             // 카메라 촬영 완료 확인 Task
        private bool IsProcessRunning = false;              // 검사 진행 상태
        #endregion

        #region 화면 관련 변수
        private static frmCamera frmCameraSetup;    // 카메라 설정 창 변수
        private static frmSetting frmProgramSetting;// 프로그램 설정 창 변수
        private static frmTools frmToolSetting;     // 도구 설정 창 변수
        private static frmMerge frmMergeToolSetting;// 병합 도구 설정 창 변수

        private static CogStopwatch cStopWatch = new CogStopwatch();    // 택 타임 체크할 스톱워치
        #endregion

        #region I/O Signal 관련 변수

        private CniIOControl ioControl = null;

        #endregion

        #region 네트워크 변수
        private CniTcpClient client = null;
        #endregion

        #region 인덱서
        public static int CameraNum                // _iCameraNum의 인덱서 (초기 카메라 개수를 확인할 때 초기화)
        {
            get
            {
                return _iCameraNum.GetValueOrDefault(-1); // 초기화되지 않았는데 불러올 경우 에러 발생 시킴
            }
            set
            {
                if (!_iCameraNum.HasValue)
                {
                    _iCameraNum = value;
                }
            }
        }
        #endregion

        #endregion

        #region 초기화 부분
        public frmMain()
        {
            InitializeComponent();

            InitializeCameras();
            InitializeTools();
            InitializeSignal();
            InitializeForm();
            InitializeNetwork();
        }


        // 초기화 동시에 바로 연결
        private void InitializeNetwork()
        {
            client = new CniTcpClient();
            client.SendCompleted += Client_SendCompleted;
            client.ServerConnected += Client_ServerConnected;
            client.ServerDisconnected += Client_ServerDisconnected;

            string ip = CniIniControl.IniReadValue("TCP", "SERVER_IP");
            int port = int.Parse(CniIniControl.IniReadValue("TCP", "SERVER_PORT"));

            client.ServerIP = ip;
            client.ServerPort = port;

            client.HeartBeat();
        }



        private void InitializeSignal()
        {
            ioControl = new CniIOControl();
            
            //ioControl.SetInputToOutputSignal(9, 7);
        }

        private void InitializeForm()
        {
            Icon = Properties.Resources.Logo;
            splitContainer1.FixedPanel = FixedPanel.Panel2;
            picLogo.Size = Icon.Size;
        }

        // 카메라 초기화 (검색 및 연결)
        private void InitializeCameras()
        {
            try
            {
                // 연결된 카메라 검색
                using (CogFrameGrabberGigEs fgs = new CogFrameGrabberGigEs())
                {
                    CameraNum = fgs.Count;

                    if (CameraNum < 1) return;

                    cameras = new CniCamera[CameraNum];     // 연결된 카메라 개수 만큼 생성

                    // 할당 후 연결
                    for (int idx = 0; idx < CameraNum; ++idx)
                    {
                        cameras[idx] = new CniCamera(idx);
                        cameras[idx].Connected += Connected;
                        cameras[idx].Disconnected += Disconnected;
                        cameras[idx].Acquired += Acquired;

                        cameras[idx].SetVideoFormat(cameras[idx].GetAvailableVideoFormat(fgs[idx], "mono"));    // 카메라 'mono' 포맷 확인 후 설정
                        cameras[idx].Connect(fgs[idx]);
                    }

                    cameraAcqState = new bool[CameraNum]; // 카메라 촬영 상태 배열 초기화
                    images = new ICogImage[CameraNum];    // 이미지 배열 초기화
                }
            }
            catch (Exception ex)
            {
                CniLog.WriteLog(ex);
            }

            // Task로 취득 완료 확인 후 프로세싱 돌림 
            tCheckAllAcquired = new Task(new Action(() =>
            {
                while (true)
                {
                    // 전체 카메라 촬영 완료 확인 부분
                    if (cameraAcqState.All(acqState => acqState))
                    {
                        cameraAcqState = Enumerable.Repeat(false, cameraAcqState.Length).ToArray();     // 모든 카메라 촬영 상태 false로 초기화
                        Console.WriteLine("모든 카메라 촬영 완료");
                        WriteLog("모든 카메라 촬영 완료", false);
                        if (frmMergeToolSetting != null)                                                // 병합 도구 창이 켜져 있으면 이미지를 병합 도구 창으로 보냄
                        {
                            frmMergeToolSetting.SetMergeImage(images);
                        }
                        else
                        {
                            IsProcessRunning = true;
                            cStopWatch.Reset();
                            cStopWatch.Start();
                            Process();                                                                  // 모든 이미지가 촬영 완료, 즉 이미지가 들어왔을 때만 Process함수를 실행
                        }
                    }
                }
            }));

            tCheckAllAcquired.Start();
        }

        // 모든 툴 초기화(Vpro 및 이미지 병합 도구)
        private void InitializeTools()
        {

            //mergeTool = new CniMerge();
            CniMerge.LoadMergeRegion();
            toolProcess = new CniToolProcess();
            toolProcess.Ran += ToolProcessRan;
        }
        #endregion

        #region 폼관련 이벤트 함수

        // 폼 열릴 때
        private void frmMain_Load(object sender, EventArgs e)
        {
            syncContext = SynchronizationContext.Current;
            tmCurrentTime.Enabled = true;

            // 폼을 불러올 때  UI 변경
            syncContext.Post(delegate
            {
                lblTactTime.Text = $"Time : {iTactTime} ms";
                lblTriggerCount.Text = $"Trigger Count : {iTrigCount}";
                lblDataCount.Text = $"찾은 개수 : {iDataCount}";
            }, null);



        }

        // 폼 닫힐 때
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cameras == null) return;
            foreach (CniCamera camera in cameras)
            {
                camera.Disconnect();
            }

        }

        // 현재시간 표시
        private void tmCurrentTime_Tick(object sender, EventArgs e)
        {
            syncContext.Post(delegate
            {
                lblTime.Text = DateTime.Now.ToString("yyyy-MM-dd" + "\r\n" + "tt hh:mm:ss");
            }, null);
        }

        // 트리거 카운트 리셋
        private void btnTriggerCountReset_Click(object sender, EventArgs e)
        {
            iTrigCount = 0;
            syncContext.Post(delegate
            {
                lblTriggerCount.Text = $"Trigger Count : {iTrigCount}";
            }, null);
        }

        // 카메라 버튼 클릭
        private void btnCameraControl_Click(object sender, EventArgs e)
        {
            if (frmCameraSetup == null)
            {
                ChangeCameraTriggerModel(CogAcqTriggerModelConstants.Manual);
                frmCameraSetup = new frmCamera();
                frmCameraSetup.FormClosed += FrmCameraSetup_FormClosed;
                frmCameraSetup.Cameras = cameras;
                frmCameraSetup.Show();
            }
        }
        // 카메라 설정 창 닫혔을 때
        private void FrmCameraSetup_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frmCameraSetup != null)
            {
                ChangeCameraTriggerModel(CogAcqTriggerModelConstants.Auto);
                frmCameraSetup = null;
            }
        }

        // 툴 버튼 클릭
        private void btnToolControl_Click(object sender, EventArgs e)
        {
            if (frmToolSetting == null)
            {
                ChangeCameraTriggerModel(CogAcqTriggerModelConstants.Manual);
                frmToolSetting = new frmTools(toolProcess);
                frmToolSetting.FormClosed += FrmToolSetting_FormClosed;
                frmToolSetting.Show();
            }
        }
        // 도구 설정 창 닫혔을 때
        private void FrmToolSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frmToolSetting != null)
            {
                ChangeCameraTriggerModel(CogAcqTriggerModelConstants.Auto);
                frmToolSetting = null;
            }
        }

        // 셋업 버튼 클릭
        private void btnSetupControl_Click(object sender, EventArgs e)
        {
            if (frmProgramSetting == null)
            {
                ChangeCameraTriggerModel(CogAcqTriggerModelConstants.Manual);
                frmProgramSetting = new frmSetting(this.ioControl);
                frmProgramSetting.FormClosed += FrmProgramSetting_FormClosed;
                frmProgramSetting.Show();
            }
        }
        // 프로그램 설정 창 닫혔을 때
        private void FrmProgramSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frmProgramSetting != null)
            {
                ChangeCameraTriggerModel(CogAcqTriggerModelConstants.Auto);
                frmProgramSetting = null;
            }
        }

        // 병합 버튼 클릭
        private void btnMergeControl_Click(object sender, EventArgs e)
        {
            if (frmMergeToolSetting == null)
            {
                ChangeCameraTriggerModel(CogAcqTriggerModelConstants.Manual);
                frmMergeToolSetting = new frmMerge(cameras, images, cRecordDisplay.Image);
                frmMergeToolSetting.FormClosed += FrmMergeToolSetting_FormClosed;
                frmMergeToolSetting.Show();
            }
        }
        // 병합 설정 창 닫혔을 때
        private void FrmMergeToolSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frmMergeToolSetting != null)
            {
                ChangeCameraTriggerModel(CogAcqTriggerModelConstants.Auto);
                frmMergeToolSetting = null;
            }
        }

        // 로그 텍스트 함수
        private void rtxLog_TextChanged(object sender, EventArgs e)
        {
            if (rtxLog.Lines.Length > 500)
            {
                string[] sLines = rtxLog.Lines;
                string[] sNewLines = new string[sLines.Length - 100];
                Array.Copy(sLines, 1, sNewLines, 0, sNewLines.Length);
                rtxLog.Lines = sNewLines;
            }

            rtxLog.SelectionStart = rtxLog.TextLength;
            rtxLog.ScrollToCaret();
        }

        // 로그 함수
        public void WriteLog(string sLog, bool bWriteLog)
        {
            try
            {
                syncContext.Post(
                delegate
                {
                    rtxLog.Text += ("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] " + sLog + "\r\n");

                    if (bWriteLog) // Text 파일로 저장여부 확인
                    {
                        CniLog.WriteLog("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] " + sLog);
                    }
                },
                null);
            }
            catch (Exception)
            {

            }
        }



        #endregion

        #region 카메라 이벤트 함수 

        // 연결 완료
        private void Connected(bool state, int num)
        {
            if (state)
            {
                Console.WriteLine($"{num} 카메라 연결 완료");
                WriteLog($"{num}번째 카메라 연결 완료", false);
            }
            else
            {
                Console.WriteLine($"{num} 카메라 연결 에러 발생");
                WriteLog($"{num}번째 카메라 연결 에러 발생", false);
            }
        }

        // 해제 완료
        private void Disconnected(bool state, int num)
        {
            if (state)
            {
                Console.WriteLine($"{num} 카메라 해제 완료");
                WriteLog($"{num}번째 카메라 해제 완료", false);
            }
            else
            {
                Console.WriteLine($"{num} 카메라 해제 에러 발생");
                WriteLog($"{num}번째 카메라 해제 에러 발생", false);
            }
        }

        // 취득 완료
        private void Acquired(bool state, int num, ICogImage image)
        {
            if (state)
            {
                Console.WriteLine($"{num} 카메라 촬영 완료");
                WriteLog($"{num}번째 카메라 촬영 완료", false);
                cameraAcqState[num] = state;
                images[num] = image;
            }
            else
            {
                Console.WriteLine($"{num} 카메라 촬영 에러 발생");
                WriteLog($"{num}번째 카메라 촬영 에러 발생", false);

                for (int i = 0; i < cameras.Length; ++i)
                {
                    cameraAcqState[i] = false;
                    images[i] = null;
                }
            }
        }



        #endregion

        #region 이미지 촬영 완료 후 처리 부분

        // 이미지 병합 후 도구 처리
        private void Process()
        {


            WriteLog("검사 시작", false);
            // UI 변경 부분
            {
                syncContext.Post(delegate
                {
                    // Graphic 초기화
                    if (cRecordDisplay.Record != null && cRecordDisplay.Record.SubRecords.Count > 0)
                    {
                        cRecordDisplay.Record.SubRecords.Clear();
                        cRecordDisplay.InteractiveGraphics.Clear();
                    }

                    // DataGridView 변경
                    if (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                    }


                    // 검사 카운트 증가
                    lblTriggerCount.Text = $"Trigger Count : {++iTrigCount}";
                }, null);
            }

            // 이미지 자름
            List<ICogImage> clipImages = CniMerge.ImageClipConvert(images.ToList());

            // ICogImage 배열을 Bitmap 리스트로 변환
            List<Bitmap> bitmapList = CniMerge.ICogImageToBitmapConvert(clipImages);

            // 이미지 병합
            WriteLog("이미지 병합 시작", false);
            Bitmap bImage = CniMerge.Merge(bitmapList);
            WriteLog("이미지 병합 완료", false);

            CogImage8Grey cImage8Grey = new CogImage8Grey(bImage);  // Bitmap에서 cogimage로 변환



            syncContext.Post(delegate
            {
                cRecordDisplay.Image = cImage8Grey;
                cRecordDisplay.Fit(true);
            }, null);


            WriteLog("검사 시작", false);
            toolProcess.Run(cImage8Grey);                           // 병합된 이미지로 검사

            if (bToolProcessState)                                  // 성공 후 데이터 저장
            {
                try
                {
                    if (CniIniArguments.IsSaveOriginImage)              // 원본 이미지 저장
                    {

                        WriteLog("촬영 이미지 저장", false);
                        Bitmap img = new Bitmap(cRecordDisplay.Image.ToBitmap());
                        string strSaveFileName = $@"{CniIniArguments.SaveImageDirectory}\Image_{DateTime.Now.ToString("yy_MM_dd_HH_mm_ss")}.bmp";


                        using (MemoryStream memory = new MemoryStream())
                        {
                            using (FileStream fs = new FileStream(strSaveFileName, FileMode.Create, FileAccess.Write))
                            {
                                img.Save(memory, ImageFormat.Bmp);
                                byte[] bytes = memory.ToArray();
                                fs.Write(bytes, 0, bytes.Length);
                            }
                        }
                    }
                    if (CniIniArguments.IsSaveResultImage)              // 그래픽 포함 이미지 저장
                    {
                        WriteLog("결과 이미지 저장", false);
                        cRecordDisplay.CreateContentBitmap(CogDisplayContentBitmapConstants.Image, null, 0).Save(CniIniArguments.SaveImageDirectory + @"\Result_Image_" + DateTime.Now.ToString("yy_MM_dd_HH_mm_ss") + ".bmp");  // bitmap으로 저장
                    }
                    if (CniIniArguments.IsSaveCSV)                      // CSV로 저장
                    {
                        WriteLog("결과 데이터 CSV형식으로 저장", false);
                        using (StreamWriter sw = new StreamWriter(CniIniArguments.SaveDataDirectory + @"\Result_Data_" + DateTime.Now.ToString("yy_MM_dd_HH_mm_ss") + ".csv"))      // 엑셀 형식
                        {
                            string line = "";
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    line += (cell.Value.ToString() + ",");
                                }
                                sw.WriteLine(line);
                                line = "";
                            }
                        }
                    }
                    if (CniIniArguments.IsSaveTXT)                      // TXT로 저장
                    {
                        WriteLog("결과 데이터 TXT형식으로 저장", false);
                        using (StreamWriter sw = new StreamWriter(CniIniArguments.SaveDataDirectory + @"\Result_Data_" + DateTime.Now.ToString("yy_MM_dd_HH_mm_ss") + ".txt"))      // 텍스트 형식
                        {
                            string line = "";
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    line += (cell.Value.ToString() + ",");
                                }
                                sw.WriteLine(line);
                                line = "";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (ex is DirectoryNotFoundException)           // 저장경로가 잘못되었을 경우 
                    {
                        MessageBox.Show("저장경로가 잘못되었습니다.\r\n저장경로를 변경해주세요.");
                    }
                }
            }

            IsProcessRunning = false;
            GC.Collect();

            WriteLog("검사 대기...", false);
        }

        #endregion

        #region 툴 이벤트 함수
        private void ToolProcessRan(bool state)
        {
            cStopWatch.Stop();
            iTactTime = (int)cStopWatch.Milliseconds;
            bToolProcessState = state;

            if (state)
            {
                // 검사 성공

                Dictionary<string, string> dicResult = toolProcess.GetDecodeResult();

                int cnt = 0;


                // 검사 후 UI 변경
                syncContext.Post(delegate
                {
                    foreach (var v in dicResult)
                    {
                        dataGridView1.Rows.Add(new object[3] { ++cnt, v.Key, v.Value });
                    }

                    cRecordDisplay.Record = toolProcess.GetRecordResult();

                    lblDataCount.Text = $"찾은 개수 : {dicResult.Count.ToString()}";

                    lblTactTime.Text = $"Time : {iTactTime} ms";

                }, null);

                WriteLog("검사 완료", false);
            }
            else
            {
                // 검사 실패
                syncContext.Post(delegate
                {
                    lblDataCount.Text = $"찾은 개수 : 0";

                    lblTactTime.Text = $"Time : {iTactTime} ms";

                }, null);
                WriteLog("검사 실패", false);
            }


            // 연결 중일 때만 데이터 전송
            if (client.IsConnected)
            {
                string data = "";
                if (state)
                {
                    foreach (var d in toolProcess.GetDecodeResult())
                    {
                        data += $"{d.Key}, {d.Value}";
                    }

                }
                else
                {
                    data = "NoRead";
                }
                client.Send(data);
            }

        }
        #endregion

        #region 네트워크 함수
        #region 네트워크 이벤트 함수
        // 데이터 전송 성공
        private void Client_SendCompleted(bool state)
        {
            if (state)
            {
                WriteLog($"{client.ServerIP} 데이터 전송 성공", false);
            }
            else
            {
                WriteLog($"{client.ServerIP} 데이터 전송 실패", false);
            }

        }
        // 서버 연결 해제 
        private void Client_ServerDisconnected(bool state)
        {
            if (state)
            {
                WriteLog($"{client.ServerIP} 연결 해제 성공", false);
            }
            else
            {
                WriteLog($"{client.ServerIP} 연결 해제 실패", false);
                WriteLog("강제 연결 해제", false);
                client = null;
            }
            GC.Collect();
        }
        // 서버 연결
        private void Client_ServerConnected(bool state)
        {
            if (state)
            {
                WriteLog($"{client.ServerIP} 연결 성공", false);
            }
            else
            {
                WriteLog($"{client.ServerIP} 연결 실패", false);
                WriteLog($"{client.ServerIP} 연결 재시도", false);
            }

            client.IsConnected = state;

        }

        #endregion

        #endregion

        // 카메라 트리거 모델 변경 함수
        private void ChangeCameraTriggerModel(CogAcqTriggerModelConstants trigModel)
        {
            // 테스트 모드일 경우 트리거 모드 변경하지 않음
            if (test || cameras is null) return;

            foreach (CniCamera cam in cameras)
            {
                if (cam.TrigModel != trigModel)
                {
                    cam.TrigModel = trigModel;
                }
            }
        }


        //test
        private void button1_Click(object sender, EventArgs e)
        {
            if (cameras == null) return;
            if (!IsProcessRunning)
            {
                WriteLog("촬영 시작", false);
                IsProcessRunning = true;

                foreach (CniCamera cam in cameras)
                {
                    cam.Grab();
                }
            }
        }
        private bool test = false;
        // manual grab test
        private void picLogo_DoubleClick(object sender, EventArgs e)
        {
            if (!test)
            {
                test = true;
                button1.Visible = true;
                ChangeCameraTriggerModel(CogAcqTriggerModelConstants.Manual);
            }
            else
            {
                test = false;
                button1.Visible = false;
                ChangeCameraTriggerModel(CogAcqTriggerModelConstants.Auto);
            }
        }


    }
}
