using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using System.Timers;
using Exiled.Permissions.Extensions;

namespace EventTools
{
    public class Plugin : Plugin<Config>
    {
        private static Timer aTimer;
        private static Timer aTimer2;

        public static Plugin Instance;
        public override Version RequiredExiledVersion => new Version(5, 2, 1);

        public static int tester1 = 2;
        public static int tester2 = 2;

        public override void OnEnabled()
        {
            Instance = this;
            SetTimer();
            SetTimer2();
            base.OnEnabled();
        }

        public static void RoundLockAdminChat(Object sender, ElapsedEventArgs e)
        {
            if (Round.IsLocked == true)
            {
                string message = Instance.Config.RLEnabledMessage;
                tester1 = 1;
                if (tester2 == 2)
                {
                    tester2 = tester1;
                    foreach (Player player in Player.List)
                    {
                        if (Permissions.CheckPermission(player, "et.roundlockinfo") == true)
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
                        if (Permissions.CheckPermission(player, "et.roundlockinfo") == true)
                        {
                            player.Broadcast(5, message, Broadcast.BroadcastFlags.AdminChat);
                        }
                    }
                    tester2 = tester1;
                }
            }
            else
            {
                string message = Instance.Config.RLDisabledMessage;
                tester1 = 0;
                if (tester2 == 2)
                {
                    tester2 = tester1;
                    foreach (Player player in Player.List)
                    {
                        if (Permissions.CheckPermission(player, "et.roundlockinfo") == true)
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
                        if (Permissions.CheckPermission(player, "et.roundlockinfo") == true)
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
            string message = Instance.Config.RLStillEnabled;
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
            int time = Instance.Config.RLReminderTime;
            aTimer2 = new Timer(time);
            aTimer2.Elapsed += RoundLockAdminChatReminder;
            aTimer2.AutoReset = true;
            aTimer2.Enabled = true;
        }
    }
}
