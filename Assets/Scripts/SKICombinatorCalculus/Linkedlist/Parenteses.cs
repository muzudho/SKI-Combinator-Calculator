namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    using System.Text;

    internal class Parenteses : AbstractElement
    {
        public Parenteses()
        {
            StartElement = new StartElement(this);
            var endElement = new EndElement(this);
            StartElement.AppendNext(endElement);
        }

        public IElement StartElement { get; private set; }

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
