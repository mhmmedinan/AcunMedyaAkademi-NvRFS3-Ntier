using Business;
using Core.Exceptions.Extensions;
using Core.Security.Encryption;
using Core.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRepositoriesServices(builder.Configuration);
builder.Services.AddBusinessServices();



//AddScoped => //Her Http request icin bir kez olusturulur

//AddSingleton => Uygulama basladiginda bir kez olusturulur.Çok sýk kullailan ve degismeyen yapilar icin. Cache,config islemleri icin kullanilir.

//AddTransiet => Her kullanimda yeni bir nesne olusturur. cok hafif objeler veya bagimsiz is yapan kucuk servisler icin kullanilir.=> EmailSenderService

builder.Services.AddControllers(); //controller servislerini tanýmlar.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

TokenOptions? tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey),
        ClockSkew = TimeSpan.Zero
    };
});

//Uygulamalarý yapýlandýrýr
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ConfigureCustomExceptionMiddleware();
}

if (app.Environment.IsProduction())
{
    app.ConfigureCustomExceptionMiddleware();
}

app.UseAuthentication();
app.UseAuthorization();
// Configure the HTTP request pipeline.

app.MapControllers(); // Http isteklerini controller'lara yönlendirir.


app.Run();

