
    public class CalculoValorIRPF
    {
    public static decimal BaseDeCalculo(decimal salarioBruto, decimal inss, int dependentes)
    {
        decimal valorPorDependente = 189.59M;
        return salarioBruto - inss - (valorPorDependente * dependentes);
    }
    public static decimal ValorIRPF(decimal baseCalculo)
        {
            if (baseCalculo >= 2428.81M && baseCalculo <= 2826.65M)
                return (baseCalculo * 0.075M) - 182.16M;
            else if (baseCalculo >= 2826.66M && baseCalculo <= 3751.05M)
                return (baseCalculo * 0.15M) - 394.16M;
            else if (baseCalculo >= 3751.06M && baseCalculo <= 4664.68M)
                return (baseCalculo * 0.225M) - 675.49M;
            else if (baseCalculo > 4664.68M)
                return (baseCalculo * 0.275M) - 908.73M;

            return 0;
        }
    }

