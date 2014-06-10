using System;

namespace TLS
{
	public class uint8 
	{
		public long value;
		public long Load(byte[] buffer,long offset) {
			return BufferTools.ReadNumberFromBuffer(buffer,offset,1,out value); 
		}
	}

	public class uint16 
	{
		public long value;
		public long Load(byte[] buffer,long offset) {
			return BufferTools.ReadNumberFromBuffer(buffer,offset,2,out value); 
		}
	}

	public class uint24 
	{
		public long value;
		public long Load(byte[] buffer,long offset) {
			return BufferTools.ReadNumberFromBuffer(buffer,offset,3,out value); 
		}
	}

	public class uint32 
	{
		public long value;
		public long Load(byte[] buffer,long offset) {
			return BufferTools.ReadNumberFromBuffer(buffer,offset,4,out value); 
		}
	}

	public class opaque
	{
		public byte[] buffer;
		public long Load(byte[] buffer,long offset) {
			long length;
			var new_offset = BufferTools.ReadNumberFromBuffer(buffer,offset,2,out length);
			this.buffer = new byte[length];
			Array.Copy (buffer, new_offset, this.buffer, 0, length);
			return offset+2+length;
		}
	}
}