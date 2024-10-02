using calculator.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator.Command
{
    public class OperatorBtnClickCommand : CommandBase
    {
        private readonly MainWindowViewModel _mainWindowViewModel;

        public OperatorBtnClickCommand(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        public override void Execute(object? input)
        {
            if (input == null)
            {
                _mainWindowViewModel.ClearDisplay();
                _mainWindowViewModel.Display = "ERROR";
                return;
            }

            string? operation = input?.ToString();
            if (string.IsNullOrEmpty(operation))
            {
                _mainWindowViewModel.ClearDisplay();
                _mainWindowViewModel.Display = "ERROR";
                return;
            }

            if (string.IsNullOrEmpty(_mainWindowViewModel.FirstOperand) || _mainWindowViewModel.NewDisplay || _mainWindowViewModel.LastOperation == "=")
            {
                _mainWindowViewModel.FirstOperand = _mainWindowViewModel.Display;
                _mainWindowViewModel.LastOperation = operation;
                _mainWindowViewModel.FullExpression = _mainWindowViewModel.FirstOperand + " " + operation + " ";
            }
            else if (operation == "=")
            {
                _mainWindowViewModel.LastOperand = _mainWindowViewModel.Display;
                _mainWindowViewModel.Operation = _mainWindowViewModel.LastOperation;

                _mainWindowViewModel.Calculation.CalculateResult();

                _mainWindowViewModel.FullExpression += _mainWindowViewModel.LastOperand + " " + operation;
                _mainWindowViewModel.Display = _mainWindowViewModel.Result;
                _mainWindowViewModel.LastOperation = operation;
                _mainWindowViewModel.FirstOperand = _mainWindowViewModel.Result;
                _mainWindowViewModel.LastOperand = string.Empty;
            }
            else
            {
                _mainWindowViewModel.LastOperand = _mainWindowViewModel.Display;
                _mainWindowViewModel.Operation = _mainWindowViewModel.LastOperation;

                _mainWindowViewModel.Calculation.CalculateResult();

                _mainWindowViewModel.FullExpression = _mainWindowViewModel.Result + " " + operation + " ";
                _mainWindowViewModel.Display = _mainWindowViewModel.Result;
                _mainWindowViewModel.LastOperation = operation;
                _mainWindowViewModel.FirstOperand = _mainWindowViewModel.Result;
                _mainWindowViewModel.LastOperand = string.Empty;
            }

            _mainWindowViewModel.NewDisplay = true;
        }
    }
}
