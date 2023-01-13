namespace Assets.Scripts.SKICombinatorCalculus
{
    internal enum StripParenthesesError
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
