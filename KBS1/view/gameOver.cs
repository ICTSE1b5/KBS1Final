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
    public partial class gameOver : UserControl
    {
        public event EventHandler GameOverScreenClick;
        public gameOver()
        {
            InitializeComponent();
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            GameOverScreenClick(sender, e);
        }

        private void selectLevel_Click(object sender, EventArgs e)
        {
            GameOverScreenClick(sender, e);
        }

        private void MainMenu_Click(object sender, EventArgs e)
        {
            GameOverScreenClick(sender, e);
        }

        private void CloseGame_Click(object sender, EventArgs e)
        {
            GameOverScreenClick(sender, e);
        }

        public Button Get_Button_MainMenu()
        {
            return MainMenu;
        }

        public Button Get_Button_CloseGame()
        {
            return CloseGame;
        }
        public Button Get_Button_selectLevel()
        {
            return selectLevel;
        }
        public Button Get_Button_Restart()
        {
            return Restart;
        }

    }
}
