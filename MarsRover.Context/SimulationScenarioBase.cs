using MarsRover.Core;
using MarsRover.Entity.Enum;
using MarsRover.Entity.Model;
using System;
using System.Linq;

namespace MarsRover.Context
{
	public abstract class SimulationScenarioBase
	{
		protected MainContext Context;
		protected string BoundString;

		/// <summary>
		/// Initializes scenario rovers
		/// </summary>
		public abstract void InitializeRovers();

		/// <summary>
		/// Executes the scenario.
		/// </summary>
		public virtual void Run()
		{
			Context = MainContext.GetInstance();
			InitializeLand();
			InitializeRovers();

			Context.MoveRovers();

			AfterRun();
		}

		/// <summary>
		/// An overridable method that executes after Run method.
		/// </summary>
		public virtual void AfterRun() { }


		/// <summary>
		/// Initializes land
		/// </summary>
		protected void InitializeLand()
		{
			Context.SetLand(GetLand());
			Context.Land.Build();
		}

		/// <summary>
		/// Returns a new Land according to bound value
		/// </summary>
		public virtual LandBase GetLand()
		{
			var boundArray = StringOperations.GetSplittedArray<int>(BoundString);
			var bound = new Bound(boundArray.ElementAt(0), boundArray.ElementAt(1));
			return new Land(bound);
		}

		/// <summary>
		/// Creates and initializes new rover 
		/// </summary>
		/// <param name="initialPosition"></param>
		/// <param name="pathValue"></param>
		/// <returns></returns>
		protected RoverBase GetRover(string initialPosition, string pathValue)
		{
			var values = StringOperations.GetSplittedArray<string>(initialPosition); 

			var xPosition = Convert.ToInt32(values.ElementAt(0));
			var yPosition = Convert.ToInt32(values.ElementAt(1));
			var direction = DirectionAdapter.GetDirectionByLetter(values.ElementAt(2));

			var path = StringOperations.GetSplittedArray<StepDirection>(pathValue);

			return new Rover(xPosition, yPosition, direction, path);
		}
	}
}
