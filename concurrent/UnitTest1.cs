#if TRIAL

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nilnul._algo_._TEST_.concurrent
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{

		}
		public IEnumerable<int> MethodName()
		{
			//			there is at least one implementation of IEnumerable in the framework that can be infinite: BlockingCollection.GetConsumingEnumerable():

			//What you would do is to create a bounded BlockingCollection that's filled in an infinite loop from a separate thread. Calling GetConsumingEnumerable() will then return an infinite IEnumerable:

			var source = new BlockingCollection<int>(boundedCapacity: 1);
			Task.Run(() => { while (true) source.Add(1); });
			return source.GetConsumingEnumerable();
//@ta.speot.is At any moment, there is at most one item queued (that's what the 1 passed to the constructor means). When that 1 item is queued and you call Add() again, it blocks until the queued item is consumed. So, the while loop adds the items as fast as they are consumed (or slower).
		}
	}
}
#endif
