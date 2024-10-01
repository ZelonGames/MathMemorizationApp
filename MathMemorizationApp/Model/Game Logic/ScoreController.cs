using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MathMemorizationApp
{
    public class ScoreController
    {
        public static NumberPair.OperatorMode operatorMode = NumberPair.OperatorMode.Addition;
        public static Dictionary<string, NumberPair> GetNormalizedScores(Dictionary<string, NumberPair> numberPairs)
        {
            IEnumerable<double> scores = numberPairs.Select(x => x.Value.score);
            double min = scores.Min();
            double max = scores.Max();
            
            Dictionary<string, NumberPair> normalizedNumberPairScores = new();

            foreach (var numberPair in numberPairs)
            {
                // normalize between 0.5 and 1
                double minRange = 1d / numberPairs.Count;
                double maxRange = 1;
                double range = max - min;
                range = max == min ? 1 : range;
                double normalizedScore = max == 0 ? minRange :
                    minRange + ((numberPair.Value.score - min) / range * (maxRange - minRange));
                /*if (numberPair.Value.score - min == 0)
                    normalizedScore = minRange;*/
                
                var newNumberPair = new NumberPair(
                    numberPair.Value.leftNumber,
                    numberPair.Value.rightNumber,
                    normalizedScore,
                    operatorMode);
                normalizedNumberPairScores.Add(numberPair.Key, newNumberPair);
            }

            return normalizedNumberPairScores;
        }

        public static void UpdateNumberPairScores(Dictionary<string, NumberPair> numberPairs, NumberPair numberPair, int userInput, out bool userGaveCorrectAnswer)
        {
            string key = numberPair.leftNumber.ToString() + numberPair.rightNumber;
            userGaveCorrectAnswer = userInput == numberPair.Operate();
            if (userGaveCorrectAnswer)
                numberPairs[key].score++;
            else
                numberPairs[key].score--;
        }
    }
}
