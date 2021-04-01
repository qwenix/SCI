﻿using Microsoft.AspNetCore.Identity;
using SCI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Entities {
    public partial class Company : BaseEntity {

        public string Name { get; set; }

        public User User { get; set; }
        public ICollection<Driver> Drivers { get; set; }
    }
}
