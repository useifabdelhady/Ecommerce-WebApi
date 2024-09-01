using Ecommerce.Api;
using Ecommerce.Api.Extensions;
using Ecommerce.Presentation.Actions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Service Extensions
builder.Services.ConfigureCors();
builder.Services.ConfigureSqlServer(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureAutoMapper();
builder.Services.AddAuthentication(); // Auth Identity
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.AddScoped<ValidationActionAttribute>();
builder.Services.AddScoped<ValidationProductAttribute>();

builder.Services.AddControllers();
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
app.UseCors();
app.UseHttpsRedirection();
// Extenstions
app.ConfigureExceptionHandler();

// auth Identity
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
