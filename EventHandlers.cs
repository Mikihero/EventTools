using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;

namespace EventTools
{
    public class EventHandlers
    {
        public void OnLeft(LeftEventArgs ev)
        {
            Commands.TeamDeathmatch.ClassD.Remove(ev.Player); //removes a player from the list of players so that it (hopefully) doesn't do a funny
            Commands.TeamDeathmatch.Scientist.Remove(ev.Player);
        }

        public void OnRespawningTeam(RespawningTeamEventArgs ev)
        {
            if (Commands.EventPrep.IsEventActive && Plugin.Instance.Config.PreventRespawns)
            {
                ev.IsAllowed = false;
            }
        }
        
        public void OnRoundStart()
        {
            Commands.EventFinish.FriendlyFireState = Server.FriendlyFire; //saves the friendly fire state
        }
    }
}
