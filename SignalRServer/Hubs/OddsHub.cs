using Microsoft.AspNetCore.SignalR;
using SignalRServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRServer.Hubs {
    public class OddsHub : Hub {

        List<Odds> Gamelog;

        public OddsHub() {
            Gamelog = new List<Odds>();
            Gamelog.Add(new Odds {Rating = 20,Text = "Dupreeh ace next round"});
            Gamelog.Add(new Odds { Rating = 5, Text = "device gets HE next round" });
            Gamelog.Add(new Odds { Rating = 150, Text = "gla1ve knifes coldzera on B site" });
            Gamelog.Add(new Odds { Rating = 120, Text = "fer plants the bomb 10 sec before time" });
            Gamelog.Add(new Odds { Rating = 2, Text = "Astralis will win 2nd Pistol round" });
        }

        public async Task BroadcastOdds() {

            Random random = new Random();
            int mseconds = random.Next(3, 8) * 1000;

            foreach (var log in Gamelog) {
                Thread.Sleep(mseconds);
                await Clients.All.SendAsync("BroadcastOdds", log.Text, log.Rating);
            }

        }

    }
}
