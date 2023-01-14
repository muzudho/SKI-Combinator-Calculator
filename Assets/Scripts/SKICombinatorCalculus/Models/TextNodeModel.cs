namespace Assets.Scripts.SKICombinatorCalculus.Models
{
    /// <summary>
    /// テキスト・ノード
    /// </summary>
    internal class TextNodeModel : INodeModel
    {
        public TextNodeModel(string text)
        {
            Text = text;
        }

        public string Text { get; set; }
    }
}
