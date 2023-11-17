# EventTools
<a href="https://github.com/Mikihero/EventTools/releases"><img src="https://img.shields.io/github/downloads/Mikihero/EventTools/total?label=Downloads" alt="Downloads"></a>
  
An SCP:SL EXILED plugin designed to automate several tasks usually done by hand while organizing events.

# **Commands**  
- **EventPrep** - Starts the event by: removing all the items and ragdolls, enabling roundlock, preventing future respawns, forceclassing everyone to class d, forceclassing the command sender to tutorial and enabling noclip for them, locking all the doors in the facility (all of the aformentioned can be configured in the config). Useful for explaining the event and doing other prep-related tasks.  
- **EventExplode** - Teleports everyone to 106 bottom and turns off their god modes, turns off roundlock, and sets off the biggest "firework" in the facility! (it's are a bit loud tho, so be careful whilst using!). A fun way to end an event.  
- **EventCountdown** - Sets off a configurable cassie (by default a 10 to 1 countdown). Useful for starting the event.  
- **LockZone** - Toggles door lock in a specified zone (lcz/hcz/ez/surface/all), if the door was opened then it will be closed too. Useful for preparing the event. 
- **EventNext** - Informs people about an event happening next round by sendning a broadcast and a discord message with the configured role mention.
- **EventNow** - Informs people about an event happening this round by sendning a broadcast and a discord message with the configured role mention. 
- **Lottery** - Spins the lottery wheel displaying the rolled number on the screen and does something different for each number.    
- **Deathmatch** - Starts a deathmatch with a specified weapon and zone(dm weapons to see all weapons, dm zones to see all zones), unlocks all the doors in that zone, then locks doors specified in the config, gives everyone heals (usually SCP-500 and a medkit but it differs depending on the chosen weapon), armor and ammo for the chosen weapon, after 1 minute sends a silent cassie with a countdown and then gives everyone the specified weapon. Best used in combination with the EventPrep command. Also turns on FF at the start if for some reason it was off (why would you turn it off?!).
- **TeamDeathmatch** - Divides everyone (except the command's sender) into 2 teams (ClassD's and Scientists), teleports them into separate rooms, gives them equipment depending on the specified weapon (tdm weapons to see all weapons). Turns off friendly fire and after 30s allows everyone to go out and start killing! (the Particle Disruptor was taken into account and it is given at the end of the countdown unlike other weapons). Also disables the elevators indefinitely. Best used in combination with the EventPrep command.  
- **EventFinish** - Finishes the event by setting certain values to false.  
  
**Most of the above commands have aliases that are shorter of the original command eg. EventEnd == EEnd.**

**Lottery numbers:**  
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
**47-50** - Fakes a cassie announcement (you can still get a christmast MTF tho).  

# **Other Features:**  
- Whenever roundlock is toggled an AC message is sent. 
- If roundlock is enabled for 5 minutes (configurable) then an AC message is sent reminding you about it.

# **Permissions**
- et.roundlockinfo - allows the player to see the broadcast sent whenever RL is toggled or left enabled for 5 minutes.
- et.dm - grants access to the Deathmatch command
- et.elock - grants access to the ElevatorLock command
- et.ecount - grant access to the EventCountdown command
- et.eexplode - grants access to the EventExplode command
- et.efinish - grants access to the EventFinish command
- et.enext - grants access to the EventNext command
- et.enow - grants access to the EventNow command
- et.eprep - grants access to the EvetPrep command
- et.ewin - grants access to the EventWin command
- et.lzone - grants access to the LockZone command
- et.lottery - grants access to the Lottery command
- et.tdm - grants access to the TeamDeathmatch command
- et.tower - grants access to the Tower command

# Default config
```yaml
event_tools:
  # Enables or disables the plugin.
  is_enabled: true
  # Whether or not debug messages should be shown in the console.
  debug: false
  # The message sent when someone enables the RoundLock, can be formatted like a normal SL broadcast.
  r_l_enabled_message: '[<color=#002db3>Event</color><color=#98fb98>Tools</color>] <color=#50c878>RoundLock</color><color=#ffffff> has been </color><color=#00ffff>enabled.</color>'
  # The message sent when someone disables the RoundLock, can be formatted like a normal SL broadcast.
  r_l_disabled_message: '[<color=#002db3>Event</color><color=#98fb98>Tools</color>] <color=#50c878>RoundLock</color><color=#ffffff> has been </color><color=#c50000>disabled.</color>'
  # The message sent in AdminChat as a reminder that roundlock is still enabled, can be formatted like a normal SL broadcast.
  r_l_still_enabled: '[<color=#002db3>Event</color><color=#98fb98>Tools</color>] <color=#ffffff> A quick reminder that </color><color=#50c878>RoundLock</color><color=#ffffff> is still </color><color=#00ffff>enabled.</color>'
  # The amount of time that if round lock is left enabled for, will send a broadcast to permissioned people. Default: 300
  r_l_reminder_time: 300
  # Whether or not the EventPrep command should cleanup ragdolls and items. Default: true
  e_p_cleanup: true
  # Whether or not the EventPrep command should enable roundlock. Default: true
  e_p_round_lock: true
  # Whether or not respawns of CI and MTF should be prevented while an event is haoppening.
  prevent_respawns: true
  # Whether or not the person executing the EventPrep command should be forceclassed to tutorial. Default: true
  e_p_f_c_to_tutorial: true
  # Whether or not the EventPrep command should close all doors in the facility. Default: true
  e_p_close_doors: true
  # Whether or not the EventPrep command should lock Class D cell doors. Default: true
  e_p_lock_class_d: true
  # Whether or not the person using the EventPrep command should have their noclip enabled. Default: true
  e_p_enable_noclip: true
  # Whether or not everyone except the person executing the EventPrep command should be forceclassed to Class D. Default: true
  e_p_force_class_everyone: true
  # Whether or not the EventPrep command should disable LCZ Decontamination. Default: true
  e_p_disable_decont: true
  # The message sent using CASSIE with the EventCountdown command.
  e_c_cassie_message: 10 9 8 7 6 5 4 3 2 1 start
  # Whether or not the CASSIE message for the EventCountdown command should have subtitles. Default: true
  e_c_subtitles: true
  # Server name included in the webhook message sent via the EventNext and EventNow commands.
  server_name: MyServer 1
  # The broadcast to be sent when using the EventNext command. Variables: EVENTNAME
  e_next_b_c: >-
    <size=40><b><color=#cc9900>In the next round there will be an event:

    </color></b></size><size=50><b><color=#ff0000>{EVENTNAME}</color></b></size>
  # Whether or not the EventNext command should send a message to discord. Default: false.
  e_next_send_to_discord: false
  # The message to be sent via a discord webhook when using the EventNext command. Variables: EVENTNAME, SERVERNAME, DISCORDMENTION
  e_next_discord_message: '{DISCORDMENTION} In the next round there will be an event: `{EVENTNAME}` on the server: `{SERVERNAME}`'
  # Discord ID of the role to mention when using the EventNext command.
  e_next_discord_role_i_d: ''
  # Name of the Discord Webhook used in the EventNext command
  e_next_webhook_name: EventNotifier
  # The Discord Webhook URL used in the EventNext command.
  e_next_discord_webhook_u_r_l: ''
  # The avatar Discord Webhook's avatar URL for the EventNext command.
  e_next_webhook_avatar_u_r_l: https://media.giphy.com/media/jzKb8n8n2GC6s0cUB1/giphy.gif
  # The message to be broadcast when using the EventNow command. Variables: EVENTNAME
  e_now_b_c: >-
    <size=40><b><color=#cc9900>Event:

    </color></b></size> <size=50><b><color=#ff0000>{EVENTNAME}</color></b></size>
  # Whether or not the EventNow command should send a message to discord. Default: false.
  e_now_send_to_discord: false
  # The message to be sent via a discord webhook when using the EventNow command. Variables: EVENTNAME, SERVERNAME, DISCORDMENTION
  e_now_discord_message: '{DISCORDMENTION} An event is happening this round: `{EVENTNAME}` on the server: `{SERVERNAME}`'
  # Discord ID of the role that should be pinged when using the EventNow command.
  e_now_discord_role_i_d: ''
  # Name of the Discord Webhook used in the EventNow command.
  e_now_webhook_name: EventNotifier
  # The Discord Webhook URL used in the EventNow command.
  e_now_discord_webhook_u_r_l: ''
  # The avatar Discord Webhook's avatar URL for the EventNow command.
  e_now_webhook_avatar_u_r_l: https://media.giphy.com/media/jzKb8n8n2GC6s0cUB1/giphy.gif
  # The broadcast to be sent whenever the lottery command is used. Variables: NUMBER
  lottery_broadcast: <color=#b00b69><b><size=60>{NUMBER}</size></b></color>
  # Whether or not the EventWin command should forceclass everyone except you and your target to spectator. Default: false
  e_w_f_c_everyone_to_spectator: false
  # Whether or not the FactionWars command should disable friendly fire. Default: true.
  t_d_m_disaable_f_f: true
  # The doors to lock for a deathmatch happening in LCZ.
  dm_l_c_z_doors:
  - Scp914Gate
  - Scp330Chamber
  - Scp330
  - LczCafe
  - LczWc
  - LczArmory
  - Scp173Bottom
  - GR18Gate
  - CheckpointLczA
  - CheckpointLczB
  # The doors to lock for a deathmatch happening in HCZ.
  dm_h_c_z_doors:
  - CheckpointEzHczA
  - CheckpointEzHczB
  - Scp106Primary
  - Scp106Secondary
  - Scp096
  - Scp079First
  - HczArmory
  - ElevatorNuke
  - ElevatorScp049
  - ElevatorLczA
  - ElevatorLczB
  # The doors to lock for a deathmatch happening in EZ.
  dm_e_z_doors:
  - CheckpointEzHczA
  - CheckpointEzHczB
  - GateA
  - GateB
  - ElevatorGateA
  - ElevatorGateB
  # The doors to lock for a deathmatch happening on the surface.
  dm_surface_doors:
  - EscapePrimary
  - ElevatorGateA
  - ElevatorGateB
```
