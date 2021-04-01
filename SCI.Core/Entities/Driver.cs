﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Entities {
    public class Driver : BaseEntity {

        public string CompanyId;

        public ApplicationUser ApplicationUser { get; set; }
        public Company Company { get; set; }
    }
}
