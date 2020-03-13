using System;

namespace MarsRover.Entity
{
	public class Rover
	{
		public Rover(int initialXPosition, int initialYPosition, Direction initialDirection, StepDirection[] path)
		{
			InitialDirection = initialDirection;
			InitialXPosition = initialXPosition;
			InitialYPosition = initialYPosition;
			Path = path;
			Direction = initialDirection;
			XPosition = initialXPosition;
			YPosition = initialYPosition;
		}

		public Direction InitialDirection { get; }
		public int InitialXPosition { get; }
		public int InitialYPosition { get; }
		public StepDirection[] Path { get; set; }
		public Direction Direction { get; set; }
		public int XPosition { get; set; }
		public int YPosition { get; set; }

		public void Print()
		{
			String arrowKey = "";
			switch (Direction)
			{
				case Direction.North:
					arrowKey= "^";
					break;
				case Direction.East:
					arrowKey = ">";
					break;
				case Direction.South:
					arrowKey = "J";
					break;
				case Direction.West:
					arrowKey = "<";
					break;
				default:
					throw new InvalidCastException();
			}
			Console.Write(arrowKey);
		}
		//public int StepNumber { get; set; }
	}
}
