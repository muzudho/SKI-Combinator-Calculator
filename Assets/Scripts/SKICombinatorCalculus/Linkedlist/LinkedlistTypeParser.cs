namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    using System.Text;

    internal static class LinkedlistTypeParser
    {
        public static ParserResult Parse(string inputText)
        {
            var expression = SKICombinatorCalculator.TrimAllSpaces(inputText);

            // 生成
            StartElement topLevelStartElement = CursorOperation.Spawn(expression);

            // 計算過程
            StringBuilder calculationProcess = new StringBuilder();

            // 文字列化（入力した式）
            {
                string resultText = CursorOperation.Stringify(topLevelStartElement);
                calculationProcess.AppendLine(resultText);
            }

            int tired = 0;

            for (; tired < 100; tired++)
            {
                // 評価する前に、不要な丸括弧をすべて外す必要がある
                while (CursorOperation.StripUnnecessaryParentheses(topLevelStartElement))
                {
                    // 文字列化
                    var strippedResultText = CursorOperation.Stringify(topLevelStartElement);
                    calculationProcess.AppendLine($"    stripped {strippedResultText}");
                }

                // 評価（１回だけ）
                var cursor = new Cursor(topLevelStartElement);
                if (!cursor.EvaluateElements())
                {
                    // TODO 評価できなかったら終了
                    break;
                }

                // 文字列化
                var evaluatedResultText = CursorOperation.Stringify(topLevelStartElement);
                calculationProcess.AppendLine(evaluatedResultText);

                cursor = new Cursor(topLevelStartElement);
            }

            if (100 <= tired)
            {
                // 計算中断
                calculationProcess.AppendLine("very tired...");
            }

            return new ParserResult(topLevelStartElement, calculationProcess.ToString());
        }
    }
}
