using SCI.Core.Entities;
using SCI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Extensions {
    public static class ModelsExtensions {

        public static PerUnitDriverRidesReview GetPerUnitDriverRidesReview(
            this DriverRidesReview driverRidesReview, double mileageUnit) {

            return new PerUnitDriverRidesReview {
                MileageUnit = mileageUnit,
                DriverRidesReview = new DriverRidesReview {
                    AverageRideMiles = driverRidesReview.AverageRideMiles,
                    AverageSpeed = driverRidesReview.AverageSpeed,
                    DaysPeriod = driverRidesReview.DaysPeriod,
                    DriverUsername = driverRidesReview.DriverUsername,
                    Mileage = driverRidesReview.Mileage,
                    TotalRides = driverRidesReview.TotalRides,
                    PhoneUsageSeconds = driverRidesReview.PhoneUsageSeconds /
                        driverRidesReview.Mileage * mileageUnit,
                    OverSpeedingAmount = Convert.ToInt32(Math.Floor(
                        driverRidesReview.OverSpeedingAmount /
                        driverRidesReview.Mileage * mileageUnit)),
                    SharpSlowDownsAmount = Convert.ToInt32(Math.Floor(
                        driverRidesReview.SharpSlowDownsAmount /
                        driverRidesReview.Mileage * mileageUnit)),
                    SharpSpeedUpsAmount = Convert.ToInt32(Math.Floor(
                        driverRidesReview.SharpSpeedUpsAmount /
                        driverRidesReview.Mileage * mileageUnit)),
                    SharpSteeringsWheelAmount = Convert.ToInt32(Math.Floor(
                        driverRidesReview.SharpSteeringsWheelAmount /
                        driverRidesReview.Mileage * mileageUnit)),
                    SharpTurnEntriesAmount = Convert.ToInt32(Math.Floor(
                        driverRidesReview.SharpTurnEntriesAmount /
                        driverRidesReview.Mileage * mileageUnit)),
                }
            };
        }

        public static DriverStyleReview GetDriverStyleReview(
            this PerUnitDriverRidesReview perUnitDriverRidesReview, 
            Company company, double rateScaleMaximum) {

            DriverRidesReview ridesReview = perUnitDriverRidesReview.DriverRidesReview;
            DriverStyleReview styleReview =  new DriverStyleReview {
                DaysPeriod = ridesReview.DaysPeriod,
                DriverUsername = ridesReview.DriverUsername,
                AverageRideMilesRate = ridesReview.AverageRideMiles
                    .Normalize(company.MaxAverageRideMiles, rateScaleMaximum),
                AverageSpeedRate = ridesReview.AverageSpeed
                    .Normalize(company.MaxAverageSpeed, rateScaleMaximum),
                MileageRate = ridesReview.Mileage
                    .Normalize(company.MaxMileage, rateScaleMaximum),
                OverSpeedingAmountRate = ridesReview.OverSpeedingAmount
                    .Normalize(company.MaxOverSpeedingAmount, rateScaleMaximum),
                PhoneUsageSecondsRate = ridesReview.PhoneUsageSeconds
                    .Normalize(company.MaxPhoneUsageSeconds, rateScaleMaximum),
                SharpSlowDownsAmountRate = ridesReview.SharpSlowDownsAmount
                    .Normalize(company.MaxSharpSlowDownsAmount, rateScaleMaximum),
                SharpSpeedUpsAmountRate = ridesReview.SharpSpeedUpsAmount
                    .Normalize(company.MaxSharpSpeedUpsAmount, rateScaleMaximum),
                SharpSteeringsWheelAmountRate = ridesReview.SharpSteeringsWheelAmount
                    .Normalize(company.MaxSharpSteeringsWheelAmount, rateScaleMaximum),
                SharpTurnEntriesAmountRate = ridesReview.SharpTurnEntriesAmount
                    .Normalize(company.MaxSharpTurnEntriesAmount, rateScaleMaximum),
            };

            return styleReview;
        }
    }
}
