using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace EventTools
{
    public class EventHandlers
    {
        public void OnLeft(LeftEventArgs ev)
        {
            Commands.FactionWars.ClassD.Remove(ev.Player);
            Commands.FactionWars.Scientist.Remove(ev.Player);
        }
    }
}
