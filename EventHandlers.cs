using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;

namespace EventTools
{
    public class EventHandlers
    {
        public void OnLeft(LeftEventArgs ev)
        {
            Commands.FactionWars.ClassD.Remove(ev.Player); //removes a player from the list of players so that it (hopefully) doesn't do a funny
            Commands.FactionWars.Scientist.Remove(ev.Player);
        }

        public void OnUsingElevator(InteractingElevatorEventArgs ev)
        {
            if(Commands.EventPrep.IsEventActive)
            {
                ev.IsAllowed = false; //prevents the elevators from being used while an Event is happening
            }
        }

        public void OnRoundStart()
        {
            Commands.EventFinish.FriendlyFireState = Server.FriendlyFire; //saves the friendly fire state
        }
    }
}
