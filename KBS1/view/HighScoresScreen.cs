using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using KBS1.controller;
using System.Drawing;
using System.Linq;

namespace KBS1.view
{
    public partial class HighScoresScreen : UserControl
    {
        public event EventHandler HighscoresScreenClick;
        private XmlParserHighscores parser;
        private int ranking;
        private int y;

        public HighScoresScreen()
        {
            InitializeComponent();
            parser = new XmlParserHighscores();
            AddItemsToListBox();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadHighscores(listBoxLevel.SelectedItem.ToString());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        //Adds a listboxitem to the listbox for every file from the folder: scores, that has a xml extension
        public void AddItemsToListBox()
        {
            try
            {
                string path = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
                //Get file directory from levels folder
                String [] files = Directory.GetFiles(path + @"\scores\", "*.xml");
            
                // sort the levels ascending
                Array.Sort(files, (a, b) => int.Parse(Regex.Replace(a, "[^0-9]", "")) - int.Parse(Regex.Replace(b, "[^0-9]", "")));

                //For each level file create a listbox entry
                foreach (var filename in files)
                {
                    listBoxLevel.Items.Add(Path.GetFileNameWithoutExtension(filename));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong: " + e);
            }
        }


        //Uses the xmlparser to read data from a file and then puts that data in a panel using the AddHighscores mehtod
        public void LoadHighscores(string level)
        {
            panelHighscores.Controls.Clear();
            parser.data.Clear();

            parser.Parse(level);
            
            y = 0;
            ranking = 1;

            //Sorts the list with highscores descending
            var highscoresSorted =
                from h in parser.data
                orderby int.Parse(h[0]) descending
                select h;

            foreach (List<string> highscore in highscoresSorted)
            {
                if(ranking <= 15)
                AddHighscores(highscore);
            }
        }
        
        //Creates a panel for each highscore and its it to panelHighscores
        public void AddHighscores(List<string> highscore)
        {
            FlowLayoutPanel scorePanel = new FlowLayoutPanel();
            scorePanel.Location = new Point(0, y);
            scorePanel.Size = new Size(163, 13);
            scorePanel.AutoScroll = true;

            //Label that shows: the ranking of a player
            Label numberLabel = new Label();
            numberLabel.Text = ranking.ToString();
            numberLabel.AutoSize = true;

            //Label that shows: the name of the player
            Label nameLabel = new Label();
            nameLabel.Text = highscore[1];
            nameLabel.AutoSize = true;

            //Label that shows: the highscore of the player
            Label highscoreLabel = new Label();
            highscoreLabel.Text = highscore[0];
            highscoreLabel.AutoSize = true;

            scorePanel.Controls.Add(numberLabel);
            scorePanel.Controls.Add(nameLabel);
            scorePanel.Controls.Add(highscoreLabel);
            
            panelHighscores.Controls.Add(scorePanel);
            y += 15;
            ranking ++;
        }

        private void button_Return_Click(object sender, EventArgs e)
        {
            HighscoresScreenClick(sender, e);
        }

        public Button Get_Button_Return()
        {
            return button_Return;
        }
    }
}
