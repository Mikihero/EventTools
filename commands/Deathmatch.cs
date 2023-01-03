using System;
using System.Linq;
using CommandSystem;
using Exiled.API.Features;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using MEC;
using Exiled.Permissions.Extensions;

namespace EventTools.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class Deathmatch : ICommand, IUsageProvider
    {
        public string Command => "Deathmatch";

        public string[] Aliases => new[] { "dm" };

        public string Description => "Starts a Deathmatch";

        public string[] Usage => new[] {"weapon", "zone", "use <b><u>deathmatch weapons</u></b> to see all the weapons", "use <b><u>deathmatch zones</u></b> to see all the zones"};

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
                    if (pl != sender)
                    {
                        pl.AddItem(gun);
                    }
                    else
                    {
                        pl.AddItem(ItemType.GunE11SR);
                        pl.AddItem(ItemType.ArmorHeavy);
                        pl.SetAmmo(AmmoType.Nato556, 200);
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
                        response = "<b>Possible weapons:</b> \n - GunCOM15 \n - GunCOM18 \n - GunCom45 \n - GunFSP9 \n - GunCrossvec \n - GunAK \n - GunE11SR \n - GunLogicer \n - GunShotgun \n - GunRevolver \n - ParticleDisruptor";
                        return false;
                    case "zones":
                        response = "<b>Possible zones:</b> \n - LightContainment \n - HeavyContainment \n - Entrance \n - Surface";
                        return false;
                    default:
                        response = "Incorrect usage.";
                        return false;
                }
            }
            bool weaponParsed = Enum.TryParse(arguments.At(0), true, out ItemType weapon);
            bool zoneParsed = Enum.TryParse(arguments.At(1), true, out ZoneType zone);
            if (!weaponParsed || !weapon.IsWeapon() || !zoneParsed)
            {
                response = "Incorrect usage.";
                return false;
            }
            foreach (Player pl in Player.List)
            {
                if (pl != senderPlr)
                {
                    GiveItems(weapon, pl);
                }
            }
            Door.UnlockAll();
            Server.FriendlyFire = true;
            switch (zone)
            {
                case ZoneType.LightContainment:
                    foreach (Door door in Door.List.Where(x => Plugin.Instance.Config.DmLCZDoors.Contains(x.Type)))
                    {
                        door.ChangeLock(DoorLockType.AdminCommand);
                    }
                    break;
                case ZoneType.HeavyContainment:
                    foreach (Door door in Door.List.Where(x => Plugin.Instance.Config.DmHCZDoors.Contains(x.Type)))
                    {
                        door.ChangeLock(DoorLockType.AdminCommand);
                    }
                    /*foreach (Door door1 in Door.List.Where(x => x.Type == DoorType.ElevatorLczA || x.Type == DoorType.ElevatorLczB || x.Type == DoorType.ElevatorNuke || x.Type == DoorType.ElevatorScp049))
                    {
                        door1.ChangeLock(DoorLockType.AdminCommand);   
                    }*/
                    foreach (Player pl in Player.List)
                    {
                        pl.Teleport(Door.Get(DoorType.HczArmory));
                    }
                    break;
                case ZoneType.Entrance:
                    foreach (Door door in Door.List.Where(x => Plugin.Instance.Config.DmEZDoors.Contains(x.Type)))
                    {
                        door.ChangeLock(DoorLockType.AdminCommand);
                    }
                    foreach (Door door1 in Door.List.Where(x => x.Type == DoorType.ElevatorGateA || x.Type == DoorType.ElevatorGateB))
                    {
                        door1.ChangeLock(DoorLockType.AdminCommand);
                    }

                    foreach (Player pl in Player.List)
                    {
                        pl.Teleport(RoomType.EzShelter);
                    }
                    break;
                case ZoneType.Surface:
                    foreach (Door door in Door.List.Where(x => Plugin.Instance.Config.DmSurfaceDoors.Contains(x.Type)))
                    {
                        door.ChangeLock(DoorLockType.AdminCommand);
                    }
                    foreach (Door door1 in Door.List.Where(x => x.Type == DoorType.ElevatorGateA || x.Type == DoorType.ElevatorGateB))
                    {
                        door1.ChangeLock(DoorLockType.AdminCommand);   
                    }
                    break;
            }
            Timing.CallDelayed(60f, () =>
            {
                CassieAndGun(weapon, senderPlr);
            });
            response = "Deathmatch started successfully.";
            return true;
        }
    }
}