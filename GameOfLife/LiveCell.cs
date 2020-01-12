using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class LiveCell
    {
        public LiveCell(int index)
        {
            Index = index;
        }

        public int Index { get; set; }
        public int Row { get; set; }
        public int column { get; set; }
        public LiveCell[] Neighbours ()
        {
            return null;
        }
    }
}
