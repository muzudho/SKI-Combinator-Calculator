using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SKICombinatorCalculator
{
    /// <summary>
    /// �v�Z���s
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static string Run(string expression)
    {
        // �v�Z�ߒ�
        StringBuilder calculationProcess = new StringBuilder();
        calculationProcess.AppendLine(expression);

        bool isOk = true;

        while (isOk)
        {
            expression = expression.TrimStart();

            // �擪�̂P�������擾
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
                    // TODO �Ή����� `)` ����������
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
                                    // �擪�� `(` �ƁA�Ή����� `)` ��������������
                                    rest = $"{rest.Substring(1, i)}{rest.Substring(i + 1)}";
                                    goto after_loop;
                                }
                                break;

                        }
                    }

                    // �\���G���[
                    Debug.Log("[NextCombinator] �\���G���[");
                    return (false, ' ', "");

                after_loop:
                    break;

                // �v�Z�s�\
                default:
                    return (false, ' ', "");
            }
        }

        // �󕶎�����w�莞
        return (false, ' ', "");
    }

    private static (bool, string, string) Parse(string expression)
    {
        var first = expression[0];

        switch (first)
        {
            case '(':
                // TODO �Ή����� ')' �܂œǂ�
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
