using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCDS.BehaviorTree.Library;
using MVCDS.BehaviorTree.Library.Composites;
using MVCDS.BehaviorTree.Library.Test.Helper;

namespace MVCDS.BehaviorTree.Library.Test
{
    //S = Starting Point
    //E = Ending Point
    //H = Hero (makes S and E invisible)
    //D = Closed Door (invisible when unlocked)

    //Axis X is time
    //Axis Y is position

    // 0   1   2   3   4   5
    //|E| |E| |E| |E| |E| |H| 4
    //|D| |D| |D| | | |H| | | 3
    //| | | | |H| |H| | | | | 2
    //| | |H| | | | | | | | | 1
    //|H| |S| |S| |S| |S| |S| 0

    [TestClass]
    public class Sequence_Test
    {
        Sequence sequence = new Sequence();
        Map map = new Map(1, 5);
        Hero hero;
        NodeStatus result;

        [TestInitialize]
        public void Setup()
        {
            hero = new Hero(map, 0, 0);
            hero.Behaviour = new Behaviour(sequence);
            
            sequence.Add(new MoveLeaf(map, hero, 0, 4));
        }

        [TestMethod]
        public void No_Door()
        {
            Test(NodeStatus.Success, 4);
        }

        [TestMethod]
        public void No_Key()
        {
            AddDoor();

            Test(NodeStatus.Failure, 2);
        }

        [TestMethod]
        public void With_Door_And_Key()
        {
            AddDoor();
            hero.Items.Add(new Key());
            Test(NodeStatus.Success, 4);
        }

        private void AssertHero(int y)
        {
            Assert.AreEqual(y, hero.Position.Y);
        }

        private void AddDoor()
        {
            Door door = new Door(map, 0, 3);

            OpenLeaf openLeaf = new OpenLeaf(map, hero, door);
            sequence.Add(openLeaf);
        }

        private void Test(NodeStatus expected, int y)
        {
            result = hero.Behaviour.Process();
            Assert.AreEqual(expected, result);
            AssertHero(y);
        }
    }
}
