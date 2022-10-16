using System.IO.Ports;
using System.Runtime.InteropServices;

namespace Unip.Tcc
{
    public partial class frmAtividade : Form
    {
        #region Timer
        public System.Windows.Forms.Timer aTimer = new();
        #endregion
        private readonly frmPrincipal _frmPrincipal;
        public int esteira1 = 0;
        public int esteira2 = 0;

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public frmAtividade(frmPrincipal frmPrincipal)
        {
            InitializeComponent();

            _frmPrincipal = frmPrincipal;
            //#region Configurações de Cronômetro
            //aTimer.Tick += TerminalPrintData;
            //aTimer.Interval = 1000;
            //aTimer.Enabled = true;
            //#endregion

        }

        private void TerminalPrintData(object sender, EventArgs e)
        {
            if (_frmPrincipal.ArduinoIsConnected())
            {
                var port = _frmPrincipal.GetPortArduino();
                var teste = port.ReadLine();
            }
        }

        private void AumentaVelocidadeEsteira1(object sender, EventArgs e)
        {
            if (_frmPrincipal.ArduinoIsConnected())
            {
                if (esteira1 == 3)
                {
                    increase1.Enabled = false;
                    decrease1.Enabled = true;
                }
                else
                {
                    increase1.Enabled = true;
                    decrease1.Enabled = true;
                }

                if (esteira1 < 3)
                {
                    esteira1 += 1;
                }

                var port = _frmPrincipal.GetPortArduino();
                port.Write("#ESTEIRA1V" + esteira1 + "\n");
                velocidade1.Text = esteira1.ToString();

                if (esteira1 == 3)
                {
                    increase1.Enabled = false;
                    decrease1.Enabled = true;
                }
                else
                {
                    increase1.Enabled = true;
                    decrease1.Enabled = true;
                }
            }
            else
            {
                esteira1 = 0;
            }
        }

        private void DiminuiVelocidadeEsteira1(object sender, EventArgs e)
        {
            if (_frmPrincipal.ArduinoIsConnected())
            {
                if (esteira1 == 0)
                {
                    decrease1.Enabled = false;
                    increase1.Enabled = true;
                }
                else
                {
                    decrease1.Enabled = true;
                    increase1.Enabled = true;
                }

                if (esteira1 > 0)
                {
                    esteira1 -= 1;
                }


                var port = _frmPrincipal.GetPortArduino();
                port.Write("#ESTEIRA1V" + esteira1 + "\n");
                velocidade1.Text = esteira1.ToString();

                if (esteira1 == 0)
                {
                    decrease1.Enabled = false;
                    increase1.Enabled = true;
                }
                else
                {
                    decrease1.Enabled = true;
                    increase1.Enabled = true;
                }
            }
            else
            {
                esteira1 = 0;
            }
        }

        private void AumentaVelocidadeEsteira2(object sender, EventArgs e)
        {
            if (_frmPrincipal.ArduinoIsConnected())
            {
                if (esteira2 == 3)
                {
                    increase2.Enabled = false;
                    decrease2.Enabled = true;
                }
                else
                {
                    increase2.Enabled = true;
                    decrease2.Enabled = true;
                }

                if (esteira2 < 3)
                {
                    esteira2 += 1;
                }

                var port = _frmPrincipal.GetPortArduino();
                port.Write("#ESTEIRA2V" + esteira2 + "\n");
                velocidade2.Text = esteira2.ToString();

                if (esteira2 == 3)
                {
                    increase2.Enabled = false;
                    decrease2.Enabled = true;
                }
                else
                {
                    increase2.Enabled = true;
                    decrease2.Enabled = true;
                }
            }
            else
            {
                esteira2 = 0;
            }
        }

        private void DiminuiVelocidadeEsteira2(object sender, EventArgs e)
        {
            if (_frmPrincipal.ArduinoIsConnected())
            {
                if (esteira2 == 0)
                {
                    decrease2.Enabled = false;
                    increase2.Enabled = true;
                }
                else
                {
                    decrease2.Enabled = true;
                    increase2.Enabled = true;
                }

                if (esteira2 > 0)
                {
                    esteira2 -= 1;
                }

                var port = _frmPrincipal.GetPortArduino();
                port.Write("#ESTEIRA2V" + esteira2 + "\n");
                velocidade2.Text = esteira2.ToString();

                if (esteira2 == 0)
                {
                    decrease2.Enabled = false;
                    increase2.Enabled = true;
                }
                else
                {
                    decrease2.Enabled = true;
                    increase2.Enabled = true;
                }
            }
            else
            {
                esteira2 = 0;
            }
        }
    }
}