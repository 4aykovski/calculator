using calculator.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator.Command
{
    public class DegreeUpBtnClickCommand : CommandBase
    {
        private readonly MainWindowViewModel _mainWindowViewModel;

        public DegreeUpBtnClickCommand(MainWindowViewModel mainWindowViewModel)
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

            try
            {
                int degree = (int)Convert.ToInt64(input.ToString());

                // если первый операнд пустой, то мы будем работать с текущим вводом в "Display"
                if (string.IsNullOrEmpty(_mainWindowViewModel.FirstOperand))
                {
                    _mainWindowViewModel.FirstOperand = _mainWindowViewModel.Display;
                    _mainWindowViewModel.Operation = "1^2";

                    _mainWindowViewModel.Calculation.CalculateResult();

                    _mainWindowViewModel.FullExpression = _mainWindowViewModel.Display + $"^{degree}";
                    _mainWindowViewModel.Display = _mainWindowViewModel.Result;
                    _mainWindowViewModel.NewDisplay = true;
                }
                // если первый операнд не пустой, значит остается работать только со вторым операндом, который сейчас введен в "Display"
                else
                {
                    _mainWindowViewModel.LastOperand = _mainWindowViewModel.Display;
                    string tmpOperation = _mainWindowViewModel.Operation;
                    _mainWindowViewModel.Operation = "2^2";

                    _mainWindowViewModel.Calculation.CalculateResult();

                    _mainWindowViewModel.Operation = tmpOperation;
                    _mainWindowViewModel.Display = _mainWindowViewModel.Result;
                }
            }
            catch
            {
                _mainWindowViewModel.ClearDisplay();
                _mainWindowViewModel.Display = "ERROR";
                return;
            }

            

        }
    }
}
