namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    internal class AbstractElement : IElement
    {
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

            if (oldNext!=null)
            {
                oldNext.Previous = null;
            }
        }
    }
}
