using Assets.Scripts.SKICombinatorCalculus.Linkedlist;
using Assets.Scripts.SKICombinatorCalculus.Text;

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
        // TODO �ۊ��ʂ̍ō���D�悵�ĕ]���������i�܂� children[0] �̃e�L�X�g�m�[�h���H�j
        //      - "(Sxyz...)"
        //      - "(Kxy...)"
        //      - "(Ix...)"
        // �̂悤�Ȃ��̂ɊY������΁A�]������Ηǂ����������B
        // �����ŁA xyz �� �ۊ��ʂł͂Ȃ����̂Ƃ���
        //
        // xyz ���ۊ��ʂł���΁A���̒���D�悵����
        //
        // �]���ł��Ȃ��ۊ��ʂł���΁A �]���̗D�揇�ʂ�������
        //
        // �܂��A
        //      - "aSbcde"
        // �̂悤�� �ō��ɕϐ��������ꍇ�́A����𖳎����Ē��߂̉E�̃R���r�l�[�^�[��]������

        // �����N���X�g�^�̃p�[�T�[
        LinkedlistTypeParser.DoAsserts();
        
        // return "";
        
        var linkedlistTypeParserResult = LinkedlistTypeParser.Parse(inputText);

        // �e�L�X�g�^�̃p�[�T�[
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
