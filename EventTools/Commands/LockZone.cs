using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandSystem;
using Exiled.API.Features;
using Exiled.API.Enums;

namespace EventTools.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class LockZone : ICommand
    {
        public string Command { get; set; } = "lockzone";

        public string[] Aliases { get; set; } = { "zonelock", "lz", "zl" };

        public string Description { get; set; } = "Locks all the doors in a specified zone";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (arguments.Count != 1)
            {
                response = "Usage: lockzone lcz/hcz/ez/surface/all.";
                return false;
            }
            switch (arguments.At(0))
            {
                case "lcz": 
                    Door.LockAll(9999, ZoneType.LightContainment, DoorLockType.AdminCommand);
                    response = "Toggled door lock in LCZ.";
                    return true;
                case "hcz": 
                    Door.LockAll(9999, ZoneType.HeavyContainment, DoorLockType.AdminCommand);
                    response = "Toggled door lock in HCZ.";
                    return true;
                case "ez": 
                    Door.LockAll(9999, ZoneType.Entrance, DoorLockType.AdminCommand);
                    response = "Toggled door lock in HCZ.";
                    return true;
                case "surface": 
                    Door.LockAll(9999, ZoneType.Surface, DoorLockType.AdminCommand);
                    response = "Toggled door lock on the surface.";
                    return true;
                case "all":
                    Door.LockAll(9999, DoorLockType.AdminCommand);
                    response = "Toggled door lock everywhere in the facility.";
                    return true;
                default:
                    response = "Usage: lockzone lcz/hcz/ez/surface/all.";
                    return false;
            }
        }
    }
}
