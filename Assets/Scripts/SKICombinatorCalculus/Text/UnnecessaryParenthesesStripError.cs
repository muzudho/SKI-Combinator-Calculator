namespace Assets.Scripts.SKICombinatorCalculus
{
    internal enum UnnecessaryParenthesesStripError
    {
        /// <summary>
        /// エラーなし
        /// </summary>
        None,

        /// <summary>
        /// 右側にコンビネーターまたは変数が無いケース
        /// </summary>
        NotFoundArgument,

        /// <summary>
        /// 構文エラー
        /// </summary>
        Sintax,
    }
}
