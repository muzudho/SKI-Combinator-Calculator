namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    using System.Text;

    internal static class LinkedlistTypeParser
    {
        public static string Parse(string inputText)
        {
            var expression = SKICombinatorCalculator.TrimAllSpaces(inputText);

            // トップ・レベルの始端と終端
            var startElement = new StartElement(null);
            var endElement = new EndElement(null);
            startElement.AppendNext(endElement);

            // 生成
            {
                var cursor = new Cursor(startElement);

                // 先頭から順に書いていくだけ
                foreach (var ch in expression)
                {
                    cursor.Write(ch);
                }
            }

            // 文字列化
            string resultText;
            {
                StringBuilder buf = new StringBuilder();

                var cursor = new Cursor(startElement);

                // 先頭から順に読んでいくだけ
                foreach (var ch in expression)
                {
                    var element = cursor.Read();
                    buf.Append(element.ToString());                    
                }

                resultText = buf.ToString();
            }

            StringBuilder calculationProcess = new StringBuilder();

            calculationProcess.AppendLine($@"Last state:
    {resultText}
");

            return calculationProcess.ToString();
        }
    }
}
