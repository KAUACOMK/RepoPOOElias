public class Consulta
{
    ModificadorDeVoo m = new ModificadorDeVoo();
    public void ConsultarVoo(int id)
    {
        var v1 = ContextDb.Voo.Where(v => v.GetVooId() == id).Select(v => v.GetVooId()).FirstOrDefault();
        var v2 = ContextDb.Voo.Where(v => v.GetVooId() == id).Select(v => v.GetDataHoraVoo()).FirstOrDefault();
        var v3 = m.VerificarQuantAssentosVagos(id);

        ContextDb.tupla.Add((v1, v2, v3));

    }
}
