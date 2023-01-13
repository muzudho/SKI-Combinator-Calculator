using Assets.Scripts.SKICombinatorCalculus;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

internal class SKICombinatorCalculator
{
    public static string combinatorCharacters = "SKI";
    public static string variableCharacters = "abcdefghijklmnopqrstuvwxyz";

    /// <summary>
    /// �S�Ă̔��p�󔒂�����
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static string TrimAllSpaces(string source)
    {
        return source.Replace(" ", "");
    }

    /// <summary>
    /// �v�Z���s
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static string Run(string inputText)
    {
        // �v�Z�ߒ�
        StringBuilder calculationProcess = new StringBuilder();
        calculationProcess.AppendLine(inputText);

        string leftText;
        // �󔒂͋l�߂�
        string rightText = TrimAllSpaces(inputText);

        if (inputText!=rightText)
        {
            calculationProcess.AppendLine($"    formatting {rightText}");
        }

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
            char nextCombinator;
            (isOk, leftText, nextCombinator, rightText) = RightOfCursor.NextCombinator(calculationProcess, rightText);
            if (!isOk)
            {
                Debug.Log($"[Run] Not found nextCombinator");
                break;
            }
            Debug.Log($"[Run 1] leftText:{leftText} nextCombinator:{nextCombinator} rightText:{rightText}");

            switch (nextCombinator)
            {
                case 'S':
                    (isOk, rightText) = SCombinator.Solve(calculationProcess, rightText);
                    break;
                case 'K':
                    (isOk, rightText) = KCombinator.Solve(calculationProcess, rightText);
                    break;
                case 'I':
                    (isOk, rightText) = ICombinator.Solve(calculationProcess, rightText);
                    break;
            }

            if (!isOk)
            {
                Debug.Log($"[Run] Failed");
                break;
            }

            // �E�e�L�X�g�ɂ܂Ƃ߂�
            Debug.Log($"[Run 2] leftText:{leftText} rightText:{rightText}");
            rightText = $"{leftText}{rightText}";
            leftText = "";
            calculationProcess.AppendLine(rightText);
        }

        return calculationProcess.ToString();
    }
}
