using System;
using System.Collections.Generic;
using System.Linq;
using CommandSystem;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;

namespace EventTools.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class ElevatorLock : ICommand, IUsageProvider
    {
        public string Command => "ElevatorLock";
        public string[] Aliases => new[] { "elock" };
        public string Description => "Locks elevators in the facility";
        public string[] Usage => new[] { "zone (optional)", "use <b><u>ElevatorLock zones</u></b> to see all zones"};

        public HashSet<DoorType> ElevatorsToLock = new HashSet<DoorType>
        {
            DoorType.ElevatorNuke,
            DoorType.ElevatorScp049,
            DoorType.ElevatorGateA,
            DoorType.ElevatorGateB,
            DoorType.ElevatorLczA,
            DoorType.ElevatorLczB
        };
        
        public Dictionary<string, ZoneType> ZonesDict = new Dictionary<string, ZoneType>
        {
            { "lcz", ZoneType.LightContainment },
            { "hcz", ZoneType.HeavyContainment },
            { "ez", ZoneType.Entrance },
            { "surface", ZoneType.Surface }
        };

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Player.Get(sender).CheckPermission("et.elock"))
            {
                response = "You don't have permission to use this command.";
                return false;
            }
            if(arguments.Count == 0)
            {
                foreach (Door door in Door.List.Where(x => ElevatorsToLock.Contains(x.Type)))
                {
                    door.ChangeLock(DoorLockType.AdminCommand);
                }
                response = "Command executed successfully.";
                return true;    
            }

            if (arguments.Count != 1)
            {
                response = "Incorrect usage.";
                return false;
            }
            
            if (arguments.At(0) == "zones")
            {
                response = "<b>Possible zones:</b> \n - lcz \n - hcz \n - ez \n - surface";
                return false;
            }

            if (!ZonesDict.ContainsKey(arguments.At(0)))
            {
                response = "Incorrect usage.";
                return false;
            }
            
            switch (ZonesDict[arguments.At(0)])
            {
                case ZoneType.LightContainment:
                    foreach (Door door in Door.List.Where(x => x.Type == DoorType.ElevatorLczA || x.Type == DoorType.ElevatorLczB))
                    {
                        door.ChangeLock(DoorLockType.AdminCommand);
                    }
                    break;
                case ZoneType.HeavyContainment:
                    Door.Get(DoorType.ElevatorNuke).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.ElevatorScp049).ChangeLock(DoorLockType.AdminCommand);
                    foreach (Door door in Door.List.Where(x => x.Type == DoorType.ElevatorLczA || x.Type == DoorType.ElevatorLczB))
                    {
                        door.ChangeLock(DoorLockType.AdminCommand);
                    }
                    break;
                case ZoneType.Entrance:
                case ZoneType.Surface:
                    Door.Get(DoorType.ElevatorGateA).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.ElevatorGateB).ChangeLock(DoorLockType.AdminCommand);
                    break;
            }
            
            response = "Command executed successfully.";
            return true;
        }
    }
}