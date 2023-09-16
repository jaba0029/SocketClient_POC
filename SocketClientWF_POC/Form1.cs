using System.Numerics;
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
            
        }

        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a scoped instance of a WS client that will be properly disposed
            //using (WebSocket ws = new WebSocket("ws://simple-websocket-server-echo.glitch.me/"))
            using (WebSocket ws = new WebSocket("ws://127.0.0.1:7890/EchoAll"))
            {
                ws.OnMessage += Ws_OnMessage1;
                ws.Connect();
                ws.Send("Hello from Client!");
                //Console.ReadKey();
            }
        }

        private void Ws_OnMessage1(object? sender, MessageEventArgs e)
        {
            try
            {
                //Vector pos = JsonConvert.DeserializeObject<Vector>(e.Data);
                //Console.WriteLine("Created a vector: " + pos.x + "," + pos.y);
                //DrawDot(pos.x, pos.y, 50, 15, 1);
                MessageBox.Show("Received from the server: " + e.Data);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
                //Console.WriteLine("I don't know what to do with \"" + e.Data + "\"");
                MessageBox.Show("I don't know what to do with \"" + e.Data + "\"");
            }

        }
    }
}