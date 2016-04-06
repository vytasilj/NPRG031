using System;

namespace Calculator
{
    public class Calculator
    {
        private double _result;
        private Operation _lastOperation;
        private bool _firstNumber;


        public Calculator()
        {
            _firstNumber = true;
        }


        public double Result
        {
            get { return _result; }
        }
        

        public void Operate(Operation oper, string value)
        {
            double number;
            if (!double.TryParse(value, out number))
                throw new ArgumentException("Value není číslo.");
            
            if (_firstNumber)
            {
                _result = number;
                _lastOperation = oper;
                _firstNumber = false;
                return;
            }

            switch (_lastOperation)
            {
                case Operation.Plus:
                    _result = _result + number;
                    break;
                case Operation.Minus:
                    _result = _result - number;
                    break;
                case Operation.Multiply:
                    _result = _result * number;
                    break;
                case Operation.Devide:
                    if (Math.Abs(number) < float.Epsilon)
                        throw new DivideByZeroException("Nelze dělit 0.");
                    _result = _result / number;
                    break;
                case Operation.Result:
                    _result = number;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(oper), oper, null);
            }
            _lastOperation = oper;
        }
    }
}