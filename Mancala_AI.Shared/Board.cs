using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mancala_AI
{
    class Board
    {
        private bool hasWinner;
        private List<int> boxes;        //index is the box and value is the number of pebbles
        private int playerNum;
        private const int INITIAL_PEBBLE_COUNT = 5;

        public Board(int boxesIn)
        {
            boxes = new List<int>();
            playerNum = 2;
            boxes.Capacity = boxesIn + playerNum;       //account for the player's boxes

            bool skip = false;
            //populate boxes
            for (int i = 1; i <= boxes.Capacity; i++)
            {
                //do not put any into the player's boxes
                for (int j = 0; j < playerNum - 1; j++)
                {
                    if (i == (boxes.Capacity / playerNum) * j)
                    {
                        skip = true;
                    }
                }

                if (!skip)
                {
                    boxes[i] = INITIAL_PEBBLE_COUNT;
                }
            }
        }
        public void update(int action)
        {
            int pickedUp = boxes[action];
            boxes[action] = 0;

            //distribute pebbles
            for (int offset = 0; pickedUp > 0; pickedUp--, offset++)
            {
                boxes[action + offset] = boxes[action + offset] + 1;
            }
        }

        public bool getHasWinner()
        {
            return hasWinner;
        }

        public int getPebbles(int box)
        {
            if (box % (boxes.Count / playerNum) != 0 && box > 0 && box < boxes.Count)
            {
                return boxes[box];
            }
            else
            {
                return -1;
            }
        }

        public int getPlayerPebbles(int player)
        {
            int basePlayerBox = (boxes.Count / playerNum);   //the second player's box
            return boxes[basePlayerBox * player];
        }

        public int getOtherPlayerPebbles(int player)
        {
            int pebbles = 0;
            int basePlayerBox = (boxes.Count / playerNum);   //the second player's box
            for (int i = 0; i < playerNum; i++)
            {
                if (i != player)
                {
                    pebbles += boxes[basePlayerBox * player];
                }
            }
            return pebbles;
        }
    }
}
