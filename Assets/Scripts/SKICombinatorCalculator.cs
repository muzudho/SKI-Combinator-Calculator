using Assets.Scripts.SKICombinatorCalculus.Text;
using Assets.Scripts.SKICombinatorCalculus.Tree;
using System.Text;

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
        // �c���[�^�̃p�[�T�[
        var treeTypeParser = new TreeTypeParser();
        var treeTypeResult = treeTypeParser.Parse();

        // �e�L�X�g�^�̃p�[�T�[
        string rightText = workingTree.ToString();
        var textTypeResult = TextTypeParser.Parse(rightText);

        return $@"Tree type parser

{treeTypeResult}

----------
Text type parser

{textTypeResult}
";
    }
}
