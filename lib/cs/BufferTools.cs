using System;

namespace TLS
{
	/// <summary>
	/// Buffer tools.
	/// </summary>
	public class BufferTools 
	{
		/// <summary>Reads a number from the input buffer</summary>
		/// <param name="buffer">The buffer to read form</param>
		/// <param name="offset">The offset to start reading from</param>
		/// <param name="num_bytes">Number of bytes that represents the value</param>
		/// <param name="number">The value read from the buffer</param>
		/// <returns>The new buffer offset</returns>
		///
		public static long ReadNumberFromBuffer(byte[] buffer,long offset,int num_bytes,out long number) {
			long temp_number = 0;

			// This assumes big endian 
			// TODO : Add flag or something to support little endian.
			//

			for(var i=0;i<num_bytes;i++) {
				temp_number += buffer [offset + i] << ((num_bytes - i -1)*8);	
			}
			number = temp_number;
			return offset+num_bytes;
		}
	}

}