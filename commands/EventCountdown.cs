using System;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;

namespace EventTools.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class EventCountdown : ICommand
    {
        public string Command { get; } = "EventCountdown";

        public string[] Aliases { get; set; } = { "ecount" };

        public string Description { get; } = "Sends a cassie countdown specified in the plugins config.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Permissions.CheckPermission(Player.Get(sender), "et.ecount"))
            {
                response = "You don't have permission to use this command.";
                return false;
            }
            Cassie.Message(Plugin.Instance.Config.ECCassieMessage, false, false, Plugin.Instance.Config.ECSubtitles);
            response = "Countdown started";
            return true;
        }
    }
}
