Contribuinte c1 = new Contribuinte();

c1.nome = "KAUA";
c1.cpf = "017.489.992.06";

c1.salarioBruto = 5000M;
c1.quantDependentes = 2;

Console.WriteLine(Math.Round(c1.ValorINSS(),2));
Console.WriteLine(Math.Round(c1.BaseDeCalculo(),2));
Console.WriteLine(Math.Round(c1.ValorIRPF(),2));
Console.WriteLine(Math.Round(c1.SalarioLiquido(),2));