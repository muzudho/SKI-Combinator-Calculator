namespace Assets.Scripts.SKICombinatorCalculus.Tree
{
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 読取ったテキスト
    /// </summary>
    internal class SeekedNode : INode
    {
        private StringBuilder buffer = new StringBuilder();

        /// <summary>
        /// 親
        /// 
        /// - 無ければヌル
        /// </summary>
        public SeekedNode Parent { get; private set; }

        /// <summary>
        /// 子
        /// </summary>
        private List<INode> children = new List<INode>();

        public SeekedNode(SeekedNode parent)
        {
            this.Parent = parent;
        }

        public void Append(char ch)
        {
            buffer.Append(ch);
        }

        public void FlushLeafNode()
        {
            if (this.buffer.Length < 1)
            {
                return;
            }

            var leaf = new TextNode(buffer.ToString());
            this.buffer.Clear();

            this.children.Add(leaf);
        }

        /// <summary>
        /// 子要素を返す
        /// </summary>
        /// <returns></returns>
        public SeekedNode SpawnChild()
        {
            var child = new SeekedNode(this);
            this.children.Add(child);
            return child;
        }

        public override string ToString()
        {
            StringBuilder buf = new StringBuilder();

            foreach(var node in this.children)
            {
                if (node is TextNode textNode)
                {
                    buf.Append(textNode.Text);
                }
                else if (node is SeekedNode seekedNode)
                {
                    buf.Append($"({seekedNode.ToString()})");
                }
            }

            return buf.ToString();
        }
    }
}
