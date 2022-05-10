using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using System.Timers;
using Exiled.Permissions.Extensions;

namespace EventTools
{
    public class EventTools : Plugin<Config>
    {
        private static Timer aTimer;
        private static Timer aTimer2;

        private static readonly Lazy<EventTools> LazyInstance = new Lazy<EventTools>(() => new EventTools());
        public static EventTools Instance => LazyInstance.Value;

        public override PluginPriority Priority { get; } = PluginPriority.Medium;


        private EventTools()
        {

        }

        public static int tester1 = 2;
        public static int tester2 = 2;
        public static void RoundLockAdminChat(Object sender, ElapsedEventArgs e)
        {
            if (Round.IsLocked == true)
            {
                string message = EventTools.Instance.Config.RLEnabledMessage;
                tester1 = 1;
                if (tester2 == 2)
                {
                    tester2 = tester1;
                    foreach (Player player in Player.List)
                    {
                        if (Permissions.CheckPermission(player, "AdminChat") == true)
                        {
                            player.Broadcast(5, message, Broadcast.BroadcastFlags.AdminChat);
                        }
                    }
                }
                if (tester2 == tester1)
                {

                }
                else
                {
                    foreach (Player player in Player.List)
                    {
                        if (Permissions.CheckPermission(player, "AdminChat") == true)
                        {
                            player.Broadcast(5, message, Broadcast.BroadcastFlags.AdminChat);
                        }
                    }
                    tester2 = tester1;
                }
            }
            else
            {
                string message = EventTools.Instance.Config.RLDisabledMessage;
                tester1 = 0;
                if (tester2 == 2)
                {
                    tester2 = tester1;
                    foreach (Player player in Player.List)
                    {
                        if (Permissions.CheckPermission(player, "AdminChat") == true)
                        {
                            player.Broadcast(5, message, Broadcast.BroadcastFlags.AdminChat);
                        }
                    }
                }
                if (tester2 == tester1)
                {

                }
                else
                {
                    foreach (Player player in Player.List)
                    {
                        if (Permissions.CheckPermission(player, "AdminChat") == true)
                        {
                            player.Broadcast(5, message, Broadcast.BroadcastFlags.AdminChat);
                        }
                    }
                    tester2 = tester1;
                }
            }
        }

        public static void RoundLockAdminChatReminder(Object sender, ElapsedEventArgs e)
        {
            string message = EventTools.Instance.Config.RLStillEnabled;
            if (Round.IsLocked == true)
            {
                foreach (Player player in Player.List)
                {
                    if (Permissions.CheckPermission(player, "AdminChat") == true)
                    {
                        player.Broadcast(5, message, Broadcast.BroadcastFlags.AdminChat);
                    }
                }
            }
        }

        private static void SetTimer()
        {
            aTimer = new Timer(1000);
            aTimer.Elapsed += RoundLockAdminChat;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void SetTimer2()
        {
            int time = EventTools.Instance.Config.RLReminderTime;
            aTimer2 = new Timer(time);
            aTimer2.Elapsed += RoundLockAdminChatReminder;
            aTimer2.AutoReset = true;
            aTimer2.Enabled = true;
        }

        public override void OnEnabled()
        {
            SetTimer();
            SetTimer2();
        }
    }
}
