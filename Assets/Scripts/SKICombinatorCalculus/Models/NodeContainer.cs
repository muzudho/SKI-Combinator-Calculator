namespace Assets.Scripts.SKICombinatorCalculus.Models
{
    /// <summary>
    /// テキスト・ノード、または インナー・ノード を含む
    /// </summary>
    internal class NodeContainer
    {
        public NodeContainer(INodeModel nodeModel)
        {
            NodeModel = nodeModel;
        }

        public INodeModel NodeModel { get; set; }

        public override string ToString()
        {
            if (this.NodeModel is TextNodeModel textNodeModel)
            {
                return textNodeModel.Text;
            }

            return "[NodeContainer Error]";
        }
    }
}
