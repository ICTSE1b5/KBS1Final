using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KBS1.controller;
using KBS1.model;
using KBS1.view;
using System.Media;

namespace KBS1
{
    public partial class Form1 : Form
    {
        private GameLoop game_loop;
        private GameView game_view;
        private GameLevels game_levels;
        private SoundPlayer player;
        private bool mainOptions;
        public int currentlevel = 1;
        public WMPLib.WindowsMediaPlayer wmp = new WMPLib.WindowsMediaPlayerClass();
        public WMPLib.WindowsMediaPlayer GameOver = new WMPLib.WindowsMediaPlayerClass();
        public WMPLib.WindowsMediaPlayer LevelWon = new WMPLib.WindowsMediaPlayerClass();

        public Form1()
        {
            InitializeComponent();
            this.Text = "Wolf Escape";
            player = new System.Media.SoundPlayer();
            player.Stream = Properties.Resources.MainMenuMusic;

            //Event handler for buttons that have been pressed
            mainMenuScreen.MainMenuScreenClick += new EventHandler(MainMenu_ButtonHandler);
            levelSelectScreen.LevelSelectScreenClick += new EventHandler(LevelSelect_ButtonHandler);
            inGameMenu.InGameMenuScreenClick += new EventHandler(InGameMenu_ButtonHandler);
            optionsMenu.OptionsMenuClick += new EventHandler(OptionMenu_ButtonHandler);
            gameoverMenu.GameOverScreenClick += new EventHandler(GameOver_ButtonHandler);
            victoryMenu.VictoryMenuClick += new EventHandler(VictoryMenu_ButtonHandler);
            levelEditor.LevelEditorButtonClick += new EventHandler(LevelEditor_ButtonHandler);
            highScoresScreen.HighscoresScreenClick += new EventHandler(Highscores_ButtonHandler);
            levelSelectScreen.AddForm(this);
            

            this.SetStyle(
          ControlStyles.UserPaint |
          ControlStyles.AllPaintingInWmPaint |
          ControlStyles.OptimizedDoubleBuffer, true);
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //switch the direction of the player
            //switch statement
            try
            {
                game_loop.parser.player1.changeDirections(e.KeyCode, true);
                if (e.KeyCode == Keys.Escape)
                {
                    //if options menu is opened while in-game it will close by pressing escape
                    if (optionsMenu.Visible == true)
                    {
                        optionsMenu.Visible = false;
                        optionsMenu.Enabled = false;
                        inGameMenu.Visible = true;
                        inGameMenu.Enabled = true;
                    }
                    //pressing escape will close the in-game menu if it is already open
                    else if (game_loop.Get_Properties_Pause())
                    {
                        game_loop.Set_Properties_Pause(false);
                        inGameMenu.Visible = false;
                        inGameMenu.Enabled = false;
                    }
                    //pressing escape will open the in-game menu if it is not already open
                    else
                    {
                        game_loop.Set_Properties_Pause(true);
                        inGameMenu.Visible = true;
                        inGameMenu.Enabled = true;
                    }
                }
            }
            catch (NullReferenceException EX_DOWN)
            {
            }


        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //switch statement if key is released
            try
            {
                game_loop.parser.player1.changeDirections(e.KeyCode, false);
            }
            catch (NullReferenceException EX_UP)
            {
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game_loop = new GameLoop(this, GameLoop.FrameRate.SIXTY, statisticsScreen1);
            game_view = new GameView(this, game_loop);
            game_levels = new GameLevels(this);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics_GraphicDevice = e.Graphics;
            game_view.DrawGame(e.Graphics);
        }

        // the button handler for the main menu
        public void MainMenu_ButtonHandler(object sender, EventArgs e)
        {
            //Check what button is pressed.
            if (sender == mainMenuScreen.Get_Button_Select_Level())
            {
                mainMenuScreen.Visible = false;
                mainMenuScreen.Enabled = false;
                levelSelectScreen.Visible = true;
                levelSelectScreen.Enabled = true;
                levelSelectScreen.CreateDynamicButton();
            }
            else if (sender == mainMenuScreen.Get_Button_New_Game())
            {
                this.Text = "level" + currentlevel;
                this.Update();
                mainMenuScreen.Visible = false;
                mainMenuScreen.Enabled = false;
                StartGame("level" + currentlevel);
                
            }
            else if (sender == mainMenuScreen.Get_Button_Options())
            {
                optionsMenu.Visible = true;
                optionsMenu.Enabled = true;
                optionsMenu.BringToFront();
                mainOptions = true;
            }
            else if (sender == mainMenuScreen.Get_Button_Highscores())
            {
                highScoresScreen.Visible = true;
                highScoresScreen.Enabled = true;
                highScoresScreen.BringToFront();
            }
            else if (sender == mainMenuScreen.Get_Button_LevelEditor()) {
                this.levelEditor.SetItems(this.GetResources());
                this.levelEditor.Init();
                Width = 1040;
                mainMenuScreen.Visible = false;
                mainMenuScreen.Enabled = false;
                levelEditor.Visible = true;
                levelEditor.Enabled = true;
            }
            else if (sender == mainMenuScreen.Get_Button_Close())
            {
                CloseGame();
            }
        }

        // the button handler for the level select screen
        public void LevelSelect_ButtonHandler(object sender, EventArgs e)
        {
            if (sender == levelSelectScreen.Get_Button_Main_Click())
            {
                levelSelectScreen.Visible = false;
                levelSelectScreen.Enabled = false;
                mainMenuScreen.Visible = true;
                mainMenuScreen.Enabled = true;
            }
        }

        public void LevelEditor_ButtonHandler(object sender, EventArgs e) {
            if (sender == levelEditor.Get_Button_Cancel()) {
                Width = 800;
                levelEditor.Destruct();
                mainMenuScreen.Visible = true;
                mainMenuScreen.Enabled = true;
            } else if (sender == levelEditor.Get_Button_Save()) {
                Console.WriteLine("PRESSED SAVE");
                // DO SAVE ACTION
                XmlParser writer = new XmlParser();
                string savedname = writer.SaveLevel(levelEditor.GetAddedObjects());
                MessageBox.Show("Saved level as " + savedname);
            }
        }


        // the button handler for the game over screen
        public void GameOver_ButtonHandler(object sender, EventArgs e)
        {
            if (sender == gameoverMenu.Get_Button_selectLevel())
            {
                GameOver.controls.stop();
                gameoverMenu.Visible = false;
                gameoverMenu.Enabled = false;
                levelSelectScreen.Visible = true;
                levelSelectScreen.Enabled = true;
                levelSelectScreen.CreateDynamicButton();
            }
            else if (sender == gameoverMenu.Get_Button_MainMenu())
            {
                game_loop.Shutdown();
                GameOver.controls.stop();
                gameoverMenu.Visible = false;
                gameoverMenu.Enabled = false;
                statisticsScreen1.Visible = false;
                Width = 800;
                mainMenuScreen.Visible = true;
                mainMenuScreen.Enabled = true;

            }
            else if (sender == gameoverMenu.Get_Button_CloseGame())
            {
                CloseGame();
            }
            else if (sender == gameoverMenu.Get_Button_Restart())
            {
                GameOver.controls.stop();
                game_loop.Shutdown();
                gameoverMenu.Visible = false;
                gameoverMenu.Enabled = false;
                StartGame("level" + currentlevel);
            }
        }

        //method to show the gameOverMenu
        public void showGameOver()
        {
            game_loop.Set_Properties_Pause(true);
            gameoverMenu.Visible = true;
            gameoverMenu.Enabled = true;
        }

        //the button handler for the victory menu
        public void VictoryMenu_ButtonHandler(object sender, EventArgs e)
        {
            if(sender == victoryMenu.Get_Button_Exit_Game())
            {
                Close();
                LevelWon.controls.stop();
            }
            else if (sender == victoryMenu.Get_Button_Submit_Score())
            { 
            XmlParser xml_parser = new XmlParser();
            xml_parser.SubmitScore(victoryMenu.Get_Submit_Score_Name().Text, game_loop.Get_score() , currentlevel);
            }
            else if(sender == victoryMenu.Get_Button_Main_Menu())
            {
                game_loop.Shutdown();
                LevelWon.controls.stop();
                victoryMenu.Visible = false;
                victoryMenu.Enabled = false;
                statisticsScreen1.Visible = false;
                Width = 800;
                mainMenuScreen.Visible = true;
                mainMenuScreen.Enabled = true;
            }
            else if(sender == victoryMenu.Get_Button_Next_Level())
            {
                LevelWon.controls.stop();
                game_loop.Shutdown();
                victoryMenu.Visible = false;
                victoryMenu.Enabled = false;
                try
                {
                    currentlevel++;
                    this.Text = "level" + currentlevel;
                    this.Update();
                    StartGame("level" + currentlevel);
                }
                catch(FileNotFoundException x)
                {
                    currentlevel--;
                    this.Text = "level" + currentlevel;
                    this.Update();
                    StartGame("level" + currentlevel);
                } 
            }
            else if (sender == victoryMenu.Get_Button_Restart_Level())
            {
                LevelWon.controls.stop();
                game_loop.Shutdown();
                victoryMenu.Visible = false;
                victoryMenu.Enabled = false;
                StartGame("level" + currentlevel);
            }
        }

        //method to show the victory menu
        public void showVictoryMenu()
        {
            victoryMenu.Get_Your_Score().Text = "Your score: " + game_loop.Get_score();
            game_loop.Set_Properties_Pause(true);
            victoryMenu.Get_Submit_Score_Name().MaxLength = 3;
            victoryMenu.Visible = true;
            victoryMenu.Enabled = true;
        }
        
        //The button handler for the in game menu
        public void InGameMenu_ButtonHandler(object sender, EventArgs e)
        {
            if (sender == inGameMenu.Get_Button_Main_Menu())
            {
                game_loop.Shutdown();
                inGameMenu.Visible = false;
                inGameMenu.Enabled = false;
                statisticsScreen1.Visible = false;
                Width = 800;
                mainMenuScreen.Visible = true;
                mainMenuScreen.Enabled = true;
                
            }
            else if (sender == inGameMenu.Get_Button_Resume())
            {
                game_loop.Set_Properties_Pause(false);
                inGameMenu.Visible = false;
                inGameMenu.Enabled = false;
            }
            else if (sender == inGameMenu.Get_Button_Options())
            {
                inGameMenu.Visible = false;
                inGameMenu.Enabled = false;
                optionsMenu.Visible = true;
                optionsMenu.Enabled = true;
                mainOptions = false;
            }
            else if (sender == inGameMenu.Get_Button_Close())
            {
                CloseGame();
            }
        }

        //The button handler for the options menu
        public void OptionMenu_ButtonHandler(object sender, EventArgs e)
        {
            if (sender == optionsMenu.Get_CheckBox_Music())
            {
                playMusic();
            }
            else if (sender == optionsMenu.Get_Button_Return())
            {
                if (!mainOptions)
                {
                    inGameMenu.Visible = true;
                    inGameMenu.Enabled = true;
                }
                optionsMenu.Visible = false;
                optionsMenu.Enabled = false;
            }
            else if (sender == optionsMenu.Get_CheckBox_Statistics())
            {
                if (optionsMenu.Get_CheckBox_Statistics().Checked)
                {
                    if (!mainOptions)
                    {
                        statisticsScreen1.Visible = true;
                        statisticsScreen1.Enabled = true;
                        Width = 1040;
                        statisticsScreen1.DrawPanel(game_loop.GameEntities);
                        optionsMenu.Enabled = false;
                        optionsMenu.Enabled = true;
                    }
                }
                else
                {
                    statisticsScreen1.Visible = false;
                    Width = 800;
                    optionsMenu.Enabled = false;
                    optionsMenu.Enabled = true;
                }
            }
        }

        //The button handler for the highscores screen
        public void Highscores_ButtonHandler(object sender, EventArgs e)
        {
            if (sender == highScoresScreen.Get_Button_Return())
            {
                highScoresScreen.Visible = false;
                highScoresScreen.Enabled = false;
            }
        }

        private void playMusic()
        {
            if (optionsMenu.Get_CheckBox_Music().Checked)
            {
                string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
                wmp.URL = path + @"\SoundEffects\MainMenuMusic.wav";
                wmp.settings.setMode("loop", true);
                wmp.controls.play();
                optionsMenu.Enabled = false;
                optionsMenu.Enabled = true;
            }
            else
            {
                wmp.controls.stop();
                optionsMenu.Enabled = false;
                optionsMenu.Enabled = true;
            }
        }

        public void playSoundEffectDead()
        {
            if (optionsMenu.Get_CheckBox_Soundeffects().Checked)
            {
                string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
                GameOver.URL = path + @"\SoundEffects\wolfSoundeffect.wav";
                GameOver.controls.play();
            }
            else
            {

            }
        }

        public void playSoundEffectVictory()
        {
            if (optionsMenu.Get_CheckBox_Soundeffects().Checked)
            {
                string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
                LevelWon.URL = path + @"\SoundEffects\DoorSoundeffect.wav";
                LevelWon.controls.play();
            }
            else
            {

            }

        }

        public void StartGame(string level)
        {
            game_loop = new GameLoop(this, GameLoop.FrameRate.SIXTY, statisticsScreen1);
            game_view = new GameView(this, game_loop);
            game_levels = new GameLevels(this);

            if (optionsMenu.Get_CheckBox_Statistics().Checked)
            {
                statisticsScreen1.Visible = true;
                statisticsScreen1.Enabled = true;
                Width = 1040;
                //statisticsScreen1.DrawPanel(game_loop.GameEntities);
            }

            game_loop.Start(level);

        }

        public void QuitGameLoop()
        {
            try
            {
                game_loop.Shutdown();
            }
            catch(NullReferenceException EX_QGL)
            {

            }
        }

        public int getWidthOfGame()
        {
            return mainMenuScreen.Width;
        }
        public int getHeightOfGame()
        {
            return mainMenuScreen.Height;
        }

        private void CloseGame()
        {
            try
            {
                game_loop.Shutdown();
            }
            catch (NullReferenceException EX_CG)
            {

            }
            finally
            {
                Application.Exit();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseGame();
        }

        /// <summary>
        /// This method returns the name and image used in the level editor
        /// </summary>
        /// <returns>Dictionary</returns>
        public Dictionary<string, Image> GetResources() {
            Dictionary<string, Image> data = new Dictionary<string, Image>();
            data.Add("player", Properties.Resources.playerIDLE);
            data.Add("enemy", Properties.Resources.wolf_up);
            data.Add("finish", Properties.Resources.loghouse);
            data.Add("static", Properties.Resources.bush);
            data.Add("bolt", Properties.Resources.bolt);
            data.Add("logs", Properties.Resources.log);
            data.Add("water", Properties.Resources.pool);
            return data;
        } 
    }
}
