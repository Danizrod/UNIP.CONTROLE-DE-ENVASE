using System;
using System.IO.Ports;
using System.Runtime.InteropServices;

namespace Unip.Tcc
{
    public partial class frmAtividade : Form
    {
        private readonly frmPrincipal _frmPrincipal;

        public frmAtividade(frmPrincipal frmPrincipal)
        {
            InitializeComponent();

            _frmPrincipal = frmPrincipal;

            velocidade1.Text = _frmPrincipal.esteira1.ToString();
            velocidade2.Text = _frmPrincipal.esteira2.ToString();

            VerificarVelocidades();
        }

        private void VerificarVelocidades()
        {
            if (_frmPrincipal.esteira1 == 3)
            {
                increase1.Enabled = false;
                decrease1.Enabled = true;
            }
            else if (_frmPrincipal.esteira1 == 0)
            {
                increase1.Enabled = true;
                decrease1.Enabled = false;
            }
            else
            {
                increase1.Enabled = true;
                decrease1.Enabled = true;
            }

            if (_frmPrincipal.esteira2 == 3)
            {
                increase2.Enabled = false;
                decrease2.Enabled = true;
            }
            else if (_frmPrincipal.esteira2 == 0)
            {
                increase2.Enabled = true;
                decrease2.Enabled = false;
            }
            else
            {
                increase2.Enabled = true;
                decrease2.Enabled = true;
            }
        }

        private void AumentaVelocidadeEsteira1(object sender, EventArgs e)
        {
            if (_frmPrincipal.ArduinoIsConnected())
            {
                if (_frmPrincipal.esteira1 == 3)
                {
                    increase1.Enabled = false;
                    decrease1.Enabled = true;
                }
                else
                {
                    increase1.Enabled = true;
                    decrease1.Enabled = true;
                }

                if (_frmPrincipal.esteira1 < 3)
                {
                    _frmPrincipal.esteira1 += 1;
                }

                var port = _frmPrincipal.GetPortArduino();
                var command = "#ESTEIRA1V" + _frmPrincipal.esteira1 + "\n";
                port.Write(command);
                velocidade1.Text = _frmPrincipal.esteira1.ToString();

                if (_frmPrincipal.esteira1 == 3)
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
                _frmPrincipal.esteira1 = 0;
            }
        }

        private void DiminuiVelocidadeEsteira1(object sender, EventArgs e)
        {
            if (_frmPrincipal.ArduinoIsConnected())
            {
                if (_frmPrincipal.esteira1 == 0)
                {
                    decrease1.Enabled = false;
                    increase1.Enabled = true;
                }
                else
                {
                    decrease1.Enabled = true;
                    increase1.Enabled = true;
                }

                if (_frmPrincipal.esteira1 > 0)
                {
                    _frmPrincipal.esteira1 -= 1;
                }


                var port = _frmPrincipal.GetPortArduino();
                var command = "#ESTEIRA1V" + _frmPrincipal.esteira1 + "\n";
                port.Write(command);
                velocidade1.Text = _frmPrincipal.esteira1.ToString();

                if (_frmPrincipal.esteira1 == 0)
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
                _frmPrincipal.esteira1 = 0;
            }
        }

        private void AumentaVelocidadeEsteira2(object sender, EventArgs e)
        {
            if (_frmPrincipal.ArduinoIsConnected())
            {
                if (_frmPrincipal.esteira2 == 3)
                {
                    increase2.Enabled = false;
                    decrease2.Enabled = true;
                }
                else
                {
                    increase2.Enabled = true;
                    decrease2.Enabled = true;
                }

                if (_frmPrincipal.esteira2 < 3)
                {
                    _frmPrincipal.esteira2 += 1;
                }

                var port = _frmPrincipal.GetPortArduino();
                var command = "#ESTEIRA2V" + _frmPrincipal.esteira2 + "\n";
                port.Write(command);
                velocidade2.Text = _frmPrincipal.esteira2.ToString();

                if (_frmPrincipal.esteira2 == 3)
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
                _frmPrincipal.esteira2 = 0;
            }
        }

        private void DiminuiVelocidadeEsteira2(object sender, EventArgs e)
        {
            if (_frmPrincipal.ArduinoIsConnected())
            {
                if (_frmPrincipal.esteira2 == 0)
                {
                    decrease2.Enabled = false;
                    increase2.Enabled = true;
                }
                else
                {
                    decrease2.Enabled = true;
                    increase2.Enabled = true;
                }

                if (_frmPrincipal.esteira2 > 0)
                {
                    _frmPrincipal.esteira2 -= 1;
                }

                var port = _frmPrincipal.GetPortArduino();
                var command = "#ESTEIRA2V" + _frmPrincipal.esteira2 + "\n";
                port.Write(command);
                velocidade2.Text = _frmPrincipal.esteira2.ToString();

                if (_frmPrincipal.esteira2 == 0)
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
                _frmPrincipal.esteira2 = 0;
            }
        }

        private void PararEnvase(object sender, EventArgs e)
        {
            if (_frmPrincipal.ArduinoIsConnected())
            {
                var port = _frmPrincipal.GetPortArduino();
                var command = "#PARARENVASE\n";
                port.Write(command);
            }
        }

        private void PararEsteiras(object sender, EventArgs e)
        {
            if (_frmPrincipal.ArduinoIsConnected())
            {
                _frmPrincipal.esteira1 = 0;
                _frmPrincipal.esteira2 = 0;

                velocidade1.Text = _frmPrincipal.esteira1.ToString();
                velocidade2.Text = _frmPrincipal.esteira2.ToString();

                _frmPrincipal.DisconnectFromArduino(true);
            }
        }
    }
}