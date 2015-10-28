using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using KBS1.model;

namespace KBS1.view
{
    public partial class StatisticsScreen : UserControl
    {
        private List<StatisticPanel> panelList;

        public StatisticsScreen()
        {
            panelList = new List<StatisticPanel>();
            InitializeComponent();
            SetStyle(ControlStyles.Selectable, false);
            AutoScroll = true;
        }

        //Loops through all gameobjects and creates a panel for each object
        public void DrawPanel(List<GameObject> gameobjects)
        {
            //Clears the controls so when a new level is started this list is clean
            Controls.Clear();
            int x = 0;

            //Distinct select on gameobjects, so only one of each object will be shown
            var distinctGameOjbect = gameobjects
                .GroupBy(p => p.Type)
                .Select(g => g.First())
                .ToList();

            foreach (GameObject item in distinctGameOjbect)
            {
                StatisticPanel panel = new StatisticPanel(item);
                panel.Location = new Point(0, x);
                panel.Size = new Size(220, 100);

                if (!(item is Border))
                {
                    panelList.Add(panel);
                    Controls.Add(panel);
                    //Adds 100 to the X position of the Panel
                    x += 100;
                }
            }
        }

        //Loops through all gameobjects and updates each panel for each corresponding object
        public void UpdatePanel()
        {
            foreach (StatisticPanel panel in panelList)
            {
                panel.updatePanel();
            }
        }
    }
}
