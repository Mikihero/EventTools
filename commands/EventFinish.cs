using System;
using CommandSystem;
using Exiled.API.Features;

namespace EventTools.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class EventFinish : ICommand
    {
        public string Command => "EventFinish";

        public string[] Aliases => new string[] { "EFinish" };

        public string Description => "Finishes the current event by enabling the elevators and returning friendly fire back to normal.";

        public static bool FriendlyFireState = false;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Server.FriendlyFire = FriendlyFireState;
            FactionWars.IsEventActive = false;
            response = "Re-enabled the elevators!";
            return true;   
        }
    }
}
