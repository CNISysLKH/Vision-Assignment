using System.Timers;

namespace CniVision.IO
{

    public delegate void InputSignalEventHandler(int num);
    public class CniInputSignal
    {

        /// <summary>
        /// Input 신호 번호
        /// </summary>
        public int Number { get; private set; }
        /// <summary>
        /// 트리거 사용 여부
        /// </summary>
        public bool TriggerEnable { get; set; }
        /// <summary>
        /// 활성화 상태
        /// </summary>
        public bool Status { get; private set; }
        /// <summary>
        /// 신호 활성화 기준
        /// True = Rising
        /// False = Falling
        /// </summary>
        public bool Polarity { get; set; }
        /// <summary>
        /// 활성화 시간
        /// (기준 ms)
        /// </summary>
        public int DebounceTime { get; set; }


        /// <summary>
        /// Input 신호 생성자
        /// </summary>
        /// <param name="num">Input 신호 순번</param>
        public CniInputSignal(int num)
        {
            Number = num;
            Status = false;
            Polarity = true;
            DebounceTime = 5;

            tm.Interval = DebounceTime;
            tm.AutoReset = false;
            tm.Elapsed += Elapsed;
        }


        /// <summary>
        /// 활성 시간 체크 Timer
        /// </summary>
        private Timer tm = new Timer();



        /// <summary>
        /// 활성 이벤트
        /// </summary>
        public event InputSignalEventHandler Occured;


        /// <summary>
        /// 신호 발생
        /// </summary>
        public void Occur()
        {
            if (!Status)                    // 비활성화 되어있을 경우에만 활성화
            {
                Status = true;
                tm.Start();
            }
        }


        /// <summary>
        /// 신호 발생 이벤트
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
        /// 타이머 완료 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Elapsed(object sender, ElapsedEventArgs e)
        {
            Status = false;
            OnOccured(Number);
        }

    }
}
