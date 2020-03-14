using MarsRover.Context;
using MarsRover.Entity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.BoardSimulation
{
	public class DefaultSimulator : SimulationScenarioBase
	{
		public override void InitializeRovers()
		{
			var rover1 = GetRover(1, "1 2 N", "LMLMLMLMM");
			var rover2 = GetRover(2, "3 3 E", "MMRMMRMRRM");
			Context.AddRover(rover1, rover2);
		}

		public override LandBase GetLand()
		{
			Console.WriteLine("Enter the board land dimensions (Press enter for '5 5')");
			BoundString = Console.ReadLine();
			BoundString = BoundString == string.Empty ? "5 5" : BoundString;

			return base.GetLand();
		}

		public override RoverBase GetRover(int roverNumber, string defaultPosition, string defaultPath)
		{
			Console.WriteLine($"Enter #{roverNumber} rover position and direction (Press enter for {defaultPosition})");
			var roverInput = Console.ReadLine();
			roverInput = roverInput == string.Empty ? defaultPosition : roverInput;
			Console.WriteLine($"Enter the path of #{roverNumber} rover (Press enter for {defaultPath})");
			var pathValue = Console.ReadLine();
			pathValue = pathValue == string.Empty ? defaultPath : pathValue;
			return base.GetRover(roverInput, pathValue);
		}

	}
}
