public class Contribuinte
{
    public string nome;
    public string cpf;
    private decimal _salarioBruto;
    private int _quantDependentes;



    //GET E SET SALARIO
    public void SetSalarioBruto(decimal salarioBruto)
    {
        _salarioBruto = salarioBruto;
    }

    public decimal GetSalarioBruto()
    {
        return _salarioBruto;
    }

    //GET E SET DEPENDENTES
    public void SetQuantDependentes(int dependentes)
    {
        _quantDependentes = dependentes;
    }
    public int GetQuantDependetes()
    {
        return _quantDependentes;
    }

}
