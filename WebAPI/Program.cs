using Business;
using Core.Exceptions.Extensions;
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

// Configure the HTTP request pipeline.

app.MapControllers(); // Http isteklerini controller'lara yönlendirir.


app.Run();

