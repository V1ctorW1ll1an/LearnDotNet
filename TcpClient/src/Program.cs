using System.Net.Sockets;
using System.Text;

static async Task SendHttpRequestASync(Uri? uri = null, int port = 80, CancellationToken cancellationToken = default)
{
  uri ??= new Uri("https://www.google.com");
  port = 80;

  // create a socket object
  using Socket socket = new(SocketType.Stream, ProtocolType.Tcp);
  socket.Connect(uri.Host, port);

  // Construct a minimalistic HTTP/1.1 request
  byte[] requestBytes = Encoding.ASCII.GetBytes(@$"GET {uri.AbsoluteUri} HTTP/1.0
Host: {uri.Host}
Connection: Close

");

  int bytesSent = 0;
  while (bytesSent < requestBytes.Length)
  {
    bytesSent += await socket.SendAsync(requestBytes.AsMemory(bytesSent), SocketFlags.None);
  }

  // Do minimalistic buffering assuming ASCII response
  byte[] responseBytes = new byte[256];
  char[] responseChars = new char[256];

  while (true)
  {
    int bytesReceived = socket.Receive(responseBytes);

    // Receiving 0 bytes means EOF has been reached
    if (bytesReceived == 0) break;

    // Convert byteCount bytes to ASCII characters using the 'responseChars' buffer as destination
    int charCount = Encoding.ASCII.GetChars(responseBytes, 0, bytesReceived, responseChars, 0);

    // Print the contents of the 'responseChars' buffer to Console.Out
    Console.Out.Write(responseChars, 0, charCount);
  }
}

await SendHttpRequestASync();