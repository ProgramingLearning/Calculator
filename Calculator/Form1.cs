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
        string firstTerm;
        string secondTerm;
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
            firstTerm = "0";
            secondTerm = "0";
            isOperationPerformed = false;
            operationPerformed = Operation.None;
        }

        private void btn_CE_Click(object sender, EventArgs e)
        {
            textbox_result.Text = "0";
        }

        private void btn_sum_click(object sender, EventArgs e)
        {
            saveFirstTermAndOperation();
            operationPerformed = Operation.Sum;
            lbl_title.Text = "+";
        }

        private void btn_sub_click(object sender, EventArgs e)
        {
            saveFirstTermAndOperation();
            operationPerformed = Operation.Subtract;
            lbl_title.Text = "-";
        }

        private void btn_mul_click(object sender, EventArgs e)
        {
            saveFirstTermAndOperation();
            operationPerformed = Operation.Multiply;
            lbl_title.Text = "*";
        }

        private void btn_div_click(object sender, EventArgs e)
        {
            saveFirstTermAndOperation();
            operationPerformed = Operation.Divide;
            lbl_title.Text = "/";
        }
        private void btn_RaiseNumberToPower_Click(object sender, EventArgs e)
        {
            saveFirstTermAndOperation();
            operationPerformed = Operation.RaiseNumberToPower;
            lbl_title.Text = "^";
        }

        private void btn_SquareRoot_Click(object sender, EventArgs e)
        {
            saveFirstTermAndOperation();
            operationPerformed = Operation.SquareRoot;
            lbl_title.Text = "SqRt";
        }

        private void btn_NumberParity_Click(object sender, EventArgs e)
        {
            saveFirstTermAndOperation();
            operationPerformed = Operation.NumberParity;
            lbl_title.Text = "NumberParity";
        }

        private void btn_MirroredNumber_Click(object sender, EventArgs e)
        {
            saveFirstTermAndOperation();
            operationPerformed = Operation.MirroredNumber;
            lbl_title.Text = "MirroredNumber";
        }

        private void btn_IsPrime_Click(object sender, EventArgs e)
        {
            saveFirstTermAndOperation();
            operationPerformed = Operation.IsPrime;
            lbl_title.Text = "IsPrime";
        }

        private void btn_PalindromeSuperPalindrome_Click(object sender, EventArgs e)
        {
            saveFirstTermAndOperation();
            operationPerformed = Operation.PalindromeSuperPalindrome;
            lbl_title.Text = "PalindromeSuperPalindrome";
        }
        private void btn_LeastCommonMultiple_Click(object sender, EventArgs e)
        {
            saveFirstTermAndOperation();
            operationPerformed = Operation.LeastCommonMultiple;
            lbl_title.Text = "LeastCommonMultiple";
        }

        private void saveFirstTermAndOperation()
        {
            isOperationPerformed = true;
            firstTerm = textbox_result.Text;
        }

        private void btn_BiggestCommunalDivisor_Click(object sender, EventArgs e)
        {
            saveFirstTermAndOperation();
            operationPerformed = Operation.BiggestCommunalDivisor;
            lbl_title.Text = "BiggestCommunalDivisor";
        }

        private void btn_result_Click(object sender, EventArgs e)
        {
            lbl_title.Text = "Result";
            secondTerm = textbox_result.Text;
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
                case CalculatorExceptionCause.None:
                    break;
                case CalculatorExceptionCause.DivideBy0:
                    {
                        lbl_title.Text = "Cannot divide by 0";
                    }
                    break;
                case CalculatorExceptionCause.NoOperationSelected:
                    {
                        lbl_title.Text = "Select operation: +, -, * or /";
                    }
                    break;
                case CalculatorExceptionCause.ThisOperationNeedsTwoOperants:
                    {
                        lbl_title.Text = "This operation needs two operants.";
                    }
                    break;
                case CalculatorExceptionCause.ThisOperationRequiersNaturalOperants:
                    {
                        lbl_title.Text = "This operation requiers natural operants.";
                    }
                    break;
                case CalculatorExceptionCause.InvalidNumberInput:
                    lbl_title.Text = $"{ex.Value} is not a number. Please enter a number";
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
                        throw new CalculatorException(CalculatorExceptionCause.NoOperationSelected);
                    }
                case Operation.Sum:
                    {
                        var termOne = CalculatorConverterStringToNumber.ConvertToDouble(firstTerm);
                        var termTwo = CalculatorConverterStringToNumber.ConvertToDouble(secondTerm);
                        resultValue = termOne + termTwo;
                        textbox_result.Text = resultValue.ToString();
                        break;
                    }
                case Operation.Subtract:
                    {
                        var termOne = CalculatorConverterStringToNumber.ConvertToDouble(firstTerm);
                        var termTwo = CalculatorConverterStringToNumber.ConvertToDouble(secondTerm);
                        resultValue = termOne - termTwo;
                        textbox_result.Text = resultValue.ToString();
                        break;
                    }
                case Operation.Multiply:
                    {
                        var termOne = CalculatorConverterStringToNumber.ConvertToDouble(firstTerm);
                        var termTwo = CalculatorConverterStringToNumber.ConvertToDouble(secondTerm);
                        resultValue = termOne * termTwo;
                        textbox_result.Text = resultValue.ToString();
                        break;
                    }
                case Operation.Divide:
                    {
                        var termOne = CalculatorConverterStringToNumber.ConvertToDouble(firstTerm);
                        var termTwo = CalculatorConverterStringToNumber.ConvertToDouble(secondTerm);
                        ValidateSecondTermForDivision();
                        resultValue = termOne / termTwo;
                        textbox_result.Text = resultValue.ToString();
                        break;
                    }
                case Operation.RaiseNumberToPower:
                    {
                        var termOne = CalculatorConverterStringToNumber.ConvertToDouble(firstTerm);
                        var termTwo = CalculatorConverterStringToNumber.ConvertToDouble(secondTerm);
                        resultValue = Math.Pow(termOne, termTwo);
                        textbox_result.Text = resultValue.ToString();
                        break;
                    }
                case Operation.SquareRoot:
                    {
                        var termOne = CalculatorConverterStringToNumber.ConvertToDouble(firstTerm);
                        resultValue = Math.Sqrt(termOne);
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
                        ExecuteGetMirroredOperation();
                        break;
                    }
                case Operation.IsPrime:
                    {
                        ExecuteIsPrimeOperation();
                        break;
                    }
                case Operation.PalindromeSuperPalindrome:
                    {
                        uint termOne = CalculatorConverterStringToNumber.ConvertToUInt(firstTerm);
                        uint mirrored = GetMirrored(termOne);
                        var numberraisedtopower = Math.Pow(termOne, 2);
                        var mirrored2 = GetMirrored((uint)numberraisedtopower);
                        CheckAndShowIfPalindromeOrSuperPalindrome(termOne, mirrored, numberraisedtopower, mirrored2);
                        break;
                    }
                case Operation.LeastCommonMultiple:
                    {
                        var number1 = CalculatorConverterStringToNumber.ConvertToUInt(firstTerm);
                        var number2 = CalculatorConverterStringToNumber.ConvertToUInt(secondTerm);
                        var number1Aux = number1;
                        var number2Aux = number2;
                        CheckLeastCommonMultiple(number1, number2, ref number1Aux, ref number2Aux);
                        lbl_title.Text = $"LCM between {number1} and {number2} is {number2Aux}.";
                        textbox_result.Text = $"{number2Aux}";
                        break;
                    }
                case Operation.BiggestCommunalDivisor:
                    {
                        var number1 = CalculatorConverterStringToNumber.ConvertToUInt(firstTerm);
                        var number2 = CalculatorConverterStringToNumber.ConvertToUInt(secondTerm);
                        var number1Aux = number1;
                        var number2Aux = number2;
                        CheckBiggestCommunalDivisor(ref number1Aux, ref number2Aux);
                        lbl_title.Text = $"BCD between {number1} and {number2} is {number2Aux}.";
                        textbox_result.Text = $"{number2Aux}";
                        break;
                    }
            }
        }

        private void ExecuteGetMirroredOperation()
        {
            var termOne = CalculatorConverterStringToNumber.ConvertToDouble(firstTerm);
            if (IsNaturalNumber(termOne))
            {
                uint number = Convert.ToUInt32(firstTerm);
                resultValue = GetMirroredNumber(number);
                textbox_result.Text = resultValue.ToString();
            }
            else
            {
                textbox_result.Text = "Please enter a natural number.";
            }
        }

        private void CheckAndShowIfPalindromeOrSuperPalindrome(uint termOne, double mirrored, double numberraisedtopower, double mirrored2)
        {

            if (termOne == mirrored)
            {
                if (numberraisedtopower == mirrored2)
                {
                    lbl_title.Text = $"{firstTerm} is a superpalindrome.";
                    textbox_result.Text = firstTerm;

                }
                else
                {
                    lbl_title.Text = $"{firstTerm} is a palindrome.";
                    textbox_result.Text = firstTerm;
                }
            }
            else
            {
                lbl_title.Text = $"{firstTerm} is not a palindrome.";
                textbox_result.Text = firstTerm;

            }
        }

        private static void CheckBiggestCommunalDivisor(ref uint number1Aux, ref uint number2Aux)
        {
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
        }

        private static void CheckLeastCommonMultiple(uint number1, uint number2, ref uint number1Aux, ref uint number2Aux)
        {
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
        }

        private uint GetMirroredNumber(uint number)
        {
            uint mirrored = 0;
            while (number != 0)
            {
                mirrored = mirrored * 10 + number % 10;
                number /= 10;
            }
            return mirrored;
        }

        private void ExecuteIsPrimeOperation()
        {
            var termOne = CalculatorConverterStringToNumber.ConvertToDouble(firstTerm);
            if (IsNaturalNumber(termOne))
            {
                uint convertedFirstTerm = Convert.ToUInt32(firstTerm);
                if (convertedFirstTerm <= 1)
                {
                    lbl_title.Text = $"{convertedFirstTerm} is not a prime number.";
                    textbox_result.Text = $"{convertedFirstTerm}";
                }
                else if (convertedFirstTerm == 2)
                {
                    lbl_title.Text = $"{convertedFirstTerm} is  a prime number.";
                    textbox_result.Text = $"{convertedFirstTerm}";

                }
                else
                {
                    if (HasDivisors(convertedFirstTerm))
                    {
                        lbl_title.Text = $"{convertedFirstTerm} is  a prime number.";
                        textbox_result.Text = $"{convertedFirstTerm}";

                    }
                    else
                    {
                        lbl_title.Text = $"{convertedFirstTerm} is not a prime number.";
                        textbox_result.Text = $"{convertedFirstTerm}";

                    }
                }
            }
            else
            {
                lbl_title.Text = $" {firstTerm} is not a natural number.";
                textbox_result.Text = $"{firstTerm}";

            }
        }

        private static bool HasDivisors(uint convertedFirstTerm)
        {
            for (double divisor = 2; divisor <= Math.Sqrt(convertedFirstTerm); divisor++)
            {
                if (convertedFirstTerm % divisor == 0)
                {
                    return false;
                }
            }
            return true;
        }
        private bool IsNaturalNumber(double value)
        {
            if (Math.Floor(value) == value && value > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ValidateSecondTermForDivision()
        {
            var termTwo = CalculatorConverterStringToNumber.ConvertToDouble(secondTerm);
            if (termTwo == 0)
            {
                throw new CalculatorException(CalculatorExceptionCause.DivideBy0);
            }
        }

        private static uint GetMirrored(uint number)
        {

            uint ogl = 0;
            while (number != 0)
            {
                ogl = ogl * 10 + number % 10;
                number /= 10;
            }
            return ogl;
        }

        private void SetLabelTitleTextBasedOnFirstTermParity()
        {
            var termOne = CalculatorConverterStringToNumber.ConvertToUInt(firstTerm);
            if (termOne % 2 == 0)
            {
                lbl_title.Text = "The number is even.";
                textbox_result.Text = $"{termOne}";
            }
            else
            {
                lbl_title.Text = "The number is odd.";
                textbox_result.Text = $"{termOne}";
            }
        }
    }
}
