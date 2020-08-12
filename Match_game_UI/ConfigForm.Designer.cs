namespace Match_game_UI
{
    public partial class ConfigForm
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
            this.firstPlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.firstPlayerNameLabel = new System.Windows.Forms.Label();
            this.secondPlayerNameLabel = new System.Windows.Forms.Label();
            this.secondPlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.friendOrComputerButton = new System.Windows.Forms.Button();
            this.sizeOfBoardButton = new System.Windows.Forms.Button();
            this.startGameButton = new System.Windows.Forms.Button();
            this.boardSizeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // firstPlayerNameTextBox
            // 
            this.firstPlayerNameTextBox.Location = new System.Drawing.Point(157, 17);
            this.firstPlayerNameTextBox.Name = "firstPlayerNameTextBox";
            this.firstPlayerNameTextBox.Size = new System.Drawing.Size(170, 22);
            this.firstPlayerNameTextBox.TabIndex = 0;
            this.firstPlayerNameTextBox.TextChanged += new System.EventHandler(this.firstPlayerNameTextBoxTextChanged);
            // 
            // firstPlayerNameLabel
            // 
            this.firstPlayerNameLabel.AutoSize = true;
            this.firstPlayerNameLabel.Location = new System.Drawing.Point(12, 23);
            this.firstPlayerNameLabel.Name = "firstPlayerNameLabel";
            this.firstPlayerNameLabel.Size = new System.Drawing.Size(118, 16);
            this.firstPlayerNameLabel.TabIndex = 1;
            this.firstPlayerNameLabel.Text = "First Player Name:";
            
            // 
            // secondPlayerNameLabel
            // 
            this.secondPlayerNameLabel.AutoSize = true;
            this.secondPlayerNameLabel.Location = new System.Drawing.Point(12, 88);
            this.secondPlayerNameLabel.Name = "secondPlayerNameLabel";
            this.secondPlayerNameLabel.Size = new System.Drawing.Size(140, 16);
            this.secondPlayerNameLabel.TabIndex = 2;
            this.secondPlayerNameLabel.Text = "Second Player Name:";
            // 
            // secondPlayerNameTextBox
            // 
            this.secondPlayerNameTextBox.Enabled = false;
            this.secondPlayerNameTextBox.Location = new System.Drawing.Point(157, 82);
            this.secondPlayerNameTextBox.Name = "secondPlayerNameTextBox";
            this.secondPlayerNameTextBox.Size = new System.Drawing.Size(170, 22);
            this.secondPlayerNameTextBox.TabIndex = 3;
            this.secondPlayerNameTextBox.Text = "-Computer-";
            this.secondPlayerNameTextBox.TextChanged += new System.EventHandler(this.secondPlayerNameTextBox_TextChanged);
            // 
            // friendOrComputerButton
            // 
            this.friendOrComputerButton.Location = new System.Drawing.Point(333, 74);
            this.friendOrComputerButton.Name = "friendOrComputerButton";
            this.friendOrComputerButton.Size = new System.Drawing.Size(159, 30);
            this.friendOrComputerButton.TabIndex = 4;
            this.friendOrComputerButton.Text = "Against a Friend";
            this.friendOrComputerButton.UseVisualStyleBackColor = true;
            this.friendOrComputerButton.Click += new System.EventHandler(this.friendOrComputerButton_Click);
            // 
            // sizeOfBoardButton
            // 
            this.sizeOfBoardButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.sizeOfBoardButton.Location = new System.Drawing.Point(33, 191);
            this.sizeOfBoardButton.Name = "sizeOfBoardButton";
            this.sizeOfBoardButton.Size = new System.Drawing.Size(105, 92);
            this.sizeOfBoardButton.TabIndex = 5;
            this.sizeOfBoardButton.Text = "4x4";
            this.sizeOfBoardButton.UseVisualStyleBackColor = false;
            this.sizeOfBoardButton.Click += new System.EventHandler(this.sizeOfBoardButton_Click);
            // 
            // startGameButton
            // 
            this.startGameButton.BackColor = System.Drawing.Color.LawnGreen;
            this.startGameButton.Location = new System.Drawing.Point(353, 260);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(117, 23);
            this.startGameButton.TabIndex = 6;
            this.startGameButton.Text = "Start!";
            this.startGameButton.UseVisualStyleBackColor = false;
            this.startGameButton.Click += new System.EventHandler(this.startGameButton_Click);
            // 
            // boardSizeLabel
            // 
            this.boardSizeLabel.AutoSize = true;
            this.boardSizeLabel.Location = new System.Drawing.Point(44, 159);
            this.boardSizeLabel.Name = "boardSizeLabel";
            this.boardSizeLabel.Size = new System.Drawing.Size(77, 16);
            this.boardSizeLabel.TabIndex = 7;
            this.boardSizeLabel.Text = "Board Size:";
            
            // 
            // ConfigForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(538, 317);
            this.Controls.Add(this.boardSizeLabel);
            this.Controls.Add(this.startGameButton);
            this.Controls.Add(this.sizeOfBoardButton);
            this.Controls.Add(this.friendOrComputerButton);
            this.Controls.Add(this.secondPlayerNameTextBox);
            this.Controls.Add(this.secondPlayerNameLabel);
            this.Controls.Add(this.firstPlayerNameLabel);
            this.Controls.Add(this.firstPlayerNameTextBox);
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "ConfigForm";
            this.Text = "ConfigForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox firstPlayerNameTextBox;
        private System.Windows.Forms.Label firstPlayerNameLabel;
        private System.Windows.Forms.Label secondPlayerNameLabel;
        private System.Windows.Forms.TextBox secondPlayerNameTextBox;
        private System.Windows.Forms.Button friendOrComputerButton;
        private System.Windows.Forms.Button sizeOfBoardButton;
        private System.Windows.Forms.Button startGameButton;
        private System.Windows.Forms.Label boardSizeLabel;
    }
}