
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace KBS1
{
    class GameLevels
    {
        private Form1 form1;
        private string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));

        public GameLevels(Form1 form)
        {
            this.form1 = form;
        }

        public List<string> ShowLevels(){
            List<string> lijst = new List<string>();

            //get files from directory with filetype XML
            string[] files = Directory.GetFiles(path+@"\levels\", "*.xml");
            // returns:
            // "\project\levels\level1.xml"
            // "\project\levels\level2.xml"

            foreach(string file in files)
            {
                // do something for each file
                lijst.Add(file);
                MessageBox.Show(file);
            }
            return lijst;
        }

        public void SaveLevel(string name)
        {
            string file = @"\levels\" + name + ".xml";
            string savefile = path + file;

            // write the XML file
            XmlTextWriter writer = new XmlTextWriter(savefile, System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("level");
            writeFinish(500, 500, writer);
            writePlayer(100, 1000, 200,0,0, writer);
            writer.WriteStartElement("elements");
            writeEnemy("1","Following", 300, 150, 500, 100, writer);
            writeEnemy("2","Static", 200, 200, 500, 100, writer);
            writeWall("1", 50, 50, writer);
            writeWall("2", 100, 100, writer);
            writeWall("3", 150, 150, writer);
            writeWall("4", 200, 200, writer);
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();

            writer.Close();
            MessageBox.Show("Gefeliciteerd, uw eigen level is aangemaakt! pad: " + savefile);

        }

        public void LoadLevel(string name)
        {
            
            MessageBox.Show("Gefeliciteerd, uw eigen level is geladen ! pad: ");
            
            
        }

        private void writePlayer(int speed, int health, int damage,int posX,int posY, XmlTextWriter writer)
        {
            // In plaats van Elementen kunnen er beter attributen aangemaakt worden,
            // zodat de xml reader gebruik kan maken van XmlReader.GetAttribute(Attributename)
            // Hoe dit werkt is te vinden op : https://msdn.microsoft.com/en-us/library/97dce9e6%28v=vs.80%29.aspx
            // Robin
            writer.WriteStartElement("player");
            writer.WriteStartElement("Xposition");
            writer.WriteValue(posX);
            writer.WriteEndElement();
            writer.WriteStartElement("Yposition");
            writer.WriteValue(posY);
            writer.WriteEndElement();
            writer.WriteStartElement("speed");
            writer.WriteValue(speed);
            writer.WriteEndElement();
            writer.WriteStartElement("health");
            writer.WriteValue(health);
            writer.WriteEndElement();
            writer.WriteStartElement("damage");
            writer.WriteValue(damage);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        private void writeFinish(int posX, int posY, XmlTextWriter writer)
        {
            writer.WriteStartElement("finish");
            writer.WriteStartElement("Xposition");
            writer.WriteValue(posX);
            writer.WriteEndElement();
            writer.WriteStartElement("Yposition");
            writer.WriteValue(posY);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        private void writeWall(string pID, int posX, int posY, XmlTextWriter writer)
        {
            writer.WriteStartElement("wall");
            writer.WriteStartElement("wall_id");
            writer.WriteString(pID);
            writer.WriteEndElement();
            writer.WriteStartElement("Xposition");
            writer.WriteValue(posX);
            writer.WriteEndElement();
            writer.WriteStartElement("Yposition");
            writer.WriteValue(posY);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        private void writeEnemy(string pID, string type, int posX, int posY, int health, int damage, XmlTextWriter writer)
        {
            writer.WriteStartElement("enemy");
            writer.WriteStartElement("enemy_id");
            writer.WriteString(pID);
            writer.WriteEndElement();
            writer.WriteStartElement("type");
            writer.WriteValue(posX);
            writer.WriteEndElement();
            writer.WriteStartElement("Xposition");
            writer.WriteValue(posX);
            writer.WriteEndElement();
            writer.WriteStartElement("Yposition");
            writer.WriteValue(posY);
            writer.WriteEndElement();
            writer.WriteStartElement("health");
            writer.WriteValue(health);
            writer.WriteEndElement();
            writer.WriteStartElement("damage");
            writer.WriteValue(health);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}



