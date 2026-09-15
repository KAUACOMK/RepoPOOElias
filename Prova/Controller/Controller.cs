public class Controller
{
    public void CadastrarGabarito()
    {
        Console.WriteLine("Nº GABARITO:");
        var nGabarito = Convert.ToInt32(Console.ReadLine());
        List<string> respostas = new List<string>();
        Console.WriteLine("QUANTAS QUESTOES GOSTARIA DE REGISTRAR:");
        var quantQuestoes = Convert.ToInt32(Console.ReadLine());

        for(int i = 0; i < quantQuestoes; i++)
        {
            Console.WriteLine($"Questao {i + 1}");
            respostas.Add(Console.ReadLine());
        }

        Gabarito gabarito = new Gabarito(nGabarito, respostas.ToList());
        ContextDb.Gabarito.Add(gabarito);

        respostas.Clear();
        Console.ReadKey();
        Console.Clear();
        Home();
    }

    public void CadastrarProva()
    {
        Console.WriteLine("Nome do aluno: ");
        var nomeAluno = Console.ReadLine();
        Console.WriteLine("N Gabarito: ");
        var nGabarito = Convert.ToInt32(Console.ReadLine());

        var gabarito = ContextDb.Gabarito.Find(g => g.GetNumeroGabarito() == nGabarito);

        Prova prova = new Prova(nomeAluno,gabarito);

        ContextDb.Prova.Add(prova);
        Console.ReadKey();
        Console.Clear();
        Home();
    }

    public void ResponderProva()
    {
        VerificadoresDaProva v = new VerificadoresDaProva();
        Console.WriteLine("Informe o nome do aluno para responder a prova: ");
        var nome = Console.ReadLine();
        var prova = ContextDb.Prova.Where(p => p.GetNomeAluno() == nome).First();

        var quantDeQuestoes = prova.GetProvaGabarito().GetRespostas().Count();
        List<string> resposta = new List<string>();
        Console.WriteLine("\nRESPONDA AS QUESTOES");
        for(int i = 0; i < quantDeQuestoes; i++)
        {
            Console.WriteLine($"Q{i+1} (A B C D E): ");
            var res = Console.ReadLine();
            resposta.Add(res);
            Console.WriteLine();
        }

        prova.SetRespostaAluno(resposta.ToList());
        resposta.Clear();
        Console.WriteLine("\n##### RESULTADO #####");
        ResultadoProva(prova);
        Console.WriteLine($"Acertos: {prova.GetQuantAcertos()}");
        Console.WriteLine($"Nota: {prova.GetNotaProva():F2}");
        
        if(ContextDb.Prova.Count() > 1)
        {
            prova.SetProva(ContextDb.Prova.LastOrDefault());
            v.CompararProvas(prova, prova.GetProva());
        }
        Console.ReadKey();
        Console.Clear();
        Home();
    }

    public void ResultadoProva(Prova prova)
    {
        VerificadoresDaProva v = new VerificadoresDaProva();
        prova.SetAcertos(v.Acertos(prova.GetProvaGabarito().GetRespostas(), prova.GetRespostasAluno()));
        prova.SetNotaProva(v.Nota(prova.GetProvaGabarito().GetRespostas().Count(),prova.GetQuantAcertos()));
    }

    public void Home()
    {
        do
        {
            Console.WriteLine("REGISTRO DE PROVA E GABARITOS");
            Console.WriteLine(
                "1 - CADASTRAR GABARITO\n" +
                "2 - CADASTRAR PROVA\n" +
                "3 - RESPONDER PROVA\n" +
                "0 - SAIR"
                );
            var rs = Convert.ToInt32(Console.ReadLine());
            switch (rs)
            {
                case 1:
                    CadastrarGabarito();
                    Console.Clear();
                    break;
                case 2:
                    CadastrarProva();
                    Console.Clear();
                    break;
                case 3:
                    ResponderProva();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Tente novamente!");
                    break;
            }
        } while (true);
    }
}

