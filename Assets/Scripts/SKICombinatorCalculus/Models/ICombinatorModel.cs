namespace Assets.Scripts.SKICombinatorCalculus.Models
{
    internal class ICombinatorModel
    {
        public ICombinatorModel(NodeContainer arg1)
        {
            this.arg1 = arg1;
        }

        public NodeContainer arg1 { get; set; }

        public override string ToString()
        {
            return $@"
    I
      1 {arg1.ToString()}
";
        }
    }
}
