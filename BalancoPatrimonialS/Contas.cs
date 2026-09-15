using System.Dynamic;
using System.Threading.Channels;

public class Contas
{
    private string _codigo;
    private string _nome;
    //Ativo,Passivo ou Patrimônio Líquido
    private string _tipo;
    private double _saldo;
    private bool _contaRetificadora;

    public Contas (string codigo, string nome, string tipo, double saldo, bool contaRetificadora)
    {
        try
        {
        SetCodigo(codigo);
        SetNome(nome);
        SetTipo(tipo);
        SetSaldo(saldo);
        SetContaRetificadore(contaRetificadora);
        }
        catch (Exception)
        {
            Console.WriteLine("Verifique os dados inseridos");
        }
    }

    public void SetCodigo(string codigo)
    {
            _codigo = codigo;
    }

    public void SetNome(string nome)
    {
        if (nome != "" || nome != null)
            _nome = nome;
    }

    public void SetTipo(string tipo)
    {
        if (tipo != "" || tipo != null)
            _tipo = tipo;
    }

    public void SetSaldo(double saldo)
    {
            _saldo = saldo;
    }

    public void SetContaRetificadore(bool cRet)
    {
        _contaRetificadora = cRet;
    }

    public string GetNome()
    {
        return _nome;
    }
    public double GetSaldo()
    {
        return _saldo;
    }
    public string GetTipo()
    {
        return _tipo; 
    }
    public bool GetContaRetificadora()
    {
        return _contaRetificadora;
    }
    public string GetCodigo()
    {
        return _codigo;
    }
    public void Debitar(double valor)
    {
        if(valor <= 0) throw new Exception("Valor da Operação é invalido");
                
        if (_contaRetificadora == false)
        {
            if (_tipo == "Ativo")
            {
                _saldo += valor;
            }
            else if (_tipo == "Passivo")
            {
                if (_saldo >= valor)
                    _saldo -= valor;
                else
                    throw new Exception("Operação não pode ser Realizada");
            }
        }
        else
        {
            if (_tipo == "Ativo")
            {
                if (_saldo >= valor)
                    _saldo -= valor;
                else
                    throw new Exception("Operação não pode ser Realizada");
            }
            else if (_tipo == "Passivo" || _tipo == "Patrimonio Liquido")
            {
                _saldo += valor;
            }
        }

    }
    public void Creditar(double valor)
    {
        if (valor < 0) throw new Exception("Valor da Operação é invalido");
        if (_contaRetificadora == false)
        {
            if (_tipo == "Ativo")
            {
                if (_saldo >= valor)
                    _saldo -= valor;
                else
                    throw new Exception("Operação não pode ser Realizada");
            }
            else if (_tipo == "Passivo" || _tipo == "Patrimonio Liquido")
            {
                _saldo += valor;
            }
        }
        else
        {
            if (_tipo == "Ativo")
            {
                _saldo += valor;
            }
            else if (_tipo == "Passivo")
            {
                if (_saldo >= valor)
                    _saldo -= valor;
                else
                    throw new Exception("Operação não pode ser Realizada");
            }
        }
    }

}