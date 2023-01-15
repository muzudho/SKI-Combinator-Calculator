namespace Assets.Scripts.SKICombinatorCalculus
{
    using System.Text;

    internal static class KCombinatorAsTextType
    {
        /// <summary>
        /// カーソルは 0 から始まります
        /// </summary>
        /// <param name="calculationProcess"></param>
        /// <param name="rest"></param>
        /// <returns></returns>
        public static (bool, string) Solve(StringBuilder calculationProcess, string rest)
        {
            bool isOk;
            string arg1;
            string arg2;
            (isOk, arg1, rest) = RightOfCursor.Parse(rest);
            if (!isOk)
            {
                return (false, "");
            }

            ParenthesesAsTextType.Strip(
                expression: arg1,
                onOk: (value) =>
                {
                    arg1 = value;
                });

            (isOk, arg2, rest) = RightOfCursor.Parse(rest);
            if (!isOk)
            {
                return (false, "");
            }

            ParenthesesAsTextType.Strip(
                expression: arg2,
                onOk: (value) =>
                {
                    arg2 = value;
                });

            calculationProcess.AppendLine($@"
    K
      1 {arg1}
      2 {arg2}
      _ {rest}
");

            return (true, $"{arg1}{rest}");
        }
    }
}
