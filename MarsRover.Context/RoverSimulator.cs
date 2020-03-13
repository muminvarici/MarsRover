using MarsRover.Entity;
using System;

namespace MarsRover.Context
{
	internal class RoverSimulator
	{
		public Rover Rover { get; }
		public Land Land { get; }

		public RoverSimulator(Rover rover, Land land)
		{
			Rover = rover;
			Land = land;
		}

		public void PrintForRover()
		{
			foreach (var path in Rover.Path)
			{
				MoveRover();
			}
		}

		private void MoveRover()
		{
			for (int i = 0; i < Rover.Path.Length; i++)
			{
				if (Rover.Path[i] == StepDirection.MoveForward)
				{
					MoveForward();
				}

				var path = Rover.Path[i];
				Console.WriteLine($"Position: {Rover.XPosition}, {Rover.YPosition}\t Direction {Rover.Direction}\t Path {path.ToString()}");
				var nextDirection = DirectionAdapter.GetNextDirectionByStepDirection(Rover.Direction, path);
				PrintInternal(Rover.XPosition, Rover.YPosition);
				Console.WriteLine($"Next direction: {nextDirection}");
				Rover.Direction = nextDirection;
				//Rover.StepNumber++;
			}

		}

		private void MoveForward()
		{
			switch (Rover.Direction)
			{
				case Direction.North:
					Rover.YPosition++;
					break;
				case Direction.East:
					Rover.XPosition++;
					break;
				case Direction.South:
					Rover.YPosition--;
					break;
				case Direction.West:
					Rover.XPosition--;
					break;
				default:
					break;
			}
		}

		private void PrintInternal(int roverXPosition = -1, int roverYPosition = -1)
		{
			for (int x = Land.XUpperBound - 1; x >= 0; x--)
			{
				Console.Write(x);
				for (int y = Land.YUpperBound; y > 0; y--)
				{
					if (roverXPosition == x && roverYPosition == y)
					{
						Rover.Print();
					}
					else
					{
						Console.Write(".");
					}
					Console.Write(" ");
				}
				Console.WriteLine();
			}
			for (int y = 0; y < Land.YUpperBound; y++)
			{
				Console.Write($" {y}");
			}

			Console.WriteLine();
		}

		public void Print()
		{
			PrintInternal();
		}
	}
}