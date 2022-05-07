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
    class EventNow : ICommand
    {
        public string Command => "EventNow";

        public string[] Aliases { get; set; } = { };

        public string Description => "Sends an announcement about an event happening this round.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if(arguments.Count == 0)
            {
                response = "Usage: EventNow {EventName}";
                return false;
            }
            else
            {
                string message = string.Join("", arguments);
                string MessageStart = EventTools.Instance.Config.EventNowMessage1;
                string MessageEnd = EventTools.Instance.Config.EventNowMessage2;
                Map.Broadcast(20, MessageStart + message + MessageEnd);
                response = "Broadcast sent!";
                return true;
            }
        }
    }
}
