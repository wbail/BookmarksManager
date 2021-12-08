using BookmarksManager.App;
using BookmarksManager.Infrastructure.Configurations;
using BookmarksManager.Persistence;

var builder = WebApplication.CreateBuilder(args);

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetService<IConfiguration>();

var googleChromeBookmarksPathConfigurationWindows = new GoogleChromeBookmarksPathConfigurationWindows();
googleChromeBookmarksPathConfigurationWindows.GoogleChromeBookmarksPathWindows = configuration.GetValue<string>("GoogleChromeBookmarksPathWindows");
builder.Services.AddSingleton<GoogleChromeBookmarksPathConfigurationWindows>(googleChromeBookmarksPathConfigurationWindows);

var googleChromeBookmarksPathConfigurationLinux = new GoogleChromeBookmarksPathConfigurationLinux();
googleChromeBookmarksPathConfigurationLinux.GoogleChromeBookmarksPathLinux = configuration.GetValue<string>("GoogleChromeBookmarksPathLinux");
builder.Services.AddSingleton<GoogleChromeBookmarksPathConfigurationLinux>(googleChromeBookmarksPathConfigurationLinux);

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
