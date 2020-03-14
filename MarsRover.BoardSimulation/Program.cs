using MarsRover.Context;
using System.Threading;

namespace MarsRover.BoardSimulation
{
	public class Program
	{

		public static void Main(string[] args)
		{
			var simulationScenario = new UserTestSimulator();
			simulationScenario.Run();

			SpinWait.SpinUntil(() => false);
		}
	}
}
