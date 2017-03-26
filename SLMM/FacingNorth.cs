using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLMM
{
    class FacingNorth:INextPosition,IChangeDirection
    {
        Position mowerPosition = new Position();
        public FacingNorth(Position mowerPos)
        {
            this.mowerPosition = mowerPos;
        }
        public bool MoveToNextPosition()
        {
            bool success;
            if (mowerPosition.PositionY + 1 <= Lawn.length)
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
            mowerPosition.FacingDirection = Program.Direction.WEST.ToString();
        }
        public void GetNewTurnRightDirection()
        {
            mowerPosition.FacingDirection = Program.Direction.EAST.ToString();
        }
    }
}
