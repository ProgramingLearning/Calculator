using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Calculator.Logic;

namespace Calculator
{
    public partial class Form1 : Form
    {
        List<string> terms = new List<string>();
        string firstTerm;
        string secondTerm;
        double resultValue;
        Operation operationButtonPressed = Operation.None;
        bool isOperationButtonPressed = false;
        bool isResultButtonthelastbuttonpressed = false;
        ICalculatorLogic calculatorLogic;

        public Form1(ICalculatorLogic calculatorLogic)
        {
            this.calculatorLogic = calculatorLogic;
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
            if (isOperationButtonPressed)
            {
                textbox_result.Clear();
                isOperationButtonPressed = false;
            }
            textbox_result.Text = $"{textbox_result.Text}0";
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            if (textbox_result.Text == "0")
                textbox_result.Clear();

            if (isOperationButtonPressed)
            {
                textbox_result.Clear();
                isOperationButtonPressed = false;
            }
            textbox_result.Text = $"{textbox_result.Text}1";
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            if (textbox_result.Text == "0")
                textbox_result.Clear();

            if (isOperationButtonPressed)
            {
                textbox_result.Clear();
                isOperationButtonPressed = false;
            }
            textbox_result.Text = $"{textbox_result.Text}2";
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            if (textbox_result.Text == "0")
                textbox_result.Clear();

            if (isOperationButtonPressed)
            {
                textbox_result.Clear();
                isOperationButtonPressed = false;
            }
            textbox_result.Text = $"{textbox_result.Text}3";
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            if (textbox_result.Text == "0")
                textbox_result.Clear();

            if (isOperationButtonPressed)
            {
                textbox_result.Clear();
                isOperationButtonPressed = false;
            }
            textbox_result.Text = $"{textbox_result.Text}4";
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            if (textbox_result.Text == "0")
                textbox_result.Clear();

            if (isOperationButtonPressed)
            {
                textbox_result.Clear();
                isOperationButtonPressed = false;
            }
            textbox_result.Text = $"{textbox_result.Text}5";
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            if (textbox_result.Text == "0")
                textbox_result.Clear();

            if (isOperationButtonPressed)
            {
                textbox_result.Clear();
                isOperationButtonPressed = false;
            }
            textbox_result.Text = $"{textbox_result.Text}6";
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            if (textbox_result.Text == "0")
                textbox_result.Clear();

            if (isOperationButtonPressed)
            {
                textbox_result.Clear();
                isOperationButtonPressed = false;
            }
            textbox_result.Text = $"{textbox_result.Text}7";
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            if (textbox_result.Text == "0")
                textbox_result.Clear();

            if (isOperationButtonPressed)
            {
                textbox_result.Clear();
                isOperationButtonPressed = false;
            }
            textbox_result.Text = $"{textbox_result.Text}8";
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            if (textbox_result.Text == "0")
                textbox_result.Clear();

            if (isOperationButtonPressed)
            {
                textbox_result.Clear();
                isOperationButtonPressed = false;
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
            firstTerm = 0.ToString();
            secondTerm = 0.ToString();
            terms = new List<string>();
            isOperationButtonPressed = false;
            operationButtonPressed = Operation.None;
            isResultButtonthelastbuttonpressed = false;
        }

        private void btn_CE_Click(object sender, EventArgs e)
        {
            textbox_result.Text = "0";
        }

        private void btn_sum_click(object sender, EventArgs e)
        {
            operationButtonPressed = Operation.Sum;
            isOperationButtonPressed = true;
            firstTerm = textbox_result.Text;
            lbl_title.Text = "+";
            isResultButtonthelastbuttonpressed = false;
        }

        private void btn_sub_click(object sender, EventArgs e)
        {
            isOperationButtonPressed = true;
            firstTerm = textbox_result.Text;
            operationButtonPressed = Operation.Subtract;
            lbl_title.Text = "-";
            isResultButtonthelastbuttonpressed = false;
        }

        private void btn_mul_click(object sender, EventArgs e)
        {
            isOperationButtonPressed = true;
            firstTerm = textbox_result.Text;
            operationButtonPressed = Operation.Multiply;
            lbl_title.Text = "*";
            isResultButtonthelastbuttonpressed = false;
        }

        private void btn_div_click(object sender, EventArgs e)
        {
            isOperationButtonPressed = true;
            isResultButtonthelastbuttonpressed = false;
            terms.Add(textbox_result.Text);
            operationButtonPressed = Operation.Divide;
            lbl_title.Text = "/";
        }

        private void btn_result_Click(object sender, EventArgs e)
        {
            if (isResultButtonthelastbuttonpressed)
            {
                firstTerm = textbox_result.Text;
                TryCatch();
            }
            else
            {
                lbl_title.Text = "Result";
                if (operationButtonPressed == Operation.Divide)
                {
                    terms.Add(textbox_result.Text);
                    ProcessResult(calculatorLogic.DoStuff(operationButtonPressed, terms.ToArray()));
                }
                else
                {
                    secondTerm = textbox_result.Text;
                    TryCatch();
                }
                isResultButtonthelastbuttonpressed = true;
            }
        }

        private void TryCatch()
        {
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
                case Error.IsNotAnInteger:
                    {
                        lbl_title.Text = "The number is not an Integer";
                    }
                    break;
                case Error.Error4:
                    break;
                default:
                    break;
            }
        }

        private void PerformOperation()
        {
            switch (operationButtonPressed)
            {
                case Operation.None:
                    {
                        throw new CalculatorException(Error.NoOperationSelected);
                    }
                case Operation.Sum:
                    {
                        resultValue = ConvertToDouble(firstTerm) + ConvertToDouble(secondTerm);
                        textbox_result.Text = resultValue.ToString();
                        break;
                    }
                case Operation.Subtract:
                    {
                        resultValue = ConvertToDouble(firstTerm) - ConvertToDouble(secondTerm);
                        textbox_result.Text = resultValue.ToString();
                        break;
                    }
                case Operation.Multiply:
                    {
                        resultValue = ConvertToDouble(firstTerm) * ConvertToDouble(secondTerm);
                        textbox_result.Text = resultValue.ToString();
                        break;
                    }
                case Operation.Divide:
                    {
                        ValidateSecondTermForDivision();
                        resultValue = ConvertToDouble(firstTerm) / ConvertToDouble(secondTerm);
                        textbox_result.Text = resultValue.ToString();
                        break;
                    }
                case Operation.IsPrime:
                    {
                        if (IsPrime(ConvertToInteger(firstTerm)))
                        {
                            lbl_title.Text = ($"Is a prime number");
                        }
                        else
                        {
                            lbl_title.Text = ($"Is not a prime number");
                        }
                        break;
                    }
                case Operation.IsOddOrEven:
                    {
                        if ((ConvertToInteger(firstTerm)) % 2 == 0)
                        {
                            lbl_title.Text = ($"Is an Even number");
                        }
                        else
                        {
                            lbl_title.Text = ($"Is an Odd number");
                        }
                        break;
                    }
                case Operation.Power:
                    {
                        resultValue = Math.Pow(ConvertToDouble(firstTerm), ConvertToDouble(secondTerm));
                        textbox_result.Text = resultValue.ToString();
                        lbl_title.Text = ($"Result");
                        break;
                    }
                case Operation.AbsoluteValue:
                    {
                        resultValue = Math.Abs(ConvertToDouble(firstTerm));
                        textbox_result.Text = resultValue.ToString();
                        lbl_title.Text = ($"|{firstTerm}|");
                        break;
                    }

                case Operation.Reverse:
                    {
                        resultValue = Reverse(ConvertToInteger(firstTerm));
                        textbox_result.Text = resultValue.ToString();
                        lbl_title.Text = "Reverse";
                        break;
                    }

                case Operation.Palindrome:
                    {
                        if (IsPalindrom(ConvertToInteger(firstTerm)))
                        {
                            lbl_title.Text = ($"Is a palindrome number");
                        }
                        else
                        {
                            lbl_title.Text = ($"{firstTerm} is not a palindrome number");
                        }
                        break;
                    }

                case Operation.Superpalindrome:
                    {
                        if (IsPalindrom(ConvertToInteger(firstTerm)))
                        {

                            if (IsPalindrom(ConvertToInteger(Math.Pow((ConvertToDouble(firstTerm)), 2).ToString())))
                            {
                                lbl_title.Text = ($"Is a Superpalindrom number");
                            }
                            else
                            {
                                lbl_title.Text = ($"Is not a Superpalindrom number");

                            }
                        }
                        else
                        {
                            lbl_title.Text = ($"Is not a Superpalindrom number");

                        }
                        break;
                    }
            }
        }

        private void ValidateSecondTermForDivision()
        {
            if (ConvertToDouble(secondTerm) == 0)
            {
                throw new CalculatorException(Error.DivideBy0);
            }
        }

        private static double ConvertToDouble(string valueToConvert)
        {
            double.TryParse(valueToConvert, out double result);
            return result;
        }

        private static int ConvertToInteger(string valueToConvert)
        {
            if (int.TryParse(valueToConvert, out int result))
            {
                return result;
            }
            else
            {
                throw new CalculatorException(Error.IsNotAnInteger);
            }
        }

        private static bool IsPrime(int a)
        {
            if (a == 1 || a == 0)
            {
                return false;
            }
            for (int i = 2; i <= Math.Sqrt(a); i++)
            {
                if (a % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsPalindrom(int a)
        {
            return a == Reverse(a);
        }

        public static int Reverse(int a)
        {
            int oglindit = 0;
            int reminder;
            int numar = a;

            while (numar > 0)
            {
                reminder = numar % 10;
                oglindit = oglindit * 10 + reminder;
                numar /= 10;
            }

            return oglindit;
        }

        private void btn_IsPrime_Click(object sender, EventArgs e)
        {
            operationButtonPressed = Operation.IsPrime;
            isOperationButtonPressed = true;
            firstTerm = textbox_result.Text;
            isResultButtonthelastbuttonpressed = false;
            TryCatch();
        }

        private void btn_SuperPalindrome_Click(object sender, EventArgs e)
        {
            operationButtonPressed = Operation.Superpalindrome;
            isOperationButtonPressed = true;
            firstTerm = textbox_result.Text;
            isResultButtonthelastbuttonpressed = false;
            TryCatch();
        }

        private void btn_Pow_Click(object sender, EventArgs e)
        {
            operationButtonPressed = Operation.Power;
            isOperationButtonPressed = true;
            firstTerm = textbox_result.Text;
            isResultButtonthelastbuttonpressed = false;
            lbl_title.Text = "x^y";
        }

        private void btn_AbsoluteValue_Click(object sender, EventArgs e)
        {
            operationButtonPressed = Operation.AbsoluteValue;
            isOperationButtonPressed = true;
            firstTerm = textbox_result.Text;
            isResultButtonthelastbuttonpressed = false;
            TryCatch();
        }

        private void btn_Palindrome_Click(object sender, EventArgs e)
        {
            operationButtonPressed = Operation.Palindrome;
            isOperationButtonPressed = true;
            firstTerm = textbox_result.Text;
            isResultButtonthelastbuttonpressed = false;
            TryCatch();
        }

        private void btn_Square_Click(object sender, EventArgs e)
        {
            isOperationButtonPressed = true;
            var result = calculatorLogic.DoStuff(Operation.SquareRoot, textbox_result.Text);
            ProcessResult(result);
        }

        private void ProcessResult(CalculatorResult result)
        {
            lbl_title.Text = result.Message;
            if (result.IsSuccess)
            {
                textbox_result.Text = result.Value;
            }
            terms = new List<string> { result.Value };
        }

        private void btn_Reverse_Click(object sender, EventArgs e)
        {
            operationButtonPressed = Operation.Reverse;
            isOperationButtonPressed = true;
            firstTerm = textbox_result.Text;
            isResultButtonthelastbuttonpressed = false;
            TryCatch();
        }

        private void btn_Odd_Click(object sender, EventArgs e)
        {
            operationButtonPressed = Operation.IsOddOrEven;
            isOperationButtonPressed = true;
            firstTerm = textbox_result.Text;
            isResultButtonthelastbuttonpressed = false;
            TryCatch();
        }

        private void btn_ChangeSign_Click(object sender, EventArgs e)
        {
            textbox_result.Text = ((-1) * (ConvertToDouble(textbox_result.Text))).ToString();
            isResultButtonthelastbuttonpressed = false;
        }
    }
}
