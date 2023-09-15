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

        private static void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            MessageBox.Show("Received from the server: " + e.Data);

            try
            {
                //Vector pos = JsonConvert.DeserializeObject<Vector>(e.Data);
                //Console.WriteLine("Created a vector: " + pos.x + "," + pos.y);
                //DrawDot(pos.x, pos.y, 50, 15, 1);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
                //Console.WriteLine("I don't know what to do with \"" + e.Data + "\"");
                MessageBox.Show("I don't know what to do with \"" + e.Data + "\"");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}