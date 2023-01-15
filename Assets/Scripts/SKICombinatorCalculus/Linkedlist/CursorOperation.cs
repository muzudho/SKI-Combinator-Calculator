using UnityEngine;

namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    internal static class CursorOperation
    {
        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="expression">空白除去済みの式</param>
        /// <returns>topLevelStartElement</returns>
        public static StartElement Spawn(string expression)
        {
            // トップ・レベルの始端と終端
            StartElement topLevelStartElement = new StartElement(new EndElement(null));

            var cursor = new Cursor(topLevelStartElement);

            // 先頭から順に書いていくだけ
            foreach (var ch in expression)
            {
                cursor.Write(ch);
            }

            return topLevelStartElement;
        }

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
            Debug.Log("不要な丸括弧の除去開始");

            Parentheses parentheses = FindParenthesesEachElement(topLevelStartElement);
            if (parentheses == null)
            {
                Debug.Log("丸括弧 not found");
                return false;
            }

            Debug.Log($"丸括弧発見 parentheses:{parentheses}");

            bool necessary = CheckNecessaryParentheses(parentheses);
            if (!necessary)
            {
                Debug.Log("丸括弧 不要");
                StripParentheses(parentheses);

                Debug.Log("丸括弧 除去済");
                return true;
            }

            Debug.Log("丸括弧 必要");
            return false;
        }

        /// <summary>
        /// 丸括弧を探す
        /// </summary>
        private static Parentheses FindParenthesesEachElement(IElement topLevelStartElement)
        {
            Debug.Log($"丸括弧を探す topLevelStartElement:{topLevelStartElement}");

            var cursor = new Cursor(topLevelStartElement);

            for (IElement current = cursor.ReadElement(); current != null; current = cursor.ReadElement())
            {
                Debug.Log($"丸括弧を探す current:{current}");

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

            Debug.Log($"丸括弧必要判定 variable:{variable}");

            return 1 < variable;
        }

        /// <summary>
        /// TODO 丸括弧を剥がす
        /// </summary>
        private static void StripParentheses(Parentheses parentheses)
        {
            // 丸括弧の中身
            var expression = parentheses.ToString();
            Debug.Log($"丸括弧の中身 expression:{expression}");

            // 生成
            StartElement topLevelStartElement = CursorOperation.Spawn(expression);

            var previous = parentheses.Previous;

            // 丸括弧の削除
            parentheses.Remove();

            // 挿入
            previous.InsertNext(topLevelStartElement);
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
