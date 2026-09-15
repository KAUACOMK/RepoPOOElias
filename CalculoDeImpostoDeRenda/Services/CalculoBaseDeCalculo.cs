
    public class CalculoBaseDeCalculo
    {
        public static decimal BaseDeCalculo(decimal salarioBruto, decimal inss, int dependentes)
        {
        decimal valorPorDependente = 189.59M;
            return salarioBruto - inss - (valorPorDependente * dependentes);
        }
       }
