using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using System.Timers;

namespace EventTools
{
    public class EventTools : Plugin<Config>
    {
        private static System.Timers.Timer aTimer;

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
                    Map.Broadcast(2, message, Broadcast.BroadcastFlags.AdminChat);
                }
                if (tester2 == tester1)
                {

                }
                else
                {
                    Map.Broadcast(2, message, Broadcast.BroadcastFlags.AdminChat);
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
                    Map.Broadcast(2, message, Broadcast.BroadcastFlags.AdminChat);
                }
                if (tester2 == tester1)
                {

                }
                else
                {
                    Map.Broadcast(2, message, Broadcast.BroadcastFlags.AdminChat);
                    tester2 = tester1;
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

        public override void OnEnabled()
        {
            SetTimer();
        }
    }
}
