using UnityEngine.Assertions;

namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    internal abstract class AbstractElement : IElement
    {
        public Parenteses Parent { get; set; }
        public IElement Previous { get; set; }
        public IElement Next { get; set; }

        public void InsertNext(IElement removable)
        {
            Assert.IsNotNull(removable);

            // 後ろに回る要素
            var oldNext = Next;
            Next = removable;

            // 挿し込まれる要素
            {
                var removableOldPrevious = removable.Previous;
                var removableOldNext = removable.Next;

                removable.Previous = this;
                removable.Next = oldNext;

                if (removableOldPrevious != null)
                {
                    removableOldPrevious.Next = removableOldNext;
                }

                if (removableOldNext != null)
                {
                    removableOldNext.Previous = removableOldPrevious;
                }
            }

            oldNext.Previous = removable;
        }

        /// <summary>
        /// 丸括弧であれば、その内部の始端の '(' を返します。
        /// 丸括弧以外はヌルを返します
        /// </summary>
        /// <returns></returns>
        public StartElement StepIn()
        {
            if (this is Parenteses parenteses)
            {
                return parenteses.StartElement;
            }

            return null;
        }

        /// <summary>
        /// 後要素を辿っていき、その最後尾要素の親を返します
        /// 
        /// - トップ・レベルであれば、ヌルを返します
        /// </summary>
        /// <returns></returns>
        public Parenteses StepOut()
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
