public class Proprietario
{
    public string _nome;
    private string _cpf;
    private DateTime _datanasc;
    public string _telefone;




    public void SetDataNascimento(DateTime datanasc)
    {
        if (datanasc < DateTime.Today )
            _datanasc = datanasc;
        else
            Console.WriteLine("Data de Nascimento Invalida!");   
    }
    public DateTime GetDataNascimento()
    {
        return _datanasc;
    }

    public void SetCPF(string cpf)
    {
        if (ValidadorDeCPF(cpf) == true)
            _cpf = cpf;
        else
            throw new Exception("CPF Invalido");
     }

    public string GetCPF()
    {
        return _cpf.ToString();
    }


    public bool ValidadorDeCPF(string cpf)
    {
        cpf = cpf.Replace(".", "").Replace("-","");

        if(cpf.Length != 11) return false; //teste paravalidar se o CPF esta no tamnho certo

        int[] cpfV = new int[11];

        for (int i = 0; i < 11; i++) //Laço para dividir o CPF em caracteres
        {
            cpfV[i] = Convert.ToInt32(cpf.Substring(i, 1));
        }

        int soma = 0;
        int multiplicador = 10; 
        for (int i = 0; i < cpf.Length - 2; i++) // Laço para multiplicar os 9 primeiros numeros
        {
            soma += cpfV[i] * multiplicador;
            multiplicador--;
        }

        int resto = soma % 11;

        if (resto < 2)
        {
            if (cpfV[9] != 0) // verificando se o 10 digito é 0
            {
                return false;
            }
        }
        else
        {
            int primeiroDigito = 11 - resto;
            if (primeiroDigito != cpfV[9]) // verificando se o digito é diferente do restante encontrado
                return false;
        }

        soma = 0;
        multiplicador = 11;
        for (int i = 0; i < cpf.Length - 1; i++)
        {
            soma += cpfV[i] * multiplicador;
            multiplicador--;
        }

        resto = soma % 11;

        if (resto < 2)
        {
            if (cpfV[10] != 0)
                return false;
        }
        else
        {
            int segundoDigito = 11 - resto;

            if (segundoDigito != cpfV[10])
                return false;
        }
        return true;
    }
}
