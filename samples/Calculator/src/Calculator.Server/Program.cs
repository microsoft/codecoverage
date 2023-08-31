using Calculator.Core;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet($"/{OperationCalculator.Add}/{{a}}/{{b}}/", (double a , double b) => OperationCalculator.CalculateAdd(a, b).ToString());
app.MapGet($"/{OperationCalculator.Multiply}/{{a}}/{{b}}/", (double a , double b) => OperationCalculator.CalculateMultiply(a, b).ToString());
app.MapGet($"/{OperationCalculator.Subtract}/{{a}}/{{b}}/", (double a , double b) => OperationCalculator.CalculateSubtract(a, b).ToString());
app.MapGet($"/{OperationCalculator.Divide}/{{a}}/{{b}}/", (double a , double b) => OperationCalculator.CalculateDivide(a, b).ToString());

app.Run();
public partial class Program { }
