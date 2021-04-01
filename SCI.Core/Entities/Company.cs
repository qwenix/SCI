using Microsoft.AspNetCore.Identity;
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


        public double MaxAverageSpeed { get; set; }
        public int AverageSpeedPriority { get; set; }

        public double MaxAverageRideMiles { get; set; }
        public int AverageRideMilesPriority { get; set; }

        public double MaxSpeed { get; set; }
        public int AllowedOverSpeedingAmount { get; set; }
        public int OverSpeedingAmountPriority { get; set; }

        public double MinTurnEntryGrade { get; set; }
        public int AllowedTurnEntriesAmount { get; set; }
        public int TurnEntriesAmountPriority { get; set; }

        public double MinSpeedUpGrade { get; set; }
        public int AllowedSpeedUpsAmount { get; set; }
        public int SpeedUpsAmountPriority { get; set; }

        public double MinSlowDownGrade { get; set; }
        public int AllowedSlowDownsAmount { get; set; }
        public int SlowDownsAmountPriority { get; set; }

        public double MinSteeringWheelGrade { get; set; }
        public int AllowedSteeringsWheelAmount { get; set; }
        public int SteeringsWheelAmountPriority { get; set; }

        public double MaxPhoneUsageTime { get; set; }
        public double AllowedPhoneUsageTime { get; set; }
        public int PhoneUsageTimePriority { get; set; }

        #endregion

        public User User { get; set; }
        public ICollection<Driver> Drivers { get; set; }
    }
}
