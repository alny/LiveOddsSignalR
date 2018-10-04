using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;

namespace WinFormClient {
    public partial class Form1 : Form {

        HubConnection connection;

        public Form1() {
            InitializeComponent();

            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:49833/oddshub")
                .Build();
            connection.StartAsync();

        }

        private void button1_Click(object sender, EventArgs e) {
            
            connection.On<string>("ReceiveMessage", (message) => {
                
                label2.Text = message;
                
            });

       

        }
    }
}
