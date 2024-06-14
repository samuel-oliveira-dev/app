using App;

var ano = new Ano();

foreach (var item in ano.Dias)
{
    Console.WriteLine(item.ToString());
}

var maiorFaturamento = ano.GetFaturamentoMaximo();
var menorFaturamento = ano.GetFaturamentoMinimo();
Console.WriteLine($"Maior Faturamento: {maiorFaturamento.ToString()}");
Console.WriteLine($"Menor Faturamento: {menorFaturamento.ToString()}");
Console.WriteLine($"Media: {ano.GetMedia()}");
Console.WriteLine($"Dias faturados acima da média: {ano.GetQtdFaturamentoAcimaMedia()}");