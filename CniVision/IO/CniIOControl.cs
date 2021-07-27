using System;
using System.Timers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace CniVision.IO
{

    public delegate void TriggerEventHandler();

    public class CniIOControl
    {
        /// <summary>
        /// Input Signal 배열 변수
        /// </summary>
        public static CniInputSignal[] ISArray = new CniInputSignal[16];
        /// <summary>
        /// Output Signal 배열 변수
        /// </summary>
        public static CniOutputSignal[] OSArray = new CniOutputSignal[16];
        /// <summary>
        /// Input Signal 확인 변수
        /// </summary>
        public string InputSignalValue = new string('0', 16);
        /// <summary>
        /// Output Signal 확인 변수
        /// </summary>
        public string OutputSignalValue = new string('0', 16);
        /// <summary>
        /// Output Signal 활성화 확인 변수
        /// </summary>
        public string CheckOutputSignalValue = new string('0', 16);

        /// <summary>
        /// CniIOControl 생성자(초기화)
        /// </summary>
        public CniIOControl()
        {
            InitializeInputSignal();
            InitializeOutputSignal();

            //ISArray = LoadInputSignalConfigValue();
            //OSArray = LoadOutputSignalConfigValue();

            for (int num = 0; num < 16; ++num)
            {
                //ISArray[num] = new CniInputSignal(num);
                ISArray[num].Occured += InputSignalOccured;

                //OSArray[num] = new CniOutputSignal(num);
                OSArray[num].Occured += OutputSignalOccured;
                OSArray[num].Opened += OutputSignalOpened;
                OSArray[num].Closed += OutputSignalClosed;
            }

            tmInputCheck.Elapsed += tmInputCheckElapsed;
            tmOutputCheck.Elapsed += tmOutputCheckElapsed;

            sCard = CniIODllImport.Register_Card(CniIODllImport.PCI_7230, 0);
            if (sCard < 0)
            {
                BoardConnectStatus = false;
                //Log
            }
            else
            {
                BoardConnectStatus = true;
                tmInputCheck.Start();
                tmOutputCheck.Start();
            }

           

        }



        /// <summary>
        /// I/O 보드 연결 인식 변수
        /// </summary>
        private short sCard;
        /// <summary>
        /// Input 상태 확인 Timer
        /// </summary>
        private Timer tmInputCheck = new Timer(1);
        /// <summary>
        /// Output 상태 확인 Timer
        /// </summary>
        private Timer tmOutputCheck = new Timer(1);
        /// <summary>
        /// I/O 보드 연결 상태
        /// </summary>
        public bool BoardConnectStatus { get; private set; }


        /// <summary>
        /// 트리거 발생 이벤트
        /// </summary>
        public event TriggerEventHandler Triggered;


        /// <summary>
        /// Input Signal 배열 초기화
        /// </summary>
        private void InitializeInputSignal()
        {
            try
            {
                ISArray = LoadInputSignalConfigValue();
            }catch(FileNotFoundException ex)
            {
                File.Create(System.Windows.Forms.Application.StartupPath + @"InputSignal Data.json");
            }
        }
        /// <summary>
        /// Output Signal 배열 초기화
        /// </summary>
        private void InitializeOutputSignal()
        {
            try
            {
                OSArray = LoadOutputSignalConfigValue();
            }catch(FileNotFoundException ex)
            {
                File.Create(System.Windows.Forms.Application.StartupPath + @"OutputSignal Data.json");
            }
        }
        /// <summary>
        /// Input Signal 설정 가져오기
        /// </summary>
        /// <param name="num">신호 순번</param>
        /// <returns></returns>
        public CniInputSignal[] LoadInputSignalConfigValue()
        {
            return JsonSerializer.Deserialize<CniInputSignal[]>(File.ReadAllText(System.Windows.Forms.Application.StartupPath + @"InputSignal Data.json"));
        }
        /// <summary>
        /// Output Signal 설정 가져오기
        /// </summary>
        /// <param name="num">신호 순번</param>
        /// <returns></returns>
        public CniOutputSignal[] LoadOutputSignalConfigValue()
        {
            return JsonSerializer.Deserialize<CniOutputSignal[]>(File.ReadAllText(System.Windows.Forms.Application.StartupPath + @"OutputSignal Data.json"));
        }
        /// <summary>
        /// Input Signal 설정 저장하기
        /// </summary>
        /// <param name="num">신호 순번</param>
        public void SaveInputSignalConfigValue(CniInputSignal[] inputs)
        {
            File.WriteAllText(System.Windows.Forms.Application.StartupPath + @"\InputSginal Data.json", JsonSerializer.Serialize<CniInputSignal[]>(inputs));
        }
        /// <summary>
        /// Output Signal 신호 저장하기
        /// </summary>
        /// <param name="num">신호 순번</param>
        public void SaveOutputSignalConfigValue(CniOutputSignal[] outputs)
        {
            File.WriteAllText(System.Windows.Forms.Application.StartupPath + @"\OutputSginal Data.json", JsonSerializer.Serialize<CniOutputSignal[]>(outputs));
        }

        /// <summary>
        /// 트리거 활성화 시 발생
        /// </summary>
        private void OnTriggered()
        {
            if (Triggered != null)
            {
                IAsyncResult res = Triggered.BeginInvoke(delegate
                {
                }, null);

                Triggered.EndInvoke(res);

            }
        }


        /// <summary>
        /// Input Signal 발생 이벤트
        /// </summary>
        /// <param name="num"></param>
        private void InputSignalOccured(int num)
        {
            bool curStatus = Convert.ToBoolean(InputSignalValue[num]);
            char[] cArr = InputSignalValue.ToCharArray();
            cArr[num] = Convert.ToChar(curStatus);
            InputSignalValue = cArr.ToString();
        }
        /// <summary>
        /// Output Signal 발생 이벤트
        /// </summary>
        /// <param name="num"></param>
        private void OutputSignalOccured(int num)
        {
            char[] cArr = OutputSignalValue.ToCharArray();
            cArr[num] = '0';
            OutputSignalValue = cArr.ToString();
        }
        /// <summary>
        /// Output Signal 강제 활성화
        /// </summary>
        /// <param name="num"></param>
        private void OutputSignalOpened(int num)
        {
            char[] cArr = OutputSignalValue.ToCharArray();
            cArr[num] = '1';
            OutputSignalValue = cArr.ToString();
        }
        /// <summary>
        /// Output Signal 강제 비활성화
        /// </summary>
        /// <param name="num"></param>
        private void OutputSignalClosed(int num)
        {
            char[] cArr = OutputSignalValue.ToCharArray();
            cArr[num] = '0';
            OutputSignalValue = cArr.ToString();
        }
        /// <summary>
        /// Input Signal 체크 Timer 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmInputCheckElapsed(object sender, ElapsedEventArgs e)
        {
            string chkInput = new string('0', 16);

            CniIODllImport.ReadPort_Input((ushort)sCard, 0, ref chkInput);

            for (int i = 0; i < 16; ++i)
            {
                if (InputSignalValue[i].CompareTo(chkInput[i]) < 0)
                {
                    if (ISArray[i].Polarity)
                    {
                        OnTriggered();
                        ISArray[i].Occur();
                    }
                }
                else if (InputSignalValue[i].CompareTo(chkInput[i]) > 0)
                {
                    if (!ISArray[i].Polarity)
                    {
                        OnTriggered();
                        ISArray[i].Occur();
                    }
                }
            }

            InputSignalValue = chkInput;

        }
        /// <summary>
        /// Output Signla 정상작동 체크 Timer 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmOutputCheckElapsed(object sender, ElapsedEventArgs e)
        {
            if (OutputSignalValue.CompareTo(CheckOutputSignalValue) != 0)
            {
                // Output 신호 발생 에러 
            }
        }
    }
}
