using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculator.Logic;

namespace Calculator
{
    public partial class Form1 : Form
    {
        string firstTerm;
        string secondTerm;
        CalculatorOperation operationPerformed = CalculatorOperation.None;
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
            operationPerformed = CalculatorOperation.None;
        }

        private void btn_CE_Click(object sender, EventArgs e)
        {
            textbox_result.Text = "0";
        }

        private void btn_sum_click(object sender, EventArgs e)
        {
            saveFirstTermAndOperation();
            operationPerformed = CalculatorOperation.Sum;
            lbl_title.Text = "+";
        }

        private void btn_sub_click(object sender, EventArgs e)
        {
            saveFirstTermAndOperation();
            operationPerformed = CalculatorOperation.Subtract;
            lbl_title.Text = "-";
        }

        private void btn_mul_click(object sender, EventArgs e)
        {
            saveFirstTermAndOperation();
            operationPerformed = CalculatorOperation.Multiply;
            lbl_title.Text = "*";
        }

        private void btn_div_click(object sender, EventArgs e)
        {
            saveFirstTermAndOperation();
            operationPerformed = CalculatorOperation.Divide;
            lbl_title.Text = "/";
        }
        private void btn_RaiseNumberToPower_Click(object sender, EventArgs e)
        {
            saveFirstTermAndOperation();
            operationPerformed = CalculatorOperation.RaiseNumberToPower;
            lbl_title.Text = "^";
        }

        private void btn_SquareRoot_Click(object sender, EventArgs e)
        {
            saveFirstTermAndOperation();
            operationPerformed = CalculatorOperation.SquareRoot;
            lbl_title.Text = "SqRt";
        }

        private void btn_NumberParity_Click(object sender, EventArgs e)
        {
            saveFirstTermAndOperation();
            operationPerformed = CalculatorOperation.NumberParity;
            lbl_title.Text = "NumberParity";
        }

        private void btn_MirroredNumber_Click(object sender, EventArgs e)
        {
            saveFirstTermAndOperation();
            operationPerformed = CalculatorOperation.MirroredNumber;
            lbl_title.Text = "MirroredNumber";
        }

        private void btn_IsPrime_Click(object sender, EventArgs e)
        {
            saveFirstTermAndOperation();
            operationPerformed = CalculatorOperation.IsPrime;
            lbl_title.Text = "IsPrime";
        }

        private void btn_PalindromeSuperPalindrome_Click(object sender, EventArgs e)
        {
            saveFirstTermAndOperation();
            operationPerformed = CalculatorOperation.PalindromeSuperPalindrome;
            lbl_title.Text = "PalindromeSuperPalindrome";
        }
        private void btn_LeastCommonMultiple_Click(object sender, EventArgs e)
        {
            saveFirstTermAndOperation();
            operationPerformed = CalculatorOperation.LeastCommonMultiple;
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
            operationPerformed = CalculatorOperation.BiggestCommunalDivisor;
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
                var errorHandler = new CalculatorExceptionHandler();
                lbl_title.Text = errorHandler.HandleCalculatorException(ex);
            }
        }

        private void PerformOperation()
        {
            switch (operationPerformed)
            {
                case CalculatorOperation.None:
                    {
                        throw new CalculatorException(CalculatorExceptionCause.NoOperationSelected);
                    }
                case CalculatorOperation.Sum:
                    {
                        var result = CalculatorLogic.PerformOperation(firstTerm, secondTerm, operationPerformed);
                        lbl_title.Text = result.Message;
                        textbox_result.Text = result.Value;
                        break;
                    }
                case CalculatorOperation.Subtract:
                    {
                        var result = CalculatorLogic.PerformOperation(firstTerm, secondTerm, operationPerformed);
                        lbl_title.Text = result.Message;
                        textbox_result.Text = result.Value;
                        break;
                    }
                case CalculatorOperation.Multiply:
                    {
                        var result = CalculatorLogic.PerformOperation(firstTerm, secondTerm, operationPerformed);
                        lbl_title.Text = result.Message;
                        textbox_result.Text = result.Value;
                        break;
                    }
                case CalculatorOperation.Divide:
                    {
                        var result = CalculatorLogic.PerformOperation(firstTerm, secondTerm, operationPerformed);
                        lbl_title.Text = result.Message;
                        textbox_result.Text = result.Value;
                        break;
                    }
                case CalculatorOperation.RaiseNumberToPower:
                    {
                        var result = CalculatorLogic.PerformOperation(firstTerm, secondTerm, operationPerformed);
                        lbl_title.Text = result.Message;
                        textbox_result.Text = result.Value;
                        break;
                    }
                case CalculatorOperation.SquareRoot:
                    {
                        var result = CalculatorLogic.PerformOperation(firstTerm, secondTerm, operationPerformed);
                        lbl_title.Text = result.Message;
                        textbox_result.Text = result.Value;
                        break;
                    }
                case CalculatorOperation.NumberParity:
                    {
                        var result = CalculatorLogic.PerformOperation(firstTerm, secondTerm, operationPerformed);
                        lbl_title.Text = result.Message;
                        textbox_result.Text = result.Value;
                        break;
                    }
                case CalculatorOperation.MirroredNumber:
                    {
                        var result = CalculatorLogic.PerformOperation(firstTerm, secondTerm, operationPerformed);
                        lbl_title.Text = result.Message;
                        textbox_result.Text = result.Value;
                        break;
                    }
                case CalculatorOperation.IsPrime:
                    {
                        var result = CalculatorLogic.PerformOperation(firstTerm, secondTerm, operationPerformed);
                        lbl_title.Text = result.Message;
                        textbox_result.Text = result.Value;
                        break;
                    }
                case CalculatorOperation.PalindromeSuperPalindrome:
                    {
                        var result = CalculatorLogic.PerformOperation(firstTerm, secondTerm, operationPerformed);
                        lbl_title.Text = result.Message;
                        textbox_result.Text = result.Value;
                        break;
                    }
                case CalculatorOperation.LeastCommonMultiple:
                    {
                        var result = CalculatorLogic.PerformOperation(firstTerm, secondTerm, operationPerformed);
                        lbl_title.Text = result.Message;
                        textbox_result.Text = result.Value;
                        break;
                    }
                case CalculatorOperation.BiggestCommunalDivisor:
                    {
                        var result = CalculatorLogic.PerformOperation(firstTerm, secondTerm, operationPerformed);
                        lbl_title.Text = result.Message;
                        textbox_result.Text = result.Value;
                        break;
                    }
            }
        }
       
    }
}
