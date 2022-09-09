using Exiled.API.Interfaces;
using System.ComponentModel;

namespace EventTools
{
    public sealed class Config : IConfig
    {
        [Description("Enables or disables the plugin.")]
        public bool IsEnabled { get; set; } = true;

        [Description("The message sent when someone enables the RoundLock, can be formatted like a normal SL broadcast.")]
        public string RLEnabledMessage { get; set; } = "[<color=#002db3>Event</color><color=#98fb98>Tools</color>] <color=#50c878>RoundLock</color><color=#ffffff> has been </color><color=#00ffff>enabled.</color>";

        [Description("The message sent when someone disables the RoundLock, can be formatted like a normal SL broadcast.")]
        public string RLDisabledMessage { get; set; } = "[<color=#002db3>Event</color><color=#98fb98>Tools</color>] <color=#50c878>RoundLock</color><color=#ffffff> has been </color><color=#c50000>disabled.</color>";

        [Description("The message sent in AdminChat as a reminder that roundlock is still enabled, can be formatted like a normal SL broadcast.")]
        public string RLStillEnabled { get; set; } = "[<color=#002db3>Event</color><color=#98fb98>Tools</color>] <color=#ffffff> A quick reminder that </color><color=#50c878>RoundLock</color><color=#ffffff> is still </color><color=#00ffff>enabled.</color>";

        [Description("The amount of seconds every which the plugin should check if round lock is enabled and send a broadcast accordingly. Default: 300")]
        public float RLReminderTime { get; set; } = 300;

        [Description("Whether or not the EventStart command should cleanup ragdolls. Default: true")]
        public bool ESCleanupRagdolls { get; set; } = true;

        [Description("Whether or not the EventStart command should cleanup items. Default: true")]
        public bool ESCleanupItems { get; set; } = true;

        [Description("Whether or not the EventStart command should enable roundlock. Default: true")]
        public bool ESRoundLock { get; set; } = true;

        [Description("Whether or not the EventStart command should set MTF and CI tickets to 1 (1 not 0 because at 0 tickets SL will still spawn ~5 people). Default: true")]
        public bool ESRespawnTickets { get; set; } = true;

        [Description("Whether or not the person executing the EventStart command should be forceclassed to tutorial. Default: true")]
        public bool ESFCToTutorial { get; set; } = true;

        [Description("Whether or not the EventStart command should lock all doors in the facility. Default: true")]
        public bool ESLockAllDoors { get; set; } = true;

        [Description("Whether or not the person using the EventStart command should have their noclip enabled. Default: true")]
        public bool ESEnableNoclip { get; set; } = true;

        [Description("Whether or not everyone except for the person executing the EventStart command should be forceclassed Class D. Default: true")]
        public bool ESForceClassEveryone { get; set; } = true;

        [Description("The message sent using CASSIE with the EventCountdown command.")]
        public string ECCassieMessage { get; set; } = "10 9 8 7 6 5 4 3 2 1 start";

        [Description("Whether or not the CASSIE message for the EventCountdown command should have subtitles. Default: true")]
        public bool ECSubtitles { get; set; } = true;

        [Description("The message to be broadcasted when using the EventNext command, can be formatted like a normal SL broadcast. {EVENTNAME} will be replaced with the name of the event.")]
        public string ENextMessage { get; set; } = "<size=40><b><color=#cc9900>In the next round there will be an event:\n</color></b></size><size=50><b><color=#ff0000>{EVENTNAME}</color></b></size>";

        [Description("The messsage to be broadcasted when using the EventNow command, can be formatted like a normal SL broadcast. {EVENTNAME} will be replaced with the name of the event.")]
        public string ENowMessage { get; set; } = "<size=40><b><color=#cc9900>Event:\n</color></b></size> <size=50><b><color=#ff0000>{EVENTNAME}</color></b></size>";

        [Description("The broadcast to be sent whenever the lottery command is used. [NUMBER] will be replaced with the chosen number.")]
        public string LotteryBroadcast { get; set; } = "<color=#b00b69><b><size=60>[NUMBER]</size></b></color>";

        [Description("Whether or not the EventWin command should forceclass everyone except you and your target to spectator. Default: false")]
        public bool EWFCEveryoneToSpectator { get; set; } = false;

        [Description ("Whether or not the FactionWars command should cleanup items. Default: true.")]
        public bool FWCleanupItems { get; set; } = true;
    }
}