using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLife
{
    public interface INewGenerationListener
    {
        void Notify(bool[,] cells);
    }
    public class Game
    {
        
        int delay;
        private int boardSize;
        private bool[,] cells;
        INewGenerationListener listener;
        public Game(INewGenerationListener listener,int boardSize, int delayInMiliSecond) : this( listener, boardSize,new bool[boardSize, boardSize], delayInMiliSecond)
        {
            this.InitializeRandom();
        }
        public Game(INewGenerationListener listener, int boardSize, bool[,] initilizationPattern, int delayInMiliSecond)
        {
            this.delay = delayInMiliSecond;
            this.boardSize = boardSize;
            this.cells = initilizationPattern;
            this.listener = listener;
        }
        private void InitializeRandom()
        {
            Random random = new Random();
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    cells[i, j] = random.Next(2) == 1;
                }
            }
        }
        bool stoped = false;
        public void Start()
        {
            stoped = false;
            while (!stoped)
            {
                listener.Notify(this.cells);
                Thread.Sleep(delay);
                Run();

            }
        }
        private int GetNumberOfLiveNeighbors(int x, int y)
        {
            int result = 0;

            for (int i = x - 1; i < x + 2; i++)
            {
                for (int j = y - 1; j < y + 2; j++)
                {
                    if (!((i < 0 || j < 0) || (i >= boardSize || j >= boardSize)))
                    {
                        if (cells[i, j]) result++;
                    }
                }
            }
            return result;
        }

        private void Run()
        {
            int numOfAliveNeighbors = 0;
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                     numOfAliveNeighbors = GetNumberOfLiveNeighbors(i, j);

                    if (cells[i, j] && (numOfAliveNeighbors < 2 || numOfAliveNeighbors > 3))
                    {
                        cells[i, j] = false;
                    }
                    else if (!cells[i, j] && numOfAliveNeighbors == 3)
                    {
                        cells[i, j] = true;
                    }
                }
            }

        }
        public void Stop()
        {
            stoped = true;
        }
    }
}
