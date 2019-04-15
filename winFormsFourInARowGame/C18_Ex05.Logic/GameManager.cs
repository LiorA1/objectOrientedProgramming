using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05.Logic
{
    public delegate void InsertionOfChip(int i_Row, int i_Col, ePlayerNum i_PlayerNum);

    public delegate void DeletionOfChip(int i_Row, int i_Col);

    public enum ePlayerNum
    {
        Empty = 0,
        Player1 = 1,
        Player2 = 2,
        Computer = 3
    }
    // $G$ CSS-999 (-3) each non nested Class/Enum/Interface should be in a seperate file
    public enum eRepresentation
    {
        Empty = ' ',
        Player1 = 'X',
        Player2 = 'O',
        Computer = 'O'
    }

    public class GameManager
    {
        // $G$ DSN-999 (-3) This kind of field should be readonly.
        private Board m_GameBoard;
        private int m_Player1Points;
        private int m_Player2Points;
        private ePlayerNum m_LastRoundWinner;
        
        public GameManager(int i_NumOfRows, int i_NumOfCols)
        {
            m_GameBoard = new Board(i_NumOfRows, i_NumOfCols);
            m_Player1Points = 0;
            m_Player2Points = 0;
            m_LastRoundWinner = ePlayerNum.Empty;
        }

        public Board GameBoard
        {
            get { return this.m_GameBoard; }
        }

        public int Player1Points
        {
            get { return m_Player1Points; }
            set { m_Player1Points = value; }
        }

        public int Player2Points
        {
            get { return m_Player2Points; }
            set { m_Player2Points = value; }
        }

        public ePlayerNum LastRoundWinner
        {
            get { return m_LastRoundWinner; }
            set { m_LastRoundWinner = value; }
        }

        public int GetNumOfCols()
        {
            return m_GameBoard.GetNumOfCols();
        }

        public int GetNumOfRows()
        {
            return m_GameBoard.GetNumOfRows();
        }

        public int IncreasePointsByOne(ePlayerNum i_PlayerNum)
        {
            int updatedPoints = 0;
            if (i_PlayerNum == ePlayerNum.Player1)
            {
                m_Player1Points++;
                updatedPoints = this.m_Player1Points;
            }
            else
            {
                m_Player2Points++;
                updatedPoints = this.m_Player2Points;
            }

            return updatedPoints;
        }

        public void IncreaseOpponentPointsByOne(ePlayerNum i_PlayerNum)
        {
            if (i_PlayerNum == ePlayerNum.Player1)
            {
                m_Player2Points++;
            }
            else
            {
                m_Player1Points++;
            }
        }

        // This method check if the last move was a 4 chip flash.
        // It also updates the 'm_LastRoundWinner' attribute.
        // If i_Update , true - updates the winner. else - not update.(For AI purpose).
        public bool CheckForAWin(int i_ColumnNum, ePlayerNum i_PlayerNum, bool i_Update)
        {
            bool isASeqExists = false;

            if (i_Update)
            {
                this.LastRoundWinner = ePlayerNum.Empty;
            }

            isASeqExists = m_GameBoard.IsPartOfASequence(i_ColumnNum, i_PlayerNum);

            if (isASeqExists)
            {
                if (i_Update)
                {
                    this.LastRoundWinner = i_PlayerNum;
                }
            }

            return isASeqExists;
        }

        // insert chip. return true - if succeed . false - otherwise.
        // If i_Update , true - change the board. else - not update.(For AI purpose & UI better function).
        public bool InsertChip(Chip i_Chip, int i_ColumNum, bool i_Update)
        {
            return m_GameBoard.InsertChip(i_Chip, i_ColumNum, i_Update);
        }

        // Remove the upper chip from the given column (if exists).
        // Return true, If succeed.
        // False , Otherwise.
        // If i_Update , true - change the board. else - not update.(For AI purpose & UI better function).
        public bool RemoveChip(int i_ColumNum, bool i_Update)
        {
            return m_GameBoard.RemoveChip(i_ColumNum, i_Update);
        }

        public bool IsRowNumInRange(int i_RowNum)
        {
            return this.m_GameBoard.IsRowNumInRange(i_RowNum);
        }

        public bool IsColNumInRange(int i_ColNum)
        {
            bool isColInRange = false;

            isColInRange = this.m_GameBoard.IsColNumInRange(i_ColNum);

            return isColInRange;
        }

        // Check if can be inserted to column i_Column.
        // return true - if chip can be inserted to column number i_Column . false - otherwise.
        public bool ValidateColumn(int i_Column)
        {
            return m_GameBoard.ValidateColumn(i_Column);
        }

        public bool IsBoardFull()
        {
            return m_GameBoard.IsBoardFull();
        }

        public string RoundWinner()
        {
            StringBuilder res = new StringBuilder();
            string envNewLine = Environment.NewLine;

            if (m_LastRoundWinner == ePlayerNum.Empty)
            {
                //// A tie.
                res.Append("A tie" + envNewLine);
                LastRoundWinner = ePlayerNum.Empty;
            }
            else if (m_LastRoundWinner == ePlayerNum.Player1)
            {
                //// Player 1 won.
                res.Append("Player 1 Won" + envNewLine);
                LastRoundWinner = ePlayerNum.Player1;
            }
            else
            {
                //// Player 2 won. AKA player 2 OR computer.
                res.Append("Player 2 Won" + envNewLine);
                LastRoundWinner = ePlayerNum.Player2;
            }

            return res.ToString();
        }

        // Prints the board.
        public override string ToString()
        {
            StringBuilder boardRep = new StringBuilder();

            boardRep.Append(m_GameBoard.ToString());

            return boardRep.ToString();
        }

        public void ClearBoard()
        {
            m_GameBoard.ClearBoard();
        }
    }
}