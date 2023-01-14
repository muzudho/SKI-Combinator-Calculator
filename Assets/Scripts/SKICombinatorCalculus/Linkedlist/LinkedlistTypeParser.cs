namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    using Assets.Scripts.SKICombinatorCalculus.Models;
    using Assets.Scripts.SKICombinatorCalculus.Tree;
    using System.Text;

    internal static class LinkedlistTypeParser
    {
        public static string Parse(string inputText)
        {
            StringBuilder calculationProcess = new StringBuilder();

            calculationProcess.AppendLine($@"Last state:
    {inputText}
");

            return calculationProcess.ToString();
        }
    }
}
