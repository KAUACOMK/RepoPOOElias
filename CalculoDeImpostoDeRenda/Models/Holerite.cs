public class Holerite
{
    private decimal _inss;
    private decimal _irpf;
    private decimal _baseDeCalculo;
    private decimal _salarioLiquido;

    //GET E SET INSS
    public void SetInss(decimal inss)
    {
        _inss = inss;
    }
    public decimal GetInss()
    {
        return _inss;
    }

    //GET E SET IRPF
    public void SetIrpf(decimal irpf)
    {
        _irpf = irpf;
    }
    public decimal GetIrpf()
    {
        return _irpf;
    }
    //GET E SET BASE DE CALCULO
    public void SetBaseDeCalculo(decimal baseDeCalculo)
    {
        _baseDeCalculo = baseDeCalculo;
    }
    public decimal GetBaseDeCalculo()
    {
        return _baseDeCalculo;
    }
    //GET E SET SALARIO LIQUIDO
    public void SetSalarioLiquido(decimal salarioLiquido)
    {
        _salarioLiquido = salarioLiquido;
    }
    public decimal GetSalarioLiquido()
    {
        return _salarioLiquido;
    }
}

