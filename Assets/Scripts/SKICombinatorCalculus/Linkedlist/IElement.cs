﻿namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
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

        /// <summary>
        /// 複製します
        /// </summary>
        IElement Duplicate();

        /// <summary>
        /// 前後の要素から切り離します
        /// </summary>
        void Remove();

        /// <summary>
        /// 次の要素を挿入
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
        Parenteses StepOut();
    }
}
