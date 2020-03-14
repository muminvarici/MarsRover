using MarsRover.Core;
using MarsRover.Entity.Enum;
using MarsRover.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Context
{
	public abstract class SimulationScenarioBase
	{
		protected MainContext Context;
		protected string BoundString;

		public abstract void InitializeRovers();
		public abstract RoverBase GetRover(int roverNumber, string defaultPosition, string defaultPath);

		public virtual void Run()
		{
			Context = MainContext.GetInstance();
			InitializeLand();
			InitializeRovers();
			Context.MoveRovers();

			RunInternal();
		}

		public virtual void RunInternal() { }


		protected void InitializeLand()
		{
			Context.SetLand(GetLand());
			Context.Land.Build();
		}

		public virtual LandBase GetLand()
		{
			var boundArray = StringOperations.GetSplittedArray<int>(BoundString);
			var bound = new Bound(boundArray.ElementAt(0), boundArray.ElementAt(1));
			return new Land(bound);
		}

		protected RoverBase GetRover(string initialPosition, string pathValue)
		{
			var values = initialPosition.Split(' ');
			var xPosition = Convert.ToInt32(values[0]);
			var yPosition = Convert.ToInt32(values[1]);
			var direction = DirectionAdapter.GetDirectionByLetter(values[2]);

			var path = StringOperations.GetSplittedArray<StepDirection>(pathValue);

			return new Rover(xPosition, yPosition, direction, path);
		}
	}
}
