using UnityEngine.Assertions;

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
                        var parenteses = new Parenteses();
                        Current.AppendNext(parenteses);
                        Current = parenteses.StepIn();
                        Assert.IsNotNull(Current, $"parenteses.StartElement:{parenteses.StartElement}");
                    }
                    break;

                case ')':
                    {
                        Parenteses parenteses = Current.StepOut();
                        Assert.IsNotNull(parenteses, $"Current:{Current}");
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns>終端を超えたら、ヌル</returns>
        public IElement Read()
        {
            var current = Current;

            if (current == null)
            {
                return null;
            }
            else if (current is Parenteses parenteses)
            {
                current = parenteses.StartElement;
                Current = current.Next;
                return current;
            }
            else if (current is EndElement endElement)
            {
                current = endElement;
                Current = endElement.Parent.Next;
                return current;
            }

            Current = current.Next;
            return current;
        }
    }
}
