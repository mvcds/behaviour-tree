using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCDS.BehaviorTree.Library.Archetypes;
using MVCDS.BehaviorTree.Library.Composites;
using MVCDS.BehaviorTree.Library.Test.Helper;

namespace MVCDS.BehaviorTree.Library.Test.Composites
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

    public class Composite_Test
    {
        public Composite_Test()
        {
            SequenceNode = new Sequence();
            Location = new Map(1, 5);
            
            Character = new Hero(Location, 0, 0);
            Character.Behaviour = new Behaviour(SequenceNode);
        }

        protected Map Location { get; private set; }

        protected Hero Character { get; private set; }

        protected Sequence SequenceNode { get; private set; }

        public virtual void Setup()
        {
            MoveLeaf goal = new MoveLeaf(Location, Character, 0, 4);
            SequenceNode.Add(goal);
        }

        [TestMethod]
        public void No_Door()
        {
            Test(NodeStatus.Success, 4);
        }

        protected void AddDoor(Composite node)
        {
            Door door = new Door(Location, 0, 3);

            OpenLeaf openLeaf = new OpenLeaf(Location, Character, door);
            node.Add(openLeaf);
        }

        private void AssertHero(int y)
        {
            Assert.AreEqual(y, Character.Position.Y);
        }

        protected void Test(NodeStatus expected, int y)
        {
            NodeStatus result = Character.Behaviour.Process();
            Assert.AreEqual(expected, result);
            AssertHero(y);
        }
    }
}
