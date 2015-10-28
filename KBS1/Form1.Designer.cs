using System.Drawing;
using System.Windows.Forms;

namespace KBS1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.highScoresScreen = new KBS1.view.HighScoresScreen();
            this.statisticsScreen1 = new KBS1.view.StatisticsScreen();
            this.mainMenuScreen = new KBS1.view.MainMenuScreen();
            this.levelSelectScreen = new KBS1.view.LevelSelectScreen();
            this.inGameMenu = new KBS1.view.InGameMenu();
            this.optionsMenu = new KBS1.view.OptionsMenu();
            this.gameoverMenu = new KBS1.view.gameOver();
            this.victoryMenu = new KBS1.view.VictoryMenu();
            this.levelEditor = new KBS1.view.LevelEditor();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // highScoresScreen
            // 
            this.highScoresScreen.Location = new System.Drawing.Point(280, 144);
            this.highScoresScreen.Name = "highScoresScreen";
            this.highScoresScreen.Size = new System.Drawing.Size(255, 253);
            this.highScoresScreen.TabIndex = 6;
            this.highScoresScreen.Visible = false;
            // 
            // statisticsScreen1
            // 
            this.statisticsScreen1.AutoScroll = true;
            this.statisticsScreen1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.statisticsScreen1.Enabled = false;
            this.statisticsScreen1.Location = new System.Drawing.Point(784, 0);
            this.statisticsScreen1.Margin = new System.Windows.Forms.Padding(4);
            this.statisticsScreen1.Name = "statisticsScreen1";
            this.statisticsScreen1.Size = new System.Drawing.Size(240, 561);
            this.statisticsScreen1.TabIndex = 4;
            this.statisticsScreen1.Visible = false;
            // 
            // mainMenuScreen
            // 
            this.mainMenuScreen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mainMenuScreen.BackgroundImage")));
            this.mainMenuScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainMenuScreen.Location = new System.Drawing.Point(0, 0);
            this.mainMenuScreen.Margin = new System.Windows.Forms.Padding(4);
            this.mainMenuScreen.Name = "mainMenuScreen";
            this.mainMenuScreen.Size = new System.Drawing.Size(784, 561);
            this.mainMenuScreen.TabIndex = 0;
            // 
            // levelSelectScreen
            // 
            this.levelSelectScreen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("levelSelectScreen.BackgroundImage")));
            this.levelSelectScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.levelSelectScreen.Location = new System.Drawing.Point(0, 0);
            this.levelSelectScreen.Margin = new System.Windows.Forms.Padding(4);
            this.levelSelectScreen.Name = "levelSelectScreen";
            this.levelSelectScreen.Size = new System.Drawing.Size(784, 561);
            this.levelSelectScreen.TabIndex = 1;
            this.levelSelectScreen.Visible = false;
            // 
            // inGameMenu
            // 
            this.inGameMenu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.inGameMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inGameMenu.Location = new System.Drawing.Point(289, 144);
            this.inGameMenu.Margin = new System.Windows.Forms.Padding(4);
            this.inGameMenu.Name = "inGameMenu";
            this.inGameMenu.Size = new System.Drawing.Size(199, 250);
            this.inGameMenu.TabIndex = 2;
            this.inGameMenu.Visible = false;
            // 
            // optionsMenu
            // 
            this.optionsMenu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.optionsMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.optionsMenu.Location = new System.Drawing.Point(195, 144);
            this.optionsMenu.Margin = new System.Windows.Forms.Padding(4);
            this.optionsMenu.Name = "optionsMenu";
            this.optionsMenu.Size = new System.Drawing.Size(440, 231);
            this.optionsMenu.TabIndex = 3;
            this.optionsMenu.Visible = false;
            // 
            // gameoverMenu
            // 
            this.gameoverMenu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gameoverMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gameoverMenu.BackgroundImage")));
            this.gameoverMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gameoverMenu.Location = new System.Drawing.Point(195, 144);
            this.gameoverMenu.Margin = new System.Windows.Forms.Padding(2);
            this.gameoverMenu.Name = "gameoverMenu";
            this.gameoverMenu.Size = new System.Drawing.Size(450, 250);
            this.gameoverMenu.TabIndex = 5;
            this.gameoverMenu.Visible = false;
            // 
            // victoryMenu
            // 
            this.victoryMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("victoryMenu.BackgroundImage")));
            this.victoryMenu.Location = new System.Drawing.Point(195, 144);
            this.victoryMenu.Name = "victoryMenu";
            this.victoryMenu.Size = new System.Drawing.Size(450, 250);
            this.victoryMenu.TabIndex = 6;
            this.victoryMenu.Visible = false;
            // 
            // levelEditor
            // 
            this.levelEditor.Location = new System.Drawing.Point(0, 0);
            this.levelEditor.Name = "levelEditor";
            this.levelEditor.Size = new System.Drawing.Size(1040, 561);
            this.levelEditor.TabIndex = 7;
            this.levelEditor.Visible = false;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(46, 25);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(65, 23);
            this.axWindowsMediaPlayer1.TabIndex = 8;
            this.axWindowsMediaPlayer1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::KBS1.Properties.Resources.Gamebackground;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.highScoresScreen);
            this.Controls.Add(this.victoryMenu);
            this.Controls.Add(this.statisticsScreen1);
            this.Controls.Add(this.mainMenuScreen);
            this.Controls.Add(this.levelSelectScreen);
            this.Controls.Add(this.inGameMenu);
            this.Controls.Add(this.optionsMenu);
            this.Controls.Add(this.gameoverMenu);
            this.Controls.Add(this.levelEditor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private view.MainMenuScreen mainMenuScreen;
        private view.LevelSelectScreen levelSelectScreen;
        private view.InGameMenu inGameMenu;
        private view.OptionsMenu optionsMenu;
        private view.StatisticsScreen statisticsScreen1;
        private view.gameOver gameoverMenu;
        private view.HighScoresScreen highScoresScreen;
        private view.VictoryMenu victoryMenu;
        private view.LevelEditor levelEditor;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}

