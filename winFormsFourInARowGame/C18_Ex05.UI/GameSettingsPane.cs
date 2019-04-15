using System;
using System.Drawing;
using System.Windows.Forms;

namespace C18_Ex05.UI
{
    public delegate void ChangedtextBox(object sender, EventArgs e);
    
    public partial class GameSettingsPane : Form
    {
        // $G$ CSS-010 (-5) Bad method name. Event handlers should not be public
        public ChangedtextBox m_ChangedtextBox;

        public GameSettingsPane()
        {
            InitializeComponent();
        }

        private void checkBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxPlayer2.Checked)
            {
                textBoxPlayer2.Enabled = true;
                textBoxPlayer2.BackColor = Color.White;
                textBoxPlayer2.Text = string.Empty;
                textBoxPlayer2.ForeColor = Color.Black;

                this.StartButton.Enabled = false;
            }
            else
            {
                textBoxPlayer2.Enabled = false;
                textBoxPlayer2.BackColor = Color.Silver;
                textBoxPlayer2.Text = @"[Computer]";
                textBoxPlayer2.ForeColor = SystemColors.ControlDarkDark;

                if (this.textBoxPlayer1.TextLength > 0)
                {
                    this.StartButton.Enabled = true;
                }
                else
                {
                    this.StartButton.Enabled = false;
                }
            }
        }
        
        private void StartButton_Click(object sender, EventArgs e)
        {
            GamePanel gameBoard = new GamePanel(
                Convert.ToInt16(this.nUDRows.Value),
                Convert.ToInt16(this.nUDCols.Value),
                this.textBoxPlayer1.Text,
                this.checkBoxPlayer2.Checked ? this.textBoxPlayer2.Text : this.checkBoxPlayer2.Text,
                this.checkBoxPlayer2.Checked ? 2 : 1);

            this.Hide();
            gameBoard.ShowDialog();
        }
 
        private void textBoxPlayer1_TextChanged(object sender, EventArgs e)
        {
            this.StartButton.Enabled = false;

            if (this.textBoxPlayer1.TextLength > 0)
            {
                this.StartButton.Enabled = true;
            }
        }

        private void textBoxPlayer2_TextChanged(object sender, EventArgs e)
        {
            this.StartButton.Enabled = false;

            if (this.textBoxPlayer2.TextLength > 0)
            {
                this.StartButton.Enabled = true;
            }
        }
    }
}
