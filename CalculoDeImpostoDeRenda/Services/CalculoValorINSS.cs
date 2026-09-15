public class CalculoValorINSS
{

    public static decimal ValorINSS(decimal salario)
    {
        decimal faixa1 = 1518.00M;
        decimal faixa2 = 2793.88M;
        decimal faixa3 = 4190.83M;
        decimal faixa4 = 8157.41M;
        
        if (salario <= faixa1)
            return Math.Round(salario * 0.075M,2);

        else if (salario <= faixa2)
            return Math.Round((faixa1 * 0.075M) + ((salario - faixa1) * 0.09M),2);
        
        else if (salario <= faixa3)
            return Math.Round((faixa1 * 0.075M) + ((faixa2 - faixa1) * 0.09M) + ((salario - faixa2) * 0.12M),2);

        else if (salario <= faixa4)
            return Math.Round((faixa1 * 0.075M) + ((faixa2 - faixa1) * 0.09M) + ((faixa3 - faixa2) * 0.12M) + ((salario - faixa3) * 0.14M),2);

        return Math.Round((faixa1 * 0.075M) + ((faixa2 - faixa1) * 0.09M) + ((faixa3 - faixa2) * 0.12M) + ((faixa4 - faixa3) * 0.14M),2);
        

    }
}
