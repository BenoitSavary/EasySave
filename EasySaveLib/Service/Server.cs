using EasySaveLib.Model;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class Server
{
    public Stockage stockage { get; set; }

    public Server(Stockage stockage)
    {
        this.stockage = stockage; 
        RunServer();
        
    }

    public void RunServer()
    {

        IPHostEntry myhost = Dns.GetHostEntry("localhost");
        IPAddress ipAddr = myhost.AddressList[0];
        IPEndPoint myEndPoint = new IPEndPoint(ipAddr, 11000);

        try
        {

            Socket listenerSocket = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            listenerSocket.Bind(myEndPoint);
            while (true)
            {

            
            listenerSocket.Listen(5);

            Console.WriteLine("Waiting for Client Socket to Coonect...");
            Socket socketHandler = listenerSocket.Accept();
            
            // data from the client.
            string myData = null;
            byte[] dataBytes = null;

            while (true)
            {
                dataBytes = new byte[1023];
                int bytesRece = socketHandler.Receive(dataBytes);
                myData += Encoding.ASCII.GetString(dataBytes, 0, bytesRece);

                if (myData.IndexOf("<EOF>") > -1)
                {
                    myData = myData.Remove(myData.Length - 5);
                    break;
                }
            }
            
            stockage.EtatServeur = myData;
            Console.WriteLine("Data Received from Client : {0}", myData);

            byte[] msg = Encoding.ASCII.GetBytes("Ordre executer");
            socketHandler.Send(msg);
            socketHandler.Shutdown(SocketShutdown.Both);
            socketHandler.Close();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        Console.WriteLine("\n Press any key to continue...");
        //Console.ReadKey();
    }

}


