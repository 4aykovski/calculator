using calculator.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace calculator.Model
{
    public class CalculationModel
    {
        private string _result;

        public string FirstOperand { get; set; }
        public string LastOperand { get; set; }
        public string Operation { get; set; }
        public string Result { get { return _result; } }

        public CalculationModel() 
        {
            FirstOperand = string.Empty;
            LastOperand = string.Empty;
            Operation = string.Empty;
            _result = "0";
        }

        public void CalculateResult()
        {
            ValidateData();
            try
            {
                switch (Operation)
                {
                    case "/":
                        _result = (Convert.ToDouble(FirstOperand) / Convert.ToDouble(LastOperand)).ToString();
                        break;

                    case "*":
                        _result = (Convert.ToDouble(FirstOperand) * Convert.ToDouble(LastOperand)).ToString();
                        break;

                    case "+":
                        _result = (Convert.ToDouble(FirstOperand) + Convert.ToDouble(LastOperand)).ToString();
                        break;

                    case "-":
                        _result = (Convert.ToDouble(FirstOperand) - Convert.ToDouble(LastOperand)).ToString();
                        break;

                    case "1^2":
                        _result = Math.Pow(Convert.ToDouble(FirstOperand), 2).ToString();
                        break;

                    case "2^2":
                        _result = Math.Pow(Convert.ToDouble(LastOperand), 2).ToString();
                        break;
                }
            }
            catch (Exception ex)
            {
                _result = "Error while calculation";
                throw;
            }
        }

        private void ValidateData()
        {
            ValidateOperation(Operation);
            switch (Operation)
            {
                case "/":
                case "*":
                case "+":
                case "-":
                    ValidateOperand(FirstOperand);
                    ValidateOperand(LastOperand);
                    break;
                case "1^2":
                case "2^2":
                    ValidateOperand(FirstOperand);
                    break;
            }

        }

        private void ValidateOperand(string operand)
        {
            try
            {
                Convert.ToDouble(operand);
            }
            catch (Exception ex)
            {
                _result = "Invalid number: " + operand;
                throw;
            }
        }

        private void ValidateOperation(string operation)
        {
            switch (operation)
            {
                case "/":
                case "*":
                case "+":
                case "-":
                case "1^2":
                case "2^2":
                    break;
                default:
                    _result = "Invalid operation: " + operation;
                    throw new ArgumentException($"Unknown Operation: {operation}");
            }
        }
    }
}
