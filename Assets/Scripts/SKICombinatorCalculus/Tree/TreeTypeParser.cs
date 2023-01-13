using Assets.Scripts.SKICombinatorCalculus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.SKICombinatorCalculus.Tree
{
    internal class TreeTypeParser
    {
        public string Parse(WorkingTree workingTree)
        {
            StringBuilder calculationProcess = new StringBuilder();

            // TODO 丸括弧の最左を優先して評価したい（つまり children[0] のテキストノードか？）
            //      - "(Sxyz...)"
            //      - "(Kxy...)"
            //      - "(Ix...)"
            // のようなものに該当すれば、評価すれば良さそうだが。
            // ここで、 xyz は 丸括弧ではないものとする
            //
            // xyz が丸括弧であれば、その中を優先したい
            //
            // 評価できない丸括弧であれば、 評価の優先順位を下げる
            //
            // また、
            //      - "aSbcde"
            // のように 最左に変数がきた場合は、それを無視して直近の右のコンビネーターを評価する

            // TODO 次の葉を取得
            TextNode textNode = workingTree.ReadTextNode();

            if (textNode != null)
            {
                if (0 < textNode.Text.Length)
                {
                    var iCombinatorModel = textNode.RemoveICombinatorModel();
                    if (iCombinatorModel!=null)
                    {
                        calculationProcess.AppendLine($@"{iCombinatorModel.ToString()}
");
                    }
                }
            }

            calculationProcess.AppendLine($@"

Last state:
    {workingTree.ToString()}
");
            return calculationProcess.ToString();
        }
    }
}
