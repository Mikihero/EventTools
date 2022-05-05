using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Interfaces;
using System.ComponentModel;

namespace EventTools
{
    public sealed class Config : IConfig
    {
        [Description("Enables or disables the plugin.")]
        public bool IsEnabled { get; set; } = true;

        [Description("The message sent when someone enables the RoundLock, can be colored ONLY using hex codes displayed in game client console under the 'colors' command.")]
        public string RLEnabledMessage { get; set; } = "[<color=#002db3>Event</color><color=#98fb98>Tools</color>] <color=#50c878>RoundLock</color><color=#ffffff> has been </color><color=#00ffff>enabled.</color>";

        [Description("The message sent when someone disables the RoundLock, can be colored ONLY using hex codes displayed in game client console under the 'colors' command..")]
        public string RLDisabledMessage { get; set; } = "[<color=#002db3>Event</color><color=#98fb98>Tools</color>] <color=#50c878>RoundLock</color><color=#ffffff> has been </color><color=#c50000>disabled.</color>";

        [Description("Sets the response message sent in RemoteAdmin after executing the 'EventStart' command.")]
        public string EventStartResponseMessage { get; set; } = "The event has been succesfully started.";

        [Description("Whether or not the EventStart command should cleanup ragdolls. Default: true")]
        public bool CleanupRagdolls { get; set; } = true;

        [Description("Whether or not the EventStart command should cleanup items. Default: true")]
        public bool CleanupItems { get; set; } = true;

        [Description("Whether or not the EventStart command should enable roundlock.")]
        public bool RoundLock { get; set; } = true;

        [Description("Whether or not the EventStart command should set MTF and CI tickets to 1.")]
        public bool RespawnTickets { get; set; } = true;

        [Description("The message sent using CASSIE with the EventCountdown command.")]
        public string CassieMessage = "10 . 9 . 8 . 7 . 6 . 5 . 4 . 3 . 2 . 1 start";

        [Description("Sets the response message given in RemoteAdmin after executing the 'EventCountdown' command.")]
        public string CassieResponseMessage { get; set; } = "The countdown has begun.";

        [Description("Whether or not the person executing the command should be forceclassed to tutorial.")]
        public bool FCToTutorial { get; set; } = true;

        [Description("Whether or not all doors in the facility should be locked. Currently will ONLY send a reminder in AC due to EXILED being broken doo doo.")]
        public bool LockAllDoors { get; set; } = true;

        [Description("Whether or not the person sending the command should have their noclip enabled.")]
        public bool EnableNoclip { get; set; } = true;

        [Description("Whether or not everyone except for the person executing the command should be forceclassed Class D.")]
        public bool ForceClassEveryone { get; set; } = true;

        [Description("Sets the response message given in RemoteAdmin after executing the 'EventEnd' command.")]
        public string EventEndResponseMessage { get; set; } = "Everyone is sad because the event is over (and also they exploded!).";
    }
}
