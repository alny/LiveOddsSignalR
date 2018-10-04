using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleClient {
    class Program {
        public static void Main(string[] args) {

            SetupConnection();
        }


        public static async Task SetupConnection() {
            var connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:49833/oddshub")
                .Build();


            await connection.StartAsync();
            await connection.InvokeAsync("BroadcastOdds");
        }

    }
}
