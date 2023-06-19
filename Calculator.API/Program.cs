using System.Text.Json.Serialization;
using Calculator.Logic;
using Calculator.Logic.Errors;

var builder = WebApplication.CreateBuilder(args);
var devCorsPolicy = "devCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(devCorsPolicy, builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ICalculatorLogic, CalculatorLogic>();
builder.Services.AddSingleton<ICalculatorError, CalculatorError>();
builder.Services.AddSingleton<ICalculatorValidator, CalculatorValidator>();
builder.Services.AddSingleton<IStringToNumberConvertor, StringToNumberConvertor>();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors(devCorsPolicy);
app.Run();

