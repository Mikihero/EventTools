using Exiled.API.Interfaces;
using System.ComponentModel;

namespace EventTools
{
    public sealed class Config : IConfig
    {
        [Description("Enables or disables the plugin.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Whether or not debug messages should be shown in the console.")]
        public bool Debug { get; set; } = false;

        [Description("The message sent when someone enables the RoundLock, can be formatted like a normal SL broadcast.")]
        public string RLEnabledMessage { get; set; } = "[<color=#002db3>Event</color><color=#98fb98>Tools</color>] <color=#50c878>RoundLock</color><color=#ffffff> has been </color><color=#00ffff>enabled.</color>";

        [Description("The message sent when someone disables the RoundLock, can be formatted like a normal SL broadcast.")]
        public string RLDisabledMessage { get; set; } = "[<color=#002db3>Event</color><color=#98fb98>Tools</color>] <color=#50c878>RoundLock</color><color=#ffffff> has been </color><color=#c50000>disabled.</color>";

        [Description("The message sent in AdminChat as a reminder that roundlock is still enabled, can be formatted like a normal SL broadcast.")]
        public string RLStillEnabled { get; set; } = "[<color=#002db3>Event</color><color=#98fb98>Tools</color>] <color=#ffffff> A quick reminder that </color><color=#50c878>RoundLock</color><color=#ffffff> is still </color><color=#00ffff>enabled.</color>";

        [Description("The amount of seconds every which the plugin should check if round lock is enabled and send a broadcast accordingly. Default: 300")]
        public float RLReminderTime { get; set; } = 300;

        [Description("Whether or not the EventPrep command should cleanup ragdolls. Default: true")]
        public bool EPCleanupRagdolls { get; set; } = true;

        [Description("Whether or not the EventPrep command should cleanup items. Default: true")]
        public bool EPCleanupItems { get; set; } = true;

        [Description("Whether or not the EventPrep command should enable roundlock. Default: true")]
        public bool EPRoundLock { get; set; } = true;

        [Description("Whether or not the EventPrep command should set MTF and CI tickets to 1 (1 not 0 because at 0 tickets SL will still spawn ~5 people). Default: true")]
        public bool EPRespawnTickets { get; set; } = true;

        [Description("Whether or not the person executing the EventPrep command should be forceclassed to tutorial. Default: true")]
        public bool EPFCToTutorial { get; set; } = true;

        [Description("Whether or not the person executing the EventPrep command should be teleported to the old Tutorial Tower")]
        public bool EPTpToTower { get; set; } = true;

        [Description("Whether or not the EventPrep command should lock all doors in the facility. Default: true")]
        public bool EPLockAllDoors { get; set; } = true;

        [Description("Whether or not the person using the EventPrep command should have their noclip enabled. Default: true")]
        public bool EPEnableNoclip { get; set; } = true;

        [Description("Whether or not everyone except the person executing the EventPrep command should be forceclassed to Class D. Default: true")]
        public bool EPForceClassEveryone { get; set; } = true;

        [Description("The message sent using CASSIE with the EventCountdown command.")]
        public string ECCassieMessage { get; set; } = "10 9 8 7 6 5 4 3 2 1 start";

        [Description("Whether or not the CASSIE message for the EventCountdown command should have subtitles. Default: true")]
        public bool ECSubtitles { get; set; } = true;

        [Description("The message to be broadcasted when using the EventNext command, can be formatted like a normal SL broadcast. {EVENTNAME} will be replaced with the name of the event.")]
        public string ENextBC { get; set; } = "<size=40><b><color=#cc9900>In the next round there will be an event:\n</color></b></size><size=50><b><color=#ff0000>{EVENTNAME}</color></b></size>";

        [Description("Whether or not the EventNext command should send a message to discord, if set to true the ENextDiscordWebhookURL value has to be correctly specified. Default: false.")]
        public bool ENextSendToDiscord { get; set; } = false;

        [Description("The message to be sent via a discord webhook when using the EventNext command. Can be formatted like a normal discord message.")]
        public string ENextDiscordMessage { get; set; } = "In the next round there will be an event: `{EVENTNAME}`";

        [Description("Discord ID of the role that should be pinged when using the EventNext command. Leave empty to not ping any role.")]
        public string ENextDiscordRoleID { get; set; } = "";

        [Description("Name of the Webhook used in the EventNext command that's displayed on discord.")]
        public string ENextWebhookName { get; set; } = "EventNotifier";

        [Description("The Discord Webhook URL via which the EventNext command will send messages.")]
        public string ENextDiscordWebhookURL { get; set; } = "";

        [Description("The avatar Discord Webhook's avatar URL for the EventNext command.")]
        public string ENextWebhookAvatarURL { get; set; } = "https://media.giphy.com/media/jzKb8n8n2GC6s0cUB1/giphy.gif";

        [Description("The messsage to be broadcasted when using the EventNow command, can be formatted like a normal SL broadcast. {EVENTNAME} will be replaced with the name of the event.")]
        public string ENowBC { get; set; } = "<size=40><b><color=#cc9900>Event:\n</color></b></size> <size=50><b><color=#ff0000>{EVENTNAME}</color></b></size>";

        [Description("Whether or not the EventNow command should send a message to discord, if set to true the  value has to be correctly specified. Default: false.")]
        public bool ENowSendToDiscord { get; set; } = false;

        [Description("The message to be sent via a discord webhook when using the EventNow command. Can be formatted like a normal discord message.")]
        public string ENowDiscordMessage { get; set; } = "An event is happening this round: `{EVENTNAME}`";

        [Description("Discord ID of the role that should be pinged when using the EventNow command. Leave empty to not ping any role.")]
        public string ENowDiscordRoleID { get; set; } = "";

        [Description("Name of the Webhook used in the EventNow command that's displayed on discord.")]
        public string ENowWebhookName { get; set; } = "EventNotifier";

        [Description("The Discord Webhook URL via which the EventNow command will send messages.")]
        public string ENowDiscordWebhookURL { get; set; } = "";

        [Description("The avatar Discord Webhook's avatar URL for the EventNow command.")]
        public string ENowWebhookAvatarURL { get; set; } = "https://media.giphy.com/media/jzKb8n8n2GC6s0cUB1/giphy.gif";

        [Description("The broadcast to be sent whenever the lottery command is used. [NUMBER] will be replaced with the chosen number.")]
        public string LotteryBroadcast { get; set; } = "<color=#b00b69><b><size=60>[NUMBER]</size></b></color>";

        [Description("Whether or not the EventWin command should forceclass everyone except you and your target to spectator. Default: false")]
        public bool EWFCEveryoneToSpectator { get; set; } = false;

        [Description("Whether or not the FactionWars command should disable friendly fire. Default: true.")]
        public bool FWDisaableFF { get; set; } = true;
    }
}