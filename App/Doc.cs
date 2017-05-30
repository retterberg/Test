using App.Models;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;

namespace App
{
    class Doc
    {
        public Doc(IEnumerable<Credit> Credits)
        {
            Excel.Application excelApp = new Excel.Application();
            excelApp.Workbooks.Add(); //новая пустая книга
            Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;

            workSheet.Cells[1, "A"] = "Info";
            workSheet.Cells[1, "B"] = "Date";

            var row = 1;
            foreach (var c in Credits)
            {
                row++;
                workSheet.Cells[row, "A"] = c.Info;
                workSheet.Cells[row, "B"] = c.Date.ToString();
            }

            //авт. ширина столбцов
            workSheet.Columns[1].AutoFit();
            workSheet.Columns[2].AutoFit();

            excelApp.Visible = true;
        }
    }
}
