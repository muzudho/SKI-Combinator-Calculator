using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    internal interface IElement
    {
        IElement Previous { get; set; }
        IElement Next { get; set; }
    }
}
