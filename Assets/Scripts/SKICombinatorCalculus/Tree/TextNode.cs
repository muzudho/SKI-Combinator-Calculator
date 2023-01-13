namespace Assets.Scripts.SKICombinatorCalculus.Tree
{
    /// <summary>
    /// テキスト節
    /// </summary>
    internal class TextNode : ILeafNode
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text">文字列</param>
        public TextNode(string text)
        {
            this.Text = text;
        }

        public string Text { get; set; }
    }
}
