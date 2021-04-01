using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SCI.Core.Constants;
using SCI.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Services {
    public class AdminService : IAdminService {

        private readonly IConfiguration configuration;
        private readonly IOptions<CertificateInfo> certificateOptions;

        public AdminService(IConfiguration configuration) {
            this.configuration = configuration;
        }

        public async Task BackupDatabase(string path) {
            if (path is null || path == string.Empty) {
                path = configuration.GetValue<string>(AppSettingsStrings.BACKUP_FOLDER);
            }

            string connectionString = configuration.GetConnectionString(
                AppSettingsStrings.MAIN_CONNECTION);
            var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
            var backupFileName = string.Format("{0}{1}-{2}.bak",
                path, connectionStringBuilder.InitialCatalog,
                DateTime.Now.ToString("yyyy-MM-dd"));

            using var connection = new SqlConnection(connectionStringBuilder.ConnectionString); 
            var query = string.Format("BACKUP DATABASE {0} TO DISK='{1}'",
                connectionStringBuilder.InitialCatalog, backupFileName);

            using var command = new SqlCommand(query, connection); 
            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        public CertificateInfo GetCertificateInfo() {
            return certificateOptions.Value;
        }
    }
}
