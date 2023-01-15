namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist.Process
{
    /// <summary>
    /// 計算過程
    /// </summary>
    internal class CalculationProcess
    {
        public CalculationProcess(string combinator, string arg1 = "", string arg2 = "", string arg3 = "")
        {
            Combinator = combinator;
            Arg1 = arg1;
            Arg2 = arg2;
            Arg3 = arg3;
        }

        public string Combinator { get; private set; }
        public string Arg1 { get; private set; }
        public string Arg2 { get; private set; }
        public string Arg3 { get; private set; }

        public override string ToString()
        {
            switch (Combinator)
            {
                case "S":
                    return $@"    S
      1 {Arg1}
      2 {Arg2}
      3 {Arg3}
";

                case "K":
                    return $@"    K
      1 {Arg1}
      2 {Arg2}
";

                case "I":
                    return $@"    I
      1 {Arg1}
";

                default:
                    throw new System.Exception("unexpected combinator:{Combinator}");
            }
        }
    }
}
