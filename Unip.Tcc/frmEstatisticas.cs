using System.IO.Ports;
using static System.Net.Mime.MediaTypeNames;

namespace Unip.Tcc
{
    public partial class frmEstatisticas : Form
    {
        #region Timer
        public System.Windows.Forms.Timer aTimer = new();
        #endregion
        private readonly frmPrincipal _frmPrincipal;

        public frmEstatisticas(frmPrincipal frmPrincipal)
        {
            InitializeComponent();

            _frmPrincipal = frmPrincipal;
            update.Enabled = false;
            update.BackColor = Color.Firebrick;


            #region Configurações de Cronômetro
            aTimer.Tick += CheckData;
            aTimer.Interval = 200;
            aTimer.Enabled = true;
            #endregion
        }

        private void CheckData(object sender, EventArgs e)
        {
            if (!_frmPrincipal.ArduinoIsConnected())
            {
                update.Enabled = false;
                update.BackColor = Color.Firebrick;

                if (_frmPrincipal.action == DialogResult.Yes)
                {
                    _frmPrincipal.action = DialogResult.None;
                    //ResetValues();
                }

                RecoverData();

            }
            else
            {
                if (_frmPrincipal.GarrafaSetada())
                {
                    update.Enabled = true;
                    update.BackColor = Color.CornflowerBlue;
                }

                RecoverData();
            }
        }

        private void UpdateValues(object sender, EventArgs e)
        {
            if (_frmPrincipal.ArduinoIsConnected())
            {
                ExecutaAtualizacao();
                RecoverData();
            }
        }

        private void ExecutaAtualizacao()
        {
            var port = _frmPrincipal.GetPortArduino();
            var command = "#CHECARDADOS\n";
            port.Write(command);

            var resp = port.ReadLine();

            SaveData(resp);
        }

        private void SaveData(string valores)
        {
            if (valores.Contains("GE2:") && valores.Contains(".GE3:") &&
                valores.Contains(".GD2:") && valores.Contains(".GD3:"))
            {
                var qP2 = valores.Substring(valores.LastIndexOf("GE2:") + 4, valores.IndexOf(".GE3:") - (valores.LastIndexOf("GE2:") + 4));
                _frmPrincipal.dataValues.QntProd200 = qP2;
                var qP3 = valores.Substring(valores.LastIndexOf(".GE3:") + 5, valores.IndexOf(".GD2:") - (valores.LastIndexOf(".GE3:") + 5));
                _frmPrincipal.dataValues.QntProd300 = qP3;
                var qR2 = valores.Substring(valores.LastIndexOf(".GD2:") + 5, valores.IndexOf(".GD3:") - (valores.LastIndexOf(".GD2:") + 5));
                _frmPrincipal.dataValues.QntRej200 = qR2;
                var qR3 = valores.Substring(valores.LastIndexOf(".GD3:") + 5, valores.IndexOf("\r") - (valores.LastIndexOf(".GD3:") + 5));
                _frmPrincipal.dataValues.QntRej300 = qR3;

                _frmPrincipal.dataValues.Energ200 = energ200.Text;
                _frmPrincipal.dataValues.Energ300 = energ300.Text;
                _frmPrincipal.dataValues.Litros200 = litros200.Text;
                _frmPrincipal.dataValues.Litros300 = litros300.Text;
            }
            else
            {
                ExecutaAtualizacao();
            }
        }

        private void RecoverData()
        {
            qntProd200.Text = _frmPrincipal.dataValues.QntProd200;
            qntProd300.Text = _frmPrincipal.dataValues.QntProd300;
            qntRej200.Text = _frmPrincipal.dataValues.QntRej200;
            qntRej300.Text = _frmPrincipal.dataValues.QntRej300;
            energ200.Text = _frmPrincipal.dataValues.Energ200;
            energ300.Text = _frmPrincipal.dataValues.Energ300;
            litros200.Text = _frmPrincipal.dataValues.Litros200;
            litros300.Text = _frmPrincipal.dataValues.Litros300;
        }

        private void ResetValues()
        {
            _frmPrincipal.dataValues = new();
        }

        private void GenerateExcel(object sender, EventArgs e)
        {

        }
    }
}
