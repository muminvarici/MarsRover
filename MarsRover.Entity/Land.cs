using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Entity
{
	public class Land
	{
		public int XUpperBound { get; private set; }
		public int YUpperBound { get; private set; }
		public int[,] GroundMatrix { get; private set; }
		public Land(int xUpperBound, int yUpperBound)
		{
			XUpperBound = xUpperBound;
			YUpperBound = yUpperBound;
		}

		public void Build()
		{
			GroundMatrix = new int[XUpperBound, YUpperBound];
		}
	}
}
