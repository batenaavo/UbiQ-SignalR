using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace ServerSignalR.Hubs
{
    public class UbiQHub:Hub
    {
        public async Task UpdateUserList(string queue)
        {
            Console.WriteLine("UpdateUserList");
            await Groups.AddToGroupAsync(Context.ConnectionId, queue);
            await Clients.OthersInGroup(queue).SendAsync("ReceiveNewUserList");
        }   

        public async Task UpdateQueue(string queue)
        {
            Console.WriteLine("UpdateQueue");
            await Clients.OthersInGroup(queue).SendAsync("ReceiveNewQueue");
        }

        public async Task DeleteQueue(string queue)
        {
            Console.WriteLine("deleteQueue");
            await Clients.OthersInGroup(queue).SendAsync("QueueDeleted");
        }

        public async Task LoadTrack(string queue)
        {
            Console.WriteLine("LoadTrack");
            await Clients.OthersInGroup(queue).SendAsync("TrackLoaded");    
        }

        public async Task RemoveFromQueue(string queue)
        {
            Console.WriteLine("RemoveFromQueue");
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, queue);
        }

        public async Task BanFromQueue(string queue, string user)
        {
            Console.WriteLine("BanFromQueue");
            await Clients.OthersInGroup(queue).SendAsync("UserBanned", user);
        }
    }   
}
    