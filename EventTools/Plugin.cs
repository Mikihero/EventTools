using Exiled.API.Features;
using System;
using Exiled.Permissions.Extensions;
using MEC;
using System.Collections.Generic;
using System.Linq;
using player = Exiled.Events.Handlers.Player;
using server = Exiled.Events.Handlers.Server;
// ReSharper disable IteratorNeverReturns

namespace EventTools
{
    public class Plugin : Plugin<Config>
    {
        public override string Author => "Miki_hero";
        public override Version Version => new Version(4, 0, 0, 0);
        public override Version RequiredExiledVersion => new Version(8,3,9,0);

        public static Plugin Instance;
        private EventHandlers _eventHandlers;
        
        public override void OnEnabled()
        {
            Instance = this;
            
            Timing.RunCoroutine(RoundLockToggle(), "rl toggle");
            Timing.RunCoroutine(RoundLockReminder(), "RoundLockReminder");
            
            RegisterEvents();
            
            base.OnEnabled();
        }
        
        public override void OnDisabled()
        {
            Timing.KillCoroutines("rl toggle");
            Timing.KillCoroutines("RoundLockReminder");
            
            UnRegisterEvents();
            
            Instance = null;
            
            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            _eventHandlers = new EventHandlers();
            
            player.Left += _eventHandlers.OnLeft;
            server.RoundStarted += _eventHandlers.OnRoundStart;
            server.RespawningTeam += _eventHandlers.OnRespawningTeam;
        }

        private void UnRegisterEvents()
        {
            player.Left -= _eventHandlers.OnLeft;
            server.RoundStarted -= _eventHandlers.OnRoundStart;
            server.RespawningTeam -= _eventHandlers.OnRespawningTeam;
            
            _eventHandlers = null;
        }
        
        private IEnumerator<float> RoundLockToggle()
        {
            bool wasLocked = false;
            string lockedMessage = Instance.Config.RLEnabledMessage;
            string unLockedMessage = Instance.Config.RLDisabledMessage;
            while(true)
            {
                if (Round.IsLocked)
                {
                    if (!wasLocked) //check if the round was already locked, if not send the broadcast
                    {
                        foreach (Player pl in Player.List.Where(pl => pl.CheckPermission("et.roundlockinfo")))
                        {
                            pl.Broadcast(3, lockedMessage, Broadcast.BroadcastFlags.AdminChat);
                        }
                    }

                    wasLocked = true;
                }
                else
                {
                    if (wasLocked) //check if the round was locked, if it was send the broadcast
                    {
                        foreach (Player pl in Player.List.Where(pl => pl.CheckPermission("et.roundlockinfo")))
                        {
                            pl.Broadcast(3, unLockedMessage, Broadcast.BroadcastFlags.AdminChat);
                        }
                    }
                    
                    wasLocked = false;
                }

                yield return Timing.WaitForSeconds(1f);
            }   
        }

        private IEnumerator<float> RoundLockReminder()
        {
            string message = Instance.Config.RLStillEnabled;
            int timeLocked = 0;
            while (true)
            {
                yield return Timing.WaitForSeconds(1f);
                
                if (Round.IsLocked)
                {
                    if (timeLocked >= Config.RLReminderTime)
                    {
                        foreach (Player player in Player.List.Where(pl => pl.CheckPermission("et.roundlockinfo")))
                        {
                            player.Broadcast(5, message, Broadcast.BroadcastFlags.AdminChat);
                        }

                        timeLocked = 0;
                    }

                    timeLocked++;
                }
                else
                    timeLocked = 0;
            }
        }
    }
}