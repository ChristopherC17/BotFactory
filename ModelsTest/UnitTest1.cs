using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BotFactory.Models;
using BotFactory.Common.Tools;

namespace ModelsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void TestEqualsCoordinates()
        {
            Coordinates coord1 = new Coordinates(1, 5);
            Coordinates coord2 = new Coordinates(1, 5);
            Assert.AreEqual(coord1, coord2);

        }

        [TestMethod]
        public void TestLengthVecteur()
        {
            Vector vecteur = new Vector();
            vecteur.X = 3;
            vecteur.Y = 2;
            Assert.AreEqual(vecteur.Length(), Math.Sqrt(13));

        }

    }
}
