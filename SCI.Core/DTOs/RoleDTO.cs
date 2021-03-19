using SCI.Core.Entities;
using SCI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.DTOs {
    public class RoleDTO : BaseEntityDTO, IFullAccess {

        public string Name { get; set; }
    }
}
