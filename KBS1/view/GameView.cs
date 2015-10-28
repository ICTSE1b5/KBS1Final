using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing.Design;
using System.Drawing.Text;
using System.Windows.Forms;
using KBS1.controller;
using KBS1.model;

namespace KBS1.view
{
    class GameView
    {
        Form game_Form;
        GameLoop game_loop;

        public bool showHitBox = false;

        public GameView(Form form, GameLoop loop)
        {
            game_Form = form;
            game_loop = loop;
        }


        public void DrawGame(Graphics graphics_GraphicsDevice)
        //public void DrawGame(ref Graphics graphics_GraphicsDevice)
        {
            //LINQ statement to select the player
            var getPlayerStatement =
                from play in game_loop.GameEntities
                where play.Type == GameObject.ObjectType.PLAYER
                select play;

            //LINQ statement to select the Effect Givers to get their AOE
            var getEffectGiversStatement =
                from effect in game_loop.GameEntities
                where effect.Type == GameObject.ObjectType.EFFECT
                select effect;

            //go through each object currently alive and draw them
            game_loop.GameEntities.ForEach(obj1 => graphics_GraphicsDevice.DrawImage(obj1.getObjectImage(), obj1.ObjectRectangle));

            //Draw the hitboxes if requested
            if(showHitBox)
            { 
                //AOE Hitbox
                foreach(EffectGiver obj2 in getEffectGiversStatement)
                {
                    graphics_GraphicsDevice.DrawRectangle(new Pen(Brushes.Red), obj2.EffectSquare);
                }

                //Collision Hitbox
                game_loop.GameEntities.ForEach(obj3 => graphics_GraphicsDevice.DrawRectangle(new Pen(Brushes.Black), obj3.ObjectRectangle));
            }
            
            //Draw the player object ALWAYS above all other object
            foreach(GameObject obj4 in getPlayerStatement)
            {
                graphics_GraphicsDevice.DrawImage(obj4.getObjectImage(), obj4.ObjectRectangle);
            }

        }



    }
}
