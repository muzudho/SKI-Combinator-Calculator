namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    using UnityEngine.Assertions;

    internal abstract class AbstractElement : IElement
    {
        public Parentheses Parent { get; set; }
        public IElement Previous { get; set; }
        public IElement Next { get; set; }

        /// <summary>
        /// 複製します
        /// </summary>
        public IElement Duplicate()
        {
            if (this is IdCombinator)
            {
                return new IdCombinator();
            }
            else if (this is KCombinator)
            {
                return new KCombinator();
            }
            else if (this is SCombinator)
            {
                return new SCombinator();
            }
            else if (this is Variable variable)
            {
                return new Variable(variable.Character);
            }
            else if (this is Parentheses parentheses)
            {
                var expression = parentheses.ToString();

                // トップ・レベルの始端と終端
                var newStartElement = new StartElement(new EndElement(null));

                // 生成
                {
                    var cursor = new Cursor(newStartElement);

                    // 先頭から順に書いていくだけ
                    foreach (var ch in expression)
                    {
                        cursor.Write(ch);
                    }
                }

                return new Parentheses(newStartElement);
            }
            else
            {
                throw new System.Exception($"unknown type:{this.GetType().Name}");
            }
        }

        /// <summary>
        /// 前後の要素から切り離します
        /// </summary>
        public void Remove()
        {
            Assert.IsFalse(this is StartElement);
            Assert.IsFalse(this is EndElement);

            var oldPrevious = this.Previous;
            var oldNext = this.Next;

            oldPrevious.Next = oldNext;
            oldNext.Previous = oldPrevious;
        }

        /// <summary>
        /// 次の要素を挿入
        /// </summary>
        /// <param name="expressionStartElement">単一の要素、または一連の要素</param>
        /// <returns>引数の expressionStartElement の EndElement を返す</returns>
        public IElement InsertNext(IElement expressionStartElement)
        {
            Assert.IsNotNull(expressionStartElement);

            // 最後の要素（最初の要素と同一であるケースを含む）
            IElement expressionEndElement = CursorOperation.GetEndElement(expressionStartElement);
            Assert.IsNotNull(expressionEndElement);

            // 後ろに回る要素
            var oldNext = Next;
            Next = expressionStartElement;

            // 挿し込まれる要素
            {
                var expressionStartElementOldPrevious = expressionStartElement.Previous;
                var expressionEndElementOldNext = expressionEndElement.Next;

                expressionStartElement.Previous = this;
                expressionStartElement.Next = oldNext;

                if (expressionStartElementOldPrevious != null)
                {
                    expressionStartElementOldPrevious.Next = expressionEndElementOldNext;
                }

                if (expressionEndElementOldNext != null)
                {
                    expressionEndElementOldNext.Previous = expressionStartElementOldPrevious;
                }
            }

            oldNext.Previous = expressionEndElement;
            return expressionEndElement;
        }

        /// <summary>
        /// 丸括弧であれば、その内部の始端の '(' を返します。
        /// 丸括弧以外はヌルを返します
        /// </summary>
        /// <returns></returns>
        public StartElement StepIn()
        {
            if (this is Parentheses parentheses)
            {
                return parentheses.StartElement;
            }

            return null;
        }

        /// <summary>
        /// 後要素を辿っていき、その最後尾要素の親を返します
        /// 
        /// - トップ・レベルであれば、ヌルを返します
        /// </summary>
        /// <returns></returns>
        public Parentheses StepOut()
        {
            IElement current = this;
            while (current.Next != null)
            {
                current = current.Next;
            }

            return current.Parent;
        }
    }
}
