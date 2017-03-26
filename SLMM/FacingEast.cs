using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLMM
{
    class FacingEast:INextPosition,IChangeDirection
    {
        Position mowerPosition = new Position();
        public FacingEast(Position mowerPos)
        {
            this.mowerPosition = mowerPos;
        }                

        public bool MoveToNextPosition()
        {
            bool success;
            if (mowerPosition.PositionX + 1 <= Lawn.width)
            {
                mowerPosition.PositionX++;
                success = true;
            }
            else
                success = false;
            return success;
        }
        public void GetNewTurnlLeftDirection()
        {
            mowerPosition.FacingDirection = Program.Direction.NORTH.ToString();
        }
        public void GetNewTurnRightDirection()
        {
            mowerPosition.FacingDirection = Program.Direction.SOUTH.ToString();
        }
    }
}
