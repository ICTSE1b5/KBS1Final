using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS1.model
{
    class SpeedPort : EffectGiver
    {
        public SpeedPort(int pos_x, int pos_y, List<GameObject> props, Form1 form)
            : base(pos_x, pos_y, 50, 50, 0, 0, 0, 999, 50, props, form)
        {
            this.image = Properties.Resources.pool;
            this.description = "This thunder bolt will give you a speed boost if you're in the area of its effect";

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
                if (ob.Type == ObjectType.PLAYER && ob.ObjectRectangle.IntersectsWith(RectangleOfEffect))
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
