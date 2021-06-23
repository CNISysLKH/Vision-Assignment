using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Net;
using System.Net.NetworkInformation;
using System.Net.Configuration;
using System.Net.Sockets;

namespace CniVision
{
    public delegate void SendDataEventHandler(bool state);
    public delegate void ServerConnectCompleteEventHandler(bool state);
    public delegate void ServerDisconnectCompleteEventHandler(bool state);


    /// <summary>
    /// 서버와 연결 후 검사 데이터 전송 
    /// </summary>
    public class CniTcpClient
    {
        #region 네트워크 관련 변수
        public string ServerIP { get; set; }                // 서버 아이피
        public int ServerPort { get; set; }                 // 서버 포트
        public bool IsConnected { get; set; }               // 서버와의 연결 상태

        private TcpClient tcpClient = null;                    // 클라이언트 변수
        private NetworkStream stream = null;                // 데이터 송수신 변수
        #endregion

        #region 이벤트 함수
        public event SendDataEventHandler SendCompleted;
        public event ServerConnectCompleteEventHandler ServerConnected;
        public event ServerDisconnectCompleteEventHandler ServerDisconnected;
        #endregion

        #region 네트워크 함수
        /// <summary>
        /// 서버와 연결
        /// </summary>
        /// <param name="serverIP">서버 IP</param>
        /// <param name="serverPort">서버 Port</param>
        public void Connect()
        {
            bool state = false;
            try
            {
                tcpClient = new TcpClient(ServerIP, ServerPort);
                stream = tcpClient.GetStream();


                state = true;
            }
            catch (Exception ex)
            {
                CniLog.WriteLog(ex);
                state = false;
            }
            finally
            {
                OnServerConneceted(state);
            }

        }

        /// <summary>
        /// 서버와 연결 해제
        /// </summary>
        public void Disconnect()
        {
            bool state = false;
            try
            {
                stream.Close();
                tcpClient.Close();

                state = true;
            }
            catch (Exception ex)
            {
                CniLog.WriteLog(ex);
                state = false;
            }
            finally
            {
                OnServerDisconnected(state);
            }
        }

        /// <summary>
        /// 서버에 데이터 전송 함수
        /// </summary>
        /// <param name="sendData">전송 데이터</param>
        public void Send(string sendData)
        {
            bool state = false;
            try
            {
                byte[] data = Encoding.ASCII.GetBytes(sendData);

                stream.WriteAsync(data, 0, data.Length);
                state = true;

            }
            catch (Exception ex)
            {
                CniLog.WriteLog(ex);
                state = false;
            }
            finally
            {
                OnSendData(state);
            }

        }

        /// <summary>
        /// 서버와 연결상태 확인 함수(HeartBeat 함수)
        /// 프로그램이 켜지면 즉시 실행
        /// </summary>
        public void HeartBeat()
        {
            byte[] pingData = Encoding.ASCII.GetBytes("aaa");

            // Thread를 만들어 비동기적으로 연결 상태 확인
            new Task(() =>
            {
                while (true)
                {
                    Thread.Sleep(1000);                 // 1초 마다 확인
                    try
                    {
                        if (IsConnected)
                        {
                            stream.WriteAsync(pingData, 0, pingData.Length);
                        }
                        else
                        {   // 연결이 안되어 있다면 연결 해제 후 재연결 시도
                            tcpClient.Close();          
                            Connect();
                            IsConnected = true;
                        }
                    }
                    catch
                    {
                        IsConnected = false;
                    }

                }

            }).Start();
        }
        #endregion

        #region 이벤트 활성화 함수

        // 데이터 전송 성공 후
        private void OnSendData(bool state)
        {
            SendCompleted?.Invoke(state);
        }

        // 서버 연결 성공
        private void OnServerConneceted(bool state)
        {
            ServerConnected?.Invoke(state);
        }
        // 서버 해제 성공
        private void OnServerDisconnected(bool state)
        {
            ServerDisconnected?.Invoke(state);
        }
        #endregion


    }
}
