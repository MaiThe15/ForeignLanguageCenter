using ClosedXML.Excel; // Thư viện xuất Excel
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ForeignLanguageCenter
{
    public static class ExcelExporter
    {
        public static void ExportDataGridViewToExcel(DataGridView dgv, string title)
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("No data available to export!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                sfd.FileName = title + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Report");

                            // 1. Report Title
                            worksheet.Cell(1, 1).Value = title.Replace("_", " ").ToUpper();
                            worksheet.Cell(1, 1).Style.Font.Bold = true;
                            worksheet.Cell(1, 1).Style.Font.FontSize = 16;
                            worksheet.Range(1, 1, 1, dgv.Columns.Count).Merge();

                            // 2. Header Columns
                            int colIndex = 1;
                            for (int i = 0; i < dgv.Columns.Count; i++)
                            {
                                if (dgv.Columns[i].Visible)
                                {
                                    var cell = worksheet.Cell(3, colIndex);
                                    cell.Value = dgv.Columns[i].HeaderText;
                                    cell.Style.Font.Bold = true;
                                    cell.Style.Fill.BackgroundColor = XLColor.LightGray;
                                    colIndex++;
                                }
                            }

                            // 3. Data Rows
                            int rowIndex = 4;
                            for (int i = 0; i < dgv.Rows.Count; i++)
                            {
                                if (dgv.Rows[i].IsNewRow) continue;

                                colIndex = 1;
                                for (int j = 0; j < dgv.Columns.Count; j++)
                                {
                                    if (dgv.Columns[j].Visible)
                                    {
                                        worksheet.Cell(rowIndex, colIndex).Value = dgv.Rows[i].Cells[j].Value?.ToString() ?? "";
                                        colIndex++;
                                    }
                                }
                                rowIndex++;
                            }

                            worksheet.Columns().AdjustToContents();
                            workbook.SaveAs(sfd.FileName);

                            MessageBox.Show("Data exported successfully to Excel!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error occurred while exporting: " + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}