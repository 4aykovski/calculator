using calculator.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator.Command
{
    public class RemoveLastSymbolBtnClickCommand : CommandBase
    {
        private readonly MainWindowViewModel _mainWindowViewModel;

        public RemoveLastSymbolBtnClickCommand(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        public override void Execute(object? parameter)
        {
            int displayLength = _mainWindowViewModel.Display.Length;

            if (displayLength < 2)
            {
                _mainWindowViewModel.Display = "0";
                return;
            }

            _mainWindowViewModel.Display = _mainWindowViewModel.Display.Substring(0, displayLength - 1);
        }
    }
}
