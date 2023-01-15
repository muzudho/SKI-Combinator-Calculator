namespace Assets.Scripts.SKICombinatorCalculus
{
    /// <summary>
    /// "(xyz)" のように、 "(" で始まり、")" で終わるような文字列
    /// </summary>
    internal static class ParenthesesAsTextType
    {
        public delegate void SetString(string value);

        /// <summary>
        /// 左端の "(" と、 右端の ")" を外す
        /// </summary>
        public static bool Strip(string expression, SetString onOk)
        {
            if (expression.Length <= 1)
            {
                return false;
            }

            if (expression[0] != '(' || expression[expression.Length-1] != ')')
            {
                return false;
            }

            onOk(expression[1..(expression.Length - 1)]);

            return true;
        }
    }
}
