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

            var cursorForSpawn = new CursorForSpawn(startElement);

            var currentElement = startElement;

            // 先頭から順に読んでいくだけ
            foreach (var ch in expression)
            {
                cursorForSpawn.Read(ch);

            }

            StringBuilder calculationProcess = new StringBuilder();

            calculationProcess.AppendLine($@"Last state:
    {inputText}
");

            return calculationProcess.ToString();
        }
    }
}
