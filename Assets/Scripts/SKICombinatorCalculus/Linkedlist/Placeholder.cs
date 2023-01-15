namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    using System.Text;

    internal class Placeholder : AbstractElement
    {
        public Placeholder(bool withParentheses)
        {
            if (withParentheses)
            {
                FirstCap = new FirstCap(new LastCap(this));
            }
            else
            {
                FirstCap = new FirstCap(new LastCap(null));
            }
        }

        public FirstCap FirstCap { get; private set; }

        public override string ToString()
        {
            StringBuilder buf = new StringBuilder();

            IElement current = FirstCap;
            while (current!=null)
            {
                buf.Append(current.ToString());
                current = current.Next;
            }

            return buf.ToString();
        }
    }
}
