public class Controller
{
    public void ControllerContribuinte(Contribuinte c1, Holerite h1)
    {

        try
        {
            h1.SetInss(CalculoDeHolerite.ValorINSS(c1.GetSalarioBruto()));
            h1.SetBaseDeCalculo(CalculoDeHolerite.BaseDeCalculo(c1.GetSalarioBruto(), h1.GetInss(), c1.GetQuantDependetes()));
            h1.SetIrpf(CalculoDeHolerite.ValorIRPF(h1.GetBaseDeCalculo()));
            h1.SetSalarioLiquido(CalculoDeHolerite.SalarioLiquido(c1.GetSalarioBruto(), h1.GetInss(), h1.GetIrpf()));
        }
        catch (Exception)
        {
            Console.WriteLine("Ops... Algo de errado nao esta certo!");
        }
    }
}

