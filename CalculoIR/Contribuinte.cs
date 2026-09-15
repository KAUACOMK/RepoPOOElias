public class Contribuinte
{
    public string nome;
    public string cpf;
    public decimal salarioBruto;
    public int quantDependentes;
    public decimal _salarioLiquido;

    private decimal _inss;
    private decimal _irpf;
    private decimal baseCalculo;


    public decimal ValorINSS()
    {
        decimal faixa1 = 1518.00M;
        decimal faixa2 = 2793.88M;
        decimal faixa3 = 4190.83M;
        decimal faixa4 = 8157.41M;

        if (salarioBruto <= faixa1)
            return _inss = salarioBruto * 0.075M;

        else if (salarioBruto <= faixa2)
            return _inss = (faixa1 * 0.075M) + ((salarioBruto - faixa1) * 0.09M);

        else if (salarioBruto <= faixa3)
            return _inss = (faixa1 * 0.075M) + ((faixa2 - faixa1) * 0.09M) + ((salarioBruto - faixa2) * 0.12M);

        else if (salarioBruto <= faixa4)
            return _inss =(faixa1 * 0.075M) + ((faixa2 - faixa1) * 0.09M) + ((faixa3 - faixa2) * 0.12M) + ((salarioBruto - faixa3) * 0.14M);

        return _inss = (faixa1 * 0.075M) + ((faixa2 - faixa1) * 0.09M) + ((faixa3 - faixa2) * 0.12M) + ((faixa4 - faixa3) * 0.14M);


    }

    public decimal BaseDeCalculo()
    {
        decimal valorPorDependente = 189.59M;
        return baseCalculo = salarioBruto - _inss - (valorPorDependente * quantDependentes);
    }


    public decimal ValorIRPF()
    { 

        if (baseCalculo >= 2428.81M && baseCalculo <= 2826.65M)
            return _irpf = (baseCalculo * 0.075M) - 182.16M;
        
        else if (baseCalculo >= 2826.66M && baseCalculo <= 3751.05M)
            return _irpf = (baseCalculo * 0.15M) - 394.16M;
        
        else if (baseCalculo >= 3751.06M && baseCalculo <= 4664.68M)
            return _irpf = (baseCalculo * 0.225M) - 675.49M;
        
        else if (baseCalculo > 4664.68M)
            return _irpf = (baseCalculo * 0.275M) - 908.73M;

        return _irpf = 0;
    }

    public  decimal SalarioLiquido()
    {
        return _salarioLiquido = salarioBruto - _inss - _irpf;
    }
}
