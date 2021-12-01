using BookmarksManager.App;
using BookmarksManager.Infrastructure.Configurations;
using BookmarksManager.Persistence;

var builder = WebApplication.CreateBuilder(args);

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetService<IConfiguration>();

var googleChromeBookmarksPathConfiguration = new GoogleChromeBookmarksPathConfiguration();
googleChromeBookmarksPathConfiguration.GoogleChromeBookmarksPath = configuration.GetValue<string>("GoogleChromeBookmarksPath");
builder.Services.AddSingleton<GoogleChromeBookmarksPathConfiguration>(googleChromeBookmarksPathConfiguration);

BookmarksManagerServiceRegistration.AddAppServices(builder.Services);
PersistenceServiceRegistration.AddPersistenceServices(builder.Services, configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
