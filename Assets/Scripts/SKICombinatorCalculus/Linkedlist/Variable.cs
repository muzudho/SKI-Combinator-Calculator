namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    internal class Variable : AbstractElement
    {
        public Variable(char character)
        {
            Character = character;
        }

        public char Character { get; protected set; }

        public override string ToString()
        {
            return $"{Character}";
        }
    }
}
