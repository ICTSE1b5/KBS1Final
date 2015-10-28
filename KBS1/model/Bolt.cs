using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS1.model
{
    class Bolt : EffectGiver
    {
        public Bolt(int pos_x, int pos_y, List<GameObject> props, Form1 form)
            : base(pos_x, pos_y, 50, 50, 0, 0, 0, 999, 20, props, form)
        {
            this.image = Properties.Resources.bolt;
            this.description = "This thunder bolt will give you a speed boost if you're in the area of its effect";

            isSolid = false;
        }
        protected override void setupImages()
        {
            imageNorthWest = Properties.Resources.bolt;
            imageNorth = Properties.Resources.bolt;
            imageNorthEast = Properties.Resources.bolt;

            imageWest = Properties.Resources.bolt;
            imageIdle = Properties.Resources.bolt;
            imageEast = Properties.Resources.bolt;

            imageSouthWest = Properties.Resources.bolt;
            imageSouth = Properties.Resources.bolt;
            imageSouthEast = Properties.Resources.bolt;
        }

        protected override void AI()
        {
            foreach (GameObject ob in allObjects)
            {
                if (ob.ObjectRectangle.IntersectsWith(RectangleOfEffect) && (ob.Type == ObjectType.PLAYER))
                {
                    ob.giveSpeedEffect(SpeedEffects.FAST_2);
                }
            }
        }

        protected override bool CollisionAI(GameObject target)
        {
            return false;
        }

        protected override void OnDeath()
        {
            //The thunder has subsided
        }


    }
}
