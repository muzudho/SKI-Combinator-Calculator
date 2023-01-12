using Assets.Scripts.SKICombinatorCalculus;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// ������̃J�[�\�����E��
/// </summary>
public static class RightOfCursor
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
                        // �ۂ������𔍂��i�����Ȃ��P�[�X������j
                        var (error, rest2) = StripParentheses(i, rest);
                        switch (error)
                        {
                            case StripParenthesesError.None:
                                rest = rest2;
                                calculationProcess.AppendLine($"    stripped {rest}");
                                i = 0;
                                break;

                            case StripParenthesesError.NotFoundArgument:
                                // ����ȋ����B�G���[�ł͂Ȃ�
                                // calculationProcess.AppendLine($"    can't stripped {rest}");
                                i++;
                                break;

                            case StripParenthesesError.Sintax:
                                // �\���G���[
                                calculationProcess.AppendLine($"    sintax error. rest:{rest}");
                                Debug.Log("[NextCombinator] �\���G���[");
                                return (false, "", ' ', "");

                            default:
                                throw new System.Exception();
                        }

                        break;
                    }

                default:
                    {
                        // �ϐ��ƕ��������͓ǂݔ�΂��܂�
                        if (SKICombinatorCalculator.variableCharacters.Contains(cursor) || cursor == ')')
                        {
                            // calculationProcess.AppendLine($"    ... i:{i}");
                            i++;
                        }
                        else
                        {
                            // �v�Z�s�\
                            // calculationProcess.AppendLine($"    incalculable. i:{i}");
                            Debug.Log($"[NextCombinator] �v�Z�s�\ i:{i} first:{cursor} rest:{rest}");
                            return (false, "", ' ', "");
                        }
                    }
                    break;
            }
        }

        // - �󕶎�����w�莞
        // - �v�Z����I����
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

    /// <summary>
    /// �ۂ������𔍂�
    /// 
    /// - �������A�J���ۊ��ʂɑΉ�������ۊ��ʂ̉E���ɁA�R���r�l�[�^�[�A�܂��͕ϐ�����������Ȃ��ꍇ�� ���̊ۊ��ʂ͔����Ȃ�
    /// </summary>
    /// <returns></returns>
    private static (StripParenthesesError, string) StripParentheses(int start, string expression)
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
                        // �����ŒT����ł��؂邪�A�E���ɃR���r�l�[�^�[���ϐ������邩�m�F
                        {
                            string rest = expression[(i + 1)..];
                            rest = rest.Replace(")", "");
                            rest = rest.Replace("(", "");
                            if (rest.Length < 1)
                            {
                                // �\���G���[
                                Debug.Log($"[StripParentheses] �ۊ��ʂ𔍂��Ȃ��P�[�X������ rest:{expression[(i + 1)..]}");
                                return (StripParenthesesError.NotFoundArgument, "");
                            }
                        }

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
                        return (StripParenthesesError.None, newExpression);
                    }
                    break;

            }
        }

        // �\���G���[
        Debug.Log($"[StripParentheses] �\���G���[ expression:{expression} start:{start} nested:{nested} i:{i}");
        return (StripParenthesesError.Sintax, "");
    }

    private static (bool, string, string) Parse(int start, string expression)
    {
        if (expression.Length <= start)
        {
            Debug.Log($"[Parse] �I�[�o�[ length:{expression.Length} start:{start}");
            return (false, "", "");
        }

        var cursor = expression[start];

        if (cursor == '(')
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

        if (SKICombinatorCalculator.combinatorCharacters.Contains(cursor) || SKICombinatorCalculator.variableCharacters.Contains(cursor))
        {
            return (true, $"{cursor}", expression[1..]);
        }

        Debug.Log("[Parse] �\���G���[2");
        return (false, "", "");
    }
}
