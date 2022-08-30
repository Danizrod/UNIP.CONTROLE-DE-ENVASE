namespace Unip.Tcc
{
    public partial class Form1 : Form
    {
        State _state = State.Zerado;
        decimal _initialTimer = 0;
        public System.Windows.Forms.Timer aTimer = new();


        public Form1()
        {
            InitializeComponent();

            aTimer.Tick += CallTimer;
            aTimer.Interval = 1000;
            aTimer.Enabled = true;
        }

        private void Cronometro_Click(object sender, EventArgs e)
        {
            _state = State.Funcionando;
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            _state = State.Zerado;
        }

        private void CallTimer(object sender, EventArgs e)
        {
            UpdateTimer();
        }

        private void UpdateTimer()
        {
            if (_state.Equals(State.Funcionando))
            {
                _initialTimer += 1;
            }
            else
            {
                _initialTimer = 0;
            }

            label2.Text = string.Format(_initialTimer.ToString());
        }
    }

    public enum State
    {
        Zerado,
        Funcionando,
        Pausado
    }
}