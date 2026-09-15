public class Interface
{
    public void Input(Contribuinte c1)
    {
        Console.WriteLine("Informe o seu salario: ");
        c1.SetSalarioBruto(Convert.ToDecimal(Console.ReadLine()));
        Console.WriteLine("Informe a quantidade de dependentes: ");
        c1.SetQuantDependentes(Convert.ToInt32(Console.ReadLine()));
    }
}
