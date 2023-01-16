namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    using System;
    using UnityEngine;
    using UnityEngine.Assertions;

    internal abstract class AbstractElement : IElement
    {
        public Placeholder Parent { get; set; }
        public IElement Previous { get; set; }
        public void SetPreviousManually(IElement previous)
        {
            if (this is FirstCap)
            {
                // FIXME
                throw new System.Exception("StartElementでPrevious操作するとおかしくなる");
            }

            this.Previous = previous;
        }
        public IElement Next { get; private set; }
        public void SetNextManually(IElement next)
        {
            if (this is LastCap)
            {
                // FIXME
                throw new System.Exception("EndElementでNext操作するとおかしくなる");
            }

            this.Next = next;
        }

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
            else if (this is Placeholder parentheses)
            {
                // 文字列からオブジェクトを生成
                return SpawnHelper.SpawnPlaceholderByText(parentheses.ToString());
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
            Assert.IsFalse(this is FirstCap);
            Assert.IsFalse(this is LastCap);

            var oldPrevious = this.Previous;
            var oldNext = this.Next;

            oldPrevious.SetNextManually(oldNext);
            oldNext.SetPreviousManually(oldPrevious);
        }

        /// <summary>
        /// 次の要素を挿入
        /// </summary>
        /// <param name="expressionStartElement">単一の要素、または一連の要素</param>
        /// <returns>引数の expressionStartElement の EndElement を返す</returns>
        [Obsolete]
        public IElement InsertNext(IElement expressionStartElement)
        {
            // FIXME 丸括弧を追加するときに不具合がある？
            Assert.IsNotNull(expressionStartElement);
            // Debug.Log($"[InsertNext] expressionStartElement:{expressionStartElement} {expressionStartElement.GetType().Name}");

            // 最後の要素の１つ前（最初の要素と同一であるケースを含む）
            // IElement expressionEndElement = CursorOperation.GetEndSiblingElementOldtypeWithinEndElement(expressionStartElement);
            IElement contentLastElement = CursorOperation.GetLastSiblingOfContentWithoutEndElement(expressionStartElement);
            // IElement expressionEndElement = CursorOperation.GetEndElementEachSibling(expressionStartElement);
            Assert.IsNotNull(contentLastElement);
            // Debug.Log($"[InsertNext] contentLastElement:{contentLastElement} {contentLastElement.GetType().Name}");

            // FIXME 丸括弧の次の要素がヌルのケースがある
            var contentLastElementOldNext = contentLastElement.Next;
            if (contentLastElementOldNext != null)
            {
                Assert.IsNotNull(contentLastElementOldNext);
                // Debug.Log($"[InsertNext] contentLastElementOldNext:{contentLastElementOldNext} {contentLastElementOldNext.GetType().Name}");
            }
            else
            {
                // FIXME
                Debug.Log($"[InsertNext] expressionEndElementOldNext:null ★おかしい");
            }

            // 後ろに回る要素
            var oldRightElement = Next;
            Assert.IsNotNull(oldRightElement);
            // Debug.Log($"[InsertNext] oldRightElement:{oldRightElement} {oldRightElement.GetType().Name}");

            SetNextManually(expressionStartElement);

            // 挿し込まれる要素
            {
                var expressionStartElementOldPrevious = expressionStartElement.Previous;
                Assert.IsNotNull(expressionStartElement);
                // Debug.Log($"[InsertNext] expressionStartElement:{expressionStartElement} {expressionStartElement.GetType().Name}");

                // 新しいつながりを得る
                expressionStartElement.SetPreviousManually(this);
                contentLastElement.SetNextManually(oldRightElement);

                // 元から抜ける
                {
                    if (expressionStartElementOldPrevious != null)
                    {
                        expressionStartElementOldPrevious.SetNextManually(contentLastElementOldNext);
                    }

                    if (contentLastElementOldNext != null)
                    {
                        contentLastElementOldNext.SetPreviousManually(expressionStartElementOldPrevious);
                    }
                }
            }

            // この要素は、新しいつながりを得る
            Next = expressionStartElement;

            // 元からあった後ろの要素は、新しいつながりを得る
            oldRightElement.SetPreviousManually(contentLastElement);

            return contentLastElement;
        }

        /// <summary>
        /// 次の要素を挿入
        /// </summary>
        /// <param name="expressionStartElement">単一の要素、または一連の要素</param>
        /// <returns>引数の expressionStartElement の EndElement を返す</returns>
        public IElement InsertNextType2(IElement expressionStartElement)
        {
            // FIXME 丸括弧を追加するときに不具合がある？
            Assert.IsNotNull(expressionStartElement);
            // Debug.Log($"[InsertNext] expressionStartElement:{expressionStartElement} {expressionStartElement.GetType().Name}");

            // 最後の要素の１つ前（最初の要素と同一であるケースを含む）
            IElement contentLastElement = expressionStartElement;
            // IElement contentLastElement = CursorOperation.GetLastSiblingOfContentWithoutEndElement(expressionStartElement);
            Assert.IsNotNull(contentLastElement);
            // Debug.Log($"[InsertNext] contentLastElement:{contentLastElement} {contentLastElement.GetType().Name}");

            // FIXME 丸括弧の次の要素がヌルのケースがある
            var contentLastElementOldNext = contentLastElement.Next;
            if (contentLastElementOldNext != null)
            {
                Assert.IsNotNull(contentLastElementOldNext);
                // Debug.Log($"[InsertNext] contentLastElementOldNext:{contentLastElementOldNext} {contentLastElementOldNext.GetType().Name}");
            }
            else
            {
                // FIXME
                // Debug.Log($"[InsertNext] expressionEndElementOldNext:null ★おかしい");
            }

            // 後ろに回る要素
            var oldRightElement = Next;
            Assert.IsNotNull(oldRightElement);
            // Debug.Log($"[InsertNext] oldRightElement:{oldRightElement} {oldRightElement.GetType().Name}");

            SetNextManually(expressionStartElement);

            // 挿し込まれる要素
            {
                var expressionStartElementOldPrevious = expressionStartElement.Previous;
                Assert.IsNotNull(expressionStartElement);
                // Debug.Log($"[InsertNext] expressionStartElement:{expressionStartElement} {expressionStartElement.GetType().Name}");

                // 新しいつながりを得る
                expressionStartElement.SetPreviousManually(this);
                contentLastElement.SetNextManually(oldRightElement);

                // 元から抜ける
                {
                    if (expressionStartElementOldPrevious != null)
                    {
                        expressionStartElementOldPrevious.SetNextManually(contentLastElementOldNext);
                    }

                    if (contentLastElementOldNext != null)
                    {
                        contentLastElementOldNext.SetPreviousManually(expressionStartElementOldPrevious);
                    }
                }
            }

            // この要素は、新しいつながりを得る
            Next = expressionStartElement;

            // 元からあった後ろの要素は、新しいつながりを得る
            oldRightElement.SetPreviousManually(contentLastElement);

            return contentLastElement;
        }

        /// <summary>
        /// 丸括弧であれば、その内部の始端の '(' を返します。
        /// 丸括弧以外はヌルを返します
        /// </summary>
        /// <returns></returns>
        public FirstCap StepIn()
        {
            if (this is Placeholder parentheses)
            {
                return parentheses.FirstCap;
            }

            return null;
        }

        /// <summary>
        /// 後要素を辿っていき、その最後尾要素の親を返します
        /// 
        /// - トップ・レベルであれば、ヌルを返します
        /// </summary>
        /// <returns></returns>
        public Placeholder StepOut()
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
