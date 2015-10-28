using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using KBS1.controller;
using System.Text.RegularExpressions;

namespace KBS1.view
{
    public partial class LevelSelectScreen : UserControl
    {
        public List<Button> listOfButtons = new List<Button>();
        private string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        

        public event EventHandler LevelSelectScreenClick;
        public Form1 form;

        public LevelSelectScreen()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            LevelSelectScreenClick(sender, e);
        }

        private void Button_Main_Menu_Click(object sender, EventArgs e)
        {
            //Fires event to the EventHandler and then sends it to Form1
            LevelSelectScreenClick(sender, e);
        }

        public Button Get_Button_Main_Click()
        {
            return button_Main_Menu;
        }


        public void CreateDynamicButton()
        {
            // get file directory from levels
            string[] files = Directory.GetFiles(path + @"\levels\", "*.xml");
            // sort the levels ascending
            Array.Sort(files, (a, b) => int.Parse(Regex.Replace(a, "[^0-9]", "")) - int.Parse(Regex.Replace(b, "[^0-9]", "")));

            int xPos = 25;
            int yPos = 25;

            this.panel1.AutoScroll = true;

            // for each file in the directory, create a button with the name of the file
            for (int i2 = 1; i2 <= files.Length; i2++)
            {
                string path2 = files[i2-1];
                // get the file name
                String result = Path.GetFileNameWithoutExtension(path2);
                Button btn = new Button();
                btn.Name = "btn1";
                // text from the button is the file name
                btn.Text = result;
                //add event handler
                btn.Click += new EventHandler(DynamicButton_Click);
                // add the button to the form
                this.panel1.Controls.Add(btn);


                // give the button location
                 btn.Location = new Point(xPos, yPos);
                // location of next button to the left
                xPos += 80; // add 80 per button


                int eachFive = 5;
                // if the 5th button is added, new row
                if (i2 %eachFive == 0)
                {
                    xPos = 25;
                    yPos +=30;
                    eachFive += 5;
                }
            }



        }


        private void DynamicButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string XMLfile = path + @"\levels\" + button.Text + "*.xml";
            form.currentlevel = int.Parse(button.Text.Trim(new Char[] { 'l', 'e', 'v' }));

            this.Visible = false;
            this.Enabled = false;
            form.Text = "level" + form.currentlevel;
            form.Update();
            form.StartGame(button.Text);
            
        }

        public void AddForm(Form1 form)
        {
            this.form = form;
        }


    }
}


