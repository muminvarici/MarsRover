using MarsRover.Entity.Enum;
using MarsRover.Entity.Model;
using System.Collections.Generic;

namespace MarsRover.Entity.Model
{
	public abstract class RoverBase
	{
		public RoverBase(int xPosition, int yPosition, Direction initialDirection, IEnumerable<StepDirection> path)
		{
			Path = path;
			Direction = initialDirection;
			Position = new Position { X = xPosition, Y = yPosition };
		}

		public IEnumerable<StepDirection> Path { get; protected set; }
		public Direction Direction { get; set; }
		public Position Position { get; protected set; }

		public abstract void MoveForward();
	}
}
