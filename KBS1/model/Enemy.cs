using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KBS1.model
{
    abstract class Enemy : GameObject
    {
        protected Player player1;

        public Enemy(int pos_x, int pos_y, int width, int height, int speed_x, int speed_y, int damage, int health, List<GameObject> props, Form1 form)
            : base(pos_x, pos_y, width, height, speed_x, speed_y, damage, health, form)
        {
            Type = ObjectType.ENEMY;
            
            foreach(GameObject player in props)
            {
                if(player.Type.Equals(ObjectType.PLAYER))
                {
                    player1 = (Player)player;
                }                
                
            }
        }
    }
}