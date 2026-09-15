public class ModificadorDeVoo
{
    public void RegistrarNovoPlanoVoo(int vooID, DateTime dataVoo, int maxPassageiros)
    {
        Controllers c = new Controllers();
        if(ContextDb.Voo.Count > 0)
        {
        if (ContextDb.Voo.Any(v => v.GetVooId() == vooID)
        )
        {
            Console.WriteLine("Já existe um voo de mesmo Nº");
            Console.ReadKey();
            Console.Clear();
            c.RegistrarPlanoDeVoo();
        }       
        }

        Voo v = new Voo(vooID,dataVoo,maxPassageiros);
        ContextDb.Voo.Add(v);

        Console.WriteLine("Voo registrado com sucesso!");
        Console.ReadKey();
        Console.Clear();
    }
    public string ProximoLivre(int vooID)
    { 
        var voo = ContextDb.Voo.Where(v => v.GetVooId() == vooID).First();
        var assentos = voo.GetAssentos();

        for (int i = 0; i < assentos.Length; i++)
        {
            if (assentos[i] == false)
                return Convert.ToString(i + 1);
        }

        return "Sem Assentos livres";
    }

    public bool VerificarAssento(int numeroAssento, int vooID)
    {
        var voo = ContextDb.Voo.Where(v => v.GetVooId() == vooID).FirstOrDefault();
        var assentos = voo.GetAssentos();

        if (assentos[numeroAssento] == false)
            return true;

        return false;
    }

    public int VerificarQuantAssentosVagos (int vooID)
    {

        var voo = ContextDb.Voo.Where(v => v.GetVooId() == vooID).FirstOrDefault();
        var assentos = voo.GetAssentos();
        int contVagas = 0;
        foreach(var v in assentos)
        {
            if (v == false)
                contVagas++;
        }

        return contVagas;
    }

    public void ReservarAssento(int assento, int id)
    {
        var voo = ContextDb.Voo.Where(v => v.GetVooId() == id).FirstOrDefault();
        voo.SetEstadoAssentos(true, assento);
    }


}