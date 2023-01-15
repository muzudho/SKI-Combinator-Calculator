namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    using System;
    using UnityEngine;
    using UnityEngine.Assertions;

    /// <summary>
    /// 生成用のカーソル
    /// </summary>
    internal class Cursor
    {
        public Cursor(IElement element)
        {
            Current = element;
            SourceElement = element;
        }

        private IElement Current { get; set; }

        /// <summary>
        /// カーソルに渡された要素
        /// </summary>
        private IElement SourceElement { get; set; }

        /// <summary>
        /// 書込
        /// </summary>
        /// <param name="ch"></param>
        public void Write(char ch)
        {
            switch (ch)
            {
                case 'S':
                    {
                        var next = new SCombinator();
                        Current.InsertNext(next);
                        Current = next;
                    }
                    break;

                case 'K':
                    {
                        var next = new KCombinator();
                        Current.InsertNext(next);
                        Current = next;
                    }
                    break;

                case 'I':
                    {
                        var next = new IdCombinator();
                        Current.InsertNext(next);
                        Current = next;
                    }
                    break;

                case '(':
                    {
                        var parentheses = new Parentheses();
                        Current.InsertNext(parentheses);
                        Current = parentheses.StepIn();
                        Assert.IsNotNull(Current, $"parentheses.StartElement:{parentheses.StartElement}");
                    }
                    break;

                case ')':
                    {
                        Parentheses parentheses = Current.StepOut();
                        Assert.IsNotNull(parentheses, $"Current:{Current}");
                        Current = parentheses;
                    }
                    break;

                default:
                    {
                        if (SKICombinatorCalculator.variableCharacters.Contains(ch))
                        {
                            var next = new Variable(ch);
                            Current.InsertNext(next);
                            Current = next;
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// 読取
        /// 
        /// - 丸括弧の内側に入ります
        /// - 丸括弧の外側に出ます
        /// </summary>
        /// <returns>終端を超えたら、ヌル</returns>
        public IElement ReadChar()
        {
            var current = Current;

            // トップ・レベルの先頭要素は飛ばす
            if (current is StartElement startElement && startElement.Parent == null)
            {
                Current = current.Next;
                current = Current;
            }

            if (current == null)
            {
                return null;
            }
            else if (current is Parentheses parentheses)
            {
                current = parentheses.StartElement;
                Current = current.Next;
                return current;
            }
            else if (current is EndElement endElement)
            {
                current = endElement;
                Parentheses parentheses2 = endElement.Parent;
                if (parentheses2 == null)
                {
                    return null;
                }

                Current = parentheses2.Next;
                return current;
            }

            Current = current.Next;
            return current;
        }

        /// <summary>
        /// 読取
        /// 
        /// - `ReadElementWithinEndElement()` を使うようにしたい
        /// - 丸括弧の内側には入りません
        /// - 丸括弧の外側には出ません
        /// </summary>
        /// <returns>終端を超えたら、ヌル</returns>
        [Obsolete]
        public IElement ReadElementWithoutEndElement()
        {
            var current = Current;

            // `)` はヌル扱いです
            if (current == null || current is EndElement)
            {
                return null;
            }

            // トップ・レベルの先頭要素は飛ばす
            if (current is StartElement startElement && startElement.Parent == null)
            {
                Current = current.Next;
                current = Current;
            }

            Current = current.Next;
            return current;
        }

        /// <summary>
        /// 読取
        /// 
        /// - 丸括弧の内側には入りません
        /// - 丸括弧の外側には出ません
        /// </summary>
        /// <returns>終端を超えたら、ヌル</returns>
        public IElement ReadElementWithinEndElement()
        {
            var current = Current;

            if (current == null)
            {
                return null;
            }

            // トップ・レベルの先頭要素は飛ばす
            if (current is StartElement startElement && startElement.Parent == null)
            {
                Current = current.Next;
                current = Current;
            }

            Current = current.Next;
            return current;
        }

        /// <summary>
        /// 読取（逆方向）
        /// 
        /// - 丸括弧の内側には入りません
        /// - 丸括弧の外側には出ません
        /// </summary>
        /// <returns>終端を超えたら、ヌル</returns>
        public IElement ReadBackElement()
        {
            var current = Current;

            if (current == null)
            {
                return null;
            }

            Current = current.Previous;

            // トップ・レベルの先頭要素は、カーソルは指さない
            if (current is StartElement startElement && startElement.Parent == null)
            {
                return null;
            }

            return current;
        }

        /// <summary>
        /// 評価
        /// </summary>
        public bool EvaluateElements()
        {
            IElement element0 = ReadElementWithoutEndElement();
            Debug.Log($"[EvaluateElements] element0:{element0.ToString()}");

            while (element0 != null)
            {
                if (element0 is ICombinator combinator)
                {
                    if (combinator is IdCombinator)
                    {
                        var arg1 = ReadElementWithoutEndElement();

                        if (arg1 == null)
                        {
                            // `I` しかないケース
                            return false;
                        }

                        Debug.Log($"[EvaluateElements] I arg1:{arg1}");

                        combinator.Remove();
                        return true;
                    }
                    else if (combinator is KCombinator)
                    {
                        var _arg1 = ReadElementWithoutEndElement();
                        var arg2 = ReadElementWithoutEndElement();

                        if (arg2 == null)
                        {
                            // `K` や、 `Kx` しかないケース
                            return false;
                        }

                        Debug.Log($"[EvaluateElements] K _arg1:{_arg1} arg2:{arg2}");

                        combinator.Remove();
                        arg2.Remove();
                        return true;
                    }
                    else if (combinator is SCombinator)
                    {
                        var arg1 = ReadElementWithoutEndElement();
                        var arg2 = ReadElementWithoutEndElement();
                        var arg3 = ReadElementWithoutEndElement();

                        if (arg3 == null)
                        {
                            // `S` や、 `Sa` や、 `Sab` しかないケース
                            return false;
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
                        combinator.InsertNext(clone1).InsertNext(clone2).InsertNext(clone3);

                        Debug.Log($"[EvaluateElements] S Result:{CursorOperation.Stringify(SourceElement)}");


                        // コンビネーター削除
                        combinator.Remove();
                        return true;
                    }

                    throw new System.Exception($"unknown combinator:{combinator.GetType().Name}");
                }
                else if (element0 is Variable || element0 is StartElement)
                {
                    // 変数、`(` なら評価はできない
                }
                else if (element0 is Parentheses parentheses)
                {
                    Debug.Log($"丸括弧のケース parentheses:{parentheses.ToString()}");
                    // TODO 丸括弧を外していいケースかどうかは、ここでは分からない

                    // 丸括弧の内側を（再帰的に）評価することはできるだろう
                    Current = parentheses.StepIn(); // `(`
                    Current = ReadChar(); // 丸括弧の内側の先頭要素
                    Debug.Log($"丸括弧のケース Current:{Current.ToString()}");
                    var isOk = EvaluateElements(); // 再帰

                    // TODO 丸括弧の右側を評価してはいけない
                    return isOk;
                }

                // 次の要素へ、読み進める
                element0 = ReadElementWithoutEndElement();
            }

            // 何も評価せず、終端まで来てしまった
            return false;
        }
    }
}
