using ExcelFileReader;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Windows;

namespace WpfAppS2E1
{
    public class ExcelFileReaderDLL
    {
        [Import(typeof(IExcelReader))]
        public IExcelReader? excelReader;

        public void ExcelFileImport(string File)
        {
            try
            {
                var catalog = new AggregateCatalog();
                catalog.Catalogs.Add(new AssemblyCatalog(typeof(ExcelFileReaderDLL).Assembly));
                catalog.Catalogs.Add(new DirectoryCatalog(File, "*.dll"));

                CompositionContainer _container = new(catalog);
                _container.ComposeParts(this);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message);
            }
            catch(ChangeRejectedException e)
            { 
                MessageBox.Show(e.Message);
            }
        }
    }
}
