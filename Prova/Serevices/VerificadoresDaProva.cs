internal class VerificadoresDaProva
{
    public int Acertos(List<string> respostasGabarito, List<string> respostasAluno)
    {
        var acertos = 0;
        for(int i = 0; i < respostasAluno.Count();i++)
        {
            if (respostasAluno[i] == respostasGabarito[i])
                acertos++;
        }
        return acertos;
    }

    public double Nota(int quantQuestions, int acertos)
    {
        const double notaMaxima = 10;
        var notaPorQuestao = notaMaxima / quantQuestions;
        return notaPorQuestao * acertos;
    }

    public void CompararProvas(Prova provaAluno, Prova provaAluno2)
    {
        var acertosAluno1 = provaAluno.GetQuantAcertos();
        var acertosAluno2 = provaAluno2.GetQuantAcertos();
        var notaAluno1 = provaAluno.GetNotaProva();
        var notaAluno2 = provaAluno2.GetNotaProva();
        if(acertosAluno1 > acertosAluno2)
        {
            Console.WriteLine($"Maior nota Aluno: {provaAluno.GetNomeAluno()} Nota:{provaAluno.GetNotaProva()}");
        }
        else if(acertosAluno1 < acertosAluno2)
        {
            Console.WriteLine($"Maior nota Aluno: {provaAluno2.GetNomeAluno()} Nota:{provaAluno2.GetNotaProva()}");
        }

        if (notaAluno1 > notaAluno2)
        {
            Console.WriteLine($"Maior nota Aluno: {provaAluno.GetNomeAluno()} Nota:{provaAluno.GetNotaProva()}");
        }
        else if (notaAluno1 < notaAluno2)
        {
            Console.WriteLine($"Maior nota Aluno: {provaAluno2.GetNomeAluno()} Nota:{provaAluno2.GetNotaProva()}");
        }
    }
    
}

