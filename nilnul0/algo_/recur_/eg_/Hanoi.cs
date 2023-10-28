using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nilnul.algo_.recur_.eg_
{
	static public class _HanoiX
	{

		static public int[] Indexes = Enumerable.Range(0, 3).ToArray();

		static public IEnumerable<(int, int)> _Steps(int total, int from, int to)
		{
			if (total == 0)
			{
				yield break;
			}
			var via = Indexes.Except(new[] { from, to }).Single();
			total--;
			foreach (var item in _Steps(--total, from, via))
			{
				yield return item;
			}
			yield return (from, to);
			foreach (var item in _Steps(total, via, to))
			{
				yield return item;
			}
		}

		static public IEnumerable<(int, int)> Steps()
		{
			return _Steps(3, 0, 2);
		}
	}
}
