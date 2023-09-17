using System.Numerics;
using System.Windows.Forms;
using WebSocketSharp;
namespace SocketClientWF_POC
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //using (WebSocket ws = new WebSocket("ws://127.0.0.1:7890/EchoAll"))
            //{
            //    ws.OnOpen += (ss, ee) =>
            //     listBox1.Items.Add(string.Format("Connected to {0} successfully ", "ws://127.0.0.1:7890/EchoAll"));
            //    ws.OnError += (ss, ee) =>
            //       listBox1.Items.Add("    Error: " + ee.Message);
            //    ws.OnMessage += (ss, ee) =>
            //       listBox1.Items.Add("Echo: " + ee.Data);
            //    ws.OnClose += (ss, ee) =>
            //       listBox1.Items.Add(string.Format("Disconnected with {0}", "ws://127.0.0.1:7890/EchoAll"));
            //    ws.Connect();
            //    ws.Send("Hello from Windows Client!");
            //    //Console.ReadKey();           
            //}

        }


        private void button1_Click(object sender, EventArgs e)
        {
            //// Create a scoped instance of a WS client that will be properly disposed
            ////using (WebSocket ws = new WebSocket("ws://simple-websocket-server-echo.glitch.me/"))
            //using (WebSocket ws = new WebSocket("ws://127.0.0.1:7890/EchoAll"))
            //{
            //    //ws.OnMessage += Ws_OnMessage;
            //    ws.Connect();
            //    ws.Send("Hello from Windows Button Client!");
            //    //Console.ReadKey();
            //}
            using (WebSocket ws = new WebSocket("ws://127.0.0.1:7890/EchoAll"))
            {
                ws.OnOpen += (ss, ee) =>
                 listBox1.Items.Add(string.Format("Connected to {0} successfully ", "ws://127.0.0.1:7890/EchoAll"));
                ws.OnError += (ss, ee) =>
                   listBox1.Items.Add("    Error: " + ee.Message);
                ws.OnMessage += (ss, ee) =>
                   listBox1.Items.Add("Echo: " + ee.Data);
                ws.OnClose += (ss, ee) =>
                   listBox1.Items.Add(string.Format("Disconnected with {0}", "ws://127.0.0.1:7890/EchoAll"));
                ws.Connect();
                ws.Send("Hello from Windows Button Client!");
                //Console.ReadKey();           
            }

        }

        //private void Ws_OnMessage(object? sender, MessageEventArgs e)
        //{
        //    try
        //    {
        //        //Vector pos = JsonConvert.DeserializeObject<Vector>(e.Data);
        //        //Console.WriteLine("Created a vector: " + pos.x + "," + pos.y);
        //        //DrawDot(pos.x, pos.y, 50, 15, 1);
        //        MessageBox.Show("Received from the server: " + e.Data);
        //    }
        //    catch (Exception ex)
        //    {
        //        //Console.WriteLine(ex);
        //        //Console.WriteLine("I don't know what to do with \"" + e.Data + "\"");
        //        MessageBox.Show("I don't know what to do with \"" + e.Data + "\"");
        //    }
        //}
    }
}