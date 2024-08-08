using Microsoft.EntityFrameworkCore;
using wandermate_backend.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();     //api end point
builder.Services.AddSwaggerGen();

//AddCors() for cross origin resource sharing policies
// builder.Services.AddCors(options => {
//     options.AddPolicy("AllowAll", builder =>{
//         builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
//     });
// });
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

// builder.Services.AddMemoryCache();
// builder.Services.AddSession(options =>{

// })

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.MapControllers();   //adding map controllers
app.Run();

