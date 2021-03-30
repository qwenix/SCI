using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCI.Core.Constants {
    public static class RegularExpressions {

        public const string EMAIL_REGEX = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        public const string PASSWORD_REGEX = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";
    }
}
