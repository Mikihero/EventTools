# EventTools
SCP:SL plugin designed to automate several tasks usually done by hand while organizing events.
This plugin is property of Miki_hero, using it is obviously allowed, if you wish to expand it, incorporate it into your project or use parts of it in any way feel free to do so but do give me credit for my work.

**Commands:**  
- **EventStart** - Starts the event by: removing all the items and ragdolls, enabling roundlock, setting respawn tickets to 1, forceclassing everyone to class d, forceclassing the command sender to tutorial and enabling noclip for them, locking all the doors in the facility. Useful for preparing the event.  
- **EventEnd** - Teleports everyone to 106 bottom, turns off roundlock and god modes and sets off fireworks! (they are a bit loud tho, so be careful whilst using). A fun way to end an event.  
- **EventCountdown** - sets off a silent cassie that counts down slowly from 10 to 1. Useful for starting the event.  
- **LockZone** - Toggles door lock in a specified zone (lcz/hcz/ez/surface/all), if the door was opened then it will be closed too. Useful for preparing the event. 
- **EventNext** - Sends a broadcast informing about an event happening next round.  
- **EventNow** - Sends a broadcast informing about an event happening this round.  
- **Lottery** - Spins the lottery wheel displaying the rolled number on the screen and doing something depending on the number.
**All the numbers:**
**1-3** - Starts/Stops the warhead.  
**4-5** - Spawns a random healing item on everyone's head.  
**6-10** - Turns off lights for 20 seconds.  
**11-14** - Applies a random effect to a random player for 3 seconds.  
**15-16** - Spawns a containment engineer keycard in a random room.  
**17-20** - Nothing for now (I'm out of ideas xD).  
**21-24** - Forces a CI spawn.  
**25-26** - Also nothing.  
**27-30** - Forces an MTF spawn.  
**31-34** - Teleports a random player to Class D spawn or Nuke's armory depending on LCZ's decontamination status.  
**35-36** - Closes and locks a random door.    
**37-40** - Teleports a random player to Gate A/Gate B.  
**41-44** - Locks all the doors for 10 seconds in a pattern of: 10s locked, 10s unlocked. Doors are closed 3 times.  
**45-46** - Teleports everyone to a random room.  
**47-50** - Deep, and I mean **Deep** fakes a cassie announcement (you can still get a christmast MTF tho). I've spent a lot of time on this one and I'm proud of it.  
  
**Other Features:**  
- Whenever roundlock is toggled an adminchat message is sent.  
- Every 5 minutes there is an administrative broadcast reminding you that roundlock is enabled (if it is).  
  
**Pretty much everything you can imagine about the above commands and features can be changed in the config file of your server.**
