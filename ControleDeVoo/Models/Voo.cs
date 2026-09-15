using System.Security.Cryptography.X509Certificates;

public class Voo
{
    private int _VooID;
    private DateTime _dataHoraVoo;
    private int _numeroMaxPassageiros;
    private bool[] _assentos;


    public Voo(int VooId, DateTime dataHoraVoo, int numeroMaxPassageiros)
    {
        _VooID = VooId;
        _dataHoraVoo = dataHoraVoo;
        _numeroMaxPassageiros = numeroMaxPassageiros;
        SetAssentos(_numeroMaxPassageiros);
    }

    internal void SetAssentos(int numeroDePassageiros)
    {
        _assentos = new bool[numeroDePassageiros];
    }

    public int GetVooId()
    {
        return _VooID;
    }

    public DateTime GetDataHoraVoo()
    {
        return _dataHoraVoo;
    }

    public bool[] GetAssentos()
    {
        return _assentos;
    }
    public void SetEstadoAssentos(bool estado, int assento)
    {
        _assentos[assento] = estado;
    }
}


