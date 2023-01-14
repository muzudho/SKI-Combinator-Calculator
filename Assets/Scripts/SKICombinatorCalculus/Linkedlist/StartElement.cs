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
        /// <param name="endElement">終端要素</param>
        public StartElement(EndElement endElement)
        {
            Next = endElement;
        }

        public override string ToString()
        {
            if (Parent != null)
            {
                return "(";
            }

            return string.Empty;
        }
    }
}
