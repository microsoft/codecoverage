using Calculator.Core;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/add/{a}/{b}/", (double a , double b) => OperationCalculator.CalculateAdd(a, b).ToString());
app.MapGet("/multiply/{a}/{b}/", (double a , double b) => OperationCalculator.CalculateMultiply(a, b).ToString());
app.MapGet("/substract/{a}/{b}/", (double a , double b) => OperationCalculator.CalculateSubstract(a, b).ToString());
app.MapGet("/devide/{a}/{b}/", (double a , double b) => OperationCalculator.CalculateDevide(a, b).ToString());

app.Run();
