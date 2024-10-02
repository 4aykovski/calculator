using calculator.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace calculator.Command
{
    public class DigitBtnClickCommand : CommandBase
    {
        private readonly MainWindowViewModel _mainWindowViewModel;

        public DigitBtnClickCommand(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        public override void Execute(object? button)
        {
            if (button == null)
            {
                _mainWindowViewModel.ClearDisplay();
                _mainWindowViewModel.Display = "ERROR";
                return;
            }

            string? input = button?.ToString();
            if (string.IsNullOrEmpty(input))
            {
                _mainWindowViewModel.ClearDisplay();
                _mainWindowViewModel.Display = "ERROR";
                return;
            }

            // обрабатываем возможные значения передаваемого параметра в команду
            // , - разделитель для дробных
            // остальное - цифры
            switch (button)
            {
                case ",":
                    if (_mainWindowViewModel.NewDisplay)
                    {
                        _mainWindowViewModel.Display = "0,";
                        _mainWindowViewModel.NewDisplay = false;
                        return;
                    }

                    if (!_mainWindowViewModel.Display.Contains(','))
                    {
                        _mainWindowViewModel.Display += ",";
                    }
                    break;

                default:
                    if (_mainWindowViewModel.NewDisplay)
                    {
                        _mainWindowViewModel.ClearDisplay();
                    }

                    // если сейчас на Display 0, то приравниваем инпут, чтобы не получилось "01"
                    if (_mainWindowViewModel.Display == "0")
                    {
                        _mainWindowViewModel.Display = input;
                    }
                    else
                    {
                        _mainWindowViewModel.Display += input;
                    }
                    break;
            }
        }
    }
}
