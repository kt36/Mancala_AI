using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mancala_AI
{
    class Game
    {
        public enum Mode { aiVAiSlow, aiVAiFast, aiVHuman };   //mainly for readability

        public void mainLoop(int boxes, Mode mode)
        {
            //setup
            Board board = new Board(boxes);
            bool gameOver = false;
            Player player1 = new Player(false);
            Player player2;
            if (mode == Mode.aiVHuman)
            {
                player2 = new Player(true);
            }
            else        //no human players
            {
                player2 = new Player(false);
            }
            player1.setOrder(0);
            player2.setOrder(1);
            Player[] players = { player1, player2 };
            int action;     //references the box to redistribute
            int turn = 1;

            //game loop
            while (!gameOver)
            {
                action = players[turn].doTurn(board);
                board.update(action);
                if (board.getHasWinner())
                {
                    //do coolio winner stuff
                    gameOver = true;
                }

                turn = turn % 2;        //do not let turn go past 2
                turn++;
            }
        }
    }
}
