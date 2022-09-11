using System;
using CommandSystem;
using Exiled.API.Features;
using Exiled.API.Enums;

namespace EventTools.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class EventEnd : ICommand
    {
        public string Command => "EventEnd";

        public string[] Aliases { get; set; } = { "Eventfinish", "eend"};

        public string Description => "Finishes the event with a bang!";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            foreach(Player player in Player.List)
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
