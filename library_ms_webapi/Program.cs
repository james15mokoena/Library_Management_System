using library_ms_webapi.Data;
using library_ms_webapi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// get the connection string to the library database "librarydb".
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// enable the use of controllers.
builder.Services.AddControllers();

// register the AppDbContext with the DI container.
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)));

// register the services that implement APIs functionality.
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<PasswordService>();
builder.Services.AddScoped<AuthService>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.MapControllers();

app.Run();