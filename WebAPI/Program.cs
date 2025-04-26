using Business.Abstracts;
using Business.Concretes;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstracts;
using Repositories.Concretes.EntityFramework;
using Repositories.Concretes.EntityFramework.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BaseDbContext>(op=>op.UseSqlServer(builder.Configuration.GetConnectionString("BaseDb")));

builder.Services.AddScoped<IBrandService, BrandManager>();  //Her Http request icin bir kez olusturulur
builder.Services.AddScoped<IBrandRepository,BrandRepository>();

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
}

// Configure the HTTP request pipeline.

app.MapControllers(); // Http isteklerini controller'lara yönlendirir.


app.Run();

