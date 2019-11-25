namespace FluentBehaviour
{
    using System;
    using UnityEngine;

    public class ActionNode : ITreeNode
    {
        private string name_;
        private Func<TreeStatus> invoker_;

        public ActionNode(string name, Func<TreeStatus> func)
        {
            Debug.Assert(func != null);
            this.name_ = name;
            this.invoker_ = func;
        }

        public TreeStatus tick()
        {
            return invoker_();
        }
    }
}