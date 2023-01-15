namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    using System.Text;

    internal class Parentheses : AbstractElement
    {
        public Parentheses()
        {
            StartElement = new StartElement(new EndElement(this));
        }

        public Parentheses(StartElement startElement)
        {
            StartElement = startElement;
        }

        public StartElement StartElement { get; private set; }

        public override string ToString()
        {
            StringBuilder buf = new StringBuilder();

            IElement current = StartElement;
            while (current!=null)
            {
                buf.Append(current.ToString());
                current = current.Next;
            }

            return buf.ToString();
        }
    }
}
