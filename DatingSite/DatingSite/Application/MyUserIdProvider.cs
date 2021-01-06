using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace DatingSite.Application
{
    public class MyUserIdProvider : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection)
        {
            return connection.User.Identity.Name;
        }
    }
}