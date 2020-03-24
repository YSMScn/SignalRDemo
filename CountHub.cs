using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Service;

namespace SignalRDemo
{
    //[Authorize]
    public class CountHub : Hub
    {
        private readonly CountService countService;

        public CountHub(CountService countService)
        {
            this.countService = countService;
        }

        public async Task GetLatestCount(string random)
        {
            //var user = Context.User.Identity.Name;
            int count;
            do {
                count = countService.GetLatestCount();
                Thread.Sleep(1000);
                await Clients.All.SendAsync("ReceiveUpdate", count);
            }
            while (count < 10);
            await Clients.All.SendAsync("Finished");
        }

        public override async Task OnConnectedAsync()
        {
            //var connectedId = Context.ConnectionId;
            //var client = Clients.Client(connectedId);
            //await client.SendAsync("someFunc",new { });
            //await Clients.AllExcept(connectedId).SendAsync("someFunc", new { });

            //await Groups.AddToGroupAsync(connectedId, "MyGroup");
            //await Groups.RemoveFromGroupAsync(connectedId, "MyGroup");

            //await Clients.Groups("MyGroup").SendAsync("someFunc");

        }
    }
}
