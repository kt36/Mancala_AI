using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mancala_AI
{
    class Player
    {
        private bool isHuman;
        private int order;

        public Player(bool human)
        {
            isHuman = human;
        }

        public void setOrder(int orderIn)
        {
            order = orderIn;
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
            int v = -999;
            int a = 0;
            int alpha = -999;
            int beta = 999;     //v, a, α & β are variables local to these functions
            for (int i = 0; i < moves.Count; i++) {
                Board newState = RESULT(state, moves[i]);
                int newV = MIN(newState, alpha, beta);
                if (newV > v) {
                    v = newV;
                    a = moves[i];
                }
                if (v >= beta) {
                    return a;     //prune based on beta
                }
                else if (v > alpha) {
                    alpha = v;    //update alpha
                }
            }
        return a;
        }

        int MAX(Board state, int alpha, int beta) {
            List<int> moves = orderedMoves(state);
            if (TERMINAL-TEST(state)) {
                return h1(state);
            }
            int v = -999;
            for (int i = 0; i < moves.Count; i++) {
                Board newState = RESULT(state, moves[i]);
                int newV = MIN(newState, alpha, beta);
                if (newV > v) {
                    v = newV;
                }
                if (v >= beta) {
                    return v;     //prune based on beta
                }
                else if (v > alpha) {
                    alpha = v;    //update alpha
                }
            }
            return v;
        }

        int MIN(Board state, int alpha, int beta) {
            List<int> moves = orderedMoves(state);
            if (h1(state) == state.PEBBLETOTAL || h1(state) == (state.PEBBLETOTAL * -1)) {
                return h1(state);
            }
            int v = 999;
            for (int i = 0; i < moves.Count; i++) {
                Board newState = RESULT(state, moves[i]);
                int newV = MAX(newState, alpha, beta);
                if (newV < v) {
                    v = newV;
                }
                if (v <= alpha) {
                    return v;     //prune based on alpha
                }
                else if (v < beta) {
                    beta = v;    //update beta
                }
            }
            return v;
        }

        private int h1(Board state)
        {
            return state.getPlayerPebbles(order) - state.getOtherPlayerPebbles(order);
        }

        private List<int> orderedMoves(Board state)   //it is in the Player class, therefore does not need the player passed to it
        {
            List<int> moves = new List<int>();
            bool finished = false;
            int previous = 0;
            int place = 0;
            int current = state.getPebbles(place);

            //get all possible moves
            while (!finished)
            {
                if (current > -1)
                {
                    // insertion sort by impact
                    for (int i = 0; i < moves.Count; i++)
                    {

                    }
                }
                

                place++;
                previous = current;
                current = state.getPebbles(place);
                if (previous == -1 && current == -1)
                {
                    finished = true;
                }
            }
            return moves;
        }
    }
}
