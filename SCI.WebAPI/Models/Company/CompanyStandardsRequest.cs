using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCI.WebAPI.Models.Company {
    public class CompanyStandardsRequest {
        public double MileageUnit { get; set; }
        public double MaxDiscountPersentage { get; set; }

        public double MaxMileage { get; set; }
        public double MileagePriority { get; set; }

        public double MaxAverageSpeed { get; set; }
        public int AverageSpeedPriority { get; set; }

        public double MaxAverageRideMiles { get; set; }
        public int AverageRideMilesPriority { get; set; }

        public double MaxSpeed { get; set; }
        public int MaxOverSpeedingAmount { get; set; }
        public int OverSpeedingAmountPriority { get; set; }

        public double MinTurnEntryGrade { get; set; }
        public int MaxSharpTurnEntriesAmount { get; set; }
        public int SharpTurnEntriesAmountPriority { get; set; }

        public double MinSpeedUpGrade { get; set; }
        public int MaxSharpSpeedUpsAmount { get; set; }
        public int SharpSpeedUpsAmountPriority { get; set; }

        public double MinSlowDownGrade { get; set; }
        public int MaxSharpSlowDownsAmount { get; set; }
        public int SharpSlowDownsAmountPriority { get; set; }

        public double MinSteeringWheelGrade { get; set; }
        public int MaxSharpSteeringsWheelAmount { get; set; }
        public int SharpSteeringsWheelAmountPriority { get; set; }

        public int MaxPhoneUsageSeconds { get; set; }
        public int PhoneUsageSecondsPriority { get; set; }
    }
}
