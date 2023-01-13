using Assets.Scripts.SKICombinatorCalculus.Text;
using Assets.Scripts.SKICombinatorCalculus.Tree;
using System.Text;

internal class SKICombinatorCalculator
{
    public static string combinatorCharacters = "SKI";
    public static string variableCharacters = "abcdefghijklmnopqrstuvwxyz";

    /// <summary>
    /// 計算実行
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static string Run(WorkingTree workingTree)
    {
        // ツリー型のパーサー
        var treeTypeParser = new TreeTypeParser();
        var treeTypeResult = treeTypeParser.Parse();

        // テキスト型のパーサー
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
