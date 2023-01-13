using Assets.Scripts.SKICombinatorCalculus;
using System.Text;
using UnityEngine;

/// <summary>
/// 数式上のカーソルより右側
/// </summary>
internal static class RightOfCursor
{
    public static (bool, string, char, string) NextCombinator(StringBuilder calculationProcess, string expression1)
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
                    return (true, rest[0..i], cursor, rest[(i + 1)..]);

                case '(':
                    {
                        // 指定した開き括弧に対応する閉じ丸括弧を剥く（剥けないケースもある）
                        var (error, rest2) = UnnecessaryParenteses.Strip(rest, i);
                        switch (error)
                        {
                            case StripParenthesesError.None:
                                rest = rest2;
                                calculationProcess.AppendLine($"    stripped {rest}");
                                i = 0;
                                break;

                            case StripParenthesesError.NotFoundArgument:
                                // 正常な挙動。エラーではない
                                // calculationProcess.AppendLine($"    can't stripped {rest}");
                                i++;
                                break;

                            case StripParenthesesError.Sintax:
                                // 構文エラー
                                calculationProcess.AppendLine($"    sintax error. rest:{rest}");
                                Debug.Log("[NextCombinator] 構文エラー");
                                return (false, "", ' ', "");

                            default:
                                throw new System.Exception();
                        }

                        break;
                    }

                default:
                    {
                        // 変数と閉じかっこは読み飛ばします
                        if (SKICombinatorCalculator.variableCharacters.Contains(cursor) || cursor == ')')
                        {
                            // calculationProcess.AppendLine($"    ... i:{i}");
                            i++;
                        }
                        else
                        {
                            // 計算不能
                            // calculationProcess.AppendLine($"    incalculable. i:{i}");
                            Debug.Log($"[NextCombinator] 計算不能 i:{i} first:{cursor} rest:{rest}");
                            return (false, "", ' ', "");
                        }
                    }
                    break;
            }
        }

        // - 空文字列を指定時
        // - 計算正常終了時
        // calculationProcess.AppendLine($"    out of index exception");
        return (false, "", ' ', "");
    }

    public static (bool, string) SolveSCombinator(StringBuilder calculationProcess, int start, string rest)
    {
        bool isOk;
        string arg1;
        string arg2;
        string arg3;
        (isOk, arg1, rest) = RightOfCursor.Parse(start, rest);
        if (!isOk)
        {
            return (false, "");
        }
        (isOk, arg2, rest) = RightOfCursor.Parse(start, rest);
        if (!isOk)
        {
            return (false, "");
        }
        (isOk, arg3, rest) = RightOfCursor.Parse(start, rest);
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
    public static (bool, string) SolveKCombinator(StringBuilder calculationProcess, int start, string rest)
    {
        bool isOk;
        string arg1;
        string arg2;
        (isOk, arg1, rest) = RightOfCursor.Parse(start, rest);
        if (!isOk)
        {
            return (false, "");
        }
        (isOk, arg2, rest) = RightOfCursor.Parse(start, rest);
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
    public static (bool, string) SolveICombinator(StringBuilder calculationProcess, int start, string rest)
    {
        bool isOk;
        string arg1;
        (isOk, arg1, rest) = RightOfCursor.Parse(start, rest);
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

        if (SKICombinatorCalculator.combinatorCharacters.Contains(cursor) || SKICombinatorCalculator.variableCharacters.Contains(cursor))
        {
            return (true, $"{cursor}", expression[1..]);
        }

        Debug.Log("[Parse] 構文エラー2");
        return (false, "", "");
    }
}
