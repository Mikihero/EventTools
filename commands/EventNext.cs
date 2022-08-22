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
    class EventNext : ICommand
    {
        public string Command => "EventNext";

        public string[] Aliases { get; set; } = { "enext" };

        public string Description => "Sends an announcement about an event happening next round.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if(arguments.Count == 0)
            {
                response = "Usage: EventNext {EventName}";
                return false;
            }
            else
            {
                string message = string.Join(" ", arguments);
                string MessageStart = Plugin.Instance.Config.EventNextMessage1;
                string MessageEnd = Plugin.Instance.Config.EventNextMessage2;
                Map.Broadcast(10, MessageStart + message + MessageEnd);
                response = "Broadcast sent!";
                return true;
            }
        }
    }
}
