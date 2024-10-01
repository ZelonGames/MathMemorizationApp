using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMemorizationApp
{
    public class NumberPair
    {
        public enum OperatorMode
        {
            Addition,
            Subtraction,
            Multiplication,
            Division,
        }
        public OperatorMode operatorMode;
        public readonly int leftNumber, rightNumber;
        public double score;

        public NumberPair()
        {
        }

        public NumberPair(int leftNumber, int rightNumber, double score, OperatorMode operatorMode)
        {
            this.leftNumber = leftNumber;
            this.rightNumber = rightNumber;
            this.score = score;
            this.operatorMode = operatorMode;
        }

        public string GetOperator()
        {
            return operatorMode switch
            {
                OperatorMode.Addition => "+",
                OperatorMode.Subtraction => "-",
                OperatorMode.Multiplication => "*",
                OperatorMode.Division => "/",
                _ => throw new NotImplementedException(),
            };
        }

        public double Operate(int decimals = 0)
        {
            return operatorMode switch
            {
                OperatorMode.Addition => MathF.Round(leftNumber + rightNumber, decimals),
                OperatorMode.Subtraction => MathF.Round(leftNumber - rightNumber, decimals),
                OperatorMode.Multiplication => MathF.Round(leftNumber * rightNumber, decimals),
                OperatorMode.Division => MathF.Round(leftNumber / rightNumber, decimals),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
