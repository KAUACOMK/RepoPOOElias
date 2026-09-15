using System.Diagnostics;

public class Paineis
{

    ModificadorDeVoo m = new ModificadorDeVoo();
    Controllers c = new Controllers();
    
    public void Home()
    {
        var iniciador = -1;
        do
        {
            Console.WriteLine("CONTROLE DE VOO!");
            Console.WriteLine("1 - Criar novo plano de Voo!");
            Console.WriteLine("2 - Listar Voos!");
            Console.WriteLine("3 - Consultar Voo por numero de voo!");
            Console.WriteLine("0 - Sair");
            var escolha = Convert.ToInt32(Console.ReadLine());
            
            switch(escolha)
            { 
                case 1:
                    Console.Clear();
                    c.RegistrarPlanoDeVoo();
                    break;
                case 2:
                    Console.Clear();
                    c.ListarVoos();
                    break;
                
                case 3:
                    Console.Clear();
                    c.ListarVoo();
                    break;

                case 0:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Escolha uma opção valida!");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }

        } while (iniciador != 0);
    }

    public void RegistrarPlanoDeVooInput()
    {
        Console.WriteLine("Informe o numero do Voo: ");
        var numeroVoo = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Informe a data do Voo: ");
        var dataVoo = Convert.ToDateTime(Console.ReadLine());
        Console.WriteLine("Informe a quatidade de poltronas: ");
        var quantPoltronas = Convert.ToInt32(Console.ReadLine());

        ContextDb.tupla.Add((numeroVoo,dataVoo,quantPoltronas));
    }

    public void ListarVoosOutput(Voo v)
    {
        Console.WriteLine("######################");
        Console.WriteLine($"Nº VOO: {v.GetVooId().ToString()}");
        Console.WriteLine($"Data e Hora Voo: {v.GetDataHoraVoo().ToString()}");
        Console.WriteLine("######################\n");
    }

    public int ConsultarVooPorIdInput()
    {
        Console.WriteLine("Informe o Nº do VOO: ");
        var nVoo = Convert.ToInt32(Console.ReadLine());

        return nVoo;
    }
    public void ConsultarVooPorIdOutput(int id)
    { 
        Console.WriteLine($"Nº de Voo: {ContextDb.tupla.Where(p => p.vooID == id).Select(p => p.vooID).FirstOrDefault()}");
        Console.WriteLine($"Data de Voo: {ContextDb.tupla.Where(p => p.vooID == id).Select(p => p.dataVoo).FirstOrDefault()}");
        Console.WriteLine($"Nº de assentos vagos {ContextDb.tupla.Where(p => p.vooID == id).Select(p => p.maxPoltronas).FirstOrDefault()}");
        Console.WriteLine();
        ContextDb.tupla.Clear();
        OptionsDeVoo(id);
        Console.ReadKey();
        Console.Clear();

    }

    public void OptionsDeVoo(int id)
    {
        do
        {
            Console.WriteLine("Opções: ");
            Console.WriteLine("1 - Verificar Proximo Assento Livre");
            Console.WriteLine("2 - Reservar Assento");
            Console.WriteLine("0 - Voltar ao Menu");
            var rs = Convert.ToInt32(Console.ReadLine());
            switch (rs)
            {
                case 1:
                    Console.WriteLine($"Proximo Assento vago é {m.ProximoLivre(id)}");
                    Console.ReadKey();
                    Console.WriteLine("Qualquer tecla para voltar");
                    break;
                case 2:
                    Console.WriteLine("Qual assento gostaria de reservar: ");
                    var assento = Convert.ToInt32(Console.ReadLine()) -1;
                    if(m.VerificarAssento(assento,id) == false)
                    {
                        Console.WriteLine("Assento ocupado tente novemente com outro assento!");
                        Console.ReadKey();
                        Console.Clear();
                        OptionsDeVoo(id);
                    }
                    m.ReservarAssento(assento,id);
                    Console.WriteLine("Assento Reservado!");
                    Console.ReadKey();
                    OptionsDeVoo(id);
                    break;
                case 0:
                    Home();
                    break;

                default:
                    Console.WriteLine("Ops!!!!");
                    break;
            }
        }
        while (true);
    }

}