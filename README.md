# Feature Flags Demo (.NET 9.0)

This project demonstrates feature flag management in a .NET 9.0 Web API using Azure App Configuration and Microsoft.FeatureManagement. It supports user targeting and dynamic feature control.

## Prerequisites
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download)
- [Azure Developer CLI (azd)](https://aka.ms/azure-dev/install)
- (Optional) Visual Studio 2022+ or VS Code

## Quickstart: Deploy with azd

This project uses [Azure Developer CLI (azd)](https://aka.ms/azure-dev) to provision all required Azure resources—including App Configuration—automatically.

### 1. Clone the repository
```pwsh
git clone https://github.com/<your-org>/feature_flags.git
cd feature_flags
```

### 2. Login to Azure
```pwsh
az login
```

### 3. Provision resources and deploy
```pwsh
azd up
```
This command will:
- Provision all required Azure resources (App Configuration, etc.)
- Deploy the application
- Output endpoints and connection info

### 4. Run the API locally
```pwsh
cd src/FeatureFlagApi
pwsh
 dotnet restore
 dotnet run
```

The API will start on `https://localhost:5001` (or as configured).

## API Endpoints
- `GET /feature-flag` — Returns if the `Demo` feature is enabled for the current user.
- `GET /enabled-flags` — Lists all enabled feature flags for the current user.

## Feature Targeting
User targeting is implemented via `DemoTargetingContextAccessor` and `UserService`. You can customize user/group logic in these files.

## Troubleshooting
- Ensure you have run `azd up` and resources are provisioned.
- For more info, see [Microsoft Learn: Feature Management](https://learn.microsoft.com/en-us/azure/azure-app-configuration/feature-management-overview).

## Resources
- [Azure Developer CLI Docs](https://learn.microsoft.com/en-us/azure/developer/azure-developer-cli/)
- [Azure App Configuration Docs](https://learn.microsoft.com/en-us/azure/azure-app-configuration/)
- [Feature Management for .NET](https://learn.microsoft.com/en-us/azure/azure-app-configuration/feature-management-dotnet-reference)
- [Quickstart: ASP.NET Core + App Configuration](https://learn.microsoft.com/en-us/azure/azure-app-configuration/quickstart-aspnet-core-app)
