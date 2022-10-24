using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2016.Excel;
using OfficeOpenXml;
using System.IO.Packaging;


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
            var data = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
            var horario = DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;
            using SaveFileDialog saveFileDialog = new()
            {
                Filter = "Planilha Excel | *.xlsx*",
                AddExtension = true,
                FileName = "Dados_Coletados_" + data + "_as_" + horario
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var fileInfo = new FileInfo(saveFileDialog.FileName + ".xlsx");
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using ExcelPackage package = new(fileInfo);

                    CriaPastaDeTrabalho(package);

                    package.Save();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static void CriaPastaDeTrabalho(ExcelPackage package)
        {
            var sheet = package.Workbook.Worksheets.Add("Dados Coletados");
            CriaCabecalhos(sheet);



            var row = 4;

            sheet.Cells[1, 1, 7, 7].AutoFitColumns();
        }

        private static void CriaCabecalhos(ExcelWorksheet sheet)
        {
            sheet.Cells["A1"].Value = "Relatório";
            sheet.Cells["B1"].Value = "Dados Importados";

            sheet.Cells["D1"].Value = "Data";
            sheet.Cells["E1"].Value = DateTime.Now;
            sheet.Cells["E1"].Style.Numberformat.Format = "dd/MM/yyyy";

            sheet.Cells["B3"].Value = "Garrafa 200mL";
            sheet.Cells["C3"].Value = "Garrafa 300mL";
            sheet.Cells["A4"].Value = "Quantidade Produzida";
            sheet.Cells["A5"].Value = "Quantidade Rejeitada";
            sheet.Cells["A6"].Value = "Energia Gasta";
            sheet.Cells["A7"].Value = "Litros Envazados";

            XLSHelper.SetRangeBorderAndBackground(sheet.Cells["A1"]);
            XLSHelper.FillBorders(sheet.Cells["A1:B1"]);
            XLSHelper.SetRangeBorderAndBackground(sheet.Cells["D1"]);
            XLSHelper.FillBorders(sheet.Cells["D1:E1"]);

            XLSHelper.SetRangeAsHeader(sheet.Cells[3, 1, 3, 3]);
            XLSHelper.FillBorders(sheet.Cells[3, 1, 3, 3]);

            XLSHelper.SetRangeAsHeader(sheet.Cells[3, 1, 7, 1]);
            XLSHelper.FillBorders(sheet.Cells[3, 1, 7, 1]);
        }
    }
}
