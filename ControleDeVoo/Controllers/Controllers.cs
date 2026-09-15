using System.Xml.Serialization;

public class Controllers
{
    ModificadorDeVoo modificador = new ModificadorDeVoo();
    Consulta v = new Consulta();
    
    public void RegistrarPlanoDeVoo()
    {
        Paineis p = new Paineis();
        p.RegistrarPlanoDeVooInput();
 
        modificador.RegistrarNovoPlanoVoo(
                                            Convert.ToInt32(ContextDb.tupla.Select(t => t.vooID).First()), 
                                            Convert.ToDateTime(ContextDb.tupla.Select(t => t.dataVoo).First()), 
                                            Convert.ToInt32(ContextDb.tupla.Select(t => t.maxPoltronas).First())
                                            );
        ContextDb.tupla.Clear();
    }

    public void ListarVoos()
    {
        Paineis p = new Paineis();
        foreach(var i in ContextDb.Voo)
        {
            p.ListarVoosOutput(i);        
        }
    }

    public void ListarVoo()
    {
        Paineis p = new Paineis();
        var id = p.ConsultarVooPorIdInput();
        v.ConsultarVoo(id);
        p.ConsultarVooPorIdOutput(id);


    }
}