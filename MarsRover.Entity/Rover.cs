using System;
using System.Collections.Generic;

namespace MarsRover.Entity
{
	/// <summary>
	/// Rover model
	/// </summary>
	public class Rover
	{
		public Rover(int initialXPosition, int initialYPosition, Direction initialDirection, IEnumerable<StepDirection> path)
		{
			InitialDirection = initialDirection;
			//InitialXPosition = initialXPosition;
			//InitialYPosition = initialYPosition;
			Path = path;
			Direction = initialDirection;
			Position = new Position { X = initialXPosition, Y = initialYPosition };
		}

		public Direction InitialDirection { get; }
		//public int InitialXPosition { get; }
		//public int InitialYPosition { get; }
		public IEnumerable<StepDirection> Path { get; set; }
		public Direction Direction { get; set; }
		public Position Position { get; private set; }

		//public void Print()
		//{
		//	String arrowKey = "";
		//	switch (Direction)
		//	{
		//		case Direction.North:
		//			arrowKey= "^";
		//			break;
		//		case Direction.East:
		//			arrowKey = ">";
		//			break;
		//		case Direction.South:
		//			arrowKey = "J";
		//			break;
		//		case Direction.West:
		//			arrowKey = "<";
		//			break;
		//		default:
		//			throw new InvalidCastException();
		//	}
		//	Console.Write(arrowKey);
		//}
		//public int StepNumber { get; set; }

		/// <summary>
		/// Calculates the nex position by the direction
		/// </summary>
		public void MoveForward()
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
