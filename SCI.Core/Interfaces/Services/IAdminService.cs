using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Interfaces.Services {

    public record CertificateInfo(
        string Issuer,
        string PublicKey,
        string SerialNumber,
        string ValidFrom,
        string ValidTo
        );

    public interface IAdminService {

        Task BackupDatabase(string path);

        CertificateInfo GetCertificateInfo();
    }
}
