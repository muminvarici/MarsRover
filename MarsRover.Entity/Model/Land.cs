using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Entity.Model
{
	/// <summary>
	/// Land Model
	/// </summary>
	public class Land : LandBase
	{
		public Land(Bound upperBound) : base(upperBound)
		{
		}

		public override void Build()
		{
			GroundMatrix = new int[UpperBounds.X, UpperBounds.Y];
		}
	}
}
