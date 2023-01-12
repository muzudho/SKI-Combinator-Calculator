using System.Collections;
using System.Collections.Generic;
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
        // 先頭の１文字を取得
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
