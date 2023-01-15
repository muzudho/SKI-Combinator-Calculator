﻿namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    using Assets.Scripts.SKICombinatorCalculus.Linkedlist.Process;
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

        public string ToCurrentString()
        {
            return this.Current.ToString();
        }
    }
}
