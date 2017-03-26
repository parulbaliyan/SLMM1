using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLMM
{
    class Program
    {
        public enum Direction { EAST, WEST, NORTH, SOUTH };

        static void Main(string[] args)
        {
            Position mowerPosition = new Position();


            Console.WriteLine("Please enter the mower position X & Y below 80 & 100 respectively:");
            string coord = Console.ReadLine();
            string[] points = coord.Split(' ', ',');
            mowerPosition.PositionX = Convert.ToInt32(points[0]);
            mowerPosition.PositionY = Convert.ToInt32(points[1]);

            if (!(mowerPosition.PositionX > 0 && mowerPosition.PositionX <= Lawn.width) &&
                (mowerPosition.PositionY > 0 && mowerPosition.PositionY <= Lawn.length))
                Console.WriteLine("Mower position is not inside the lawn boundaries");
            else
            {
                Console.WriteLine("Please enter the mower direction as East,West,North,South:");
                string dir = Console.ReadLine();
                //Console.ReadKey();
                while (!(dir.Equals(Direction.EAST.ToString(), StringComparison.OrdinalIgnoreCase) ||
                        dir.Equals(Direction.WEST.ToString(), StringComparison.OrdinalIgnoreCase) ||
                        dir.Equals(Direction.NORTH.ToString(), StringComparison.OrdinalIgnoreCase) ||
                        dir.Equals(Direction.SOUTH.ToString(), StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Please enter the mower direction as East,West,North,South:");
                    dir = Console.ReadLine();
                }

                mowerPosition.FacingDirection = dir.ToUpper();

                Dictionary<string, INextPosition> facingDirection = new Dictionary<string, INextPosition>();
                facingDirection.Add(Direction.EAST.ToString(), new FacingEast(mowerPosition));
                facingDirection.Add(Direction.WEST.ToString(), new FacingWest(mowerPosition));
                facingDirection.Add(Direction.NORTH.ToString(), new FacingNorth(mowerPosition));
                facingDirection.Add(Direction.SOUTH.ToString(), new FacingSouth(mowerPosition));

                Dictionary<string, IChangeDirection> changeDirection = new Dictionary<string, IChangeDirection>();
                changeDirection.Add(Direction.EAST.ToString(), new FacingEast(mowerPosition));
                changeDirection.Add(Direction.WEST.ToString(), new FacingWest(mowerPosition));
                changeDirection.Add(Direction.NORTH.ToString(), new FacingNorth(mowerPosition));
                changeDirection.Add(Direction.SOUTH.ToString(), new FacingSouth(mowerPosition));

                Dictionary<string, IMove> mowerCommand = new Dictionary<string, IMove>();
                mowerCommand.Add("TL", new TurnLeft(changeDirection));
                mowerCommand.Add("TR", new TurnRight(changeDirection));
                mowerCommand.Add("MF", new MoveForward(facingDirection));
                mowerCommand.Add("ML", new MowLawn());

                SmartMower mower = new SmartMower(ref mowerPosition, mowerCommand);
                Console.WriteLine("Enter command as TL,TR,MF,ML");
                string command = Console.ReadLine().ToUpper();
                if (command.Equals("TL") ||
                    command.Equals("TR") ||
                    command.Equals("MF") ||
                    command.Equals("ML"))
                {
                    Console.WriteLine("Time: {0}", DateTime.Now.ToString("h:mm:ss tt"));

                    if (mower.CommandGiven(command))
                    {

                        Console.WriteLine("Time: {0}", DateTime.Now.ToString("h:mm:ss tt"));
                        Console.WriteLine("Action: {0}", command);
                        Console.WriteLine("Current Location: X: {0}, Y:{1}, dir: {2}",
                            mowerPosition.PositionX.ToString(),
                            mowerPosition.PositionY.ToString(),
                            mowerPosition.FacingDirection);
                    }
                    else
                        Console.WriteLine("command cannot be accepted");
                }
                else
                {
                    Console.WriteLine("Command is not valid");
                }
            }
            Console.ReadKey();
        }
    }
}
