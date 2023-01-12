using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.SKICombinatorCalculus
{
    public enum StripParenthesesError
    {
        /// <summary>
        /// エラーなし
        /// </summary>
        None,

        /// <summary>
        /// 右側にコンビネーターまたは変数が無いケース
        /// </summary>
        NotFoundArgument,

        /// <summary>
        /// 構文エラー
        /// </summary>
        Sintax,
    }
}
