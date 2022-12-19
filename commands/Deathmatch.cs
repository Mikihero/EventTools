using System;
using CommandSystem;
using Exiled.API.Features;
using Exiled.API.Enums;
using MEC;
using Exiled.Permissions.Extensions;
using System.Linq;

namespace EventTools.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class Deathmatch : ICommand, IUsageProvider
    {
        public string Command => "Deathmatch";

        public string[] Aliases => new string[] { "dm" };

        public string Description => "Starts a Deathmatch";

        public string[] Usage { get; set; } = {"weapon", "use <b><u>deathmatch weapons</u></b> to see all the weapons"};

        public void SetDoorsAndFF() //TODO: add a switch with an option of choosing a zone, use UnityEngine.Random.Range() instead of System.Random.Next(), this applies for the entire project
        {
            Server.FriendlyFire = true;
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
        }

        public void GiveItems(ItemType weapon, Player pl)
        {
            switch(weapon)
            {
                case ItemType.GunCOM15:
                    pl.AddItem(ItemType.SCP500);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddAmmo(AmmoType.Nato9, 100);
                    pl.AddItem(ItemType.ArmorCombat);
                    break;
                case ItemType.GunCOM18:
                    pl.AddItem(ItemType.SCP500);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddAmmo(AmmoType.Nato9, 120);
                    pl.AddItem(ItemType.ArmorCombat);
                    break;
                case ItemType.GunFSP9:
                    pl.AddItem(ItemType.SCP500);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddAmmo(AmmoType.Nato9, 200);
                    pl.AddItem(ItemType.ArmorCombat);
                    break;
                case ItemType.GunCrossvec:
                    pl.AddItem(ItemType.SCP500);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddAmmo(AmmoType.Nato9, 200);
                    pl.AddItem(ItemType.ArmorCombat);
                    break;
                case ItemType.GunAK:
                    pl.AddItem(ItemType.SCP500);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddAmmo(AmmoType.Nato762, 200);
                    pl.AddItem(ItemType.ArmorHeavy);
                    break;
                case ItemType.GunE11SR:
                    pl.AddItem(ItemType.SCP500);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddAmmo(AmmoType.Nato556, 200);
                    pl.AddItem(ItemType.ArmorHeavy);
                    break;
                case ItemType.GunLogicer:
                    pl.AddItem(ItemType.SCP500);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddAmmo(AmmoType.Nato762, 200);
                    pl.AddItem(ItemType.ArmorHeavy);
                    break;
                case ItemType.GunShotgun:
                    pl.AddItem(ItemType.SCP500);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddAmmo(AmmoType.Ammo12Gauge, 70);
                    pl.AddItem(ItemType.ArmorHeavy);
                    break;
                case ItemType.GunRevolver:
                    pl.AddItem(ItemType.SCP500);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddAmmo(AmmoType.Ammo44Cal, 100);
                    pl.AddItem(ItemType.ArmorHeavy);
                    break;
                case ItemType.ParticleDisruptor:
                    pl.AddItem(ItemType.SCP500, 2);
                    pl.AddItem(ItemType.Medkit);
                    break;
                default:
                    Log.Info("If you're seeing this, open an issue on github (https://github.com/Mikihero/EventTools). Method: GiveItems");
                    break;
            }
        }

        public void CassieAndGun(ItemType gun, Player sender)
        {
            Cassie.Message("10 9 8 7 6 5 4 3 2 1 start", false, false, true);
            Timing.CallDelayed(8f, () =>
            {
                foreach (Player pl in Player.List)
                {
                    if (pl != sender)
                    {
                        pl.AddItem(gun);
                    }
                    else
                    {
                        pl.AddItem(ItemType.GunE11SR);
                        pl.AddItem(ItemType.ArmorCombat);
                        pl.SetAmmo(AmmoType.Nato556, 120);
                    }
                }
            });
        }
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player senderPlr = Player.Get(sender);
            if (!Permissions.CheckPermission(Player.Get(sender), "et.dm"))
            {
                response = "You don't have permission to use this command.";
                return false;
            }
            if (arguments.Count != 1)
            {
                response = "Incorrect usage.";
                return false;
            }
            bool parsedCorrectly = Enum.TryParse(arguments.At(0), true, out Team team);
            switch (arguments.At(0))
            {
                case "weapons":
                    response = "<b>Possible weapons:</b> \n - com15 \n - com18 \n - fsp9 \n - crossvec \n - ak \n - epsilon \n - logicer \n - shotgun \n - revolver \n - lasergun";
                        return false;
                case "com15":
                    foreach (Player pl in Player.List)
                    {
                        if(pl != senderPlr)
                        {                                
                            GiveItems(ItemType.GunCOM15, pl);
                        }
                    }
                    SetDoorsAndFF();
                    Timing.CallDelayed(60f, () =>
                    {
                        CassieAndGun(ItemType.GunCOM15, senderPlr);
                    });
                    response = "Deathmatch successfully started.";
                    return true;
                case "com18":
                    foreach (Player pl in Player.List)
                    {
                        if (pl != senderPlr)
                        {
                            GiveItems(ItemType.GunCOM18, pl);
                        }
                    }
                    SetDoorsAndFF();
                    Timing.CallDelayed(60f, () =>
                    {
                        CassieAndGun(ItemType.GunCOM18, senderPlr);
                    });
                    response = "Deathmatch successfully started.";
                    return true;
                case "fsp9":
                    foreach (Player pl in Player.List)
                    {
                        if (pl != senderPlr)
                        {
                            GiveItems(ItemType.GunFSP9, pl);
                        }
                    }
                    SetDoorsAndFF();
                    Timing.CallDelayed(60f, () =>
                    {
                        CassieAndGun(ItemType.GunFSP9, senderPlr);
                    });
                    response = "Deathmatch successfully started.";
                    return true;
                case "crossvec":
                    foreach (Player pl in Player.List)
                    {
                        if (pl != senderPlr)
                        {
                            GiveItems(ItemType.GunCrossvec, pl);
                        }
                    }
                    SetDoorsAndFF();
                    Timing.CallDelayed(60f, () =>
                    {
                        CassieAndGun(ItemType.GunCrossvec, senderPlr);
                    });
                    response = "Deathmatch successfully started.";
                    return true;
                case "ak":
                    foreach (Player pl in Player.List)
                    {
                        if (pl != senderPlr)
                        {
                            GiveItems(ItemType.GunAK, pl);
                        }
                    }
                    SetDoorsAndFF();
                    Timing.CallDelayed(60f, () =>
                    {
                        CassieAndGun(ItemType.GunAK, senderPlr);
                    });
                    response = "Deathmatch successfully started.";
                    return true;
                case "epsilon":
                    foreach (Player pl in Player.List)
                    {
                        if (pl != senderPlr)
                        {
                            GiveItems(ItemType.GunE11SR, pl);
                        }
                    }
                    SetDoorsAndFF();
                    Timing.CallDelayed(60f, () =>
                    {
                        CassieAndGun(ItemType.GunE11SR, senderPlr);
                    });
                    response = "Deathmatch successfully started.";
                    return true;
                case "logicer":
                    foreach (Player pl in Player.List)
                    {
                        if (pl != senderPlr)
                        {
                            GiveItems(ItemType.GunLogicer, pl);
                        }
                    }
                    SetDoorsAndFF();
                    Timing.CallDelayed(60f, () =>
                    {
                        CassieAndGun(ItemType.GunLogicer, senderPlr);
                    });
                    response = "Deathmatch successfully started.";
                    return true;
                case "shotgun":
                    foreach (Player pl in Player.List)
                    {
                        if (pl != senderPlr)
                        {
                            GiveItems(ItemType.GunShotgun, pl);
                        }
                    }
                    SetDoorsAndFF();
                    Timing.CallDelayed(60f, () =>
                    {
                        CassieAndGun(ItemType.GunShotgun, senderPlr);
                    });
                    response = "Deathmatch successfully started.";
                    return true;
                case "revolver":
                    foreach (Player pl in Player.List)
                    {
                        if (pl != senderPlr)
                        {
                            GiveItems(ItemType.GunRevolver, pl);
                        }
                    }
                    SetDoorsAndFF();
                    Timing.CallDelayed(60f, () =>
                    {
                        CassieAndGun(ItemType.GunRevolver, senderPlr);
                    });
                    response = "Deathmatch successfully started.";
                    return true;
                case "lasergun":
                    foreach (Player pl in Player.List)
                    {
                        if (pl != senderPlr)
                        {
                            GiveItems(ItemType.ParticleDisruptor, pl);
                        }
                    }
                    SetDoorsAndFF();
                    Timing.CallDelayed(60f, () =>
                    {
                        CassieAndGun(ItemType.ParticleDisruptor, senderPlr);
                    });
                    response = "Deathmatch successfully started.";
                    return true;
                default:
                    response = "Incorrect usage.";
                    return false;
            }
        }
    }
}
