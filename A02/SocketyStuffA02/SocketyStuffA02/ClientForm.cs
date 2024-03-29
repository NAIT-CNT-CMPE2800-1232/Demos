﻿using System;
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

namespace SocketyStuffA02
{
    public partial class ClientForm : Form
    {
        Socket _Client = null;

        public ClientForm()
        {
            InitializeComponent();
            _ConnectButton.Click += _ConnectButton_Click;
        }

        private void _ConnectButton_Click(object sender, EventArgs e)
        {
            _Client = new Socket
            (
                AddressFamily.InterNetwork, // IP V4 address scheme
                SocketType.Stream, // streaming socket (connection-based)
                ProtocolType.Tcp
            );

            _Client.BeginConnect
            (
                "localhost", // target address (a string, supports DNS lookup)
                1666, // target port
                cbCallback, // callback function when operation completes
                null
            );
        }

        private void cbCallback(IAsyncResult result)
        {
            try
            {
                _Client.EndConnect(result); // complete the connection attempt
                                            // no error! We should be connected!
                                            // update a control in the form, Invoke is required
                try 
                {
                    Invoke(new Action(() => { Text = "Connected!"; }));
                }
                catch (Exception formInvokeError) 
                {
                    Console.WriteLine(formInvokeError.Message);
                }
            }
            catch (Exception endConnectError)
            {
                // not connected... what should you do?
                Console.WriteLine(endConnectError.Message);
            }

        }

        private void UI_btn_send_Click(object sender, EventArgs e)
        {
            string message = "Hello from the client";
            byte[] data = Encoding.UTF8.GetBytes(message);

            try
            {
                _Client.Send(data);
                _Client.Send(data);
                Trace.WriteLine(data.Length);
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Error sending data {ex.Message}");
            }
        }
    }
}
