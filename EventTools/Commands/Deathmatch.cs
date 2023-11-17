using System;
using System.Collections.Generic;
using System.Linq;
using CommandSystem;
using Exiled.API.Features;
using Exiled.API.Enums;
using Exiled.API.Features.Doors;
using MEC;
using Exiled.Permissions.Extensions;

namespace EventTools.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))] //TODO: test if dm in ez works, test if jailbird dm works
    public class Deathmatch : ICommand, IUsageProvider
    {
        public string Command => "Deathmatch";

        public string[] Aliases => new[] { "dm" };

        public string Description => "Starts a Deathmatch";

        public string[] Usage => new[] {"weapon", "zone", "use <b><u>deathmatch weapons</u></b> to see all the weapons", "use <b><u>deathmatch zones</u></b> to see all the zones"};
        
        public Dictionary<string, ZoneType> ZonesDict = new Dictionary<string, ZoneType>
        {
            { "lcz", ZoneType.LightContainment },
            { "hcz", ZoneType.HeavyContainment },
            { "ez", ZoneType.Entrance },
            { "surface", ZoneType.Surface }
        };

        public Dictionary<string, ItemType> WeaponsDict = new Dictionary<string, ItemType>
        {
            { "com15", ItemType.GunCOM15 },
            { "com18", ItemType.GunCOM18 },
            { "com45", ItemType.GunCom45 },
            { "fsp9", ItemType.GunFSP9 },
            { "crossvec", ItemType.GunCrossvec },
            { "ak", ItemType.GunAK },
            { "e11", ItemType.GunE11SR },
            { "epsilon", ItemType.GunE11SR },
            { "logicer", ItemType.GunLogicer },
            { "revolver", ItemType.GunRevolver },
            { "shotgun", ItemType.GunShotgun },
            { "lasergun", ItemType.ParticleDisruptor },
            { "jailbird", ItemType.Jailbird },
            { "hid", ItemType.MicroHID }
        };
        private void GiveItems(ItemType weapon, Player pl)
        {
            switch(weapon)
            {
                case ItemType.GunCOM15:
                    pl.AddItem(ItemType.SCP500);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddItem(ItemType.ArmorCombat);
                    pl.AddAmmo(AmmoType.Nato9, 100);
                    break;
                case ItemType.GunCOM18:
                    pl.AddItem(ItemType.SCP500);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddItem(ItemType.ArmorCombat);
                    pl.AddAmmo(AmmoType.Nato9, 120);
                    break;
                case ItemType.GunCom45:
                    pl.AddItem(ItemType.SCP500, 2);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddItem(ItemType.Adrenaline);
                    pl.AddItem(ItemType.ArmorHeavy);
                    pl.AddAmmo(AmmoType.Nato9, 200);
                    break;
                case ItemType.GunFSP9:
                    pl.AddItem(ItemType.SCP500);
                    pl.AddItem(ItemType.Medkit);
                    pl.AddItem(ItemType.ArmorCombat);
                    pl.AddAmmo(AmmoType.Nato9, 200);
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
                case ItemType.Jailbird:
                    pl.AddItem(ItemType.SCP500);
                    pl.AddItem(ItemType.Medkit, 2);
                    pl.AddItem(ItemType.Adrenaline);
                    break;
                case ItemType.MicroHID:
                    pl.AddItem(ItemType.GrenadeFlash, 3);
                    break;
                default:
                    Log.Info("If you're seeing this, open an issue on github (https://github.com/Mikihero/EventTools). Method: GiveItems");
                    break;
            }
        }

        private void CassieAndGun(ItemType gun, Player sender)
        {
            Cassie.Message("10 9 8 7 6 5 4 3 2 1 start", false, false, true);
            Timing.CallDelayed(8f, () =>
            {
                foreach (Player pl in Player.List)
                {
                    if (pl == sender)
                        continue;
                    switch (gun)
                    {
                        case ItemType.Jailbird:
                            pl.AddItem(ItemType.Jailbird, 4);
                            break;
                        case ItemType.MicroHID:
                            pl.AddItem(ItemType.MicroHID, 4);
                            break;
                        case ItemType.ParticleDisruptor:
                            pl.AddItem(ItemType.ParticleDisruptor, 4);
                            break;
                        default:
                            pl.AddItem(gun);
                            break;
                    }
                }
            });
        }
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player senderPlr = Player.Get(sender);
            if (!Player.Get(sender).CheckPermission("et.dm"))
            {
                response = "You don't have permission to use this command.";
                return false;
            }
            if (arguments.Count < 1)
            {
                response = "Incorrect usage.";
                return false;
            }

            if (arguments.Count == 1)
            {
                switch (arguments.At(0))
                {
                    case "weapons":
                        response = "<b>Possible weapons:</b> \n - com15 \n - com18 \n - com45 \n - fsp9 \n - crossvec \n - ak \n - e11/epsilon \n - logicer \n - shotgun \n - revolver \n - lasergun \n - jailbird \n - hid";
                        return false;
                    case "zones":
                        response = "<b>Possible zones:</b> \n - lcz \n - hcz \n - ez \n - surface";
                        return false;
                    default:
                        response = "Incorrect usage.";
                        return false;
                }
            }
            if (!WeaponsDict.ContainsKey(arguments.At(0)) || !ZonesDict.ContainsKey(arguments.At(1)))
            {
                response = "Incorrect usage.";
                return false;
                
            }
            
            ItemType weapon = WeaponsDict[arguments.At(0)];
            foreach (Player pl in Player.List)
            {
                if (pl != senderPlr)
                {
                    GiveItems(weapon, pl);
                }
            }
            Door.UnlockAll();
            Server.FriendlyFire = true;
            switch (ZonesDict[arguments.At(1)])
            {
                case ZoneType.LightContainment:
                    foreach (Door door in Door.List.Where(x => Plugin.Instance.Config.DmLCZDoors.Contains(x.Type)))
                    {
                        door.ChangeLock(DoorLockType.AdminCommand);
                    }

                    foreach (Player pl in Player.List)
                    {
                        pl.Teleport(Door.Get(DoorType.PrisonDoor));
                    }
                    break;
                case ZoneType.HeavyContainment:
                    foreach (Door door in Door.List.Where(x => Plugin.Instance.Config.DmHCZDoors.Contains(x.Type)))
                    {
                        door.ChangeLock(DoorLockType.AdminCommand);
                    }
                    
                    foreach (Player pl in Player.List)
                    {
                        pl.Teleport(Door.Get(DoorType.Scp939Cryo));
                    }
                    break;
                case ZoneType.Entrance:
                    foreach (Door door in Door.List.Where(x => Plugin.Instance.Config.DmEZDoors.Contains(x.Type)))
                    {
                        door.ChangeLock(DoorLockType.AdminCommand);
                    }

                    Door.Get(DoorType.GateA).IsOpen = true;
                    foreach (Player pl in Player.List)
                    {
                        pl.Teleport(Door.Get(DoorType.GateA));
                    }
                    break;
                case ZoneType.Surface:
                    foreach (Door door in Door.List.Where(x => Plugin.Instance.Config.DmSurfaceDoors.Contains(x.Type)))
                    {
                        door.ChangeLock(DoorLockType.AdminCommand);
                    }

                    foreach (Player pl in Player.List)
                    {
                        pl.Teleport(Door.Get(DoorType.SurfaceGate));
                    }
                    break;
            }
            senderPlr.AddItem(ItemType.GunE11SR);
            senderPlr.AddItem(ItemType.ArmorHeavy);
            senderPlr.SetAmmo(AmmoType.Nato556, 200);
            Timing.CallDelayed(60f, () =>
            {
                CassieAndGun(weapon, senderPlr);
            });
            response = "Deathmatch started successfully.";
            return true;
        }
    }
}