namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    internal static class SpawnHelper
    {
        public static Placeholder SpawnPlaceholderByText(string expression)
        {
            // 両端は丸括弧か？
            bool withParentheses = expression[0] == '(' && expression[expression.Length - 1] == ')';

            // トップ・レベル
            var newTopLevel = new Placeholder(withParentheses: withParentheses);

            // 両端の丸括弧は外す
            if (withParentheses)
            {
                expression = expression[1..(expression.Length - 1)];
            }

            // 構築
            {
                var cursor = new CursorIO(newTopLevel.FirstCap);

                // 先頭から順に書いていくだけ
                foreach (var ch in expression)
                {
                    cursor.Write(ch);
                }
            }

            return newTopLevel;
        }
    }
}
