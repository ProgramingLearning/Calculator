using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Domain.Request
{
    public class CalculatorState
    {
        public List<string> Terms { get; set; }
        public Operation CurrentOperation { get; set; }

        public CalculatorState()
        {
            Terms = new List<string>();
        }
    }
}
