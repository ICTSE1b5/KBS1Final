using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBS1.model
{
    class Enemy_Static : Enemy
    {
        public Enemy_Static(int pos_x, int pos_y, List<GameObject> props, Form1 form)
            : base(pos_x, pos_y, 50, 50, 0, 0, 5, 10, props, form)
        {
            this.image = Properties.Resources.wolf_right;
            this.description = "This wolf doesn't move but when you hit him, you are dead";
        }

        protected override void setupImages()
        {
            imageNorthWest = Properties.Resources.imagenotfound;
            imageNorth = Properties.Resources.imagenotfound;
            imageNorthEast = Properties.Resources.imagenotfound;

            imageWest = Properties.Resources.imagenotfound;
            imageIdle = Properties.Resources.imagenotfound;
            imageEast = Properties.Resources.imagenotfound;

            imageSouthWest = Properties.Resources.imagenotfound;
            imageSouth = Properties.Resources.imagenotfound;
            imageSouthEast = Properties.Resources.imagenotfound;
        }

        protected override void AI()
        {
            
        }

        protected override void OnDeath()
        {
            
        }

        protected override bool CollisionAI(GameObject target)
        {
            
            switch (target.Type)
            {
                case ObjectType.PLAYER:
                    return true;
                default:
                    return true;
            }
        
        }
    }
}
