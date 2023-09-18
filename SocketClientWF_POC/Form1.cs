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
            using (WebSocket ws = new WebSocket("ws://127.0.0.1:7890/EchoAll"))
            {
                ws.OnOpen += (sender, e) =>
                 listBox1.Items.Add(string.Format("Connected to {0} successfully ", "ws://127.0.0.1:7890/EchoAll"));
                ws.OnError += (sender, e) =>
                   listBox1.Items.Add("Error: " + e.Message);
                ws.OnMessage += (sender, e) =>
                   listBox1.Items.Add("Echo: " + e.Data);
                ws.OnClose += (sender, e) =>
                   listBox1.Items.Add(string.Format("Disconnected with {0}", "ws://127.0.0.1:7890/EchoAll"));
                ws.OnMessage += Ws_OnMessage;
                ws.Connect();
                ws.Send("Hello from Windows Form Client!");
                Thread.Sleep(1000);
            }
        }

        private static void Ws_OnMessage(object? sender, MessageEventArgs e)
        {
            try
            {
                CommonData.serverData = e.Data;
                //MessageBox.Show("Received from the server: " + e.Data);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("I don't know what to do with \"" + e.Data + "\"");
            }
        }

        private  void Ws_OnMessage1(object? sender, MessageEventArgs e)
        {
            try
            {
                CommonData.serverData = e.Data;
                textBox1.Text = "";
            }
            catch (Exception ex)
            {
                //MessageBox.Show("I don't know what to do with \"" + e.Data + "\"");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (WebSocket ws = new WebSocket("ws://127.0.0.1:7890/EchoAll"))
            {

                ws.OnMessage += Ws_OnMessage;
                ws.Connect();
                ws.Send("Hello from Windows Button Client!");
                string received = string.IsNullOrEmpty(CommonData.serverData) ? "Error" : CommonData.serverData;
                listBox1.Items.Add(received);
                textBox1.Text = "";
                textBox1.Text = received;
                //Thread.Sleep(500);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            using (WebSocket ws = new WebSocket("ws://127.0.0.1:7890/EchoAll"))
            {

                ws.OnMessage += Ws_OnMessage1;
                ws.Connect();
                ws.Send("Hello from Windows Text Client!");
                string received = string.IsNullOrEmpty(CommonData.serverData) ? "Error" : CommonData.serverData;
                listBox1.Items.Add(received);
                textBox1.Text = received;
                Thread.Sleep(500);
            }
        }
    }
}
