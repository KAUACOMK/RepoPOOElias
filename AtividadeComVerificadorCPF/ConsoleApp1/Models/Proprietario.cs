public class Proprietario
{
    public string _nome;
    public string _cpf;
    public DateTime _datanasc;
    public string _telefone;

    public bool ValidadorDeCPF(string cpf)
    { 
        if(cpf.Length > 11 || cpf.Length < 11) return false; //teste paravalidar se o CPF esta no tamnho certo

        int[] cpfV = new int[11];
        int primeiroDigito = 0;

        for (int i = 0; i < 11; i++) //Laço para dividir o CPF em caracteres
        {
            cpfV[i] = Convert.ToInt32(cpf.Substring(i, 1));
        }

        int multiplicador = 10;

        int[] cpfMult = new int[11];

        for (int i = 0; i < 9; i++) // Laço para multiplicar os 9 primeiros numeros
        {
            cpfMult[i] = cpfV[i] * multiplicador;

            multiplicador--;
        }

        int soma = 0;

        for (int i = 0; i < 9; i++) // Laco para soma
        {
            soma = cpfMult[i] + soma;
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
            primeiroDigito = 11 - resto;
            if (primeiroDigito != cpfV[9]) // verificando se o digito é diferente do restante encontrado
                return false;
        }

        multiplicador = 11;
        for (int i = 0; i < 10; i++)
        {
            cpfMult[i] = cpfV[i] * multiplicador;
            multiplicador--;
        }
        soma = 0;
        for (int i = 0; i < 10; i++)
        {
            soma = cpfMult[i] + soma;
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
