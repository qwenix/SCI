using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Models {
    public class DriverReview {
        public int DaysPeriod { get; set; }
        public double Mileage { get; set; }
        public double AverageSpeed { get; set; }
        public double AverageRideMiles { get; set; }
        public int OverspeedingAmount { get; set; }
        public int SharpTurnEntriesAmount { get; set; }
        public int SharpSpeedUpsAmount { get; set; }
        public int SharpSlowDownsAmount { get; set; }
        public int SharpSteeringsWheelAmount { get; set; }
        public double PhoneUsageTime { get; set; }
    }
}