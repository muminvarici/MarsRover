using FluentAssertions;
using MarsRover.Context;
using MarsRover.Entity.Model;

namespace MarsRover.Test
{
	public class TestSimulator : SimulationScenarioBase
	{
		public string InitialPosition { get; set; }
		public string Path { get; internal set; }
		public string ExpectedResult { get; internal set; }
		public int RoverCode { get; internal set; }
		public RoverBase Rover { get; private set; }

		public override void AfterRun()
		{
			var output = $"{Rover.Position.X} {Rover.Position.Y} {Rover.Direction.ToString().Substring(0, 1)}";
			ExpectedResult.Should().BeEquivalentTo(output);
		}


		public override void InitializeRovers()
		{
			Rover = GetRover(InitialPosition, Path);
			Context.AddRover(Rover);
		}

		/// <summary>
		/// Returns a new Land according to bound value
		/// </summary>
		public override LandBase GetLand()
		{
			BoundString = "5 5";
			return base.GetLand();
		}
	}
}
