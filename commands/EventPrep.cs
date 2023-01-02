using System;
using System.Linq;
using CommandSystem;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using InventorySystem.Items.Pickups;
using Mirror;
using PlayerRoles;
using PlayerRoles.FirstPersonControl;
using UnityEngine;
using Object = UnityEngine.Object;

namespace EventTools.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class EventPrep : ICommand
    {
        public string Command => "EventPrep";

        public string[] Aliases { get; } = { "eprep" };

        public string Description => "Allows for easy event preparation.";

        public static bool IsEventActive;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Player.Get(sender).CheckPermission("et.eprep"))
            {
                response = "You don't have permission to use this command.";
                return false;
            }
            if (Plugin.Instance.Config.EPCleanupRagdolls)
            {
                BasicRagdoll[] array = (from r in Object.FindObjectsOfType<BasicRagdoll>() orderby r.Info.CreationTime descending select r).ToArray();
                foreach (var t in array)
                {
                    NetworkServer.Destroy(t.gameObject);
                }
            }
            if (Plugin.Instance.Config.EPCleanupItems)
            {
                ItemPickupBase[] array = Object.FindObjectsOfType<ItemPickupBase>();
                foreach (ItemPickupBase item in array)
                {
                    NetworkServer.Destroy(item.gameObject);
                }
            }
            if (Plugin.Instance.Config.EPRoundLock)
            {
                Round.IsLocked = true;
            }
            if (Plugin.Instance.Config.EPRespawnTickets)
            {
                Respawn.NtfTickets = 1;
                Respawn.ChaosTickets = 1;
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
            if (Plugin.Instance.Config.EPTpToTower)
            {
                Player.Get(sender).Teleport(new Vector3(38, 1014, -31));
            }
            if (Plugin.Instance.Config.EPLockClassD)
            {
                foreach (Door door in Room.Get(RoomType.LczClassDSpawn).Doors)
                {
                    door.ChangeLock(DoorLockType.AdminCommand);
                }
            }
            if (Plugin.Instance.Config.EPEnableNoclip)
            {
                FpcNoclip.PermitPlayer(Player.Get(sender).ReferenceHub);
            }
            response = "Successfully executed the command.";
            return true;
        }
    }
}
