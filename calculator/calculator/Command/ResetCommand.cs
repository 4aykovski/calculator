using calculator.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator.Command
{
    public class ResetCommand : CommandBase
    {
        private readonly MainWindowViewModel _mainWindowViewModel;

        public ResetCommand(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        public override void Execute(object? parameter)
        {
            _mainWindowViewModel.Reset();
        }
    }
}
