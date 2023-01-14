namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    using UnityEngine;
    using UnityEngine.Assertions;

    /// <summary>
    /// 生成用のカーソル
    /// </summary>
    internal class Cursor
    {
        public Cursor(IElement startElement)
        {
            Current = startElement;
        }

        private IElement Current { get; set; }

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
                        var parenteses = new Parenteses();
                        Current.InsertNext(parenteses);
                        Current = parenteses.StepIn();
                        Assert.IsNotNull(Current, $"parenteses.StartElement:{parenteses.StartElement}");
                    }
                    break;

                case ')':
                    {
                        Parenteses parenteses = Current.StepOut();
                        Assert.IsNotNull(parenteses, $"Current:{Current}");
                        Current = parenteses;
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
            else if (current is Parenteses parenteses)
            {
                current = parenteses.StartElement;
                Current = current.Next;
                return current;
            }
            else if (current is EndElement endElement)
            {
                current = endElement;
                Parenteses parenteses2 = endElement.Parent;
                if (parenteses2 == null)
                {
                    return null;
                }

                Current = parenteses2.Next;
                return current;
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
        public IElement ReadElement()
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
            IElement element0 = ReadElement();
            Debug.Log($"[EvaluateElements] element0:{element0.ToString()}");

            while (element0 != null)
            {
                if (element0 is ICombinator combinator)
                {
                    if (combinator is IdCombinator)
                    {
                        var arg1 = ReadElement();

                        if (arg1 == null)
                        {
                            // `I` しかないケース
                            return false;
                        }

                        element0.Remove();
                        return true;
                    }
                    else if (combinator is KCombinator)
                    {
                        var _arg1 = ReadElement();
                        var arg2 = ReadElement();

                        if (arg2 == null)
                        {
                            // `K` や、 `Kx` しかないケース
                            return false;
                        }

                        element0.Remove();
                        arg2.Remove();
                        return true;
                    }
                    else if (combinator is SCombinator)
                    {
                        var arg1 = ReadElement();
                        var arg2 = ReadElement();
                        var arg3 = ReadElement();

                        if (arg3 == null)
                        {
                            // `S` や、 `Sa` や、 `Sab` しかないケース
                            return false;
                        }

                        // とりあえず、引数を全部抜く
                        arg1.Remove();
                        arg2.Remove();
                        arg3.Remove();

                        // 複製
                        var clone1 = arg1.Duplicate();
                        var clone2 = arg3.Duplicate();
                        var clone3o1 = arg2.Duplicate();
                        var clone3o2 = arg3.Duplicate();

                        Parenteses clone3 = new Parenteses();
                        clone3.StepIn().InsertNext(clone3o1).InsertNext(clone3o2);

                        // 複製を追加する
                        element0.InsertNext(clone1).InsertNext(clone2).InsertNext(clone3);

                        // コンビネーター削除
                        element0.Remove();
                        return true;
                    }

                    throw new System.Exception($"unknown combinator:{combinator.GetType().Name}");
                }
                else if (element0 is Variable || element0 is StartElement)
                {
                    // 変数、`(` なら評価はできない
                }
                else if (element0 is Parenteses parenteses)
                {
                    Debug.Log($"丸括弧のケース parenteses:{parenteses.ToString()}");
                    // TODO 丸括弧を外していいケースかどうかは、ここでは分からない

                    // 丸括弧の内側を（再帰的に）評価することはできるだろう
                    Current = parenteses.StepIn(); // `(`
                    Current = ReadChar(); // 丸括弧の内側の先頭要素
                    Debug.Log($"丸括弧のケース Current:{Current.ToString()}");
                    var isOk = EvaluateElements(); // 再帰

                    // TODO 丸括弧の右側を評価してはいけない
                    return isOk;
                }

                // 次の要素へ、読み進める
                element0 = ReadElement();
            }

            // 何も評価せず、終端まで来てしまった
            return false;
        }
    }
}
