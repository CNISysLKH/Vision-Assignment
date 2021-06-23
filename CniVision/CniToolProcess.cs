using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.IO;

using Cognex.VisionPro;
using Cognex.VisionPro.ToolGroup;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.ID;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.Implementation;

namespace CniVision
{
    public delegate void ProcessRunCompleteEventHandler(bool state);


    public class CniToolProcess
    {
        public event ProcessRunCompleteEventHandler Ran;

        private static string strVppRootPath = Application.StartupPath + @"\VppTools";      // 툴 들어있는 폴더

        public CogToolGroup cToolGroup = null;                                              // 사용 툴 그룹
        private CogIPOneImageTool cIPOneImageTool = null;                                    // Input Image
        private CogBlobTool cBlobTool = null;                                                // 2D Code를 찾을 Blob
        private CogIDTool cIDToolQR = null;                                                  // QR
        private CogIDTool cIDToolDataMatrix = null;                                          // Data Matrix
        private CogIDTool cIDTool1D = null;                                                  // 1D Code
        private CogIDTool cIDToolQRUnit = null;                                              // QR 1개씩 찾을 때
        private CogIDTool cIDToolDataMatrixUnit = null;                                      // DataMatrix 1개씩 찾을 때

        private CogRecord cRecordResult = new CogRecord();
        private Dictionary<string, string> dicResult = new Dictionary<string, string>();

        // Tool Process 초기화 생성자 (모든 사용 툴이 존재한다고 가정하에 진행)
        public CniToolProcess()
        {
            // 폴더 유무 확인
            if (!Directory.Exists(strVppRootPath))
            {
                MessageBox.Show("ToolGroup 폴더가 없습니다");
            }

            // 툴 그룹 불러오기
            object tool = LoadTool("IDReadToolGroup");
            // ---툴그룹이 없을 경우 예외처리 필요--- // 

            if (tool is CogToolGroup)
            {
                cToolGroup = tool as CogToolGroup;
            }


            RefreshTools();

        }

        // tool 변경시 변수들 바뀐 툴로 변경
        public void RefreshTools()
        {
            // 툴 그룹안에 있는 툴들 가져오기
            CogToolCollection cToolCollection = cToolGroup.Tools;

            try
            {
                cIPOneImageTool = cToolCollection["CogIPOneImage"] as CogIPOneImageTool;
                cBlobTool = cToolCollection["CogBlobTool"] as CogBlobTool;
                cIDToolQR = cToolCollection["CogIDTool_QR"] as CogIDTool;
                cIDToolDataMatrix = cToolCollection["CogIDTool_DataMatrix"] as CogIDTool;
                cIDTool1D = cToolCollection["CogIDTool_1D"] as CogIDTool;
                cIDToolQRUnit = cToolCollection["CogIDTool_QR_Unit"] as CogIDTool;
                cIDToolDataMatrixUnit = cToolCollection["CogIDTool_DataMatrix_Unit"] as CogIDTool;
            }
            catch (Exception ex)
            {
                CniLog.WriteLog(ex);
            }
        }

        public void Run(ICogImage image)
        {
            // 데이터 정리
            if (dicResult.Count > 0)
            {
                dicResult.Clear();
            }

            bool bRunState = false;

            ICogImage _image = image;

            try
            {
                // IPOneImageTool에서 Run 후 OutputImage로 ID Read 시행
                cIPOneImageTool.InputImage = _image;
                cIPOneImageTool.Run();
                _image = cIPOneImageTool.OutputImage;

                // 리딩 작업 전 필요 작업들
                cBlobTool.InputImage = _image;
                cIDToolDataMatrix.InputImage = _image;
                cIDToolQR.InputImage = _image;
                cIDTool1D.InputImage = _image;
                cIDToolQRUnit.InputImage = _image;
                cIDToolDataMatrixUnit.InputImage = _image;

                // Blob 실행 후 찾은 블랍에서 DM, QR 리딩
                cBlobTool.Run();
                CogBlobResultCollection cBlobResultCollection = cBlobTool.Results.GetBlobs();

                bool bDMUnitState = false;
                bool bQRUnitState = false;

                // DM,QR 리딩
                if (cBlobResultCollection.Count > 0)
                {

                    // DM 검색
                    foreach (CogBlobResult cBlobResult in cBlobResultCollection)
                    {
                        cIDToolDataMatrixUnit.Region = cBlobResult.GetBoundingBox(CogBlobAxisConstants.Principal);
                        cIDToolDataMatrixUnit.Run();

                        if (cIDToolDataMatrixUnit.Results != null && cIDToolDataMatrixUnit.Results.Count > 0)       // 결과가 없을 경우 건너 뜀
                        {
                            string strDecodeData = cIDToolDataMatrixUnit.Results[0].DecodedData.DecodedString;
                            string strSymbology = cIDToolDataMatrixUnit.Results[0].DecodedData.Symbology.ToString();

                            if (!dicResult.ContainsKey(strDecodeData))
                            {
                                dicResult.Add(strDecodeData, strSymbology);
                            }

                            cRecordResult.SubRecords.Add(cIDToolDataMatrixUnit.CreateLastRunRecord());
                            bDMUnitState = true;
                        }
                    }


                    // QR 검색
                    foreach (CogBlobResult cBlobResult in cBlobResultCollection)
                    {
                        cIDToolQRUnit.Region = cBlobResult.GetBoundingBox(CogBlobAxisConstants.Principal);
                        cIDToolQRUnit.Run();

                        if (cIDToolQRUnit.Results != null && cIDToolQRUnit.Results.Count > 0)       // 결과가 없을 경우 건너 뜀
                        {
                            string strDecodeData = cIDToolQRUnit.Results[0].DecodedData.DecodedString;
                            string strSymbology = cIDToolQRUnit.Results[0].DecodedData.Symbology.ToString();

                            if (!dicResult.ContainsKey(strDecodeData))
                            {
                                dicResult.Add(strDecodeData, strSymbology);
                            }

                            cRecordResult.SubRecords.Add(cIDToolQRUnit.CreateLastRunRecord());
                            bQRUnitState = true;
                        }
                    }

                }

                // 못찾을 경우 DataMan 전체 리딩 시도
                if (!bDMUnitState)
                {
                    cIDToolDataMatrix.Run();

                    if (cIDToolDataMatrix.Results != null && cIDToolDataMatrix.Results.Count > 0)
                    {
                        foreach (CogIDResult cDMResult in cIDToolDataMatrix.Results)
                        {
                            if (!dicResult.ContainsKey(cDMResult.DecodedData.DecodedString))
                            {
                                dicResult.Add(cDMResult.DecodedData.DecodedString, cDMResult.DecodedData.Symbology.ToString());
                            }
                        }

                        cRecordResult.SubRecords.Add(cIDToolDataMatrix.CreateLastRunRecord());
                    }

                }

                // 못찾을 경우 QR 전체 리딩 시도
                if (!bQRUnitState)
                {
                    cIDToolQR.Run();

                    if (cIDToolQR.Results != null && cIDToolQR.Results.Count > 0)
                    {
                        foreach (CogIDResult cQRResult in cIDToolQR.Results)
                        {
                            if (!dicResult.ContainsKey(cQRResult.DecodedData.DecodedString))
                            {
                                dicResult.Add(cQRResult.DecodedData.DecodedString, cQRResult.DecodedData.Symbology.ToString());
                            }
                        }

                        cRecordResult.SubRecords.Add(cIDToolQR.CreateLastRunRecord());
                    }
                }

                // 1D 코드 리딩
                cIDTool1D.Run();
                if (cIDTool1D.Results != null && cIDTool1D.Results.Count > 0)
                {

                    foreach (CogIDResult c1DResult in cIDTool1D.Results)
                    {
                        if (!dicResult.ContainsKey(c1DResult.DecodedData.DecodedString))
                        {
                            dicResult.Add(c1DResult.DecodedData.DecodedString, c1DResult.DecodedData.Symbology.ToString());
                        }
                    }

                    cRecordResult.SubRecords.Add(cIDTool1D.CreateLastRunRecord());
                }

                bRunState = true;

            }
            catch (Exception ex)
            {
                CniLog.WriteLog(ex);
                bRunState = false;
            }
            finally
            {
                OnRan(bRunState);
            }
        }

        #region ToolProcess 이벤트 함수


        private void OnRan(bool state)
        {
            Ran?.Invoke(state);
        }

        #endregion


        // 수정 필요 //
        #region 결과 데이터 접근 함수

        public Dictionary<string, string> GetDecodeResult()
        {
            return dicResult;
        }

        public CogRecord GetRecordResult()
        {
            return cRecordResult;
        }

        #endregion


        #region 툴 load/Save 함수

        // 툴 불러오기
        public static object LoadTool(string name)
        {
            object tool = null;

            try
            {
                tool = CogSerializer.LoadObjectFromFile(strVppRootPath + $@"\{name}.vpp", typeof(BinaryFormatter), CogSerializationOptionsConstants.Minimum);
            }
            catch (Exception ex)
            {
                CniLog.WriteLog(ex);
            }

            return tool;
        }

        // 툴 저장
        public static void SaveTool(object tool, string name)
        {
            try
            {
                CogSerializer.SaveObjectToFile(tool, strVppRootPath + $@"\{name}.vpp", typeof(BinaryFormatter), CogSerializationOptionsConstants.Minimum);
            }
            catch (Exception ex)
            {
                CniLog.WriteLog(ex);
            }
        }

        #endregion


    }
}
