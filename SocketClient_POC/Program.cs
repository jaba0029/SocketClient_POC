using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebSocketSharp;
using Newtonsoft.Json;
using System.Security.AccessControl;
using SocketClientWF_POC;

namespace csharp_client
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a scoped instance of a WS client that will be properly disposed
            //using (WebSocket ws = new WebSocket("ws://simple-websocket-server-echo.glitch.me/"))
            using (WebSocket ws = new WebSocket("ws://127.0.0.1:7890/Echo"))
            {
                ws.OnMessage += Ws_OnMessage;
                
                ws.Connect();
                ws.Send("Hello from Console Client!");

                Console.ReadKey();
            }
        }

        private static void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            SocketClientWF_POC.CommonData.serverData = e.Data;
            try
            {
                string received = string.IsNullOrEmpty(CommonData.serverData) ? "Error" : CommonData.serverData;
                Console.WriteLine(received);
            }
            catch (Exception ex)
            {
                Console.WriteLine("I don't know what to do with \"" + e.Data + "\"");
            }

        }

    }
}