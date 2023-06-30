using Minesweeper_2;
using System;

namespace CampoMinado
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Bem-vindo ao Campo Minado!");
            Console.WriteLine();

            int tamanho = 10; // Tamanho do campo minado (10x10)
            int numeroMinas = 10; // Número de minas no campo minado

            Gamelogic game = new Gamelogic(tamanho, numeroMinas);
            game.IniciarJogo();

            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
