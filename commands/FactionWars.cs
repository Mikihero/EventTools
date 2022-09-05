using System;
using System.Collections.Generic;
using MEC;
using CommandSystem;
using Exiled.API.Features;
using Exiled.API.Enums;
using Exiled.API.Features.Items;

namespace EventTools.Commands
{
    class FactionWars : ICommand, IUsageProvider
    {
        public string Command => "FactionWars";

        public string[] Aliases { get; set; } = { "FWars", "Wars" };

        public string Description => "Starts an event of faction wars.";

        public string[] Usage { get; set; } = { "weapon", "use <b><u>factionwars weapons</u></b> to see all the weapons" };

        public HashSet<Player> ClassD = new HashSet<Player> { };
        public HashSet<Player> Scientist = new HashSet<Player> { };

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (arguments.Count < 1)
            {
                response = "Incorrect usage.";
                return false;
            }
            else
            {
                if (Plugin.Instance.Config.FWCleanupItems)
                {
                    foreach (Pickup item in Map.Pickups)
                        item.Destroy();
                }
                int test = 0;
                foreach (Player pl in Player.List)
                {
                    if(pl != Player.Get(sender))
                    {
                        if(test == 0)
                        {
                            ClassD.Add(pl);
                            test = 1;
                        }
                        if(test == 1)
                        {
                            Scientist.Add(pl);
                            test = 0;
                        }
                    }
                }
                Player.Get(sender).SetRole(RoleType.Tutorial);
                Player.Get(sender).NoClipEnabled = true;
                foreach(Player pl in ClassD)
                {
                    pl.SetRole(RoleType.ClassD);
                    pl.ClearInventory();
                }
                foreach(Player pl in Scientist)
                {
                    pl.SetRole(RoleType.Scientist);
                    pl.ClearInventory();
                }
                switch (arguments.At(0))
                {
                    case "weapons":
                        response = "<b>Possible weapons:</b> \n - com15 \n - com18 \n - fsp9 \n - crossvec \n - ak \n - epsilon \n - logicer \n - shotgun \n - revolver \n - lasergun";
                        return false;
                    case "com15":
                        foreach(Player pl in ClassD)
                        {
                            pl.Teleport(Door.Get(DoorType.GateA));
                            pl.AddItem(ItemType.ArmorCombat);
                            pl.AddItem(ItemType.GunCOM15);
                            pl.AddAmmo(ItemType.Ammo9x19, 100);
                            pl.AddItem(ItemType.Medkit);
                            pl.AddItem(ItemType.Painkillers);
                        }
                        foreach (Player pl in Scientist)
                        {
                            pl.Teleport(Door.Get(DoorType.GateB));
                            pl.AddItem(ItemType.ArmorCombat);
                            pl.AddItem(ItemType.GunCOM15);
                            pl.AddAmmo(ItemType.Ammo9x19, 100);
                            pl.AddItem(ItemType.Medkit);
                            pl.AddItem(ItemType.Painkillers);
                        }
                        Door.LockAll(9999, DoorLockType.AdminCommand);
                        Cassie.Message("30 29 28 27 26 25 24 23 22 21 20 19 18 17 16 15 14 13 12 11 10 9 8 7 6 5 4 3 2 1 start", false, true, true);
                        Timing.CallDelayed(20f, () =>
                        {
                            Door.UnlockAll();
                            Door.Get(DoorType.CheckpointEntrance).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.GateA).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.GateB).Lock(9999, DoorLockType.AdminCommand);
                        });
                        response = "Faction Wars were successfully started!";
                        return true;
                    case "com18":
                        foreach (Player pl in ClassD)
                        {
                            pl.Teleport(Door.Get(DoorType.GateA));
                            pl.AddItem(ItemType.ArmorCombat);
                            pl.AddItem(ItemType.GunCOM18);
                            pl.AddAmmo(ItemType.Ammo9x19, 120);
                            pl.AddItem(ItemType.Medkit);
                            pl.AddItem(ItemType.SCP500);
                        }
                        foreach (Player pl in Scientist)
                        {
                            pl.Teleport(Door.Get(DoorType.GateB));
                            pl.AddItem(ItemType.ArmorCombat);
                            pl.AddItem(ItemType.GunCOM18);
                            pl.AddAmmo(ItemType.Ammo9x19, 120);
                            pl.AddItem(ItemType.Medkit);
                            pl.AddItem(ItemType.SCP500);
                        }
                        Door.LockAll(9999, DoorLockType.AdminCommand);
                        Cassie.Message("30 29 28 27 26 25 24 23 22 21 20 19 18 17 16 15 14 13 12 11 10 9 8 7 6 5 4 3 2 1 start", false, true, true);
                        Timing.CallDelayed(20f, () =>
                        {
                            Door.UnlockAll();
                            Door.Get(DoorType.CheckpointEntrance).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.GateA).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.GateB).Lock(9999, DoorLockType.AdminCommand);
                        });
                        response = "Faction Wars were successfully started!";
                        return true;
                    case "fsp9":
                        foreach (Player pl in ClassD)
                        {
                            pl.Teleport(Door.Get(DoorType.ServersBottom));
                            pl.AddItem(ItemType.ArmorCombat);
                            pl.AddItem(ItemType.GunFSP9);
                            pl.AddAmmo(ItemType.Ammo9x19, 150);
                            pl.AddItem(ItemType.Medkit);
                            pl.AddItem(ItemType.SCP500);
                            pl.AddItem(ItemType.Adrenaline);
                        }
                        foreach (Player pl in Scientist)
                        {
                            pl.Teleport(Door.Get(DoorType.Scp096));
                            pl.AddItem(ItemType.ArmorCombat);
                            pl.AddItem(ItemType.GunFSP9);
                            pl.AddAmmo(ItemType.Ammo9x19, 150);
                            pl.AddItem(ItemType.Medkit);
                            pl.AddItem(ItemType.SCP500);
                            pl.AddItem(ItemType.Adrenaline);
                        }
                        Door.LockAll(9999, DoorLockType.AdminCommand);
                        Cassie.Message("30 29 28 27 26 25 24 23 22 21 20 19 18 17 16 15 14 13 12 11 10 9 8 7 6 5 4 3 2 1 start", false, true, true);
                        Timing.CallDelayed(20f, () =>
                        {
                            Door.UnlockAll();
                            Door.Get(DoorType.HID).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.HczArmory).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.CheckpointLczA).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.CheckpointLczB).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.CheckpointEntrance).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.NukeArmory).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.Scp079First).Lock(9999, DoorLockType.AdminCommand);

                        });
                        response = "Faction Wars were successfully started!";
                        return true;
                    case "crossvec":
                        foreach (Player pl in ClassD)
                        {
                            pl.Teleport(Door.Get(DoorType.ServersBottom));
                            pl.AddItem(ItemType.ArmorCombat);
                            pl.AddItem(ItemType.GunCrossvec);
                            pl.AddAmmo(ItemType.Ammo9x19, 150);
                            pl.AddItem(ItemType.Medkit);
                            pl.AddItem(ItemType.SCP500);
                            pl.AddItem(ItemType.Adrenaline);
                        }
                        foreach (Player pl in Scientist)
                        {
                            pl.Teleport(Door.Get(DoorType.Scp096));
                            pl.AddItem(ItemType.ArmorCombat);
                            pl.AddItem(ItemType.GunCrossvec);
                            pl.AddAmmo(ItemType.Ammo9x19, 150);
                            pl.AddItem(ItemType.Medkit);
                            pl.AddItem(ItemType.SCP500);
                            pl.AddItem(ItemType.Adrenaline);
                        }
                        Door.LockAll(9999, DoorLockType.AdminCommand);
                        Cassie.Message("30 29 28 27 26 25 24 23 22 21 20 19 18 17 16 15 14 13 12 11 10 9 8 7 6 5 4 3 2 1 start", false, true, true);
                        Timing.CallDelayed(20f, () =>
                        {
                            Door.UnlockAll();
                            Door.Get(DoorType.HID).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.HczArmory).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.CheckpointLczA).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.CheckpointLczB).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.CheckpointEntrance).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.NukeArmory).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.Scp079First).Lock(9999, DoorLockType.AdminCommand);

                        });
                        response = "Faction Wars were successfully started!";
                        return true;
                    case "ak":
                        foreach (Player pl in ClassD)
                        {
                            pl.Teleport(Door.Get(DoorType.ServersBottom));
                            pl.AddItem(ItemType.ArmorCombat);
                            pl.AddItem(ItemType.GunAK);
                            pl.AddAmmo(ItemType.Ammo762x39, 150);
                            pl.AddItem(ItemType.Medkit);
                            pl.AddItem(ItemType.SCP500);
                            pl.AddItem(ItemType.Adrenaline);
                        }
                        foreach (Player pl in Scientist)
                        {
                            pl.Teleport(Door.Get(DoorType.Scp096));
                            pl.AddItem(ItemType.ArmorCombat);
                            pl.AddItem(ItemType.GunAK);
                            pl.AddAmmo(ItemType.Ammo762x39, 150);
                            pl.AddItem(ItemType.Medkit);
                            pl.AddItem(ItemType.SCP500);
                            pl.AddItem(ItemType.Adrenaline);
                        }
                        Door.LockAll(9999, DoorLockType.AdminCommand);
                        Cassie.Message("30 29 28 27 26 25 24 23 22 21 20 19 18 17 16 15 14 13 12 11 10 9 8 7 6 5 4 3 2 1 start", false, true, true);
                        Timing.CallDelayed(20f, () =>
                        {
                            Door.UnlockAll();
                            Door.Get(DoorType.HID).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.HczArmory).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.CheckpointLczA).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.CheckpointLczB).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.CheckpointEntrance).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.NukeArmory).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.Scp079First).Lock(9999, DoorLockType.AdminCommand);

                        });
                        response = "Faction Wars were successfully started!";
                        return true;
                    case "epsilon":
                        foreach (Player pl in ClassD)
                        {
                            pl.Teleport(Door.Get(DoorType.ServersBottom));
                            pl.AddItem(ItemType.ArmorCombat);
                            pl.AddItem(ItemType.GunE11SR);
                            pl.AddAmmo(ItemType.Ammo556x45, 150);
                            pl.AddItem(ItemType.Medkit);
                            pl.AddItem(ItemType.SCP500);
                            pl.AddItem(ItemType.Adrenaline);
                        }
                        foreach (Player pl in Scientist)
                        {
                            pl.Teleport(Door.Get(DoorType.Scp096));
                            pl.AddItem(ItemType.ArmorCombat);
                            pl.AddItem(ItemType.GunAK);
                            pl.AddAmmo(ItemType.Ammo556x45, 150);
                            pl.AddItem(ItemType.Medkit);
                            pl.AddItem(ItemType.SCP500);
                            pl.AddItem(ItemType.Adrenaline);
                        }
                        Door.LockAll(9999, DoorLockType.AdminCommand);
                        Cassie.Message("30 29 28 27 26 25 24 23 22 21 20 19 18 17 16 15 14 13 12 11 10 9 8 7 6 5 4 3 2 1 start", false, true, true);
                        Timing.CallDelayed(20f, () =>
                        {
                            Door.UnlockAll();
                            Door.Get(DoorType.HID).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.HczArmory).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.CheckpointLczA).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.CheckpointLczB).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.CheckpointEntrance).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.NukeArmory).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.Scp079First).Lock(9999, DoorLockType.AdminCommand);

                        });
                        response = "Faction Wars were successfully started!";
                        return true;
                    case "logicer":
                        foreach (Player pl in ClassD)
                        {
                            pl.Teleport(Door.Get(DoorType.ServersBottom));
                            pl.AddItem(ItemType.ArmorHeavy);
                            pl.AddItem(ItemType.GunLogicer);
                            pl.AddAmmo(ItemType.Ammo762x39, 200);
                            pl.AddItem(ItemType.Medkit);
                            pl.AddItem(ItemType.SCP500);
                            pl.AddItem(ItemType.SCP500);
                            pl.AddItem(ItemType.Adrenaline);
                        }
                        foreach (Player pl in Scientist)
                        {
                            pl.Teleport(Door.Get(DoorType.Scp096));
                            pl.AddItem(ItemType.ArmorHeavy);
                            pl.AddItem(ItemType.GunLogicer);
                            pl.AddAmmo(ItemType.Ammo762x39, 200);
                            pl.AddItem(ItemType.Medkit);
                            pl.AddItem(ItemType.SCP500);
                            pl.AddItem(ItemType.SCP500);
                            pl.AddItem(ItemType.Adrenaline);
                        }
                        Door.LockAll(9999, DoorLockType.AdminCommand);
                        Cassie.Message("30 29 28 27 26 25 24 23 22 21 20 19 18 17 16 15 14 13 12 11 10 9 8 7 6 5 4 3 2 1 start", false, true, true);
                        Timing.CallDelayed(20f, () =>
                        {
                            Door.UnlockAll();
                            Door.Get(DoorType.HID).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.HczArmory).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.CheckpointLczA).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.CheckpointLczB).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.CheckpointEntrance).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.NukeArmory).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.Scp079First).Lock(9999, DoorLockType.AdminCommand);

                        });
                        response = "Faction Wars were successfully started!";
                        return true;
                    case "shotgun":
                        foreach (Player pl in ClassD)
                        {
                            pl.Teleport(Door.Get(DoorType.GateA));
                            pl.AddItem(ItemType.ArmorHeavy);
                            pl.AddItem(ItemType.GunShotgun);
                            pl.AddAmmo(ItemType.Ammo12gauge, 69);
                            pl.AddItem(ItemType.Medkit);
                            pl.AddItem(ItemType.SCP500);
                            pl.AddItem(ItemType.Adrenaline);
                            pl.AddItem(ItemType.Adrenaline);
                        }
                        foreach (Player pl in Scientist)
                        {
                            pl.Teleport(Door.Get(DoorType.GateB));
                            pl.AddItem(ItemType.ArmorHeavy);
                            pl.AddItem(ItemType.GunShotgun);
                            pl.AddAmmo(ItemType.Ammo12gauge, 69);
                            pl.AddItem(ItemType.Medkit);
                            pl.AddItem(ItemType.SCP500);
                            pl.AddItem(ItemType.Adrenaline);
                            pl.AddItem(ItemType.Adrenaline);
                        }
                        Door.LockAll(9999, DoorLockType.AdminCommand);
                        Cassie.Message("30 29 28 27 26 25 24 23 22 21 20 19 18 17 16 15 14 13 12 11 10 9 8 7 6 5 4 3 2 1 start", false, true, true);
                        Timing.CallDelayed(20f, () =>
                        {
                            Door.UnlockAll();
                            Door.Get(DoorType.CheckpointEntrance).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.GateA).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.GateB).Lock(9999, DoorLockType.AdminCommand);

                        });
                        response = "Faction Wars were successfully started!";
                        return true;
                    case "revolver":
                        foreach (Player pl in ClassD)
                        {
                            pl.Teleport(Door.Get(DoorType.GateA));
                            pl.AddItem(ItemType.ArmorCombat);
                            pl.AddItem(ItemType.GunRevolver);
                            pl.AddAmmo(ItemType.Ammo44cal, 69);
                            pl.AddItem(ItemType.Medkit);
                            pl.AddItem(ItemType.SCP500);
                        }
                        foreach (Player pl in Scientist)
                        {
                            pl.Teleport(Door.Get(DoorType.GateB));
                            pl.AddItem(ItemType.ArmorCombat);
                            pl.AddItem(ItemType.GunRevolver);
                            pl.AddAmmo(ItemType.Ammo44cal, 69);
                            pl.AddItem(ItemType.Medkit);
                            pl.AddItem(ItemType.SCP500);
                        }
                        Door.LockAll(9999, DoorLockType.AdminCommand);
                        Cassie.Message("30 29 28 27 26 25 24 23 22 21 20 19 18 17 16 15 14 13 12 11 10 9 8 7 6 5 4 3 2 1 start", false, true, true);
                        Timing.CallDelayed(20f, () =>
                        {
                            Door.UnlockAll();
                            Door.Get(DoorType.CheckpointEntrance).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.GateA).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.GateB).Lock(9999, DoorLockType.AdminCommand);

                        });
                        response = "Faction Wars were successfully started!";
                        return true;
                    case "lasergun":
                        foreach (Player pl in ClassD)
                        {
                            pl.Teleport(Door.Get(DoorType.GateA));
                            pl.AddItem(ItemType.ParticleDisruptor);
                            pl.AddItem(ItemType.ParticleDisruptor);
                            pl.AddItem(ItemType.ParticleDisruptor);
                            pl.AddItem(ItemType.ParticleDisruptor);
                            pl.AddItem(ItemType.Medkit);
                            pl.AddItem(ItemType.Medkit);
                            pl.AddItem(ItemType.SCP500);
                            pl.AddItem(ItemType.SCP500);
                        }
                        foreach (Player pl in Scientist)
                        {
                            pl.Teleport(Door.Get(DoorType.GateB));
                            pl.AddItem(ItemType.ParticleDisruptor);
                            pl.AddItem(ItemType.ParticleDisruptor);
                            pl.AddItem(ItemType.ParticleDisruptor);
                            pl.AddItem(ItemType.ParticleDisruptor);
                            pl.AddItem(ItemType.Medkit);
                            pl.AddItem(ItemType.Medkit);
                            pl.AddItem(ItemType.SCP500);
                            pl.AddItem(ItemType.SCP500);
                        }
                        Door.LockAll(9999, DoorLockType.AdminCommand);
                        Cassie.Message("30 29 28 27 26 25 24 23 22 21 20 19 18 17 16 15 14 13 12 11 10 9 8 7 6 5 4 3 2 1 start", false, true, true);
                        Timing.CallDelayed(20f, () =>
                        {
                            Door.UnlockAll();
                            Door.Get(DoorType.CheckpointEntrance).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.GateA).Lock(9999, DoorLockType.AdminCommand);
                            Door.Get(DoorType.GateB).Lock(9999, DoorLockType.AdminCommand);

                        });
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
