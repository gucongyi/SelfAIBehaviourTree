namespace FluentBehaviour
{
    using System.Collections.Generic;

    public class SelectorNode : ILogicNode
    {
        private string name_;
        private List<ITreeNode> children_ = null;

        public SelectorNode(string name)
        {
            this.name_ = name;
            children_ = new List<ITreeNode>();
        }

        public TreeStatus tick()
        {
            foreach(var child in children_)
            {
                var childStatus = child.tick();
                if(childStatus != TreeStatus.kFailure)
                    return childStatus;
            }

            return TreeStatus.kFailure;
        }

        public void addChild(ITreeNode child)
        {
            children_.Add(child);
        }
    }
}