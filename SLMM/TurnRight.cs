using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLMM
{
    class TurnRight : IMove
    {
        Dictionary<string, IChangeDirection> changeDirection = new Dictionary<string, IChangeDirection>();

        public TurnRight(Dictionary<string, IChangeDirection> pchangeDirection)
        {
            this.changeDirection = pchangeDirection;
        }

        public bool Move(Position mowerPos)
        {
            changeDirection[mowerPos.FacingDirection].GetNewTurnlLeftDirection();

            System.Threading.Thread.Sleep(10000);
            return true;
        }

    }
}
