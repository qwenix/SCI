using SCI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Interfaces.Services {

    public interface IAdminService {

        Task BackupDatabase(string path);

        CertificateInfo GetCertificateInfo();
    }
}
