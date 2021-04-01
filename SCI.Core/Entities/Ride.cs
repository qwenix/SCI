using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Entities {
    public class Ride {
        public string DriverId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public double AverageSpeed { get; set; }
        public double Miles { get; set; }
        public double OverSpeedingAmount { get; set; }
        public double TurnEntriesAmount { get; set; }
        public double SpeedUpsAmount { get; set; }
        public double SlowDownsAmount { get; set; }
        public double SteeringsWheelAmount { get; set; }
        public double PhoneUsageTime { get; set; }

        public Driver Driver { get; set; }
    }
}
