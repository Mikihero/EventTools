using System;
using CommandSystem;
using Exiled.API.Features;

namespace EventTools.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class EventNow : ICommand, IUsageProvider
    {
        public string Command => "EventNow";

        public string[] Aliases { get; set; } = { "enow" };

        public string Description => "Sends an announcement about an event happening this round.";

        public string[] Usage { get; set; } = { "event name" };

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if(arguments.Count == 0)
            {
                response = "Invalid usage.";
                return false;
            }
            else
            {
                string eventname = string.Join(" ", arguments);
                string message = Plugin.Instance.Config.ENowMessage.Replace("{EVENTNAME}", eventname);
                Map.Broadcast(20, message);
                response = "Broadcast sent!";
                return true;
            }
        }
    }
}
