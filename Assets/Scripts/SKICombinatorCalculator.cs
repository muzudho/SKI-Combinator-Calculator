using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SKICombinatorCalculator
{
    /// <summary>
    /// 計算実行
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static string Run(string expression)
    {
        // 計算過程
        StringBuilder calculationProcess = new StringBuilder();
        calculationProcess.AppendLine(expression);

        bool isOk = true;

        while (isOk)
        {
            expression = expression.TrimStart();

            // 先頭の１文字を取得
            var (isOk2, nextCombinator, rest) = NextCombinator(expression);
            if (!isOk2)
            {
                Debug.Log($"[Run] Not found nextCombinator. expression:{expression}");
                break;
            }
            Debug.Log($"[Run 1] isOk:{isOk2} nextCombinator:{nextCombinator} rest:{rest} expression:{expression}");

            switch (nextCombinator)
            {
                case 'S':
                    (isOk, expression) = SolveSCombinator(calculationProcess, rest.TrimStart());
                    break;
                case 'K':
                    (isOk, expression) = SolveSCombinator(calculationProcess, rest.TrimStart());
                    break;
                case 'I':
                    (isOk, expression) = SolveSCombinator(calculationProcess, rest.TrimStart());
                    break;
            }

            Debug.Log($"[Run 2] isOk:{isOk} restExpression:{expression}");
            calculationProcess.AppendLine(expression);
        }

        return calculationProcess.ToString();
    }

    private static (bool, string) SolveSCombinator(StringBuilder calculationProcess, string rest)
    {
        bool isOk;
        string arg1;
        string arg2;
        string arg3;
        (isOk, arg1, rest) = Parse(rest.TrimStart());
        Debug.Log($"[SolveCombinator S1] arg1:{arg1} rest:{rest}");
        if (!isOk)
        {
            return (false, "");
        }
        (isOk, arg2, rest) = Parse(rest.TrimStart());
        Debug.Log($"[SolveCombinator S2] arg2:{arg2} rest:{rest}");
        if (!isOk)
        {
            return (false, "");
        }
        (isOk, arg3, rest) = Parse(rest.TrimStart());
        Debug.Log($"[SolveCombinator S3] arg3:{arg3} rest:{rest}");
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
    private static (bool, string) SolveKCombinator(StringBuilder calculationProcess, string rest)
    {
        bool isOk;
        string arg1;
        string arg2;
        (isOk, arg1, rest) = Parse(rest.TrimStart());
        Debug.Log($"[SolveCombinator K1] arg1:{arg1} rest:{rest}");
        if (!isOk)
        {
            return (false, "");
        }
        (isOk, arg2, rest) = Parse(rest.TrimStart());
        Debug.Log($"[SolveCombinator K2] arg2:{arg2} rest:{rest}");
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
    private static (bool, string) SolveICombinator(StringBuilder calculationProcess, string rest)
    {
        bool isOk;
        string arg1;
        (isOk, arg1, rest) = Parse(rest.TrimStart());
        Debug.Log($"[SolveCombinator I] arg1:{arg1} rest:{rest}");
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

    private static (bool, char, string) NextCombinator(string expression1)
    {
        var rest = expression1;

        while (0 < rest.Length)
        {
            char first = rest[0];
            rest = rest[1..];

            switch (first)
            {
                case 'S':
                case 'K':
                case 'I':
                    return (true, first, rest);

                case '(':
                    // TODO 対応する `)` を消去する
                    var nested = 1;

                    for (int i = 1; i < rest.Length; i++)
                    {
                        var ch = rest[i];

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
                                    rest = $"{rest.Substring(1, i)}{rest.Substring(i + 1)}";
                                    goto after_loop;
                                }
                                break;

                        }
                    }

                    // 構文エラー
                    Debug.Log("[NextCombinator] 構文エラー");
                    return (false, ' ', "");

                after_loop:
                    break;

                // 計算不能
                default:
                    return (false, ' ', "");
            }
        }

        // 空文字列を指定時
        return (false, ' ', "");
    }

    private static (bool, string, string) Parse(string expression)
    {
        var first = expression[0];

        switch (first)
        {
            case '(':
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
                                return (true, expression.Substring(0, i + 1), expression.Substring(i + 1));
                            }
                            break;

                    }
                }
                break;

            case 'K':
                return (true, $"{first}", expression.Substring(1));

            case 'x':
                return (true, $"{first}", expression.Substring(1));
        }

        return (false, "", "");
    }
}
