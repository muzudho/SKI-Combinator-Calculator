using UnityEngine.Assertions;

namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    internal static class CursorOperation
    {
        /// <summary>
        /// TODO 不要な丸括弧を剥く
        /// 
        /// ３つの要素がある
        /// 
        /// - 丸括弧を探す
        /// - その丸括弧が不要であるか判定する
        /// - 不要な丸括弧を剥く
        /// </summary>
        /// <returns></returns>
        public static bool StripUnnecessaryParentheses(IElement topLevelStartElement)
        {
            Parentheses parentheses = FindParenthesesEachElement(topLevelStartElement);
            if (parentheses == null)
            {
                return false;
            }

            bool necessary = CheckNecessaryParentheses(parentheses);
            if (!necessary)
            {
                ParserResult parserResult = StripParentheses(parentheses);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 丸括弧を探す
        /// </summary>
        private static Parentheses FindParenthesesEachElement(IElement topLevelStartElement)
        {
            var cursor = new Cursor(topLevelStartElement);

            for (IElement current = cursor.ReadElement(); current != null; current = cursor.ReadElement())
            {
                if (current is Parentheses parentheses)
                {
                    return parentheses;
                }
            }

            return null;
        }

        /// <summary>
        /// TODO 必要な丸括弧か判定する
        /// 
        /// - `()` や、 `(x)` のような、１つ以下の変数しか含まない丸括弧は不要
        /// </summary>
        private static bool CheckNecessaryParentheses(Parentheses parentheses)
        {
            int variable = 0;

            var cursor = new Cursor(parentheses.StartElement);

            for (IElement current = cursor.ReadElement(); current != null; current = cursor.ReadElement())
            {
                if (current is Variable)
                {
                    variable++;

                    if (2 <= variable)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            return variable < 2;
        }

        /// <summary>
        /// TODO 丸括弧を剥がす
        /// </summary>
        private static ParserResult StripParentheses(Parentheses parentheses)
        {
            // 丸括弧の中身
            var text = parentheses.ToString();

            // リンクリスト型のパーサー
            var parserResult = LinkedlistTypeParser.Parse(text);

            var previous = parentheses.Previous;

            // 丸括弧の削除
            parentheses.Remove();

            // 挿入
            previous.InsertNext(parserResult.StartElement);

            return parserResult;
        }

        /// <summary>
        /// 最後の要素を取得
        /// 
        /// - 最初の要素と同一のケースを含む
        /// </summary>
        /// <param name="elementAsStart"></param>
        /// <returns></returns>
        public static IElement GetEndElement(IElement elementAsStart)
        {
            var cursor = new Cursor(elementAsStart);

            IElement current = cursor.ReadElement();

            while (current != null)
            {
                IElement previous = current;

                // Next
                current = cursor.ReadElement();

                // Over
                if (current == null)
                {
                    return previous;
                }
            }

            // 必ず取得できるはずなので、エラー
            throw new System.Exception($"[CursorOperation GetEndElement] failed 1");
        }
    }
}
