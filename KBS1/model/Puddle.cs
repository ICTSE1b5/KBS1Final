using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS1.model
{
    class Puddle : EffectGiver
    {
        public Puddle(int pos_x, int pos_y, List<GameObject> props, Form1 form)
            : base(pos_x, pos_y, 50, 50, 0, 0, 0, 999, 0, props, form)
        {
            this.image = Properties.Resources.pool;
            this.description = "This puddle will cause you to slow down then you are near it.";

            isSolid = false;
        }
        protected override void setupImages()
        {
            imageNorthWest = Properties.Resources.pool;
            imageNorth = Properties.Resources.pool;
            imageNorthEast = Properties.Resources.pool;

            imageWest = Properties.Resources.pool;
            imageIdle = Properties.Resources.pool;
            imageEast = Properties.Resources.pool;

            imageSouthWest = Properties.Resources.pool;
            imageSouth = Properties.Resources.pool;
            imageSouthEast = Properties.Resources.pool;
        }


        protected override void AI()
        {
            foreach (GameObject ob in allObjects)
            {
                if (ob.ObjectRectangle.IntersectsWith(RectangleOfEffect) && (ob.Type == ObjectType.PLAYER))
                {
                    ob.giveSpeedEffect(SpeedEffects.SLOW_2);
                }
            }
        }

        protected override bool CollisionAI(GameObject target)
        {
            return false;
        }

        protected override void OnDeath()
        {
            //The puddle dries up
        }


    }
}
