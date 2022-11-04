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
    public class FilterByDateCommand : CommandBase
    {
        public DataView? dv;

        private readonly ExcelViewModel _excelViewModel;

        public FilterByDateCommand(ExcelViewModel excelViewModel)
        {
            _excelViewModel = excelViewModel;
        }

        public override void Execute(object? parameter)
        {
            dv = _excelViewModel.ExcelFile;

            try
            {
                if (dv != null)
                {
                    dv.RowFilter = $"OrderDate >= '{_excelViewModel.StartDate}' AND OrderDate <= '{_excelViewModel.EndDate}'";
                    _excelViewModel.TotalRows = _excelViewModel.ExcelFile.Count;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please select a start and end date", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
