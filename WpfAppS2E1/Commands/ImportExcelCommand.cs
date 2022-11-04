using ExcelDataReader;
using Microsoft.Win32;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows;
using WpfAppS2E1.ViewModels;

namespace WpfAppS2E1.Commands
{
    public class ImportExcelCommand : CommandBase
    {
        public DataTable? dt;
        public DataView? dv;
        public DataTableCollection? tableCollection;

        private readonly ExcelViewModel _excelViewModel;

        public ImportExcelCommand(ExcelViewModel excelViewModel)
        {
            _excelViewModel = excelViewModel;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Excel Files|*.xls;*.xlsx;";
                if (ofd.ShowDialog() != null)
                {
                    string path = ofd.FileName;
                    _excelViewModel.FilePath = ofd.FileName;
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                { UseHeaderRow = true }
                            });
                            tableCollection = result.Tables;
                            _excelViewModel.ExcelSheets.Clear();
                            foreach (DataTable table in tableCollection)
                            {
                                _excelViewModel.ExcelSheets.Add(table.TableName);
                            }
                            
                        }
                    }
                }
                dt = tableCollection?[_excelViewModel.ExcelSheet];
                _excelViewModel.ExcelFile = dt?.DefaultView;
                _excelViewModel.TotalRows = _excelViewModel.ExcelFile.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
