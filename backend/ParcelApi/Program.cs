using ParcelApi.Data;
using ParcelApi.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ParcelManager") ?? "Data Source=ParcelManager.db";

builder.Services.AddSqlite<ParcelManagerContext>(connectionString);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<BagService>();
builder.Services.AddScoped<ParcelBagService>();
builder.Services.AddScoped<LetterBagService>();
builder.Services.AddScoped<ParcelService>();
builder.Services.AddScoped<ShipmentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
