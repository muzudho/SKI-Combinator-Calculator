using Assets.Scripts.SKICombinatorCalculus.Linkedlist;
using Assets.Scripts.SKICombinatorCalculus.Text;
using Assets.Scripts.SKICombinatorCalculus.Tree;
using System.Text;

internal class SKICombinatorCalculator
{
    public static string combinatorCharacters = "SKI";
    public static string variableCharacters = "abcdefghijklmnopqrstuvwxyz";

    /// <summary>
    /// 全ての半角空白を除去
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static string TrimAllSpaces(string source)
    {
        return source.Replace(" ", "");
    }

    /// <summary>
    /// 計算実行
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static string Run(string inputText, WorkingTree workingTree)
    {
        // リンクリスト型のパーサー
        var linkedlistTypeParserResult = LinkedlistTypeParser.Parse(inputText);

        // ツリー型のパーサー
        var treeTypeParser = new TreeTypeParser();
        var treeTypeResult = treeTypeParser.Parse(workingTree);

        // テキスト型のパーサー
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
