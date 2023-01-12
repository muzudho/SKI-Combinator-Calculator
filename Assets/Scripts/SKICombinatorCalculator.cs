using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SKICombinatorCalculator
{
    private static string combinatorCharacters = "SKI";
    private static string variableCharacters = "abcdefghijklmnopqrstuvwxyz";

    /// <summary>
    /// 計算実行
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static string Run(string inputText)
    {
        string leftText;
        // 空白は詰める
        string rightText = inputText.Replace(" ", "");

        // 計算過程
        StringBuilder calculationProcess = new StringBuilder();
        calculationProcess.AppendLine(inputText);

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
            (isOk, leftText, nextCombinator, rightText) = NextCombinator(calculationProcess, rightText);
            if (!isOk)
            {
                Debug.Log($"[Run] Not found nextCombinator");
                break;
            }
            Debug.Log($"[Run 1] leftText:{leftText} nextCombinator:{nextCombinator} rightText:{rightText}");

            int startInRightText = 0;
            switch (nextCombinator)
            {
                case 'S':
                    (isOk, rightText) = SolveSCombinator(calculationProcess, startInRightText, rightText);
                    break;
                case 'K':
                    (isOk, rightText) = SolveKCombinator(calculationProcess, startInRightText, rightText);
                    break;
                case 'I':
                    (isOk, rightText) = SolveICombinator(calculationProcess, startInRightText, rightText);
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

    private static (bool, string) SolveSCombinator(StringBuilder calculationProcess, int start, string rest)
    {
        bool isOk;
        string arg1;
        string arg2;
        string arg3;
        (isOk, arg1, rest) = Parse(start, rest);
        if (!isOk)
        {
            return (false, "");
        }
        (isOk, arg2, rest) = Parse(start, rest);
        if (!isOk)
        {
            return (false, "");
        }
        (isOk, arg3, rest) = Parse(start, rest);
        if (!isOk)
        {
            return (false, "");
        }

        calculationProcess.AppendLine($@"
    S
      1 {arg1}
      2 {arg2}
      3 {arg3}
      _ {rest}
");

        return (true, $"{arg1}{arg3}({arg2}{arg3}){rest}");
    }
    private static (bool, string) SolveKCombinator(StringBuilder calculationProcess, int start, string rest)
    {
        bool isOk;
        string arg1;
        string arg2;
        (isOk, arg1, rest) = Parse(start, rest);
        if (!isOk)
        {
            return (false, "");
        }
        (isOk, arg2, rest) = Parse(start, rest);
        if (!isOk)
        {
            return (false, "");
        }

        calculationProcess.AppendLine($@"
    K
      1 {arg1}
      2 {arg2}
      _ {rest}
");

        return (true, $"{arg1}{rest}");
    }
    private static (bool, string) SolveICombinator(StringBuilder calculationProcess, int start, string rest)
    {
        bool isOk;
        string arg1;
        (isOk, arg1, rest) = Parse(start, rest);
        if (!isOk)
        {
            return (false, "");
        }

        calculationProcess.AppendLine($@"
    I
      1 {arg1}
      _ {rest}
");

        return (true, $"{arg1}{rest}");
    }

    /// <summary>
    /// 丸かっこを剥く
    /// </summary>
    /// <returns></returns>
    private static (bool, string) StripParentheses(int start, string expression)
    {
        // 対応する `)` を消去する
        int i = start + 1;
        var nested = 1;

        for (; i < expression.Length; i++)
        {
            var ch = expression[i];

            switch (ch)
            {
                case '(':
                    nested++;
                    break;
                case ')':
                    nested--;
                    if (nested == 0)
                    {
                        // 先頭の `(` と、対応する `)` を消去した数式
                        string left = string.Empty;
                        if (0 < start)
                        {
                            left = expression[0..start];
                        }
                        var middle = expression[(start + 1)..i];
                        var right = expression[(i + 1)..];
                        Debug.Log($"[StripParentheses] expression:{expression} start:{start} i:{i} ◆{left}◆{middle}◆{right}◆");
                        var newExpression = $"{left}{middle}{right}";
                        return (true, newExpression);
                    }
                    break;

            }
        }

        // 構文エラー
        Debug.Log($"[StripParentheses] 構文エラー expression:{expression} start:{start} nested:{nested} i:{i}");
        return (false, "");
    }

    private static (bool, string, char, string) NextCombinator(StringBuilder calculationProcess, string expression1)
    {
        var rest = expression1;
        var i = 0;

        while (i < rest.Length)
        {
            char cursor = rest[i];

            switch (cursor)
            {
                case 'S':
                case 'K':
                case 'I':
                    return (true, rest[0..i], cursor, rest[(i+1)..]);

                case '(':
                    {
                        // 丸かっこを剥く
                        bool isOk;
                        (isOk, rest) = StripParentheses(i, rest);
                        if (!isOk)
                        {
                            // 構文エラー
                            Debug.Log("[NextCombinator] 構文エラー");
                            return (false, "", ' ', "");
                        }

                        calculationProcess.AppendLine($"    stripped {rest}");
                        i = 0;
                        break;
                    }

                default:
                    {
                        // 変数と閉じかっこは読み飛ばします
                        if (variableCharacters.Contains(cursor) || cursor == ')')
                        {
                            i++;
                        }
                        else
                        {
                            // 計算不能
                            Debug.Log($"[NextCombinator] 計算不能 i:{i} first:{cursor} rest:{rest}");
                            return (false, "", ' ', "");
                        }
                    }
                    break;
            }
        }

        // 空文字列を指定時
        return (false, "", ' ', "");
    }

    private static (bool, string, string) Parse(int start, string expression)
    {
        if (expression.Length <= start)
        {
            Debug.Log($"[Parse] オーバー length:{expression.Length} start:{start}");
            return (false, "", "");
        }

        var cursor = expression[start];

        if (cursor == '(')
        {
            // TODO 対応する ')' まで読む
            var nested = 1;

            for (int i = 1; i < expression.Length; i++)
            {
                var ch = expression[i];

                switch (ch)
                {
                    case '(':
                        nested++;
                        break;
                    case ')':
                        nested--;
                        if (nested == 0)
                        {
                            return (true, expression[0..(i + 1)], expression[(i + 1)..]);
                        }
                        break;

                }
            }

            // 構文エラー
            Debug.Log("[Parse] 構文エラー1");
            return (false, "", "");
        }

        if (combinatorCharacters.Contains(cursor) || variableCharacters.Contains(cursor))
        {
            return (true, $"{cursor}", expression[1..]);
        }

        Debug.Log("[Parse] 構文エラー2");
        return (false, "", "");
    }
}
