using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KBS1.model;
using System.Drawing;

namespace KBS1.view
{
    public class StatisticPanel : Panel
    {
        private Label xLabel;
        private Label xLabelData;
        private Label yLabel;
        private Label yLabelData;
        private Label speedLabel;
        private Label speedLabelData;
        private Label descriptionLabel;
        private PictureBox objectPicture;
        public GameObject gameObject { get; }

        //Creates a Panel for each gameobject
        public StatisticPanel(GameObject gameObject)
        {
            this.gameObject = gameObject;
            //Label that shows: X 
            xLabel = new Label();
            xLabel.Text = "X = ";
            xLabel.Location = new Point(95, 11);
            xLabel.AutoSize = true;

            //Label that shows: X position
            xLabelData = new Label();
            xLabelData.Text = gameObject.pos_x.ToString();
            xLabelData.Location = new Point(118, 11);
            xLabelData.AutoSize = true;

            //Label that shows: Y 
            yLabel = new Label();
            yLabel.Text = "Y = ";
            yLabel.Location = new Point(95, 24);
            yLabel.AutoSize = true;

            //Label that shows: Y position
            yLabelData = new Label();
            yLabelData.Text = gameObject.pos_y.ToString();
            yLabelData.Location = new Point(118, 24);
            yLabelData.AutoSize = true;

            //Label that shows: Speed
            speedLabel = new Label();
            speedLabel.Text = "Speed = ";
            speedLabel.Location = new Point(95, 37);
            speedLabel.AutoSize = true;

            //Label that shows: speed of a gameobject
            speedLabelData = new Label();
            speedLabelData.Text = gameObject.speed_X.ToString();
            speedLabelData.Location = new Point(141, 37);
            speedLabelData.AutoSize = true;

            //Label that shows: description of a gameobject
            descriptionLabel = new Label();
            descriptionLabel.Text = gameObject.description;
            descriptionLabel.Location = new Point(16, 69);
            descriptionLabel.Size = new Size(200, 41);

            //Adds a Picture of the gameobject
            objectPicture = new PictureBox();

            if (gameObject is Player)
            {
                objectPicture.Image = Properties.Resources.playerEAST;
            }
            else if(gameObject is Enemy_Following)
            {
                objectPicture.Image = Properties.Resources.wolf_right;
            }
            else if (gameObject is Enemy_Static)
            {
                objectPicture.Image = Properties.Resources.wolf_right;
            }
            else
            {
                objectPicture.Image = gameObject.image;
            }

            objectPicture.Location = new Point(16, 11);
            objectPicture.Size = new Size(73, 54);
            objectPicture.SizeMode = PictureBoxSizeMode.StretchImage;

            //Add all labels to the panel
            Controls.Add(xLabel);
            Controls.Add(xLabelData);
            Controls.Add(yLabel);
            Controls.Add(yLabelData);
            Controls.Add(speedLabel);
            Controls.Add(speedLabelData);
            Controls.Add(descriptionLabel);
            Controls.Add(objectPicture);
        }

        //Updates the info for each panel in the StatisticsScreen
        public void updatePanel()
        {
            int speedbuff = gameObject.getSpeedBuffNumber();
            int playerspeed = gameObject.speed_X;
            xLabelData.Text = this.gameObject.pos_x.ToString();
            yLabelData.Text = this.gameObject.pos_y.ToString();
            speedLabelData.Text = (playerspeed + speedbuff).ToString();
        }
    }
}
