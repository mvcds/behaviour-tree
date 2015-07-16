﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCDS.BehaviorTree.Library.Common;

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
        Door door = new Door(y: 3);
        Point2D target = new Point2D(0, 4);
        NodeStatus result;

        [TestInitialize]
        public void Init()
        {
            map.Add(hero);
            sequence.Children.Add(new MoveLeaf(hero, target));

        }

        private void AddDoor()
        {
            map.Add(door);
            sequence.Children.Add(new OpenLeaf(hero, door));
        }

        [TestMethod]
        public void Hero_Reachs_Target_No_Door()
        {
            KeepRunning();
            Assert.AreEqual(result, NodeStatus.Success);
        }

        private void KeepRunning()
        {
            while (result == NodeStatus.Running)
                result = sequence.Process();
        }
    }
}
