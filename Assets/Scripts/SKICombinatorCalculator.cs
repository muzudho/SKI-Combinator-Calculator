using Assets.Scripts.SKICombinatorCalculus.Linkedlist;
using Assets.Scripts.SKICombinatorCalculus.Text;
using Assets.Scripts.SKICombinatorCalculus.Tree;
using System.Text;

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
    public static string Run(string inputText, WorkingTree workingTree)
    {
        // �����N���X�g�^�̃p�[�T�[
        var linkedlistTypeParserResult = LinkedlistTypeParser.Parse(inputText);

        // �c���[�^�̃p�[�T�[
        var treeTypeParser = new TreeTypeParser();
        var treeTypeResult = treeTypeParser.Parse(workingTree);

        // �e�L�X�g�^�̃p�[�T�[
        string rightText = workingTree.ToString();
        var textTypeResult = TextTypeParser.Parse(rightText);

        return $@"Linked type parser

{linkedlistTypeParserResult}

--------

Tree type parser

{treeTypeResult}

--------

Text type parser

{textTypeResult}
";
    }
}
