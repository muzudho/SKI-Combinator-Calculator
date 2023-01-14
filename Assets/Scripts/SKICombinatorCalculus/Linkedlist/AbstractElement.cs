namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    internal abstract class AbstractElement : IElement
    {
        public Parenteses Parent { get; set; }
        public IElement Previous { get; set; }
        public IElement Next { get; set; }

        public void AppendNext(IElement next)
        {
            var oldNext = Next;
            Next = next;

            if (next != null)
            {
                var oldPrevious = next.Previous;
                next.Previous = this;

                if (oldPrevious != null)
                {
                    oldPrevious.Next = null;
                }
            }

            if (oldNext != null)
            {
                oldNext.Previous = null;
            }
        }

        /// <summary>
        /// 始端を返します
        /// 
        /// - 丸括弧でなければ、ヌル
        /// </summary>
        /// <returns></returns>
        public IElement StepIn()
        {
            if (this is Parenteses parenteses)
            {
                return parenteses.StartElement;
            }

            return null;
        }

        /// <summary>
        /// 前要素を辿っていき、その最前要素の親を返します
        /// 
        /// - トップ・レベルであれば、ヌルを返します
        /// </summary>
        /// <returns></returns>
        public Parenteses StepOut()
        {
            IElement current = this;
            while (current.Previous != null)
            {
                current = current.Previous;
            }

            return current.Parent;
        }
    }
}
