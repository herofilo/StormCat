using System;
using System.Data;
using System.Windows.Forms;
using ClosedXML.Excel;
using MSAddonLib.Util;

namespace StormCat.Misc
{
    public sealed class ExcelExporter
    {

        public static bool ExcelExport(DataGridView pDataGridView, string pOutputFile, string pWorksheetName, out string pErrorText)
        {
            pErrorText = null;

            bool saveOk = false;
            try
            {
                //Creating DataTable
                DataTable dt = new DataTable();

                //Adding the Columns
                foreach (DataGridViewColumn column in pDataGridView.Columns)
                {
                    dt.Columns.Add(column.HeaderText, typeof(string));
                }

                //Adding the Rows
                foreach (DataGridViewRow row in pDataGridView.Rows)
                {
                    dt.Rows.Add();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value?.ToString();
                    }
                }


                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, pWorksheetName);
                    wb.SaveAs(pOutputFile);
                }

                saveOk = true;
            }
            catch (Exception exception)
            {
                pErrorText = $"EXCEPTION: {Utils.GetExceptionFullMessage(exception)}";
            }

            return saveOk;
        }

    }
}
