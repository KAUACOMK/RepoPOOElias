Carro c1 = new Carro();

Console.WriteLine("Informe a placa do carro: ");
c1.placa = Console.ReadLine();
Console.WriteLine("Infome o modelo do carro: ");
c1.modelo = Console.ReadLine();
Console.WriteLine("Informe a marca do carro: ");
c1.marca = Console.ReadLine();
Console.WriteLine("Informe a cor do carro: ");
c1.cor = Console.ReadLine();

Console.WriteLine(
    "\n---- // ---- // ----\n\n" +
    "  Placa: " + c1.placa +
    "\n\n  Modelo: " + c1.modelo +
    "\n\n  Marca: " + c1.marca +
    "\n\n  Cor: " + c1.cor +
    "\n\n---- // ---- // ----\n"
    );

Aluguel a1 = new Aluguel((16.75),"1");

Console.WriteLine("Informe o numero de horas: ");
a1._totalDeHoras = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Valor do Aluguel: ");
a1.Desconto(a1.calcularValor());


Proprietario p1 = new Proprietario();

Console.WriteLine("\n#### INFORME OS DADOS DO PROPRIETARIO ####");
Console.Write("Nome: ");
p1._nome = Console.ReadLine();

Console.Write("CPF: ");
p1._cpf = Console.ReadLine();

if (p1.ValidadorDeCPF(p1._cpf) == false)
{
    Console.WriteLine("CPF INVALIDO");
    Environment.Exit(0);
}
Console.Write("Data de nascimento:");
p1._datanasc = Convert.ToDateTime(Console.ReadLine());

Console.Write("Telefone:");
p1._telefone = Console.ReadLine();

Console.WriteLine(
    "\n#### DADOS PROPRIETARIOS ####" +
    "Nome :" + p1._nome +
    "\nCPF: " + p1._cpf +
    "\nData de Nascimento: " + p1._datanasc +
    "\nTelefone: " + p1._telefone  
    );