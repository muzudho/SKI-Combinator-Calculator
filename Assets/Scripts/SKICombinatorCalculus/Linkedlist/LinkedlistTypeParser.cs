namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    using System.Text;
    using UnityEngine;
    using UnityEngine.Assertions;

    internal static class LinkedlistTypeParser
    {
        public static void DoAsserts()
        {
            // テスト
            var buf = new StringBuilder();

            {
                Placeholder topLevel = CursorOperation.Spawn("Ix");
                string result = CursorOperation.Stringify(topLevel);
                Assert.IsTrue(result=="Ix");
            }
            {
                Placeholder topLevel = CursorOperation.Spawn("(Ix)");
                string result = CursorOperation.Stringify(topLevel);
                Assert.IsTrue(result == "(Ix)");
            }
        }

        public static ParserResult Parse(string inputText)
        {
            var expression = SKICombinatorCalculator.TrimAllSpaces(inputText);

            // 生成
            Placeholder topLevel = CursorOperation.Spawn(expression);

            // 計算過程
            StringBuilder calculationProcessStr = new StringBuilder();

            // 文字列化（入力した式）
            {
                string resultText = CursorOperation.Stringify(topLevel.FirstCap);
                calculationProcessStr.AppendLine($"input {resultText}");
            }

            int tired = 0;

            for (; tired < 100; tired++)
            {
                bool strippedUnnecessaryParentheses = false;
                bool evaluated = false;

                // 評価する前に、不要な丸括弧をすべて外す必要がある
                while (StripUnnecessaryParentheses.DoIt(topLevel))
                {
                    strippedUnnecessaryParentheses = true;

                    // 文字列化
                    var strippedResultText = CursorOperation.Stringify(topLevel.FirstCap);
                    calculationProcessStr.AppendLine($"    stripped {strippedResultText}");
                }

                // 評価（１回だけ）
                var cursor = new CursorIO(topLevel.FirstCap);
                var calculationProcessObj = CursorOperation.EvaluateElements(cursor);
                if (calculationProcessObj != null)
                {
                    evaluated = true;

                    // 文字列化
                    calculationProcessStr.AppendLine(calculationProcessObj.ToString());

                    // 文字列化
                    var evaluatedResultText = CursorOperation.Stringify(topLevel.FirstCap);
                    calculationProcessStr.AppendLine($"evaluated {evaluatedResultText}");
                }

                if (!strippedUnnecessaryParentheses && !evaluated)
                {
                    // 丸括弧を剥かず、かつ、評価できなかったら終了
                    break;
                }

                cursor = new CursorIO(topLevel.FirstCap);
            }

            if (100 <= tired)
            {
                // 計算中断
                calculationProcessStr.AppendLine("very tired...");
            }

            return new ParserResult(topLevel.FirstCap, calculationProcessStr.ToString());
        }
    }
}
