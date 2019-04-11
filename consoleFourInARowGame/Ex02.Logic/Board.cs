using System;
using System.Collections.Generic;
using System.Text;

namespace Ex02.Logic
{
    public class Board
    {
        private Chip[,] m_Board;

        public Board(int i_NumOfRows, int i_NumOfCols)
        {
            m_Board = new Chip[i_NumOfRows, i_NumOfCols];
        }
    
        public int GetNumOfCols()
        {
            return m_Board.GetLength(1);
        }

        public int GetNumOfRows()
        {
            return m_Board.GetLength(0);
        }

        // insert chip. return true - if succeed . false - otherwise.
        public bool InsertChip(Chip i_Chip, int i_ColumNum)
        {
            bool res = false;
            int numOfRows = m_Board.GetLength(0);

            if (ValidateColumn(i_ColumNum))
            {
                int row = 0;
                
                for(; row < numOfRows - 1 && m_Board[row, i_ColumNum] == null; row++)
                {
                }

                if (row < numOfRows  
                    && m_Board[row, i_ColumNum] != null 
                    && m_Board[row, i_ColumNum].PlayerNum != ePlayerNum.Empty)
                {
                    row--;
                }
                
                m_Board[row, i_ColumNum] = i_Chip;
                
                res = true;
            }

            return res;
        }

        // Remove the upper chip from the given column (if exists).
        // Return true, If succeed.
        // False , Otherwise.
        public bool RemoveChip(int i_ColumNum)
        {
            bool succeedRemoval = false;
            int numOfRows = this.m_Board.GetLength(0);

            if (this.IsColNumInRange(i_ColumNum))
            {
                int row = 0;
                
                for (; row < numOfRows - 1 && this.m_Board[row, i_ColumNum] == null; row++)
                {
                }
                
                if(this.IsRowNumInRange(row))
                {
                    this.m_Board[row, i_ColumNum] = null;

                    succeedRemoval = true;
                }
            }

            return succeedRemoval;
        }

        public bool IsRowNumInRange(int i_RowNum)
        {
            bool isRowInRange = false;

            if (i_RowNum >= 0 && i_RowNum < m_Board.GetLength(0))
            {
                isRowInRange = true;
            }

            return isRowInRange;
        }

        public bool IsColNumInRange(int i_ColNum)
        {
            bool isColInRange = false;

            if (i_ColNum >= 0 && i_ColNum < m_Board.GetLength(1))
            {
                isColInRange = true;
            }

            return isColInRange;
        }

        //// Check if can be inserted to column i_Column.
        //// return true - if chip can be inserted to column number i_Column . false - otherwise.
        public bool ValidateColumn(int i_ColNum)
        {
            bool isColValid = false;
            
            if (IsColNumInRange(i_ColNum)
                && (m_Board[0, i_ColNum] == null || m_Board[0, i_ColNum].PlayerNum == ePlayerNum.Empty) )
            {
                isColValid = true;
            }

            return isColValid;
        }

        public bool IsPartOfASequence(int i_ColumNum, ePlayerNum i_PlayerNum)
        {
            bool isPartOfSeq = false;
            int numOfRows = m_Board.GetLength(0);
            
            if (IsColNumInRange(i_ColumNum))
            {
                int row = 0;

                for (; row < numOfRows - 1 && m_Board[row, i_ColumNum] == null; row++)
                {
                    //// Find the first non-null object in the column
                }

                if(row <= numOfRows - 1)
                {
                    isPartOfSeq = isPartOfASequence(row, i_ColumNum, m_Board[row, i_ColumNum].PlayerNum);
                } 
            }

            return isPartOfSeq;
        }

        //// checks winning conditions after adding a chip to pos [i_Row,i_Col]
        private bool isPartOfASequence(int i_Row, int i_Col, ePlayerNum i_ePlayerNum)
        {
            bool isPartOfSeq = false;

            if (checkRowSeq(i_Row, i_Col, i_ePlayerNum) || 
                checkColumnSeq(i_Row, i_Col, i_ePlayerNum) || 
                checkDiagonalSeq(i_Row, i_Col, i_ePlayerNum))
            {
                isPartOfSeq = true;
            }

            return isPartOfSeq;
        }

        // Checks whether a row sequence exists with the new added chip
        private bool checkRowSeq(int i_Row, int i_Col, ePlayerNum i_ePlayerNum)
        {
            bool isPartOfSeq = false;
            int chipCounter = 1;
            int runningColIndex = i_Col + 1;

            // Explore the right side of the row
            while (runningColIndex < m_Board.GetLength(1) && chipCounter < 4)
            {
                if (checkPosPerPlayer(i_Row, runningColIndex, i_ePlayerNum))
                {
                    chipCounter++;
                    runningColIndex++;
                }
                else
                {
                    break;
                }
            }

            runningColIndex = i_Col - 1;

            // Explore the left side of the row
            while (runningColIndex >= 0 && chipCounter < 4)
            {
                if (checkPosPerPlayer(i_Row, runningColIndex, i_ePlayerNum))
                {
                    chipCounter++;
                    runningColIndex--;
                }
                else
                {
                    break;
                }
            }

            if (chipCounter == 4)
            {
                isPartOfSeq = true;
            }
            
            return isPartOfSeq;
        }

        // Checks whether a column sequence exists with the new added chip
        private bool checkColumnSeq(int i_Row, int i_Col, ePlayerNum i_ePlayerNum)
        {
            bool isPartOfSeq = false;
            int chipCounter = 1;
            int runningRowIndex = i_Row + 1;

            // Explore the upper column for a sequnce
            while (runningRowIndex < m_Board.GetLength(0) && chipCounter < 4)
            {
                if (checkPosPerPlayer(runningRowIndex, i_Col, i_ePlayerNum))
                {
                    chipCounter++;
                    runningRowIndex++;
                }
                else
                {
                    break;
                }
            }

            runningRowIndex = i_Row - 1;

            // Explore the bottom column for a sequnce 
            while (runningRowIndex >= 0 && chipCounter < 4)
            {
                if (checkPosPerPlayer(runningRowIndex, i_Col, i_ePlayerNum))
                {
                    chipCounter++;
                    runningRowIndex--;
                }
                else
                {
                    break;
                }
            }

            if (chipCounter == 4)
            {
                isPartOfSeq = true;
            }

            return isPartOfSeq;
        }

        // Checks whether a diagonal sequence exists with the new added chip
        private bool checkDiagonalSeq(int i_Row, int i_Col, ePlayerNum i_ePlayerNum)
        {
            bool isPartOfSeq = false;
            int chipCounterForwardDiag = 1;
            int chipCounterBackwardDiag = 1;

            chipCounterForwardDiag += checkDiagonalSeqAux(i_Row, i_Col, 0, '+', '+', i_ePlayerNum) 
                + checkDiagonalSeqAux(i_Row, i_Col, 0, '-', '-', i_ePlayerNum);
            chipCounterBackwardDiag += checkDiagonalSeqAux(i_Row, i_Col, 0, '+', '-', i_ePlayerNum)
                + checkDiagonalSeqAux(i_Row, i_Col, 0, '-', '+', i_ePlayerNum);

            if (chipCounterForwardDiag == 4 || chipCounterBackwardDiag == 4)
            {
                isPartOfSeq = true;
            }

            return isPartOfSeq;
        }
         
        // Auxilery function for checking both possible diagonal sequences
        private int checkDiagonalSeqAux(int i_Row, int i_Col, int i_ChipCounter, char i_RowIncDir, char i_ColIncDir, ePlayerNum i_ePlayerNum)
        {
            int runningColIndex = i_ColIncDir == '+' ? i_Col + 1 : i_Col - 1;
            int runningRowIndex = i_RowIncDir == '+' ? i_Row + 1 : i_Row - 1;

            while (IsColNumInRange(runningColIndex) && IsRowNumInRange(runningRowIndex) && i_ChipCounter < 4)
            {
                if (checkPosPerPlayer(runningRowIndex, runningColIndex, i_ePlayerNum))
                {
                    i_ChipCounter++;
                    runningColIndex = i_ColIncDir == '+' ? runningColIndex + 1 : runningColIndex - 1;
                    runningRowIndex = i_RowIncDir == '+' ? runningRowIndex + 1 : runningRowIndex - 1;
                }
                else
                {
                    break;
                }
            }

            return i_ChipCounter;
        }

        // Checks if the board position is filled by the passed player enum.
        private bool checkPosPerPlayer(int i_Row, int i_Col, ePlayerNum i_ePlayerNum = ePlayerNum.Empty)
        {
            bool res = false;

            if ((i_Row >= 0 && i_Row < m_Board.GetLength(0)) && (i_Col >= 0 && i_Col < m_Board.GetLength(1)))
            {
                if (m_Board[i_Row, i_Col] != null && m_Board[i_Row, i_Col].PlayerNum == i_ePlayerNum)
                {
                    res = true;
                }
            }

            return res;
        }

        // This function return true - if the board is full. i.e - all upper row is contain nonEmpty Chips.
        // Otherwise - false.
        public bool IsBoardFull()
        {
            bool isBoardFull = true;

            for (int col = 0; col < m_Board.GetLength(1); col++)
            {
                if (m_Board[0, col] == null || m_Board[0, col].PlayerNum == ePlayerNum.Empty)
                {
                    isBoardFull = false;
                }
            }

            return isBoardFull;
        }

        public void ClearBoard()
        {  
            for (int row = 0; row < this.m_Board.GetLength(0); row++)
            {
                for (int col = 0; col < this.m_Board.GetLength(1); col++)
                {
                    if(this.m_Board[row, col] != null)
                    {
                        this.m_Board[row, col] = null;
                    }
                }
            }
        }

        // Prints the Board .
        public override string ToString()
        {
            char emptyCellToken = ' ';
            StringBuilder boardRep = new StringBuilder();

            for(int i = 0; i < m_Board.GetLength(0); i++)
            {
                for (int j = 0; j < m_Board.GetLength(1); j++)
                {
                    if (m_Board[i, j] == null)
                    {
                        boardRep.Append(emptyCellToken);
                    }
                    else
                    {
                        boardRep.Append((char)m_Board[i, j].Representation);
                    }
                }

                boardRep.Append(System.Environment.NewLine);
            }

            return boardRep.ToString();
        }
    }
}
