namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    using System;
    using UnityEngine;
    using UnityEngine.Assertions;

    internal abstract class AbstractElement : IElement
    {
        public Placeholder Parent { get; set; }
        public IElement Previous { get; set; }
        public void SetPreviousManually(IElement previous)
        {
            if (this is FirstCap)
            {
                // FIXME
                throw new System.Exception("StartElementでPrevious操作するとおかしくなる");
            }

            this.Previous = previous;
        }
        public IElement Next { get; private set; }
        public void SetNextManually(IElement next)
        {
            if (this is LastCap)
            {
                // FIXME
                throw new System.Exception("EndElementでNext操作するとおかしくなる");
            }

            this.Next = next;
        }

        /// <summary>
        /// 複製します
        /// </summary>
        public IElement Duplicate()
        {
            if (this is IdCombinator)
            {
                return new IdCombinator();
            }
            else if (this is KCombinator)
            {
                return new KCombinator();
            }
            else if (this is SCombinator)
            {
                return new SCombinator();
            }
            else if (this is Variable variable)
            {
                return new Variable(variable.Character);
            }
            else if (this is Placeholder parentheses)
            {
                // 文字列からオブジェクトを生成
                return SpawnHelper.SpawnPlaceholderByText(parentheses.ToString());
            }
            else
            {
                throw new System.Exception($"unknown type:{this.GetType().Name}");
            }
        }

        /// <summary>
        /// 前後の要素から切り離します
        /// </summary>
        public void Remove()
        {
            Assert.IsFalse(this is FirstCap);
            Assert.IsFalse(this is LastCap);

            var oldPrevious = this.Previous;
            var oldNext = this.Next;

            oldPrevious.SetNextManually(oldNext);
            oldNext.SetPreviousManually(oldPrevious);
        }

        /// <summary>
        /// 複数の要素を、後要素として挿入
        /// </summary>
        /// <param name="cursor"></param>
        /// <returns>挿入後の次の要素を返す</returns>
        public IElement InsertNextAll(CursorIO cursor)
        {
            IElement current = this; // 例えば FirstCap

            // 先頭から順に書いていくだけ
            for(IElement ch = cursor.ReadChar();ch!=null; ch = cursor.ReadChar())
            {
                if (ch is FirstCap)
                {
                    // Ignored
                }
                else if (ch is LastCap)
                {
                    // Ignored
                }
                else
                {
                    // 順繰り
                    current.InsertNext(ch);
                    current = ch;
                }
            }

            return current;
        }

        /// <summary>
        /// 次の要素を挿入
        /// </summary>
        /// <param name="visitor">挿入される要素</param>
        /// <returns>引数の expressionStartElement の EndElement を返す</returns>
        public IElement InsertNext(IElement visitor)
        {
            Assert.IsNotNull(visitor);
            // Debug.Log($"[InsertNext] ★開始。 visitor:{visitor} {visitor.GetType().Name} を {this.ToString()} {this.GetType().Name} の次へ挿入したい");

            // リンクを貼り替える前の情報
            var visitorOldPrevious = visitor.Previous; // ヌルのケースがある
            var visitorOldNext = visitor.Next; // ヌルのケースがある
            var targetOldNext = Next; // ヌルのケースがある

            if (targetOldNext!=null)
            {
                Assert.IsNotNull(targetOldNext);
                // Debug.Log($"[InsertNext] targetOldNext:{targetOldNext} {targetOldNext.GetType().Name}");
            }
            else
            {
                throw new Exception($"[InsertNext] targetOldNext:null トップレベルの末尾 ★おかしい");
            }

            // この要素は、新しいつながりを得る
            SetNextManually(visitor);

            // 元からあった後ろの要素は、新しいつながりを得る
            targetOldNext.SetPreviousManually(visitor);

            // 挿し込まれる要素は、新しいつながりを得る
            visitor.SetPreviousManually(this);
            visitor.SetNextManually(targetOldNext);

            // 切り抜かれた元のつながりは、修復する
            if (visitorOldPrevious != null)
            {
                Assert.IsNotNull(visitorOldPrevious);
                // Debug.Log($"[InsertNext] visitorOldPrevious:{visitorOldPrevious} {visitorOldPrevious.GetType().Name}");

                if (visitorOldNext != null)
                {
                    Assert.IsNotNull(visitorOldNext);
                    // Debug.Log($"[InsertNext] visitorOldNext:{visitorOldNext} {visitorOldNext.GetType().Name}");

                    visitorOldPrevious.SetNextManually(visitorOldNext);
                    visitorOldNext.SetPreviousManually(visitorOldPrevious);
                }
                else
                {
                    // Debug.Log($"[InsertNext] visitorOldNext:null （元のつながりはない？）");
                }
            }
            else
            {
                // Debug.Log($"[InsertNext] guestOldPrevious:null （元のつながりはない？）");
            }

            return visitor;
        }

        /// <summary>
        /// 丸括弧であれば、その内部の始端の '(' を返します。
        /// 丸括弧以外はヌルを返します
        /// </summary>
        /// <returns></returns>
        public FirstCap StepIn()
        {
            if (this is Placeholder parentheses)
            {
                return parentheses.FirstCap;
            }

            return null;
        }

        /// <summary>
        /// 後要素を辿っていき、その最後尾要素の親を返します
        /// 
        /// - トップ・レベルであれば、ヌルを返します
        /// </summary>
        /// <returns></returns>
        public Placeholder StepOut()
        {
            IElement current = this;
            while (current.Next != null)
            {
                current = current.Next;
            }

            return current.Parent;
        }
    }
}
