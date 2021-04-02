using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Extensions {
    public static class ConvolutionExtensions {

        public static double Normalize(this double value, double standard, double max) {
            double tempExpression = standard / value * max;
            return tempExpression > max ? tempExpression : max;
        }

        public static double Normalize(this int value, int standard, double max) {
            double tempExpression = (double)standard / value * max;
            return tempExpression > max ? tempExpression : max;
        }

        public static List<KeyValuePair<double, double>> ToRatesWeightsList(
            this List<KeyValuePair<int, double>> ratesPriorities) {

            List<KeyValuePair<double, double>> ratesWeights = new(ratesPriorities
                .Select(rp => new KeyValuePair<double, double>(rp.Key, rp.Value)));

            ratesWeights.Sort(new RatesPrioritiesComparer());
            for (int i = 0; i < ratesWeights.Count; i++) {
                double priority = ratesWeights[i].Key;
                int j = i;
                double weight = 0;
                while(j < ratesWeights.Count && ratesWeights[j].Key == priority) {
                    j++;
                    weight = (weight + ratesWeights.Count - j + 1) / j;
                }
                i = --j;
                while(j >= 0) {
                    ratesWeights[j] = new KeyValuePair<double, double>(weight, ratesWeights[j].Value);
                    j--;
                }
            }

            return ratesWeights;
        }

        private class RatesPrioritiesComparer : IComparer<KeyValuePair<double, double>> {
            public int Compare(KeyValuePair<double, double> x, KeyValuePair<double, double> y) {
                return x.Key.CompareTo(y.Key);
            }
        }
    }
}
