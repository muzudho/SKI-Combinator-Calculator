namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    internal interface IElement
    {
        /// <summary>
        /// 親要素
        /// 
        /// - トップ・レベルであれば、ヌル
        /// - 先頭要素でなければ、ヌル
        /// </summary>
        Parenteses Parent { get; set; }

        /// <summary>
        /// 前要素
        /// </summary>
        IElement Previous { get; set; }

        /// <summary>
        /// 後要素
        /// </summary>
        IElement Next { get; set; }

        void InsertNext(IElement next);

        /// <summary>
        /// 丸括弧であれば、その内部の始端の '(' を返します。
        /// 丸括弧以外はヌルを返します
        /// </summary>
        /// <returns></returns>
        StartElement StepIn();

        /// <summary>
        /// 後要素を辿っていき、その最後尾要素の親を返します
        /// 
        /// - トップ・レベルであれば、ヌルを返します
        /// </summary>
        /// <returns></returns>
        Parenteses StepOut();
    }
}
