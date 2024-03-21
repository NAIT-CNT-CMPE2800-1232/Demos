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

namespace TheServer
{
    public partial class ServerForm : Form
    {
        Socket _lSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Socket _cSocket = null;
        public ServerForm()
        {
            InitializeComponent();
        }

        private void UI_CB_Enable_CheckedChanged(object sender, EventArgs e)
        {
            if(UI_CB_Enable.Checked)
            {
                // NOTE: EACH of these should be in a separate try/catch block
                // create the soon to be listening socket
                try
                {
                    _lSock.Bind(new IPEndPoint(IPAddress.Any, 1666));
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("Looks like a server is already running. Please stop first server, then try again.");
                    Application.Exit();
                    return;
                }
                try
                {
                    _lSock.Listen(5);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                try
                {
                    _lSock.BeginAccept(cbAcceptDone, null);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("We made it!!");
            }
        }
        private void cbAcceptDone(IAsyncResult ar)
        {
            try
            {
                _cSocket = _lSock.EndAccept(ar);

                // if all goes well, a socket is created for you, and
                // is connected to the remote end point.
                // you must take custody of this socket!
                try
                {
                    Invoke(new Action(() => { Text = "CUSTODY FOUND"; }));

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


                
            }
            catch (Exception err)
            {
                // accept failed. Weird, but can happen.
                Console.WriteLine(err.Message);
            }
            // the listener DOES NOT automatically look for another connection
            // if you want more connections, you need to call BeginAccept again
            // if you don't want more connections, you should Close() the listener
            _lSock.Close();
        }
    }
}
