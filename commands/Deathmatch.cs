using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandSystem;
using Exiled.API.Features;
using Exiled.API.Enums;
using MEC;

namespace EventTools.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class Deathmatch : ICommand, IUsageProvider
    {
        public string Command => "Deathmatch";

        public string[] Aliases => new string[] { "dm" };

        public string Description => "Starts a Deathmatch";

        public string[] Usage { get; set; } = {"weapon", "use <b><u>deathmatch weapons</u></b> to see all the weapons"};

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
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
                        foreach (Player pl in Player.List)
                        {
                            pl.AddItem(ItemType.SCP500);
                            pl.AddItem(ItemType.Medkit);
                            pl.AddAmmo(AmmoType.Nato9, 100);
                            pl.AddItem(ItemType.ArmorCombat);
                        }
                        Door.UnlockAll(ZoneType.LightContainment);
                        Door.Get(DoorType.Scp914Gate).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.Scp330Chamber).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.Scp330).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.LczCafe).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.LczWc).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.LczArmory).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.Scp173Bottom).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.GR18Gate).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.CheckpointLczA).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.CheckpointLczB).Lock(9999, DoorLockType.AdminCommand);
                        Timing.CallDelayed(60f, () =>
                        {
                            Cassie.Message("10 9 8 7 6 5 4 3 2 1 start", false, false, true);
                            Timing.CallDelayed(8f, () =>
                            {
                                foreach (Player pl in Player.List)
                                {
                                    pl.AddItem(ItemType.GunCOM15);
                                }
                            });
                        });
                        response = "Deathmatch successfully started.";
                        return true;
                    case "com18":
                        foreach (Player pl in Player.List)
                        {
                            pl.AddItem(ItemType.SCP500);
                            pl.AddItem(ItemType.Medkit);
                            pl.AddAmmo(AmmoType.Nato9, 120);
                            pl.AddItem(ItemType.ArmorCombat);
                        }
                        Door.UnlockAll(ZoneType.LightContainment);
                        Door.Get(DoorType.Scp914Gate).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.Scp330Chamber).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.Scp330).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.LczCafe).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.LczWc).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.LczArmory).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.Scp173Bottom).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.GR18Gate).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.CheckpointLczA).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.CheckpointLczB).Lock(9999, DoorLockType.AdminCommand);
                        Timing.CallDelayed(60f, () =>
                        {
                            Cassie.Message("10 9 8 7 6 5 4 3 2 1 start", false, false, true);
                            Timing.CallDelayed(8f, () =>
                            {
                                foreach (Player pl in Player.List)
                                {
                                    pl.AddItem(ItemType.GunCOM18);
                                }
                            });
                        });
                        response = "Deathmatch successfully started.";
                        return true;
                    case "fsp9":
                        foreach (Player pl in Player.List)
                        {
                            pl.AddItem(ItemType.SCP500);
                            pl.AddItem(ItemType.Medkit);
                            pl.AddAmmo(AmmoType.Nato9, 200);
                            pl.AddItem(ItemType.ArmorCombat);
                        }
                        Door.UnlockAll(ZoneType.LightContainment);
                        Door.Get(DoorType.Scp914Gate).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.Scp330Chamber).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.Scp330).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.LczCafe).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.LczWc).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.LczArmory).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.Scp173Bottom).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.GR18Gate).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.CheckpointLczA).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.CheckpointLczB).Lock(9999, DoorLockType.AdminCommand);
                        Timing.CallDelayed(60f, () =>
                        {
                            Cassie.Message("10 9 8 7 6 5 4 3 2 1 start", false, false, true);
                            Timing.CallDelayed(8f, () =>
                            {
                                foreach (Player pl in Player.List)
                                {
                                    pl.AddItem(ItemType.GunFSP9);
                                }
                            });
                        });
                        response = "Deathmatch successfully started.";
                        return true;
                    case "crossvec":
                        foreach (Player pl in Player.List)
                        {
                            pl.AddItem(ItemType.SCP500);
                            pl.AddItem(ItemType.Medkit);
                            pl.AddAmmo(AmmoType.Nato9, 200);
                            pl.AddItem(ItemType.ArmorCombat);
                        }
                        Door.UnlockAll(ZoneType.LightContainment);
                        Door.Get(DoorType.Scp914Gate).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.Scp330Chamber).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.Scp330).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.LczCafe).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.LczWc).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.LczArmory).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.Scp173Bottom).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.GR18Gate).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.CheckpointLczA).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.CheckpointLczB).Lock(9999, DoorLockType.AdminCommand);
                        Timing.CallDelayed(60f, () =>
                        {
                            Cassie.Message("10 9 8 7 6 5 4 3 2 1 start", false, false, true);
                            Timing.CallDelayed(8f, () =>
                            {
                                foreach (Player pl in Player.List)
                                {
                                    pl.AddItem(ItemType.GunCrossvec);
                                }
                            });
                        });
                        response = "Deathmatch successfully started.";
                        return true;
                    case "ak":
                        foreach (Player pl in Player.List)
                        {
                            pl.AddItem(ItemType.SCP500);
                            pl.AddItem(ItemType.Medkit);
                            pl.AddAmmo(AmmoType.Nato762, 200);
                            pl.AddItem(ItemType.ArmorHeavy);
                        }
                        Door.UnlockAll(ZoneType.LightContainment);
                        Door.Get(DoorType.Scp914Gate).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.Scp330Chamber).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.Scp330).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.LczCafe).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.LczWc).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.LczArmory).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.Scp173Bottom).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.GR18Gate).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.CheckpointLczA).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.CheckpointLczB).Lock(9999, DoorLockType.AdminCommand);
                        Timing.CallDelayed(60f, () =>
                        {
                            Cassie.Message("10 9 8 7 6 5 4 3 2 1 start", false, false, true);
                            Timing.CallDelayed(8f, () =>
                            {
                                foreach (Player pl in Player.List)
                                {
                                    pl.AddItem(ItemType.GunAK);
                                }
                            });
                        });
                        response = "Deathmatch successfully started.";
                        return true;
                    case "epsilon":
                        foreach (Player pl in Player.List)
                        {
                            pl.AddItem(ItemType.SCP500);
                            pl.AddItem(ItemType.Medkit);
                            pl.AddAmmo(AmmoType.Nato556, 200);
                            pl.AddItem(ItemType.ArmorHeavy);
                        }
                        Door.UnlockAll(ZoneType.LightContainment);
                        Door.Get(DoorType.Scp914Gate).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.Scp330Chamber).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.Scp330).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.LczCafe).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.LczWc).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.LczArmory).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.Scp173Bottom).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.GR18Gate).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.CheckpointLczA).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.CheckpointLczB).Lock(9999, DoorLockType.AdminCommand);
                        Timing.CallDelayed(60f, () =>
                        {
                            Cassie.Message("10 9 8 7 6 5 4 3 2 1 start", false, false, true);
                            Timing.CallDelayed(8f, () =>
                            {
                                foreach (Player pl in Player.List)
                                {
                                    pl.AddItem(ItemType.GunE11SR);
                                }
                            });
                        });
                        response = "Deathmatch successfully started.";
                        return true;
                    case "logicer":
                        foreach (Player pl in Player.List)
                        {
                            pl.AddItem(ItemType.SCP500);
                            pl.AddItem(ItemType.Medkit);
                            pl.AddAmmo(AmmoType.Nato762, 200);
                            pl.AddItem(ItemType.ArmorHeavy);
                        }
                        Door.UnlockAll(ZoneType.LightContainment);
                        Door.Get(DoorType.Scp914Gate).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.Scp330Chamber).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.Scp330).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.LczCafe).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.LczWc).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.LczArmory).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.Scp173Bottom).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.GR18Gate).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.CheckpointLczA).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.CheckpointLczB).Lock(9999, DoorLockType.AdminCommand);
                        Timing.CallDelayed(60f, () =>
                        {
                            Cassie.Message("10 9 8 7 6 5 4 3 2 1 start", false, false, true);
                            Timing.CallDelayed(8f, () =>
                            {
                                foreach (Player pl in Player.List)
                                {
                                    pl.AddItem(ItemType.GunLogicer);
                                }
                            });
                        });
                        response = "Deathmatch successfully started.";
                        return true;
                    case "shotgun":
                        foreach (Player pl in Player.List)
                        {
                            pl.AddItem(ItemType.SCP500);
                            pl.AddItem(ItemType.Medkit);
                            pl.AddAmmo(AmmoType.Ammo12Gauge, 70);
                            pl.AddItem(ItemType.ArmorHeavy);
                        }
                        Door.UnlockAll(ZoneType.LightContainment);
                        Door.Get(DoorType.Scp914Gate).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.Scp330Chamber).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.Scp330).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.LczCafe).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.LczWc).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.LczArmory).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.Scp173Bottom).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.GR18Gate).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.CheckpointLczA).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.CheckpointLczB).Lock(9999, DoorLockType.AdminCommand);
                        Timing.CallDelayed(60f, () =>
                        {
                            Cassie.Message("10 9 8 7 6 5 4 3 2 1 start", false, false, true);
                            Timing.CallDelayed(8f, () =>
                            {
                                foreach (Player pl in Player.List)
                                {
                                    pl.AddItem(ItemType.GunShotgun);
                                }
                            });
                        });
                        response = "Deathmatch successfully started.";
                        return true;
                    case "revolver":
                        foreach (Player pl in Player.List)
                        {
                            pl.AddItem(ItemType.SCP500);
                            pl.AddItem(ItemType.Medkit);
                            pl.AddAmmo(AmmoType.Ammo44Cal, 100);
                            pl.AddItem(ItemType.ArmorHeavy);
                        }
                        Door.UnlockAll(ZoneType.LightContainment);
                        Door.Get(DoorType.Scp914Gate).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.Scp330Chamber).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.Scp330).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.LczCafe).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.LczWc).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.LczArmory).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.Scp173Bottom).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.GR18Gate).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.CheckpointLczA).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.CheckpointLczB).Lock(9999, DoorLockType.AdminCommand);
                        Timing.CallDelayed(60f, () =>
                        {
                            Cassie.Message("10 9 8 7 6 5 4 3 2 1 start", false, false, true);
                            Timing.CallDelayed(8f, () =>
                            {
                                foreach (Player pl in Player.List)
                                {
                                    pl.AddItem(ItemType.GunRevolver);
                                }
                            });
                        });
                        response = "Deathmatch successfully started.";
                        return true;
                    case "lasergun":
                        foreach (Player pl in Player.List)
                        {
                            pl.AddItem(ItemType.SCP500);
                            pl.AddItem(ItemType.SCP500);
                            pl.AddItem(ItemType.Medkit);
                        }
                        Door.UnlockAll(ZoneType.LightContainment);
                        Door.Get(DoorType.Scp914Gate).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.Scp330Chamber).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.Scp330).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.LczCafe).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.LczWc).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.LczArmory).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.Scp173Bottom).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.GR18Gate).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.CheckpointLczA).Lock(9999, DoorLockType.AdminCommand);
                        Door.Get(DoorType.CheckpointLczB).Lock(9999, DoorLockType.AdminCommand);
                        Timing.CallDelayed(60f, () =>
                        {
                            Cassie.Message("10 9 8 7 6 5 4 3 2 1 start", false, false, true);
                            Timing.CallDelayed(8f, () =>
                            {
                                foreach (Player pl in Player.List)
                                {
                                    pl.AddItem(ItemType.ParticleDisruptor);
                                    pl.AddItem(ItemType.ParticleDisruptor);
                                    pl.AddItem(ItemType.ParticleDisruptor);
                                    pl.AddItem(ItemType.ParticleDisruptor);
                                    pl.AddItem(ItemType.ParticleDisruptor);
                                }
                            });
                        });
                        response = "Deathmatch successfully started.";
                        return true;
                    default:
                        response = "Usage: deathmatch com15/com18/fsp9/crossvec/ak/e11/logicer/shotgun/revolver/lasergun";
                        return false;
                }
            }
        }
    }
}
