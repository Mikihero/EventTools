using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;

namespace EventTools
{
    public class EventHandlers
    {
        public void OnLeft(LeftEventArgs ev)
        {
            Commands.FactionWars.ClassD.Remove(ev.Player); //removes a player from the list of players so that it (hopefully) doesn't do the funny
            Commands.FactionWars.Scientist.Remove(ev.Player);
        }

        public void OnUsingElevator(InteractingElevatorEventArgs ev)
        {
            if(Commands.FactionWars.IsEventActive)
            {
                ev.IsAllowed = false; //prevents the elevators from being used while the FactionWars event is happening
            }
        }

        public void OnRoundStart()
        {
            Commands.EventFinish.FriendlyFireState = Server.FriendlyFire;
        }
    }
}
