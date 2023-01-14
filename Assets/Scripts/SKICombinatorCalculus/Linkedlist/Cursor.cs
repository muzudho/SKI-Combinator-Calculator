namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    /// <summary>
    /// 生成用のカーソル
    /// </summary>
    internal class Cursor
    {
        public Cursor(IElement startElement)
        {
            Current = startElement;
        }

        private IElement Current { get; set; }

        public void Write(char ch)
        {
            switch (ch)
            {
                case 'S':
                    {
                        var next = new SCombinator();
                        Current.AppendNext(next);
                        Current = next;
                    }
                    break;

                case 'K':
                    {
                        var next = new KCombinator();
                        Current.AppendNext(next);
                        Current = next;
                    }
                    break;

                case 'I':
                    {
                        var next = new IdCombinator();
                        Current.AppendNext(next);
                        Current = next;
                    }
                    break;

                case '(':
                    {
                        var next = new Parenteses();
                        Current.AppendNext(next);
                        Current = next;
                        Current = Current.StepIn();
                    }
                    break;

                case ')':
                    {
                        var parenteses = Current.StepOut();
                        Current = parenteses;
                    }
                    break;

                default:
                    {
                        if (SKICombinatorCalculator.variableCharacters.Contains(ch))
                        {
                            var next = new Variable(ch);
                            Current.AppendNext(next);
                            Current = next;
                        }
                    }
                    break;
            }
        }

        public IElement Read()
        {
            var element = Current;

            if (Current is Parenteses parenteses)
            {
                return parenteses.StartElement;
            }

            return element;
        }
    }
}
