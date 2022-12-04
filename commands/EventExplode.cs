using System;
using CommandSystem;
using Exiled.API.Features;
using Exiled.API.Enums;
using Exiled.Permissions.Extensions;

namespace EventTools.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class EventExplode : ICommand
    {
        public string Command => "EventExplode";

        public string[] Aliases { get; set; } = { "eexplode", "eboom", "enuke" };

        public string Description => "Ends the event (and round) with a bang!";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Permissions.CheckPermission(Player.Get(sender), "et.eexplode"))
            {
                response = "You don't have permission to use this command.";
                return false;
            }
            foreach (Player player in Player.List)
            {
                player.Teleport(Door.Get(DoorType.Scp106Bottom));
                player.IsGodModeEnabled = false;
            }
            Round.IsLocked = false;
            Warhead.Detonate();
            response = "Everyone is sad because the event is over (and also they exploded!).";
            return true;
        }
    }
}
