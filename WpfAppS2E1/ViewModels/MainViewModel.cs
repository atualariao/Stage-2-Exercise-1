namespace WpfAppS2E1.ViewModels
{
    public class MainViewModel: ExcelViewModelBase
    {
        public ExcelViewModelBase CurrentViewModel { get; }

        public MainViewModel()
        {
            CurrentViewModel = new ExcelViewModel();
        }
    }
}
