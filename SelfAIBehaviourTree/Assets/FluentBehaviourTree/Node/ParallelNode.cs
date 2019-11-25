namespace FluentBehaviour
{
    using System.Collections.Generic;

    public class ParallelNode : ILogicNode
    {
        private string name_;
        
        private int required_to_fail_;
        private int required_to_succeed_;
        private List<ITreeNode> children_ = null;

        public ParallelNode(string name, int numRequiredToFail, int numRequiredToSucceed)
        {
            this.name_ = name;
            this.required_to_fail_ = numRequiredToFail;
            this.required_to_succeed_ = numRequiredToSucceed;
            children_ = new List<ITreeNode>();
        }

        public TreeStatus tick()
        {
            var nSuceeded = 0;
            var nFailed = 0;

            foreach(var child in children_)
            {
                var childStatus = child.tick();
                switch(childStatus)
                {
                    case TreeStatus.kSuccess: ++nSuceeded; break;
                    case TreeStatus.kFailure: ++nFailed; break;
                }
            }

            if(required_to_succeed_ > 0 && nSuceeded >= required_to_succeed_)
                return TreeStatus.kSuccess;

            if(required_to_fail_ > 0 && nFailed >= required_to_fail_)
                return TreeStatus.kFailure;

            return TreeStatus.kRunning;
        }

        public void addChild(ITreeNode child)
        {
            children_.Add(child);
        }
    }
}