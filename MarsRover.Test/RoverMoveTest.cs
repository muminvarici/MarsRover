using Xunit;

namespace MarsRover.Test
{
	public class RoverMoveTest
	{
		[Fact]
		public void Test_12N_LMLMLMLMM()
		{
			TestSimulator testSimulator = new TestSimulator
			{
				RoverCode = 1,
				InitialPosition = "1 2 N",
				Path = "LMLMLMLMM",
				ExpectedResult = "1 3 N"
			};
			testSimulator.Run();
		}

		[Fact]
		public void Test_33E_MMRMMRMRRM()
		{
			TestSimulator testSimulator = new TestSimulator
			{
				RoverCode = 2,
				InitialPosition = "3 3 E",
				Path = "MMRMMRMRRM",
				ExpectedResult = "5 1 E"
			};
			testSimulator.Run();
		}
	}
}
