using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mancala_AI
{
    class Board
    {
        private bool hasWinner;
        private List<int> boxes;

        public Board(int boxesIn)
        {
            boxes = new List<int>();
            boxes.Capacity = boxesIn;
        }
        public void update(int action)
        {
            
        }

        public bool getHasWinner()
        {
            return hasWinner;
        }
    }
}
