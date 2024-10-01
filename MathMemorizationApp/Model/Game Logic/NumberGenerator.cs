using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathMemorizationApp
{
    public class NumberGenerator
    {
        public static Random rnd = new();
        public Dictionary<string, NumberPair> numberPairs = new();
        public readonly int leftMin, leftMax;
        private readonly int rightMin, rightMax;

        public NumberGenerator(int leftMin, int leftMax, int rightMin, int rightMax)
        {
            this.leftMin = leftMin;
            this.leftMax = leftMax;
            this.rightMin = rightMin;
            this.rightMax = rightMax;

            if (leftMin > leftMax || leftMax < leftMin)
                this.leftMin = leftMax;
            if (rightMin > rightMax || rightMax < rightMin)
                this.rightMin = rightMax;

            GenerateNumberPairs();
        }


        private void GenerateNumberPairs()
        {
            for (int i = leftMin; i <= leftMax; i++)
            {
                for (int j = rightMin; j <= rightMax; j++)
                {
                    if (!numberPairs.ContainsKey(i.ToString() + j))
                        numberPairs.Add(i.ToString() + j, new NumberPair(i, j, 0, ScoreController.operatorMode));
                }
            }
        }

        public NumberPair GetRandomNumberPair()
        {
            List<NumberPair> numberPairs = ScoreController.GetNormalizedScores(this.numberPairs)
                .Select(x => x.Value).ToList();

            while (true)
            {
                List<NumberPair> selectedNumberPairs =
                    numberPairs.Where(x => rnd.NextDouble() > x.score).ToList();
                if (selectedNumberPairs.Count > 0)
                    numberPairs = selectedNumberPairs;

                if (numberPairs.Count == 1)
                    return numberPairs.First();
            }
        }
    }
}
