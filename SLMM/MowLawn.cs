using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLMM
{
    class MowLawn : IMove
    {
        public bool Move(Position mowerPos)
        {
            System.Threading.Thread.Sleep(120000);
            return true;
        }

    }
}
