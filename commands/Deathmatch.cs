using System;
using CommandSystem;
using Exiled.API.Features;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using MEC;
using Exiled.Permissions.Extensions;

namespace EventTools.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class Deathmatch : ICommand, IUsageProvider
    {
        public string Command => "Deathmatch";


        public string[] Aliases => new[] { "dm" };

        public string Description => "Starts a Deathmatch";

        public string[] Usage { get; set; } = {"weapon", "use <b><u>deathmatch weapons</u></b> to see all the weapons"};

        private void SetDoorsAndFF(ZoneType zone) //TODO: add a switch with an option of choosing a zone, use UnityEngine.Random.Range() instead of System.Random.Next(), this applies for the entire project
        {
            Server.FriendlyFire = true;
            switch (zone)
            {
                case ZoneType.LightContainment:
                    Door.UnlockAll(ZoneType.LightContainment);
                    Door.Get(DoorType.Scp914Gate).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.Scp330Chamber).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.Scp330).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.LczCafe).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.LczWc).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.LczArmory).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.Scp173Bottom).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.GR18Gate).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.CheckpointLczA).ChangeLock(DoorLockType.AdminCommand);
                    Door.Get(DoorType.CheckpointLczB).ChangeLock(DoorLockType.AdminCommand);
                    break;
                case ZoneType.HeavyContainment:
                    Door.UnlockAll(ZoneType.HeavyContainment);
                    Door.Get().ChangeLock(DoorLockType.AdminCommand);
                    break;
                case ZoneType.Entrance:
                    break;
                case ZoneType.Surface:
                    break;
            }
        }

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
                        pl.AddItem(ItemType.ArmorCombat);
                        pl.SetAmmo(AmmoType.Nato556, 120);
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
            if (arguments.Count != 1)
            {
                response = "Incorrect usage.";
                return false;
            }
            if(arguments.At(0) == "weapons")
            {
                response = "<b>Possible weapons:</b> \n - com15 \n - com18 \n - com45 \n - fsp9 \n - crossvec \n - ak \n - epsilon \n - logicer \n - shotgun \n - revolver \n - lasergun";
                return false;
            }
            bool parsedCorrectly = Enum.TryParse(arguments.At(0), true, out ItemType weapon);
            if (!parsedCorrectly || !weapon.IsWeapon())
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
            SetDoorsAndFF();
            Timing.CallDelayed(60f, () =>
            {
                CassieAndGun(weapon, senderPlr);
            });
            response = "Deathmatch started successfully.";
            return true;
        }
    }
}