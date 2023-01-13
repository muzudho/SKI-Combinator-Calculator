namespace Assets.Scripts.SKICombinatorCalculus
{
    using System.Text;

    internal static class ICombinator
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
            (isOk, arg1, rest) = RightOfCursor.Parse(rest);
            if (!isOk)
            {
                return (false, "");
            }

            Parenteses.Strip(
                expression: arg1,
                onOk: (value) =>
                {
                    arg1 = value;
                });

            calculationProcess.AppendLine($@"
    I
      1 {arg1}
      _ {rest}
");

            return (true, $"{arg1}{rest}");
        }
    }
}
