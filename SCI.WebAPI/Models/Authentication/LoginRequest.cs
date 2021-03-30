using SCI.Core.Constants;
using SCI.WebAPI.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SCI.WebAPI.Models.Authentication {
    public class LoginRequest {
        [RegularExpression(RegularExpressions.EMAIL_REGEX, ErrorMessage = Messages.INVALID_FORMAT)]
        public string Email { get; set; }

        //[RegularExpression(RegularExpressions.PASSWORD, ErrorMessage = Messages.INVALID_FORMAT)]
        public string Password { get; set; }
    }
}
