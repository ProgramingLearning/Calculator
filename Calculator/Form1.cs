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
            if (textbox_result.Text.Contains("."))
            {
                lbl_title.Text = "Already contains a .";
            }
            else
            {
                textbox_result.Text = $"{textbox_result.Text}.";
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
                case Operation.RaiseNumberToPower:
                    {
                        resultValue = Math.Pow(firstTerm, secondTerm);
                        textbox_result.Text = resultValue.ToString();
                        break;
                    }
                case Operation.SquareRoot:
                    {
                        resultValue = Math.Sqrt(firstTerm);
                        textbox_result.Text = resultValue.ToString();
                        break;
                    }
                case Operation.NumberParity:
                    {
                        SetLabelTitleTextBasedOnFirstTermParity();
                        break;
                    }
                case Operation.MirroredNumber:
                    {
                        uint resultValue = 0;
                        uint number = Convert.ToUInt32(firstTerm);
                        while (number != 0)
                        {
                            resultValue = resultValue * 10 + number % 10;
                            number /= 10;
                        }
                        lbl_title.Text = $"The mirrored number is {resultValue}";
                        break;
                    }
                case Operation.IsPrime:
                    {
                        IsNaturalNumber(firstTerm);
                        if (IsNaturalNumber(firstTerm))
                        {
                            uint convertedFirstTerm = Convert.ToUInt32(firstTerm);
                            if (convertedFirstTerm <= 1)
                            {
                                lbl_title.Text = $"{convertedFirstTerm} is not a prime number.";
                            }
                            else
                            {
                                for (double divisor = 2; divisor <= Math.Sqrt(convertedFirstTerm); divisor++)
                                {
                                    if (convertedFirstTerm % divisor == 0)
                                    {
                                        lbl_title.Text = $"{convertedFirstTerm} is not a prime number.";
                                        break;
                                    }
                                    else
                                    {
                                        lbl_title.Text = $"{convertedFirstTerm} is  a prime number.";
                                    }
                                }
                            }
                        }
                        else
                        {
                            lbl_title.Text = $" {firstTerm} is not a natural number.";
                        }
                        break;
                    }
                case Operation.PalindromeSuperPalindrome:
                    {
                        double mirrored = GetMirrored(firstTerm);
                        var numberraisedtopower = Math.Pow(firstTerm, 2);
                        var mirrored2 = GetMirrored(numberraisedtopower);
                        if (firstTerm == mirrored)
                        {
                            if (numberraisedtopower == mirrored2)
                            {
                                lbl_title.Text = $"{firstTerm} is a superpalindrome.";
                            }
                            else
                            {
                                lbl_title.Text = $"{firstTerm} is a palindrome.";

                            }
                        }
                        else
                        {
                            lbl_title.Text = $"{firstTerm} is not a palindrome.";
                        }
                        break;
                    }
                case Operation.LeastCommonMultiple:
                    {
                        var number1 = Convert.ToUInt32(firstTerm);
                        var number2 = Convert.ToUInt32(secondTerm);

                        var number1Aux = number1;
                        var number2Aux = number2;

                        while (number1Aux != number2Aux)
                        {
                            if (number1Aux < number2Aux)
                            {
                                number1Aux += number1;
                            }
                            else
                            {
                                number2Aux += number2;
                            }
                        }

                        lbl_title.Text = $"CMMMC between {number1} and {number2} is {number2Aux}.";
                        break;
                    }
                case Operation.BiggestCommunalDivisor:
                    {
                        var number1 = Convert.ToUInt32(firstTerm);
                        var number2 = Convert.ToUInt32(secondTerm);

                        var number1Aux = number1;
                        var number2Aux = number2;

                        while (number1Aux != number2Aux)
                        {
                            if (number1Aux > number2Aux)
                            {
                                number1Aux -= number2Aux;
                            }
                            else
                            {
                                number2Aux -= number1Aux;
                            }
                        }
                        lbl_title.Text = $"CMMDC between {number1} and {number2} is {number2Aux}.";
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

        private void btn_RaiseNumberToPower_Click(object sender, EventArgs e)
        {
            isOperationPerformed = true;
            firstTerm = ConvertDouble(textbox_result.Text);
            operationPerformed = Operation.RaiseNumberToPower;
            lbl_title.Text = "^";
        }

        private void btn_SquareRoot_Click(object sender, EventArgs e)
        {

            isOperationPerformed = true;
            firstTerm = ConvertDouble(textbox_result.Text);
            operationPerformed = Operation.SquareRoot;
            lbl_title.Text = "SqRt";
        }

        private void btn_NumberParity_Click(object sender, EventArgs e)
        {
            isOperationPerformed = true;
            firstTerm = ConvertDouble(textbox_result.Text);
            operationPerformed = Operation.NumberParity;
            lbl_title.Text = "NumberParity";
        }

        private void btn_MirroredNumber_Click(object sender, EventArgs e)
        {
            isOperationPerformed = true;
            firstTerm = ConvertDouble(textbox_result.Text);
            operationPerformed = Operation.MirroredNumber;
            lbl_title.Text = "MirroredNumber";
        }

        private void btn_IsPrime_Click(object sender, EventArgs e)
        {
            isOperationPerformed = true;
            firstTerm = ConvertDouble(textbox_result.Text);
            operationPerformed = Operation.IsPrime;
            lbl_title.Text = "IsPrime";
        }

        private void btn_PalindromeSuperPalindrome_Click(object sender, EventArgs e)
        {
            isOperationPerformed = true;
            firstTerm = ConvertDouble(textbox_result.Text);
            operationPerformed = Operation.PalindromeSuperPalindrome;
            lbl_title.Text = "PalindromeSuperPalindrome";
        }
        private static double GetMirrored(double value)
        {
            uint ogl = 0;
            uint number = Convert.ToUInt32(value);
            while (number != 0)
            {
                ogl = ogl * 10 + number % 10;
                number /= 10;
            }
            double ConvertedOgl = Convert.ToDouble(ogl);

            return ConvertedOgl;
        }

        private void btn_LeastCommonMultiple_Click(object sender, EventArgs e)
        {
            isOperationPerformed = true;
            firstTerm = ConvertDouble(textbox_result.Text);
            operationPerformed = Operation.LeastCommonMultiple;
            lbl_title.Text = "LeastCommonMultiple";
        }

        private void btn_BiggestCommunalDivisor_Click(object sender, EventArgs e)
        {
            isOperationPerformed = true;
            firstTerm = ConvertDouble(textbox_result.Text);
            operationPerformed = Operation.BiggestCommunalDivisor;
            lbl_title.Text = "BiggestCommunalDivisor";
        }
        private bool IsNaturalNumber(double value)
        {
            if (Math.Floor(value) == value)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void SetLabelTitleTextBasedOnFirstTermParity()
        {
            if (firstTerm % 2 == 0)
            {
                lbl_title.Text = "The number is even.";
            }
            else
            {
                lbl_title.Text = "The number is odd.";
            }
        }
    }
}
