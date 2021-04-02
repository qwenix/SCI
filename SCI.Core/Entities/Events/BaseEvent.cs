using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Entities.Events {
    public abstract class BaseEvent {
        public virtual DateTime DateTime { get; set; }
        public virtual int DriverId { get; set; }

        public virtual Driver Driver { get; set; }
    }
}
