using MarsRover.Core;
using MarsRover.Entity.Enum;
using System;

namespace MarsRover.Context
{
	public class DirectionAdapter
	{
		/// <summary>
		/// Returns the direction according to it's first character
		/// </summary>
		public static Direction GetDirectionByLetter(string letter)
		{
			return StringOperations.GetEnumByFirstCharacter<Direction>(letter.ToUpper());
			//switch (letter)
			//{
			//	case "N":
			//		return Direction.North;
			//	case "S":
			//		return Direction.South;
			//	case "E":
			//		return Direction.East;
			//	case "W":
			//		return Direction.West;
			//	default:
			//		throw new InvalidCastException();
			//}
		}

		/// <summary>
		/// Returns the step direction according to it's first character
		/// </summary>
		public static StepDirection GetStepDirectionByLetter(string letter)
		{
			return StringOperations.GetEnumByFirstCharacter<StepDirection>(letter.ToUpper());

			//switch (letter.ToUpper())
			//{
			//	case "L":
			//		return StepDirection.Left;
			//	case "R":
			//		return StepDirection.Rigth;
			//	case "M":
			//		return StepDirection.MoveForward;
			//	default:
			//		throw new InvalidCastException();
			//}
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
