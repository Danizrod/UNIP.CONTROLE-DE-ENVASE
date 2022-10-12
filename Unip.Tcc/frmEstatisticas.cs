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
            #region Configurações de Cronômetro
            aTimer.Tick += UpdateValues;
            aTimer.Interval = 200;
            aTimer.Enabled = true;
            #endregion

        }

        private void UpdateValues(object sender, EventArgs e)
        {
            if (_frmPrincipal.ArduinoIsConnected())
            {
                //Fazer funções p/ capturar dados seriais que o arduino manda e preencher dados de tela

                SaveData();
            }
            else
            {
                if (_frmPrincipal.action == DialogResult.Yes)
                {
                    _frmPrincipal.action = DialogResult.None;
                    ResetValues();
                } 
                else if(_frmPrincipal.action == DialogResult.No)
                {
                    RecoverData();
                }
            }
        }

        private void SaveData()
        {
            _frmPrincipal.dataValues.QntProd200 = qntProd200.Text;
            _frmPrincipal.dataValues.QntProd300 = qntProd300.Text;
            _frmPrincipal.dataValues.QntRej200 = qntRej200.Text;
            _frmPrincipal.dataValues.QntRej300 = qntRej300.Text;
            _frmPrincipal.dataValues.Energ200 = energ200.Text;
            _frmPrincipal.dataValues.Energ300 = energ300.Text;
            _frmPrincipal.dataValues.Litros200 = litros200.Text;
            _frmPrincipal.dataValues.Litros300 = litros300.Text;
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
            qntProd200.Text = "0";
            qntProd300.Text = "0";
            qntRej200.Text = "0";
            qntRej300.Text = "0";
            energ200.Text = "0";
            energ300.Text = "0";
            litros200.Text = "0";
            litros300.Text = "0";
        }

        private void GenerateExcel(object sender, EventArgs e)
        {

        }
    }
}
