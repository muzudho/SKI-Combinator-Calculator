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
        Parentheses Parent { get; set; }

        /// <summary>
        /// 前要素
        /// </summary>
        IElement Previous { get; set; }

        /// <summary>
        /// 後要素
        /// </summary>
        IElement Next { get; }

        /// <summary>
        /// 複製します
        /// </summary>
        IElement Duplicate();

        /// <summary>
        /// 前後の要素から切り離します
        /// </summary>
        void Remove();

        /// <summary>
        /// 要素１つを、後要素として挿入
        /// </summary>
        /// <param name="removable"></param>
        /// <returns>引数の removable をそのまま返す</returns>
        IElement InsertNext(IElement removable);

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
        Parentheses StepOut();

        /// <summary>
        /// Nextプロパティを上書きします
        /// 
        /// - リンクの貼り直しは自動で行われません
        /// </summary>
        /// <param name="next"></param>
        void SetNextManually(IElement next);
    }
}
