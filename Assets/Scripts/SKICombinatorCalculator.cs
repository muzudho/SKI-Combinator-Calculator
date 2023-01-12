using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SKICombinatorCalculator
{
    public static string combinatorCharacters = "SKI";
    public static string variableCharacters = "abcdefghijklmnopqrstuvwxyz";

    /// <summary>
    /// �v�Z���s
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static string Run(string inputText)
    {
        string leftText;
        // �󔒂͋l�߂�
        string rightText = inputText.Replace(" ", "");

        // �v�Z�ߒ�
        StringBuilder calculationProcess = new StringBuilder();
        calculationProcess.AppendLine(inputText);

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

            int startInRightText = 0;
            switch (nextCombinator)
            {
                case 'S':
                    (isOk, rightText) = RightOfCursor.SolveSCombinator(calculationProcess, startInRightText, rightText);
                    break;
                case 'K':
                    (isOk, rightText) = RightOfCursor.SolveKCombinator(calculationProcess, startInRightText, rightText);
                    break;
                case 'I':
                    (isOk, rightText) = RightOfCursor.SolveICombinator(calculationProcess, startInRightText, rightText);
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
