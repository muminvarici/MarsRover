using MarsRover.Entity;
using System;
using System.Collections.Generic;

namespace MarsRover.Context
{
	public class MainContext
	{
		private static MainContext CurrentContext;

		public Land Land { get; private set; }
		public List<Rover> Rovers { get; private set; }

		public static MainContext GetInstance()
		{
			if (CurrentContext == null)
			{
				CurrentContext = new MainContext
				{
					Rovers = new List<Rover>()
				};
			}
			return CurrentContext;
		}

		public void MoveRovers()
		{
			foreach (var rover in Rovers)
			{
				new RoverSimulator(rover, Land).MoveRover();
			}
		}

		public void SetLand(Land board)
		{
			Land = board;
		}
		public void AddRover(params Rover[] rovers)
		{
			Rovers.AddRange(rovers);
		}
	}
}
