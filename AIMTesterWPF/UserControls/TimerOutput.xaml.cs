using System.Windows.Controls;
using System.Windows.Threading;

namespace AIMTesterWPF.UserControls
{
    /// <summary>
    /// Interaction logic for TimerOutput.xaml
    /// </summary>
    public partial class TimerOutput : UserControl
    {
        private DispatcherTimer timer = new DispatcherTimer();

        private int _seconds = 0;
        public int Seconds
        {
            get
            {
                return _seconds;
            }
            set
            {
                _seconds = value;
                timerTextblock.Text = Seconds.ToString();
                if (_seconds == -1)
                    OnTimerStoped();
            }
        }

        public event EventHandler? Stoped;

        protected virtual void OnTimerStoped()
        {
            if (Stoped != null) Stoped(this, EventArgs.Empty);
            timerTextblock.Text = "Stop!";
            timer.Stop();
        }

        public TimerOutput()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += TimerTick;
        }

        public void Start()
        {
            timer.Start();
        }

        private void TimerTick(object? sender, EventArgs e)
        {
            Seconds--;
        }
    }
}
