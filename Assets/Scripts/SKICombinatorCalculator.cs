using Assets.Scripts.SKICombinatorCalculus.Linkedlist;
using Assets.Scripts.SKICombinatorCalculus.Text;

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
    public static string Run(string inputText)
    {
        // TODO 丸括弧の最左を優先して評価したい（つまり children[0] のテキストノードか？）
        //      - "(Sxyz...)"
        //      - "(Kxy...)"
        //      - "(Ix...)"
        // のようなものに該当すれば、評価すれば良さそうだが。
        // ここで、 xyz は 丸括弧ではないものとする
        //
        // xyz が丸括弧であれば、その中を優先したい
        //
        // 評価できない丸括弧であれば、 評価の優先順位を下げる
        //
        // また、
        //      - "aSbcde"
        // のように 最左に変数がきた場合は、それを無視して直近の右のコンビネーターを評価する

        // リンクリスト型のパーサー
        LinkedlistTypeParser.DoAsserts();
        
        // return "";
        
        var linkedlistTypeParserResult = LinkedlistTypeParser.Parse(inputText);

        // テキスト型のパーサー
        var rightText = SKICombinatorCalculator.TrimAllSpaces(inputText);
        var textTypeResult = TextTypeParser.Parse(rightText);

        return $@"Linked type parser

{linkedlistTypeParserResult.CalculationProcess}

--------

Text type parser

{textTypeResult}
";

    }
}
