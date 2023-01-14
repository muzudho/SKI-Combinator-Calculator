namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    /// <summary>
    /// 生成用のカーソル
    /// </summary>
    internal class CursorForSpawn
    {
        public CursorForSpawn(IElement startElement)
        {
            Current = startElement;
        }

        private IElement Current { get; set; }

        public void Read(char ch)
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
                        // TODO
                    }
                    break;

                case ')':
                    {
                        // TODO
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
    }
}
