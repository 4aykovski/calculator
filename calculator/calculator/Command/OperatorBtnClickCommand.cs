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

            // Обрабатываем возможные случаи, в которых может быть нажата кнопка оператора
            // 1 случай - мы ввели первое значение в Display и нажимаем на кнопку оператора / прошлый нажатый оператор был "=" / нам нужно обновить дисплей.
            // 1.1 - мы просто забираем наш ввод из Display и кладем его в первый операнд. Запоминаем операцию. Обновляем верхнюю строку дисплея, где показывается полностью выражение
            // 1.2 - в данном случае в Display будет лежать результат, который получился после равенства. Его мы просто кладем в первый операнд.
            // 1.3 - в данном случае в Display будет лежать результат каких-то вычислений. Аналогично с 1.2 кладем результат в первый операнд.
            if (string.IsNullOrEmpty(_mainWindowViewModel.FirstOperand) || _mainWindowViewModel.NewDisplay || _mainWindowViewModel.LastOperation == "=")
            {
                _mainWindowViewModel.FirstOperand = _mainWindowViewModel.Display;
                _mainWindowViewModel.LastOperation = operation;
                _mainWindowViewModel.FullExpression = _mainWindowViewModel.FirstOperand + " " + operation + " ";
            }
            // 2 случай - первый операнд не пустой и мы вводим оператор "="
            // В таком случае нам нужно вывести полное выражение в FullExpression и результат его вычисления в Display. 
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
            // 3 случай - все остальные случаи, а именно, когда первый операнд не пустой и мы нажимаем любую из возможных операций.
            // В таком случае полное выражение в FullExpression нам указывать не нужно. Там мы указываем сразу результат вычислений и оператор, который был нажат в данный момент. Так же выводим результат в Display.
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
