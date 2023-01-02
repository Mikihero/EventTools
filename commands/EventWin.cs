using System;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using PlayerRoles;

namespace EventTools.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class EventWin : ICommand, IUsageProvider
    {
        public string Command => "eventwin";

        public string[] Aliases => new[] { "ew" };

        public string Description => "Forceclasses you and a chosen player to tutorial.";

        public string[] Usage { get; set; } = { "Player ID or Name"};

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Player.Get(sender).CheckPermission("et.ewin"))
            {
                response = "You don't have permission to use this command.";
                return false;
            }
            if (arguments.Count < 1)
            {
                response = "Incorrect usage.";
                return false;
            }

            Player target = Player.Get(arguments.At(0));
            if (target == null)
            {
                response = $"Player not found: {arguments.At(0)}";
                return false;
            }

            if (Plugin.Instance.Config.EWFCEveryoneToSpectator)
            {
                foreach (Player pl in Player.List) pl.Role.Set(RoleTypeId.Spectator);
            }
            Player.Get(sender).Role.Set(RoleTypeId.ClassD);
            target.Role.Set(RoleTypeId.ClassD);
            Player.Get(sender).Role.Set(RoleTypeId.Tutorial);
            target.Role.Set(RoleTypeId.Tutorial);
            response = "Success!";
            return true;
        }
    }
}
