using calculator.Command;
using calculator.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace calculator.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly CalculationModel _calculation;
        public CalculationModel Calculation => _calculation;

        public string Result
        {
            get { return _calculation.Result; }
        }

        private string _fullExpression;
        public string FullExpression
        {
            get { return _fullExpression; }
            set { _fullExpression = value; OnPropertyChanged(nameof(FullExpression)); }
        }

        private string _display;
        public string Display
        {
            get { return _display; }
            set { _display = value; OnPropertyChanged(nameof(Display)); }
        }

        public string FirstOperand
        {
            get { return _calculation.FirstOperand; }
            set { _calculation.FirstOperand = value; OnPropertyChanged(nameof(FirstOperand)); }
        }

        public string LastOperand
        {
            get { return _calculation.LastOperand; }
            set { _calculation.LastOperand = value; OnPropertyChanged(nameof(LastOperand)); }
        }

        public string Operation
        {
            get { return _calculation.Operation; }
            set { _calculation.Operation = value; OnPropertyChanged(nameof(Operation)); }
        }

        /// <summary>
        ///     Поле показывающее нужно ли обновлять нижний дисплей текущего ввода.
        /// </summary>
        private bool _newDisplay;
        public bool NewDisplay
        {
            get { return _newDisplay; }
            set { _newDisplay = value; OnPropertyChanged(nameof(NewDisplay)); }
        }

        private string _lastOperation;
        public string LastOperation
        {
            get { return _lastOperation; }
            set { _lastOperation = value; OnPropertyChanged(nameof(LastOperand)); }
        }

        public ICommand DigitBtnClickCommand { get; }
        public ICommand ResetCommand { get; }
        public ICommand OperatorBtnClickCommand { get; }
        public ICommand ChangeMinusBtnClickCommand { get; }
        public ICommand RemoveLastSymbolBtnClickCommand { get; }
        public ICommand DegreeUpBtnClickCommand { get; }

        public MainWindowViewModel()
        {
            _calculation = new CalculationModel();
            _display = "0";
            _newDisplay = false;
            _fullExpression = string.Empty;
            DigitBtnClickCommand = new DigitBtnClickCommand(this);
            ResetCommand = new ResetCommand(this);
            OperatorBtnClickCommand = new OperatorBtnClickCommand(this);
            ChangeMinusBtnClickCommand = new ChangeMinusBtnClickCommand();
            RemoveLastSymbolBtnClickCommand = new RemoveLastSymbolBtnClickCommand(this);
            DegreeUpBtnClickCommand = new DegreeUpBtnClickCommand(this);
        }

        
        /// <summary>
        ///     Полностью обнуляет значения калькулятора, скидывая его до изначального состояния запуска.
        /// </summary>
        public void Reset()
        {
            NewDisplay = false;
            Display = "0";
            LastOperand = string.Empty;
            FirstOperand = string.Empty;
            Operation = string.Empty;
            FullExpression = string.Empty;
        }

        /// <summary>
        ///     Обнуляет нижнюю строку дисплея "Display", в которой показывается текущий ввод пользователя.
        /// </summary>
        public void ClearDisplay()
        {
            Display = "";
            NewDisplay = false;
        }
    }
}
