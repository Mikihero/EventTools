using System;
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
            int lotteryTicket = Rd.Next(15, 16);
            string message = EventTools.Instance.Config.LotteryBC.Replace("[NUMBER]", lotteryTicket.ToString());
            Log.Info("Herobrine.");
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
                    //nic
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
                    //nic
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
                    int ClassDCount = 0;
                    int ScientistCount = 0;
                    int MTFCount = 0;
                    int CICount = 0;
                    int ScpAmount = 0;
                    int Count079 = 0;
                    foreach (Player pl in Player.List)
                    {
                        if (pl.Role == RoleType.ClassD) ClassDCount++;
                        if (pl.Role == RoleType.Scientist) ScientistCount++;
                        if (pl.Role == RoleType.Scp079) Count079++;
                        if (pl.LeadingTeam == LeadingTeam.FacilityForces && pl.Role != RoleType.Scientist) MTFCount++;
                        if (pl.LeadingTeam == LeadingTeam.ChaosInsurgency && pl.Role != RoleType.ClassD) CICount++;
                        if (pl.LeadingTeam == LeadingTeam.Anomalies && pl.Role != RoleType.Scp0492) ScpAmount++;
                    }
                    switch (RandomCassie)
                    {
                        case 1:
                            switch (ScpAmount)
                            {
                                case 0:
                                    Cassie.Message("MTFunit Epsilon 11 designated Nato_B 14 HasEntered Allremaining NoSCPsLeft");
                                    break;
                                case 1:
                                    Cassie.Message("MTFunit Epsilon 11 designated Nato_B 14 HasEntered Allremaining AwaitingRecontainment 1 ScpSubject");
                                    break;
                                default:
                                    Cassie.Message($"MTFunit Epsilon 11 designated Nato_B 14 HasEntered Allremaining AwaitingRecontainment {ScpAmount} ScpSubjects");
                                    break;
                            }
                            break;
                        case 2:
                            Cassie.Message("3. out of 3 generators activated . allgeneratorsengaged");
                            Cassie.Message("Overcharge in . 3 .  2 . 1");
                            Timing.CallDelayed(21.5f, () => {
                                Map.TurnOffAllLights(10, ZoneType.HeavyContainment);
                                Door.LockAll(10, ZoneType.HeavyContainment, DoorLockType.NoPower);
                                if (Count079 > 0)
                                {
                                    if (ClassDCount > 0) Cassie.Message("SCP 0 7 9 contained successfully by class D personnel");
                                    else if (CICount > 0) Cassie.Message("SCP 0 7 9 contained successfully by Chaos Insurgency");
                                    else if (MTFCount > 0) Cassie.Message("SCP 0 7 9 contained successfully . containment unit NATO_B 14");
                                    else if (ScientistCount > 0) Cassie.Message("SCP 0 7 9 contained successfully by science personnel");
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
                            Cassie.Message($"Xmas_epsilon11 NATO_B 14 Xmas_hasentered {ScpAmount} xmas_scpsubjects");
                            break;
                        case 4:
                            foreach (Player pl in Player.List)
                            {
                                if (pl.Role == RoleType.Scp173) Cassie.Message("SCP 1 7 3 successfully terminated by Automatic Security System");
                                if (pl.Role == RoleType.Scp049) Cassie.Message("SCP 0 4 9 successfully terminated by Automatic Security System");
                                if (pl.Role == RoleType.Scp096) Cassie.Message("SCP 0 9 6 successfully terminated by Automatic Security System");
                                if (pl.Role == RoleType.Scp106) Cassie.Message("SCP 1 0 6 successfully terminated by Automatic Security System");
                                if (pl.Role == RoleType.Scp93953 || pl.Role == RoleType.Scp93989) Cassie.Message("SCP 9 3 9 successfully terminated by Automatic Security System");
                                else Cassie.Message("pitch_0.1 .g6 pitch_0.2 .g6 pitch_0.3 .g6 pitch_0.4 .g6 pitch_0.5 .g6", false, false);
                            }
                            break;
                    }
                    break;
            }
            response = "The lottery wheel has been spun!";
            return true;
        }
    }
}
