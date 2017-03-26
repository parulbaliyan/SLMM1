using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLMM
{
    class MoveForward : IMove
    {
        Dictionary<string, INextPosition> facingDirection = new Dictionary<string, INextPosition>();

        public MoveForward(Dictionary<string, INextPosition> pfacingDirection)
        {
            this.facingDirection = pfacingDirection;            
        }

        public bool Move(Position mowerPos)
        {            
            bool success = false;
            success = facingDirection[mowerPos.FacingDirection].MoveToNextPosition();
                   
            if (success)
                System.Threading.Thread.Sleep(15000);
            return success;
        }
        
     }
}
