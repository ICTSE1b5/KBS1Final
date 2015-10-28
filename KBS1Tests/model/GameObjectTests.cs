using Microsoft.VisualStudio.TestTools.UnitTesting;
using KBS1.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBS1.model.Tests {
    [TestClass()]
    public class GameObjectTests {

        private int x = 0;
        private int y = 0;
        private int width = 10;
        private int height = 10;
        private int speed_x = 5;
        private int speed_y = 2;
        private int damage = 20;
        private int health = 100;
        private Form1 form;

        [TestMethod()]
        public void MoveTest() {
            form = new Form1();
            Player gameObject = new Player(health, speed_x, x, y, width, height, form);
            gameObject.changeDirections(Keys.Down, true);
            gameObject.Move();
            int new_x = gameObject.pos_x;
            int new_y = gameObject.pos_y;
            Console.WriteLine("Old y = {0}, and new y = {1}", y, new_y);
            Assert.IsTrue(new_x != x || new_y != y);
        }

        [TestMethod()]
        public void GetPropertyTest() {
            form = new Form1();
            Player p = new Player(10, 5, 0, 0, 50, 50, form);
            Assert.IsTrue(p.pos_y is int);
            Assert.IsTrue(p.getObjectImage() is Image);

        }
    }
}