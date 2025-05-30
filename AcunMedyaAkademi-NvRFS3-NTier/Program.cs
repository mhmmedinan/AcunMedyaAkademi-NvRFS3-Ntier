
//Uygulama oluşuturmaya yarar
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); //controller servislerini tanımlar.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Uygulamaları yapılandırır
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.MapControllers(); // Http isteklerini controller'lara yönlendirir.

app.Run();

