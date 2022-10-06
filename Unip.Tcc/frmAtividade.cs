using System.IO.Ports;

namespace Unip.Tcc
{
    public partial class frmAtividade : Form
    {
        bool isConnected = false;
        string[] ports;
        SerialPort port;

        public frmAtividade()
        {
            InitializeComponent();
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
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                ConnectToArduino();
            }
            else
            {
                DisconnectFromArduino();
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
            port.Open();
            port.Write("#STAR\n");
            connect.Text = "Disconnect";
            EnableControls();
        }

        private void Led1CheckboxClicked(object sender, EventArgs e)

        {
            if (isConnected)
            {
                if (led1.Checked)
                {
                    port.Write("#LED1ON\n");
                }
                else
                {
                    port.Write("#LED1OF\n");
                }
            }
        }

        private void Led2CheckboxClicked(object sender, EventArgs e)

        {
            if (isConnected)
            {
                if (led2.Checked)
                {
                    port.Write("#LED2ON\n");
                }
                else
                {
                    port.Write("#LED2OF\n");
                }
            }
        }

        private void Led3CheckboxClicked(object sender, EventArgs e)

        {
            if (isConnected)
            {
                if (led3.Checked)
                {
                    port.Write("#LED3ON\n");
                }
                else
                {
                    port.Write("#LED3OF\n");
                }
            }
        }

        private void DisconnectFromArduino()
        {
            isConnected = false;
            port.Write("#STOP\n");
            port.Close();
            connect.Text = "Conectar";
            DisableControls();
            ResetDefaults();
        }

        private void EnableControls()
        {
            led1.Enabled = true;
            led2.Enabled = true;
            led3.Enabled = true;
            groupBox1.Enabled = true;
        }

        private void DisableControls()
        {
            led1.Enabled = false;
            led2.Enabled = false;
            led3.Enabled = false;
            groupBox1.Enabled = false;
        }

        private void ResetDefaults()
        {
            led1.Checked = false;
            led2.Checked = false;
            led3.Checked = false;

        }
    }
}
