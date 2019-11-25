namespace FluentBehaviour
{
    using System.Collections.Generic;

    public class SequenceNode : ILogicNode
    {
        private string name_;
        private List<ITreeNode> children = null;

        public SequenceNode(string name)
        {
            this.name_ = name;
            children = new List<ITreeNode>();
        }

        public TreeStatus tick()
        {
            foreach(var child in children)
            {
                var childStatus = child.tick();
                if(childStatus != TreeStatus.kSuccess)
                    return childStatus;
            }

            return TreeStatus.kSuccess;
        }

        public void addChild(ITreeNode child)
        {
            children.Add(child);
        }
    }
}