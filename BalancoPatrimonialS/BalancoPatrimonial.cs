using System.ComponentModel.Design;
using System.Dynamic;
using System.Linq.Expressions;

public class BalancoPatrimonial
{
    private Guid _id;
    private DateTime _data;
    private List<Contas> _contas;

    public BalancoPatrimonial()
    {
        _contas = new List<Contas>();
    }

    public void SetData(DateTime data)
    {
        _data = data;
    }
    public void AdicionarConta(Contas c)
    { 
        _contas.Add(c);
    }

    public void RemoverConta()
    {
        Console.WriteLine("Informe o Codigo da Conta: ");
        var codigo = Console.ReadLine();

        int conta = _contas.IndexOf(_contas.FirstOrDefault(c => c.GetCodigo() == codigo));

        _contas.RemoveAt(conta);
    }

    public void ExibirConta()
    {
        Console.WriteLine("Informe o codigo da conta: ");
        var codigo = Console.ReadLine();

        var conta = _contas.FirstOrDefault(c => c.GetCodigo() == codigo);

        Console.WriteLine(
            $"Codigo: {conta.GetCodigo()}" +
            $"Nome: {conta.GetNome()}" +
            $"Tipo: {conta.GetTipo()}" +
            $"Saldo: {conta.GetSaldo()}" +
            $"Conta Retificadora: {conta.GetContaRetificadora()}");
    }

    public void ListarContas()
    { 
        foreach ( var conta in _contas )
        {
            Console.WriteLine(
                $"\nCodigo: {conta.GetCodigo()}" +
                $"\nNome: {conta.GetNome()}" +
                $"\nTipo: {conta.GetTipo()}" +
                $"\nSaldo: {conta.GetSaldo()}" +
                $"\nConta Retificadora: {conta.GetContaRetificadora()}");
        }
    }

    public double SomatoriaDosSaldosAtivos()
    {
        var soma1 = _contas.Where(c => c.GetTipo() == "Ativo" && c.GetContaRetificadora() != true).ToList().Sum(x => x.GetSaldo());
        var soma2 = _contas.Where(c => c.GetTipo() == "Ativo" && c.GetContaRetificadora() == true).ToList().Sum(x => x.GetSaldo());
        var resultado = soma1 - soma2;

        Console.WriteLine($"Soma dos saldo das contas ativo: {resultado:C2}");
        return resultado;
    }

    public double SomatoriaDosSaldosPassivos()
    {
        var contador = _contas.Count();
        var soma1 = _contas.Where(c => c.GetTipo() == "Passivo" && c.GetContaRetificadora() != true).ToList().Sum(x => x.GetSaldo());
        var soma2 = _contas.Where(c => c.GetTipo() == "Passivo" && c.GetContaRetificadora() == true).ToList().Sum(x => x.GetSaldo());
        var resultado = soma1 - soma2;

        Console.WriteLine($"Soma dos saldo das contas passivas: {resultado:C2}");
        return resultado;
    }
    public double SomatoriaDosSaldosPatrimonioLiquido()
    {
        var soma1 = _contas.Where(c => c.GetTipo() == "Patrimonio Liquido" && c.GetContaRetificadora() != true).ToList().Sum(x => x.GetSaldo());
        var soma2 = _contas.Where(c => c.GetTipo() == "Patrimonio Liquido" && c.GetContaRetificadora() == true).ToList().Sum(x => x.GetSaldo());
        var resultado = soma1 - soma2;

        Console.WriteLine($"Soma dos saldo das contas Patrimonio Liquido: {resultado:C2}");
        return resultado;
    }
    public bool PartidasDobradas()
    {
        if (SomatoriaDosSaldosAtivos() == (SomatoriaDosSaldosPassivos() + SomatoriaDosSaldosPatrimonioLiquido()))
        {
            Console.WriteLine("True");
            return true;
        }
        else
        {
            Console.WriteLine("False");
            return false;
        }
    }

    public void LançamentoPatrimonial(Contas debitar, Contas creditar, double vDebitar, double vCreditar)
    {
        if (vDebitar != vCreditar)
        {
            throw new Exception("Valor Invalido!");
        }
        else 
        {
            debitar.Debitar(vDebitar);
            creditar.Creditar(vCreditar);
        }
}

