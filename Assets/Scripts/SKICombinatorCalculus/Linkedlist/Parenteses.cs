namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    using System.Text;

    internal class Parenteses : AbstractElement
    {
        public Parenteses()
        {
            StartElement = new StartElement(new EndElement(this));
        }

        public Parenteses(StartElement startElement)
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
