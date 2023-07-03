using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Logic
{
    public interface IStringToNumberConvertor
    {
         T ReadTerm<T>(string input);
         List<T> ReadTerms<T>(List<string> input);
    }
}
