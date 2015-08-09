namespace MVCDS.BehaviorTree.Library.Archetypes
{
    public interface IComposite : INode
    {
        bool IsEmpty { get; }

        bool IsRandom { get; }

        INode[] Children { get; }

        void Add(INode node);

        bool Remove(INode node);
    }

    public interface IDecorator : INode
    {
        INode Child { get; }
    }

    public interface ILeaf : INode
    {
        void Refresh();//todo: review if it's really necessary
    }
}