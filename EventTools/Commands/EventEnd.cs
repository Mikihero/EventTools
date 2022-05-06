using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandSystem;
using Exiled.API;
using Exiled.Events;
using Exiled.API.Features;
using Exiled.API.Enums;

namespace EventTools.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class EventEnd : ICommand
    {
        public string Command => "EventEnd";

        public string[] Aliases { get; set; } = { "Eventfinish"};

        public string Description => "Finishes the event with a bang!";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            foreach(Player player in Player.List)
            {
                player.Teleport(Door.Get(DoorType.PrisonDoor));
                player.IsGodModeEnabled = false;
            }
            Round.IsLocked = false;
            Warhead.Detonate();
            string responseMessage = EventTools.Instance.Config.EventEndResponseMessage;
            response = "Everyone is sad because the event is over (and also they exploded!).";
            return true;
        }
    }
}
