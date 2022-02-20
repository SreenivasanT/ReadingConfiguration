using ReadingConfiguration.Model;

var builder = WebApplication.CreateBuilder(args);


#region Start reading AppSettings.Json file
//Reading Configuration file using JSon
builder.Services.Configure<MySettingsConfiguration>(
    builder.Configuration.GetSection("MySettings"));
builder.Services.AddConfig(builder.Configuration);
#endregion
// Add services to the container.

builder.Services.AddControllers();

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
