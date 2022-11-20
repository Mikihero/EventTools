using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CommandSystem;
using Exiled.API.Features;

namespace EventTools.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class EventNow : ICommand, IUsageProvider
    {
        public string Command => "EventNow";

        public string[] Aliases { get; set; } = { "enow" };

        public string Description => "Sends an announcement about an event happening this round.";

        public string[] Usage { get; set; } = { "event name" };

        private static readonly HttpClient client = new HttpClient();

        public static async Task ActuallySendWebhook(StringContent data)
        {
            HttpResponseMessage responseMessage = await client.PostAsync(Plugin.Instance.Config.ENowDiscordWebhookURL, data);
            string responseMessageString = await responseMessage.Content.ReadAsStringAsync();
            if (!responseMessage.IsSuccessStatusCode)
            {
                Log.Error($"[{(int)responseMessage.StatusCode} - {responseMessage.StatusCode}] A non-successful status code was returned by Discord when trying to post to webhook. Response Message: {responseMessageString} .");
            }
        }

        public void SendWebHook(string webhookContent)
        {
            var SuccessWebHook = new
            {
                username = Plugin.Instance.Config.ENowWebhookName,
                content = webhookContent,
                avatar_url = Plugin.Instance.Config.ENowWebhookAvatarURL
            };
            StringContent content = new StringContent(Encoding.UTF8.GetString(Utf8Json.JsonSerializer.Serialize<object>(SuccessWebHook)), Encoding.UTF8, "application/json");
            _ = ActuallySendWebhook(content);
        }

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if(arguments.Count == 0)
            {
                response = "Invalid usage.";
                return false;
            }
            else
            {
                string eventname = string.Join(" ", arguments);
                string broadcastMessage = Plugin.Instance.Config.ENowBC.Replace("{EVENTNAME}", eventname);
                Map.Broadcast(10, broadcastMessage);
                if (Plugin.Instance.Config.ENowSendToDiscord)
                {
                    if (Plugin.Instance.Config.ENowDiscordRoleID == "" || Plugin.Instance.Config.ENowDiscordRoleID == null)
                    {
                        SendWebHook(Plugin.Instance.Config.ENowDiscordMessage.Replace("{EVENTNAME}", eventname));
                    }
                    else
                    {
                        string message = $"<@&{Plugin.Instance.Config.ENowDiscordRoleID}> {Plugin.Instance.Config.ENowDiscordMessage.Replace("{EVENTNAME}", eventname)}";
                        SendWebHook(message);
                    }
                }
                response = "Successfuly informed people about the event!";
                return true;
            }
        }
    }
}
