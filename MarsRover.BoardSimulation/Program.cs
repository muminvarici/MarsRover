using MarsRover.Context;
using MarsRover.Core;
using MarsRover.Entity.Enum;
using MarsRover.Entity.Model;
using System;
using System.Linq;
using System.Threading;

namespace MarsRover.BoardSimulation
{
	public class Program  
	{
		private static SimulationScenarioBase SimulationScenario;

		public static void Main(string[] args)
		{
			SimulationScenario = new DefaultSimulator();
			SimulationScenario.Run();

			SpinWait.SpinUntil(() => false);
		}
	}
}
