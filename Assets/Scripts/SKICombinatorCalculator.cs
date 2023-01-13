using Assets.Scripts.SKICombinatorCalculus.Text;
using Assets.Scripts.SKICombinatorCalculus.Tree;

internal class SKICombinatorCalculator
{
    public static string combinatorCharacters = "SKI";
    public static string variableCharacters = "abcdefghijklmnopqrstuvwxyz";

    /// <summary>
    /// �v�Z���s
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static string Run(WorkingTree workingTree)
    {
        // �e�L�X�g�^�̃p�[�T�[
        string rightText = workingTree.ToString();
        return TextTypeParser.Parse(rightText);
    }
}
