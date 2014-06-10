using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;


// State object for reading client data asynchronously
public class StateObject {
	// Client  socket.
	public Socket workSocket = null;
	// Size of receive buffer.
	public const int BufferSize = 1024;
	// Receive buffer.
	public byte[] buffer = new byte[BufferSize];
	// Received data string.
	public StringBuilder sb = new StringBuilder();  
}

public class AsynchronousSocketListener {
	// Thread signal.
	public static ManualResetEvent allDone = new ManualResetEvent(false);

	public AsynchronousSocketListener() {
	}

	public static void StartListening() {
		// Data buffer for incoming data.
		byte[] bytes = new Byte[1024];

		// Establish the local endpoint for the socket.
		// The DNS name of the computer
		// running the listener is "host.contoso.com".
		IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
		IPAddress ipAddress = ipHostInfo.AddressList[0];
		IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

		// Create a TCP/IP socket.
		Socket listener = new Socket(AddressFamily.InterNetwork,
			SocketType.Stream, ProtocolType.Tcp );

		// Bind the socket to the local endpoint and listen for incoming connections.
		try {
			listener.Bind(localEndPoint);
			listener.Listen(100);

			while (true) {
				// Set the event to nonsignaled state.
				allDone.Reset();

				// Start an asynchronous socket to listen for connections.
				Console.WriteLine("Waiting for a connection..."+ipHostInfo.HostName );
				listener.BeginAccept( 
					new AsyncCallback(AcceptCallback),
					listener );

				// Wait until a connection is made before continuing.
				allDone.WaitOne();
			}

		} catch (Exception e) {
			Console.WriteLine(e.ToString());
		}

		Console.WriteLine("\nPress ENTER to continue...");
		Console.Read();

	}

	public static void AcceptCallback(IAsyncResult ar) {
		// Signal the main thread to continue.
		allDone.Set();

		// Get the socket that handles the client request.
		Socket listener = (Socket) ar.AsyncState;
		Socket handler = listener.EndAccept(ar);

		// Create the state object.
		StateObject state = new StateObject();
		state.workSocket = handler;
		handler.BeginReceive( state.buffer, 0, StateObject.BufferSize, 0,
			new AsyncCallback(ReadCallback), state);
	}

	public static void ReadCallback(IAsyncResult ar) {
		String content = String.Empty;

		// Retrieve the state object and the handler socket
		// from the asynchronous state object.
		StateObject state = (StateObject) ar.AsyncState;
		Socket handler = state.workSocket;

		// Read data from the client socket. 
		int bytesRead = handler.EndReceive(ar);

		if (bytesRead > 0) {
			// There  might be more data, so store the data received so far.
			state.sb.Append (Encoding.ASCII.GetString (
				state.buffer, 0, bytesRead));

			// Check for end-of-file tag. If it is not there, read 
			// more data.
			var i = 0;
			var content_type = (uint)(state.buffer [i]); i += 1;
			var major = (uint)(state.buffer [i]); i += 1;
			var minor = (uint)(state.buffer [i]); i += 1;
			var length = (state.buffer[i]<<8)+state.buffer[i+1]; i += 2; 
			var message_type = (uint)(state.buffer [i]); i += 1;
			var message_length = (state.buffer[i]<<16)+(state.buffer[i+1]<<8)+state.buffer[i+2]; i += 3; 
			var major2 = (uint)(state.buffer [i]); i += 1;
			var minor2 = (uint)(state.buffer [i]); i += 1;


			var unix = BitConverter.ToInt16(state.buffer, i);	i += 4; 
			var random = new byte[28];
			Buffer.BlockCopy (state.buffer, i, random, 0, 28);  i += 28;




			var session_id_c = (uint)(state.buffer [i]); i += 1;
			var session_id = new byte[session_id_c];
			Buffer.BlockCopy (state.buffer, i, session_id, 0, (int)session_id_c); i += (int)session_id_c;


			var cipher_suite_count = ((state.buffer[i]<<8)+state.buffer[i+1])/2; i += 2; 
			var cipher_suits = new System.Collections.Generic.List<byte[]> ();
			var cipher_suite = new byte[2];
			for (var csi = 0; csi < cipher_suite_count; csi++) 
			{
				Buffer.BlockCopy (state.buffer, i+(csi*2), cipher_suite, 0, 2); 
				cipher_suits.Add (cipher_suite);
				cipher_suite = new byte[2];
			}
			i += ((int)cipher_suite_count * 2);

			var compression_method_count = state.buffer[i]; i += 1; 
			var compression_method = new System.Collections.Generic.List<byte> ();
			for (var cmi = 0; cmi < compression_method_count; cmi++) 
			{
				compression_method.Add (state.buffer [i]);
				i += 1;
			}

			var extension_type = (uint)(state.buffer [i]); i += 1;
			var extension_length = state.buffer[i]; i += 1; 


			content = state.sb.ToString();
			if (content.IndexOf("\r\n\r\n") > -1) {
				// All the data has been read from the 
				// client. Display it on the console.
				Console.WriteLine("Read {0} bytes from socket. \n Data : {1}",
					content.Length, content );
				// Echo the data back to the client.
				Send(handler, content);
			} else {
				// Not all data received. Get more.
				handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
					new AsyncCallback(ReadCallback), state);
			}
		}
	}

	private static void Send(Socket handler, String data) {
		// Convert the string data to byte data using ASCII encoding.
		byte[] byteData = Encoding.ASCII.GetBytes(data);

		// Begin sending the data to the remote device.
		handler.BeginSend(byteData, 0, byteData.Length, 0,
			new AsyncCallback(SendCallback), handler);
	}

	private static void SendCallback(IAsyncResult ar) {
		try {
			// Retrieve the socket from the state object.
			Socket handler = (Socket) ar.AsyncState;

			// Complete sending the data to the remote device.
			int bytesSent = handler.EndSend(ar);
			Console.WriteLine("Sent {0} bytes to client.", bytesSent);

			handler.Shutdown(SocketShutdown.Both);
			handler.Close();

		} catch (Exception e) {
			Console.WriteLine(e.ToString());
		}
	}


	public static int Main(String[] args) {
		StartListening();
		return 0;
	}
}