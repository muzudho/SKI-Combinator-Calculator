using System.Collections;
using System.Collections.Generic;
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
        // �擪�̂P�������擾
        var (isOk, ch) = ExtractFirst(expression.TrimStart());

        return $"{ch}";
    }

    private static (bool, char) ExtractFirst(string expression)
    {
        var first = expression[0];

        switch (first)
        {
            case 'S':
                return (true, first);
        }

        return (false, ' ');
    }

}
