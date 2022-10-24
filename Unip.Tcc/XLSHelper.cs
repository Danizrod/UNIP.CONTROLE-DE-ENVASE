using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Unip.Tcc
{
    public class XLSHelper
    {
        private static readonly Color GreenBackgroundColor = ColorTranslator.FromHtml("#59bd7b");
        private static readonly Color GrayBackgroundColor = ColorTranslator.FromHtml("#d3d3d3");
        private static readonly Color LightRedBackgroundColor = ColorTranslator.FromHtml("#ff6666");
        private static readonly Color RedBackgroundColor = ColorTranslator.FromHtml("#ff0000");

        public static void FillBorders(ExcelRange cells)
        {
            cells.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            cells.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            cells.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            cells.Style.Border.Right.Style = ExcelBorderStyle.Thin;
        }

        public static void SetColumnsToCurrency(ExcelWorksheet sheet, int[] columns)
        {
            foreach (var i in columns)
            {
                sheet.Column(i).Style.Numberformat.Format = @"#,##0.00";
                sheet.Column(i).Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            }
        }

        public static void SetColumnsAlignToCenter(ExcelWorksheet sheet, int[] columns)
        {
            foreach (var i in columns)
                sheet.Column(i).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        }

        public static void SetColumnToPercentage(ExcelColumn column)
        {
            column.Style.Numberformat.Format = @"0.00%";
            column.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
        }

        public static void SetColumnToCenter(ExcelColumn column)
        {
            column.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        }

        public static void SetColumnToCurrency(ExcelColumn column)
        {
            column.Style.Numberformat.Format = @"#,##0.00";
            column.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
        }

        public static void SetColumnAsForward(ExcelColumn column)
        {
            column.Style.Numberformat.Format = @"#,##0.0000";
            column.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
        }

        public static void SetColumnAsDate(ExcelColumn column)
        {
            column.Style.Numberformat.Format = "dd/mm/yyyy";
            column.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
        }

        public static void SetCellsAsDate(ExcelRange cells)
        {
            cells.Style.Numberformat.Format = "dd/MM/yyyy";
            cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
        }

        public static void SetColumnAsForward(ExcelColumn column, int qtd)
        {
            var zero = "".PadLeft(qtd, '0');
            column.Style.Numberformat.Format = $"#,##0.{zero}";
            column.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
        }

        public static void SetRangeAsHeader(ExcelRange cells)
        {
            cells.Style.Fill.PatternType = ExcelFillStyle.Solid;
            cells.Style.Fill.BackgroundColor.SetColor(GreenBackgroundColor);
            cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        }

        public static void SetRowAsSimulation(ExcelRange cells)
        {
            cells.Style.Fill.PatternType = ExcelFillStyle.Solid;
            cells.Style.Fill.BackgroundColor.SetColor(GrayBackgroundColor);
        }

        public static void SetRowAsOldFundSimulation(ExcelRange cells)
        {
            cells.Style.Fill.PatternType = ExcelFillStyle.Solid;
            cells.Style.Fill.BackgroundColor.SetColor(RedBackgroundColor);
        }

        public static void SetRowAsOldFund(ExcelRange cells)
        {
            cells.Style.Fill.PatternType = ExcelFillStyle.Solid;
            cells.Style.Fill.BackgroundColor.SetColor(LightRedBackgroundColor);
        }

        public static void SetRangeBorderAndBackground(ExcelRange cells)
        {
            cells.Style.Fill.PatternType = ExcelFillStyle.Solid;
            cells.Style.Fill.BackgroundColor.SetColor(GreenBackgroundColor);
        }

        public static void SetRangeBorderAndBackgroundMemo(ExcelRange cells)
        {
            cells.Style.Fill.PatternType = ExcelFillStyle.Solid;
            cells.Style.Fill.BackgroundColor.SetColor(GrayBackgroundColor);
        }

        public static void SetAlignment(ExcelWorksheet sheet, int row, int column)
        {
            sheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            sheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;
        }

        public static void SetMergeCenter(ExcelRange cells)
        {
            cells.Merge = true;
            cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
        }
    }
}