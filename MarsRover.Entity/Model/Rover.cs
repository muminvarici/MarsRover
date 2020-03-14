using MarsRover.Entity.Enum;
using System.Collections.Generic;

namespace MarsRover.Entity.Model
{
	/// <summary>
	/// Rover model
	/// </summary>
	public class Rover : RoverBase
	{
		public Rover(int xPosition, int yPosition, Direction initialDirection, IEnumerable<StepDirection> path) 
			: base(xPosition, yPosition, initialDirection, path)
		{
		}

		/// <summary>
		/// Calculates the nex position by the direction
		/// </summary>
		public override void MoveForward()
		{
			switch (Direction)
			{
				case Direction.North:
					Position.Y++;
					break;
				case Direction.East:
					Position.X++;
					break;
				case Direction.South:
					Position.Y--;
					break;
				case Direction.West:
					Position.X--;
					break;
				default:
					break;
			}
		}
	}
}
