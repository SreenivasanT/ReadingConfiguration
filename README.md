# ReadingConfiguration
Reading the configuration of app in .Net 6
1. Create secret manager key for connecting to Azure App Configuration in local machine while development
dotnet user-secrets init

2. Configure connection string of Azure App configuration in secret manager.

dotnet user-secrets set ConnectionStrings:AppConfig "Endpoint=https://sreeappconfiguration.azconfig.io;Id=gaV5-lh-s0:NIGgl+xNTfRcl4i3PWKX;Secret=ewzeGox8V3RsI7S0tGC0GXBaFRRfVAsPnI1ZBuR//9I="

3. Add package from Nuget Microsoft.Azure.AppConfiguration.AspNetCore

4. When publishing to the App Service we need to configure the App configuration connection string in Configuration -> Connection String --> Create New
	Name - AppConfig
	Value - <App configuration Primary connection string>
	Type - Custom
