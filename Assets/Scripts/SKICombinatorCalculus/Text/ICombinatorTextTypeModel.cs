using UnityEngine;

namespace Assets.Scripts.SKICombinatorCalculus.Models
{
    internal class ICombinatorTextTypeModel
    {
        public ICombinatorTextTypeModel(string arg1)
        {
            this.arg1 = arg1;
        }

        public string arg1 { get; set; }

        public override string ToString()
        {
            return $@"
    I
      1 {arg1}
";
        }
    }
}
