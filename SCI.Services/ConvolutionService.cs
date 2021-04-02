using SCI.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Services {
    public class ConvolutionService : IConvolutionService {
        public double CountConvolution(List<KeyValuePair<double, double>> ratesWeights) {
            double convolutionResult = 0;
            foreach (var p in ratesWeights) {
                convolutionResult += p.Key * p.Value;
            }
            return convolutionResult;
        }
    }
}
