public class Response
{
    public void Output(Contribuinte c1, Holerite h1)
    {
        //REPOSTA API
        Console.WriteLine("#### HOLERITE ####");
        Console.WriteLine($"Salario Bruto: {c1.GetSalarioBruto():C}");
        Console.WriteLine("\n!!!! DEDUÇÕES !!!!");
        Console.WriteLine($"INSS: {h1.GetInss():C}");
        Console.WriteLine($"IRPF: {h1.GetIrpf():C}");
        Console.WriteLine($"\nSalario Liquido: {h1.GetSalarioLiquido():C}");
    }
}
