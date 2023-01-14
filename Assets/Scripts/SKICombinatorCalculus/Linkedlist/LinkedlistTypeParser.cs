namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    using System.Text;

    internal static class LinkedlistTypeParser
    {
        public static string Parse(string inputText)
        {
            var expression = SKICombinatorCalculator.TrimAllSpaces(inputText);

            var startElement = new StartElement();
            var endElement = new EndElement();
            startElement.AppendNext(endElement);

            var currentElement = startElement;

            // 先頭から順に読んでいくだけ
            foreach (var ch in expression)
            {
                switch (ch)
                {
                    case 'S':
                        {
                            currentElement.AppendNext(new SCombinator());
                        }
                        break;

                    case 'K':
                        {
                            currentElement.AppendNext(new KCombinator());
                        }
                        break;

                    case 'I':
                        {
                            currentElement.AppendNext(new IdCombinator());
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
                                currentElement.AppendNext(new Variable(ch));
                            }
                        }
                        break;
                }
            }

            StringBuilder calculationProcess = new StringBuilder();

            calculationProcess.AppendLine($@"Last state:
    {inputText}
");

            return calculationProcess.ToString();
        }
    }
}
