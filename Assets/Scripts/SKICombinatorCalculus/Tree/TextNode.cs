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

        /// <summary>
        /// 最初のノードを削除
        /// </summary>
        /// <returns></returns>
        public NodeContainer RemoveFirstNode()
        {
            if (0 < this.Text.Length)
            {
                var ch = this.Text[0];
                var textNodeModel = new TextNodeModel($"{ch}");
                return new NodeContainer(textNodeModel);
            }

            return null;
        }

        public ICombinatorTextTypeModel RemoveICombinatorModel()
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

                                ICombinatorTextTypeModel iCombinatorModel = new ICombinatorTextTypeModel($"{arg1}");

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

        public KCombinatorModel RemoveKCombinatorModel()
        {
            if (0 < this.Text.Length)
            {
                var ch = this.Text[0];

                switch (ch)
                {
                    case 'K':
                        {
                            if (2 < this.Text.Length)
                            {
                                var arg1 = this.Text[1];
                                var arg2 = this.Text[1]; // TODO "(" かも知れない（ノード）

                                KCombinatorModel kCombinatorModel = new KCombinatorModel($"{arg1}", $"{arg2}");

                                //// 先頭の "K" と arg2 を除去したい
                                //this.Text = this.Text[1..];

                                return kCombinatorModel;
                            }
                        }
                        break;
                }
            }

            return null;
        }
    }
}
