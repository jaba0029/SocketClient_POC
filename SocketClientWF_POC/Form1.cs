using System.Drawing;
using System;
using WebSocketSharp;
namespace SocketClientWF_POC
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        WebSocket ws = new WebSocket("ws://127.0.0.1:7890/Echo");
        private void Form1_Load(object sender, EventArgs e)
        {
            ws.OnMessage += Ws_OnMessage;
            ws.Connect();
            ws.Send("Hello from Windows Form Client!");
            Thread.Sleep(1000);
        }

        private void Ws_OnMessage(object? sender, MessageEventArgs e)
        {
            try
            {
                CommonData.serverData = e.Data;
                string received = string.IsNullOrEmpty(CommonData.serverData) ? "Error" : CommonData.serverData;
                Invoke(new MethodInvoker(() =>
                {
                    int pColor = int.Parse(received.Replace("Hola Mundo", "").Trim());
                    listBox1.Items.Add(received);
                    if ((pColor % 2) == 0)
                    {
                      pictureBox1.BackColor = Color.Green;
                    }
                    else if ((pColor % 3) ==0)
                    {
                        pictureBox1.BackColor = Color.Yellow;
                    }
                    else
                    { pictureBox1.BackColor = Color.Red;
                    }
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("I don't know what to do with \"" + e.Data + "\"");
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ws.Close();
        }


    }
}
