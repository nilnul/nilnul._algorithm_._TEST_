using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace nilnul._algorithm_._TEST_.nilnul0.algo_.recur_.eg_.path
{
	/// <summary>
	/// 
	/// </summary>
	[TestClass]
	public class UnitTest1
	{
		/// <summary>
		/// can only move from one cell to one of the four neighbors;
		/// and the number in the next cell must be lower than that in the current;
		/// and cannot move into a cell twice;
		/// </summary>
		/// <remarks>
		/// now we need to know how long the longest path is.
		/// </remarks>
		int[,] matrix = new int[3, 3] {
				{ 1,1,3}
				,
				{2,3,4 }
				,
				{1,1,1 }

			};

		[TestMethod]
		public void TestMethod1()
		{

			var m = depth1stSearch().Select(x => x.Count()).Max();

			Debug.WriteLine(m);

		}

		/// <summary>
		/// enumerate all paths;
		/// </summary>
		/// <returns></returns>
		IEnumerable<IEnumerable<(int, int)>> depth1stSearch(

		)
		{
			return Enumerable.Range(0, matrix.GetLength(0)).SelectMany(
				r => Enumerable.Range(
					0, matrix.GetLength(1)).Select(c => (r, c)
				)
			).SelectMany(
				cel =>		depth1stSearch(cel)
			);
		}

		/// <summary>
		/// enumerate all paths start from a cell;
		/// </summary>
		/// <param name="current"></param>
		/// <returns></returns>
		IEnumerable<IEnumerable<(int, int)>> depth1stSearch(
			(int, int) current
		)
		{

			return depth1stSearch(
				new (int, int)[0]
				,
				current
			);


		}


		/// <summary>
		/// given previous past path, enumerate all paths from current cell;
		/// </summary>
		/// <param name="visited"></param>
		/// <param name="current"></param>
		/// <returns></returns>
		IEnumerable<IEnumerable<(int, int)>> depth1stSearch(
			IEnumerable<(int, int)> visited
			,
			(int, int) current
		)
		{

			var left = (current.Item1 - 1, current.Item2);
			var up = (current.Item1, current.Item2 + 1);
			var right = (current.Item1 + 1, current.Item2);
			var down = (current.Item1, current.Item2 - 1);

			var neighbors = new (int, int)[] { left, up, right, down };

			var found = 0;

			foreach (var item in neighbors)
			{
				
				if (
					item.Item1 >= matrix.GetLength(0) || item.Item1 < 0
					||
					item.Item2 >= matrix.GetLength(1) || item.Item2 < 0
				) // cannot exceed the bounds of the matrix
				{
					continue;
				}

				if (visited.Contains(item)) // cannot get into a cell twice;
				{
					continue;
				}

				if (matrix[item.Item1, item.Item2] >= matrix[current.Item1, current.Item2]) // can only get into a cell containing a lower number;
				{
					continue;
				}
				found++;
				foreach (var p in depth1stSearch(
					visited.Append(current)
					,
					item
				))
				{
					yield return p;
				}
			}

			if (found == 0)
			{
				yield return visited.Append(current);
			}
		}
	}
}