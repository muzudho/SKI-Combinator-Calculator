namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    using Assets.Scripts.SKICombinatorCalculus.Linkedlist.Process;
    using System;
    using System.Text;
    using UnityEngine.Assertions;

    internal static class CursorOperation
    {
        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="expression">空白除去済みの式</param>
        /// <returns>topLevelStartElement</returns>
        public static Placeholder Spawn(string expression)
        {
            // トップ・レベル
            Placeholder topLevel = new Placeholder(withParentheses: false);

            var cursor = new CursorIO(topLevel.FirstCap);

            // 先頭から順に書いていくだけ
            foreach (var ch in expression)
            {
                cursor.Write(ch);
            }

            return topLevel;
        }

        /// <summary>
        /// 兄弟の最後の要素を取得
        /// 
        /// - `GetEndElementEachSibling()` を使いたい
        /// - 最初の要素と同一のケースを含む
        /// </summary>
        /// <param name="elementAsStart"></param>
        /// <returns></returns>
        [Obsolete]
        public static IElement GetLastSiblingOfContentWithoutEndElement(IElement elementAsStart)
        {
            var cursor = new CursorIO(elementAsStart);

            IElement current = cursor.ReadElementWithoutEndElement();

            while (current != null)
            {
                IElement previous = current;

                // Next
                current = cursor.ReadElementWithoutEndElement();

                // Over
                if (current == null)
                {
                    return previous;
                }
            }

            // 必ず取得できるはずなので、エラー
            throw new System.Exception($"[CursorOperation GetEndElement] failed 1");
        }

        /// <summary>
        /// 兄弟の最後の要素を取得
        /// 
        /// - `GetEndElementEachSibling()` を使いたい
        /// - 最初の要素と同一のケースを含む
        /// </summary>
        /// <param name="elementAsStart"></param>
        /// <returns></returns>
        [Obsolete]
        public static IElement GetLastSiblingWithinEndElement(IElement elementAsStart)
        {
            var cursor = new CursorIO(elementAsStart);

            IElement current = cursor.ReadElementWithinEndElement();

            while (current != null)
            {
                IElement previous = current;

                // Next
                current = cursor.ReadElementWithinEndElement();

                // Over
                if (current == null)
                {
                    return previous;
                }
            }

            // 必ず取得できるはずなので、エラー
            throw new System.Exception($"[CursorOperation GetEndElement] failed 1");
        }

        /// <summary>
        /// 兄弟の最後の要素を取得
        /// 
        /// - 最初の要素と同一のケースを含む
        /// </summary>
        /// <param name="elementAsStart"></param>
        /// <returns></returns>
        public static IElement GetEndElementEachSibling(IElement elementAsStart)
        {
            var cursor = new CursorIO(elementAsStart);

            IElement current = cursor.ReadElementWithinEndElement();
            // Debug.Log($"[CursorOperation GetEndElementEachSibling] current:{current} {current.GetType().Name}");
            if (current == null)
            {
                throw new System.Exception("[CursorOperation GetEndElementEachSibling] null 1");
            }

            while (!(current is LastCap))
            {
                // Next
                current = cursor.ReadElementWithinEndElement();
                if (current == null)
                {
                    throw new System.Exception("[CursorOperation GetEndElementEachSibling] null 2");
                }

                // Debug.Log($"[CursorOperation GetEndElementEachSibling] current:{current} {current.GetType().Name}");
            }

            // `)`
            Assert.IsTrue(current is LastCap);
            return current;
        }

        /// <summary>
        /// 評価
        /// </summary>
        public static CalculationProcess EvaluateElements(CursorIO cursor)
        {
            IElement element0 = cursor.ReadElementWithinEndElement();
            // Debug.Log($"[EvaluateElements] element0:{element0}");

            while (element0 != null)
            {
                if (element0 is ICombinator combinator)
                {
                    if (combinator is IdCombinator)
                    {
                        var arg1 = cursor.ReadElementWithinEndElement();

                        if (arg1 == null || arg1 is LastCap)
                        {
                            // `I` しかないケース
                            return null;
                        }

                        // Debug.Log($"[EvaluateElements] I arg1:{arg1}");

                        combinator.Remove();
                        return new CalculationProcess(
                            combinator: "I",
                            arg1: arg1.ToString());
                    }
                    else if (combinator is KCombinator)
                    {
                        var arg1 = cursor.ReadElementWithinEndElement();
                        var arg2 = cursor.ReadElementWithinEndElement();

                        if (arg2 == null || arg2 is LastCap)
                        {
                            // `K` や、 `Kx` しかないケース
                            return null;
                        }

                        // Debug.Log($"[EvaluateElements] K arg1:{arg1} arg2:{arg2}");

                        combinator.Remove();
                        arg2.Remove();
                        return new CalculationProcess(
                            combinator: "K",
                            arg1: arg1.ToString(),
                            arg2: arg2.ToString());
                    }
                    else if (combinator is SCombinator)
                    {
                        var arg1 = cursor.ReadElementWithinEndElement();
                        var arg2 = cursor.ReadElementWithinEndElement();
                        var arg3 = cursor.ReadElementWithinEndElement();

                        if (arg3 == null || arg3 is LastCap)
                        {
                            // `S` や、 `Sa` や、 `Sab` しかないケース
                            return null;
                        }

                        // Debug.Log($"[EvaluateElements] S 1:{arg1} 2:{arg2} 3:{arg3}");

                        // とりあえず、引数を全部抜く
                        arg1.Remove();
                        arg2.Remove();
                        arg3.Remove();

                        // 複製
                        var clone1 = arg1.Duplicate();
                        var clone2 = arg3.Duplicate();
                        var clone3o1 = arg2.Duplicate();
                        var clone3o2 = arg3.Duplicate();

                        // Debug.Log($"[EvaluateElements] S clone1:{clone1} clone2:{clone2} clone3o1:{clone3o1} clone3o2:{clone3o2}");

                        Placeholder clone3 = new Placeholder(withParentheses: true);
                        clone3.StepIn().InsertNext(clone3o1).InsertNext(clone3o2);

                        // Debug.Log($"[EvaluateElements] S clone3:{clone3}");

                        // 複製を追加する
                        // FIXME 丸括弧を追加するときに不具合がある？
                        combinator.InsertNext(clone1).InsertNext(clone2).InsertNext(clone3);

                        // Debug.Log($"[EvaluateElements] S Result:{CursorOperation.Stringify(cursor.GetSourceElement())}");

                        // コンビネーター削除
                        combinator.Remove();
                        return new CalculationProcess(
                            combinator: "S",
                            arg1: arg1.ToString(),
                            arg2: arg2.ToString(),
                            arg3: arg3.ToString());
                    }

                    throw new System.Exception($"unknown combinator:{combinator.GetType().Name}");
                }
                else if (element0 is Variable || element0 is FirstCap || element0 is LastCap)
                {
                    // 変数、`(`、`)` なら評価はできない
                }
                else if (element0 is Placeholder parentheses)
                {
                    // Debug.Log($"丸括弧のケース parentheses:{parentheses.ToString()}");
                    // TODO 丸括弧を外していいケースかどうかは、ここでは分からない

                    // 丸括弧の内側を（再帰的に）評価することはできるだろう
                    cursor.StepIn(); // `(`
                    cursor.ReadChar(); // 丸括弧の内側の先頭要素
                    // Debug.Log($"丸括弧のケース Current:{cursor.ToCurrentString()}");
                    var calculationProcess = EvaluateElements(cursor); // 再帰

                    // TODO 丸括弧の右側を評価してはいけない
                    return calculationProcess;
                }

                // 次の要素へ、読み進める
                element0 = cursor.ReadElementWithinEndElement();
            }

            // 何も評価せず、終端まで来てしまった
            return null;
        }
    }
}
