using MarsRover.Context;
using MarsRover.Entity.Model;
using System;

namespace MarsRover.BoardSimulation
{
	public class UserTestSimulator : SimulationScenarioBase
	{
		/// <summary>
		/// Initializes scenario rovers
		/// </summary>
		public override void InitializeRovers()
		{
			var rover1 = GetRoverInternal(1, "1 2 N", "LMLMLMLMM");
			var rover2 = GetRoverInternal(2, "3 3 E", "MMRMMRMRRM");
			Context.AddRover(rover1, rover2);
		}

		/// <summary>
		/// Returns a new Land according to bound value
		/// </summary>
		public override LandBase GetLand()
		{
			Console.WriteLine("Enter the board land dimensions (Press enter for '5 5')");
			BoundString = Console.ReadLine();
			BoundString = BoundString == string.Empty ? "5 5" : BoundString;

			return base.GetLand();
		}


		/// <summary>
		/// Returns a new Rover with default
		/// </summary>
		/// <param name="roverNumber">Rover number to print for user interaction</param>
		/// <param name="defaultPosition">Default rover position and direction</param>
		/// <param name="defaultPath">Default rover path</param>
		/// <returns></returns>
		private RoverBase GetRoverInternal(int roverNumber, string defaultPosition, string defaultPath)
		{
			string roverInput = GetRoverPosition(roverNumber, defaultPosition);
			string pathValue = GetRoverPath(roverNumber, defaultPath);
			return GetRover(roverInput, pathValue);
		}

		/// <summary>
		/// Gets Rover path from user. If path is not suplied, returns the default path value.
		/// </summary>
		/// <param name="roverNumber">Rover number to print for user interaction</param>
		/// <param name="defaultPath">Default rover path</param>
		/// <returns></returns>
		private static string GetRoverPath(int roverNumber, string defaultPath)
		{
			Console.WriteLine($"Enter the path of #{roverNumber} rover (Press enter for {defaultPath})");
			var path = Console.ReadLine();
			path = path == string.Empty ? defaultPath : path;
			return path;
		}

		/// <summary>
		/// Gets Rover position and direction from user. If value is not suplied, returns the default position value.
		/// </summary>
		/// <param name="roverNumber">Rover number to print for user interaction</param>
		/// <param name="defaultPosition">Default rover position and direction</param>
		/// <returns></returns>
		private static string GetRoverPosition(int roverNumber, string defaultPosition)
		{
			Console.WriteLine($"Enter #{roverNumber} rover position and direction (Press enter for {defaultPosition})");
			var roverPosition = Console.ReadLine();
			roverPosition = roverPosition == string.Empty ? defaultPosition : roverPosition;
			return roverPosition;
		}
	}
}
