namespace Assets.Scripts.SKICombinatorCalculus.Models
{
    using UnityEngine;

    internal class KCombinatorModel
    {
        public KCombinatorModel(string arg1, string arg2)
        {
            this.arg1 = arg1;
            this.arg2 = arg2;
        }

        public string arg1 { get; set; }
        public string arg2 { get; set; }

        public override string ToString()
        {
            return $@"
    K
      1 {arg1}
      2 {arg2}
";
        }
    }
}
