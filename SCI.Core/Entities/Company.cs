﻿using Microsoft.AspNet.Identity.EntityFramework;
using SCI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Entities {
    public partial class Company {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}