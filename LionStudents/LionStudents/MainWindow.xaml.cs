using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.SQLite;

namespace LionStudents
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private static void ReleaseExcelObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }

        public void ReadExcelData(string path, int sheetnum)
        {
            Excel.Application excelApp = null;
            Excel.Workbook wb = null;
            Excel.Worksheet ws = null;
            try
            {
                excelApp = new Excel.Application();
                wb = excelApp.Workbooks.Open(path);
                // path 대신 문자열도 가능합니다
                // 예. Open(@"D:\test\test.xslx");
                ws = wb.Worksheets.get_Item(sheetnum) as Excel.Worksheet;
                // 시트넘 번째 Worksheet를 선택합니다.
                Excel.Range rng = ws.UsedRange;   // '여기'
                                                  // 현재 Worksheet에서 사용된 셀 전체를 선택합니다.
                object[,] data = rng.Value;
                // 열들에 들어있는 Data를 배열 (One-based array)로 받아옵니다.
                for (int r = 1, i = 0; r <= data.GetLength(0); r++)
                {
                    for (int c = 1; c <= data.GetLength(1); c++)
                    {
                        if (data[r, c] == null)
                        {
                            continue;
                        }
                        // Data 빼오기
                        // data[r, c] 는 excel의 (r, c) 셀 입니다.
                        // data.GetLength(0)은 엑셀에서 사용되는 행의 수를 가져오는 것이고,
                        // data.GetLength(1)은 엑셀에서 사용되는 열의 수를 가져오는 것입니다.
                        // GetLength와 [ r, c] 의 순서를 바꿔서 사용할 수 있습니다.
                    }
                }
                wb.Close(true);
                excelApp.Quit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ReleaseExcelObject(ws);
                ReleaseExcelObject(wb);
                ReleaseExcelObject(excelApp);
            }
        }

        private static void WriteExcelData(string path, string ExcelPath, object row, object column)
        {
            Excel.Application excelApp = null;
            Excel.Workbook wb = null;
            Excel.Worksheet ws = null;
            try
            {
                excelApp = new Excel.Application();

                wb = excelApp.Workbooks.Open(ExcelPath);
                // 엑셀파일을 엽니다.
                // ExcelPath 대신 문자열도 가능합니다
                // 예. Open(@"D:\test\test.xlsx");

                ws = wb.Worksheets.get_Item(1) as Excel.Worksheet;
                // 첫번째 Worksheet를 선택합니다.

                Excel.Range rng = ws.Range[ws.Cells[1, 1], ws.Cells[row, column]];
                // 해당 Worksheet에서 저장할 범위를 정합니다.
                // 지금은 저장할 행렬의 크기만큼 지정합니다.
                // 다른 예시 Excel.Range rng = ws.Range["B2", "G8"];

                object[,] data = new object[(int)row, (int)column];
                // 저장할 때 사용할 object 행렬

                for (int r = 0; r < (int)row; r++)
                {
                    for (int c = 0; c < (int)column; c++)
                    {
                        // data[r , c] = Data[r, c] 저장할 데이터
                    }
                }
                // for문이 아니더라도 object[,] 형으로 저장된다면 저장이 가능합니다.

                rng.Value = data;
                // data를 불러온 엑셀파일에 적용시킵니다. 아직 완료 X

                if (path != null)
                    // path는 새로 저장될 엑셀파일의 경로입니다.
                    // 따로 지정해준다면, "다른이름으로 저장" 의 역할을 합니다.
                    // 상대경로도 가능합니다. (예. "secondExcel.xlsx")
                    wb.SaveCopyAs(path);
                else
                    // 따로 저장하지 않는다면 지금 파일에 그대로 저장합니다.
                    wb.Save();

                wb.Close();
                excelApp.Quit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ReleaseExcelObject(ws);
                ReleaseExcelObject(wb);
                ReleaseExcelObject(excelApp);
            }
        }
        







    }
}
