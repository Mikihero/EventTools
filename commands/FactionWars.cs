using System;
using System.Collections.Generic;
using MEC;
using CommandSystem;
using Exiled.API.Features;
using Exiled.API.Enums;
using Exiled.API.Features.Items;

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

        public void BeforeWeaponsStuff(Player commandSender)
        {
            if (Plugin.Instance.Config.FWCleanupItems)
            {
                foreach (Pickup item in Map.Pickups)
                {
                    item.Destroy();
                }
            }
            int test = 0;
            foreach (Player pl in Player.List) //divides all players except for the command sender into 2 groups
            {
                if (pl != commandSender)
                {
                    if (test == 0)
                    {
                        ClassD.Add(pl);
                        test = 1;
                    }
                    else if (test == 1)
                    {
                        Scientist.Add(pl);
                        test = 0;
                    }
                }
            }
            commandSender.SetRole(RoleType.Tutorial);
            commandSender.NoClipEnabled = true;
            foreach (Player pl in ClassD)
            {
                pl.SetAmmo(AmmoType.Ammo12Gauge, 0); //player.ClearInventory() doesn't remove ammo so any ammo over the no-armor ammo limit just falls on the ground if it isn't set to 0 this way
                pl.SetAmmo(AmmoType.Ammo44Cal, 0);
                pl.SetAmmo(AmmoType.Nato556, 0);
                pl.SetAmmo(AmmoType.Nato762, 0);
                pl.SetAmmo(AmmoType.Nato9, 0);
                pl.SetRole(RoleType.ClassD);
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
                pl.SetRole(RoleType.ClassD);
                pl.SetAmmo(AmmoType.Ammo12Gauge, 0); //done again in case a plugin like commonutils is used to set the starting ammo of a class
                pl.SetAmmo(AmmoType.Ammo44Cal, 0);
                pl.SetAmmo(AmmoType.Nato556, 0);
                pl.SetAmmo(AmmoType.Nato762, 0);
                pl.SetAmmo(AmmoType.Nato9, 0);
                pl.ClearInventory();
            }
        }

        public void WeaponsStuff(Player pl, string weapon, DoorType door)
        {
            Door.Get(DoorType.ServersBottom).IsOpen = true; //opening the doors before teleporting in players to prevent any form of desync's happening
            Door.Get(DoorType.GateA).IsOpen = true;
            Door.Get(DoorType.GateB).IsOpen = true;
            pl.Teleport(Door.Get(door));
            switch (weapon)
            {
                case "com15":
                    pl.AddItem(ItemType.ArmorCombat);
                    pl.AddItem(ItemType.GunCOM15);
                    pl.SetAmmo(AmmoType.Nato9, 100);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddItem(ItemType.Painkillers);
                    break;
                case "com18":
                    pl.AddItem(ItemType.ArmorCombat);
                    pl.AddItem(ItemType.GunCOM18);
                    pl.SetAmmo(AmmoType.Nato9, 120);
                    pl.AddItem(ItemType.SCP500);
                    pl.AddItem(ItemType.Medkit);
                    break;
                case "fsp9":
                    pl.AddItem(ItemType.ArmorCombat);
                    pl.AddItem(ItemType.GunFSP9);
                    pl.SetAmmo(AmmoType.Nato9, 150);
                    pl.AddItem(ItemType.SCP500);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddItem(ItemType.Adrenaline);
                    break;
                case "crossvec":
                    pl.AddItem(ItemType.ArmorCombat);
                    pl.AddItem(ItemType.GunCrossvec);
                    pl.SetAmmo(AmmoType.Nato9, 150);
                    pl.AddItem(ItemType.SCP500);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddItem(ItemType.Adrenaline);
                    break;
                case "ak":
                    pl.AddItem(ItemType.ArmorCombat);
                    pl.AddItem(ItemType.GunAK);
                    pl.SetAmmo(AmmoType.Nato762, 150);
                    pl.AddItem(ItemType.SCP500);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddItem(ItemType.Adrenaline);
                    break;
                case "epsilon":
                    pl.AddItem(ItemType.ArmorCombat);
                    pl.AddItem(ItemType.GunE11SR);
                    pl.SetAmmo(AmmoType.Nato556, 150);
                    pl.AddItem(ItemType.SCP500);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddItem(ItemType.Adrenaline);
                    break;
                case "logicer":
                    pl.AddItem(ItemType.ArmorHeavy);
                    pl.AddItem(ItemType.GunLogicer);
                    pl.SetAmmo(AmmoType.Nato762, 200);
                    pl.AddItem(ItemType.SCP500, 2);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddItem(ItemType.Adrenaline);
                    break;
                case "shotgun":
                    pl.AddItem(ItemType.ArmorHeavy);
                    pl.AddItem(ItemType.GunShotgun);
                    pl.SetAmmo(AmmoType.Ammo12Gauge, 69);
                    pl.AddItem(ItemType.SCP500);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddItem(ItemType.Adrenaline, 2);
                    break;
                case "revolver":
                    pl.AddItem(ItemType.ArmorCombat);
                    pl.AddItem(ItemType.GunRevolver);
                    pl.SetAmmo(AmmoType.Ammo44Cal, 69);
                    pl.AddItem(ItemType.SCP500);
                    pl.AddItem(ItemType.Medkit);
                    break;
                case "lasergun":
                    pl.AddItem(ItemType.ParticleDisruptor, 4);
                    pl.AddItem(ItemType.SCP500, 2);
                    pl.AddItem(ItemType.Medkit, 2);
                    break;
                default:
                    Log.Info("how in the fuck");
                    break;
            }
        }

        public void RemainingStuff(ZoneType zone)
        {
            Door.LockAll(9999, DoorLockType.AdminCommand);
            Cassie.Message("30 29 28 27 26 25 24 23 22 21 20 19 18 17 16 15 14 13 12 11 10 9 8 7 6 5 4 3 2 1 start", false, true, true);
            Timing.CallDelayed(28f, () => //a delay of 28 seconds calls the DoorsStuff() exactly after the broadcast ends
            {
                DoorsStuff(zone);
            });
            IsEventActive = true;
        }

        public void DoorsStuff(ZoneType zone)
        {
            switch(zone)
            {
                case ZoneType.Entrance:
                    Door.UnlockAll();
                    Door.Get(DoorType.CheckpointEntrance).ChangeLock(DoorLockType.AdminCommand); //Locking all the rooms that could be abused
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
                    Door.Get(DoorType.CheckpointEntrance).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.Scp079First).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.Scp106Primary).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.Scp106Secondary).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.Scp096).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.Scp096).IsOpen = true; //this has to be open because that's where scientists start
                    break;
                default:
                    Log.Info("How in the fuck");
                    break;
            }
        }

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
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
                        BeforeWeaponsStuff(Player.Get(sender));
                        Timing.CallDelayed(1f, () =>
                        {
                            foreach (Player pl in ClassD)
                            {
                                WeaponsStuff(pl, "com15", DoorType.GateA);
                            }
                            foreach (Player pl in Scientist)
                            {
                                WeaponsStuff(pl, "com15", DoorType.GateB);
                            }
                        });
                        RemainingStuff(ZoneType.Entrance);
                        response = "Faction Wars were successfully started!";
                        return true;
                    case "com18":
                        BeforeWeaponsStuff(Player.Get(sender));
                        Timing.CallDelayed(1f, () =>
                        {
                            foreach (Player pl in ClassD)
                            {
                                WeaponsStuff(pl, "com18", DoorType.GateA);
                            }
                            foreach (Player pl in Scientist)
                            {
                                WeaponsStuff(pl, "com18", DoorType.GateB);
                            }
                        });
                        RemainingStuff(ZoneType.Entrance);
                        response = "Faction Wars were successfully started!";
                        return true;
                    case "fsp9":
                        BeforeWeaponsStuff(Player.Get(sender));
                        Timing.CallDelayed(1f, () => {
                            foreach (Player pl in ClassD)
                            {
                                WeaponsStuff(pl, "fsp9", DoorType.ServersBottom);
                            }
                            foreach (Player pl in Scientist)
                            {
                                WeaponsStuff(pl, "fsp9", DoorType.Scp096);
                            }
                        });
                        RemainingStuff(ZoneType.HeavyContainment);
                        response = "Faction Wars were successfully started!";
                        return true;
                    case "crossvec":
                        BeforeWeaponsStuff(Player.Get(sender));
                        Timing.CallDelayed(1f, () => {
                            foreach (Player pl in ClassD)
                            {
                                WeaponsStuff(pl, "crossvec", DoorType.ServersBottom);
                            }
                            foreach (Player pl in Scientist)
                            {
                                WeaponsStuff(pl, "crossvec", DoorType.Scp096);
                            }
                        });
                        RemainingStuff(ZoneType.HeavyContainment);
                        response = "Faction Wars were successfully started!";
                        return true;
                    case "ak":
                        BeforeWeaponsStuff(Player.Get(sender));
                        Timing.CallDelayed(1f, () => {
                            foreach (Player pl in ClassD)
                            {
                                WeaponsStuff(pl, "ak", DoorType.ServersBottom);
                            }
                            foreach (Player pl in Scientist)
                            {
                                WeaponsStuff(pl, "ak", DoorType.Scp096);
                            }
                        });
                        RemainingStuff(ZoneType.HeavyContainment);
                        response = "Faction Wars were successfully started!";
                        return true;
                    case "epsilon":
                        BeforeWeaponsStuff(Player.Get(sender));
                        Timing.CallDelayed(1f, () => {
                            foreach (Player pl in ClassD)
                            {
                                WeaponsStuff(pl, "epsilon", DoorType.ServersBottom);
                            }
                            foreach (Player pl in Scientist)
                            {
                                WeaponsStuff(pl, "epsilon", DoorType.Scp096);
                            }
                        });
                        RemainingStuff(ZoneType.HeavyContainment);
                        response = "Faction Wars were successfully started!";
                        return true;
                    case "logicer":
                        BeforeWeaponsStuff(Player.Get(sender));
                        Timing.CallDelayed(1f, () => {
                            foreach (Player pl in ClassD)
                            {
                                WeaponsStuff(pl, "logicer", DoorType.ServersBottom);
                            }
                            foreach (Player pl in Scientist)
                            {
                                WeaponsStuff(pl, "logicer", DoorType.Scp096);
                            }
                        });
                        RemainingStuff(ZoneType.HeavyContainment);
                        response = "Faction Wars were successfully started!";
                        return true;
                    case "shotgun":
                        BeforeWeaponsStuff(Player.Get(sender));
                        Timing.CallDelayed(1f, () => {
                            foreach (Player pl in ClassD)
                            {
                                WeaponsStuff(pl, "shotgun", DoorType.GateA);
                            }
                            foreach (Player pl in Scientist)
                            {
                                WeaponsStuff(pl, "shotgun", DoorType.GateB);
                            }
                        });
                        RemainingStuff(ZoneType.Entrance);
                        response = "Faction Wars were successfully started!";
                        return true;
                    case "revolver":
                        BeforeWeaponsStuff(Player.Get(sender));
                        Timing.CallDelayed(1f, () => {
                            foreach (Player pl in ClassD)
                            {
                                WeaponsStuff(pl, "revolver", DoorType.GateA);
                            }
                            foreach (Player pl in Scientist)
                            {
                                WeaponsStuff(pl, "revolver", DoorType.GateB);
                            }
                        });
                        RemainingStuff(ZoneType.Entrance);
                        response = "Faction Wars were successfully started!";
                        return true;
                    case "lasergun":
                        BeforeWeaponsStuff(Player.Get(sender));
                        Timing.CallDelayed(1f, () => {
                            foreach (Player pl in ClassD)
                            {
                                WeaponsStuff(pl, "lasergun", DoorType.GateA);
                            }
                            foreach (Player pl in Scientist)
                            {
                                WeaponsStuff(pl, "lasergun", DoorType.GateB);
                            }
                        });
                        RemainingStuff(ZoneType.Entrance);
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