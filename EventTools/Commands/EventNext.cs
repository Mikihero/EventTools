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
    public class EventNext : ICommand, IUsageProvider
    {
        public string Command => "EventNext";

        public string[] Aliases { get; } = { "enext" };

        public string Description => "Informs people about an event happening next round.";

        public string[] Usage { get; } = { "event name" };

        private static readonly HttpClient Client = new HttpClient();

        static async Task ActuallySendWebhook(StringContent data)
        {
            HttpResponseMessage responseMessage = await Client.PostAsync(Plugin.Instance.Config.ENextDiscordWebhookURL, data);
            string responseMessageString = await responseMessage.Content.ReadAsStringAsync();
            if(!responseMessage.IsSuccessStatusCode)
            {
                Log.Error($"[{(int)responseMessage.StatusCode} - {responseMessage.StatusCode}] A non-successful status code was returned by Discord when trying to post to webhook. Response Message: {responseMessageString} .");
            }
        }

        private void SendWebHook(string webhookContent)
        {
            var successWebHook = new
            {
                username = Plugin.Instance.Config.ENextWebhookName,
                content = webhookContent,
                avatar_url = Plugin.Instance.Config.ENextWebhookAvatarURL
            };
            StringContent content = new StringContent(Encoding.UTF8.GetString(Utf8Json.JsonSerializer.Serialize<object>(successWebHook)), Encoding.UTF8, "application/json");
            _ = ActuallySendWebhook(content);
        }

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Player.Get(sender).CheckPermission("et.enext"))
            {
                response = "You don't have permission to use this command.";
                return false;
            }
            if (arguments.Count == 0)
            {
                response = "Incorrect usage.";
                return false;
            }

            string eventName = string.Join(" ", arguments);
            string serverName = Plugin.Instance.Config.ServerName;
            string mentionId = Plugin.Instance.Config.ENextDiscordRoleID;
            string broadcastMessage = Plugin.Instance.Config.ENextBC.Replace("{EVENTNAME}", eventName);
            Map.Broadcast(10, broadcastMessage);
            if(Plugin.Instance.Config.ENextSendToDiscord)
            {
                if(string.IsNullOrEmpty(Plugin.Instance.Config.ENextDiscordRoleID))
                {
                    string message = Plugin.Instance.Config.ENextDiscordMessage
                        .Replace("{EVENTNAME}", eventName)
                        .Replace("{SERVERNAME}", serverName);
                    SendWebHook(message);
                }
                else
                {
                    string message = Plugin.Instance.Config.ENextDiscordMessage
                        .Replace("{EVENTNAME}", eventName)
                        .Replace("{SERVERNAME}", serverName)
                        .Replace("{DISCORDMENTION}", $"<@&{mentionId}>");
                    SendWebHook(message);
                }
            }
            response = "Successfully informed people about the event!";
            return true;
        }
    }
}