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
    public partial class OptionsMenu : UserControl
    {
        public event EventHandler OptionsMenuClick;

        public OptionsMenu()
        {
            InitializeComponent();
        }

        private void CheckBox_Statistics_CheckedChanged(object sender, EventArgs e)
        {
            //Fires event to the EventHandler and then sends it to Form1
            OptionsMenuClick(sender, e);
        }

        private void CheckBox_Music_CheckedChanged(object sender, EventArgs e)
        {
            //Fires event to the EventHandler and then sends it to Form1
            OptionsMenuClick(sender, e);
        }

        private void soundeffects_CheckedChanged(object sender, EventArgs e)
        {
            //Fires event to the EventHandler and then sends it to Form1
            OptionsMenuClick(sender, e);
        }

        private void button_Return_Click(object sender, EventArgs e)
        {
            //Fires event to the EventHandler and then sends it to Form1
            OptionsMenuClick(sender, e);
        }

        public CheckBox Get_CheckBox_Statistics()
        {
            return checkBox_Statistics;
        }

        public CheckBox Get_CheckBox_Music()
        {
            return checkBox_Music;
        }

        public Button Get_Button_Return()
        {
            return button_Return;
        }

        public CheckBox Get_CheckBox_Soundeffects()
        {
            return soundeffects;
        }

        public void Set_CheckBox_Music(bool boolean)
        {
            checkBox_Music.Checked = boolean;
        }

        public void Set_CheckBox_Soundeffects(bool boolean)
        {
            soundeffects.Checked = boolean;
        }
    }
}
