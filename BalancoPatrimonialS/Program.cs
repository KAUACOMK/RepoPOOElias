var c1 = new Contas("1.1.01", "Caixa", "Ativo", 20000, false);

var c2 = new Contas("1.2.01", "Imobilizado", "Ativo", 40000, false);

var c3 = new Contas("1.2.02", "Depreciação Acumulada", "Ativo", 10000, true);

var c4 = new Contas("2.1.01", "Fornecedores", "Passivo", 25000, false);

var c5 = new Contas("1.2.02", "Juros a Transcorrer", "Passivo", 5000, true);

var c6 = new Contas("3.1.01", "Capital Social", "Patrimonio Liquido", 30000, false);

var c7 = new Contas("1.1.02", "Estoque", "Ativo", 0, false);

var b = new BalancoPatrimonial();

Home();

void Home() { 
do
{
    Console.WriteLine("Opção:");
    Console.WriteLine("1 - Adicionar Conta" +
        "\n2 - Remover Conta" +
        "\n3 - Exibir Conta" +
        "\n4 - Listar Contas" +
        "\n5 - Soma Ativos" +
        "\n6 - Soma Passivos" +
        "\n7 - Total PL" +
        "\n8 - Partidas Dobradas" +
        "\n0 - Sair");
    var opc = Convert.ToInt32(Console.ReadLine());

    switch(opc)
    {
        case 1:
                b.AdicionarConta(c1);
                b.AdicionarConta(c2);
                b.AdicionarConta(c3);
                b.AdicionarConta(c4);
                b.AdicionarConta(c5);
                b.AdicionarConta(c6);
                b.AdicionarConta(c7);
                Home();
                break;
        case 2:
                b.RemoverConta();
                Home();
            break; 
        case 3:
                b.ExibirConta();
                Home();
                break; 
        case 4:
                c2.Debitar(2000);
                c1.Creditar(2000);
                c4.Debitar(3000);
                c1.Creditar(3000);
                c7.Debitar(5000);
                c4.Creditar(5000);
                b.ListarContas();
                Home();
            break; 
        case 5:
                b.SomatoriaDosSaldosAtivos();
                Home();
            break; 
        case 6:
                b.SomatoriaDosSaldosPassivos();
                Home();
            break; 
        case 7:
                b.SomatoriaDosSaldosPatrimonioLiquido();
                Home();
            break;
            case 8:
                b.PartidasDobradas();
                Home();
                break;
        case 0:
                System.Environment.Exit(0);
            break;
        default:
            break;
    }
}while (true);
}