using Kutuphane.Model;
using Kutuphane.Repository;
using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;
using NLog;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
LogManager.Configuration = new NLogLoggingConfiguration(config.GetSection("NLog"));
builder.Services.AddLogging(loggingBuilder => {
    loggingBuilder.ClearProviders();
    loggingBuilder.AddNLog();
});

// Add services to the container.
builder.Services.AddDbContext<RepositoryContext>(opts => opts.UseSqlServer("Data Source=.\\SQLSERVER;Initial Catalog=KutuphaneDb;Integrated Security=True; TrustServerCertificate=True"));
builder.Services.AddScoped<RepositoryWrapper, RepositoryWrapper>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddControllers().AddJsonOptions(opts => opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/error-development");
}
else
{
    app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
