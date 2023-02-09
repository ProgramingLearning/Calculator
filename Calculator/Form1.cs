using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Calculator.Logic;

namespace Calculator
{
    public partial class Form1 : Form
    {
        List<string> terms = new List<string>();
        string lastTerm;
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
            if (operationButtonPressed != Operation.Sum && terms.Count > 1)
            {
                terms.Add(textbox_result.Text);
                ProcessResult(calculatorLogic.DoStuff(operationButtonPressed, terms.ToArray()));
            }
            else
            {
                terms.Add(textbox_result.Text);
            }

            isOperationButtonPressed = true;
            isResultButtonthelastbuttonpressed = false;
            operationButtonPressed = Operation.Sum;
            lbl_title.Text = "+";
        }

        private void btn_sub_click(object sender, EventArgs e)
        {
            if (operationButtonPressed != Operation.Subtract && terms.Count > 1)
            {
                terms.Add(textbox_result.Text);
                ProcessResult(calculatorLogic.DoStuff(operationButtonPressed, terms.ToArray()));
            }
            else
            {
                terms.Add(textbox_result.Text);
            }

            isOperationButtonPressed = true;
            isResultButtonthelastbuttonpressed = false;
            operationButtonPressed = Operation.Subtract;
            lbl_title.Text = "-";
        }


        private void btn_mul_click(object sender, EventArgs e)
        {
            if (operationButtonPressed != Operation.Multiply && terms.Count > 1)
            {
                terms.Add(textbox_result.Text);
                ProcessResult(calculatorLogic.DoStuff(operationButtonPressed, terms.ToArray()));
            }
            else
            {
                terms.Add(textbox_result.Text);
            }

            isOperationButtonPressed = true;
            isResultButtonthelastbuttonpressed = false;
            operationButtonPressed = Operation.Multiply;
            lbl_title.Text = "*";
        }

        private void btn_div_click(object sender, EventArgs e)
        {
            if (operationButtonPressed != Operation.Divide && terms.Count > 1)
            {
                terms.Add(textbox_result.Text);
                ProcessResult(calculatorLogic.DoStuff(operationButtonPressed, terms.ToArray()));
            }
            else
            {
                terms.Add(textbox_result.Text);
            }

            isOperationButtonPressed = true;
            isResultButtonthelastbuttonpressed = false;
            operationButtonPressed = Operation.Divide;
            lbl_title.Text = "/";
        }

        private void btn_result_Click(object sender, EventArgs e)
        {
            if (isResultButtonthelastbuttonpressed)
            {
                terms.Add(textbox_result.Text);
                terms.Add(lastTerm);
                ProcessResult(calculatorLogic.DoStuff(operationButtonPressed, terms.ToArray()));
            }
            else
            {
                lbl_title.Text = "Result";
                if (operationButtonPressed == Operation.Divide || operationButtonPressed == Operation.Sum || operationButtonPressed == Operation.Multiply || operationButtonPressed == Operation.Subtract || operationButtonPressed == Operation.Power)
                {
                    terms.Add(textbox_result.Text);
                    lastTerm = textbox_result.Text;
                    ProcessResult(calculatorLogic.DoStuff(operationButtonPressed, terms.ToArray()));
                }
            }
            isResultButtonthelastbuttonpressed = true;
            terms = new List<string>();

        }

        private void btn_IsPrime_Click(object sender, EventArgs e)
        {
            isOperationButtonPressed = true;
            var result = calculatorLogic.DoStuff(Operation.IsPrime, textbox_result.Text);
            ProcessResult(result);
            terms = new List<string>();
        }

        private void btn_SuperPalindrome_Click(object sender, EventArgs e)
        {
            isOperationButtonPressed = true;
            var result = calculatorLogic.DoStuff(Operation.Superpalindrome, textbox_result.Text);
            ProcessResult(result);
            terms = new List<string>();
        }

        private void btn_Pow_Click(object sender, EventArgs e)
        {
            terms.Add(textbox_result.Text);
            isOperationButtonPressed = true;
            isResultButtonthelastbuttonpressed = false;
            operationButtonPressed = Operation.Power;
            lbl_title.Text = "^";
        }

        private void btn_AbsoluteValue_Click(object sender, EventArgs e)
        {
            isOperationButtonPressed = true;
            var result = calculatorLogic.DoStuff(Operation.AbsoluteValue, textbox_result.Text);
            ProcessResult(result);
            terms = new List<string>();
        }

        private void btn_Palindrome_Click(object sender, EventArgs e)
        {
            isOperationButtonPressed = true;
            var result = calculatorLogic.DoStuff(Operation.Palindrome, textbox_result.Text);
            ProcessResult(result);
            terms = new List<string>();
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
            isOperationButtonPressed = true;
            var result = calculatorLogic.DoStuff(Operation.Reverse, textbox_result.Text);
            ProcessResult(result);
            terms = new List<string>();
        }

        private void btn_Odd_Click(object sender, EventArgs e)
        {
            isOperationButtonPressed = true;
            var result = calculatorLogic.DoStuff(Operation.IsOddOrEven, textbox_result.Text);
            ProcessResult(result);
            terms = new List<string>();
        }

        private void btn_ChangeSign_Click(object sender, EventArgs e)
        {
            isOperationButtonPressed = true;
            var result = calculatorLogic.DoStuff(Operation.ChangeSign, textbox_result.Text);
            ProcessResult(result);
            terms = new List<string>();
        }
    }
}
