namespace FluentBehaviour
{
    /// <summary>
    /// 逻辑节点接口
    /// </summary>
    public interface ILogicNode : ITreeNode
    {
        void addChild(ITreeNode childNode);
    }
}
