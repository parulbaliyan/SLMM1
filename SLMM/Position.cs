using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLMM
{
    class Position
    {
        int X;
        int Y;
        string direction;
        public int PositionX
        {
            get { return X; }
            set { X = value; }
        }
        public int PositionY
        {
            get { return Y; }
            set { Y = value; }
        }
        public string FacingDirection
        {
            get { return direction; }
            set { direction = value; }
        }
    }
}
