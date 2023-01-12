using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SKICombinatorCalculator
{
    /// <summary>
    /// ŒvZÀs
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static string Run(string expression)
    {
        // æ“ª‚Ì‚P•¶š‚ğæ“¾
        var (isOk, nextExpression) = SolveFirst(expression.TrimStart());

        return nextExpression;
    }

    private static (bool, string) SolveFirst(string expression)
    {
        var first = expression[0];
        var rest = expression[1..];

        switch (first)
        {
            case 'S':
                // TODO Ÿ‚Ì‚Ğ‚Æ‚©‚½‚Ü‚è‚ğæ“¾
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
                // TODO ‘Î‰‚·‚é ')' ‚Ü‚Å“Ç‚Ş
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
