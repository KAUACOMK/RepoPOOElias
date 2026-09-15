public class CalculoDeHolerite
{
    public static decimal SalarioLiquido(decimal salarioBruto, decimal inss, decimal irpf)
    {
        return salarioBruto - inss - irpf;
    }


    public static decimal ValorINSS(decimal salario)
    {
        decimal faixa1 = 1612.00M;
        decimal faixa2 = 2800.00M;
        decimal faixa3 = 4200.00M;
        decimal faixa4 = 8537.55M;

        if (salario <= faixa1)
            return Math.Round(salario * 0.075M, 2);

        else if (salario <= faixa2)
            return Math.Round((faixa1 * 0.075M) + ((salario - faixa1) * 0.09M), 2);

        else if (salario <= faixa3)
            return Math.Round((faixa1 * 0.075M) + ((faixa2 - faixa1) * 0.09M) + ((salario - faixa2) * 0.12M), 2);

        else if (salario <= faixa4)
            return Math.Round((faixa1 * 0.075M) + ((faixa2 - faixa1) * 0.09M) + ((faixa3 - faixa2) * 0.12M) + ((salario - faixa3) * 0.14M), 2);

        return Math.Round((faixa1 * 0.075M) + ((faixa2 - faixa1) * 0.09M) + ((faixa3 - faixa2) * 0.12M) + ((faixa4 - faixa3) * 0.14M), 2);


    }

    public static decimal BaseDeCalculo(decimal salarioBruto, decimal inss, int dependentes)
    {
        decimal valorPorDependente = 189.59M;
        return salarioBruto - inss - (valorPorDependente * dependentes);
    }

    public static decimal ValorIRPF(decimal baseCalculo)
    {
        if (baseCalculo <= 2826.65M)
            return (baseCalculo * 0.075M) - 182.16M;
        else if (baseCalculo <= 3751.05M)
            return (baseCalculo * 0.15M) - 394.16M;
        else if (baseCalculo <= 4664.68M)
            return (baseCalculo * 0.225M) - 675.49M;
        else if (baseCalculo > 4664.68M)
            return (baseCalculo * 0.275M) - 908.73M;

        return 0;
    }

}

