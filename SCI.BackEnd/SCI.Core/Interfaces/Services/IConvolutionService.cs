using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Interfaces.Services {
    public interface IConvolutionService {
        double CountConvolution(List<KeyValuePair<double, double>> ratesWeights);
    }
}
