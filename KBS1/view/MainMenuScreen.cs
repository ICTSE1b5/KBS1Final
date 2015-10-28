using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBS1.view
{
    public partial class MainMenuScreen : UserControl
    {
        public event EventHandler MainMenuScreenClick;

        public MainMenuScreen()
        {
            InitializeComponent();
        }

        private void Button_Select_Level_Click(object sender, EventArgs e)
        {
            //Fires event to the EventHandler and then sends it to Form1
            MainMenuScreenClick(sender, e);
        }

        private void button_New_Game_Click(object sender, EventArgs e)
        {
            //Fires event to the EventHandler and then sends it to Form1
            MainMenuScreenClick(sender, e);
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            //Fires event to the EventHandler and then sends it to Form1
            MainMenuScreenClick(sender, e);
        }

        private void button_Options_Click(object sender, EventArgs e)
        {
            //Fires event to the EventHandler and then sends it to Form1
            MainMenuScreenClick(sender, e);
        }

        private void button_Highscores_Click(object sender, EventArgs e)
        {
            //Fires event to the EventHandler and then sends it to Form1
            MainMenuScreenClick(sender, e);
        }

        private void button_LevelEditor_Click(object sender, EventArgs e) {
            MainMenuScreenClick(sender, e);
        }

        public Button Get_Button_Select_Level()
        {
            return button_Select_Level;
        }

        public Button Get_Button_New_Game()
        {
            return button_New_Game;
        }

        public Button Get_Button_Close()
        {
            return button_Close;
        }

        public Button Get_Button_Options()
        {
            return button_Options;
        }

        public Button Get_Button_Highscores()
        {
            return button_Highscores;
        }

        public Button Get_Button_LevelEditor() {
            return button_Level_Editor;
        }

        
    }
}
