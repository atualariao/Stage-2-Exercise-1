using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace ExcelFileReader
{
    public interface IExcelReader
    {
        public void Parse(string path)
        {
            return;
        }
    }
}