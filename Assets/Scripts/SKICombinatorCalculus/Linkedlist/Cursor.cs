namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    using UnityEngine.Assertions;

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

        /// <summary>
        /// 書込
        /// </summary>
        /// <param name="ch"></param>
        public void Write(char ch)
        {
            switch (ch)
            {
                case 'S':
                    {
                        var next = new SCombinator();
                        Current.InsertNext(next);
                        Current = next;
                    }
                    break;

                case 'K':
                    {
                        var next = new KCombinator();
                        Current.InsertNext(next);
                        Current = next;
                    }
                    break;

                case 'I':
                    {
                        var next = new IdCombinator();
                        Current.InsertNext(next);
                        Current = next;
                    }
                    break;

                case '(':
                    {
                        var parenteses = new Parenteses();
                        Current.InsertNext(parenteses);
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
                            Current.InsertNext(next);
                            Current = next;
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// 読取
        /// </summary>
        /// <returns>終端を超えたら、ヌル</returns>
        public IElement Read()
        {
            var current = Current;

            // トップ・レベルの先頭要素は飛ばす
            if (current is StartElement startElement && startElement.Parent==null)
            {
                Current = current.Next;
                current = Current;
            }

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
                Parenteses parenteses2 = endElement.Parent;
                if (parenteses2 == null)
                {
                    return null;
                }

                Current = parenteses2.Next;
                return current;
            }

            Current = current.Next;
            return current;
        }

        /// <summary>
        /// 評価
        /// </summary>
        public bool Evaluate()
        {
            var current = Read();

            if (current is ICombinator combinator)
            {
                if (combinator is IdCombinator)
                {
                    var arg1 = Read();
                    current.Remove();
                    return true;
                }
            }

            return false;
        }
    }
}
