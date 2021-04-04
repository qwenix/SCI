using Microsoft.AspNetCore.Identity;
using SCI.Core.Attributes;
using SCI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Entities {
    public partial class Company : BaseEntity {

        public string Name { get; set; }

        #region Configuration Properties

        public double MileageUnit { get; set; }
        public double MaxDiscountPersentage { get; set; }

        public double MaxMileage { get; set; }
        [PriorityProperty]
        public double MileagePriority { get; set; }

        public double MaxAverageSpeed { get; set; }
        [PriorityProperty]
        public int AverageSpeedPriority { get; set; }

        public double MaxAverageRideMiles { get; set; }
        [PriorityProperty]
        public int AverageRideMilesPriority { get; set; }

        public double MaxSpeed { get; set; }
        public int MaxOverSpeedingAmount { get; set; }
        [PriorityProperty]
        public int OverSpeedingAmountPriority { get; set; }

        public double MinTurnEntryGrade { get; set; }
        public int MaxSharpTurnEntriesAmount { get; set; }
        [PriorityProperty]
        public int SharpTurnEntriesAmountPriority { get; set; }

        public double MinSpeedUpGrade { get; set; }
        public int MaxSharpSpeedUpsAmount { get; set; }
        [PriorityProperty]
        public int SharpSpeedUpsAmountPriority { get; set; }

        public double MinSlowDownGrade { get; set; }
        public int MaxSharpSlowDownsAmount { get; set; }
        [PriorityProperty]
        public int SharpSlowDownsAmountPriority { get; set; }

        public double MinSteeringWheelGrade { get; set; }
        public int MaxSharpSteeringsWheelAmount { get; set; }
        [PriorityProperty]
        public int SharpSteeringsWheelAmountPriority { get; set; }

        public int MaxPhoneUsageSeconds { get; set; }
        [PriorityProperty]
        public int PhoneUsageSecondsPriority { get; set; }

        #endregion

        public User User { get; set; }
        public ICollection<Driver> Drivers { get; set; }
    }
}
