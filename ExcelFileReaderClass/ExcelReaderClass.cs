using ExcelFileReader;
using System.ComponentModel.Composition;
namespace ExcelFileReaderClass
{
    [Export(typeof(IExcelReader))]
    public abstract class ExcelReaderClass : IExcelReader
    {
        public string Parse()
        {
            return "Excel Parsed";
        }
        //public void Parse(string fileLocation)
        //{
        //    return;
        //}
    }
}