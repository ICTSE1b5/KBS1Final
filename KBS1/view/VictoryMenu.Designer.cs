namespace KBS1.view
{
    partial class VictoryMenu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_RestartLevel = new System.Windows.Forms.Button();
            this.button_NextLevel = new System.Windows.Forms.Button();
            this.button_MainMenu = new System.Windows.Forms.Button();
            this.button_ExitGame = new System.Windows.Forms.Button();
            this.button_SubmitScore = new System.Windows.Forms.Button();
            this.textBox_SubmitScore = new System.Windows.Forms.TextBox();
            this.label_Score = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_RestartLevel
            // 
            this.button_RestartLevel.Location = new System.Drawing.Point(151, 185);
            this.button_RestartLevel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_RestartLevel.Name = "button_RestartLevel";
            this.button_RestartLevel.Size = new System.Drawing.Size(112, 50);
            this.button_RestartLevel.TabIndex = 0;
            this.button_RestartLevel.Text = "Restart level";
            this.button_RestartLevel.UseVisualStyleBackColor = true;
            this.button_RestartLevel.Click += new System.EventHandler(this.button_RestartLevel_Click);
            // 
            // button_NextLevel
            // 
            this.button_NextLevel.Location = new System.Drawing.Point(304, 185);
            this.button_NextLevel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_NextLevel.Name = "button_NextLevel";
            this.button_NextLevel.Size = new System.Drawing.Size(112, 50);
            this.button_NextLevel.TabIndex = 1;
            this.button_NextLevel.Text = "Next level";
            this.button_NextLevel.UseVisualStyleBackColor = true;
            this.button_NextLevel.Click += new System.EventHandler(this.button_NextLevel_Click);
            // 
            // button_MainMenu
            // 
            this.button_MainMenu.Location = new System.Drawing.Point(151, 242);
            this.button_MainMenu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_MainMenu.Name = "button_MainMenu";
            this.button_MainMenu.Size = new System.Drawing.Size(112, 50);
            this.button_MainMenu.TabIndex = 2;
            this.button_MainMenu.Text = "Main menu";
            this.button_MainMenu.UseVisualStyleBackColor = true;
            this.button_MainMenu.Click += new System.EventHandler(this.button_MainMenu_Click);
            // 
            // button_ExitGame
            // 
            this.button_ExitGame.Location = new System.Drawing.Point(304, 242);
            this.button_ExitGame.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_ExitGame.Name = "button_ExitGame";
            this.button_ExitGame.Size = new System.Drawing.Size(112, 50);
            this.button_ExitGame.TabIndex = 3;
            this.button_ExitGame.Text = "Exit game";
            this.button_ExitGame.UseVisualStyleBackColor = true;
            this.button_ExitGame.Click += new System.EventHandler(this.button_ExitGame_Click);
            // 
            // button_SubmitScore
            // 
            this.button_SubmitScore.Location = new System.Drawing.Point(304, 127);
            this.button_SubmitScore.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_SubmitScore.Name = "button_SubmitScore";
            this.button_SubmitScore.Size = new System.Drawing.Size(112, 50);
            this.button_SubmitScore.TabIndex = 4;
            this.button_SubmitScore.Text = "Submit score";
            this.button_SubmitScore.UseVisualStyleBackColor = true;
            this.button_SubmitScore.Click += new System.EventHandler(this.button_SubmitScore_Click);
            // 
            // textBox_SubmitScore
            // 
            this.textBox_SubmitScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F);
            this.textBox_SubmitScore.Location = new System.Drawing.Point(151, 127);
            this.textBox_SubmitScore.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_SubmitScore.Name = "textBox_SubmitScore";
            this.textBox_SubmitScore.Size = new System.Drawing.Size(111, 47);
            this.textBox_SubmitScore.TabIndex = 5;
            this.textBox_SubmitScore.TextChanged += new System.EventHandler(this.textBox_SubmitScore_TextChanged);
            // 
            // label_Score
            // 
            this.label_Score.AutoSize = true;
            this.label_Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label_Score.ForeColor = System.Drawing.Color.Black;
            this.label_Score.Location = new System.Drawing.Point(184, 82);
            this.label_Score.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Score.Name = "label_Score";
            this.label_Score.Size = new System.Drawing.Size(148, 29);
            this.label_Score.TabIndex = 6;
            this.label_Score.Text = "Your score: ";
            this.label_Score.Click += new System.EventHandler(this.label_Score_Click);
            // 
            // VictoryMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::KBS1.Properties.Resources.victory;
            this.Controls.Add(this.label_Score);
            this.Controls.Add(this.textBox_SubmitScore);
            this.Controls.Add(this.button_SubmitScore);
            this.Controls.Add(this.button_ExitGame);
            this.Controls.Add(this.button_MainMenu);
            this.Controls.Add(this.button_NextLevel);
            this.Controls.Add(this.button_RestartLevel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "VictoryMenu";
            this.Size = new System.Drawing.Size(600, 308);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_RestartLevel;
        private System.Windows.Forms.Button button_NextLevel;
        private System.Windows.Forms.Button button_MainMenu;
        private System.Windows.Forms.Button button_ExitGame;
        private System.Windows.Forms.Button button_SubmitScore;
        private System.Windows.Forms.TextBox textBox_SubmitScore;
        private System.Windows.Forms.Label label_Score;
    }
}
