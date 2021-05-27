# Service Health Checks Demo

## Liveness Endpoint

Endpoint that validates service running and is accessible.

**Example Implementation**

```csharp
public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "status")] HttpRequest req, ILogger log)
{
   return new OkObjectResult("OK");
}
```

## Health Check Endpoint

Endpoint that validates service is running correctly by validating dependencies. Dependencies checks should be run in background and provided as a cached response from status endpoint.

Sample Dependencies:
- Storage
- Database
- KeyVault
- Service Dependancies


**Example Implementation**

```csharp
public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "status/full")] HttpRequest req, ILogger log)
{
    // Get cached health check status
    var health = HealthCheck.Current();
    if (!health.IsOK)
    {
        var result = new ObjectResult(health);
        result.StatusCode = 500;
        return result;
    }
            
    return new OkObjectResult(health);
}
```

```csharp
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
```




