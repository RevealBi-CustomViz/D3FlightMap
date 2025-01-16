using Reveal.Sdk;
using RevealSdk.Sdk;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddReveal(builder =>
{
    builder
        .AddDataSourceProvider<DataSourceProvider>();
        // Add any other providers

        // Add settings like license key and local file storage path
        //.AddSettings(settings =>
        //{
        //    settings.License = "eyJhbGciOiJQUzUx";
        //    settings.LocalFileStoragePath = "Data";
        //});
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowAll",
    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
  );
});

var app = builder.Build();

app.UseCors("AllowAll");

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
