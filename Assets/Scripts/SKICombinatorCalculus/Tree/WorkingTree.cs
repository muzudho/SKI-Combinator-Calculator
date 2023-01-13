namespace Assets.Scripts.SKICombinatorCalculus.Tree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 作業木
    /// </summary>

    internal class WorkingTree
    {
        public WorkingTree(string content)
        {
            this.source = content;

            // content を先頭から読取る
            // TODO 1. "(" が出てくるまで Leaf とする
            // TODO 2. "(" が出てきたら、対応する ")" が出てくるまで読取り WorkingNode とする
            // すべて上記の 1, 2 のどちらかになる
            Parse();
        }

        /// <summary>
        /// カーソル
        /// </summary>
        private int cursor = 0;

        /// <summary>
        /// 元の文字列
        /// </summary>
        private string source;

        /// <summary>
        /// 現在のノード
        /// </summary>
        private SeekedNode currentNode;

        public override string ToString()
        {
            return this.currentNode.ToString();
        }

        private void Parse()
        {
            // ルート・ノード
            this.currentNode = new SeekedNode(null);

            while (this.cursor < this.source.Length)
            {
                // 単調増加
                char ch = this.source[this.cursor];
                this.cursor++;

                switch (ch)
                {
                    case '(':
                        // 子の開始

                        // ここまでを 葉としてフィックス
                        this.currentNode.FlushLeafNode();

                        // 丸括弧自体は記憶しない

                        // 子要素を生成、カレントをそれへ移動
                        this.currentNode = this.currentNode.SpawnChild();
                        break;

                    case ')':
                        // 子の終了

                        // ここまでを 葉としてフィックス
                        this.currentNode.FlushLeafNode();

                        // 丸括弧自体は記憶しない

                        // 親要素へ戻る
                        this.currentNode = this.currentNode.Parent;
                        break;

                    default:
                        this.currentNode.Append(ch);
                        break;
                }
            }

            // 残りを 葉としてフィックス
            this.currentNode.FlushLeafNode();
        }
    }
}
