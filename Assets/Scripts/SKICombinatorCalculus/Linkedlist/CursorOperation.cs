using Assets.Scripts.SKICombinatorCalculus.Linkedlist.Process;
using System;
using System.Text;
using UnityEngine;
using UnityEngine.Assertions;

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

            var cursor = new CursorIO(topLevelStartElement);

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
            // Debug.Log("[不要な丸括弧の除去] 開始");

            Parentheses parentheses = FindParenthesesEachElement(topLevelStartElement);
            if (parentheses == null)
            {
                // Debug.Log("[不要な丸括弧の除去] 丸括弧 not found");
                return false;
            }

            // Debug.Log($"[不要な丸括弧の除去] 丸括弧発見 parentheses:{parentheses}");

            bool necessary = CheckNecessaryParentheses(parentheses);
            if (!necessary)
            {
                // Debug.Log("[不要な丸括弧の除去] 丸括弧 不要");
                StripParentheses(parentheses);

                // Debug.Log("[不要な丸括弧の除去] true 丸括弧除去済");
                return true;
            }

            // Debug.Log("[不要な丸括弧の除去] false 丸括弧必要");
            return false;
        }

        /// <summary>
        /// 丸括弧を探す
        /// </summary>
        private static Parentheses FindParenthesesEachElement(IElement topLevelStartElement)
        {
            // Debug.Log($"丸括弧を探す topLevelStartElement:{topLevelStartElement}");

            var cursor = new CursorIO(topLevelStartElement);

            for (IElement current = cursor.ReadElementWithinEndElement(); current != null; current = cursor.ReadElementWithinEndElement())
            {
                // Debug.Log($"丸括弧を探す current:{current}");

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
            int variableNum = 0;

            var cursor = new CursorIO(parentheses.StartElement);

            for (IElement current = cursor.ReadElementWithinEndElement(); current != null; current = cursor.ReadElementWithinEndElement())
            {
                // Debug.Log($"[丸括弧必要判定] Loop current:{current} {current.GetType().Name}");

                if (current is Variable)
                {
                    variableNum++;

                    if (2 <= variableNum)
                    {
                        // 変数が２個連続していたら、丸括弧は必要
                        // Debug.Log($"[丸括弧必要判定] true 変数が２個連続していたら、丸括弧は必要 current:{current} {current.GetType().Name}");
                        return true;
                    }
                }
                else if (current is StartElement || current is EndElement)
                {
                    // Ignored
                }
                else
                {
                    // 変数以外が混じっていたなら
                    // Debug.Log($"[丸括弧必要判定] true 変数以外混合 current:{current} {current.GetType().Name}");
                    return true;
                }
            }

            // 変数が２個未満だから、丸括弧は不要
            // Debug.Log($"[丸括弧必要判定] 変数が２個未満だから不要 variable num:{variableNum}");
            return false;
        }

        /// <summary>
        /// 丸括弧を剥がす
        /// </summary>
        private static void StripParentheses(Parentheses parentheses)
        {
            // - StartElement と EndElement が付いた状態が最小の単位なので、「丸括弧を剥がした状態」というものは、この設計の構造では存在しない
            // - そこで、リンクの貼り直しを行う
            Debug.Log($"[丸括弧を剥がす] parentheses:{parentheses}");

            // 丸括弧のクローン作成
            Parentheses clonedParentheses = (Parentheses)parentheses.Duplicate();
            Debug.Log($"[丸括弧を剥がす] clonedParentheses(Top Level):{clonedParentheses}");

            // 丸括弧の中身の最初の要素
            Debug.Log($"[丸括弧を剥がす] clonedParentheses(Top Level).StartElement:{clonedParentheses.StartElement}");
            IElement clonedFirstChild = clonedParentheses.StartElement.Next;
            Debug.Log($"[丸括弧を剥がす] clonedFirstChild:{clonedFirstChild}");

            // - `()` のような空丸括弧のケースなら、単純にこの丸括弧を削除するだけでよい
            // - それ以外のケースでは、リンクを貼り直す
            if (!(clonedFirstChild is EndElement))
            {
                // 丸括弧の中身の最後の要素
                IElement clonedLastChild = CursorOperation.GetEndElementEachSibling(clonedFirstChild).Previous;
                Debug.Log($"[丸括弧を剥がす] clonedLastChild:{clonedLastChild}");
                Debug.Log($"[丸括弧を剥がす] parentheses.Previous:{parentheses.Previous} {parentheses.Previous.GetType().Name}");
                Debug.Log($"[丸括弧を剥がす] parentheses.Next:{parentheses.Next} {parentheses.Next.GetType().Name}");

                // リンクの張り直し
                parentheses.InsertNext(clonedFirstChild);
            }

            // 丸括弧の削除
            parentheses.Remove();
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

            while (!(current is EndElement))
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
            Assert.IsTrue(current is EndElement);
            return current;
        }

        /// <summary>
        /// 文字列化
        /// </summary>
        /// <returns></returns>
        public static string Stringify(IElement element)
        {
            StringBuilder buf = new StringBuilder();

            var cursor = new CursorIO(element);

            // 先頭から順に読んでいくだけ
            var current = cursor.ReadChar();
            while (current != null)
            {
                buf.Append(current.ToString());
                current = cursor.ReadChar();
            }

            return buf.ToString();
        }

        /// <summary>
        /// 評価
        /// </summary>
        public static CalculationProcess EvaluateElements(CursorIO cursor)
        {
            IElement element0 = cursor.ReadElementWithinEndElement();
            Debug.Log($"[EvaluateElements] element0:{element0}");

            while (element0 != null)
            {
                if (element0 is ICombinator combinator)
                {
                    if (combinator is IdCombinator)
                    {
                        var arg1 = cursor.ReadElementWithinEndElement();

                        if (arg1 == null || arg1 is EndElement)
                        {
                            // `I` しかないケース
                            return null;
                        }

                        Debug.Log($"[EvaluateElements] I arg1:{arg1}");

                        combinator.Remove();
                        return new CalculationProcess(
                            combinator: "I",
                            arg1: arg1.ToString());
                    }
                    else if (combinator is KCombinator)
                    {
                        var arg1 = cursor.ReadElementWithinEndElement();
                        var arg2 = cursor.ReadElementWithinEndElement();

                        if (arg2 == null || arg2 is EndElement)
                        {
                            // `K` や、 `Kx` しかないケース
                            return null;
                        }

                        Debug.Log($"[EvaluateElements] K arg1:{arg1} arg2:{arg2}");

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

                        if (arg3 == null || arg3 is EndElement)
                        {
                            // `S` や、 `Sa` や、 `Sab` しかないケース
                            return null;
                        }

                        Debug.Log($"[EvaluateElements] S 1:{arg1} 2:{arg2} 3:{arg3}");

                        // とりあえず、引数を全部抜く
                        arg1.Remove();
                        arg2.Remove();
                        arg3.Remove();

                        // 複製
                        var clone1 = arg1.Duplicate();
                        var clone2 = arg3.Duplicate();
                        var clone3o1 = arg2.Duplicate();
                        var clone3o2 = arg3.Duplicate();

                        Debug.Log($"[EvaluateElements] S clone1:{clone1} clone2:{clone2} clone3o1:{clone3o1} clone3o2:{clone3o2}");

                        Parentheses clone3 = new Parentheses();
                        clone3.StepIn().InsertNext(clone3o1).InsertNext(clone3o2);

                        Debug.Log($"[EvaluateElements] S clone3:{clone3}");

                        // 複製を追加する
                        // FIXME 丸括弧を追加するときに不具合がある？
                        combinator.InsertNext(clone1).InsertNext(clone2).InsertNext(clone3);

                        Debug.Log($"[EvaluateElements] S Result:{CursorOperation.Stringify(cursor.GetSourceElement())}");


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
                else if (element0 is Variable || element0 is StartElement || element0 is EndElement)
                {
                    // 変数、`(`、`)` なら評価はできない
                }
                else if (element0 is Parentheses parentheses)
                {
                    Debug.Log($"丸括弧のケース parentheses:{parentheses.ToString()}");
                    // TODO 丸括弧を外していいケースかどうかは、ここでは分からない

                    // 丸括弧の内側を（再帰的に）評価することはできるだろう
                    cursor.SetCurrent(parentheses.StepIn()); // `(`
                    cursor.ReadChar(); // 丸括弧の内側の先頭要素
                    Debug.Log($"丸括弧のケース Current:{cursor.ToCurrentString()}");
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
