namespace C18_Ex05.UI
{
    public partial class GameSettingsPane
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelPlayers = new System.Windows.Forms.Label();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.textBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.textBoxPlayer2 = new System.Windows.Forms.TextBox();
            this.labelBoardSize = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.nUDCols = new System.Windows.Forms.NumericUpDown();
            this.nUDRows = new System.Windows.Forms.NumericUpDown();
            this.labelRowsSize = new System.Windows.Forms.Label();
            this.labelColsSize = new System.Windows.Forms.Label();
            this.checkBoxPlayer2 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nUDCols)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDRows)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPlayers
            // 
            this.labelPlayers.AccessibleDescription = "PlayersLabel";
            this.labelPlayers.AccessibleName = "PlayersLabel";
            this.labelPlayers.AutoSize = true;
            this.labelPlayers.Location = new System.Drawing.Point(12, 9);
            this.labelPlayers.Name = "labelPlayers";
            this.labelPlayers.Size = new System.Drawing.Size(44, 13);
            this.labelPlayers.TabIndex = 0;
            this.labelPlayers.Text = "Players:";
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AccessibleDescription = "Player1Label";
            this.labelPlayer1.AccessibleName = "Player1Label";
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.Location = new System.Drawing.Point(25, 37);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(48, 13);
            this.labelPlayer1.TabIndex = 1;
            this.labelPlayer1.Text = "Player 1:";
            // 
            // textBoxPlayer1
            // 
            this.textBoxPlayer1.AccessibleDescription = "Player1TextBox";
            this.textBoxPlayer1.AccessibleName = "Player1TextBox";
            this.textBoxPlayer1.Location = new System.Drawing.Point(123, 34);
            this.textBoxPlayer1.Name = "textBoxPlayer1";
            this.textBoxPlayer1.Size = new System.Drawing.Size(100, 20);
            this.textBoxPlayer1.TabIndex = 2;
            this.textBoxPlayer1.TextChanged += new System.EventHandler(this.textBoxPlayer1_TextChanged);
            // 
            // textBoxPlayer2
            // 
            this.textBoxPlayer2.AccessibleDescription = "Player2TextBox";
            this.textBoxPlayer2.AccessibleName = "Player2TextBox";
            this.textBoxPlayer2.BackColor = System.Drawing.Color.Silver;
            this.textBoxPlayer2.Enabled = false;
            this.textBoxPlayer2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textBoxPlayer2.Location = new System.Drawing.Point(123, 60);
            this.textBoxPlayer2.Name = "textBoxPlayer2";
            this.textBoxPlayer2.Size = new System.Drawing.Size(100, 20);
            this.textBoxPlayer2.TabIndex = 4;
            this.textBoxPlayer2.Text = "[Computer]";
            this.textBoxPlayer2.TextChanged += new System.EventHandler(this.textBoxPlayer2_TextChanged);
            // 
            // labelBoardSize
            // 
            this.labelBoardSize.AutoSize = true;
            this.labelBoardSize.Location = new System.Drawing.Point(12, 111);
            this.labelBoardSize.Name = "labelBoardSize";
            this.labelBoardSize.Size = new System.Drawing.Size(61, 13);
            this.labelBoardSize.TabIndex = 5;
            this.labelBoardSize.Text = "Board Size:";
            // 
            // StartButton
            // 
            this.StartButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.StartButton.Enabled = false;
            this.StartButton.Location = new System.Drawing.Point(15, 202);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(208, 29);
            this.StartButton.TabIndex = 10;
            this.StartButton.Text = "Start!";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // nUDCols
            // 
            this.nUDCols.Location = new System.Drawing.Point(179, 147);
            this.nUDCols.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDCols.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nUDCols.Name = "nUDCols";
            this.nUDCols.Size = new System.Drawing.Size(44, 20);
            this.nUDCols.TabIndex = 9;
            this.nUDCols.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // nUDRows
            // 
            this.nUDRows.Location = new System.Drawing.Point(64, 147);
            this.nUDRows.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDRows.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nUDRows.Name = "nUDRows";
            this.nUDRows.Size = new System.Drawing.Size(44, 20);
            this.nUDRows.TabIndex = 7;
            this.nUDRows.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // labelRowsSize
            // 
            this.labelRowsSize.AutoSize = true;
            this.labelRowsSize.Location = new System.Drawing.Point(21, 149);
            this.labelRowsSize.Name = "labelRowsSize";
            this.labelRowsSize.Size = new System.Drawing.Size(37, 13);
            this.labelRowsSize.TabIndex = 6;
            this.labelRowsSize.Text = "Rows:";
            // 
            // labelColsSize
            // 
            this.labelColsSize.AutoSize = true;
            this.labelColsSize.Location = new System.Drawing.Point(143, 149);
            this.labelColsSize.Name = "labelColsSize";
            this.labelColsSize.Size = new System.Drawing.Size(30, 13);
            this.labelColsSize.TabIndex = 8;
            this.labelColsSize.Text = "Cols:";
            // 
            // checkBoxPlayer2
            // 
            this.checkBoxPlayer2.AutoSize = true;
            this.checkBoxPlayer2.Location = new System.Drawing.Point(28, 62);
            this.checkBoxPlayer2.Name = "checkBoxPlayer2";
            this.checkBoxPlayer2.Size = new System.Drawing.Size(67, 17);
            this.checkBoxPlayer2.TabIndex = 3;
            this.checkBoxPlayer2.Text = "Player 2:";
            this.checkBoxPlayer2.UseVisualStyleBackColor = true;
            this.checkBoxPlayer2.CheckedChanged += new System.EventHandler(this.checkBoxPlayer2_CheckedChanged);
            // 
            // GameSettingsPane
            // 
            this.AcceptButton = this.StartButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(241, 243);
            this.Controls.Add(this.checkBoxPlayer2);
            this.Controls.Add(this.labelColsSize);
            this.Controls.Add(this.labelRowsSize);
            this.Controls.Add(this.nUDRows);
            this.Controls.Add(this.nUDCols);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.labelBoardSize);
            this.Controls.Add(this.textBoxPlayer2);
            this.Controls.Add(this.textBoxPlayer1);
            this.Controls.Add(this.labelPlayer1);
            this.Controls.Add(this.labelPlayers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettingsPane";
            this.Text = "Game Settings";
            ((System.ComponentModel.ISupportInitialize)(this.nUDCols)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDRows)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPlayers;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.TextBox textBoxPlayer1;
        private System.Windows.Forms.TextBox textBoxPlayer2;
        private System.Windows.Forms.Label labelBoardSize;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.NumericUpDown nUDCols;
        private System.Windows.Forms.NumericUpDown nUDRows;
        private System.Windows.Forms.Label labelRowsSize;
        private System.Windows.Forms.Label labelColsSize;
        private System.Windows.Forms.CheckBox checkBoxPlayer2;
    }
}