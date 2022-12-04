using CommandSystem;
using System;
using Exiled.API.Features.Items;
using Exiled.API.Features;
using Mirror;
using Exiled.API.Enums;
using Exiled.Permissions.Extensions;

namespace EventTools.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class EventPrep : ICommand
    {
        public string Command { get; } = "EventPrep";

        public string[] Aliases { get; } = { "ep" };

        public string Description { get; } = "Allows for easy event preparation.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Permissions.CheckPermission(Player.Get(sender), "et.eprep"))
            {
                response = "You don't have permission to use this command.";
                return false;
            }
            if (Plugin.Instance.Config.EPCleanupRagdolls)
            {
                foreach (Ragdoll doll in UnityEngine.Object.FindObjectsOfType<Ragdoll>())
                    NetworkServer.Destroy(doll.gameObject);
            }
            if(Plugin.Instance.Config.EPCleanupItems)
            {
                foreach (Pickup item in Map.Pickups)
                    item.Destroy();
            }
            if(Plugin.Instance.Config.EPRoundLock)
            {
                Round.IsLocked = true;
            }
            if(Plugin.Instance.Config.EPRespawnTickets)
            {
                Respawn.NtfTickets = 1;
                Respawn.ChaosTickets = 1;
            }
            if(Plugin.Instance.Config.EPForceClassEveryone)
            { 
                foreach (Player player in Player.List)
                {
                    player.SetRole(RoleType.Tutorial);
                    player.SetRole(RoleType.ClassD);
                }
            }
            if(Plugin.Instance.Config.EPFCToTutorial)
            {
                Player.Get(sender).SetRole(RoleType.Tutorial);
            }
            if(Plugin.Instance.Config.EPLockAllDoors)
            {
                Door.LockAll(9999, DoorLockType.AdminCommand);
            }
            if(Plugin.Instance.Config.EPEnableNoclip)
            {
                Player.Get(sender).NoClipEnabled = true;
            }
            response = "May the event preparation begin!";
            return true;
        }
    }
}
