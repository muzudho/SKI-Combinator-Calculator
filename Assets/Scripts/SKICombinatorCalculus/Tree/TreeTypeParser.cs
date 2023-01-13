using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.SKICombinatorCalculus.Tree
{
    internal class TreeTypeParser
    {
        public string Parse(WorkingTree workingTree)
        {
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

            return workingTree.ToString();
        }
    }
}
