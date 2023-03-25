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
    public class EventNow : ICommand, IUsageProvider
    {
        public string Command => "EventNow";

        public string[] Aliases { get; set; } = { "enow" };

        public string Description => "Sends an announcement about an event happening this round.";

        public string[] Usage { get; set; } = { "event name" };

        private static readonly HttpClient Client = new HttpClient();

        private static async Task ActuallySendWebhook(StringContent data)
        {
            HttpResponseMessage responseMessage = await Client.PostAsync(Plugin.Instance.Config.ENowDiscordWebhookURL, data);
            string responseMessageString = await responseMessage.Content.ReadAsStringAsync();
            if (!responseMessage.IsSuccessStatusCode)
            {
                Log.Error($"[{(int)responseMessage.StatusCode} - {responseMessage.StatusCode}] A non-successful status code was returned by Discord when trying to post to webhook. Response Message: {responseMessageString} .");
            }
        }

        private void SendWebHook(string webhookContent)
        {
            var successWebHook = new
            {
                username = Plugin.Instance.Config.ENowWebhookName,
                content = webhookContent,
                avatar_url = Plugin.Instance.Config.ENowWebhookAvatarURL
            };
            if (successWebHook == null) throw new ArgumentNullException(nameof(successWebHook));
            StringContent content = new StringContent(Encoding.UTF8.GetString(Utf8Json.JsonSerializer.Serialize<object>(successWebHook)), Encoding.UTF8, "application/json");
            _ = ActuallySendWebhook(content);
        }

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Player.Get(sender).CheckPermission("et.enow"))
            {
                response = "You don't have permission to use this command.";
                return false;
            }
            if (arguments.Count == 0)
            {
                response = "Invalid usage.";
                return false;
            }
            else
            {
                string evenTame = string.Join($"{arguments} ~ {Plugin.Instance.Config.ServerName}");
                string broadcastMessage = Plugin.Instance.Config.ENowBC.Replace("{EVENTNAME}", eventName);
                Map.Broadcast(10, broadcastMessage);
                if (Plugin.Instance.Config.ENowSendToDiscord)
                {
                    if (string.IsNullOrEmpty(Plugin.Instance.Config.ENowDiscordRoleID))
                    {
                        SendWebHook(Plugin.Instance.Config.ENowDiscordMessage.Replace("{EVENTNAME}", eventName));
                    }
                    else
                    {
                        string message = $"<@&{Plugin.Instance.Config.ENowDiscordRoleID}> {Plugin.Instance.Config.ENowDiscordMessage.Replace("{EVENTNAME}", eventName)}";
                        SendWebHook(message);
                    }
                }
                response = "Successfully informed people about the event!";
                return true;
            }
        }
    }
}
