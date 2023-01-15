namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    /// <summary>
    /// 先頭の要素
    /// 
    /// - トップ・レベルでは数式の左側の外相当
    /// - 丸括弧では `(` 相当
    /// </summary>
    internal class StartElement : AbstractElement
    {
        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="endElement">対応する終端要素</param>
        public StartElement(EndElement endElement)
        {
            this.endElement = endElement;
            SetNextManually(endElement);
        }

        /// <summary>
        /// 対応する終端要素は変わりません
        /// </summary>
        private EndElement endElement;

        /// <summary>
        /// 終端要素の親と同じ
        /// </summary>
        public new Parentheses Parent
        {
            get
            {
                return this.endElement.Parent;
            }
        }

        public override string ToString()
        {
            if (this.Parent != null)
            {
                return "(";
            }

            return string.Empty;
        }
    }
}
