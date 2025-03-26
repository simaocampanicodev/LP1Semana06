using System;

namespace MyGame
{
    public class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Uso: dotnet run --project MyGame -- <n>");
                Console.WriteLine("n: número de inimigos");
                return;
            }

            if (!int.TryParse(args[0], out int numInimigos) || numInimigos <= 0)
            {
                Console.WriteLine("Erro: O argumento deve ser um número inteiro positivo.");
                return;
            }

            Enemy[] inimigos = new Enemy[numInimigos];

            for (int i = 0; i < numInimigos; i++)
            {
                Console.Write($"Nome do inimigo {i + 1}: ");
                string nome = Console.ReadLine();
                inimigos[i] = new Enemy(nome);
            }

            Console.WriteLine("\nEstado inicial dos inimigos:");
            foreach (Enemy inimigo in inimigos)
            {
                Console.WriteLine($"{inimigo.GetName()} {inimigo.GetHealth()} {inimigo.GetShield()}");
            }

            Console.WriteLine("\nPowerUp e TakeDamage:");
            foreach (Enemy inimigo in inimigos)
            {
                inimigo.PickupPowerUp(PowerUp.Shield, Random.Shared.Next(10, 50));
                Console.WriteLine($"PowerUp Shield: {inimigo.GetName()} {inimigo.GetHealth()} {inimigo.GetShield()}");

                inimigo.TakeDamage(Random.Shared.Next(10, 100));
                Console.WriteLine($"TakeDamage: {inimigo.GetName()} {inimigo.GetHealth()} {inimigo.GetShield()}");

                inimigo.PickupPowerUp(PowerUp.Health, Random.Shared.Next(10, 50));
                Console.WriteLine($"PowerUp Health: {inimigo.GetName()} {inimigo.GetHealth()} {inimigo.GetShield()}\n");
            }

            Console.WriteLine($"\nTotal de PowerUps: {Enemy.GetTotalPowerUpsCollected()}");
        }
    }
}
