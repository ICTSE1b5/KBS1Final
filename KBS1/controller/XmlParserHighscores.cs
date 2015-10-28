using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace KBS1.controller
{
    internal class XmlParserHighscores
    {
        private XmlTextReader reader;
        private string path;
        public List<List<string>> data { get; }

        public XmlParserHighscores()
        {
            this.data = new List<List<string>>();
            path = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
        }

        //dumps the data from the level xml file specified above in a List<List<string>>
        public void Parse(string level)
        {
            //finding the directory of the XML file
            string file = @"\scores\" + level + ".xml";
            string directory = path + file;

            this.reader = new XmlTextReader(directory);

            // if the reader exists, start reading
            if (this.reader != null)
            {
                //reads the nodes in the xml file
                while (this.reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Score")
                    {
                        string score = reader.GetAttribute("score");
                        string name = reader.GetAttribute("name");
                        List<string> highscore = new List<string> { score, name };
                        this.data.Add(highscore);
                    }
                }
            }
        }
    }

}
