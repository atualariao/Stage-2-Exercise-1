using ReactiveUI;
using System.Collections.Generic;
using System.Data;
using System;
using System.Windows.Input;
using System.Collections.ObjectModel;
using WpfAppS2E1.Commands;
using WpfAppS2E1.Models;
using System.Windows;

namespace WpfAppS2E1.ViewModels
{
    public class ExcelViewModel : ExcelViewModelBase
    {
        private int _totalRows;
        private string _excelSheet = "SalesOrders";
        private string _filePath;
        private string _region;
        private string _searchInput;
        private DateTime _startDate = DateTime.Now;
        private DateTime _endDate = DateTime.Now;
        private DataView _excelFile = new();

        public IEnumerable<string> Regions { get; } = new List<string>() { "East", "West", "Central" };

        public ObservableCollection<string> ExcelSheets { get; } = new ObservableCollection<string>();

        public DataView ExcelFile
        { 
            get => this._excelFile; 
            set => this.RaiseAndSetIfChanged(ref this._excelFile, value);
        }

        public int TotalRows
        {
            get => this._totalRows;
            set => this.RaiseAndSetIfChanged(ref this._totalRows, value);
        }

        public string FilePath
        {
            get => this._filePath;
            set => this.RaiseAndSetIfChanged(ref this._filePath, value);
        }

        public string ExcelSheet
        {
            get => this._excelSheet;
            set => this.RaiseAndSetIfChanged(ref _excelSheet, value);
        }

        public string Region
        {
            get => this._region;
            set
            {
                this.RaiseAndSetIfChanged(ref this._region, value);
                {
                    DataView dv = _excelFile;

                    try
                    {
                        if (dv != null)
                        {
                            if (Region != null)
                            {
                                dv.RowFilter = String.Format("{0}='{1}'", "Region", Region);
                                TotalRows = ExcelFile.Count;
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

        public string SearchInput
        {
            get => this._searchInput;
            set => this.RaiseAndSetIfChanged(ref this._searchInput, value);
        }

        public DateTime StartDate
        {
            get => this._startDate;
            set => this.RaiseAndSetIfChanged(ref _startDate, value);
        }

        public DateTime EndDate
        {
            get => this._endDate;
            set => this.RaiseAndSetIfChanged(ref _endDate, value);
        }

        public ICommand? FilterByDateCommand { get; }
        public ICommand? SearchCommand { get; }
        public ICommand? ImportCommand { get; }

        public ExcelViewModel()
        {
            ImportCommand = new ImportExcelCommand(this);

            SearchCommand = new SearchExcelCommand(this);

            FilterByDateCommand = new FilterByDateCommand(this);
        }

    }
}
