namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    /// <summary>
    /// 終端の要素
    /// 
    /// - トップ・レベルでは数式の右側の外相当
    /// - 丸括弧では `)` 相当
    /// </summary>
    internal class EndElement : AbstractElement
    {
        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="parenteses">親要素。トップ・レベルであれば、ヌル</param>
        public EndElement(Parenteses parenteses)
        {
            Parent = parenteses;
        }

        public override string ToString()
        {
            if (Parent != null)
            {
                return ")";
            }

            return string.Empty;
        }
    }
}
