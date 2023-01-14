namespace Assets.Scripts.SKICombinatorCalculus.Text
{
    using Assets.Scripts.SKICombinatorCalculus;
    using System.Text;
    using UnityEngine;

    internal static class TextTypeParser
    {
        public static string Parse(string rightText)
        {
            // 計算過程
            StringBuilder calculationProcess = new StringBuilder();

            calculationProcess.AppendLine(rightText);

            string leftText;

            int tired = 0; // 疲れ
            bool isOk = true;

            while (isOk)
            {
                if (tired == 100)
                {
                    calculationProcess.AppendLine($@"
Very tired...");
                    break;
                }
                tired++;

                // 次に処理するコンビネーター。先頭とは限らない
                char nextCombinator;
                (isOk, leftText, nextCombinator, rightText) = RightOfCursor.NextCombinator(calculationProcess, rightText);
                if (!isOk)
                {
                    Debug.Log($"[Run] Not found nextCombinator");
                    break;
                }
                Debug.Log($"[Run 1] leftText:{leftText} nextCombinator:{nextCombinator} rightText:{rightText}");

                switch (nextCombinator)
                {
                    case 'S':
                        (isOk, rightText) = SCombinatorAsTextType.Solve(calculationProcess, rightText);
                        break;
                    case 'K':
                        (isOk, rightText) = KCombinatorAsTextType.Solve(calculationProcess, rightText);
                        break;
                    case 'I':
                        (isOk, rightText) = ICombinatorAsTextType.Solve(calculationProcess, rightText);
                        break;
                }

                if (!isOk)
                {
                    Debug.Log($"[Run] Failed");
                    break;
                }

                // 右テキストにまとめる
                Debug.Log($"[Run 2] leftText:{leftText} rightText:{rightText}");
                rightText = $"{leftText}{rightText}";
                leftText = "";
                calculationProcess.AppendLine(rightText);
            }

            return calculationProcess.ToString();
        }
    }
}
