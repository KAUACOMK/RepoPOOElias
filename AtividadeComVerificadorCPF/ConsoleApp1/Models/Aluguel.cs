public class Aluguel
{
    public int _totalDeHoras;
    public DateTime _data;
    public double _valorDahora;
    public string _nVaga;


    public Aluguel(double valorHora, string nVaga)
    {
        _data = DateTime.Now;
        _valorDahora = valorHora;
        _nVaga = nVaga;
    }



    public double calcularValor()
    {
        double valorTotal = _totalDeHoras * _valorDahora;
        return valorTotal;
    }

    public void Desconto(double valorTotal)
    {
        if (valorTotal > 100)
        {
            double valorDesconto = valorTotal * 0.05;
            valorTotal = valorTotal - (valorTotal * 0.05);
            Console.WriteLine($"Você recebeu um desconto de 5% = {valorDesconto:C2}");
        }
        
        Console.WriteLine($"Valor do aluguel: {valorTotal:C2}");
    }
}
