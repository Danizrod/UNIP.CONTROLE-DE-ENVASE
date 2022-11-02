using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using Color = System.Drawing.Color;

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

                _frmPrincipal.dataValues.Energ200 = _frmPrincipal.garrafa200mL.Checked ? Convert.ToString(CalculoEnergia("energia")) : energ200.Text;
                _frmPrincipal.dataValues.Energ300 = _frmPrincipal.garrafa300mL.Checked ? Convert.ToString(CalculoEnergia("energia")) : energ300.Text;
                _frmPrincipal.dataValues.Energ200Monetario = _frmPrincipal.garrafa200mL.Checked ? Convert.ToString(CalculoEnergia("financeiro")) : _frmPrincipal.dataValues.Energ200Monetario;
                _frmPrincipal.dataValues.Energ300Monetario = _frmPrincipal.garrafa300mL.Checked ? Convert.ToString(CalculoEnergia("financeiro")) : _frmPrincipal.dataValues.Energ300Monetario;
                _frmPrincipal.dataValues.Litros200 = Convert.ToString(Convert.ToDecimal(qP2) * 0.2M);
                _frmPrincipal.dataValues.Litros300 = Convert.ToString(Convert.ToDecimal(qP3) * 0.3M);
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
            energ200.Text = _frmPrincipal.dataValues.Energ200Monetario;
            energ300.Text = _frmPrincipal.dataValues.Energ300Monetario;
            litros200.Text = _frmPrincipal.dataValues.Litros200;
            litros300.Text = _frmPrincipal.dataValues.Litros300;
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

        private void CriaPastaDeTrabalho(ExcelPackage package)
        {
            var sheet = package.Workbook.Worksheets.Add("Dados Coletados");
            CriaCabecalhos(sheet);

            sheet.Cells["B4"].Value = Convert.ToDecimal(_frmPrincipal.dataValues.QntProd200);
            sheet.Cells["B5"].Value = Convert.ToDecimal(_frmPrincipal.dataValues.QntRej200);
            sheet.Cells["B6"].Value = Convert.ToDecimal(_frmPrincipal.dataValues.Energ200);
            sheet.Cells["B7"].Value = Convert.ToDecimal(_frmPrincipal.dataValues.Energ200Monetario);
            sheet.Cells["B8"].Value = Convert.ToDecimal(_frmPrincipal.dataValues.Litros200);

            sheet.Cells["C4"].Value = Convert.ToDecimal(_frmPrincipal.dataValues.QntProd300);
            sheet.Cells["C5"].Value = Convert.ToDecimal(_frmPrincipal.dataValues.QntRej300);
            sheet.Cells["C6"].Value = Convert.ToDecimal(_frmPrincipal.dataValues.Energ300);
            sheet.Cells["C7"].Value = Convert.ToDecimal(_frmPrincipal.dataValues.Energ300Monetario);
            sheet.Cells["C8"].Value = Convert.ToDecimal(_frmPrincipal.dataValues.Litros300);

            var columnChart = sheet.Drawings.AddBarChart("crtExtensionsSize", eBarChartType.ColumnClustered3D);
            columnChart.SetSize(520, 310);
            columnChart.SetPosition(45, 255);
            columnChart.Title.Text = "";
            columnChart.Series.Add(ExcelCellBase.GetAddress(4, 2, 8, 2), ExcelCellBase.GetAddress(4, 1, 8, 1));
            columnChart.Series[0].Header = "Garrafa 200mL";
            columnChart.Series.Add(ExcelCellBase.GetAddress(4, 3, 8, 3), ExcelCellBase.GetAddress(4, 1, 8, 1));
            columnChart.Series[1].Header = "Garrafa 300mL";

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
            sheet.Cells["A6"].Value = "Energia Gasta (kWh)";
            sheet.Cells["A7"].Value = "Energia Gasta (R$)";
            sheet.Cells["A8"].Value = "Litros Envasados";


            XLSHelper.SetRangeBorderAndBackground(sheet.Cells["A1"]);
            XLSHelper.FillBorders(sheet.Cells["A1:B1"]);
            XLSHelper.SetRangeBorderAndBackground(sheet.Cells["D1"]);
            XLSHelper.FillBorders(sheet.Cells["D1:E1"]);

            XLSHelper.SetRangeAsHeader(sheet.Cells[3, 1, 3, 3]);
            XLSHelper.FillBorders(sheet.Cells[3, 1, 3, 3]);

            XLSHelper.SetRangeAsHeader(sheet.Cells[3, 1, 8, 1]);
            XLSHelper.FillBorders(sheet.Cells[3, 1, 8, 1]);
        }

        private void ResetaValores(object sender, EventArgs e)
        {
            var port = _frmPrincipal.GetPortArduino();
            var command = "#RESETAR\n";
            port.Write(command);

            _frmPrincipal.dataValues = new();
        }

        private decimal CalculoEnergia(string retorno)
        {
            //Calculo executado com valores p/ mês de Novembro

            var segundos = _frmPrincipal._timer / 3600M;
            var consumoForaPonta = (0.25M + 0.1506M) * segundos;
            var consumoPonta = 0.26M * consumoForaPonta;
            var cip = 6M;
            var aliquotaICMS = 0.18M;
            var aliquotaPIS = 0.0368M;
            var totalImpostosICMS = consumoPonta / (1 - aliquotaPIS - aliquotaICMS) * aliquotaICMS;
            var totalImpostosPIS = consumoPonta / (1 - aliquotaICMS - aliquotaPIS) * aliquotaPIS;
            var totalMonetario = totalImpostosICMS + totalImpostosPIS + cip + consumoPonta;

            if (retorno == "energia")
            {
                return Math.Round(consumoPonta, 2);
            }
            else
            {
                return Math.Round(totalMonetario, 2);
            }
        }
    }
}
