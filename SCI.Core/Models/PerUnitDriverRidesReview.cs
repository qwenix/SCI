using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Models {
    public class PerUnitDriverRidesReview {
        public double MileageUnit { get; set; }
        public DriverRidesReview DriverRidesReview { get; set; }
    }
}