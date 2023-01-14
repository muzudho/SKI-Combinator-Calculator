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

        void AppendNext(IElement next);

        /// <summary>
        /// 始端を返します
        /// </summary>
        /// <returns></returns>
        IElement StepIn();

        /// <summary>
        /// 前要素を辿っていき、その最前要素の親を返します
        /// 
        /// - トップ・レベルであれば、ヌルを返します
        /// </summary>
        /// <returns></returns>
        Parenteses StepOut();
    }
}
