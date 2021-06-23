using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cognex.VisionPro;

namespace CniVision
{
    public delegate void ConnectEventHandler(bool state, int num);                       // 연결 이벤트 핸들러
    public delegate void DisconnectEventHandler(bool state, int num);                    // 해제 이벤트 핸들러
    public delegate void AcquisitionEventHandler(bool state, int num, ICogImage image);    // 촬영 이벤트 핸들러


    public class CniCamera
    {

        private string strVideoFormat = "";         // 현재 설정한 카메라 Vidoe Format 
        public ICogAcqFifo Camera = null;           // 현 카메라 클래스
        public readonly int Number;                 // 연결된 순서
        public string strIPAddress = "";            // 카메라 IPAdrress


        public CogAcqTriggerModelConstants TrigModel
        {
            get
            {
                return Camera.OwnedTriggerParams.TriggerModel;
            }
            set
            {
                Camera.OwnedTriggerParams.TriggerModel = value;
            }
        } // 카메라 트리거 모델


        public CniCamera(int num)
        {
            Number = num;
        }

        /// <summary>
        /// 카메라 연결
        /// </summary>
        public void Connect(ICogFrameGrabber fg)
        {

            bool bState = false; // 연결상태
            try
            {
                strIPAddress = fg.OwnedGigEAccess.CurrentIPAddress;

                Camera = fg.CreateAcqFifo(strVideoFormat, CogAcqFifoPixelFormatConstants.Format8Grey, 0, false);
                Camera.Complete += AcquisitionCompleted;

                Camera.OwnedTriggerParams.TriggerModel = CogAcqTriggerModelConstants.Auto;
                bState = true;

            }
            catch (Exception ex)
            {
                CniLog.WriteLog(ex);
                bState = false;
            }
            finally
            {
                OnConnect(bState, Number);
            }
        }

        /// <summary>
        /// 카메라 연결 해제
        /// </summary>
        public void Disconnect()
        {
            bool bState = false; // 해제상태
            try
            {
                this.Camera.FrameGrabber.Disconnect(false);

                bState = true;
            }
            catch (Exception ex)
            {
                CniLog.WriteLog(ex);
                bState = false;
            }
            finally
            {
                OnDisconnect(bState, Number);
            }
        }

        /// <summary>
        /// 카메라 이미지 수동 취득
        /// </summary>
        public void Grab()
        {
            try
            {
                this.Camera.StartAcquire();
            }
            catch (Exception ex)
            {
                CniLog.WriteLog(ex);
            }
        }

        /// <summary>
        /// 입력된 Video Format을 검색 후 첫 번째로 검색된 Format 반환
        /// </summary>
        /// <param name="vf">검색할 Video Format</param>
        /// <returns></returns>
        public string GetAvailableVideoFormat(ICogFrameGrabber fg, string vf)
        {
            string format = "";

            try
            {
                foreach (string f in fg.AvailableVideoFormats)
                {
                    if (f.ToLower().Contains(vf))
                    {
                        format = f;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                CniLog.WriteLog(ex);
            }

            return format;
        }

        /// <summary>
        /// Video Format 가져오기
        /// </summary>
        /// <returns></returns>
        public string GetVideoFormat()
        {
            return strVideoFormat;
        }


        /// <summary>
        /// Video Format 설정하기
        /// </summary>
        /// <param name="vf"></param>
        public void SetVideoFormat(string vf)
        {
            strVideoFormat = vf;
        }

        /// <summary>
        /// Exposure 가져오기
        /// </summary>
        /// <returns></returns>
        public double GetExposure()
        {
            return this.Camera.OwnedExposureParams.Exposure;
        }

        /// <summary>
        /// Exposure 설정하기
        /// </summary>
        /// <param name="exposure"></param>
        public void SetExposure(double exposure)
        {
            this.Camera.OwnedExposureParams.Exposure = exposure;
        }

        /// <summary>
        /// Gain 가져오기
        /// </summary>
        /// <returns></returns>
        public double GetGain()
        {
            return this.Camera.OwnedContrastParams.Contrast;
        }

        /// <summary>
        /// Gain 설정하기
        /// </summary>
        /// <param name="gain"></param>
        public void SetGain(double gain)
        {
            this.Camera.OwnedContrastParams.Contrast = gain;
        }

        /// <summary>
        /// Camera 가져오기
        /// </summary>
        /// <returns></returns>
        public ICogAcqFifo GetCamera()
        {
            return this.Camera;
        }

        /// <summary>
        /// 트리거 발생 후 이미지 취득 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AcquisitionCompleted(object sender, CogCompleteEventArgs e)
        {
            bool bState = false;
            int iTicket = e.Ticket;
            int iTrigNum = e.TriggerNumber;
            ICogImage image = null;
            try
            {
                image = Camera.CompleteAcquire(-1, out iTicket, out iTrigNum);

                bState = true;

            }
            catch (Exception ex)
            {
                CniLog.WriteLog(ex);
                bState = false;
            }
            finally
            {
                OnAcquisition(bState, Number, image);
            }
        }


        private void OnConnect(bool state, int num)
        {
            Connected?.Invoke(state, num);
        }
        private void OnDisconnect(bool state, int num)
        {
            Disconnected?.Invoke(state, num);
        }
        private void OnAcquisition(bool state, int num, ICogImage image)
        {
            Acquired?.Invoke(state, num, image);
        }




        public event ConnectEventHandler Connected;         // 카메라 연결 이벤트
        public event DisconnectEventHandler Disconnected;   // 카메라 해제 이벤트
        public event AcquisitionEventHandler Acquired;        // 카메라 촬영 이벤트


    }
}
