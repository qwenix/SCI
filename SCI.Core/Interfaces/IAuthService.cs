﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Interfaces {
    public interface IAuthService {

        bool IsEmailExist(string email);
    }
}