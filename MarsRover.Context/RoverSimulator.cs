using MarsRover.Entity;
using System;
using System.Linq;

namespace MarsRover.Context
{
	/// <summary>
	/// The simulator object
	/// </summary>
	public class RoverSimulator
	{
		public Rover Rover { get; }
		public Land Land { get; }

		public RoverSimulator(Rover rover, Land land)
		{
			Rover = rover;
			Land = land;
		}

		/// <summary>
		/// Moves the Rover by it's path
		/// </summary>
		public void MoveRover()
		{
			for (int i = 0; i < Rover.Path.Count(); i++)
			{
				if (Rover.Path.ElementAt(i) == StepDirection.MoveForward)
				{
					Rover.MoveForward();
				}

				var path = Rover.Path.ElementAt(i);
				Console.WriteLine($"Position: {Rover.Position.X}, {Rover.Position.Y}\t Direction {Rover.Direction}\t Path {path.ToString()}");
				var nextDirection = DirectionAdapter.GetNextDirectionByStepDirection(Rover.Direction, path);
				Console.WriteLine($"Next direction: {nextDirection}");
				Rover.Direction = nextDirection;
			}
			Console.WriteLine($"Last Position and Direction:");
			Console.WriteLine($"{Rover.Position.X} {Rover.Position.Y} {Rover.Direction.ToString().Substring(0, 1)}");
		}
	}
}