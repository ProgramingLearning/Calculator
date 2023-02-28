using Calculator.Logic;
using System;
using System.Windows.Forms;

namespace Calculator
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new CalculatorForm(new CalculatorLogic(new CalculatorError(), new CalculatorValidator(), new StringToNumberConvertor())));
        }
    }
}
