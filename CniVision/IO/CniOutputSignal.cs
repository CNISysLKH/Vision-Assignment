using System.Timers;

namespace CniVision.IO
{
    public delegate void OutputSignalEventHandler(int num);

    public class CniOutputSignal
    {
        /// <summary>
        /// Output 신호 번호
        /// </summary>
        public int Number { get; private set; }
        /// <summary>
        /// Read 일 때 신호 활성화
        /// </summary>
        public bool ReadEnable { get; set; }
        /// <summary>
        /// No Read 일 때 신호 활성화
        /// </summary>
        public bool NoReadEnable { get; set; }
        /// <summary>
        /// 활성화 상태
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 활성화 상태 강제
        /// True = open
        /// False = close
        /// </summary>
        public bool Action { get; set; }
        /// <summary>
        /// 활성화 시간
        /// 기준(ms)
        /// </summary>
        public int PulseWidth { get; set; }


        /// <summary>
        /// Output 신호 생성자
        /// </summary>
        /// <param name="num">Output 신호 순번</param>
        public CniOutputSignal(int num)
        {
            Number = num;
            Status = false;
            Action = false;
            PulseWidth = 5;


            tm.Interval = PulseWidth;
            tm.AutoReset = false;
            tm.Elapsed += Elapsed;
        }

        /// <summary>
        /// 신호 활성화 체크 Timer
        /// </summary>
        private Timer tm = new Timer();

        /// <summary>
        /// 신호 발생 이벤트
        /// </summary>
        public event OutputSignalEventHandler Occured;
        /// <summary>
        /// Open 발생 이벤트
        /// </summary>
        public event OutputSignalEventHandler Opened;
        /// <summary>
        /// Close 발생 이벤트
        /// </summary>
        public event OutputSignalEventHandler Closed;


        /// <summary>
        /// 신호 발생 함수
        /// </summary>
        public void Occur()
        {
            if (Action) return;                         // Open시 미사용
            if (!Status)                                // 신호가 미사용일 때 사용
            {
                Status = false;
                tm.Start();
            }
        }

        /// <summary>
        /// Open 발생 함수
        /// </summary>
        public void Open()
        {
            if (!Action)
            {
                Action = true;
                OnOpened(Number);
            }
        }

        /// <summary>
        /// Close 발생 함수
        /// </summary>
        public void Close()
        {
            if (Action)
            {
                Action = false;
                OnClosed(Number);
            }
        }

        /// <summary>
        /// Timer 완료 시 발생 이벤트 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Elapsed(object sender, ElapsedEventArgs e)
        {
            Status = false;
            OnOccured(Number);
        }

        /// <summary>
        /// 신호 발생 시 발생 이벤트 함수
        /// </summary>
        /// <param name="num"></param>
        private void OnOccured(int num)
        {
            if (Occured != null)
            {
                Occured.Invoke(num);
            }
        }

        /// <summary>
        /// Open 발생 시 발생 이벤트 함수
        /// </summary>
        /// <param name="num"></param>
        private void OnOpened(int num)
        {
            if (Opened != null)
            {
                Opened.Invoke(num);
            }
        }

        /// <summary>
        /// Close 발생 시 발생 이벤트 함수
        /// </summary>
        /// <param name="num"></param>
        private void OnClosed(int num)
        {
            if (Closed != null)
            {
                Closed.Invoke(num);
            }
        }
    }
}
