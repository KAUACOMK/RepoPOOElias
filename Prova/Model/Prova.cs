public class Prova
{
    private string _nomeAluno;
    private Gabarito _ProvaGabarito;
    private List<string> _RespostasAluno;
    private Prova _prova;
    private int _quantAcertos;
    private double _notaProva;


    public Prova(string nomeAluno, Gabarito provaGabarito)
    {
        _nomeAluno = nomeAluno;
        _ProvaGabarito = provaGabarito;
    }

    //GET
    public string GetNomeAluno()
    {
        return _nomeAluno;
    }

    public List<string> GetRespostasAluno()
    {
        return _RespostasAluno.ToList();
    }

    public Gabarito GetProvaGabarito()
    {
        return _ProvaGabarito;
    }

    public int GetQuantAcertos()
    {
        return _quantAcertos;
    }
    public double GetNotaProva()
    {
        return _notaProva;
    }
    public Prova GetProva() 
    {
        return _prova;
    }

    //SET
    public void SetAcertos(int acertos) 
    {
        _quantAcertos = acertos;
    }
    public void SetNotaProva(double nota)
    {
        _notaProva = nota;
    }
    public void SetRespostaAluno(List<string> resposta)
    {
        _RespostasAluno = resposta;
    }
    public void SetProva(Prova prova)
    {
        _prova = prova;
    }
}

