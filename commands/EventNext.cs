using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;

namespace EventTools.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class EventNext : ICommand, IUsageProvider
    {
        public string Command => "EventNext";

        public string[] Aliases { get; set; } = { "enext" };

        public string Description => "Informs people about an event happening next round.";

        public string[] Usage { get; set; } = { "event name" };

        private static readonly HttpClient client = new HttpClient();

        public static async Task ActuallySendWebhook(StringContent data)
        {
            HttpResponseMessage responseMessage = await client.PostAsync(Plugin.Instance.Config.ENextDiscordWebhookURL, data);
            string responseMessageString = await responseMessage.Content.ReadAsStringAsync();
            if(!responseMessage.IsSuccessStatusCode)
            {
                Log.Error($"[{(int)responseMessage.StatusCode} - {responseMessage.StatusCode}] A non-successful status code was returned by Discord when trying to post to webhook. Response Message: {responseMessageString} .");
            }
        }

        public void SendWebHook(string webhookContent)
        {
            var SuccessWebHook = new
            {
                username = Plugin.Instance.Config.ENextWebhookName,
                content = webhookContent,
                avatar_url = Plugin.Instance.Config.ENextWebhookAvatarURL
            };
            StringContent content = new StringContent(Encoding.UTF8.GetString(Utf8Json.JsonSerializer.Serialize<object>(SuccessWebHook)), Encoding.UTF8, "application/json");
            _ = ActuallySendWebhook(content);
        }

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Permissions.CheckPermission(Player.Get(sender), "et.enext"))
            {
                response = "You don't have permission to use this command.";
                return false;
            }
            if (arguments.Count == 0)
            {
                response = "Incorrect usage.";
                return false;
            }
            else
            {
                string eventname = string.Join(" ", arguments);
                string broadcastMessage = Plugin.Instance.Config.ENextBC.Replace("{EVENTNAME}", eventname);
                Map.Broadcast(10, broadcastMessage);
                if(Plugin.Instance.Config.ENextSendToDiscord)
                {
                    if(Plugin.Instance.Config.ENextDiscordRoleID == "" || Plugin.Instance.Config.ENextDiscordRoleID == null)
                    {
                        SendWebHook(Plugin.Instance.Config.ENextDiscordMessage.Replace("{EVENTNAME}", eventname));
                    }
                    else
                    {
                        string message = $"<@&{Plugin.Instance.Config.ENextDiscordRoleID}> {Plugin.Instance.Config.ENextDiscordMessage.Replace("{EVENTNAME}", eventname)}";
                        SendWebHook(message);
                    }
                }
                response = "Successfuly informed people about the event!";
                return true;
            }
        }
    }
}