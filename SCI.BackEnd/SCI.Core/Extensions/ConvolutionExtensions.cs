using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Extensions {
    public static class ConvolutionExtensions {

        public static double Normalize(this double value, double standard, double max) {
            if (value == 0) {
                return max;
            }
            double tempExpression = standard / value * max;
            return tempExpression > max ? max : tempExpression;
        }

        public static double Normalize(this int value, int standard, double max) {
            if (value == 0) {
                return max;
            }
            double tempExpression = (double)standard / value * max;
            return tempExpression > max ? max : tempExpression;
        }

        public static List<KeyValuePair<double, double>> ToRatesWeightsList(
            this List<KeyValuePair<int, double>> ratesPriorities) {

            double maxPriority = ratesPriorities.Max(rw => rw.Key);
            double prioritySum = Enumerable.Range(1, ratesPriorities.Count).Sum();
            List<KeyValuePair<double, double>> ratesWeights = new(ratesPriorities.Select(rp => 
                new KeyValuePair<double, double>(maxPriority - rp.Key + 1, rp.Value)));

            ratesWeights.Sort(new RatesPrioritiesReverseComparer());
            for (int i = 0; i < ratesWeights.Count; i++) {
                double priority = ratesWeights[i].Key;
                int j = i;
                double weight = 0;
                while(j < ratesWeights.Count && ratesWeights[j].Key == priority) {
                    j++;
                    weight += ratesWeights.Count - j + 1;
                }
                weight /= j - i;

                int iCopy = i;
                i = --j;
                while(j >= iCopy) {
                    ratesWeights[j] = new KeyValuePair<double, double>(
                        weight / prioritySum,
                        ratesWeights[j].Value);
                    j--;
                }
            }

            return ratesWeights;
        }

        private class RatesPrioritiesReverseComparer : IComparer<KeyValuePair<double, double>> {
            public int Compare(KeyValuePair<double, double> x, KeyValuePair<double, double> y) {
                return y.Key.CompareTo(x.Key);
            }
        }
    }
}
