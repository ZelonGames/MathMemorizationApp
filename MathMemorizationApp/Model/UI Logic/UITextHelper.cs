using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMemorizationApp
{
    public static class UITextHelper
    {
        public static string GetMathProblemText(NumberPair numberPair)
        {
            return numberPair.leftNumber + " " + numberPair.GetOperator() + " " + numberPair.rightNumber + " = ";
        }
    }
}
