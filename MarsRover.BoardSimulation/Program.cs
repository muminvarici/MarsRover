using MarsRover.Context;
using MarsRover.Entity;
using System;
using System.Linq;
using System.Threading;

namespace MarsRover.BoardSimulation
{
	public class Program
	{

		private static MainContext Context;
		public static void Main(string[] args)
		{
			Context = MainContext.GetInstance();
			InitializeLand();

			InitializeRovers();

			Context.Land.Build();
			Context.MoveRovers();

			SpinWait.SpinUntil(() => false);

		}

		private static void InitializeLand()
		{
			var land = GetLand();
			Context.SetLand(land);
		}

		private static void InitializeRovers()
		{
			var rover1 = GetRover(1, "1 2 N", "LMLMLMLMM");
			var rover2 = GetRover(2, "3 3 E", "MMRMMRMRRM");
			Context.AddRover(rover1, rover2);
		}

		private static Land GetLand()
		{
			Console.WriteLine("Enter the board land dimensions (Press enter for '5 5')");
			var bounds = Console.ReadLine();
			bounds = bounds == string.Empty ? "5 5" : bounds;
			var boundArray = GetSplittedArray<int>(bounds);
			return new Land(boundArray[0], boundArray[1]);
		}

		private static Rover GetRover(int roverNumber, string defaultPosition, string defaultPath)
		{
			Console.WriteLine($"Enter #{roverNumber} rover position and direction (Press enter for {defaultPosition})");
			var roverInput = Console.ReadLine();
			roverInput = roverInput == string.Empty ? defaultPosition : roverInput;
			Console.WriteLine($"Enter the path of #{roverNumber} rover (Press enter for {defaultPath})");
			var pathValue = Console.ReadLine();
			pathValue = pathValue == string.Empty ? defaultPath : pathValue;
			return CreateGetRover(roverInput, pathValue);
		}

		private static Rover CreateGetRover(string value, string pathValue)
		{
			var values = value.Split(' ');
			var xPosition = Convert.ToInt32(values[0]);
			var yPosition = Convert.ToInt32(values[1]);
			var direction = DirectionAdapter.GetDirectionByLetter(values[2]);

			var path = GetSplittedArray<StepDirection>(pathValue);

			return new Rover(xPosition, yPosition, direction, path);
		}

		/// <summary>
		/// Returns an array of values splitted by the seperator character
		/// </summary>
		/// <param name="value">The value of string contains seperator character</param>
		/// <param name="seperator">The seperator character. Default value is 'space' character</param>
		/// <returns></returns>
		private static T[] GetSplittedArray<T>(string value)
		{
			var values = value.ToCharArray().Where(w => w != ' ').Select(w => Convert.ToString(w));
			if (typeof(T) == typeof(int))
			{
				return values.Select(w => Convert.ToInt32(w)).ToArray() as T[];
			}
			else if (typeof(T) == typeof(StepDirection))
			{
				return values.Select(w => DirectionAdapter.GetStepDirectionByLetter(w)).ToArray() as T[];
			}
			return values as T[];
		}
	}
}
