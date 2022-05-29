using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandSystem;
using Exiled.API.Features;

namespace EventTools.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class EventWin : ICommand
    {
        public string Command => "eventwin";

        public string[] Aliases => new string[] { "ew" };

        public string Description => "Forceclasses you and a chosen player to tutorial.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (arguments.Count < 1)
            {
                response = "Usage: eventwin player id/player name";
                return false;
            }
            else
            {
                Player target = Player.Get(arguments.At(0));
                if (target == null)
                {
                    response = $"Player not found: {arguments.At(0)}";
                    return false;
                }
                else
                {
                    if (Plugin.Instance.Config.EWForceClassEveryoneToSpectator)
                    {
                        foreach (Player pl in Player.List) pl.SetRole(RoleType.Spectator);
                    }
                    Player.Get(sender).SetRole(RoleType.Tutorial);
                    target.SetRole(RoleType.Tutorial);
                    response = "Success!";
                    return true;
                }
            }
        }
    }
}
