using System;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;

namespace EventTools.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class EventFinish : ICommand
    {
        public string Command => "EventFinish";

        public string[] Aliases => new[] { "EFinish" };

        public string Description => "Finishes the current event.";

        public static bool FriendlyFireState;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Player.Get(sender).CheckPermission("et.efinish"))
            {
                response = "You don't have permission to use this command.";
                return false;
            }
            if (!Round.IsStarted)
            {
                response = "You can't use this command before the round starts.";
                return false;
            }
            Server.FriendlyFire = FriendlyFireState;
            EventPrep.IsEventActive = false;
            response = "Sucessfully executed the command.";
            return true;   
        }
    }
}
