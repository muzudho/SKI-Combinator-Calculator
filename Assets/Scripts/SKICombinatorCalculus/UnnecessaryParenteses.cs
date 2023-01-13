namespace Assets.Scripts.SKICombinatorCalculus
{
    using UnityEngine;

    /// <summary>
    /// 不要な丸括弧（に対する操作）
    /// 
    /// 指定した開き括弧に対応する閉じ丸括弧を剥く（剥けないケースもある）
    /// </summary>
    internal static class UnnecessaryParenteses
    {
        /// <summary>
        /// 不要な丸かっこを剥く
        /// 
        /// - 指定した開き括弧に対応する閉じ丸括弧を剥く
        /// - ただし、正常な挙動として、剥けないケースもある（必要な丸括弧であるケース）
        ///     - 開き丸括弧に対応する閉じ丸括弧の右側に、コンビネーター、または変数が見当たらない場合は その丸括弧は剥かない
        ///     - `(x)` のように、コンビネーターまたは変数を１つしか含まないものは丸括弧を剥がす
        /// </summary>
        /// <returns></returns>
        public static (StripParenthesesError, string) Strip(string expression, int openParenthesesPos)
        {
            // 対応する `)` を消去する
            int i = openParenthesesPos + 1;
            var nested = 1;

            for (; i < expression.Length; i++)
            {
                var ch = expression[i];

                switch (ch)
                {
                    case '(':
                        nested++;
                        break;
                    case ')':
                        nested--;
                        if (nested == 0)
                        {
                            // `(x)` のようなケースでは丸括弧を剥がす
                            var willStrip = i - openParenthesesPos == 2;

                            // ここで探索を打ち切るが、右側にコンビネーターか変数があるか確認
                            if (!willStrip)
                            {
                                string rest = expression[(i + 1)..];
                                rest = rest.Replace(")", "");
                                rest = rest.Replace("(", "");
                                if (rest.Length < 1)
                                {
                                    // 構文エラー
                                    Debug.Log($"[StripParentheses] 丸括弧を剥けないケースだった rest:{expression[(i + 1)..]}");
                                    return (StripParenthesesError.NotFoundArgument, "");
                                }
                            }

                            // 先頭の `(` と、対応する `)` を消去した数式
                            string left = string.Empty;
                            if (0 < openParenthesesPos)
                            {
                                left = expression[0..openParenthesesPos];
                            }
                            var middle = expression[(openParenthesesPos + 1)..i];
                            var right = expression[(i + 1)..];
                            Debug.Log($"[StripParentheses] expression:{expression} start:{openParenthesesPos} i:{i} ◆{left}◆{middle}◆{right}◆");
                            var newExpression = $"{left}{middle}{right}";
                            return (StripParenthesesError.None, newExpression);
                        }
                        break;

                }
            }

            // 構文エラー
            Debug.Log($"[StripParentheses] 構文エラー expression:{expression} start:{openParenthesesPos} nested:{nested} i:{i}");
            return (StripParenthesesError.Sintax, "");
        }
    }
}
