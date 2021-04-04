using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Entities.Events {
    public class EngineOffEvent : BaseEvent {
        public double Mileage { get; set; }
    }
}
