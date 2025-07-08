using createUserUseCase;
using debitDbRepository;
using EmailRepository;
using getAllCreditUseCase;
using getByModuleUseCase;
using getBySaidaUseCase;
using getDebitUseCase;
using handleErrorCustumer;
using iCreditRepository;
using idebitRepository;
using ihandleErrorcustom;
using ijwtRepository;
using jwtService;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.IdentityModel.Tokens;
using ProjectFinancas.Domain.Service.SendEmail;
using ProjectFinancas.Domain.UseCase.EmailAuth;
using ProjectFinancas.Infra;
using System.Text;
using ProjectFinancas.Domain.Repositories;
using ProjectFinancas.Domain.UseCase;
using ProjectFinancas.Domain.UseCase.Clients;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<IDebitRepository, DebitDbRepository>();
builder.Services.AddSingleton<ICreditRepository, CreditDbRepository>();
builder.Services.AddSingleton<IUserRepository, UserDbRepository>();
builder.Services.AddSingleton<IHandleErrorCustom, HandleErrorCustumer>();
builder.Services.AddSingleton<IJwtRepository, JwtService>();
builder.Services.AddSingleton<IEmailRepository, EmailService>();
builder.Services.AddSingleton<EmailConfig>();
builder.Services.AddSingleton<EmailService>();
builder.Services.AddSingleton<EmailAuthUseCase>();
builder.Services.AddSingleton<EmailSendClient>();
builder.Services.AddSingleton<JwtService>();
builder.Services.AddSingleton<CreateDebitUseCase>();
builder.Services.AddSingleton<CreateCreditUseCase>();
builder.Services.AddSingleton<GetByModuleEntradaUseCase>();
builder.Services.AddSingleton<CreateClientsUseCase>();
builder.Services.AddSingleton<GetDebitDataUseCase>();
builder.Services.AddSingleton<ConnectionPostgres>();
builder.Services.AddSingleton<CreateUserUseCase>();
builder.Services.AddScoped<GetBySaidaUseCase>();
builder.Services.AddScoped<GetByEntradaUseCase>();
builder.Services.AddSingleton<GetBySaidaModuleUseCase>();
builder.Services.AddSingleton<GetAllCreditUseCase>();
builder.Services.AddSingleton<GetAll>();

var config = builder.Configuration;

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["SecretKey"]))
        };
    });
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();
builder.Host.UseSerilog();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddLogging();

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });
var app = builder.Build();
app.UseCors(); // Habilitar CORS

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
