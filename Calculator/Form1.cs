using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        double firstTerm;
        double secondTerm;
        double resultValue;
        Operation operationPerformed = Operation.None;
        bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            if (textbox_result.Text == "0")
            {
                textbox_result.Clear();
            }
            if (isOperationPerformed)
            {
                textbox_result.Clear();
                isOperationPerformed = false;
            }

            textbox_result.Text = $"{textbox_result.Text}0";
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            if (textbox_result.Text == "0")
                textbox_result.Clear();

            if (isOperationPerformed)
            {
                textbox_result.Clear();
                isOperationPerformed = false;
            }
            textbox_result.Text = $"{textbox_result.Text}1";
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            if (textbox_result.Text == "0")
                textbox_result.Clear();

            if (isOperationPerformed)
            {
                textbox_result.Clear();
                isOperationPerformed = false;
            }
            textbox_result.Text = $"{textbox_result.Text}2";
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            if (textbox_result.Text == "0")
                textbox_result.Clear();

            if (isOperationPerformed)
            {
                textbox_result.Clear();
                isOperationPerformed = false;
            }
            textbox_result.Text = $"{textbox_result.Text}3";
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            if (textbox_result.Text == "0")
                textbox_result.Clear();

            if (isOperationPerformed)
            {
                textbox_result.Clear();
                isOperationPerformed = false;
            }
            textbox_result.Text = $"{textbox_result.Text}4";
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            if (textbox_result.Text == "0")
                textbox_result.Clear();

            if (isOperationPerformed)
            {
                textbox_result.Clear();
                isOperationPerformed = false;
            }
            textbox_result.Text = $"{textbox_result.Text}5";
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            if (textbox_result.Text == "0")
                textbox_result.Clear();

            if (isOperationPerformed)
            {
                textbox_result.Clear();
                isOperationPerformed = false;
            }
            textbox_result.Text = $"{textbox_result.Text}6";
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            if (textbox_result.Text == "0")
                textbox_result.Clear();

            if (isOperationPerformed)
            {
                textbox_result.Clear();
                isOperationPerformed = false;
            }
            textbox_result.Text = $"{textbox_result.Text}7";
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            if (textbox_result.Text == "0")
                textbox_result.Clear();

            if (isOperationPerformed)
            {
                textbox_result.Clear();
                isOperationPerformed = false;
            }
            textbox_result.Text = $"{textbox_result.Text}8";
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            if (textbox_result.Text == "0")
                textbox_result.Clear();

            if (isOperationPerformed)
            {
                textbox_result.Clear();
                isOperationPerformed = false;
            }
            textbox_result.Text = $"{textbox_result.Text}9";
        }

        private void btn_point_Click(object sender, EventArgs e)

        {
            if (textbox_result.Text.Contains(","))
            {
                lbl_title.Text = "Already contains a ,";
            }
            else
            {
                textbox_result.Text = $"{textbox_result.Text},";
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            textbox_result.Text = "0";
            lbl_title.Text = "Calculator";
            firstTerm = 0;
            secondTerm = 0;
            isOperationPerformed = false;
            operationPerformed = Operation.None;
        }

        private void btn_CE_Click(object sender, EventArgs e)
        {
            textbox_result.Text = "0";
        }

        private void btn_sum_click(object sender, EventArgs e)
        {
            operationPerformed = Operation.Sum;
            isOperationPerformed = true;
            firstTerm = ConvertDouble(textbox_result.Text);

            lbl_title.Text = "+";
        }

        private void btn_sub_click(object sender, EventArgs e)
        {
            isOperationPerformed = true;
            firstTerm = ConvertDouble(textbox_result.Text);
            operationPerformed = Operation.Subtract;
            lbl_title.Text = "-";
        }

        private void btn_mul_click(object sender, EventArgs e)
        {
            isOperationPerformed = true;
            firstTerm = ConvertDouble(textbox_result.Text);
            operationPerformed = Operation.Multiply;
            lbl_title.Text = "*";
        }

        private void btn_div_click(object sender, EventArgs e)
        {
            isOperationPerformed = true;
            firstTerm = ConvertDouble(textbox_result.Text);
            operationPerformed = Operation.Divide;
            lbl_title.Text = "/";
        }

        private void btn_result_Click(object sender, EventArgs e)
        {
            lbl_title.Text = "Result";

            secondTerm = ConvertDouble(textbox_result.Text);

            try
            {
                PerformOperation();
            }
            catch (CalculatorException ex)
            {
                HandleCalculatorException(ex);
            }
        }

        private void HandleCalculatorException(CalculatorException ex)
        {
            switch (ex.ErrorType)
            {
                case Error.None:
                    break;
                case Error.DivideBy0:
                    {
                        lbl_title.Text = "Cannot divide by 0";
                    }
                    break;
                case Error.NoOperationSelected:
                    {
                        lbl_title.Text = "Select operation: +, -, * or /";
                    }
                    break;
                case Error.Error3:
                    break;
                case Error.Error4:
                    break;
                default:
                    break;
            }
        }

        private void PerformOperation()
        {
            switch (operationPerformed)
            {
                case Operation.None:
                    {
                        throw new CalculatorException(Error.NoOperationSelected);
                    }
                case Operation.Sum:
                    {
                        resultValue = firstTerm + secondTerm;
                        textbox_result.Text = resultValue.ToString();
                        break;
                    }
                case Operation.Subtract:
                    {
                        resultValue = firstTerm - secondTerm;
                        textbox_result.Text = resultValue.ToString();
                        break;
                    }
                case Operation.Multiply:
                    {
                        resultValue = firstTerm * secondTerm;
                        textbox_result.Text = resultValue.ToString();
                        break;
                    }
                case Operation.Divide:
                    {
                        ValidateSecondTermForDivision();
                        resultValue = firstTerm / secondTerm;
                        textbox_result.Text = resultValue.ToString();
                        break;
                    }
            }
        }

        private void ValidateSecondTermForDivision()
        {
            if (secondTerm == 0)
            {
                throw new CalculatorException(Error.DivideBy0);
            }
        }

        private static double ConvertDouble(string valueToConvert)
        {
            double.TryParse(valueToConvert, out double result);
            return result;
        }

        private void btn_IsPrime_Click(object sender, EventArgs e)
        {

        }
    }
}
