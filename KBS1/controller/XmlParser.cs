using KBS1.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace KBS1.controller
{
    public class XmlParser
    {
        private XmlTextReader reader;
        private string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        private string directory;
        public List<List<string>> data { get; }
        public Player player1;
        public Finish finish1;

        public XmlParser()
        {
            this.data = new List<List<string>>();
            this.directory = path + @"\levels\";
        }
        //dumps the data from the level xml file specified above in a List<List<string>>
        public void Parse(string name)
        {
            //finding the directory of the XML file
            string file = @"\levels\" + name + ".xml";
            string directory = path + file;

            this.reader = new XmlTextReader(directory);

            // if the reader exists, start reading
            if (this.reader != null)
            {
                //reads the nodes in the xml file
                while (this.reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        //if the nodetype is an element, read the name of the element, and add the data in the XML-attributes to the List<List<string>>
                        case XmlNodeType.Element:
                            if(reader.Name!= "level" && reader.Name == "player")
                            {
                                string hp = reader.GetAttribute("hp");
                                string speed = reader.GetAttribute("speed");
                                string x = reader.GetAttribute("x");
                                string y = reader.GetAttribute("y");
                                string width = reader.GetAttribute("width");
                                string height = reader.GetAttribute("height");
                                List<string> temp = new List<string> { reader.Name, hp, speed, x, y, width, height };
                                this.data.Add(temp);
                            }

                            if (reader.Name != "level" && reader.Name == "finish")
                            {
                                string x = reader.GetAttribute("x");
                                string y = reader.GetAttribute("y");
                                string width = reader.GetAttribute("width");
                                string height = reader.GetAttribute("height");
                                List<string> temp = new List<string> { reader.Name, x, y, width, height };
                                this.data.Add(temp);
                            }

                            if (reader.Name != "level" && reader.Name == "enemy")
                            {
                                string hp = reader.GetAttribute("hp");
                                string speed = reader.GetAttribute("speed");
                                string x = reader.GetAttribute("x");
                                string y = reader.GetAttribute("y");
                                string width = reader.GetAttribute("width");
                                string height = reader.GetAttribute("height");
                                List<string> temp = new List<string> { reader.Name, hp, speed, x, y, width, height };
                                this.data.Add(temp);
                            }

                            if (reader.Name != "level" && reader.Name == "bolt")
                            {
                                string hp = reader.GetAttribute("hp");
                                string speed = reader.GetAttribute("speed");
                                string x = reader.GetAttribute("x");
                                string y = reader.GetAttribute("y");
                                string range = reader.GetAttribute("range");
                                string width = reader.GetAttribute("width");
                                string height = reader.GetAttribute("height");
                                List<string> temp = new List<string> { reader.Name, hp, speed, x, y, range, width, height };
                                this.data.Add(temp);
                            }

                            if (reader.Name != "level" && reader.Name == "water")
                            {
                                string hp = reader.GetAttribute("hp");
                                string speed = reader.GetAttribute("speed");
                                string x = reader.GetAttribute("x");
                                string y = reader.GetAttribute("y");
                                string range = reader.GetAttribute("range");
                                string width = reader.GetAttribute("width");
                                string height = reader.GetAttribute("height");
                                List<string> temp = new List<string> { reader.Name, hp, speed, x, y, range, width, height };
                                this.data.Add(temp);
                            }

                            if (reader.Name != "level" && reader.Name == "logs")
                            {
                                string hp = reader.GetAttribute("hp");
                                string speed = reader.GetAttribute("speed");
                                string x = reader.GetAttribute("x");
                                string y = reader.GetAttribute("y");
                                string range = reader.GetAttribute("range");
                                string width = reader.GetAttribute("width");
                                string height = reader.GetAttribute("height");
                                List<string> temp = new List<string> { reader.Name, hp, speed, x, y, range, width, height };
                                this.data.Add(temp);
                            }

                            if (reader.Name != "level" && reader.Name == "static")
                            {
                                string x = reader.GetAttribute("x");
                                string y = reader.GetAttribute("y");
                                string width = reader.GetAttribute("width");
                                string height = reader.GetAttribute("height");
                                List<string> temp = new List<string> { reader.Name, x, y, width, height };
                                this.data.Add(temp);
                            }
                            break;
                    }
                }
            }
        }

        public void Handle(List<GameObject> game_objects, Form1 game_Form,string levelslug)
        {
            // gets an XML file from a specific directory
            this.Parse(levelslug);
            // parser fills the variable list data

            // for each item in var data
            foreach (List<string> item in data)
            {
                if (item[0] == "player")
                {
                    //create new object
                    player1 = new Player(Int32.Parse(item[1]), Int32.Parse(item[2]), Int32.Parse(item[3]), Int32.Parse(item[4]), Int32.Parse(item[5]), Int32.Parse(item[6]), game_Form);
                    //Adds object to the list
                    game_objects.Add(player1);
                }
                if (item[0] == "finish")
                {
                    //create new object
                    finish1 = new Finish(Int32.Parse(item[1]), Int32.Parse(item[2]), Int32.Parse(item[3]), Int32.Parse(item[4]), game_Form);
                    //Adds object to the list
                    game_objects.Add(finish1);
                }
                if (item[0] == "enemy")
                {
                    //create new object
                    Enemy_Following enemy = new Enemy_Following(Int32.Parse(item[3]), Int32.Parse(item[4]), Int32.Parse(item[2]), game_objects, game_Form);
                    //Adds object to the list
                    game_objects.Add(enemy);
                }
                if (item[0] == "bolt")
                {
                    //create new object
                    Bolt bolt = new Bolt(Int32.Parse(item[3]), Int32.Parse(item[4]), game_objects, game_Form);
                    //Adds object to the list
                    game_objects.Add(bolt);
                }
                if (item[0] == "water")
                {
                    //create new object
                    Puddle water = new Puddle(Int32.Parse(item[3]), Int32.Parse(item[4]), game_objects, game_Form);
                    //Adds object to the list
                    game_objects.Add(water);
                }
                if (item[0] == "logs")
                {
                    //create new object
                    Pile_of_Logs logs = new Pile_of_Logs(Int32.Parse(item[3]), Int32.Parse(item[4]), game_objects, game_Form);
                    //Adds object to the list
                    game_objects.Add(logs);
                }
                if (item[0] == "static")
                {
                    //create new object
                    Wall wall = new Wall(Int32.Parse(item[1]), Int32.Parse(item[2]), game_Form);
                    //Adds object to the list
                    game_objects.Add(wall);
                }

            }
        }

        public string SaveLevel( Dictionary<int, Tuple<string, Dictionary<string, int>>> levelData ) {
            if( !Directory.Exists(this.directory) )
                Directory.CreateDirectory(this.directory);
            string filename = this.GetNextLevelName() + ".xml";
            string finalPath = this.directory + filename;
            if( !File.Exists(finalPath) ) {
                XmlTextWriter writer = new XmlTextWriter(finalPath, System.Text.Encoding.UTF8);
                writer.WriteStartDocument();
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;
                writer.WriteStartElement("level");
                foreach (KeyValuePair<int, Tuple<string, Dictionary<string, int>>> pair in levelData) {
                    this.Write(writer, pair.Value.Item1, pair.Value.Item2);
                }
                writer.WriteEndDocument();
                writer.Close();
                return filename;
            }
            return "ERROR!";
        }

        
        public string GetPath() {
            return this.path;
        }

        private void Write( XmlTextWriter writer, string name, Dictionary<string, int> objectData ) {
            writer.WriteStartElement(name);
            if(name == "player" || name == "enemy")
                writer.WriteAttributeString("hp", "1");
            else if (name == "bolt" || name == "water" || name == "logs")
                writer.WriteAttributeString("hp", "10");
            foreach( KeyValuePair<string, int> pair in objectData ) {
                writer.WriteAttributeString(pair.Key, pair.Value.ToString());
            }
            if (name == "player" || name == "finish" || name == "static") {
                writer.WriteAttributeString("width", "50");
                writer.WriteAttributeString("height", "50");
            } else if (name == "enemy") {
                writer.WriteAttributeString("width", "3");
                writer.WriteAttributeString("height", "9");
            } else if (name == "water" || name == "bolt") {
                writer.WriteAttributeString("range", "50");
                writer.WriteAttributeString("width", "20");
                writer.WriteAttributeString("height", "20");
            } else if (name == "logs") {
                writer.WriteAttributeString("range", "100");
                writer.WriteAttributeString("width", "20");
                writer.WriteAttributeString("height", "20");
            }
            writer.WriteEndElement();
        }

        private string GetNextLevelName() {
            int amount = Directory.GetFiles(this.directory).Length;
            return "level" + ( amount + 1 );
        }

        public void SubmitScore(string name, string score, int currentLevel)
        {
            //file location
            string file = @"\scores\level" + currentLevel + ".xml";
            string ScoreRegistry = path + file;

            if (File.Exists(ScoreRegistry))
            {
                var xDoc = XElement.Load(ScoreRegistry);
                //write the score into an existing xml file
                var myNewElement = new XElement("Score",
                   new XAttribute("name", name),
                   new XAttribute("score", score)
                );
                xDoc.Add(myNewElement);
                xDoc.Save(ScoreRegistry);
                MessageBox.Show("Uw score is toegevoegd. pad: " + ScoreRegistry);

            }
            else if (!File.Exists(ScoreRegistry))
            {
                // write the XML file and add a new score
                XmlTextWriter writer = new XmlTextWriter(ScoreRegistry, System.Text.Encoding.UTF8);
                writer.WriteStartDocument(true);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartElement("highscore");
                writer.Indentation = 2;
                writer.WriteStartElement("Score");
                writer.WriteAttributeString("name", name);
                writer.WriteAttributeString("score", score);
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
                MessageBox.Show("Uw score is geregistreerd. pad: " + ScoreRegistry);
            }
        }

    }
}
