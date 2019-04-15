using System;

namespace Ex05.Logic
{
    public class AILogic
    {
        // This method checks if any column gives the win to the computer - and if so, return the col num.
        // Else, checks if any column gives the win for the player - and if so, return the col num.
        // Else, gives some random column number.

        // $G$ CSS-013 (-5) Bad input variable name (should be in the form of i_PascalCased)
        public int AIManager(GameManager io_Game)
        {
            const int falseResult = -1;
            int numOfCols = io_Game.GetNumOfCols();
            int colToBeInserted = -1;

            // get a winner computer col number.if exists.
            colToBeInserted = winnerColumn(io_Game, ePlayerNum.Computer);

            // If winner computer col number doesnt exists.
            if (colToBeInserted == falseResult)
            {
                // get a winner player col number.if exists.
                colToBeInserted = winnerColumn(io_Game, ePlayerNum.Player1);
            }

            // If winner player col number doesnt exists.
            if (colToBeInserted == falseResult)
            {
                Random rand = new Random();
                colToBeInserted = rand.Next(0, numOfCols);
            }

            return colToBeInserted;
        }

        // This function return a column number that wins the game for a player(player1 or computer - as given) - if exists.
        // Otherwise ,return (-1).
        private int winnerColumn(GameManager io_Game, ePlayerNum i_PlayerNum)
        {
            int colToBeInserted = -1;
            int numOfCols = io_Game.GetNumOfCols();

            for (int col = 0; io_Game.ValidateColumn(col); col++)
            {
                if (io_Game.InsertChip(new Chip(i_PlayerNum), col, false))
                {
                    if (io_Game.CheckForAWin(col, i_PlayerNum, false))
                    {
                        colToBeInserted = col;
                    }

                    io_Game.RemoveChip(col, false);
                }
            }

            return colToBeInserted;
        }
    }
}