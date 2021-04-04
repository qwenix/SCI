using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Models {
    public class CertificateInfo {
        public string Issuer { get; set; }
        public string PublicKey { get; set; }
        public string SerialNumber { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
    }
}
