using System;
using System.Runtime.Remoting.Messaging;
using CommandSystem;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using Interactables.Interobjects;
using Interactables.Interobjects.DoorUtils;
using MapGeneration;
using PlayerRoles.PlayableScps.Scp939.Mimicry;

namespace EventTools.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class ElevatorLock : ICommand, IUsageProvider
    {
        public string Command => "ElevatorLock";
        public string[] Aliases => new[] { "elock" };
        public string Description => "Locks elevators in the facility";
        public string[] Usage => new[] { "zone", "(optional)"};

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Player.Get(sender).CheckPermission("et.elock"))
            {
                response = "You don't have permission to use this command.";
                return false;
            }
            if(arguments.Count == 0)
            {
                Door.Get(DoorType.ElevatorNuke).ChangeLock(DoorLockType.AdminCommand);
                Door.Get(DoorType.ElevatorScp049).ChangeLock(DoorLockType.AdminCommand);
                Door.Get(DoorType.ElevatorGateA).ChangeLock(DoorLockType.AdminCommand);
                Door.Get(DoorType.ElevatorGateB).ChangeLock(DoorLockType.AdminCommand);
                Door.Get(DoorType.ElevatorLczA).ChangeLock(DoorLockType.AdminCommand);
                Door.Get(DoorType.ElevatorLczB).ChangeLock(DoorLockType.AdminCommand);
                response = "Command executed successfully.";
                return true;    
            }

            if (arguments.Count != 1 || !Enum.TryParse(arguments.At(0), true, out ZoneType zone))
            {
                response = "Incorrect usage.";
                return false;
            }

            switch (zone)
            {
                case ZoneType.LightContainment:
                    Door.Get(DoorType.ElevatorLczA).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.ElevatorLczB).ChangeLock(DoorLockType.AdminCommand);
                    break;
                case ZoneType.HeavyContainment:
                    Door.Get(DoorType.ElevatorNuke).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.ElevatorScp049).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.ElevatorLczA).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.ElevatorLczB).ChangeLock(DoorLockType.AdminCommand);
                    break;
                case ZoneType.Entrance:
                    Door.Get(DoorType.ElevatorGateA).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.ElevatorGateB).ChangeLock(DoorLockType.AdminCommand);
                    break;
                case ZoneType.Surface:
                    Door.Get(DoorType.ElevatorGateA).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.ElevatorGateB).ChangeLock(DoorLockType.AdminCommand);
                    break;
                default:
                    response = "Incorrect usage.";
                    return false;
            }
            
            response = "Command executed successfully.";
            return true;
        }
    }
}