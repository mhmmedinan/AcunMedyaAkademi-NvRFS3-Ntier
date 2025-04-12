
//Uygulama oluþuturmaya yarar
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

