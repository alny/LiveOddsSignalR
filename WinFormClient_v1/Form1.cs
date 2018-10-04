using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormClient_v1 {
    public partial class Form1 : Form {

        HubConnection connection;
        int result;
        public Form1() {
            InitializeComponent();

            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:62618/oddshub")
                .Build();
            connection.StartAsync();
            

            connection.On<string, decimal>("BroadcastOdds", (text, rating) => {
                listBox1.Items.Add(text + " - Odds: " + rating);
            });

 
        }

        private void button1_Click(object sender, EventArgs e) {
            try {
                label2.Text = "Match Started";
                connection.InvokeAsync("BroadcastOdds");
            } catch (Exception) {

                throw;
            }

        }

        private void button2_Click(object sender, EventArgs e) {
            
            foreach (var item in listBox1.SelectedItems) {
                var getNumber = Regex.Match(item.ToString(), @"\d+").Value;
                int j;
                int h;
                int.TryParse(textBox1.Text, out j);
                int.TryParse(getNumber, out h);
                result = j * h;
                
            }
            MessageBox.Show("You placed a bet, & can win: " + result.ToString() + ".00 DKK");
            textBox1.Clear();
            result = 0;
        }
    }
}
