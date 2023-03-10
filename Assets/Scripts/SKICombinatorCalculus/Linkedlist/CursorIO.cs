namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    using System;
    using UnityEngine.Assertions;

    /// <summary>
    /// 読み書き用のカーソル
    /// </summary>
    internal class CursorIO
    {
        public CursorIO(IElement element)
        {
            Current = element;
            SourceElement = element;
        }

        private IElement Current { get; set; }

        [Obsolete]
        public void SetCurrent(IElement current)
        {
            this.Current = current;
        }

        /// <summary>
        /// カーソルに渡された要素
        /// </summary>
        private IElement SourceElement { get; set; }

        [Obsolete]
        public IElement GetSourceElement()
        {
            return this.SourceElement;
        }

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
                        // 丸括弧を生成
                        var parentheses = new Placeholder(withParentheses: true);
                        // 丸括弧を挿入
                        Current.InsertNext(parentheses);
                        // カーソルを丸括弧の中へ移動
                        Current = parentheses.StepIn();
                        Assert.IsNotNull(Current, $"parentheses.StartElement:{parentheses.FirstCap}");
                    }
                    break;

                case ')':
                    {
                        Placeholder parentheses = Current.StepOut();
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
            if (Current == null)
            {
                return null;
            }

            // 先頭要素が `(` でなければ飛ばす
            if (Current is FirstCap firstCap1 && (firstCap1.Parent==null || !firstCap1.Parent.WithParentheses))
            {
                var result1 = Current;
                Current = result1.Next;
                return result1;
            }

            // 末尾要素が `)` でなければ飛ばす
            if (Current is LastCap lastCap1 && (lastCap1.Parent==null || !lastCap1.Parent.WithParentheses))
            {
                var result1 = Current;
                Current = result1.Next;
                return result1;
            }

            // Step in
            if (Current is Placeholder parentheses)
            {
                var result1 = parentheses.FirstCap;
                Current = result1.Next;
                return result1;
            }

            // Step out
            if (Current is LastCap lastCap2)
            {
                var result1 = lastCap2;
                Placeholder parentheses2 = result1.Parent;
                if (parentheses2 == null)
                {
                    // トップ・レベルの終端
                    return null;
                }

                Current = parentheses2.Next;
                return result1;
            }

            var result = Current;
            Current = Current.Next;
            return result;
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
            if (current == null || current is LastCap)
            {
                return null;
            }

            // トップ・レベルの先頭要素は飛ばす
            if (current is FirstCap startElement && startElement.Parent == null)
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
            if (current is FirstCap startElement && startElement.Parent == null)
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
            if (current is FirstCap startElement && startElement.Parent == null)
            {
                return null;
            }

            return current;
        }

        public string ToCurrentString()
        {
            return this.Current.ToString();
        }

        public void StepIn()
        {
            this.Current = this.Current.StepIn();
        }
    }
}
