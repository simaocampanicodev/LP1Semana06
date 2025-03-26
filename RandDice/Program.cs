using System;

namespace RandDice
{
    public class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Uso: dotnet run --project RandDice -- <n> <s>");
                Console.WriteLine("n: número de dados");
                Console.WriteLine("s: seed para o gerador aleatório");
                return;
            }

            if (!int.TryParse(args[0], out int n) || !int.TryParse(args[1], out int s))
            {
                Console.WriteLine("Erro: Os argumentos devem ser números inteiros.");
                return;
            }

            Random random = new Random(s);
            int soma = 0;

            for (int i = 0; i < n; i++)
            {
                soma += random.Next(1, 7);
            }

            Console.WriteLine(soma);
        }
    }
}
