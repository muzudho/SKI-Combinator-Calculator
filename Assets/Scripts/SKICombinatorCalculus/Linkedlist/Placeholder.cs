namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    using System.Text;

    internal class Placeholder : AbstractElement
    {
        public Placeholder(bool withParentheses)
        {
            WithParentheses = withParentheses;

            if (WithParentheses)
            {
                FirstCap = new FirstCap(new LastCap(this));
            }
            else
            {
                FirstCap = new FirstCap(new LastCap(null));
            }
        }

        public FirstCap FirstCap { get; private set; }

        public bool WithParentheses { get; private set; }

        public override string ToString()
        {
            StringBuilder buf = new StringBuilder();

            IElement current = FirstCap;

            // 先頭の `(` を読み飛ばすなら
            if (!WithParentheses && current is FirstCap)
            {
                current = current.Next;
            }

            while (current!=null)
            {
                // 末尾の `)` を読み飛ばすなら
                if (!WithParentheses && current is LastCap)
                {
                    current = current.Next;
                    break;
                }

                buf.Append(current.ToString());
                current = current.Next;
            }

            return buf.ToString();
        }

        public void SetupStripParenthses()
        {
            if (WithParentheses)
            {
                WithParentheses = false;
                return;
            }

            throw new System.Exception("[Placeholder StripParenthses] this is not parentheses");
        }
    }
}
