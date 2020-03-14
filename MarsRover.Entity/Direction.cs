using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Entity
{
	/// <summary>
	/// Geographical direction enumeration
	/// </summary>
	public enum Direction
	{
		North = 0,
		East = 1,
		South = 2,
		West = 3
	}

	/// <summary>
	/// Step direction enumeration
	/// </summary>
	public enum StepDirection
	{
		Left = 0,
		Rigth = 1,
		MoveForward = 99
	}
}
