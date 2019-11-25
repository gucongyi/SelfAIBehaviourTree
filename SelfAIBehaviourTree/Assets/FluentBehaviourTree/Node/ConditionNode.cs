namespace FluentBehaviour
{
    using System;
    using UnityEngine;

    public class ConditionNode : ITreeNode
    {
        private string name_;
        private Func<bool> invoker_;

        public ConditionNode(string name, Func<bool> func)
        {
            Debug.Assert(func != null);
            this.name_ = name;
            this.invoker_ = func;
        }

        public TreeStatus tick()
        {
            return invoker_()? TreeStatus.kSuccess : TreeStatus.kFailure;
        }
    }
}