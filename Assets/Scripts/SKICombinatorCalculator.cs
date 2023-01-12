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
                    // TODO �Ή����� `)` ����������
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
                                    // �擪�� `(` �ƁA�Ή����� `)` ��������������
                                    expression = $"{expression.Substring(1, i)}{expression.Substring(i + 1)}";
                                    goto after_loop;
                                }
                                break;

                        }
                    }
                after_loop:
                    break;

                // �v�Z�s�\
                default:
                    return (false, ' ');
            }
        }

        // �󕶎�����w�莞
        return (false, ' ');
    }

    private static (bool, string) SolveFirst(string expression)
    {
        var first = expression[0];
        var rest = expression[1..];

        switch (first)
        {
            case 'S':
                // TODO ���̂ЂƂ����܂���擾
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
