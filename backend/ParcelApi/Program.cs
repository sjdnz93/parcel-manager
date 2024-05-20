using ParcelApi;
using ParcelApi.Data;
using ParcelApi.Interfaces;
using ParcelApi.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ParcelManager") ?? "Data Source=ParcelManager.db";

builder.Services.AddSqlite<ParcelManagerContext>(connectionString);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBagService, BagService>();
builder.Services.AddScoped<IParcelBagService, ParcelBagService>();
builder.Services.AddScoped<ILetterBagService, LetterBagService>();
builder.Services.AddScoped<IParcelService, ParcelService>();
builder.Services.AddScoped<IShipmentService, ShipmentService>();

builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
  builder.WithOrigins("http://localhost:4200") // Adjust this to your Client app's URL
        .AllowAnyMethod()
        .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
