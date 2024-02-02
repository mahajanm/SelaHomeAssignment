using Sela.Task.API.Repositories.Implementation;
using Sela.Task.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Sela.Task.API.Data;
using Sela.Task.API.Mappings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Sela.Task.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TaskDetailDbContext>(options =>
    options.UseInMemoryDatabase(databaseName: "TaskDetailAPIDb"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();
builder.Services.AddScoped<ITaskDetailRepository, TaskDetailRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.AddScoped<ExceptionHandlerMiddleware>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowTaskManagementUI",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
else
{
    app.UseHttpsRedirection();
}


app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseRouting();

app.UseCors("AllowTaskManagementUI");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
