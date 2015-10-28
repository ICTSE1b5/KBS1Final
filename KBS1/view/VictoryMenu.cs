using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace KBS1.view
{
    public partial class VictoryMenu : UserControl
    {
        public event EventHandler VictoryMenuClick;
        public VictoryMenu()
        {
            InitializeComponent();
        }

        private void button_RestartLevel_Click(object sender, EventArgs e)
        {
            this.button_SubmitScore.Enabled = true;
            VictoryMenuClick(sender, e);
        }

        private void button_NextLevel_Click(object sender, EventArgs e)
        {
            this.button_SubmitScore.Enabled = true;
            VictoryMenuClick(sender, e);
        }

        private void button_MainMenu_Click(object sender, EventArgs e)
        {
            this.button_SubmitScore.Enabled = true;
            VictoryMenuClick(sender, e);
        }

        private void button_ExitGame_Click(object sender, EventArgs e)
        {
            this.button_SubmitScore.Enabled = true;
            VictoryMenuClick(sender, e);
        }

        private void button_SubmitScore_Click(object sender, EventArgs e)
        {
            this.button_SubmitScore.Enabled = false;
            VictoryMenuClick(sender, e);
        }

        private void textBox_SubmitScore_TextChanged(object sender, EventArgs e)
        {
            VictoryMenuClick(sender, e);
        }

        private void label_Score_Click(object sender, EventArgs e)
        {

        }

        public Button Get_Button_Restart_Level()
        {
            return button_RestartLevel;
        }

        public Button Get_Button_Next_Level()
        {
            return button_NextLevel;
        }

        public Button Get_Button_Main_Menu()
        {
            return button_MainMenu;
        }

        public Button Get_Button_Exit_Game()
        {
            return button_ExitGame;
        }

        public Button Get_Button_Submit_Score()
        {
            return button_SubmitScore;
        }

        public TextBox Get_Submit_Score_Name()
        {
            return textBox_SubmitScore;
        }

        public Label Get_Your_Score()
        {
            return label_Score;
        }
    }
}
