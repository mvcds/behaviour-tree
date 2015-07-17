using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCDS.BehaviorTree.Library.Common;
using MVCDS.BehaviorTree.Library.Archetypes;

namespace MVCDS.BehaviorTree.Library.Test.Sequence_Test
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
        Map map = new Map(1, 5);
        Hero hero = new Hero();
        Sequence sequence = new Sequence();
        Door door = new Door(0, 3, true);
        Point2D target = new Point2D(0, 4);
        NodeStatus result;

        public void AddHero()
        {
            map.Add(hero);
            sequence.Children.Add(new MoveLeaf(hero, target));
        }

        private void AddDoor()
        {
            map.Add(door);

            Leaf open = new OpenLeaf(hero, door);
            sequence.Children.Add(open);
        }

        [TestMethod]
        public void No_Door()
        {
            AddHero();

            KeepRunning();
            Assert.AreEqual(result, NodeStatus.Success);
            AssertsHero();
        }

        private void KeepRunning()
        {
            while (result == NodeStatus.Running)
                result = sequence.Process();
        }

        [TestMethod]
        public void No_Key()
        {
            AddDoor();
            AddHero();

            KeepRunning();
            Assert.AreEqual(result, NodeStatus.Failure);
            AssertsHero(2);
        }

        [TestMethod]
        public void With_Door_And_Key()
        {
            AddDoor();
            AddHero();
            hero.Items.Add(new Key());

            KeepRunning();
            Assert.AreEqual(result, NodeStatus.Success);
            AssertsHero();
        }

        private void AssertsHero(int p = 4)
        {
            Assert.AreEqual(p, hero.Position.Y);
        }
    }
}
