using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandSystem;
using Exiled.API.Features;

namespace EventTools.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class EventNext : ICommand, IUsageProvider
    {
        public string Command => "EventNext";

        public string[] Aliases { get; set; } = { "enext" };

        public string Description => "Sends a broadcast about an event happening next round.";

        public string[] Usage { get; set; } = { "event name" };

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if(arguments.Count == 0)
            {
                response = "Incorrect usage.";
                return false;
            }
            else
            {
                string eventname = string.Join(" ", arguments);
                string message = Plugin.Instance.Config.ENextMessage.Replace("{EVENTNAME}", eventname);
                Map.Broadcast(10, message);
                response = "Broadcast sent!";
                return true;
            }
        }
    }
}
