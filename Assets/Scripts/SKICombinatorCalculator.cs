using Assets.Scripts.SKICombinatorCalculus.Text;
using Assets.Scripts.SKICombinatorCalculus.Tree;

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
        // テキスト型のパーサー
        string rightText = workingTree.ToString();
        return TextTypeParser.Parse(rightText);
    }
}
