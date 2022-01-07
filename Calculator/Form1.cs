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
        Double resultValue = 0;
        String operationPerformed ="";
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
                textbox_result.Clear();

            textbox_result.Text = textbox_result.Text + "0";
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            if (textbox_result.Text == "0")
                textbox_result.Clear();

            textbox_result.Text = textbox_result.Text + "1";
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            if (textbox_result.Text == "0")
                textbox_result.Clear();
            textbox_result.Text = textbox_result.Text + "2";
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            if (textbox_result.Text == "0")
                textbox_result.Clear();
            textbox_result.Text = textbox_result.Text + "3";
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            if (textbox_result.Text == "0")
                textbox_result.Clear();

            textbox_result.Text = textbox_result.Text + "4";
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            if (textbox_result.Text == "0")
                textbox_result.Clear();

            textbox_result.Text = textbox_result.Text + "5";
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            if (textbox_result.Text == "0")
                textbox_result.Clear();

            textbox_result.Text = textbox_result.Text + "6";
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            if (textbox_result.Text == "0")
                textbox_result.Clear();

            textbox_result.Text = textbox_result.Text + "7";
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            if (textbox_result.Text == "0")
                textbox_result.Clear();

            textbox_result.Text = textbox_result.Text + "8";
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            if (textbox_result.Text == "0")
                textbox_result.Clear();

            textbox_result.Text = textbox_result.Text + "9";
        }

        private void btn_point_Click(object sender, EventArgs e)
        {
            textbox_result.Text = textbox_result.Text + ".";
        }

        private void btn_4_Click_1(object sender, EventArgs e)
        {
            textbox_result.Text = textbox_result.Text + "4";
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            textbox_result.Text = "0";
        }

        private void btn_CE_Click(object sender, EventArgs e)
        {
            textbox_result.Text = "0";
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operationPerformed = button.Text;
            resultValue = Double.Parse(textbox_result.Text);
            isOperationPerformed = true;
        }

        private void btn_result_Click(object sender, EventArgs e)
        {
            switch(operationPerformed)
            {
                case "+":
                    textbox_result.Text=(resultValue + Double.Parse(textbox_result.Text)).ToString();
                    break;
                case "-":
                    textbox_result.Text = (resultValue - Double.Parse(textbox_result.Text)).ToString();
                    break;
                case "*":
                    textbox_result.Text = (resultValue * Double.Parse(textbox_result.Text)).ToString();
                    break;
                case "/":
                    textbox_result.Text = (resultValue / Double.Parse(textbox_result.Text)).ToString();
                    break;
                default:
                    break;
            }
        }
    }
    }
