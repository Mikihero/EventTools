# EventTools
[![Github All Releases](https://img.shields.io/github/downloads/Mikihero/EventTools/total.svg)]()  
  
An SCP:SL EXILED plugin designed to automate several tasks usually done by hand while organizing events.

### **Commands:**  
- **EventStart** - Starts the event by: removing all the items and ragdolls, enabling roundlock, setting respawn tickets to 1 (not 0 cause SL will spawn ~5 people when tickets are 0), forceclassing everyone to class d, forceclassing the command sender to tutorial and enabling noclip for them, locking all the doors in the facility (all of the aformentioned can be configured in the config). Useful for preparing the event.  
- **EventEnd** - Teleports everyone to 106 bottom and turns off their god modes, turns off roundlock, and sets off the biggest "firework" in the facility! (they are a bit loud tho, so be careful whilst using). A fun way to end an event.  
- **EventCountdown** - Sets off a configurable cassie (by defauly a 10 to 1 countdown). Useful for starting the event.  
- **LockZone** - Toggles door lock in a specified zone (lcz/hcz/ez/surface/all), if the door was opened then it will be closed too. Useful for preparing the event. 
- **EventNext** - Sends a configurable broadcast informing about a specified event happening next round.  
- **EventNow** - Sends a configurable broadcast informing about a specified event happening this round.  
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
**41-44** - Locks and unlocks the doors for 10 seconds in a pattern of: 10s locked, 10s unlocked. Doors are closed 3 times.  
**45-46** - Teleports everyone to a random room.  
**47-50** - Deep, and I mean **Deep** fakes a cassie announcement (you can still get a christmast MTF tho). I've spent a lot of time on this one and I'm proud of it.  
  
- **Deathmatch** - Starts a deathmatch with a specified weapon (com15/com18/fsp9/crossvec/ak/e11/logicer/shotgun/revolver/lasergun), unlocks all the doors in LCZ, then locks doors like: 914, 330, pc room etc., gives everyone heals (usually SCP-500 and a medkit but it differs depending on the chosen weapon), armor and ammo for the chosen weapon, after 1 minute sends a silent cassie with a countdown and then gives everyone the specified weapon. Highly recommended to combine it with the EventStart command since that's the way it was tested and intended to be used.

**Most of the above commands have aliases that are abreviations of the original command eg. EventEnd == EEnd.**

### **Other Features:**  
- Whenever roundlock is toggled an adminchat message is sent.  
- Every 5 minutes (configurable) there is an administrative broadcast reminding you that roundlock is enabled (if it is, if not nothing happens).

### Default config:
```yaml
event_tools:
  # Enables or disables the plugin.
  is_enabled: true
  # The message sent when someone enables the RoundLock, can be formatted like a normal SL broadcast.
  r_l_enabled_message: '[<color=#002db3>Event</color><color=#98fb98>Tools</color>] <color=#50c878>RoundLock</color><color=#ffffff> has been </color><color=#00ffff>enabled.</color>'
  # The message sent when someone disables the RoundLock, can be formatted like a normal SL broadcast.
  r_l_disabled_message: '[<color=#002db3>Event</color><color=#98fb98>Tools</color>] <color=#50c878>RoundLock</color><color=#ffffff> has been </color><color=#c50000>disabled.</color>'
  # The message sent in AdminChat as a reminder that roundlock is still enabled, can be formatted like a normal SL broadcast.
  r_l_still_enabled: '[<color=#002db3>Event</color><color=#98fb98>Tools</color>] <color=#ffffff> A quick reminder that </color><color=#50c878>RoundLock</color><color=#ffffff> is still </color><color=#00ffff>enabled.</color>'
  # The amount of seconds every which the plugin should check if round lock is enabled and send a broadcast accordingly. Default: 300
  r_l_reminder_time: 5
  # Whether or not the EventStart command should cleanup ragdolls. Default: true
  e_s_cleanup_ragdolls: true
  # Whether or not the EventStart command should cleanup items. Default: true
  e_s_cleanup_items: true
  # Whether or not the EventStart command should enable roundlock. Default: true
  e_s_round_lock: true
  # Whether or not the EventStart command should set MTF and CI tickets to 1 (1 not 0 because at 0 tickets SL will still spawn ~5 people). Default: true
  e_s_respawn_tickets: true
  # Whether or not the person executing the EventStart command should be forceclassed to tutorial. Default: true
  e_s_f_c_to_tutorial: true
  # Whether or not the EventStart command should lock all doors in the facility. Default: true
  e_s_lock_all_doors: true
  # Whether or not the person using the EventStart command should have their noclip enabled. Default: true
  e_s_enable_noclip: true
  # Whether or not everyone except for the person executing the EventStart command should be forceclassed Class D. Default: true
  e_s_force_class_everyone: true
  # The message sent using CASSIE with the EventCountdown command.
  e_c_cassie_message: 10 9 8 7 6 5 4 3 2 1 start
  # Whether or not the CASSIE message for the EventCountdown command should have subtitles. Default: true
  e_c_subtitles: true
  # The message to be broadcasted when using the EventNext command, can be formatted like a normal SL broadcast. {EVENTNAME} will be replaced with the name of the event.
  e_next_message: >-
    <size=40><b><color=#cc9900>In the next round there will be an event:

    </color></b></size><size=50><b><color=#ff0000>{EVENTNAME}</color></b></size>
  # The messsage to be broadcasted when using the EventNow command, can be formatted like a normal SL broadcast. {EVENTNAME} will be replaced with the name of the event.
  e_now_message: >-
    <size=40><b><color=#cc9900>Event:

    </color></b></size> <size=50><b><color=#ff0000>{EVENTNAME}</color></b></size>
  # The broadcast to be sent whenever the lottery command is used. [NUMBER] will be replaced with the chosen number.
  lottery_broadcast: <color=#b00b69><b><size=60>[NUMBER]</size></b></color>
  # Whether or not the EventWin command should forceclass everyone except you and your target to spectator. Default: false
  e_w_f_c_everyone_to_spectator: false
```
