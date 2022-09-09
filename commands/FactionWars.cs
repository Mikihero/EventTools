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

        public void BeforeWeaponsStuff(Player commandSender)
        {
            if (Plugin.Instance.Config.FWCleanupItems)
            {
                foreach (Pickup item in Map.Pickups)
                    item.Destroy();
            }
            int test = 0;
            foreach (Player pl in Player.List)
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
                pl.SetRole(RoleType.ClassD);
            }
            foreach (Player pl in Scientist)
            {
                pl.SetRole(RoleType.Scientist);
            }
        }

        public void WeaponsStuff(Player pl, string weapon, DoorType door)
        {
            pl.ClearInventory();
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
                    pl.AddItem(ItemType.Medkit);
                    pl.AddItem(ItemType.SCP500);
                    break;
                case "fsp9":
                    pl.AddItem(ItemType.ArmorCombat);
                    pl.AddItem(ItemType.GunFSP9);
                    pl.SetAmmo(AmmoType.Nato9, 150);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddItem(ItemType.SCP500);
                    pl.AddItem(ItemType.Adrenaline);
                    break;
                case "crossvec":
                    pl.AddItem(ItemType.ArmorCombat);
                    pl.AddItem(ItemType.GunCrossvec);
                    pl.SetAmmo(AmmoType.Nato9, 150);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddItem(ItemType.SCP500);
                    pl.AddItem(ItemType.Adrenaline);
                    break;
                case "ak":
                    pl.AddItem(ItemType.ArmorCombat);
                    pl.AddItem(ItemType.GunAK);
                    pl.SetAmmo(AmmoType.Nato762, 150);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddItem(ItemType.SCP500);
                    pl.AddItem(ItemType.Adrenaline);
                    break;
                case "epsilon":
                    pl.AddItem(ItemType.ArmorCombat);
                    pl.AddItem(ItemType.GunE11SR);
                    pl.SetAmmo(AmmoType.Nato556, 150);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddItem(ItemType.SCP500);
                    pl.AddItem(ItemType.Adrenaline);
                    break;
                case "logicer":
                    pl.AddItem(ItemType.ArmorHeavy);
                    pl.AddItem(ItemType.GunLogicer);
                    pl.SetAmmo(AmmoType.Nato762, 200);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddItem(ItemType.SCP500, 2);
                    pl.AddItem(ItemType.Adrenaline);
                    break;
                case "shotgun":
                    pl.AddItem(ItemType.ArmorHeavy);
                    pl.AddItem(ItemType.GunShotgun);
                    pl.SetAmmo(AmmoType.Ammo12Gauge, 69);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddItem(ItemType.SCP500);
                    pl.AddItem(ItemType.Adrenaline, 2);
                    break;
                case "revolver":
                    pl.AddItem(ItemType.ArmorCombat);
                    pl.AddItem(ItemType.GunRevolver);
                    pl.SetAmmo(AmmoType.Ammo44Cal, 69);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddItem(ItemType.SCP500);
                    break;
                case "lasergun":
                    pl.AddItem(ItemType.ParticleDisruptor, 4);
                    pl.AddItem(ItemType.Medkit, 2);
                    pl.AddItem(ItemType.SCP500, 2);
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
            Timing.CallDelayed(20f, () =>
            {
                CloseDoors(zone);
            });
        }

        public void CloseDoors(ZoneType zone)
        {
            switch(zone)
            {
                case ZoneType.Entrance:
                    Door.UnlockAll();
                    Door.Get(DoorType.CheckpointEntrance).Lock(9999, DoorLockType.AdminCommand);
                    Door.Get(DoorType.GateA).Lock(9999, DoorLockType.AdminCommand);
                    Door.Get(DoorType.GateB).Lock(9999, DoorLockType.AdminCommand);
                    break;
                case ZoneType.HeavyContainment:
                    Door.UnlockAll();
                    Door.Get(DoorType.HID).Lock(9999, DoorLockType.AdminCommand);
                    Door.Get(DoorType.HczArmory).Lock(9999, DoorLockType.AdminCommand);
                    Door.Get(DoorType.CheckpointLczA).Lock(9999, DoorLockType.AdminCommand);
                    Door.Get(DoorType.CheckpointLczB).Lock(9999, DoorLockType.AdminCommand);
                    Door.Get(DoorType.CheckpointEntrance).Lock(9999, DoorLockType.AdminCommand);
                    Door.Get(DoorType.NukeArmory).Lock(9999, DoorLockType.AdminCommand);
                    Door.Get(DoorType.Scp079First).Lock(9999, DoorLockType.AdminCommand);
                    break;
                default:
                    Log.Info("How in the fuck");
                    break;
            }
        }

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            ClassD.Clear();
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
                        foreach (Player pl in ClassD)
                        {
                            WeaponsStuff(pl, "fsp9", DoorType.ServersBottom);
                        }
                        foreach (Player pl in Scientist)
                        {
                            WeaponsStuff(pl, "fsp9", DoorType.Scp096);
                        }
                        RemainingStuff(ZoneType.HeavyContainment);
                        response = "Faction Wars were successfully started!";
                        return true;
                    case "crossvec":
                        BeforeWeaponsStuff(Player.Get(sender));
                        foreach (Player pl in ClassD)
                        {
                            WeaponsStuff(pl, "crossvec", DoorType.ServersBottom);
                        }
                        foreach (Player pl in Scientist)
                        {
                            WeaponsStuff(pl, "crossvec", DoorType.Scp096);
                        }
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
                        foreach (Player pl in ClassD)
                        {
                            WeaponsStuff(pl, "epsilon", DoorType.ServersBottom);
                        }
                        foreach (Player pl in Scientist)
                        {
                            WeaponsStuff(pl, "epsilon", DoorType.Scp096);
                        }
                        RemainingStuff(ZoneType.HeavyContainment);
                        response = "Faction Wars were successfully started!";
                        return true;
                    case "logicer":
                        BeforeWeaponsStuff(Player.Get(sender));
                        foreach (Player pl in ClassD)
                        {
                            WeaponsStuff(pl, "logicer", DoorType.ServersBottom);
                        }
                        foreach (Player pl in Scientist)
                        {
                            WeaponsStuff(pl, "logicer", DoorType.Scp096);
                        }
                        RemainingStuff(ZoneType.HeavyContainment);
                        response = "Faction Wars were successfully started!";
                        return true;
                    case "shotgun":
                        BeforeWeaponsStuff(Player.Get(sender));
                        foreach (Player pl in ClassD)
                        {
                            WeaponsStuff(pl, "shotgun", DoorType.GateA);
                        }
                        foreach (Player pl in Scientist)
                        {
                            WeaponsStuff(pl, "shotgun", DoorType.GateB);
                        }
                        RemainingStuff(ZoneType.Entrance);
                        response = "Faction Wars were successfully started!";
                        return true;
                    case "revolver":
                        BeforeWeaponsStuff(Player.Get(sender));
                        foreach (Player pl in ClassD)
                        {
                            WeaponsStuff(pl, "revolver", DoorType.GateA);
                        }
                        foreach (Player pl in Scientist)
                        {
                            WeaponsStuff(pl, "revolver", DoorType.GateB);
                        }
                        RemainingStuff(ZoneType.Entrance);
                        response = "Faction Wars were successfully started!";
                        return true;
                    case "lasergun":
                        BeforeWeaponsStuff(Player.Get(sender));
                        foreach (Player pl in ClassD)
                        {
                            WeaponsStuff(pl, "lasergun", DoorType.GateA);
                        }
                        foreach (Player pl in Scientist)
                        {
                            WeaponsStuff(pl, "lasergun", DoorType.GateB);
                        }
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
