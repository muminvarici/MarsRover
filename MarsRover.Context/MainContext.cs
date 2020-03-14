using MarsRover.Entity.Interface;
using MarsRover.Entity.Model;
using System.Collections.Generic;

namespace MarsRover.Context
{
	public class MainContext
	{
		private static MainContext CurrentContext;

		public LandBase Land { get; private set; }
		public List<IRoverSimulator> Simulator { get; private set; }

		/// <summary>
		/// Returns the context
		/// </summary>
		public static MainContext GetInstance()
		{
			if (CurrentContext == null)
			{
				CurrentContext = new MainContext
				{
					Simulator = new List<IRoverSimulator>()
				};
			}
			return CurrentContext;
		}

		/// <summary>
		/// Executes the simulators and moves rovers.
		/// </summary>
		public void MoveRovers()
		{
			foreach (var simulator in Simulator)
			{
				simulator.MoveRover();
			}
		}

		public void SetLand(LandBase board)
		{
			Land = board;
		}

		public void AddRover(params RoverBase[] rovers)
		{
			foreach (var simulator in rovers)
			{
				Simulator.Add(new RoverSimulator(simulator));
			}
		}
	}
}
