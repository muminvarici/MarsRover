using FluentAssertions;
using MarsRover.Context;
using MarsRover.Core;
using MarsRover.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Test
{
	public class TestSimulator : SimulationScenarioBase
	{
		public string InitialPosition { get; set; }
		public string Path { get; internal set; }
		public string ExpectedResult { get; internal set; }
		public int RoverCode { get; internal set; }
		public RoverBase Rover { get; private set; }

		public override void RunInternal()
		{
			var output = $"{Rover.Position.X} {Rover.Position.Y} {Rover.Direction.ToString().Substring(0, 1)}";
			ExpectedResult.Should().BeEquivalentTo(output);
		}


		public override void InitializeRovers()
		{
			Rover = GetRover(RoverCode, InitialPosition, Path);
			Context.AddRover(Rover);
		}

		public override LandBase GetLand()
		{
			BoundString = "5 5";
			return base.GetLand();
		}

		public override RoverBase GetRover(int roverNumber, string defaultPosition, string defaultPath)
		{
			return base.GetRover(defaultPosition, defaultPath);
		}
	}
}
