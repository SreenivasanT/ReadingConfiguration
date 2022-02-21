using ReadingConfiguration.Model;

var builder = WebApplication.CreateBuilder(args);


#region Start reading AppSettings.Json file
//Reading Configuration file using JSon
builder.Services.Configure<MySettingsConfiguration>(
    builder.Configuration.GetSection("MySettings"));
builder.Services.AddConfig(builder.Configuration);
#endregion
// Add services to the container.

#region Code start for connecting the Azure App Configuration

var connectionString = builder.Configuration.GetConnectionString("AppConfig");
builder.Host.ConfigureAppConfiguration(builder =>
{
    builder.AddAzureAppConfiguration(option =>
    {
        option.Connect(connectionString).ConfigureRefresh(refresh =>
        {
            refresh.Register("Sentinel", true).SetCacheExpiration(new TimeSpan(0, 0, 20));
        });
    });
})
.ConfigureServices(service =>
{
    service.AddControllers();   
});

// Add services to the container.This is commented as getting created when connecting the Azure App configuration in the above line
// builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
