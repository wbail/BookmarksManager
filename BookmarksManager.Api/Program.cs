using BookmarksManager.Api.Configurations;
using BookmarksManager.App;
using BookmarksManager.Infrastructure;
using BookmarksManager.Persistence;

var builder = WebApplication.CreateBuilder(args);

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetService<IConfiguration>();

AppServiceRegistration.AddAppServices(builder.Services);
PersistenceServiceRegistration.AddPersistenceServices(builder.Services, configuration);
InfrastructureServiceRegistration.AddInfrastructureServices(builder.Services, configuration);
JwtConfiguration.Configure(builder.Services, configuration);
SwaggerConfiguration.Configure(builder.Services, configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
