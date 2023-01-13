﻿namespace Assets.Scripts.SKICombinatorCalculus
{
    using Assets.Scripts.SKICombinatorCalculus.Models;
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

            ICombinatorModel iCombinatorModel = new ICombinatorModel(arg1);

            calculationProcess.AppendLine($@"{iCombinatorModel.ToString()}
      _ {rest}
");

            return (true, $"{arg1}{rest}");
        }
    }
}
