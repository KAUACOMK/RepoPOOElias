public class Gabarito
{
    private int _numeroGabarito;
    private List<string> _respostas;

    public Gabarito(int numeroGabarito, List<string> respostas)
    {
        _numeroGabarito = numeroGabarito;
        _respostas = respostas;
    }

    public int GetNumeroGabarito()
    {
        return _numeroGabarito;
    }

    public List<string> GetRespostas()
    {
        return _respostas;
    }


    public string RespostaQuestao(int numeroQuestao)
    {
        return _respostas[numeroQuestao].ToString();
    }
}



