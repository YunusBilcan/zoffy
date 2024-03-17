using MongoDB.Driver;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
     {
         options.AddPolicy(name: "AllowAll",
          builder =>
          {
              builder.AllowAnyOrigin() // Tüm kaynaklara izin ver
                     .AllowAnyMethod() // Tüm metodlara izin ver
                     .AllowAnyHeader(); // Tüm başlıklara izin ver
          });
     });

var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("MongoDb");
builder.Services.AddSingleton<IMongoClient>(new MongoClient(connectionString));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.UseStaticFiles();
app.UseAuthorization();
app.Run();