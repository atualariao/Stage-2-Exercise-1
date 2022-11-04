using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppS2E1.ViewModels;

namespace WpfAppS2E1.Commands
{
    public class SearchExcelCommand : CommandBase
    {
        public DataTable? dt;
        public DataView? dv;

        private readonly ExcelViewModel _excelViewModel;

        public SearchExcelCommand(ExcelViewModel excelViewModel)
        {
            _excelViewModel = excelViewModel;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                dv = _excelViewModel.ExcelFile;
                if (dv != null)
                {
                    if (_excelViewModel.SearchInput != string.Empty)
                    {
                        dv.RowFilter = String.Format("{0}='{1}'", "Rep", _excelViewModel.SearchInput);
                        _excelViewModel.TotalRows = _excelViewModel.ExcelFile.Count;
                    }
                    else
                    {
                        dv.RowFilter = _excelViewModel.SearchInput;
                        _excelViewModel.TotalRows = _excelViewModel.ExcelFile.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
