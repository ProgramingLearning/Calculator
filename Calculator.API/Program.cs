using Calculator.Logic;
using Calculator.Logic.Errors;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var devCorsPolicy = "devCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(devCorsPolicy, builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
builder.Services.AddSingleton<ICalculatorValidator, CalculatorValidator>();
builder.Services.AddSingleton<ICalculatorError, CalculatorError>();
builder.Services.AddSingleton<IStringToNumberConvertor, StringToNumberConvertor>();
// because of calculatorState in calculator logic, these cannot be singleton
builder.Services.AddScoped<ISingleTermOperationLogic, SingleTermOperationLogic>();
builder.Services.AddScoped<IMultipleTermOperationLogic, MultipleTermOperationLogic>();
builder.Services.AddScoped<ICalculatorService, CalculatorService>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors(devCorsPolicy);
app.Run();

