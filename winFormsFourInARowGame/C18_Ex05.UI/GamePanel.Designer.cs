namespace C18_Ex05.UI
{
    public partial class GamePanel
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
            this.tableOuter = new System.Windows.Forms.TableLayoutPanel();
            this.tableLabels = new System.Windows.Forms.TableLayoutPanel();
            this.labelPlayer2WinsCounter = new System.Windows.Forms.Label();
            this.labelPlayer1WinsCounter = new System.Windows.Forms.Label();
            this.labelPlayer1Score = new System.Windows.Forms.Label();
            this.labelPlayer2Score = new System.Windows.Forms.Label();
            this.tableButtons = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelControlButtons = new System.Windows.Forms.TableLayoutPanel();
            this.tableOuter.SuspendLayout();
            this.tableLabels.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableOuter
            // 
            this.tableOuter.AutoScroll = true;
            this.tableOuter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableOuter.ColumnCount = 1;
            this.tableOuter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableOuter.Controls.Add(this.tableLabels, 0, 2);
            this.tableOuter.Controls.Add(this.tableButtons, 0, 1);
            this.tableOuter.Controls.Add(this.tableLayoutPanelControlButtons, 0, 0);
            this.tableOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableOuter.Location = new System.Drawing.Point(0, 0);
            this.tableOuter.Margin = new System.Windows.Forms.Padding(0);
            this.tableOuter.Name = "tableOuter";
            this.tableOuter.Padding = new System.Windows.Forms.Padding(4);
            this.tableOuter.RowCount = 3;
            this.tableOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableOuter.Size = new System.Drawing.Size(365, 289);
            this.tableOuter.TabIndex = 0;
            // 
            // tableLabels
            // 
            this.tableLabels.AutoScroll = true;
            this.tableLabels.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLabels.ColumnCount = 4;
            this.tableLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLabels.Controls.Add(this.labelPlayer2WinsCounter, 3, 0);
            this.tableLabels.Controls.Add(this.labelPlayer1WinsCounter, 1, 0);
            this.tableLabels.Controls.Add(this.labelPlayer1Score, 0, 0);
            this.tableLabels.Controls.Add(this.labelPlayer2Score, 2, 0);
            this.tableLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLabels.Location = new System.Drawing.Point(4, 255);
            this.tableLabels.Margin = new System.Windows.Forms.Padding(0);
            this.tableLabels.Name = "tableLabels";
            this.tableLabels.Padding = new System.Windows.Forms.Padding(3);
            this.tableLabels.RowCount = 1;
            this.tableLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLabels.Size = new System.Drawing.Size(357, 30);
            this.tableLabels.TabIndex = 1;
            // 
            // labelPlayer2WinsCounter
            // 
            this.labelPlayer2WinsCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPlayer2WinsCounter.Enabled = false;
            this.labelPlayer2WinsCounter.Location = new System.Drawing.Point(264, 3);
            this.labelPlayer2WinsCounter.Margin = new System.Windows.Forms.Padding(0);
            this.labelPlayer2WinsCounter.Name = "labelPlayer2WinsCounter";
            this.labelPlayer2WinsCounter.Size = new System.Drawing.Size(90, 24);
            this.labelPlayer2WinsCounter.TabIndex = 3;
            this.labelPlayer2WinsCounter.Text = "0";
            this.labelPlayer2WinsCounter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPlayer1WinsCounter
            // 
            this.labelPlayer1WinsCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPlayer1WinsCounter.Enabled = false;
            this.labelPlayer1WinsCounter.Location = new System.Drawing.Point(90, 3);
            this.labelPlayer1WinsCounter.Margin = new System.Windows.Forms.Padding(0);
            this.labelPlayer1WinsCounter.Name = "labelPlayer1WinsCounter";
            this.labelPlayer1WinsCounter.Size = new System.Drawing.Size(87, 24);
            this.labelPlayer1WinsCounter.TabIndex = 2;
            this.labelPlayer1WinsCounter.Text = "0";
            this.labelPlayer1WinsCounter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPlayer1Score
            // 
            this.labelPlayer1Score.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPlayer1Score.Enabled = false;
            this.labelPlayer1Score.Location = new System.Drawing.Point(3, 3);
            this.labelPlayer1Score.Margin = new System.Windows.Forms.Padding(0);
            this.labelPlayer1Score.Name = "labelPlayer1Score";
            this.labelPlayer1Score.Size = new System.Drawing.Size(87, 24);
            this.labelPlayer1Score.TabIndex = 0;
            this.labelPlayer1Score.Text = "Player1:";
            this.labelPlayer1Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPlayer2Score
            // 
            this.labelPlayer2Score.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPlayer2Score.Enabled = false;
            this.labelPlayer2Score.Location = new System.Drawing.Point(177, 3);
            this.labelPlayer2Score.Margin = new System.Windows.Forms.Padding(0);
            this.labelPlayer2Score.Name = "labelPlayer2Score";
            this.labelPlayer2Score.Size = new System.Drawing.Size(87, 24);
            this.labelPlayer2Score.TabIndex = 1;
            this.labelPlayer2Score.Text = "Player2:";
            this.labelPlayer2Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableButtons
            // 
            this.tableButtons.AutoScroll = true;
            this.tableButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableButtons.ColumnCount = 1;
            this.tableButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableButtons.Location = new System.Drawing.Point(4, 55);
            this.tableButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tableButtons.Name = "tableButtons";
            this.tableButtons.RowCount = 1;
            this.tableButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableButtons.Size = new System.Drawing.Size(357, 200);
            this.tableButtons.TabIndex = 0;
            // 
            // tableLayoutPanelControlButtons
            // 
            this.tableLayoutPanelControlButtons.AutoScroll = true;
            this.tableLayoutPanelControlButtons.ColumnCount = 1;
            this.tableLayoutPanelControlButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelControlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelControlButtons.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanelControlButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelControlButtons.Name = "tableLayoutPanelControlButtons";
            this.tableLayoutPanelControlButtons.RowCount = 1;
            this.tableLayoutPanelControlButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelControlButtons.Size = new System.Drawing.Size(357, 51);
            this.tableLayoutPanelControlButtons.TabIndex = 2;
            // 
            // GamePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(365, 289);
            this.Controls.Add(this.tableOuter);
            this.DoubleBuffered = true;
            this.Name = "GamePanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "4 in A Row !";
            this.tableOuter.ResumeLayout(false);
            this.tableLabels.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableOuter;
        private System.Windows.Forms.TableLayoutPanel tableButtons;
        private System.Windows.Forms.TableLayoutPanel tableLabels;
        private System.Windows.Forms.Label labelPlayer1Score;
        private System.Windows.Forms.Label labelPlayer2Score;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelControlButtons;
        private System.Windows.Forms.Label labelPlayer2WinsCounter;
        private System.Windows.Forms.Label labelPlayer1WinsCounter;
    }
}