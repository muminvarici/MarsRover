using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Entity
{
	public enum Direction
	{
		/// <summary>
		/// Kuzey
		/// </summary>
		North = 0,
		/// <summary>
		/// Doğu
		/// </summary>
		East = 1,
		/// <summary>
		/// Güney
		/// </summary>
		South = 2,
		/// <summary>
		/// Batı
		/// </summary>
		West = 3
	}

	public enum StepDirection
	{
		Left = 0,
		Rigth = 1,
		MoveForward = 99
	}
}
