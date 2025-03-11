using Microsoft.AspNetCore.SignalR;

namespace WAAL.API.Hubs
{
    public class MyHub : Hub
    {
        public static Dictionary<string, string> userConnections = new Dictionary<string, string>();

        public override Task OnConnectedAsync()
        {
            var userId = Context.UserIdentifier;
            if (!string.IsNullOrEmpty(userId))
            {
                userConnections[userId] = Context.ConnectionId;
            }
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var userId = Context.UserIdentifier;
            if (!string.IsNullOrEmpty(userId))
            {
                userConnections.Remove(userId);
            }
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string receiverUserId, string message)
        {
            if (userConnections.TryGetValue(receiverUserId, out var connectionId))
            {
                await Clients.Client(connectionId).SendAsync("ReceiveMessage", Context.UserIdentifier, message);
            }
            else
            {
                Console.WriteLine($"Connection ID not found for user: {receiverUserId}");
            }
        }

    }
}
