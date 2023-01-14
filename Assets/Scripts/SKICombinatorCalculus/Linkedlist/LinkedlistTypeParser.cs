namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    using System.Text;

    internal static class LinkedlistTypeParser
    {
        public static string Parse(string inputText)
        {
            var expression = SKICombinatorCalculator.TrimAllSpaces(inputText);

            // トップ・レベルの始端と終端
            var startElement = new StartElement(new EndElement(null));

            // 生成
            {
                var cursor = new Cursor(startElement);

                // 先頭から順に書いていくだけ
                foreach (var ch in expression)
                {
                    cursor.Write(ch);
                }
            }

            // 計算過程
            StringBuilder calculationProcess = new StringBuilder();

            // 文字列化
            {
                string resultText = Stringify(startElement);
                calculationProcess.AppendLine(resultText);
            }

            // 評価
            {
                var cursor = new Cursor(startElement);
                if (cursor.Evaluate())
                {
                    // 文字列化
                    var resultText = Stringify(startElement);
                    calculationProcess.AppendLine(resultText);
                }
            }

            return calculationProcess.ToString();
        }

        /// <summary>
        /// 文字列化
        /// </summary>
        /// <returns></returns>
        public static string Stringify(StartElement startElement)
        {
            StringBuilder buf = new StringBuilder();

            var cursor = new Cursor(startElement);

            // 先頭から順に読んでいくだけ
            var current = cursor.ReadChar();
            while (current != null)
            {
                buf.Append(current.ToString());
                current = cursor.ReadChar();
            }

            return buf.ToString();
        }
    }
}
