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
    class EventCountdown : ICommand
    {
        public string Command { get; } = "EventCountdown";

        public string[] Aliases { get; } = { "ecount" };

        public string Description { get; } = "Sends a cassie countdown specified in the plugins config.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Cassie.Message(Plugin.Instance.Config.ECCassieMessage, false, false, Plugin.Instance.Config.ECSubtitles);
            response = "Countdown started";
            return true;
        }
    }
}
