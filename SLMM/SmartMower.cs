using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLMM
{
    class SmartMower
    {
        Position mowerPosition = new Position();
        Dictionary<String, IMove> mowerCommand;

        public SmartMower(ref Position mowerPosition, Dictionary<String, IMove> mowerCommand)
        {
            this.mowerPosition = mowerPosition;
            this.mowerCommand = mowerCommand;
        }

        public bool CommandGiven(string cmd)
        {
            bool success = mowerCommand[cmd].Move(mowerPosition);
            return success;

        }

    }
}
