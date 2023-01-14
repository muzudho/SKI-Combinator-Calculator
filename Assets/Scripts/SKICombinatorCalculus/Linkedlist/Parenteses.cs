namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    internal class Parenteses : AbstractElement
    {
        public Parenteses()
        {
            StartElement = new StartElement();
            var endElement = new EndElement();
            StartElement.AppendNext(endElement);
        }

        public IElement StartElement { get; private set; }
    }
}
