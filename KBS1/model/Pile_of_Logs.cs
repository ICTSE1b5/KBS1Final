using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS1.model
{
    class Pile_of_Logs : EffectGiver
    {
        public Pile_of_Logs(int pos_x, int pos_y, List<GameObject> props, Form1 form)
            : base(pos_x, pos_y, 50, 50, 0, 0, 0, 999, 10, props, form)
        {
            this.image = Properties.Resources.log;
            this.description = "This pile of logs will cause you to slow down.";

            isSolid = false;
        }
        protected override void setupImages()
        {
            imageNorthWest = Properties.Resources.log;
            imageNorth = Properties.Resources.log;
            imageNorthEast = Properties.Resources.log;

            imageWest = Properties.Resources.log;
            imageIdle = Properties.Resources.log;
            imageEast = Properties.Resources.log;

            imageSouthWest = Properties.Resources.log;
            imageSouth = Properties.Resources.log;
            imageSouthEast = Properties.Resources.log;
        }


        protected override void AI()
        {
            foreach (GameObject ob in allObjects)
            {
                if(ob.ObjectRectangle.IntersectsWith(RectangleOfEffect) && (ob.Type == ObjectType.PLAYER))
                {
                    ob.giveSpeedEffect(SpeedEffects.SLOW_1);
                }
            }
        }

        protected override bool CollisionAI(GameObject target)
        {
            return false;
        }

        protected override void OnDeath()
        {
            //The pile is destroyed
        }


    }
}
