using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal class Program
    {
        const int size = 25;


        private static void Main(string[] args)
        {
            bool[,] cells = new bool[size, size];            

            cells[3, 3] = true;
            cells[4, 4] = true;
            cells[5, 5] = true;
            cells[4, 5] = true;
            cells[6, 5] = true;
            cells[6, 5] = true;
            cells[7, 5] = true;
            cells[8, 5] = true;

            Game game = new Game(new GameUI(), size,cells, 200);

            game.Start();
            Console.ReadLine();
        }
        public class GameUI : INewGenerationListener
        {
            public void Notify(bool[,] cells)
            {

                for (int i = 0; i < size; i++)
                {

                    for (int j = 0; j < size; j++)
                    {
                        Console.Write(cells[i, j] ? "*" : " ");
                        if (j == size - 1) Console.WriteLine("\r");
                    }
                }
                Console.SetCursorPosition(0, Console.WindowTop);
            }
        }
    }
}
