using System.Text.RegularExpressions;

namespace ConsoleApp1.Services
{
    public class VerificadorCNPJ
    { 
        private static readonly int[] PesosDv1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        private static readonly int[] PesosDv2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        private static readonly Regex Formato = new("^[A-Z0-9]{12}[0-9]{2}$", RegexOptions.Compiled);

        public static string Normalizar(string entrada) =>
            entrada.Replace(".", "").Replace("/", "").Replace("-", "")
                   .Trim().ToUpperInvariant();

        public static bool Validar(string? entrada)
        {
            if (string.IsNullOrWhiteSpace(entrada)) return false;

            var cnpj = Normalizar(entrada);
            if (!Formato.IsMatch(cnpj)) return false;

            // Sequências repetidas (00000000000000, AAAAAAAAAAAA00...) fecham o
            // módulo 11. A lista fixa de sequências inválidas do CNPJ numérico
            // ficou incompleta com letras no domínio; rejeite por regra.
            if (cnpj[..12].All(c => c == cnpj[0])) return false;

            var dv1 = CalcularDv(cnpj[..12], PesosDv1);
            var dv2 = CalcularDv(cnpj[..12] + (char)('0' + dv1), PesosDv2);

            return cnpj[12] - '0' == dv1 && cnpj[13] - '0' == dv2;
        }

        private static int CalcularDv(string caracteres, int[] pesos)
        {
            var soma = 0;
            for (var i = 0; i < caracteres.Length; i++)
            {
                // ASCII - 48: para dígitos reproduz o valor numérico do algoritmo
                // antigo; para letras maiúsculas, 'A' vale 17 e 'Z' vale 42.
                soma += (caracteres[i] - 48) * pesos[i];
            }
            var resto = soma % 11;
            return resto < 2 ? 0 : 11 - resto;
        }
    }
}

