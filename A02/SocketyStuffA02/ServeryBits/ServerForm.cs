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
using System.Diagnostics;
using System.Threading;

namespace ServeryBits
{
    public partial class ServerForm : Form
    {
        Socket _lSock = null;
        Socket _cSock = null;
        Thread _RXThread = null;
        private const int GBufferSize = 1024;


        public ServerForm()
        {
            InitializeComponent();
            Shown += ServerForm_Shown;
            

        }

        private void ServerForm_Shown(object sender, EventArgs e)
        {
            connect();
        }

        private void connect()
        {
            try
            {
                _lSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
            catch (Exception ex)
            {
                Trace.WriteLine("error making the socket");
                Trace.WriteLine($"God how are you here? {ex.Message}");
                return;
            }

            try
            {
                // bind to any interface, on port 1666
                _lSock.Bind(new IPEndPoint(IPAddress.Any, 1666));
            }
            catch (Exception ex1)
            {
                Trace.WriteLine("error binding");
                Trace.WriteLine($"God how are you here? {ex1.Message}");
                return;
            }
            try
            {
                // start listening (does not fully accept connections at this point)
                _lSock.Listen(5);

            }
            catch (Exception ex2)
            {
                Trace.WriteLine("error listening?");
                Trace.WriteLine($"God how are you here? {ex2.Message}");
                return;
            }
            try
            {
                // start the asynchronous accepting process (will wait if necessary)
                _lSock.BeginAccept(cbAcceptDone, null);

            }
            catch (Exception ex3)
            {
                Trace.WriteLine($"God how are you here? {ex3.Message}");
                return;
            }
        }
        private void cbAcceptDone(IAsyncResult ar)
        {
            try
            {
                _cSock = _lSock.EndAccept(ar);

                _RXThread = new Thread(cbRXThread);
                _RXThread.IsBackground = true;
                _RXThread.Start();
                Trace.WriteLine("Thread Started");

                // if all goes well, a socket is created for you, and
                // is connected to the remote end point.
                // you must take custody of this socket!
                try
                {
                    Invoke(new Action(() => Text = "Connected!"));
                }catch (Exception ex)
                {
                    Trace.WriteLine(ex.Message);
                    
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
        }


        private void cbRXThread()
        {
            // bring the socket into a receiving state
            while (true)
            {
                // rx just the bytes from this pass
                byte[] transientbuff = new byte[GBufferSize];
                try
                {
                    int iBytesRxed = _cSock.Receive(transientbuff);
                    if (iBytesRxed == 0)
                    {
                        // soft disco
                        Trace.WriteLine($"Soft disconnect in receive.");
                        return;
                    }
                    // process data!
                    Trace.WriteLine($"Bytes Recieved: {iBytesRxed}");
                }
                catch (Exception err)
                {
                    // hard disco
                    Trace.WriteLine($"Hard disconnect in receive: {err.Message}");
                    return;
                }
            }
        }


    }
}
