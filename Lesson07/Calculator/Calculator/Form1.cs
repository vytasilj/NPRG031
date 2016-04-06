using System;
using System.Globalization;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private readonly Calculator _calculator;


        public Form1()
        {
            _calculator = new Calculator();
            InitializeComponent();

            DefaultValue();
        }


        private void AddNumber(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "";
            textBox1.Text += ((Button) sender).Text;
        }

        private void Plus(object sender, EventArgs e)
        {
            Compute(Operation.Plus);
        }

        private void Minus(object sender, EventArgs e)
        {
            Compute(Operation.Minus);
        }

        private void Multiply(object sender, EventArgs e)
        {
            Compute(Operation.Multiply);
        }

        private void Devide(object sender, EventArgs e)
        {
            Compute(Operation.Devide);
        }

        private void Result(object sender, EventArgs e)
        {
            Compute(Operation.Result);
        }

        private void Compute(Operation operation)
        {
            _calculator.Operate(operation, textBox1.Text);
            if (operation == Operation.Result)
                textBox1.Text = _calculator.Result.ToString(CultureInfo.InvariantCulture);
            else
                DefaultValue();
        }

        private void DefaultValue()
        {
            textBox1.Text = "0";
        }
    }
}
