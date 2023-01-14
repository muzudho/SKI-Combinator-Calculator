namespace Assets.Scripts.SKICombinatorCalculus
{
    using System.Text;

    internal static class SCombinatorAsTextType
    {
        /// <summary>
        /// カーソルは 0 から始まります
        /// </summary>
        /// <param name="calculationProcess"></param>
        /// <param name="start"></param>
        /// <param name="rest"></param>
        /// <returns></returns>
        public static (bool, string) Solve(StringBuilder calculationProcess, string rest)
        {
            bool isOk;
            string arg1;
            string arg2;
            string arg3;
            (isOk, arg1, rest) = RightOfCursor.Parse(rest);
            if (!isOk)
            {
                return (false, "");
            }

            ParentesesAsTextType.Strip(
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

            ParentesesAsTextType.Strip(
                expression: arg2,
                onOk: (value) =>
                {
                    arg2 = value;
                });

            (isOk, arg3, rest) = RightOfCursor.Parse(rest);
            if (!isOk)
            {
                return (false, "");
            }

            ParentesesAsTextType.Strip(
                expression: arg3,
                onOk: (value) =>
                {
                    arg3 = value;
                });

            calculationProcess.AppendLine($@"
    S
      1 {arg1}
      2 {arg2}
      3 {arg3}
      _ {rest}
");

            return (true, $"{arg1}{arg3}({arg2}{arg3}){rest}");
        }

    }
}
