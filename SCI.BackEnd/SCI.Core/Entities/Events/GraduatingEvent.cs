using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Entities.Events {
    public abstract class GraduatingEvent : BaseEvent {
        public virtual double Grade { get; set; }
    }
}
