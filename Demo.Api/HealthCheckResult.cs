using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Api
{
    public class HealthCheckResult
    {
        public HealthCheckResult(string version, bool isDatabaseOK, bool isKeyVaultOK, bool isServiceDependancyOK)
        {
            Version = version ?? throw new ArgumentNullException(nameof(version));
            IsDatabaseOK = isDatabaseOK;
            IsKeyVaultOK = isKeyVaultOK;
            IsServiceDependancyOK = isServiceDependancyOK;
            Updated = DateTime.UtcNow;
        }

        public string Version { get; set; }
        public bool IsDatabaseOK { get; set; }

        public bool IsKeyVaultOK { get; set; }

        public bool IsServiceDependancyOK { get; set; }

        public bool IsOK { get { return IsDatabaseOK && IsKeyVaultOK && IsServiceDependancyOK} }

        public DateTime Updated { get; set; }

    }
}
