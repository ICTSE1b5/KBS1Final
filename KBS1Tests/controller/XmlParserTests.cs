using Microsoft.VisualStudio.TestTools.UnitTesting;
using KBS1.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KBS1.model;

namespace KBS1.controller.Tests {
    [TestClass()]
    public class XmlParserTests {

        [TestMethod()]
        public void HandleTest() {
            XmlParser p = new XmlParser();
            Form1 form = new Form1();
            string level = "level1";
            List<GameObject> objects = new List<GameObject>();
            p.Handle(objects, form, level);
            Assert.IsTrue(objects[0] is Player);
        }
    }
}