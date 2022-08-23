﻿using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using System.Timers;
using Exiled.Permissions.Extensions;
using MEC;
using System.Collections.Generic;

namespace EventTools
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance;
        public override Version RequiredExiledVersion => new Version(5, 2, 1);
        public override Version Version => new Version(1, 4, 3);
        public override string Author => "Miki_hero";

        public static int test = 0;


        public override void OnEnabled()
        {
            Instance = this;
            Timing.RunCoroutine(RoundLockAdminChat());
            Timing.RunCoroutine(RoundLockReminder());
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Timing.KillCoroutines();
            base.OnDisabled();
        }

        public IEnumerator<float> RoundLockAdminChat()
        {
            while(true)
            {
                if (Round.IsLocked)
                {
                    string message = Instance.Config.RLEnabledMessage;
                    if (test == 0)
                    {
                        foreach (Player pl in Player.List)
                        {
                            if (Permissions.CheckPermission(pl, "et.roundlockinfo"))
                            {
                                pl.Broadcast(5, message, Broadcast.BroadcastFlags.AdminChat);
                            }
                        }
                    }
                    test = 1;
                }
                else
                {
                    string message = Instance.Config.RLDisabledMessage;
                    if (test == 1)
                    {
                        foreach (Player pl in Player.List)
                        {
                            if (Permissions.CheckPermission(pl, "et.roundlockinfo"))
                            {
                                pl.Broadcast(5, message, Broadcast.BroadcastFlags.AdminChat);
                            }
                        }
                    }
                    test = 0;
                }
                yield return Timing.WaitForSeconds(1f);
            }
        }

        public IEnumerator<float> RoundLockReminder()
        {
            while(true)
            {
                string message = Instance.Config.RLStillEnabled;
                if (Round.IsLocked)
                {
                    foreach (Player player in Player.List)
                    {
                        if (Permissions.CheckPermission(player, "AdminChat"))
                        {
                            player.Broadcast(5, message, Broadcast.BroadcastFlags.AdminChat);
                        }
                    }
                }
                yield return Timing.WaitForSeconds(300f);
            }
        }
    }
}