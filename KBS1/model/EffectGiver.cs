using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS1.model
{
    abstract class EffectGiver : GameObject
    {
        protected List<GameObject> allObjects;
        protected Rectangle RectangleOfEffect;
        protected int EffectRadius;

        public EffectGiver(int pos_x, int pos_y, int width, int height, int speed_x, int speed_y, int damage, int health, int effectRadius, List<GameObject> props, Form1 form)
            : base(pos_x, pos_y, width, height, speed_x, speed_y, damage, health, form)
        {
            Type = ObjectType.EFFECT;

            allObjects = props;

            EffectRadius = effectRadius;

            updateRectangleOfEffect();
        }

        protected void updateRectangleOfEffect()
        {
            RectangleOfEffect = new Rectangle(pos_x - EffectRadius, pos_y - EffectRadius, Width + EffectRadius * 2, Height + EffectRadius * 2);
        }

        public Rectangle EffectSquare
        {
            get { return RectangleOfEffect; }
        }
    }
}
