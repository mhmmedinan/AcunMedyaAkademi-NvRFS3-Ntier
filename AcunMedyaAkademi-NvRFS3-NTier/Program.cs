
//Uygulama olu�uturmaya yarar
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); //controller servislerini tan�mlar.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Uygulamalar� yap�land�r�r
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.MapControllers(); // Http isteklerini controller'lara y�nlendirir.

app.Run();

