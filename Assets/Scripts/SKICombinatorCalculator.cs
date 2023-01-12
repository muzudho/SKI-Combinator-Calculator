using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SKICombinatorCalculator
{
    private static string combinatorCharacters = "SKI";
    private static string variableCharacters = "abcdefghijklmnopqrstuvwxyz";

    /// <summary>
    /// �v�Z���s
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static string Run(string expression)
    {
        // �󔒂͋l�߂�
        expression = expression.Replace(" ", "");

        // �v�Z�ߒ�
        StringBuilder calculationProcess = new StringBuilder();
        calculationProcess.AppendLine(expression);

        int tired = 0; // ���
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

            // ���ɏ�������R���r�l�[�^�[�B�擪�Ƃ͌���Ȃ�
            var (isOk2, nextCombinator, rest) = NextCombinator(calculationProcess, expression);
            if (!isOk2)
            {
                Debug.Log($"[Run] Not found nextCombinator. expression:{expression}");
                break;
            }
            Debug.Log($"[Run 1] nextCombinator:{nextCombinator} rest:{rest} expression:{expression}");

            switch (nextCombinator)
            {
                case 'S':
                    (isOk, expression) = SolveSCombinator(calculationProcess, rest);
                    break;
                case 'K':
                    (isOk, expression) = SolveKCombinator(calculationProcess, rest);
                    break;
                case 'I':
                    (isOk, expression) = SolveICombinator(calculationProcess, rest);
                    break;
            }

            if (!isOk)
            {
                Debug.Log($"[Run] Failed. rest:{rest}");
                break;
            }

            Debug.Log($"[Run 2] restExpression:{expression}");
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
        (isOk, arg1, rest) = Parse(rest);
        if (!isOk)
        {
            return (false, "");
        }
        (isOk, arg2, rest) = Parse(rest);
        if (!isOk)
        {
            return (false, "");
        }
        (isOk, arg3, rest) = Parse(rest);
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
        (isOk, arg1, rest) = Parse(rest);
        if (!isOk)
        {
            return (false, "");
        }
        (isOk, arg2, rest) = Parse(rest);
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
        (isOk, arg1, rest) = Parse(rest);
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
    /// �ۂ������𔍂�
    /// </summary>
    /// <returns></returns>
    private static (bool, string) StripParentheses(int start, string expression)
    {
        // �Ή����� `)` ����������
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
                        // �擪�� `(` �ƁA�Ή����� `)` ��������������
                        string left = string.Empty;
                        if (0 < start)
                        {
                            left = expression[0..start];
                        }
                        var middle = expression[(start + 1)..i];
                        var right = expression[(i + 1)..];
                        Debug.Log($"[StripParentheses] expression:{expression} start:{start} i:{i} ��{left}��{middle}��{right}��");
                        var newExpression = $"{left}{middle}{right}";
                        return (true, newExpression);
                    }
                    break;

            }
        }

        // �\���G���[
        Debug.Log($"[StripParentheses] �\���G���[ expression:{expression} start:{start} nested:{nested} i:{i}");
        return (false, "");
    }

    private static (bool, char, string) NextCombinator(StringBuilder calculationProcess, string expression1)
    {
        var rest = expression1;
        var i = 0;

        while (0 < rest.Length)
        {
            char first = rest[i];

            switch (first)
            {
                case 'S':
                case 'K':
                case 'I':
                    return (true, first, rest[1..]);

                case '(':
                    {
                        // �ۂ������𔍂�
                        bool isOk;
                        (isOk, rest) = StripParentheses(i, rest);
                        if (!isOk)
                        {
                            // �\���G���[
                            Debug.Log("[NextCombinator] �\���G���[");
                            return (false, ' ', "");
                        }

                        calculationProcess.AppendLine($"    stripped {rest}");
                        i = 0;
                        break;
                    }

                default:
                    {
                        // �ϐ��ƕ��������͓ǂݔ�΂��܂�
                        if (variableCharacters.Contains(first) || first == ')')
                        {
                            i++;
                        }
                        else
                        {
                            // �v�Z�s�\
                            Debug.Log($"[NextCombinator] �v�Z�s�\ i:{i} first:{first} rest:{rest}");
                            return (false, ' ', "");
                        }
                    }
                    break;
            }
        }

        // �󕶎�����w�莞
        return (false, ' ', "");
    }

    private static (bool, string, string) Parse(string expression)
    {
        if (expression.Length < 1)
        {
            Debug.Log("[Parse] �󕶎���");
            return (false, "", "");
        }

        var first = expression[0];

        if (first == '(')
        {
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
                            return (true, expression[0..(i + 1)], expression[(i + 1)..]);
                        }
                        break;

                }
            }

            // �\���G���[
            Debug.Log("[Parse] �\���G���[1");
            return (false, "", "");
        }

        if (combinatorCharacters.Contains(first) || variableCharacters.Contains(first))
        {
            return (true, $"{first}", expression[1..]);
        }

        Debug.Log("[Parse] �\���G���[2");
        return (false, "", "");
    }
}
