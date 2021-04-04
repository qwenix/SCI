using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Entities {
    public class Ride {
        public int DriverId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double AverageSpeed { get; set; }
        public double Mileage { get; set; }
        public int OverSpeedingAmount { get; set; }
        public int SharpTurnEntriesAmount { get; set; }
        public int SharpSpeedUpsAmount { get; set; }
        public int SharpSlowDownsAmount { get; set; }
        public int SharpSteeringsWheelAmount { get; set; }
        public int PhoneUsageSeconds { get; set; }

        public Driver Driver { get; set; }
    }
}
