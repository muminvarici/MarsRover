using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Entity.Model
{
	public class Bound
	{
		public Bound(int x, int y)
		{
			X = x;
			Y = Y;
		}
		public int X { get; private set; }
		public int Y { get; private set; }
	}
}
