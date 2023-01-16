namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    using UnityEngine;
    using UnityEngine.Assertions;

    internal static class StripUnnecessaryParentheses
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
        public static bool DoIt(Placeholder topLevel)
        {
            Assert.IsTrue(topLevel.FirstCap != null && topLevel.FirstCap is FirstCap);
            Assert.IsTrue(topLevel.FirstCap.Next != null);
            Debug.Log($"[StripUnnecessaryParentheses DoIt] topLevel.FirstCap:{topLevel.FirstCap.Next} {topLevel.FirstCap.Next.GetType().Name}");

            // Debug.Log("[不要な丸括弧の除去] 開始");

            // 最初の要素が丸括弧
            if (topLevel.FirstCap.Next is Placeholder placeholder1 && placeholder1.WithParentheses)
            {
                Debug.Log("[StripUnnecessaryParentheses DoIt] 最初の要素が丸括弧 不要");
                StripParentheses(placeholder1);
                Debug.Log($"[StripUnnecessaryParentheses DoIt] 最初の丸括弧の除去後 stringify:{CursorOperation.Stringify(topLevel)}");

                return true;
            }

            Placeholder parentheses = FindParenthesesEachElement(topLevel.FirstCap);
            if (parentheses == null)
            {
                Debug.Log("[不要な丸括弧の除去] 丸括弧 not found");
                return false;
            }

            // Debug.Log($"[不要な丸括弧の除去] 丸括弧発見 parentheses:{parentheses}");

            // 不要な丸括弧の特長

            bool necessary = CheckEmptyOrOneVariableParentheses(parentheses);
            if (!necessary)
            {
                Debug.Log("[不要な丸括弧の除去] 丸括弧 不要");
                StripParentheses(parentheses);

                Debug.Log("[不要な丸括弧の除去] true 丸括弧除去済");
                return true;
            }

            Debug.Log("[不要な丸括弧の除去] false 丸括弧必要");
            return false;
        }

        /// <summary>
        /// 丸括弧を探す
        /// </summary>
        private static Placeholder FindParenthesesEachElement(FirstCap topLevelFirstCap)
        {
            Assert.IsTrue(topLevelFirstCap != null);
            Debug.Log($"[FindParenthesesEachElement] topLevelFirstCap:{topLevelFirstCap} {topLevelFirstCap.GetType().Name}");

            var cursor = new CursorIO(topLevelFirstCap);

            for (IElement current = cursor.ReadElementWithinEndElement(); current != null; current = cursor.ReadElementWithinEndElement())
            {
                if (current is Placeholder placeholder1)
                {
                    if (placeholder1.WithParentheses)
                    {
                        Debug.Log($"[FindParenthesesEachElement] 発見 current:{current} {current.GetType().Name}");
                        return placeholder1;
                    }
                    else
                    {
                        Debug.Log($"[FindParenthesesEachElement] ★ ここでトップレベルはおかしい current:{current} {current.GetType().Name}");
                        return placeholder1;
                    }
                }
                else
                {
                    Debug.Log($"[FindParenthesesEachElement] current:{current} {current.GetType().Name}");
                }
            }

            Debug.Log($"[FindParenthesesEachElement] not found");
            return null;
        }

        /// <summary>
        /// `()` や、 `(x)` のような、１つ以下の変数しか含まない丸括弧かどうか判定する
        /// </summary>
        private static bool CheckEmptyOrOneVariableParentheses(Placeholder parentheses)
        {
            int variableNum = 0;

            var cursor = new CursorIO(parentheses.FirstCap);

            for (IElement current = cursor.ReadElementWithinEndElement(); current != null; current = cursor.ReadElementWithinEndElement())
            {
                Debug.Log($"[CheckEmptyOrOneVariableParentheses] Loop current:{current} {current.GetType().Name}");

                if (current is Variable)
                {
                    variableNum++;

                    if (2 <= variableNum)
                    {
                        // 変数が２個連続していたら、丸括弧は必要
                        Debug.Log($"[CheckEmptyOrOneVariableParentheses] true 変数が２個連続していたら、丸括弧は必要 current:{current} {current.GetType().Name}");
                        return true;
                    }
                }
                else if (current is FirstCap || current is LastCap)
                {
                    // Ignored
                }
                else
                {
                    // 変数以外が混じっていたなら
                    Debug.Log($"[CheckEmptyOrOneVariableParentheses] true 変数以外混合 current:{current} {current.GetType().Name}");
                    return true;
                }
            }

            // 変数が２個未満だから、丸括弧は不要
            Debug.Log($"[CheckEmptyOrOneVariableParentheses] 変数が２個未満だから不要 variable num:{variableNum}");
            return false;
        }

        /// <summary>
        /// 丸括弧を剥がす
        /// </summary>
        public static void StripParentheses(Placeholder parentheses)
        {
            Debug.Log($"[StripParentheses] ★★ 開始");
            Assert.IsTrue(parentheses is Placeholder);
            Debug.Log($"[StripParentheses] parentheses:{parentheses} withParentheses:{parentheses.WithParentheses}");

            Assert.IsTrue(parentheses is Placeholder placeholder1 && placeholder1.WithParentheses);

            // 前要素
            Assert.IsTrue(parentheses.Previous!=null);
            IElement newLeader = parentheses.Previous;
            Debug.Log($"[StripParentheses] newLeader:{newLeader} {newLeader.GetType().Name}");

            // - StartElement と EndElement が付いた状態が最小の単位なので、「丸括弧を剥がした状態」というものは、この設計の構造では存在しない
            // - そこで、リンクの貼り直しを行う

            // 元の丸括弧の削除
            parentheses.Remove();

            //// 丸括弧のクローン作成
            //Placeholder clonedParentheses = (Placeholder)parentheses.Duplicate();
            //Debug.Log($"[StripParentheses] clonedParentheses:{clonedParentheses} withParentheses:{clonedParentheses.WithParentheses}");

            // 丸括弧外す
            parentheses.SetupStripParenthses();
            Placeholder strippedPlaceholder = parentheses;
            Debug.Log($"[StripParentheses] stripped parentheses:{strippedPlaceholder} withParentheses:{strippedPlaceholder.WithParentheses}");

            // 挿入し直す
            newLeader.InsertNext(strippedPlaceholder);

            //// 丸括弧の中身の最初の要素
            //Debug.Log($"[StripParentheses] clonedParentheses(Top Level).StartElement:{clonedParentheses.FirstCap}");
            //IElement clonedFirstChild = clonedParentheses.FirstCap.Next;
            //Debug.Log($"[StripParentheses] clonedFirstChild:{clonedFirstChild}");

            //// - `()` のような空丸括弧のケースなら、単純にこの丸括弧を削除するだけでよい
            //// - それ以外のケースでは、リンクを貼り直す
            //if (!(clonedFirstChild is LastCap))
            //{
            //    // 丸括弧の中身の最後の要素
            //    IElement clonedLastChild = CursorOperation.GetEndElementEachSibling(clonedFirstChild).Previous;
            //    Debug.Log($"[StripParentheses] clonedLastChild:{clonedLastChild}");
            //    Debug.Log($"[StripParentheses] parentheses.Previous:{parentheses.Previous} {parentheses.Previous.GetType().Name}");
            //    Debug.Log($"[StripParentheses] parentheses.Next:{parentheses.Next} {parentheses.Next.GetType().Name}");

            //    // リンクの張り直し
            //    parentheses.InsertNext(clonedFirstChild);
            //}
        }
    }
}
