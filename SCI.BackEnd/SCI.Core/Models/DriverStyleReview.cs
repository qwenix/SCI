using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Models {
    public class DriverStyleReview {
        public string DriverUsername { get; set; }
        public int DaysPeriod { get; set; }

        public double MileageRate { get; set; }
        public double AverageSpeedRate { get; set; }
        public double AverageRideMilesRate { get; set; }
        public double OverSpeedingAmountRate { get; set; }
        public double SharpTurnEntriesAmountRate { get; set; }
        public double SharpSpeedUpsAmountRate { get; set; }
        public double SharpSlowDownsAmountRate { get; set; }
        public double SharpSteeringsWheelAmountRate { get; set; }
        public double PhoneUsageSecondsRate { get; set; }

        public double TotalScore { get; set; }
    }
}
