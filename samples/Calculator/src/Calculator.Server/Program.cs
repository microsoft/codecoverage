using Calculator.Core;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet($"/{OperationCalculator.Add}/{{a}}/{{b}}/", (double a , double b) => OperationCalculator.CalculateAdd(a, b).ToString());
app.MapGet($"/{OperationCalculator.Multiply}/{{a}}/{{b}}/", (double a , double b) => OperationCalculator.CalculateMultiply(a, b).ToString());
app.MapGet($"/{OperationCalculator.Substract}/{{a}}/{{b}}/", (double a , double b) => OperationCalculator.CalculateSubstract(a, b).ToString());
app.MapGet($"/{OperationCalculator.Devide}/{{a}}/{{b}}/", (double a , double b) => OperationCalculator.CalculateDevide(a, b).ToString());

app.Run();
public partial class Program { }
