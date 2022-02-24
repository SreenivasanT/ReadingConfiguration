using ReadingConfiguration.Model;

var builder = WebApplication.CreateBuilder(args);


#region Start reading AppSettings.Json file
//Reading appsettings.json Configuration file using
builder.Services.Configure<MySettingsConfiguration>(
    builder.Configuration.GetSection("MySettings"));
builder.Services.AddConfig(builder.Configuration);
#endregion
// Add services to the container.

#region Code start for connecting the Azure App Configuration
// Using to connect the azure App configuration
var connectionString = builder.Configuration.GetConnectionString("AppConfig");
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    var settings = config.Build();
    config.AddAzureAppConfiguration(option =>
    {
        option.Connect(connectionString).ConfigureRefresh(refresh =>
        {
            refresh.Register("AAConfiguration:Sentinel", refreshAll:true).SetCacheExpiration(new TimeSpan(0, 0, 30));
        });
    });
})
.ConfigureServices(service =>
{    service.AddControllers();   
});
//Middleware for refreshing the azure App configuration
builder.Services.Configure<AAConfiguration>(builder.Configuration.GetSection("AAConfiguration"));
builder.Services.AddAzureAppConfiguration();
builder.Services.AddControllers();
#endregion

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// If statement can be removed if we need the swagger only in development
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }
//Middleware for refreshing the azure App configuration
app.UseAzureAppConfiguration();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
