using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mancala_AI
{
    class Player
    {
        private bool isHuman;

        public Player(bool human)
        {
            isHuman = human;
        }

        public int doTurn(Board state)
        {
            if (isHuman)
            {
                //get input as action
                return 0;
            }
            else
            {
                return abSearch(state);
            }
        }

        private int abSearch(Board state)
        {
            List<int> moves = orderedMoves(state);
            return 0;
        }

        public bool getIsHuman()
        {
            return isHuman;
        }

        private List<int> orderedMoves(Board state)   //it is in the Player class, therefore does not need the player passed to it
        {
            List<int> moves = new List<int>();
            return moves;
        }
    }
}
