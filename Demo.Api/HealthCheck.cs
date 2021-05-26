using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Api
{
    public static class HealthCheck
    {
        private static HealthCheckResult _HealthCheckResult = new HealthCheckResult("Unknown",false,false,false);
        
        public static HealthCheckResult Current()
        {
            return _HealthCheckResult;
        }

        public static void ExecuteHealthChecks()
        {
            var version = "Unknown";
            var variables = Environment.GetEnvironmentVariables();
            if (variables.Contains("APPLICATION_VERSION"))
                version = variables["APPLICATION_VERSION"].ToString();

            var databaseStatus = ValidateDatabaseConnection();
            var keyVaultStatus = ValidateKeyVaultConnection();
            var serviceStatus = ValidateServiceConnection();
            _HealthCheckResult = new HealthCheckResult(version, databaseStatus, keyVaultStatus, serviceStatus);
        }

        private static bool ValidateDatabaseConnection()
        {
            return true;
        }

        private static bool ValidateKeyVaultConnection()
        {
            return true;
        }

        private static bool ValidateServiceConnection()
        {
            return true;
        }
    }
}
