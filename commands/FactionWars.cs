using System;
using System.Collections.Generic;
using MEC;
using CommandSystem;
using Exiled.API.Features;
using Exiled.API.Enums;
using Exiled.API.Features.Items;
using Exiled.Permissions.Extensions;
using PlayerRoles;

namespace EventTools.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class FactionWars : ICommand, IUsageProvider
    {
        public string Command => "FactionWars";

        public string[] Aliases { get; set; } = { "FWars", "Wars" };

        public string Description => "Starts an event of faction wars.";

        public string[] Usage { get; set; } = { "weapon", "use <b><u>factionwars weapons</u></b> to see all the weapons" };

        public static HashSet<Player> ClassD = new HashSet<Player> { };
        public static HashSet<Player> Scientist = new HashSet<Player> { };
        public static bool IsEventActive = false;

        public void PreparePlayers(Player commandSender)
        {
            commandSender.AddItem(ItemType.GunE11SR);
            commandSender.AddItem(ItemType.ArmorCombat);
            commandSender.SetAmmo(AmmoType.Nato556, 120);
            if (Plugin.Instance.Config.FWDisaableFF)
            {
                Server.FriendlyFire = false;
            }
            int helper = 0;
            foreach (Player pl in Player.List) //divides all players except for the command sender into 2 groups
            {
                if (pl != commandSender)
                {
                    if (helper == 0)
                    {
                        ClassD.Add(pl);
                        helper = 1;
                    }
                    else if (helper == 1)
                    {
                        Scientist.Add(pl);
                        helper = 0;
                    }
                }
            }
            foreach (Player pl in ClassD)
            {
                pl.SetAmmo(AmmoType.Ammo12Gauge, 0); //player.ClearInventory() doesn't remove ammo so any ammo over the no-armor ammo limit just falls on the ground if it isn't set to 0 this way
                pl.SetAmmo(AmmoType.Ammo44Cal, 0);
                pl.SetAmmo(AmmoType.Nato556, 0);
                pl.SetAmmo(AmmoType.Nato762, 0);
                pl.SetAmmo(AmmoType.Nato9, 0);
                pl.Role.Set(RoleTypeId.ClassD);
                pl.SetAmmo(AmmoType.Ammo12Gauge, 0); //done again in case a plugin like commonutils is used to set the starting ammo of a class
                pl.SetAmmo(AmmoType.Ammo44Cal, 0);
                pl.SetAmmo(AmmoType.Nato556, 0);
                pl.SetAmmo(AmmoType.Nato762, 0);
                pl.SetAmmo(AmmoType.Nato9, 0);
                pl.ClearInventory();
            }
            foreach (Player pl in Scientist)
            {
                pl.SetAmmo(AmmoType.Ammo12Gauge, 0); //player.ClearInventory() doesn't remove ammo so any ammo over the no-armor ammo limit just falls on the ground if it isn't set to 0 this way
                pl.SetAmmo(AmmoType.Ammo44Cal, 0);
                pl.SetAmmo(AmmoType.Nato556, 0);
                pl.SetAmmo(AmmoType.Nato762, 0);
                pl.SetAmmo(AmmoType.Nato9, 0);
                pl.Role.Set(RoleTypeId.ClassD);
                pl.SetAmmo(AmmoType.Ammo12Gauge, 0); //done again in case a plugin like commonutils is used to set the starting ammo of a class
                pl.SetAmmo(AmmoType.Ammo44Cal, 0);
                pl.SetAmmo(AmmoType.Nato556, 0);
                pl.SetAmmo(AmmoType.Nato762, 0);
                pl.SetAmmo(AmmoType.Nato9, 0);
                pl.ClearInventory();
            }
        }

        public void TPAndWeapons(Player pl, ItemType weapon, DoorType door)
        {
            Door.Get(door).IsOpen = true; //opening the door before teleporting players in to prevent any form of desync's happening
            pl.Teleport(Door.Get(door));
            switch (weapon)
            {
                case ItemType.GunCOM15:
                    pl.AddItem(ItemType.ArmorCombat);
                    pl.AddItem(ItemType.GunCOM15);
                    pl.SetAmmo(AmmoType.Nato9, 100);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddItem(ItemType.Painkillers);
                    break;
                case ItemType.GunCOM18:
                    pl.AddItem(ItemType.ArmorCombat);
                    pl.AddItem(ItemType.GunCOM18);
                    pl.SetAmmo(AmmoType.Nato9, 120);
                    pl.AddItem(ItemType.SCP500);
                    pl.AddItem(ItemType.Medkit);
                    break;
                case ItemType.GunFSP9:
                    pl.AddItem(ItemType.ArmorCombat);
                    pl.AddItem(ItemType.GunFSP9);
                    pl.SetAmmo(AmmoType.Nato9, 150);
                    pl.AddItem(ItemType.SCP500);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddItem(ItemType.Adrenaline);
                    break;
                case ItemType.GunCrossvec:
                    pl.AddItem(ItemType.ArmorCombat);
                    pl.AddItem(ItemType.GunCrossvec);
                    pl.SetAmmo(AmmoType.Nato9, 150);
                    pl.AddItem(ItemType.SCP500);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddItem(ItemType.Adrenaline);
                    break;
                case ItemType.GunAK:
                    pl.AddItem(ItemType.ArmorCombat);
                    pl.AddItem(ItemType.GunAK);
                    pl.SetAmmo(AmmoType.Nato762, 150);
                    pl.AddItem(ItemType.SCP500);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddItem(ItemType.Adrenaline);
                    break;
                case ItemType.GunE11SR:
                    pl.AddItem(ItemType.ArmorCombat);
                    pl.AddItem(ItemType.GunE11SR);
                    pl.SetAmmo(AmmoType.Nato556, 150);
                    pl.AddItem(ItemType.SCP500);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddItem(ItemType.Adrenaline);
                    break;
                case ItemType.GunLogicer:
                    pl.AddItem(ItemType.ArmorHeavy);
                    pl.AddItem(ItemType.GunLogicer);
                    pl.SetAmmo(AmmoType.Nato762, 200);
                    pl.AddItem(ItemType.SCP500, 2);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddItem(ItemType.Adrenaline);
                    break;
                case ItemType.GunShotgun:
                    pl.AddItem(ItemType.ArmorHeavy);
                    pl.AddItem(ItemType.GunShotgun);
                    pl.SetAmmo(AmmoType.Ammo12Gauge, 69);
                    pl.AddItem(ItemType.SCP500);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddItem(ItemType.Adrenaline, 2);
                    break;
                case ItemType.GunRevolver:
                    pl.AddItem(ItemType.ArmorCombat);
                    pl.AddItem(ItemType.GunRevolver);
                    pl.SetAmmo(AmmoType.Ammo44Cal, 69);
                    pl.AddItem(ItemType.SCP500);
                    pl.AddItem(ItemType.Medkit);
                    break;
                case ItemType.ParticleDisruptor:
                    Timing.CallDelayed(28f, () =>
                    {
                        pl.AddItem(ItemType.ParticleDisruptor, 4);
                        pl.AddItem(ItemType.SCP500, 2);
                        pl.AddItem(ItemType.Medkit, 2);
                    });
                    break;
                default:
                    Log.Info("If you're seeing this, open an issue on github (https://github.com/Mikihero/EventTools)");
                    break;
            }
            
        }

        public void DoorsAndCassie(ZoneType zone)
        {
            Door.LockAll(9999, DoorLockType.AdminCommand);
            Cassie.Message("30 29 28 27 26 25 24 23 22 21 20 19 18 17 16 15 14 13 12 11 10 9 8 7 6 5 4 3 2 1 start", false, true, true);
            Timing.CallDelayed(28f, () => //a delay of 28 seconds calls LockDoors() exactly after the cassie ends
            {
                LockDoors(zone);
            });
            IsEventActive = true;
        }

        public void LockDoors(ZoneType zone)
        {
            switch(zone)
            {
                case ZoneType.Entrance:
                    Door.UnlockAll();
                    Door.Get(DoorType.CheckpointEzHczA).ChangeLock(DoorLockType.AdminCommand); //Locking all the rooms that could be abused
                    Door.Get(DoorType.CheckpointEzHczB).ChangeLock(DoorLockType.AdminCommand); 
                    Door.Get(DoorType.Intercom).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.GateA).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.GateB).ChangeLock(DoorLockType.AdminCommand);
                    break;
                case ZoneType.HeavyContainment:
                    Door.UnlockAll();
                    Door.Get(DoorType.HID).ChangeLock(DoorLockType.AdminCommand); //Locking all the rooms that could be abused
                    Door.Get(DoorType.HczArmory).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.CheckpointLczA).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.CheckpointLczB).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.CheckpointEzHczA).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.CheckpointEzHczB).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.Scp079First).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.Scp106Primary).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.Scp106Secondary).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.Scp096).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.Scp096).IsOpen = true; //this has to be open because that's where scientists start
                    break;
                default:
                    Log.Info("If you're seeing this, open an issue on github (https://github.com/Mikihero/EventTools)");
                    break;
            }
        }

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Permissions.CheckPermission(Player.Get(sender), "et.fwars"))
            {
                response = "You don't have permission to use this command.";
                return false;
            }
            ClassD.Clear(); //clears both of the player lists before executing the rest of the command to prevent any bad things from happening
            Scientist.Clear();
            if (arguments.Count < 1)
            {
                response = "Incorrect usage.";
                return false;
            }
            else
            {
                switch (arguments.At(0))
                {
                    case "weapons":
                        response = "<b>Possible weapons:</b> \n - com15 \n - com18 \n - fsp9 \n - crossvec \n - ak \n - epsilon \n - logicer \n - shotgun \n - revolver \n - lasergun";
                        return false;
                    case "com15":
                        PreparePlayers(Player.Get(sender));
                        Timing.CallDelayed(1f, () =>
                        {
                            foreach (Player pl in ClassD)
                            {
                                TPAndWeapons(pl, ItemType.GunCOM15, DoorType.GateA);
                            }
                            foreach (Player pl in Scientist)
                            {
                                TPAndWeapons(pl, ItemType.GunCOM15, DoorType.GateB);
                            }
                        });
                        DoorsAndCassie(ZoneType.Entrance);
                        response = "Faction Wars were successfully started!";
                        return true;
                    case "com18":
                        PreparePlayers(Player.Get(sender));
                        Timing.CallDelayed(1f, () =>
                        {
                            foreach (Player pl in ClassD)
                            {
                                TPAndWeapons(pl, ItemType.GunCOM18, DoorType.GateA);
                            }
                            foreach (Player pl in Scientist)
                            {
                                TPAndWeapons(pl, ItemType.GunCOM18, DoorType.GateB);
                            }
                        });
                        DoorsAndCassie(ZoneType.Entrance);
                        response = "Faction Wars were successfully started!";
                        return true;
                    case "fsp9":
                        PreparePlayers(Player.Get(sender));
                        Timing.CallDelayed(1f, () => {
                            foreach (Player pl in ClassD)
                            {
                                TPAndWeapons(pl, ItemType.GunFSP9, DoorType.ServersBottom);
                            }
                            foreach (Player pl in Scientist)
                            {
                                TPAndWeapons(pl, ItemType.GunFSP9, DoorType.Scp096);
                            }
                        });
                        DoorsAndCassie(ZoneType.HeavyContainment);
                        response = "Faction Wars were successfully started!";
                        return true;
                    case "crossvec":
                        PreparePlayers(Player.Get(sender));
                        Timing.CallDelayed(1f, () => {
                            foreach (Player pl in ClassD)
                            {
                                TPAndWeapons(pl, ItemType.GunCrossvec, DoorType.ServersBottom);
                            }
                            foreach (Player pl in Scientist)
                            {
                                TPAndWeapons(pl, ItemType.GunCrossvec, DoorType.Scp096);
                            }
                        });
                        DoorsAndCassie(ZoneType.HeavyContainment);
                        response = "Faction Wars were successfully started!";
                        return true;
                    case "ak":
                        PreparePlayers(Player.Get(sender));
                        Timing.CallDelayed(1f, () => {
                            foreach (Player pl in ClassD)
                            {
                                TPAndWeapons(pl, ItemType.GunAK, DoorType.ServersBottom);
                            }
                            foreach (Player pl in Scientist)
                            {
                                TPAndWeapons(pl, ItemType.GunAK, DoorType.Scp096);
                            }
                        });
                        DoorsAndCassie(ZoneType.HeavyContainment);
                        response = "Faction Wars were successfully started!";
                        return true;
                    case "epsilon":
                        PreparePlayers(Player.Get(sender));
                        Timing.CallDelayed(1f, () => {
                            foreach (Player pl in ClassD)
                            {
                                TPAndWeapons(pl, ItemType.GunE11SR, DoorType.ServersBottom);
                            }
                            foreach (Player pl in Scientist)
                            {
                                TPAndWeapons(pl, ItemType.GunE11SR, DoorType.Scp096);
                            }
                        });
                        DoorsAndCassie(ZoneType.HeavyContainment);
                        response = "Faction Wars were successfully started!";
                        return true;
                    case "logicer":
                        PreparePlayers(Player.Get(sender));
                        Timing.CallDelayed(1f, () => {
                            foreach (Player pl in ClassD)
                            {
                                TPAndWeapons(pl, ItemType.GunLogicer, DoorType.ServersBottom);
                            }
                            foreach (Player pl in Scientist)
                            {
                                TPAndWeapons(pl, ItemType.GunLogicer, DoorType.Scp096);
                            }
                        });
                        DoorsAndCassie(ZoneType.HeavyContainment);
                        response = "Faction Wars were successfully started!";
                        return true;
                    case "shotgun":
                        PreparePlayers(Player.Get(sender));
                        Timing.CallDelayed(1f, () => {
                            foreach (Player pl in ClassD)
                            {
                                TPAndWeapons(pl, ItemType.GunShotgun, DoorType.GateA);
                            }
                            foreach (Player pl in Scientist)
                            {
                                TPAndWeapons(pl, ItemType.GunShotgun, DoorType.GateB);
                            }
                        });
                        DoorsAndCassie(ZoneType.Entrance);
                        response = "Faction Wars were successfully started!";
                        return true;
                    case "revolver":
                        PreparePlayers(Player.Get(sender));
                        Timing.CallDelayed(1f, () => {
                            foreach (Player pl in ClassD)
                            {
                                TPAndWeapons(pl, ItemType.GunRevolver, DoorType.GateA);
                            }
                            foreach (Player pl in Scientist)
                            {
                                TPAndWeapons(pl, ItemType.GunRevolver, DoorType.GateB);
                            }
                        });
                        DoorsAndCassie(ZoneType.Entrance);
                        response = "Faction Wars were successfully started!";
                        return true;
                    case "lasergun":
                        PreparePlayers(Player.Get(sender));
                        Timing.CallDelayed(1f, () => {
                            foreach (Player pl in ClassD)
                            {
                                TPAndWeapons(pl, ItemType.ParticleDisruptor, DoorType.GateA);
                            }
                            foreach (Player pl in Scientist)
                            {
                                TPAndWeapons(pl, ItemType.ParticleDisruptor, DoorType.GateB);
                            }
                        });
                        DoorsAndCassie(ZoneType.Entrance);
                        response = "Faction Wars were successfully started!";
                        return true;
                    default:
                        response = "Incorrect usage.";
                        return false;
                }
            }
        }
    }
}