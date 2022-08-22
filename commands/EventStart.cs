using CommandSystem;
using System;
using RemoteAdmin;
using Exiled.API.Features.Items;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using Mirror;
using Exiled.API.Enums;
using Exiled.API;

namespace EventTools.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class EventStart : ICommand
    {
        public string Command { get; } = "EventStart";

        public string[] Aliases { get; } = { "es" };

        public string Description { get; } = "Starts the event with parameters specified in the plugins config.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if(Plugin.Instance.Config.CleanupRagdolls == true)
            {
                foreach (Ragdoll doll in UnityEngine.Object.FindObjectsOfType<Ragdoll>())
                    NetworkServer.Destroy(doll.gameObject);
            }
            if(Plugin.Instance.Config.CleanupItems == true)
            {
                foreach (Pickup item in Map.Pickups)
                    item.Destroy();
            }
            if(Plugin.Instance.Config.RoundLock == true)
            {
                Round.IsLocked = true;
            }
            if(Plugin.Instance.Config.RespawnTickets == true)
            {
                Respawn.NtfTickets = 1;
                Respawn.ChaosTickets = 1;
            }
            if(Plugin.Instance.Config.ForceClassEveryone == true)
            { 
                foreach (Player player in Player.List)
                {
                    player.SetRole(RoleType.Tutorial);
                    player.SetRole(RoleType.ClassD);
                }
            }
            if(Plugin.Instance.Config.FCToTutorial == true)
            {
                Player.Get(sender).SetRole(RoleType.Tutorial);
            }
            if (Plugin.Instance.Config.LockAllDoors == true)
            {
                Door.LockAll(9999, DoorLockType.AdminCommand);
            }
            if (Plugin.Instance.Config.EnableNoclip == true)
            {
                Player.Get(sender).NoClipEnabled = true;
            }
            string responseMessage = Plugin.Instance.Config.EventStartResponseMessage;
            response = responseMessage;
            return true;
        }
    }
}
