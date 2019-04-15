using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Ex05.Logic;

namespace C18_Ex05.UI
{
    public partial class GamePanel : Form
    {
        private readonly int r_NumOfRows;
        private readonly int r_NumOfCols;
        private GameManager m_GameManager;
        private ePlayerNum m_Player = ePlayerNum.Player1;
        private int m_NumOfPlayers;  
        
        public GamePanel(int i_NumOfRows, int i_NumOfCols, string i_Player1Name, string i_Player2Name, int i_NumOfPlayers)
        {
            InitializeComponent();

            generateControlButtonMatrix(i_NumOfCols);
            generateButtonMatrix(i_NumOfRows, i_NumOfCols);

            this.labelPlayer1Score.Text = i_Player1Name;
            this.labelPlayer2Score.Text = i_Player2Name;
            this.m_NumOfPlayers = i_NumOfPlayers;
            this.r_NumOfCols = i_NumOfCols;
            this.r_NumOfRows = i_NumOfRows;

            m_GameManager = new GameManager(i_NumOfRows, i_NumOfCols);

            this.m_GameManager.GameBoard.InsertedChip += ButtonImageChange;
            this.m_GameManager.GameBoard.DeleteChip += ButtonImageRemovel;
        }

        private void generateControlButtonMatrix(int i_NumOfCols)
        {
            int colIndexer = 0;
            int numOfPixelsPerButton = 50;
            Padding buttonPad = new Padding(0);
            Size buttonSize = new Size(numOfPixelsPerButton, numOfPixelsPerButton); // Must be a Square.
            
            this.tableLayoutPanelControlButtons.ColumnCount = i_NumOfCols;

            this.tableLayoutPanelControlButtons.ColumnStyles.Clear();
            this.tableLayoutPanelControlButtons.RowStyles.Clear();

            this.tableLayoutPanelControlButtons.RowStyles.Add(new RowStyle(SizeType.Absolute, buttonSize.Height));

            for (colIndexer = 0; colIndexer < i_NumOfCols; colIndexer++)
            {
                Button button = new Button();
                button.Name = "ControlButton_" + colIndexer.ToString();
                button.Size = buttonSize;
                button.Dock = DockStyle.Fill;
                button.Enabled = false;
                button.Margin = buttonPad;
                
                // building the header & the columnStyle - once.
                // After one run of this loop - header will be disabled.      
                this.tableLayoutPanelControlButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, buttonSize.Width));
                
                button.Text = (colIndexer + 1).ToString();
                button.Enabled = true;
                button.Click += new EventHandler(this.buttonClicked);

                this.tableLayoutPanelControlButtons.Controls.Add(button, colIndexer, 0);            
            }

            this.tableLayoutPanelControlButtons.RowCount++;
            this.tableLayoutPanelControlButtons.RowStyles.Add(new RowStyle(SizeType.Absolute, 1F));

            this.tableLayoutPanelControlButtons.ColumnCount++;
            this.tableLayoutPanelControlButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 1F));
        }

        // $G$ DSN-003 (-5) This method is too long. Should be split into several methods.
        private void generateButtonMatrix(int i_NumOfRows, int i_NumOfCols)
        {
            bool firstRow = true;
            int rowIndexer = 0;
            int colIndexer = 0;
            int numOfPixelsPerButton = 50;

            Padding buttonPad = new Padding(0);
            Size buttonSize  = new Size(numOfPixelsPerButton, numOfPixelsPerButton); // Must be a Square.
            
            this.tableButtons.RowCount = i_NumOfRows;
            this.tableButtons.ColumnCount = i_NumOfCols;

            this.tableButtons.ColumnStyles.Clear();
            this.tableButtons.RowStyles.Clear();

            for (rowIndexer = 0; rowIndexer < i_NumOfRows; rowIndexer++)
            {
                this.tableButtons.RowStyles.Add(new RowStyle(SizeType.Percent, buttonSize.Height));
                
                for (colIndexer = 0; colIndexer < i_NumOfCols; colIndexer++)
                {
                    Button button = new Button();
                    button.Name = "button " + rowIndexer.ToString() + colIndexer.ToString();
                    button.Size = buttonSize;
                    button.Dock = DockStyle.Fill;
                    button.Enabled = false;
                    button.Margin = buttonPad;
                    button.BackgroundImageLayout = ImageLayout.Zoom;

                    if (firstRow)
                    {
                        // building the first row & the columnStyle - once.
                        // After one run of this loop - header(first row) will be disabled.
                        this.tableButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, buttonSize.Width));
                    }
                    
                    this.tableButtons.Controls.Add(button, colIndexer, rowIndexer);
                }

                firstRow = false;
            }

            this.tableButtons.RowCount++;
            this.tableButtons.RowStyles.Add(new RowStyle(SizeType.Absolute, 1F));
            
            this.tableButtons.ColumnCount++;
            this.tableButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 1F));

            this.tableLayoutPanelControlButtons.MinimumSize = new Size(
                (numOfPixelsPerButton * i_NumOfCols) + this.tableLayoutPanelControlButtons.Padding.Horizontal,
                numOfPixelsPerButton + this.tableLayoutPanelControlButtons.Padding.Vertical);

            this.tableButtons.MinimumSize = new Size(
                this.tableLayoutPanelControlButtons.Width,
                (numOfPixelsPerButton * i_NumOfRows) + this.tableButtons.Padding.Vertical);
            
            this.tableLabels.MinimumSize = new Size(
                (2 * this.labelPlayer1Score.Width) + (2 * this.tableLabels.Padding.Horizontal),
                this.labelPlayer1Score.Height + this.labelPlayer1Score.Padding.Vertical + this.tableLabels.Padding.Vertical);
            
            this.tableOuter.MinimumSize = new Size(
                this.tableLayoutPanelControlButtons.Width + this.tableOuter.Padding.Horizontal,
                this.tableLayoutPanelControlButtons.Height + this.tableButtons.Height + this.tableLabels.Height + this.tableOuter.Padding.Vertical);
            
            this.MinimumSize = new Size(
                this.tableOuter.Width + this.tableOuter.Padding.Horizontal,
                this.tableOuter.Height + this.tableOuter.Padding.Vertical + this.labelPlayer1Score.Height );
        }
        
        // The game will mange by this method.
        // buttonClicked or OnButtonClicked ? - it self generated..
        private void buttonClicked(object sender, EventArgs e)
        {
            int col;
            Button b = sender as Button;
            
            // Check it before all process - more general way..
            int.TryParse(b.Name.Substring(b.Name.Length - 1), out col);

            if (this.m_NumOfPlayers == 1)
            {
                // If one player :
                // The method will get the first click from player1, and then from the computer.
                // (need to disable all controls - while computer turn)
                // All control will Enabled after it.
                // (and this function will be activate again..)
                insertSelection(col, ePlayerNum.Player1);
                
                this.Enabled = false;
                this.Refresh();

                this.computerTurn();

                this.Enabled = true;
                this.Refresh();
            }
            else
            {
                // If two players :
                // The method will use a 'ePlayer m_Player' field (Attribute), that after each click will be changed on & off.
                // In this way each click will be a click of a different player.
                insertSelection(col, this.m_Player);

                // Change the player on & off..
                this.m_Player = this.m_Player == ePlayerNum.Player1 ? ePlayerNum.Player2 : ePlayerNum.Player1;
            }
        }

        private void insertSelection(int i_Col, ePlayerNum i_PlayerNum)
        {
            // If you can click on it - you can enter a chip.
            this.InsertChip(new Chip(i_PlayerNum), i_Col, true);
            
            updateButtonsAvailability();

            if (this.CheckForAWin(i_Col, i_PlayerNum, true))
            {
                // Player i_PlayerNum WON !
                increasePointsByOne(i_PlayerNum);
                
                // If we have a winner, we need to publish it.
                winnerMessageBox(i_PlayerNum);

                this.m_GameManager.LastRoundWinner = i_PlayerNum;               
            }
            else
            {
                // Player i_PlayerNum didn't win.
                if (this.IsBoardFull())
                {
                    this.aTieMessageBox();
                } 
            }

            updateButtonsAvailability();
        }

        private void increasePointsByOne(ePlayerNum i_PlayerNum)
        {
            if(i_PlayerNum == ePlayerNum.Player1)
            {
                this.labelPlayer1WinsCounter.Text = this.m_GameManager.IncreasePointsByOne(i_PlayerNum).ToString();
            }
            else
            {
                this.labelPlayer2WinsCounter.Text = this.m_GameManager.IncreasePointsByOne(i_PlayerNum).ToString();
            }
        }

        public bool IsRowNumInRange(int i_RowNum)
        {
            bool isRowInRange = false;

            isRowInRange = this.m_GameManager.IsRowNumInRange(i_RowNum);

            return isRowInRange;
        }

        public bool IsColNumInRange(int i_ColNum)
        {
            bool isColInRange = false;

            isColInRange = this.m_GameManager.IsColNumInRange(i_ColNum);

            return isColInRange;
        }

        // insert chip. return true - if succeed . false - otherwise.
        // If i_Update , true - change the board. else - not update.(For AI purpose & UI better function).
        public bool InsertChip(Chip i_Chip, int i_ColumNum, bool i_Update)
        {
            return m_GameManager.InsertChip(i_Chip, i_ColumNum, i_Update);
        }

        //// Check if can be inserted to column i_Column.
        //// return true - if chip can be inserted to column number i_Column . false - otherwise.
        public bool ValidateColumn(int i_Column)
        {
            return m_GameManager.ValidateColumn(i_Column);
        }

        public bool IsBoardFull()
        {
            bool isBoardFull = false;

            isBoardFull = m_GameManager.IsBoardFull();

            return isBoardFull;
        }

        public bool CheckForAWin(int i_ColumnNum, ePlayerNum i_PlayerNum, bool i_Update)
        {
            bool res = false;

            res = m_GameManager.CheckForAWin(i_ColumnNum, i_PlayerNum, i_Update);

            return res;
        }

        private void computerTurn()
        {
            AILogic ai = new AILogic();
            Random rand = new Random();
            int colToBeInserted = 0;
            int numOfCols = m_GameManager.GetNumOfCols();

            //// Column choosed.
            colToBeInserted = ai.AIManager(this.m_GameManager);

            // $G$ NTT-002 (-10) You shouldn't use while for game routin. WinForm project is events oriented.
            while (!ValidateColumn(colToBeInserted))
            {
                /// Column choosed.
                /// We left the rand here, as a "Fail-Safe" procedure . please pay attion for this point.

                // $G$ DSN-002 (-20) No UI seperation! This class merge the Logic board with the Visual board (UserControl) of the game...
                colToBeInserted = rand.Next(0, numOfCols);
            }

            insertSelection(colToBeInserted, ePlayerNum.Computer);

            updateButtonsAvailability();
        }

        // check availability
        private void updateButtonsAvailability()
        {
            int colIndexer = 0;
            for (; colIndexer < this.r_NumOfCols; colIndexer++)
            {
                if(!this.ValidateColumn(colIndexer))
                {
                    // disable availability of column 'col'.
                    this.tableLayoutPanelControlButtons.GetControlFromPosition(colIndexer, 0).Enabled = false;
                }
                else
                {
                    this.tableLayoutPanelControlButtons.GetControlFromPosition(colIndexer, 0).Enabled = true;
                }
            }    
        }
        
        private void chipMovment(int i_Row, int i_Col, Bitmap i_ChipImage)
        {
            int rowIndexer = 0;
            double waitTimeInMilliseconds = 15; // for each row wait 15 milliseconds.
            Stopwatch s = new Stopwatch();
            s.Start();
            
            for(rowIndexer = 0; rowIndexer < i_Row; rowIndexer++)
            {
                this.tableButtons.GetControlFromPosition(i_Col, rowIndexer).BackgroundImage = i_ChipImage;
                this.tableButtons.GetControlFromPosition(i_Col, rowIndexer).BackgroundImageLayout = ImageLayout.Zoom;

                this.Refresh();

                s.Reset();
                s.Start();
                // $G$ NTT-002 (-3) You shouldn't use while for game routin. WinForm project is events oriented. - use Timer event instead
                while (s.ElapsedMilliseconds < waitTimeInMilliseconds)
                {
                    // Wait for 'waitTimeInMilliseconds' millisecondes
                }

                ButtonImageRemovel(rowIndexer, i_Col);
            }

            this.tableButtons.GetControlFromPosition(i_Col, i_Row).BackgroundImage = i_ChipImage;
        }

        internal void ButtonImageRemovel(int i_Row, int i_Col)
        {
            if (IsColNumInRange(i_Col) && IsRowNumInRange(i_Row))
            {
                this.tableButtons.GetControlFromPosition(i_Col, i_Row).BackgroundImage = null;
            }
        }

        internal void ButtonImageChange(int i_Row, int i_Col, ePlayerNum i_PlayerNum)
        {
            Bitmap blueChip = Properties.Resources.bluePiece;
            Bitmap redChip = Properties.Resources.RedPiece;
            
            // Dont check if avialable, because if not - should'nt get here, because cant be choosen.
            if (IsColNumInRange(i_Col) && IsRowNumInRange(i_Row))
            {
                if (i_PlayerNum == ePlayerNum.Empty)
                {
                    ButtonImageRemovel(i_Row, i_Col);
                }
                else if (i_PlayerNum == ePlayerNum.Player1)
                {
                    // Blue Chip.
                    chipMovment(i_Row, i_Col, blueChip);
                }
                else
                {
                    // Red Chip.
                    chipMovment(i_Row, i_Col, redChip);
                }
            }     
        }

        // Exit Message Box
        private void exitMessageBox()
        {
            if (MessageBox.Show(@"Want To Exit?", @"Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                this.additionalMessageBox();
            }
        }

        // Another Round Message Box
        private void additionalMessageBox()
        {
            if (MessageBox.Show("Additional Round ?", "Keep On Playing !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.clearBoard();
            }
            else
            {
                this.exitMessageBox();
            }
        }

        // Tie Message box
        private void aTieMessageBox()
        {
            MessageBox.Show("A Tie !", "Tie !", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.additionalMessageBox();
        }

        // Winner Message Box
        private void winnerMessageBox(ePlayerNum i_PlayerNum)
        {
            string playerName = i_PlayerNum == ePlayerNum.Player1 ? labelPlayer1Score.Text : labelPlayer2Score.Text;
            MessageBox.Show(
                @"Congratulation, " + playerName + @", has won this round",
                @"Congratulation !",
                MessageBoxButtons.OK);

            this.additionalMessageBox();
        }

        private void clearBoard()
        {
            this.m_GameManager.ClearBoard();

            foreach (Control control in this.tableButtons.Controls)
            {
                control.BackgroundImage = null;
            }
        }
    }
}
