using SCI.Core.Entities.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Entities {
    public class Driver : BaseEntity {

        public int CompanyId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Company Company { get; set; }

        public ICollection<Ride> Rides { get; set; }

        #region Events

        public ICollection<EngineOffEvent> EngineOffEvents { get; set; } = new HashSet<EngineOffEvent>();
        public ICollection<EngineOnEvent> EngineOnEvents { get; set; } = new HashSet<EngineOnEvent>();
        public ICollection<EquipmentInstallEvent> EquipmentInstallEvents { get; set; } = new HashSet<EquipmentInstallEvent>();
        public ICollection<PhoneFreeEvent> PhoneFreeEvents { get; set; } = new HashSet<PhoneFreeEvent>();
        public ICollection<PhoneUseEvent> PhoneUseEvents { get; set; } = new HashSet<PhoneUseEvent>();
        public ICollection<SlowDownEvent> SlowDownEvents { get; set; } = new HashSet<SlowDownEvent>();
        public ICollection<SpeedUpEvent> SpeedUpEvents { get; set; } = new HashSet<SpeedUpEvent>();
        public ICollection<SpeedChangeEvent> SpeedChangeEvents { get; set; } = new HashSet<SpeedChangeEvent>();
        public ICollection<SteeringWheelEvent> SteeringWheelEvents { get; set; } = new HashSet<SteeringWheelEvent>();
        public ICollection<TurnEntryEvent> TurnEntryEvents { get; set; } = new HashSet<TurnEntryEvent>();

        #endregion
    }
}
