using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Calculator.Logic;
using System.Linq;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        bool isOperationButtonPressed = false;
        readonly ICalculatorLogic _calculatorLogic;

        public CalculatorForm(ICalculatorLogic calculatorLogic)
        {
            this._calculatorLogic = calculatorLogic;
            InitializeComponent();
        }

        private void CalculatorForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to Andreea`s Calculator! Click OK to continue", "Welcome Message", MessageBoxButtons.OK);
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            ClearAndTypeInTextBox();
            AppendTextToTextBox("0");
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            ClearAndTypeInTextBox();
            AppendTextToTextBox("1");
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            ClearAndTypeInTextBox();
            AppendTextToTextBox("2");
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            ClearAndTypeInTextBox();
            AppendTextToTextBox("3");
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            ClearAndTypeInTextBox();
            AppendTextToTextBox("4");
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            ClearAndTypeInTextBox();
            AppendTextToTextBox("5");
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            ClearAndTypeInTextBox();
            AppendTextToTextBox("6");
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            ClearAndTypeInTextBox();
            AppendTextToTextBox("7");
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            ClearAndTypeInTextBox();
            AppendTextToTextBox("8");
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            ClearAndTypeInTextBox();
            AppendTextToTextBox("9");
        }

        private void btn_point_Click(object sender, EventArgs e)
        {
            if (TextBoxContains("."))
            {
                DisplayInLabelTitle("Already contains a .");
            }
            else
            {
                AppendTextToTextBox(".");
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            SetCalculatorOnDefault();
        }

        private void btn_CE_Click(object sender, EventArgs e)
        {
            SetTextBoxTextToDefault();
        }

        private void btn_sum_click(object sender, EventArgs e)
        {
            AddNewTermToTheList();
            CheckIfOperationSelectedHasChangedProcessResult(Operation.Sum);
            SetTheOperationSelected("+", Operation.Sum);
        }

        private void btn_sub_click(object sender, EventArgs e)
        {
            AddNewTermToTheList();
            CheckIfOperationSelectedHasChangedProcessResult(Operation.Subtract);
            SetTheOperationSelected("-", Operation.Subtract);
        }

        private void btn_mul_click(object sender, EventArgs e)
        {
            AddNewTermToTheList();
            CheckIfOperationSelectedHasChangedProcessResult(Operation.Multiply);
            SetTheOperationSelected("*", Operation.Multiply);
        }

        private void btn_div_click(object sender, EventArgs e)
        {
            AddNewTermToTheList();
            CheckIfOperationSelectedHasChangedProcessResult(Operation.Divide);
            SetTheOperationSelected("/", Operation.Divide);
        }

        private void btn_Pow_Click(object sender, EventArgs e)
        {
            AddNewTermToTheList();
            CheckIfOperationSelectedHasChangedProcessResult(Operation.Power);
            SetTheOperationSelected("^", Operation.Power);
        }

        private void btn_result_Click(object sender, EventArgs e)
        {
            AddNewTermToTheList();
            DisplayCalculatorResult(_calculatorLogic.DoMultipleTermOperation());
        }

        private void btn_IsPrime_Click(object sender, EventArgs e)
        {
            PerformSingleTermOperationWithoutUsingResultButton(Operation.IsPrime);
        }

        private void btn_SuperPalindrome_Click(object sender, EventArgs e)
        {
            PerformSingleTermOperationWithoutUsingResultButton(Operation.Superpalindrome);
        }

        private void btn_AbsoluteValue_Click(object sender, EventArgs e)
        {
            PerformSingleTermOperationWithoutUsingResultButton(Operation.AbsoluteValue);
        }

        private void btn_Palindrome_Click(object sender, EventArgs e)
        {
            PerformSingleTermOperationWithoutUsingResultButton(Operation.Palindrome);
        }

        private void btn_Square_Click(object sender, EventArgs e)
        {
            PerformSingleTermOperationWithoutUsingResultButton(Operation.SquareRoot);
        }

        private void btn_Reverse_Click(object sender, EventArgs e)
        {
            PerformSingleTermOperationWithoutUsingResultButton(Operation.Reverse);
        }

        private void btn_Odd_Click(object sender, EventArgs e)
        {
            PerformSingleTermOperationWithoutUsingResultButton(Operation.IsOddOrEven);
        }

        private void btn_ChangeSign_Click(object sender, EventArgs e)
        {
            PerformSingleTermOperationWithoutUsingResultButton(Operation.ChangeSign);
        }

        private void PerformSingleTermOperationWithoutUsingResultButton(Operation operationSelected)
        {
            AddNewTermToTheList();
            isOperationButtonPressed = true;
            _calculatorLogic.SetCurrentOperation(operationSelected);
            var result = _calculatorLogic.DoCalculation();
            DisplayCalculatorResult(result);
        }

        private void DisplayCalculatorResult(CalculatorResult result)
        {
            lbl_title.Text = result.Message;
            if (result.IsSuccess)
            {
                textbox_result.Text = result.Value;
            }
            _calculatorLogic.ResetTerms();
        }

        private void ClearAndTypeInTextBox()
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
        }

        private void AppendTextToTextBox(string numberIWantToType)
        {
            textbox_result.Text = $"{textbox_result.Text}{numberIWantToType}";
        }

        private void SetTheOperationSelected(string operatorSelected, Operation operationSelected)
        {
            isOperationButtonPressed = true;
            _calculatorLogic.SetCurrentOperation(operationSelected);
            lbl_title.Text = $"{operatorSelected}";
        }

        private void CheckIfOperationSelectedHasChangedProcessResult(Operation operationSelected)
        {
            if (_calculatorLogic.ShouldPerformOperationForCurrentTerms(operationSelected))
            {
                DisplayCalculatorResult(_calculatorLogic.DoMultipleTermOperation());
                AddNewTermToTheList();
            }
        }

        private void SetTextBoxTextToDefault()
        {
            textbox_result.Text = "0";
        }

        private bool TextBoxContains(string WhatToCheckAbout)
        {
            return textbox_result.Text.Contains(WhatToCheckAbout);
        }

        private void DisplayInLabelTitle(string textIWantToDisply)
        {
            lbl_title.Text = textIWantToDisply;
        }

        private void SetCalculatorOnDefault()
        {
            SetTextBoxTextToDefault();
            DisplayInLabelTitle("Calculator");
            InitializeANewInsatnceOfTheList();
            isOperationButtonPressed = false;
            _calculatorLogic.SetCurrentOperation(Operation.None);
        }

        private void InitializeANewInsatnceOfTheList()
        {
            _calculatorLogic.ResetTerms();
        }

        private void AddNewTermToTheList()
        {
            _calculatorLogic.AddTerm(textbox_result.Text);
        }
    }
}
