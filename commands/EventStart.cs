using CommandSystem;
using System;
using Exiled.API.Features.Items;
using Exiled.API.Features;
using Mirror;
using Exiled.API.Enums;

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
            if(Plugin.Instance.Config.ESCleanupRagdolls)
            {
                foreach (Ragdoll doll in UnityEngine.Object.FindObjectsOfType<Ragdoll>())
                    NetworkServer.Destroy(doll.gameObject);
            }
            if(Plugin.Instance.Config.ESCleanupItems)
            {
                foreach (Pickup item in Map.Pickups)
                    item.Destroy();
            }
            if(Plugin.Instance.Config.ESRoundLock)
            {
                Round.IsLocked = true;
            }
            if(Plugin.Instance.Config.ESRespawnTickets)
            {
                Respawn.NtfTickets = 1;
                Respawn.ChaosTickets = 1;
            }
            if(Plugin.Instance.Config.ESForceClassEveryone)
            { 
                foreach (Player player in Player.List)
                {
                    player.SetRole(RoleType.Tutorial);
                    player.SetRole(RoleType.ClassD);
                }
            }
            if(Plugin.Instance.Config.ESFCToTutorial)
            {
                Player.Get(sender).SetRole(RoleType.Tutorial);
            }
            if (Plugin.Instance.Config.ESLockAllDoors)
            {
                Door.LockAll(9999, DoorLockType.AdminCommand);
            }
            if (Plugin.Instance.Config.ESEnableNoclip)
            {
                Player.Get(sender).NoClipEnabled = true;
            }
            response = "The event has been succesfully started.";
            return true;
        }
    }
}
