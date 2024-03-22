using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using QuizCrafter.Modules.Quizzes.Api.Startup;
using QuizCrafter.Modules.Quizzes.Application.Extensions;
using QuizCrafter.Modules.Quizzes.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
builder.Services.AddMediatR(conf => conf.RegisterServicesFromAssemblies(typeof(Program).Assembly, typeof(ApplicationStartupExtensions).Assembly));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureCors(builder.Configuration);
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();

app.Run();
