using System;
using CommandSystem;
using Exiled.Permissions.Extensions;
using PlayerRoles;
using UnityEngine;
using Player = Exiled.API.Features.Player;

namespace EventTools.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class Tower : ICommand, IUsageProvider
    {
        public string Command => "tower";
        public string[] Aliases { get; set; }
        public string Description => "Teleports you to the tutorial tower.";
        public string[] Usage => new[] { "forceclass? = true" };

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player pl = Player.Get(sender);
            if (!pl.CheckPermission("et.tower"))
            {
                response = "Insufficient permissions.";
                return false;
            }

            switch (arguments.Count)
            {
                case 0:
                    pl.Role.Set(RoleTypeId.Tutorial);
                    pl.Teleport(new Vector3(38, 1014, -31));
                    response = "Successfully execeuted the command.";
                    return true;
                case 1:
                    if (!bool.TryParse(arguments.At(0), out bool result))
                    {
                        response = "Incorrect usage.";
                        return false;
                    }
                    if(!result)
                    {
                        pl.Teleport(new Vector3(38, 1014, -31));
                    }
                    
                    else
                    {
                        pl.Role.Set(RoleTypeId.Tutorial);
                        pl.Teleport(new Vector3(38, 1014, -31));
                    }
                    response = "Successfully execeuted the command.";
                    return true;
                default:
                    response = "Incorrect usage.";
                    return false;
            }
        }

    }
}