using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KBS1.model;
using KBS1.view;

namespace KBS1.controller
{
    class GameLoop
    {
        //Important Properties
        public Form1 game_Form;
        public GameController game_Controller;
        private List<GameObject> game_objects = new List<GameObject>();
        public XmlParser parser;
        private StatisticsScreen game_StatScreen;
        public int score = 5000;

        public enum FrameRate : int
        {
            SIXTY = 16,
            THIRTY = 33
        }

        //Game Loop Update Properties
        private bool properties_Gameover = false;
        private bool properties_Pause = false;
        private int properties_CurrentTime = 0;
        private int properties_StartTime = 0;

        //Frame Rate Properties
        private int properties_FrameUpdates = 1000; // Set in milliseconds to wait before updating the frame rate
        private int properties_FrameTimer = 0;
        private int properties_FrameCount = 0;
        private int properties_FrameRate = 0;
        private int properties_UpdateRate = 16; //60 FPS is the default


        public GameLoop(Form1 form, FrameRate updateRate, StatisticsScreen statScreen)
        {
            game_Form = form;
            game_Controller = new GameController(form, this);
            game_StatScreen = statScreen;

            SetUpdateRate(updateRate);
        }

        //Starts the game loop
        public void Start(string level)
        {
            Game_Init(level);
            game_StatScreen.DrawPanel(GameEntities);
            while (!properties_Gameover)
            {
                //Gets the current 'time'
                properties_CurrentTime = Environment.TickCount;

                //Every frame it updates, use the function SetUpdateRate to set the updateRate to 60FPS or 30FPS
                if (properties_CurrentTime > properties_StartTime + properties_UpdateRate)
                {
                    //Reset the 'timer'
                    properties_StartTime = properties_CurrentTime;

                    //Makes the application availible to listen to events, like the KeyDown event or Button_Click
                    Application.DoEvents();

                    //Updates the info like X and Y position on the statisticsScreen
                    game_StatScreen.UpdatePanel();
                    score--;

                    while (properties_Pause)
                    {
                        Application.DoEvents();
                    }
                    //Gives the command for the game to do its calculations, and move the objects
                    //And the Game Controller will also update the form
                    //Added if statement to check if the game is still running, if not, it will not update again.
                    if(!properties_Gameover)
                    {
                        game_Controller.Update(game_objects);
                    }
                }

                //Frame Rate Update
                properties_FrameCount++;
                if (properties_CurrentTime > properties_FrameTimer + properties_FrameUpdates)
                {
                    properties_FrameTimer = properties_CurrentTime;
                    properties_FrameRate = properties_FrameCount;
                    properties_FrameCount = 0;
                }
            }


            /*
            
                    TODO ANIMATION
                    -HERE-
            
            */

            Game_End();
        }

        public void Game_Init(string level)
        {
            //Initialize all components (ie. Player, Wall, Enemy,  etc.)
            properties_Gameover = false;
            properties_Pause = false;
            //Is replaced with information from the XML-file to make the enemies (loop)
            /*Right now this is a hardcoded placement*/

            game_objects = new List<GameObject>();
            // makes an XMLparser
            parser = new XmlParser();
            parser.Handle(game_objects, game_Form, level);

            //Add borders to the game
            int game_Width = game_Form.getWidthOfGame();
            int game_Height = game_Form.getHeightOfGame();
            game_objects.Add(new Border(0, 0, game_Width, 0, game_Form)); //Top
            game_objects.Add(new Border(0, game_Height, game_Width, 0, game_Form)); //Bottom
            game_objects.Add(new Border(0, 0, 0, game_Height, game_Form)); //Left
            game_objects.Add(new Border(game_Width, 0, 0, game_Height, game_Form)); //Right

            game_objects.Reverse();
        }

        private void Game_End()
        {
            //Remove all existing components (ie. Objects, GameController, etc.)
            game_objects = new List<GameObject>();
        }

        public void Shutdown()
        {
            properties_Pause = false;
            properties_Gameover = true;
        }

        public void SetUpdateRate(FrameRate update)
        {
            properties_UpdateRate = (int)update;
        }


        public List<GameObject> GameEntities
        {
            get { return game_objects; }
        }

        public void Set_Properties_Pause(bool boolean)
        {
            properties_Pause = boolean;
        }

        public bool Get_Properties_Pause()
        {
            return properties_Pause;
        }
        public String Get_score()
        {
            return ""+score;
        }
    }
}
