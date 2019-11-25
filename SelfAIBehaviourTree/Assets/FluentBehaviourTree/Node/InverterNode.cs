namespace FluentBehaviour
{
    using System;

    public class InverterNode : ILogicNode
    {
        private string name_;
        private ITreeNode childNode;

        public InverterNode(string name)
        {
            this.name_ = name;
        }

        public TreeStatus tick()
        {
            if(childNode == null)
                throw new BehaviorException("InverterNode must have a child node!");

            var result = childNode.tick();

            if(result == TreeStatus.kFailure)
                return TreeStatus.kSuccess;
            else if(result == TreeStatus.kSuccess)
                return TreeStatus.kFailure;

            return result;
        }

        public void addChild(ITreeNode child)
        {
            if(this.childNode != null)
                throw new BehaviorException("Can't add more than a single child to InverterNode!");

            this.childNode = child;
        }
    }
}