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
            var (isOk2, nextCombinator) = NextCombinator(expression);
            if (!isOk2)
            {
                break;
            }
            Debug.Log($"Next combinator:{nextCombinator}");

            (isOk, expression) = SolveFirst(expression.TrimStart());
            calculationProcess.AppendLine(expression);
        }

        return calculationProcess.ToString();
    }

    private static (bool, char) NextCombinator(string expression)
    {
        while (0 < expression.Length)
        {
            char first = expression[0];

            switch (first)
            {
                case 'S':
                case 'K':
                case 'I':
                    return (true, first);

                case '(':
                    // TODO 対応する `)` を消去する
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
                                    // 先頭の `(` と、対応する `)` を消去した数式
                                    expression = $"{expression.Substring(1, i)}{expression.Substring(i + 1)}";
                                    goto after_loop;
                                }
                                break;

                        }
                    }
                after_loop:
                    break;

                // 計算不能
                default:
                    return (false, ' ');
            }
        }

        // 空文字列を指定時
        return (false, ' ');
    }

    private static (bool, string) SolveFirst(string expression)
    {
        var first = expression[0];
        var rest = expression[1..];

        switch (first)
        {
            case 'S':
                // TODO 次のひとかたまりを取得
                bool isOk;
                string arg1;
                string arg2;
                string arg3;
                (isOk, arg1, rest) = Parse(rest.TrimStart());
                Debug.Log($"S arg1:{arg1} rest:{rest}");
                (isOk, arg2, rest) = Parse(rest.TrimStart());
                Debug.Log($"S arg2:{arg2} rest:{rest}");
                (isOk, arg3, rest) = Parse(rest.TrimStart());
                Debug.Log($"S arg3:{arg3} rest:{rest}");

                return (true, $"{arg1}{arg3}({arg2}{arg3}){rest}");
        }

        return (false, "");
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
