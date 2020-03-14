using FluentAssertions;
using MarsRover.Context;
using MarsRover.Core;
using MarsRover.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MarsRover.Test
{
	public class RoverMoveTest
	{
		private MainContext Context;

		public RoverMoveTest( )
		{
			Context = MainContext.GetInstance();
			InitializeLand();
		}

		[Fact]
		public void Test_12N_LMLMLMLMM()
		{
			TestRover("1 2 N", "LMLMLMLMM", "1 3 N");
		}

		[Fact]
		public void Test_33E_MMRMMRMRRM()
		{
			TestRover("3 3 E", "MMRMMRMRRM", "5 1 E");
		}

		private void TestRover(string initialPosition, string path, string expectedOutput)
		{
			var rover = GetRover(initialPosition, path);
			Context.AddRover(rover);

			new RoverSimulator(rover, Context.Land).MoveRover();

			var output = $"{rover.Position.X} {rover.Position.Y} {rover.Direction.ToString().Substring(0, 1)}";

			expectedOutput.Should().BeEquivalentTo(output);
		}
		 

		private void InitializeLand()
		{
			var land = GetLand();
			Context.SetLand(land);
			Context.Land.Build();
		}

		private Land GetLand()
		{
			var bounds = "5 5";
			var boundArray = StringOperations.GetSplittedArray<int>(bounds);
			return new Land(boundArray.ElementAt(0), boundArray.ElementAt(1));
		}

		private Rover GetRover(string position, string path)
		{
			return CreateRover(position, path);
		}

		private Rover CreateRover(string value, string pathValue)
		{
			var values = value.Split(' ');
			var xPosition = Convert.ToInt32(values[0]);
			var yPosition = Convert.ToInt32(values[1]);
			var direction = DirectionAdapter.GetDirectionByLetter(values[2]);

			var path = StringOperations.GetSplittedArray<StepDirection>(pathValue);

			return new Rover(xPosition, yPosition, direction, path);
		} 
	}
}
