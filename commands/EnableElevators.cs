using System;
using CommandSystem;

namespace EventTools.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class EnableElevators : ICommand
    {
        public string Command => "EnableElevators";

        public string[] Aliases => new string[] { };

        public string Description => "Enables the elevators disabled by other EventTools commands.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            FactionWars.IsEventActive = false;
            response = "Re-enabled the elevators!";
            return true;   
        }
    }
}
