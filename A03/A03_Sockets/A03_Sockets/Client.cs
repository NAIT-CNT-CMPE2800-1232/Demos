using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
namespace A03_Sockets
{
    public partial class MainForm : Form
    {
        Socket ConnSock = new Socket(
        AddressFamily.InterNetwork, // IP V4 address scheme
        SocketType.Stream, // streaming socket (connection-based)
        ProtocolType.Tcp); // TCP protocol

        public MainForm()
        {
            InitializeComponent();
            UI_SendBtn.Click += UI_SendBtn_Click;
        }

        private void UI_SendBtn_Click(object sender, EventArgs e)
        {
            string message = "This is a happy message :(";
            byte[] data = Encoding.UTF8.GetBytes(message);
            Console.WriteLine($"Sending {data.Length} bytes");
            ConnSock.Send(data);
        }

        private void _btn_Click(object sender, EventArgs e)
        {
            try
            {
                ConnSock.BeginConnect(
                "localhost", // target address (a string, supports DNS lookup)
                1666, // target port
                cbConnectDone, // callback function when operation completes
                null); // any info (object) to pass to callback
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void cbConnectDone(IAsyncResult result)
        {
            try
            {
                ConnSock.EndConnect(result); // complete the connection attempt
                                         // no error! We should be connected!

                try
                {
                    // update a control in the form, Invoke is required
                    Invoke(new Action(() => { Text = "Connected!"; }));
                    //UI_SendBtn.Enabled = true;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            catch (Exception err)
            {
                Console.WriteLine($"No connection, {err.Message}");
            }



        }
    }
}
