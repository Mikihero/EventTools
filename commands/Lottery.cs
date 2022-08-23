﻿using System;
using System.Linq;
using CommandSystem;
using Exiled.API.Features;
using Exiled.API.Enums;
using MEC;
using UnityEngine;
using Exiled.API.Features.Items;

namespace EventTools.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class Lottery : ICommand
    {
        public string Command => "lottery";

        public string[] Aliases { get; set; } = { "loteria" };

        public string Description => "Spins the lottery wheel!";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            System.Random Rd = new System.Random();
            int lotteryTicket = Rd.Next(1, 51);
            string message = Plugin.Instance.Config.LotteryBC.Replace("[NUMBER]", lotteryTicket.ToString());
            switch (lotteryTicket)
            {
                case 1:
                case 2:
                case 3:
                    Map.Broadcast(2, message);
                    if (!Warhead.IsDetonated)
                    {
                        if (Warhead.IsInProgress) Warhead.Stop();
                        else Warhead.Start();
                    }
                    else Warhead.Start();
                    break;
                case 4:
                case 5:
                    Map.Broadcast(2, message);
                    foreach (Player pl in Player.List)
                    {
                        int HealToGive = Rd.Next(1, 6);
                        switch (HealToGive)
                        {
                            case 1: Item.Create(ItemType.Painkillers).Spawn(pl.Position + Vector3.up); break;
                            case 2: Item.Create(ItemType.Painkillers).Spawn(pl.Position + Vector3.up); break;
                            case 3: Item.Create(ItemType.Medkit).Spawn(pl.Position + Vector3.up); break;
                            case 4: Item.Create(ItemType.Adrenaline).Spawn(pl.Position + Vector3.up); break;
                            case 5: Item.Create(ItemType.SCP500).Spawn(pl.Position + Vector3.up); break;
                        }
                    }
                    break;
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    Map.Broadcast(2, message);
                    Map.TurnOffAllLights(20);
                    break;
                case 11:
                case 12:
                case 13:
                case 14:
                    Map.Broadcast(2, message);
                    Player.List.ToList().RandomItem().ApplyRandomEffect(3);
                    break;
                case 15:
                case 16:
                    Map.Broadcast(2, message);
                    Item.Create(ItemType.KeycardContainmentEngineer).Spawn(Room.List.ToList().RandomItem().Position + Vector3.up);
                    break;
                case 17:
                case 18:
                case 19:
                case 20:
                    Map.Broadcast(2, message);
                    //nothing for now
                    break;
                case 21:
                case 22:
                case 23:
                case 24:
                    Map.Broadcast(2, message);
                    Respawn.ForceWave(Respawning.SpawnableTeamType.ChaosInsurgency);
                    break;
                case 25:
                case 26:
                    Map.Broadcast(2, message);
                    //nothing for now
                    break;
                case 27:
                case 28:
                case 29:
                case 30:
                    Map.Broadcast(2, message);
                    Respawn.ForceWave(Respawning.SpawnableTeamType.NineTailedFox);
                    break;
                case 31:
                case 32:
                case 33:
                case 34:
                    Map.Broadcast(2, message);
                    if (!Map.IsLczDecontaminated) Player.List.ToList().RandomItem().Teleport(Door.Get(DoorType.PrisonDoor));
                    else Player.List.ToList().RandomItem().Teleport(Door.Get(DoorType.NukeArmory));
                    break;
                case 35:
                case 36:
                    Map.Broadcast(2, message);
                    Door.List.ToList().RandomItem().Lock(10, DoorLockType.Isolation);
                    break;
                case 37:
                case 38:
                case 39:
                case 40:
                    Map.Broadcast(2, message);
                    int RandomGate = Rd.Next(1, 3);
                    if (RandomGate == 1) Player.List.ToList().RandomItem().Teleport(Door.Get(DoorType.GateA));
                    else Player.List.ToList().RandomItem().Teleport(Door.Get(DoorType.GateB));
                    break;
                case 41:
                case 42:
                case 43:
                case 44:
                    Map.Broadcast(2, message);
                    Door.LockAll(10, DoorLockType.AdminCommand);
                    Timing.CallDelayed(20f, () =>
                    {
                        Door.LockAll(10, DoorLockType.AdminCommand);
                        Timing.CallDelayed(20f, () =>
                        {
                            Door.LockAll(10, DoorLockType.AdminCommand);
                        });
                    });
                    break;
                case 45:
                case 46:
                    Map.Broadcast(2, message);
                    foreach (Player pl in Player.List)
                    {
                        Room randRoom = Room.List.ElementAt(Rd.Next(0, Room.List.Count()));
                        pl.Position = randRoom.Position + Vector3.up;
                    }
                    break;
                case 47:
                case 48:
                case 49:
                case 50:
                    Map.Broadcast(2, message);
                    int RandomCassie = Rd.Next(1, 5);
                    switch (RandomCassie)
                    {
                        case 1:
                            switch (Player.Get(Team.SCP).Count())
                            {
                                case 0:
                                    Cassie.MessageTranslated("MTFunit Epsilon 11 designated Nato_B 14 HasEntered Allremaining NoSCPsLeft", "Mobile Task Force Unit Epsilon-11 designated Bravo 14 has entered the facility. All remaining personnel are advised to proceed with standard evacuation protocols until an MTF squad reaches your destination. Substantial threat to safety remains within the facility -- exercise caution.");
                                    break;
                                case 1:
                                    Cassie.MessageTranslated("MTFunit Epsilon 11 designated Nato_B 14 HasEntered Allremaining AwaitingRecontainment 1 ScpSubject", "Mobile Task Force Unit  Epsilon-11 designated Bravo 14 has entered the facility. All remaining personnel are advised to proceed with standard evacuation protocols until an MTF squad reaches your destination. Awaiting re-containemnt of: 1 SCP subject.");
                                    break;
                                default:
                                    Cassie.MessageTranslated($"MTFunit Epsilon 11 designated Nato_B 14 HasEntered Allremaining AwaitingRecontainment {Player.Get(Team.SCP).Where(p => p.Role != RoleType.Scp0492).Count()} ScpSubjects", $"Mobile Task Force Unit  Epsilon-11 designated Bravo 14 has entered the facility. All remaining personnel are advised to proceed with standard evacuation protocols until an MTF squad reaches your destination. Awaiting re-containemnt of: {Player.Get(Team.SCP).Where(p => p.Role != RoleType.Scp0492).Count()} SCP subjects.");
                                    break;
                            }
                            break;
                        case 2:
                            Cassie.Message("3. out of 3 generators activated . allgeneratorsengaged");
                            Cassie.Message("Overcharge in . 3 .  2 . 1");
                            Timing.CallDelayed(21.5f, () => {
                                Map.TurnOffAllLights(10, ZoneType.HeavyContainment);
                                Door.LockAll(10, ZoneType.HeavyContainment, DoorLockType.NoPower);
                                if (Player.Get(RoleType.Scp079).Count() > 0)
                                {
                                    if (Player.Get(RoleType.ClassD).Count() > 0) Cassie.Message("SCP 0 7 9 contained successfully by class D personnel");
                                    else if (Player.Get(Team.CHI).Count() > 0) Cassie.Message("SCP 0 7 9 contained successfully by Chaos Insurgency");
                                    else if (Player.Get(Team.MTF).Count() > 0) Cassie.Message("SCP 0 7 9 contained successfully . containment unit NATO_B 14");
                                    else if (Player.Get(Team.RSC).Count() > 0) Cassie.Message("SCP 0 7 9 contained successfully by science personnel");
                                    else Cassie.Message("scp 0 7 9 successfully terminated . termination cause unspecified");
                                }
                                else
                                {
                                    Timing.CallDelayed(10f, () => {
                                        Cassie.Message("Facility is back in operational mode");
                                    });
                                }
                            });
                            break;
                        case 3:
                            Cassie.Message($"Xmas_epsilon11 NATO_B 14 Xmas_hasentered {Player.Get(Team.SCP).Where(p => p.Role != RoleType.Scp0492).Count()} xmas_scpsubjects");
                            break;
                        case 4:
                            if (Player.Get(RoleType.Scp173).Count() > 0) Cassie.MessageTranslated("SCP 1 7 3 successfully terminated by Automatic Security System", "SCP-173 successfully terminated by Automatic Security System.");
                            else if (Player.Get(RoleType.Scp93953).Count() > 0 || Player.Get(RoleType.Scp93989).Count() > 0) Cassie.MessageTranslated("SCP 9 3 9 successfully terminated by Automatic Security System", "SCP-939 successfully terminated by Automatic Security System.");
                            else if (Player.Get(RoleType.Scp096).Count() > 0) Cassie.MessageTranslated("SCP 0 9 6 successfully terminated by Automatic Security System", "SCP-096 successfully terminated by Automatic Security System.");
                            else if (Player.Get(RoleType.Scp106).Count() > 0) Cassie.MessageTranslated("SCP 1 0 6 successfully terminated by Automatic Security System", "SCP-106 successfully terminated by Automatic Security System.");
                            else if (Player.Get(RoleType.Scp049).Count() > 0) Cassie.MessageTranslated("SCP 0 4 9 successfully terminated by Automatic Security System", "SCP-049 successfully terminated by Automatic Security System.");
                            else Cassie.Message("pitch_0.1 .g6 pitch_0.2 .g6 pitch_0.3 .g6 pitch_0.4 .g6 pitch_0.5 .g6", false, false);
                            break;
                    }
                    break;
            }
            response = "The lottery wheel has been spun!";
            return true;
        }
    }
}
