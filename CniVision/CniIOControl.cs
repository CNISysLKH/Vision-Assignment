using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Collections;

namespace CniVision
{

    public class CniIOControl
    {

        private short sCard;
        private Timer tmInputCheck;
        private Timer tmOuputCheck;

        private InputSignal[] inSignal = new InputSignal[16];
        private OutputSignal[] outSignal = new OutputSignal[16];

        public bool ConnectionStatus { get; set; }                  // I/O보드와 연결 상태

        // 초기화
        public CniIOControl()
        {
            for (int i = 0; i < 16; ++i)
            {
                inSignal[i] = new InputSignal(i);
                outSignal[i] = new OutputSignal(i);

                inSignal[i].Enable = bool.Parse(CniIniControl.IniReadValue("INPUTSIGNAL", $"INPUT{i}_ENABLE"));
                inSignal[i].Polarity = bool.Parse(CniIniControl.IniReadValue("INPUTSIGNAL", $"INPUT{i}_POLARITY"));
                inSignal[i].DebounceTime = int.Parse(CniIniControl.IniReadValue("INPUTSIGNAL", $"INPUT{i}_DEBOUNCETIME"));
                inSignal[i].OutputSignal = int.Parse(CniIniControl.IniReadValue("INPUTSIGNAL", $"INPUT{i}_OUTPUTSIGNAL"));

                outSignal[i].Enable = bool.Parse(CniIniControl.IniReadValue("OUTPUTSIGNAL", $"OUTPUT{i}_ENABLE"));
                outSignal[i].PulseWidth = int.Parse(CniIniControl.IniReadValue("OUTPUTSIGNAL", $"OUTPUT{i}_PULSEWIDTH"));

                inSignal[i].Occured += InputSignal_Occured;
                outSignal[i].Occured += OutputSignal_Occured;
                outSignal[i].Open += OutputSignal_Opened;
                outSignal[i].Close += OutputSignal_Closed;
            }

            tmInputCheck = new Timer(1);
            tmOuputCheck = new Timer(1);
            tmInputCheck.Elapsed += TmInputCheck_Elapsed;
            tmOuputCheck.Elapsed += TmOuputCheck_Elapsed;

            sCard = DASK.Register_Card(DASK.PCI_7230, 0);
            if (sCard < 0)
            {
                ConnectionStatus = false;
                // Log

            }
            else
            {
                ConnectionStatus = true;
                tmInputCheck.Start();
                tmOuputCheck.Start();
            }
        }

        #region Signal 조작 함수

        #region Input
        // Input 사용 여부 가져오기
        public void SetInputEnable(int inNum, bool enable)
        {
            inSignal[inNum].Enable = enable;
            CniIniControl.IniWriteValue("INPUTSIGNAL", $"INPUT{inNum}_ENABLE", enable.ToString());
        }
        // Input 사용 여부 설정
        public bool GetINputEnable(int inNum)
        {
            return inSignal[inNum].Enable;
        }

        // Input에서 내보내는 Output 번호 설정
        public void SetInputToOutputSignal(int inNum, int outNum)
        {
            inSignal[inNum].OutputSignal = outNum;
            CniIniControl.IniWriteValue("INPUTSIGNAL", $"INPUT{inNum}_OUTPUTSIGNAL", outNum.ToString());
        }

        // Input에서 내보내는 Output 번호 가져오기
        public int GetInputToOutputSignal(int inNum)
        {
            return inSignal[inNum].OutputSignal;
        }

        // 원하는 Input 극성 설정
        public void SetPolarity(int inNum, bool EdgeDirection)
        {
            inSignal[inNum].Polarity = EdgeDirection;
            CniIniControl.IniWriteValue("INPUTSIGNAL", $"INPUT{inNum}_POLARITY", EdgeDirection.ToString());
        }

        // Input 극성 가져오기
        public bool GetPolarity(int inNum)
        {
            return inSignal[inNum].Polarity;
        }

        // Input Debounce Time 설정
        public void SetInputDebounceTime(int inNum, int time)
        {
            inSignal[inNum].DebounceTime = time;
            CniIniControl.IniWriteValue("INPUTSIGNAL", $"INPUT{inNum}_DEBOUNCETIME", time.ToString());
        }

        // Input Debounce Time 가져오기
        public int GetInputDebounceTime(int inNum)
        {
            return inSignal[inNum].DebounceTime;
        }
        #endregion

        #region Output
        // Output 사용 설정
        public void SetOutputEnable(int outNum, bool enable)
        {
            outSignal[outNum].Enable = enable;
            CniIniControl.IniWriteValue("OUTPUTSIGNAL", $"OUTPUT{outNum}_ENABLE", enable.ToString());
        }

        // Output 사용 상태 가져오기
        public bool GetOutputEnable(int outNum)
        {
            return outSignal[outNum].Enable;
        }

        // Output Pulse Width 설정
        public void SetOutputPulseWidth(int outNum, int width)
        {
            outSignal[outNum].PulseWidth = width;
            CniIniControl.IniWriteValue("OUTPUTSIGNAL", $"OUTPUT{outNum}_PULSEWIDTH", width.ToString());
        }
        // Output Pulse Width 가져오기
        public int GetOutputPulseWidth(int outNum)
        {
            return outSignal[outNum].PulseWidth;
        }

        // Output 열기
        public void OutputOpen(int outNum)
        {
            outSignal[outNum].SignalOpen();
        }

        // Output 닫기
        public void OutputClose(int outNum)
        {
            outSignal[outNum].SignalClose();
        }

        // Output 작업 가져오기
        public bool GetOutputAction(int outNum)
        {
            return outSignal[outNum].Action;
        }
        #endregion

        #endregion

        #region Signal 이벤트 함수
        private void InputSignal_Occured(int idx)
        {
            int iSignal = inSignal[idx].OutputSignal;
            DASK.Check_Output[iSignal] = "1";
            outSignal[iSignal].OnSignal();
            DASK.WritePort_Output((ushort)sCard, 0);

        }

        private void OutputSignal_Occured(int idx)
        {
            DASK.Check_Output[idx] = "0";
            DASK.WritePort_Output((ushort)sCard, 0);
        }

        private void OutputSignal_Opened(int idx)
        {
            DASK.Check_Output[idx] = "1";
            DASK.WritePort_Output((ushort)sCard, 0);
        }

        private void OutputSignal_Closed(int idx)
        {
            DASK.Check_Output[idx] = "0";
            DASK.WritePort_Output((ushort)sCard, 0);
        }
        #endregion

        #region Input Check

        private void TmInputCheck_Elapsed(object sender, ElapsedEventArgs e)
        {
            DASK.ReadPort_Input((ushort)sCard, 0);

            for (int i = 0; i < 16; ++i)
            {
                if (DASK.Check_Input[i] != DASK.Input[i])
                {
                    if (inSignal[i].Polarity)
                    {
                        if (DASK.Check_Input[i] == "0" && DASK.Input[i] == "1")
                        {
                            DASK.Check_Input[i] = "1";
                            inSignal[i].OnSignal();
                        }
                        else if (DASK.Check_Input[i] == "1" && DASK.Input[i] == "0")
                        {
                            DASK.Check_Input[i] = "0";
                        }
                    }
                    else
                    {
                        if (DASK.Check_Input[i] == "1" && DASK.Input[i] == "0")
                        {
                            DASK.Check_Input[i] = "0";
                            inSignal[i].OnSignal();
                        }
                        else if (DASK.Check_Input[i] == "0" && DASK.Input[i] == "1")
                        {
                            DASK.Check_Input[i] = "1";
                        }
                    }

                }
            }

        }

        #endregion

        #region Output Check

        private void TmOuputCheck_Elapsed(object sender, ElapsedEventArgs e)
        {
            DASK.ReadPort_Output((ushort)sCard, 0);
        }

        #endregion

        #region Write Output

        private void WriteOuput()
        {

            DASK.WritePort_Output((ushort)sCard, 0);
        }

        #endregion

    }


    #region Signal Class

    public delegate void InputSignalEventHandler(int idx);
    public delegate void OutputSignalEventHandler(int idx);

    #region Input
    public class InputSignal
    {
        // 기본 생성자
        public InputSignal(int num)
        {
            InputNumber = num;
            Enable = true;
            Status = false;
            Polarity = true;
            DebounceTime = 1000;
            OutputSignal = -1;

            tm.Interval = DebounceTime;
            tm.AutoReset = false;
            tm.Elapsed += tm_Elapsed;
        }

        // 순번
        public int InputNumber { get; private set; }
        // 사용 유무
        public bool Enable { get; set; }
        // 활성화 상태
        public bool Status { get; private set; }
        // true = rising, false = falling
        public bool Polarity { get; set; }
        // 단위 ms
        public int DebounceTime { get; set; }
        // 몇 번째 아웃풋에 내보낼 껀지
        public int OutputSignal { get; set; }

        private Timer tm = new Timer();

        public event InputSignalEventHandler Occured;

        // 신호 발생
        public void OnSignal()
        {
            if (!Status)
            {
                Status = true;
                OnOccured(InputNumber);
                tm.Start();
            }
        }

        // Debounce Time 끝났을 경우
        private void tm_Elapsed(object sender, ElapsedEventArgs e)
        {

            Status = false;
        }

        // 신호 발생시
        private void OnOccured(int idx)
        {
            if (Occured != null)
            {
                Occured.Invoke(idx);
            }
        }

    }
    #endregion
    #region Output
    public class OutputSignal
    {


        public OutputSignal(int num)
        {
            OutputNumber = num;
            Enable = true;
            Status = false;
            Action = false;
            PulseWidth = 1000;

            tm.Interval = PulseWidth;
            tm.AutoReset = false;
            tm.Elapsed += tm_Elapsed;
        }



        // 순번
        public int OutputNumber { get; private set; }
        // 사용유무
        public bool Enable { get; set; }
        // 활성화 상태
        public bool Status { get; private set; }
        // Open, Close
        public bool Action { get; set; }
        // 단위 ms
        public int PulseWidth { get; set; }

        private Timer tm = new Timer();

        public event OutputSignalEventHandler Occured;
        public event OutputSignalEventHandler Open;
        public event OutputSignalEventHandler Close;

        // 신호 발생
        public void OnSignal()
        {
            if (!Action)
            {
                if (!Status)
                {
                    Status = true;
                    tm.Start();
                }
            }
        }

        // 신호 강제로 살림
        public void SignalOpen()
        {
            Action = true;
            OnOpen(OutputNumber);
        }

        // 신호 강제로 죽임
        public void SignalClose()
        {
            Action = false;
            OnClose(OutputNumber);
        }

        // Pulse Width 끝났을 경우
        private void tm_Elapsed(object sender, ElapsedEventArgs e)
        {
            Status = false;
            OnOccured(OutputNumber);
        }

        // 신호 발생시
        private void OnOccured(int idx)
        {
            if (Occured != null)
            {
                Occured.Invoke(idx);
            }
        }

        // Open 발생시
        private void OnOpen(int idx)
        {
            if (Open != null)
            {
                Open.Invoke(idx);
            }
        }

        // Close 발생시
        private void OnClose(int idx)
        {
            if (Close != null)
            {
                Close.Invoke(idx);
            }
        }



    }
    #endregion
    #endregion
}
