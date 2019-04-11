using System;
using System.Collections.Generic;
using System.Text;
using Ex02.Logic;
using Ex02.ConsoleUtils;

namespace Ex02.ConsoleUI
{
    public class UserInterface
    {
        // $G$ CSS-999 (-3) Const fields should start with k_.
        private const int k_minRows = 4, k_maxRows = 8;
        private const int k_minCols = 4, k_maxCols = 8;
        private const int k_cellNumOfRowsNeeded = 3; // floor,var,ceiling.
        private const string k_ExitKey = "Q";
        private const string k_ChooseColumn = " ,Please choose a colmun:";
        private const string k_IllegalValue = "Illegal value ";
        private const string k_UserDimensions = @"Please enter the dimensions(4*4 up to 8*8) of the board (row->enter->column): ";
        private const string k_UserGameOption = "Would you play with a friend ?(Yes/No)";
        private const string k_UserClearBoard = "Would you want to clear the board ? (Yes/No)";
        private const string k_UserExitProgram = "Would you want to exit the program ? (Yes/No)";
        // $G$ CSS-999 (-5) local members should start with m_PascaleCased
        private int m_cursorColumnPos = 0, m_cursorRowPos;
        private bool m_ExitProgram = false;
        private bool m_Retire = false;
        private GameManager m_Game;

        public void Run()
        {
            int rows = 0, cols = 0;

            Console.WriteLine(k_UserDimensions);
            getDimensions(ref rows, ref cols);
            m_cursorRowPos = rows * k_cellNumOfRowsNeeded;

            m_Game = new GameManager(rows, cols);

            Console.WriteLine(k_UserGameOption);
            if (getAnswerYesOrNot(k_UserGameOption))
            {
                //// Yes - with a friend.
                RunTwoPlayers();
            }
            else
            {
                RunOnePlayer();
            }
        }

        private bool RunOnePlayerAux()
        {
            bool exitGame = false;

            if (IsBoardFull())
            {
                this.PrintGameStatus();
                exitMenu(ePlayerNum.Player1);
                this.clearBoard();
            }

            if (m_ExitProgram)
            {
                this.PrintGameStatus();
                exitGame = true;
            }

            return exitGame;
        }

        //// one player against computer.
        public void RunOnePlayer()
        {
            Screen.Clear();
            
            //// ExitProgram - if the user will press 'Q'
            while (!m_ExitProgram)
            {
                getNextTurn(ePlayerNum.Player1);

                if(RunOnePlayerAux())
                {
                    break;
                }

                computerTurn();

                if (RunOnePlayerAux())
                {
                    break;
                }
            }
        }
        
        private void runTwoPlayersAux(ePlayerNum i_PlayerNum)
        {
            getNextTurn(i_PlayerNum);

            if (this.IsBoardFull())
            {
                this.PrintGameStatus();
                exitMenu(i_PlayerNum);
                this.clearBoard();
            }
        }

        //// Two players
        public void RunTwoPlayers()
        {
            Screen.Clear();

            //// m_exitProgram - if one of the players will press 'Q'
            while (!m_ExitProgram)
            {
                runTwoPlayersAux(ePlayerNum.Player1);

                if(m_ExitProgram)
                {
                    break;
                }

                runTwoPlayersAux(ePlayerNum.Player2);

                if (m_ExitProgram)
                {
                    break;
                }
            }
        }

        //// Checks if the board is full.
        //// If so - true. else - false.
        public bool IsBoardFull()
        {
            return m_Game.IsBoardFull();
        }

        private void computerTurn()
        {
            AILogic ai = new AILogic();
            Random rand = new Random();
            int colToBeInserted = 0;
            int numOfCols = m_Game.GetNumOfCols();

            //// Column choosed.
            colToBeInserted = ai.AIManager(this.m_Game);

            while (!ValidateColumn(colToBeInserted))
            {
                /// Column choosed.
                /// We left the rand here, as a "Fail-Safe" procedure . please pay attion for this point.
                
                colToBeInserted = rand.Next(0, numOfCols);
            }

            //// only if a legal column....(have to a legal one at this point..^^^^)
            InsertChip(new Chip(ePlayerNum.Computer), colToBeInserted);
            Screen.Clear();
            PrintBoard();
            
            if (CheckForAWin(colToBeInserted, ePlayerNum.Computer, true))
            {
                this.m_Game.IncreasePointsByOne(ePlayerNum.Computer);
                this.m_Game.LastRoundWinner = ePlayerNum.Computer;

                this.PrintGameStatus();

                exitMenu(ePlayerNum.Player1);

                this.clearBoard();
            }
            else
            {
                ////Tie - because if the other player has won - it should dealt in his turn.
            }
        }

        private void getNextTurn(ePlayerNum i_PlayerNum)
        {
            int colToBeInserted = 0;
            int numOfCols = m_Game.GetNumOfCols();
            string tempLine = string.Empty;

            Screen.Clear();
            PrintBoard();

            Console.WriteLine(i_PlayerNum + k_ChooseColumn);

            //// A loop that keeps running until valid column number or 'Q' - k_ExitKey.
            for (tempLine = Console.ReadLine();
                   (!int.TryParse(tempLine, out colToBeInserted) && tempLine.CompareTo(k_ExitKey) != 0)
                   || (int.TryParse(tempLine, out colToBeInserted) && !ValidateColumn(--colToBeInserted));
                    tempLine = Console.ReadLine())
            {
                //// supposed to run until a valid num or 'Q' will be entered. (k_ExitKey).
                Console.WriteLine(k_IllegalValue + k_ChooseColumn);
            }
            
            if (tempLine.CompareTo(k_ExitKey) == 0)
            {
                m_Retire = true;
                this.PrintGameStatus();
                exitMenu(i_PlayerNum);
                m_Retire = false;
            }
            else
            {
                //// only if a legal column....(have to a legal one at this point..^^^^)
                InsertChip(new Chip(i_PlayerNum), colToBeInserted);
                Screen.Clear();
                PrintBoard();

                if (CheckForAWin(colToBeInserted, i_PlayerNum, true))
                {
                    //// The last move was a winner !
                    /// Add updates points to game manager & remove it from the exit menu method. 

                    this.m_Game.IncreasePointsByOne(i_PlayerNum);
                    this.m_Game.LastRoundWinner = i_PlayerNum;

                    this.PrintGameStatus();
                    exitMenu(i_PlayerNum);
                    this.clearBoard();
                }
                else
                {
                    ////Tie - because if the other player has won - it should dealt in his turn.
                }
            }
        }

        public bool CheckForAWin(int i_ColumnNum, ePlayerNum i_PlayerNum, bool i_Update)
        {
            bool res = false;
            res = m_Game.CheckForAWin(i_ColumnNum, i_PlayerNum, i_Update);
            return res;
        }

        public bool InsertChip(Chip i_Chip, int i_ColumNum)
        {
            return m_Game.InsertChip(i_Chip, i_ColumNum);
        }

        //// Check if can be inserted to column i_Column.
        //// return true - if chip can be inserted to column number i_Column . false - otherwise.
        public bool ValidateColumn(int i_Column)
        {
            return m_Game.ValidateColumn(i_Column);
        }

        private void getDimensions(ref int io_NumOfRows, ref int io_NumOfCols)
        {
            string rows = string.Empty, cols = string.Empty;
            int numOfRows = 0, numOfCols = 0;

            rows = Console.ReadLine();
            cols = Console.ReadLine();

            while ((!int.TryParse(rows, out numOfRows) || !int.TryParse(cols, out numOfCols) )
                || ((k_minRows > numOfRows || numOfRows > k_maxRows )
                || (k_minCols > numOfCols || numOfCols > k_maxCols)))
            {
                Console.WriteLine("What is the required dimensions? (row->enter->column)");
                rows = Console.ReadLine();
                cols = Console.ReadLine();
            }

            io_NumOfRows = numOfRows;
            io_NumOfCols = numOfCols;
        }

        /*true - Yes
        /*false - No
         * */
        private bool getAnswerYesOrNot(string ques)
        {
            bool res = false;
            bool validateAnswer = false;
            string answer = Console.ReadLine();

            while(!validateAnswer)
            {
                // $G$ CSS-999 (-3) You should have used constants here.
                if (answer.CompareTo("No") == 0)
                {
                    res = false;
                    validateAnswer = true;
                }
                else if (answer.CompareTo("Yes") == 0)
                {
                    res = true;
                    validateAnswer = true;
                }
                else
                {
                    System.Console.WriteLine(ques);
                    answer = Console.ReadLine();
                }
            }
            
            return res;
        }

        private void clearBoard()
        {
            this.m_Game.ClearBoard();
        }

        // This function prints the head of the board interface Rep.
        private string PrintHeadLine(int i_CellLength)
        {
            int cellNum = 1;
            char headPaddingChar = ' ';
            string nextHeadItemSeparator = "|";
            StringBuilder res = new StringBuilder();
            string envSep = new string(Environment.NewLine.ToCharArray());
            string headFloor = new string('-', ((i_CellLength + 1) * this.m_Game.GetNumOfCols()) + 1);
            string paddingStr = new string(headPaddingChar, i_CellLength / 2);

            while (cellNum <= this.m_Game.GetNumOfCols())
            {
                res.AppendFormat(
                    "{0}{1}{2}{1}",
                    nextHeadItemSeparator,
                    paddingStr,
                    cellNum.ToString());

                cellNum++;
            }

            res.AppendFormat("{0}{1}", nextHeadItemSeparator, envSep);

            res.Append(headFloor);
            res.AppendFormat("{0}", envSep);

            return res.ToString();
        }

        // This method prints only the board.
        public void PrintBoard()
        {
            char paddingChar = ' ';
            int cellLength = 5; // must be an odd number.
            string envSep = new string(Environment.NewLine.ToCharArray());
            string nextItemSeparator = "|";
            string nextLineSeparator = new string('=', ((cellLength + 1) * this.m_Game.GetNumOfCols()) + 1);
            string paddingStr = new string(paddingChar, cellLength / 2);

            StringBuilder res = new StringBuilder();
            string temp = string.Empty;
            string[] stringSeparators = { envSep };

            res.Append(PrintHeadLine(cellLength));

            temp = this.m_Game.ToString();

            foreach (string line in temp.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries))
            {
                foreach (char c in line)
                {
                    res.AppendFormat(
                        "{0}{1}{2}{1}",
                        nextItemSeparator,
                        paddingStr,
                        c.ToString());
                }

                res.AppendFormat(
                    "{0}{2 }{1 }{2 }",
                    nextItemSeparator,
                    nextLineSeparator,
                    envSep);
            }

            System.Console.WriteLine(res);
        }

        // This function prints on screen the status of the game in a specific location
        // on the screen.
        public void PrintGameStatus()
        {
            System.Console.SetCursorPosition(m_cursorColumnPos, m_cursorRowPos);
            System.Console.WriteLine(this.ToString());
        }

        // This method, prints the status of the points , who won the last round .
        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            string envNewLine = Environment.NewLine;
            
            res.AppendFormat(
                "Winner: {0}{1}Points-{0}Player 1: {2}{0}Player2: {3}{0}",
                envNewLine,
                this.m_Game.RoundWinner(),
                this.m_Game.Player1Points,
                this.m_Game.Player2Points);

            return res.ToString();
        }

        private void clearBoardOption(ePlayerNum i_PlayerNum)
        {
            System.Console.WriteLine(k_UserClearBoard);
            if (getAnswerYesOrNot(k_UserClearBoard))
            {
                this.clearBoard();
            }
        }

        // This method will mange the control flow after one of the players entered 'Q'.
        private void exitMenu(ePlayerNum i_PlayerNum)
        {
            System.Console.WriteLine(k_UserExitProgram);
            this.m_ExitProgram = getAnswerYesOrNot(k_UserExitProgram);

            if (!m_ExitProgram)
            {
                if(m_Retire)
                {
                    clearBoardOption(i_PlayerNum);
                }
            }
            else
            {
                //// yes - 'i_PlayerNum' want to quit !!
                this.m_ExitProgram = true;
            }
        }
    }
}
