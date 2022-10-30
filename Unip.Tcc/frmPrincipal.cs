using System.Runtime.InteropServices;
using System.IO.Ports;

namespace Unip.Tcc
{
    public partial class frmPrincipal : Form
    {
        #region Cronômetro
        State _state = State.Zerado;
        public decimal _timer = 0;
        public System.Windows.Forms.Timer aTimer = new();
        #endregion

        #region Arduino
        bool isConnected = false;
        string[] ports;
        SerialPort port;
        #endregion

        public DialogResult action = DialogResult.None;
        public DataValues dataValues = new();

        public int esteira1 = 0;
        public int esteira2 = 0;

        public frmPrincipal()
        {
            InitializeComponent();

            #region Configurações Visuais
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            pnlNav.Height = btnDashboard.Height;
            pnlNav.Top = btnDashboard.Top;
            pnlNav.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(46, 51, 73);

            lblInicio.Text = "Inicio";
            PnlFormLoader.Controls.Clear();
            frmInicio FrmDashboard_Vrb = new()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None
            };
            PnlFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
            #endregion

            #region Configurações de Cronômetro
            aTimer.Tick += CallTimer;
            aTimer.Interval = 1000;
            aTimer.Enabled = true;
            #endregion

            #region Configurações Arduino
            DisableControls();
            GetAvailableComPorts();

            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
                Console.WriteLine(port);
                if (ports[0] != null)
                {
                    comboBox1.SelectedItem = ports[0];
                }
            }
            #endregion
        }

        #region Configurações Visuais

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
        int nLeftRect,
        int nTopRect,
        int nRightRect,
        int nBottomRect,
        int nWidthEllipse,
        int nHightEllipse);

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDashboard.Height;
            pnlNav.Top = btnDashboard.Top;
            pnlNav.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(46, 51, 73);

            lblInicio.Text = "Inicio";
            PnlFormLoader.Controls.Clear();
            frmInicio FrmDashboard_Vrb = new()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None
            };
            PnlFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void BtnAnalytics_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnAnalytics.Height;
            pnlNav.Top = btnAnalytics.Top;
            btnAnalytics.BackColor = Color.FromArgb(46, 51, 73);

            lblInicio.Text = "Estatísticas";
            PnlFormLoader.Controls.Clear();
            frmEstatisticas FrmDashboard_Vrb = new(this)
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None
            };
            PnlFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void BtnCalendar_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnCalendar.Height;
            pnlNav.Top = btnCalendar.Top;
            btnCalendar.BackColor = Color.FromArgb(46, 51, 73);

            lblInicio.Text = "Atividade";
            PnlFormLoader.Controls.Clear();
            frmAtividade FrmDashboard_Vrb = new(this)
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None
            };
            PnlFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void BtnContact_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnContact.Height;
            pnlNav.Top = btnContact.Top;
            btnContact.BackColor = Color.FromArgb(46, 51, 73);

            lblInicio.Text = "Contato";
            PnlFormLoader.Controls.Clear();
            frmContato FrmDashboard_Vrb = new()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None
            };
            PnlFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void BtnDashboard_Leave(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void BtnAnalytics_Leave(object sender, EventArgs e)
        {
            btnAnalytics.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void BtnCalendar_Leave(object sender, EventArgs e)
        {
            btnCalendar.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void BtnContact_Leave(object sender, EventArgs e)
        {
            btnContact.BackColor = Color.FromArgb(24, 30, 54);
        }
        #endregion

        #region Configurações de Cronômetro
        private void CronometroStart()
        {
            _state = State.Funcionando;
        }

        public void CronometroStop()
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
                _timer += 1;
            }
            else
            {
                _timer = 0;
            }

            label2.Text = string.Format(_timer.ToString());
        }
        #endregion

        #region Configurações do Arduino

        private void Connect_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                ConnectToArduino();
            }
            else
            {
                DisconnectFromArduino(false);
            }
        }

        void GetAvailableComPorts()
        {
            ports = SerialPort.GetPortNames();
        }

        private void ConnectToArduino()
        {
            isConnected = true;
            string selectedPort = comboBox1.GetItemText(comboBox1.SelectedItem);
            port = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);

            try
            {
                if (port.IsOpen)
                {
                    port.Close();
                }

                port.Dispose();
                port.Open();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            connect.Text = "Desconectar";
            label8.Text = "Ligado";
            EnableControls();
        }

        public void DisconnectFromArduino(bool forcado)
        {
            if (!forcado)
                action = MessageBox.Show("Deseja mesmo desconectar? Desconectar-se causará a perda dos dados coletados no processo!", "Atenção!", MessageBoxButtons.YesNo);
            else
                action = DialogResult.Yes;

            if (action == DialogResult.Yes)
            {
                isConnected = false;
                connect.Text = "Conectar";
                label8.Text = "Desligado";
                port.Write("#PARARPROCESSO\n");
                port.Close();

                CronometroStop();
                DisableControls();
            }
        }

        private void EnableControls()
        {
            groupBox1.Enabled = true;
        }

        public void DisableControls()
        {
            groupBox1.Enabled = false;
            garrafa200mL.Checked = false;
            garrafa200mL.ForeColor = Color.White;
            garrafa300mL.Checked = false;
            garrafa300mL.ForeColor = Color.White;
        }

        public bool ArduinoIsConnected() => isConnected;

        public bool GarrafaSetada() => garrafa200mL.Checked || garrafa300mL.Checked;
        public SerialPort GetPortArduino() => port;

        #endregion

        #region Configurações de Funções p/ Arduino
        private void Garrafa200mLChecked(object sender, EventArgs e)
        {
            if (isConnected)
            {
                if (garrafa200mL.Checked)
                {
                    _timer = 0;
                    CronometroStart();
                    garrafa200mL.ForeColor = Color.FromArgb(0, 126, 249);
                    garrafa300mL.ForeColor = Color.White;
                    garrafa300mL.Checked = false;
                    port.Write("#GARRAFA200MLON\n");


                }
                else
                {
                    if (!garrafa300mL.Checked) CronometroStop();
                    garrafa200mL.ForeColor = Color.White;
                    port.Write("#GARRAFA200MLOFF\n");
                }
            }
        }

        private void Garrafa300mLChecked(object sender, EventArgs e)
        {
            if (isConnected)
            {
                if (garrafa300mL.Checked)
                {
                    _timer = 0;
                    CronometroStart();
                    garrafa300mL.ForeColor = Color.FromArgb(0, 126, 249);
                    garrafa200mL.ForeColor = Color.White;
                    garrafa200mL.Checked = false;
                    port.Write("#GARRAFA300MLON\n");
                }
                else
                {
                    if (!garrafa200mL.Checked) CronometroStop();
                    garrafa300mL.ForeColor = Color.White;
                    port.Write("#GARRAFA300MLOFF\n");
                }
            }
        }
        #endregion

        private void CloseApp(object sender, EventArgs e)
        {
            var finalizar = MessageBox.Show("Deseja finalizar o programa? O processo será finalizado!", "Atenção!", MessageBoxButtons.YesNo);
            if (finalizar == DialogResult.Yes)
            {
                if (ArduinoIsConnected())
                {
                    port.Write("#PARARPROCESSO\n");
                    DisableControls();
                }
                Application.Exit();
            }
        }
    }

    public enum State
    {
        Zerado,
        Funcionando,
        Pausado
    }

    public class DataValues
    {
        public string QntProd200 { get; set; } = "0";
        public string QntProd300 { get; set; } = "0";
        public string QntRej200 { get; set; } = "0";
        public string QntRej300 { get; set; } = "0";
        public string Energ200 { get; set; } = "0";
        public string Energ200Monetario { get; set; } = "0";
        public string Energ300 { get; set; } = "0";
        public string Energ300Monetario { get; set; } = "0";
        public string Litros200 { get; set; } = "0";
        public string Litros300 { get; set; } = "0";

    }
}