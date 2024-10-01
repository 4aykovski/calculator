using calculator.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace calculator.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _display;
        public string Display
        {
            get { return _display; }
            set { _display = value; OnPropertyChanged(nameof(Display)); }
        }

        public ICommand DigitBtnClickCommand { get; }
        public ICommand ClearDisplayCommand { get; }
        public ICommand OperatorBtnClickCommand { get; }

        public MainWindowViewModel()
        {
            DigitBtnClickCommand = new DigitBtnClickCommand();
            ClearDisplayCommand = new ClearDisplayCommand();
            OperatorBtnClickCommand = new OperatorBtnClickCommand();
        }

    }
}
