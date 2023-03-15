using System;
using System.Linq;
using CommandSystem;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Pickups;
using Exiled.Permissions.Extensions;
using LightContainmentZoneDecontamination;
using PlayerRoles;
using PlayerRoles.FirstPersonControl;
using Map = PluginAPI.Core.Map;

namespace EventTools.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class EventPrep : ICommand
    {
        public string Command => "EventPrep";

        public string[] Aliases { get; } = { "eprep" };

        public string Description => "Allows for easy event preparation.";

        public static bool IsEventActive = false;
        
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Player.Get(sender).CheckPermission("et.eprep"))
            {
                response = "You don't have permission to use this command.";
                return false;
            }

            if (Plugin.Instance.Config.EPCloseDoors)
            {
                foreach (Door door in Door.List)
                {
                    door.IsOpen = false;
                }
            }
            
            if (Plugin.Instance.Config.EPRoundLock)
            {
                Round.IsLocked = true;
            }
            
            if (Plugin.Instance.Config.EPLockClassD)
            {
                foreach (Door door in Door.List.Where(x => x.Type == DoorType.PrisonDoor))
                {
                    door.ChangeLock(DoorLockType.AdminCommand);
                    door.IsOpen = false;
                }
            }
            
            if (Plugin.Instance.Config.EPForceClassEveryone)
            {
                foreach (Player player in Player.List)
                {
                    player.Role.Set(RoleTypeId.Tutorial);
                    player.Role.Set(RoleTypeId.ClassD);
                }
            }
            
            if (Plugin.Instance.Config.EPFCToTutorial)
            {
                Player.Get(sender).Role.Set(RoleTypeId.Tutorial);
            }
            
            if (Plugin.Instance.Config.EPCleanup)
            {
                foreach (Ragdoll ragdoll in Ragdoll.List.ToList()) 
                    ragdoll.Destroy();
                foreach (Pickup pickup in Pickup.List.ToList()) 
                    pickup.Destroy();
            }
            
            if (Plugin.Instance.Config.EPEnableNoclip)
            {
                Player.Get(sender).IsNoclipPermitted = true;
            }

            if (Plugin.Instance.Config.EPDisableDecont)
            {
                DecontaminationController.Singleton.NetworkDecontaminationOverride = DecontaminationController.DecontaminationStatus.Disabled;
            }

            IsEventActive = true;
            response = "Successfully executed the command.";
            return true;
        }
    }
}
