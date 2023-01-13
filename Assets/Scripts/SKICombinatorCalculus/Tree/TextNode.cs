using Assets.Scripts.SKICombinatorCalculus.Models;

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

        public string Text { get; private set; }

        public ICombinatorModel RemoveICombinatorModel()
        {
            if (0 < this.Text.Length)
            {
                var ch = this.Text[0];

                switch (ch)
                {
                    case 'I':
                        {
                            if (1 < this.Text.Length)
                            {
                                var arg1 = this.Text[1];

                                ICombinatorModel iCombinatorModel = new ICombinatorModel($"{arg1}");

                                // 先頭の "I" を除去
                                this.Text = this.Text[1..];

                                return iCombinatorModel;
                            }
                        }
                        break;
                }
            }

            return null;
        }
    }
}
