using MarsRover.Entity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Entity.Model
{
	public abstract class LandBase
	{
		public Bound UpperBounds { get; private set; }
		public int[,] GroundMatrix { get; protected set; }
		public LandBase(Bound upperBound)
		{
			UpperBounds = upperBound;
		}

		public abstract void Build();
	}
}
