using Assets.Scripts.SKICombinatorCalculus;
using System.Text;
using UnityEngine;

/// <summary>
/// ������̃J�[�\�����E��
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
                        // �w�肵���J�����ʂɑΉ�������ۊ��ʂ𔍂��i�����Ȃ��P�[�X������j
                        var (error, rest2) = UnnecessaryParenteses.Strip(rest, i);
                        switch (error)
                        {
                            case UnnecessaryParenthesesStripError.None:
                                rest = rest2;
                                calculationProcess.AppendLine($"    stripped {rest}");
                                i = 0;
                                break;

                            case UnnecessaryParenthesesStripError.NotFoundArgument:
                                // ����ȋ����B�G���[�ł͂Ȃ�
                                // calculationProcess.AppendLine($"    can't stripped {rest}");
                                i++;
                                break;

                            case UnnecessaryParenthesesStripError.Sintax:
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




    /// <summary>
    /// �J�[�\���� 0 ����n�܂�܂�
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static (bool, string, string) Parse(string expression)
    {
        var start = 0;

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
