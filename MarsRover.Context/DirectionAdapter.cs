using MarsRover.Entity.Enum;
using System;

namespace MarsRover.Context
{
	public class DirectionAdapter
	{
		public static Direction GetDirectionByLetter(string letter)
		{
			switch (letter)
			{
				case "N":
					return Direction.North;
				case "S":
					return Direction.South;
				case "E":
					return Direction.East;
				case "W":
					return Direction.West;
				default:
					throw new InvalidCastException();
			}
		}

		public static StepDirection GetStepDirectionByLetter(string letter)
		{
			switch (letter.ToUpper())
			{
				case "L":
					return StepDirection.Left;
				case "R":
					return StepDirection.Rigth;
				case "M":
					return StepDirection.MoveForward;
				default:
					throw new InvalidCastException();
			}
		}

		public static Direction GetNextDirectionByStepDirection(Direction currentDirection, StepDirection stepDirection)
		{
			int plusValue = 0;
			switch (stepDirection)
			{
				case StepDirection.Left:
					plusValue--;
					break;
				case StepDirection.Rigth:
					plusValue++;
					break;
				default:
					plusValue = 0;
					break;
			}
			return (Direction)((int)(currentDirection + 4 + plusValue) % 4);
		}
	}
}
