﻿using SCI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Entities {
    public class Role : BaseEntity {

        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}