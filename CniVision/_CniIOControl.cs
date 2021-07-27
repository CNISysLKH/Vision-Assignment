using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Collections;
using System.Runtime.InteropServices;

namespace CniVision
{

    public class _CniIOControl
    {

        public static string[] Input = new string[16] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
        public static string[] Output = new string[16] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
        public static string[] Check_Input = new string[16] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
        public static string[] Check_Output = new string[16] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };


        // 초기화
        public _CniIOControl()
        {
            for (int i = 0; i < 16; ++i)
            {
                inSignal[i] = new InputSignal(i);
                outSignal[i] = new OutputSignal(i);

                inSignal[i].Enable = bool.Parse(CniIniControl.IniReadValue("INPUTSIGNAL", $"INPUT{i}_ENABLE"));
                inSignal[i].Polarity = bool.Parse(CniIniControl.IniReadValue("INPUTSIGNAL", $"INPUT{i}_POLARITY"));
                inSignal[i].DebounceTime = int.Parse(CniIniControl.IniReadValue("INPUTSIGNAL", $"INPUT{i}_DEBOUNCETIME"));
                //inSignal[i].OutputSignal = int.Parse(CniIniControl.IniReadValue("INPUTSIGNAL", $"INPUT{i}_OUTPUTSIGNAL"));

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

            sCard = CniIODllControl.Register_Card(CniIODllControl.PCI_7230, 0);
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

        private short sCard;
        private Timer tmInputCheck;
        private Timer tmOuputCheck;

        private InputSignal[] inSignal = new InputSignal[16];
        private OutputSignal[] outSignal = new OutputSignal[16];

        // I/O보드와 연결 상태
        public bool ConnectionStatus { get; set; }




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
        //public void SetInputToOutputSignal(int inNum, int outNum)
        //{
        //inSignal[inNum].OutputSignal = outNum;
        //CniIniControl.IniWriteValue("INPUTSIGNAL", $"INPUT{inNum}_OUTPUTSIGNAL", outNum.ToString());
        //}

        // Input에서 내보내는 Output 번호 가져오기
        //public int GetInputToOutputSignal(int inNum)
        //{
        //    return inSignal[inNum].OutputSignal;
        //}

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

            // 촬영 시작

            //int iSignal = inSignal[idx].OutputSignal;
            //Check_Output[iSignal] = "1";
            //outSignal[iSignal].OnSignal();
            //WritePort_Output((ushort)sCard, 0);
        }

        private void OutputSignal_Occured(int idx)
        {
            Check_Output[idx] = "0";
            CniIODllControl.WritePort_Output((ushort)sCard, 0, Check_Output);
        }

        private void OutputSignal_Opened(int idx)
        {
            Check_Output[idx] = "1";
            CniIODllControl.WritePort_Output((ushort)sCard, 0, Check_Output);
        }

        private void OutputSignal_Closed(int idx)
        {
            Check_Output[idx] = "0";
            CniIODllControl.WritePort_Output((ushort)sCard, 0, Check_Output);
        }
        #endregion

        #region Input Check

        private void TmInputCheck_Elapsed(object sender, ElapsedEventArgs e)
        {
            CniIODllControl.ReadPort_Input((ushort)sCard, 0, ref Input);

            for (int i = 0; i < 16; ++i)
            {
                if (Check_Input[i] != Input[i])
                {
                    if (inSignal[i].Polarity)
                    {
                        if (Check_Input[i] == "0" && Input[i] == "1")
                        {
                            Check_Input[i] = "1";
                            inSignal[i].OnSignal();
                        }
                        else if (Check_Input[i] == "1" && Input[i] == "0")
                        {
                            Check_Input[i] = "0";
                        }
                    }
                    else
                    {
                        if (Check_Input[i] == "1" && Input[i] == "0")
                        {
                            Check_Input[i] = "0";
                            inSignal[i].OnSignal();
                        }
                        else if (Check_Input[i] == "0" && Input[i] == "1")
                        {
                            Check_Input[i] = "1";
                        }
                    }

                }
            }

        }

        #endregion

        #region Output Check

        private void TmOuputCheck_Elapsed(object sender, ElapsedEventArgs e)
        {
            CniIODllControl.ReadPort_Output((ushort)sCard, 0, ref Output);
        }

        #endregion

        #region Write Output

        private void WriteOuput()
        {
            CniIODllControl.WritePort_Output((ushort)sCard, 0, Check_Output);
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
            //OutputSignal = -1;

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
        //public int OutputSignal { get; set; }

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

    public class CniIODllControl
    {

        public const ushort PCI_7230 = 6;


        [DllImport("PCI-Dask64.dll")]
        public static extern short Register_Card(ushort CardType, ushort card_num);
        [DllImport("PCI-Dask64.dll")]
        public static extern short Release_Card(ushort CardNumber);
        [DllImport("PCI-Dask64.dll")]
        public static extern short DO_WritePort(ushort CardNumber, byte Port, uint Value);
        [DllImport("PCI-Dask64.dll")]
        public static extern short DO_ReadPort(ushort CardNumber, ushort Port, out uint Value);
        [DllImport("PCI-Dask64.dll")]
        public static extern short DI_ReadPort(ushort CardNumber, ushort Port, out uint Value);


        public static short WritePort_Output(ushort CardNumber, byte Port, string[] CheckOutput)
        {

            string sValue = "";
            for (int i = 15; i >= 0; --i)
            {
                sValue += CheckOutput[i];
            }
            uint Value = (uint)Convert.ToInt16(sValue, 2);

            return DO_WritePort(CardNumber, Port, Value);
        }

        public static short ReadPort_Output(ushort CardNumber, byte Port, ref string[] Output)
        {
            short ret;
            uint in_Value;
            ret = DO_ReadPort(CardNumber, Port, out in_Value);

            string sValue = Convert.ToString(in_Value, 2).PadLeft(16, '0');

            for (int i = 15; i >= 0; --i)
            {
                Output[i] = sValue.Substring(15 - i, 1);

            }
            return ret;
        }

        public static short ReadPort_Input(ushort CardNumber, byte Port, ref string[] Input)
        {
            short ret;
            uint in_Value;
            ret = DI_ReadPort(CardNumber, Port, out in_Value);

            string sValue = Convert.ToString(in_Value, 2).PadLeft(16, '0');
            for (int i = 15; i >= 0; --i)
            {
                Input[i] = sValue.Substring(15 - i, 1);

            }
            return ret;
        }



    }
}
