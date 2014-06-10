using NUnit.Framework;
using System;

using TLS;

namespace tlslibtests
{
	[TestFixture ()]
	public class BufferToolsTests
	{
		[Test ()]
		public void ReadNumberFromBuffer ()
		{
			long value = 0;
			byte[] buffer = new byte[] { 0,0,5,  0,1,0, 2,0,0 };
			var new_offset = TLS.BufferTools.ReadNumberFromBuffer (buffer,0,3,out value);

			Assert.AreEqual (3,new_offset);
			Assert.AreEqual (5,value);

			new_offset = TLS.BufferTools.ReadNumberFromBuffer (buffer,new_offset,3,out value);
			Assert.AreEqual (6,new_offset);
			Assert.AreEqual (256,value);

			new_offset = TLS.BufferTools.ReadNumberFromBuffer (buffer,new_offset,3,out value);
			Assert.AreEqual (9,new_offset);
			Assert.AreEqual (65536*2,value);

			new_offset = TLS.BufferTools.ReadNumberFromBuffer (buffer,1,2,out value);
			Assert.AreEqual (3,new_offset);
			Assert.AreEqual (5,value);

			new_offset = TLS.BufferTools.ReadNumberFromBuffer (buffer,2,1,out value);
			Assert.AreEqual (3,new_offset);
			Assert.AreEqual (5,value);
		}

		/*[Test ()]
		[ExpectedException(typeof(Exception))]
		public void ReadNumberFromBuffer_BufferOverrun ()
		{
			long value = 0;
			byte[] buffer = new byte[] { };
			var new_offset = TLS.BufferTools.ReadNumberFromBuffer (buffer,0,3,out value);
		}*/
	}
}

