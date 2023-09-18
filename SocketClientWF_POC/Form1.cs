using WebSocketSharp;
namespace SocketClientWF_POC
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }



        private void Ws_OnMessage(object? sender, MessageEventArgs e)
        {
            try
            {
                MessageBox.Show("Received from the server: " + e.Data);
                listBox1.Items.Add("Echo: " + e.Data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("I don't know what to do with \"" + e.Data + "\"");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (WebSocket ws = new WebSocket("ws://127.0.0.1:7890/EchoAll"))
            {
                //ws.OnOpen += (ss, ee) =>
                // listBox1.Items.Add(string.Format("Connected to {0} successfully ", "ws://127.0.0.1:7890/EchoAll"));
                //ws.OnError += (ss, ee) =>
                //   listBox1.Items.Add("    Error: " + ee.Message);
                //ws.OnClose += (ss, ee) =>
                //   listBox1.Items.Add(string.Format("Disconnected with {0}", "ws://127.0.0.1:7890/EchoAll"));
                ws.OnMessage += Ws_OnMessage;
                ws.Connect();
                ws.Send("Hello from Windows Client!");
            }
        }
    }
}
