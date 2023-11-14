using System.Net;
using System.Net.Sockets;

IPAddress address = IPAddress.Parse(args[0]);

int min = int.Parse(args[1]);
int max = int.Parse(args[2]);

List<Task> tasks = new List<Task>();

for (int i = min; i <= max; i++)
{
    int port = i;
    tasks.Add(Task.Run(() =>
    {
        try{
            TcpClient client = new TcpClient();
            client.Connect(address, port);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Puerto {0} esta abierto", port);
        }catch{
            Console.ResetColor();
            Console.WriteLine("Puerto {0} esta cerrado", port);
        }
    }));
}

Task.WaitAll(tasks.ToArray());