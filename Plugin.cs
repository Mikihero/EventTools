﻿using Exiled.API.Features;
using System;
using Exiled.Permissions.Extensions;
using MEC;
using System.Collections.Generic;
using player = Exiled.Events.Handlers.Player;
using server = Exiled.Events.Handlers.Server;

namespace EventTools
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance;
        public override Version RequiredExiledVersion => new Version(5, 3, 0);
        public override Version Version => new Version(2, 1, 2, 0);
        public override string Author => "Miki_hero";

        private static int _test;
        private EventHandlers _eventHandler;

        public override void OnEnabled()
        {
            Instance = this;
            Timing.RunCoroutine(RoundLockToggle());
            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Timing.KillCoroutines();
            UnRegisterEvents();
            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            _eventHandler = new EventHandlers();
            player.Left += _eventHandler.OnLeft;
            server.RoundStarted += _eventHandler.OnRoundStart;
            player.InteractingElevator += _eventHandler.OnUsingElevator;
        }

        private void UnRegisterEvents()
        {
            player.Left -= _eventHandler.OnLeft;
            player.InteractingElevator -= _eventHandler.OnUsingElevator;
            _eventHandler = null;
        }
        
        private IEnumerator<float> RoundLockToggle()
        {
            while(true)
            {
                if (Round.IsLocked)
                {
                    string message = Instance.Config.RLEnabledMessage;
                    if (_test == 0) //check if the round was already locked, if not send the broadcast
                    {
                        foreach (Player pl in Player.List)
                        {
                            if (pl.CheckPermission("et.roundlockinfo"))
                            {
                                pl.Broadcast(3, message, Broadcast.BroadcastFlags.AdminChat);
                                Timing.RunCoroutine(RoundLockReminder(), "RoundLockReminder");
                            }
                        }
                    }
                    _test = 1;
                }
                else
                {
                    string message = Instance.Config.RLDisabledMessage;
                    if (_test == 1) //check if the round was already locked, if it was send the broadcast
                    {
                        foreach (Player pl in Player.List)
                        {
                            if (pl.CheckPermission("et.roundlockinfo"))
                            {
                                pl.Broadcast(3, message, Broadcast.BroadcastFlags.AdminChat);
                                Timing.KillCoroutines("RoundLockReminder");
                            }
                        }
                    }
                    _test = 0;
                }
                yield return Timing.WaitForSeconds(1f);
            }
            // ReSharper disable once IteratorNeverReturns
        }

        private IEnumerator<float> RoundLockReminder()
        {
            while(true)
            {
                yield return Timing.WaitForSeconds(Instance.Config.RLReminderTime); //if roundlock has been enabled for 300 (configurable) seconds a broadcast is sent
                string message = Instance.Config.RLStillEnabled;
                if (Round.IsLocked)
                {
                    foreach (Player player in Player.List)
                    {
                        if (player.CheckPermission("AdminChat"))
                        {
                            player.Broadcast(5, message, Broadcast.BroadcastFlags.AdminChat);
                        }
                    }
                }
            }
            // ReSharper disable once IteratorNeverReturns
        }
    }
}