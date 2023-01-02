﻿using System;
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
    class EventPrep : ICommand
    {
        public string Command { get; } = "EventPrep";

        public string[] Aliases { get; } = { "ep" };

        public string Description { get; } = "Allows for easy event preparation.";

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
                foreach (Ragdoll doll in Map.Ragdolls)
                    NetworkServer.Destroy(doll.GameObject);
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
            if (Plugin.Instance.Config.EPLockAllDoors)
            {
                Door.LockAll(9999, DoorLockType.AdminCommand);
            }
            if (Plugin.Instance.Config.EPEnableNoclip)
            {
                FpcNoclip.PermitPlayer(Player.Get(sender).ReferenceHub);
            }
            if (Plugin.Instance.Config.EPDisableElevators)
            {
                IsEventActive = true;
            }
            response = "Successfully executed the command.";
            return true;
        }
    }
}
