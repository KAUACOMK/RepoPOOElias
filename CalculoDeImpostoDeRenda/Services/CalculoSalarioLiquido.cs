public class CalculoSalarioLiquido
{
    public static decimal SalarioLiquido(decimal salarioBruto, decimal inss, decimal irpf)
    {
        return salarioBruto - CalculoValorINSS.ValorINSS(salarioBruto) - CalculoValorIRPF.ValorIRPF(salarioBruto);
    }
}

