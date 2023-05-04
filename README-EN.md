# RevolutionaryHostRoles
## About this 
This mod is based on [TownOfHost](https://github.com/tukasa0001/TownOfHost). <br>
Please do not report bugs that occur in this mod to TownOfHost, as it will cause trouble for both parties.
## change point
Moved Watchers from the Neutral role tab to the Both Factions tab

# Below is a modified README of "TownOfHost", which is the source of Fork.

## About this mod

This mod is unofficial and the developer of Among Us "Innersloth" is not involved in the development of this mod. <br>
Please do not contact us officially regarding any issues with this mod. <br>

## release

Among Us version : **2023.03.28**
**Fork the latest version of TownOfHost [here](https://github.com/tukasa0001/TownOfHost/releases/latest)**


## feature

This mod works just by installing it on the host's client, and works regardless of whether other client mods are installed or not, and regardless of the type of terminal. <br>
Also, unlike mods that use custom servers, there is no need to add servers by editing URLs or files, so players other than the host can enjoy additional roles simply by joining the host's room with RevolutionaryHostRoles. <br>

However, please note that the following restrictions apply. <br>

- If the host is changed due to reasons such as leaving the host in the middle, processing related to additional positions may not work properly.

In addition, if a player other than the host plays with this mod installed, the following changes will be made. <br>

- Display of special position unique start screen
- Display normal victory screen for special roles
- Added setting items
- others

## function
### Hotkeys

#### host only
| Keys | Functions | Scenes where it can be used |
| ------------------- | ---------------------------- | ---------------- |
| `Shift`+`L`+`Enter` | Abandoned village | In-game |
| `Shift`+`M`+`Enter` | End meeting by skipping | In-game |
| `Ctrl`+`N` | Show Current Settings | Lobby & In-Game |
| `Ctrl`+`Shift`+`N` | Show Description of Valid Settings | Lobby & In-Game |
| `C` | Interrupting game start | Counting down |
| `Shift` | Start game immediately | Countdown in progress |
| `Ctrl`+`Right click` | Execute clicked player | Conference screen |

#### MOD CLIENTS ONLY
| Keys | Functions | Scenes where it can be used |
| ----------- | ------------------------------------- --------- ------ |
| `Tab` | Page forward through list of options | Lobby |
| `Ctrl`+`F1` | Output Log to Desktop | Anywhere |
| `F10` | Open AmongUs folder | Anywhere |
| `F11` | Change resolution<br>480x270 → 640x360 → 800x450 → 1280x720 → 1600x900 → 1920x1080 | anywhere |
| `T`+`F5` | Reload custom translation files | anywhere |
| `Alt`+`C` | Copy Current Settings Text | Lobby & In-Game |
| `Ctrl`+`C` | Copy text | Chat |
| `Ctrl`+`V` | Paste Text | Chat |
| `Ctrl`+`X` | Cut text | Chat |
| `↑` | Go back in chat transmission history | Chat |
| `↓` | Retroactive chat history | Chat |

### Chat commands
Chat commands are commands that can be entered and used in chat.

#### host only
| command | function |
| ---------------------------------------- | -------- -------------------------------------------- |
| /winner<br>/win | Show Winner |
| /rename <name><br>/r <name> | Rename |
| /dis <crewmate/impostor> | End match as crewmate/impostor disconnected |
| /messagewait <seconds><br>/mw <seconds> | Sets the number of seconds between messages |
| /help<br>/h | Display command description |
| /help roles <role><br>/help r <role> | show role description |
| /help addons <attribute><br>/help a <attribute> | Show attribute description |
| /help modes <mode><br>/help m <mode> | show mode description |
| /hidename <string><br>/hn <string> | Rename Code Hide |
| /say <string> | announce as host |

#### MOD CLIENTS ONLY
| command | function |
| -------------- | ---------------------------------- - |
| /dump | dump log |
| /version<br>/v | Show all mod client versions |

#### all clients
| command | function |
| ----------------------------- | ------------------- ------- |
| /lastresult<br>/l | Display match results |
| /now<br>/n | Show current settings |
| /now roles<br>/n r | Show current role settings |
| /help now<br>/help n | View descriptions of valid settings |
| /template <Tag><br>/t <Tag> | Display fixed phrase corresponding to tag |
| /myrole<br>/m | View my role description |

### template
This function allows you to send fixed phrases. <br>
You can call it with `/template <tag>` or `/t <tag>`. <br>
To set the template, edit `./RHR_DATA/template.txt` in the same folder as AmongUs.exe. <br>
Separate them with a colon like `tag:content`. <br>
Also, you can break a line by writing `\n` in the sentence like `Tag: You can break \n like this`. <br>

#### special tags
There are special tags that can be sent automatically according to the scene. <br>
Example: `welcome: This room uses TownOfHost. `

| Tag | Scene | Target |
| -------------- |---------------- | ------------------ |
| welcome | When a player enters the room | Players who have entered the room |
| OnMeeting | At Meeting Start | Everyone |
| OnFirstMeeting | At the beginning of the first meeting | Everyone |

#### variable expansion
By describing `{{variable name}}` in the text, the contents of the variable can be expanded at the time of calling. <br>
Example: `roomcode:The room code for this room is {{RoomCode}}`

| variable name | content |
| -------------------- | -------------------------- |
| RoomCode | Room Code |
| PlayerName | host's player name |
| AmongUsVersion | Main Version |
| ModVersion | Mod Version |
| Map | Map name |
| NumEmergencyMeetings | Number of emergency meeting buttons |
| EmergencyCooldown | Emergency Meeting Button Cooldown |
| DiscussionTime | Discussion Time |
| VotingTime | Voting Time |
| PlayerSpeedMod | Player Speed |
| CrewLightMod | Crew Sight |
| ImpostorLightMod | Imposter Vision |
| KillCooldown | Kill Cooldown |
| NumCommonTasks | Number of Common Tasks |
| NumLongTasks | number of long tasks |
| NumShortTasks | number of short tasks |
| Date | Date |
| Time | Time |

### Custom translation files
Users are free to create and use their own translations. <br>
- Open the 'Language' folder created in the Among Us folder.
- Create a file called `{language name}.dat` in the folder.
   - Example: Japanese.dat
   - You can rename `template.dat` or `template_English.dat` and use it.
- Describe like `Before translation: After translation` in the file.
   - Example: Command.rename: Rename a host
   - Refer to `template.dat` for `pre-translation` strings.

You can also reload the translation by pressing `T`+`F5`.

#### List of valid languages

| language name |
|----------|
| English |
| Latam |
| Brazilian |
| Portuguese |
| Korean |
| Dutch |
| Filipino |
| French |
| German |
| Italian |
| Japanese |
| Spanish |
| S Chinese |
| TChinese |
| Irish |

### BAN function
The host can ban players even during the game without requiring other players to vote. <br>
Also, if you ban, that player will not be able to enter the room you host from now on. <br>
Banned players are recorded in `./RHR_DATA/BanList.txt` as `friend code, player name`, and you can remove the ban by deleting the corresponding line. <br>
Even if you block it with a friend, it will automatically ban. <br>

### Kick function
The host can take kicks during the game without requiring other players to vote. <br>

### Name filter
By listing the names you want to ban in `./RHR_DATA/DenyName.txt`, players with matching names will be automatically kicked. <br>
It can be specified by [regular expression](https://weblabo.oscasierra.net/tools/regex/), and it will be judged line by line. <br>

example:
| specified characters | matching name | remarks |
| -------- | ---------------------------------------- ------- | ---------------------------------- |
| Room owner | `Room owner` `MOD Room owner` `Room owner RHR` `MOD Room owner RHR` | Matches if `Room owner` is included |
| ^ Room owner | `Room owner MOD` `Room owner RHR` `Room owner TEST` | If `Room owner` is at the beginning |
| Room owner $ | `MOD room owner` `RHR room owner` `TEST room owner` | Matches if `room owner` is at the end |
| ^ room owner $ | `room owner` | `room owner` exact match |

## director

| Imposter Faction | Crewmate Faction | Third Faction | Others |
| ------------------------------------------------- ------------------- | ----------------------------- | -------------------- --------------------------------------- | --------- |
| [Bounty Hunter] (#BountyHunter Bounty Hunter) | [Bait] (#Bait Bait) | [Arsonist] (#Arsonist Arsonist) | [GM] (#GM) |
| [Evil Tracker](#EvilTracker Evil Tracker) | [Dictator](#Dictator) | [Egoist](#Egoist Egoist) | |
| [Evil Watcher] (#Watcher Watcher) | [Doctor] (#Doctor Doctor) | [Executioner] (#Executioner Executioner) | |
| [Fireworks Craftsman](#FireWorks Fireworks Craftsman) | [Writer](#Lighter Writer) | [Jackal](#Jackal Jackal) | |
| [Mare](#MareMare) | [Mayor](#MayorMayer) | [Jester](#JesterJester) | |
| [Puppeteer] (#Puppeteer Puppeteer) | [Nice Watcher] (#Watcher Watcher) | [Lovers] (#Lovers Lover) | |
| [Serial killer] (#SerialKiller serial killer) | [Sabotage master] (#SabotageMaster sabotage master) | [Opportunist] (#Opportunist opportunist) | |
| [Sniper](#Sniper Sniper) | [Seer](#Seer Seer) | [Terrorist](#Terrorist Terrorist) | |
| [Time Thief](#TimeThief Time Thief) | [Sheriff](#Sheriff Sheriff) | [Schrodinger's Cat](#SchrodingerCat) |
| [Vampire] (#Vampire Vampire) | [Snitch] (#Snitch Snitch) | | | |
| [Warlock] (#Warlock Warlock)| [Speed Booster](#SpeedBooster speed booster) | | |
| [Witch](#Witch Witch) | [Trapper](#Trapper Trapper) | | |
| [Mafia] (#Mafia Mafia) | | | |
| [Madmate](#Madmate Madmate) | | | |
| [Mad Guardian](#MadGuardian Mud Guardian) | | | |
| [Mad Snitch](#MadSnitch Mad Snitch) | | | |
| [Sidekick Madmate](#SidekickMadmate Sidekick Madmate) | | | |

### GM

GM (game master) is an observer position. <br>
The GM has no effect on the game itself and all players know who the GM is. <br>
It is always assigned to a host and is ghosted from the start. <br>

### BountyHunter

Faction: Imposter<br>
Judgment: Imposter<br>

If you kill the displayed target, the next kill cool is very short. <br>
Killing a non-target player will increase your kill cool. <br>
<!- Also in the settings kill cool he should be set to 2.5 seconds. <br>-->
Targets change periodically. <br>

#### setting

| setting name |
| ----------------------------------- |
| Target change time (s) |
| Kill Cool(s) when killing a target |
| Kill cool(s) on non-target kills |

### EvilTracker

Creator : Masami<br>

Faction: Imposter<br>
Judgment: Shapeshifter<br>

Imposter with tracking ability. <br>
An arrow to the impostor is always visible, plus you can follow the one you selected with shapeshift. <br>
Depending on your settings, you can also see a kill flash when the imposter kills. <br>

- The target can be set once per turn/game, and will be marked with a left-pointing white triangle (◁) when it can be set.
- If the transformation destination is an imposter or has already died, the ability will not be consumed.
- Transformation cooldown is fixed at "5 seconds" when targets can be set, and "255 seconds" when targets cannot be set.
- Since the transformation duration is fixed at '1 second', the transformation ability itself can hardly be used.
- Depending on the options, you can nominate a [Sidekick Madmate] (#SidekickMadmate/sidekick madmate).

#### setting

| setting name |
| -------------------------------------- |
| Flash visible when imposter killed |
| Can be retargeted after the meeting |
| During a meeting, view the last location of the tracked object |
| You can nominate a Mad Mate |

### FireWorks

Producer/Inventor: Like this. <br>

Faction: Imposter<br>
Judgment: Shapeshifter<br>

It is a position that can kill a lot by exploding fireworks. <br>
You can set up to 3 fireworks at the timing of the shape shift. <br>
Once all the fireworks have been placed, they will detonate all at once at the time of the shapeshift when the final impostor is reached. <br>
You can't kill until you start setting fireworks and blow them up. <br>
Even if you are caught in the explosion, you will win if you can annihilate it.

#### setting

| setting name |
| -------------- |
| How many fireworks you have |
| Explosion Radius of Fireworks |

### Mare

Author : Kihi,Yurino,Soukun,Shu
Creator: Kihi<br>

Faction: Imposter<br>
Judgment: Imposter<br>

Can't kill except during blackout, but kill cool is halved. <br>
You also gain movement speed only during blackouts, but your name appears in red. <br>

#### setting

| setting name |
|--------------------------|
| Acceleration value of Maer at power failure |
| Maer's Kilcool during a power outage |

### Puppeteer

Faction: Imposter<br>
Judgment: Imposter<br>

Puppeteer kills are canceled and will kill the next player (except Imposters) that comes close to the kill target. <br>
If the target killed the opponent and it was triggered at the moment the target was killed, the effect will be reflected on the target. <br>
You can't do normal kills. <br>

### SerialKiller

Faction: Imposter<br>
Judgment: Shapeshifter<br>

An impostor with a short kill cool in exchange for his own life. <br>
If you kill even once, the suicide timer will start, and if you don't continue to kill by the time, you will commit suicide. <br>

#### setting

| setting name |
| ----------------- |
| Kilcool(s) |
| Seconds to suicide (s) |

### ShapeMaster

> **Warning**
> currently unavailable.

Producer/Inventor: Shu<br>

Faction: Imposter<br>
Judgment: Shapeshifter<br>

The Shapemaster ignores the cooldown after transforming and can transform again. <br>
Normally, he can only transform for 10 seconds, but you can change the duration of the transformation through settings. <br>

#### setting

| setting name |
| --------------------------------- |
|Shape master transformation time (s) |

### Sniper

Producer/Inventor: Like this. <br>

Faction: Imposter<br>
Judgment: Shapeshifter<br>

It is a position that can shoot from a long distance. <br>
Kills targets in an extension line from the shapeshifted point to the unsharpened point. <br>
Crews on the line of fire will hear the sound of gunfire. <br>
You can't normally kill until you cut off the bullet. <br>

Precision shooting mode OFF<BR>
![off](https://user-images.githubusercontent.com/96226646/172194283-5482db76-faab-4185-9898-ac741b132112.png)<br>
Precision shooting mode ON<BR>
![on](https://user-images.githubusercontent.com/96226646/172194317-6c47b711-a870-4ec0-9062-2abbf953418b.png)<br>

#### setting

| setting name |
| -------------- |
| Number of ammunition |
| Precision Shooting Mode |

### TimeThief

Creator: Mii<br>
Author : integral, shu, sou-kun, yurino<br>

Faction: Imposter<br>
Judgment: Imposter<br>

Killing a player reduces meeting time. <br>
If the Time Thief is banished or killed, the lost meeting time will be regained. <br>

#### setting

| setting name |
|------------------------|
| Decreasing meeting time (s) |
| Lower limit of voting time (s) |
| Return stolen time after death |

### Vampire

Faction: Imposter<br>
Judgment: Imposter<br>

It is a role that actually kills after a certain period of time after pressing the kill button. <br>
No teleportation on kill. <br>
Also, if the meeting starts within the set time after pressing the kill button, a kill will occur at that moment. <br>
However, if you kill [Bait](#Bait/Bate), it will be a normal kill and you will be forced to report it. <br>

#### setting

| setting name |
| ----------------- |
| Time to Kill (s) |

### Warlock

Faction: Imposter<br>
Judgment: Shapeshifter<br>

Killing a Warlock before he transforms will curse the opponent. <br>
And the next time you transform, kill the person closest to the person who cursed you. <br>
A successful curse kill or a meeting resets the curse.
increase. <br>

### Witch

Faction: Imposter<br>
Judgment: Imposter<br>

A position that allows you to switch between kill mode and spell mode by action, and cast magic on the target by pressing the kill button while in spell mode.<br>
Players who have been enchanted will be marked with a special mark at the meeting, and will die if the witch cannot be exorcised during the meeting. <br>

#### setting

| setting name | |
| -------------------- | ----------------- |
| Mode Change Action | Enter Kill/Vent |

### Mafia

Faction: Imposter<br>
Judgment: Imposter<br>

You cannot kill in the initial state. <br>
Once all non-Mafia Imposters are dead, the Mafia will be able to kill them. <br>
Even if you can't kill, there is a kill button, but you can't kill. <br>

### Tricker

Faction: Imposter<br>
Judgment: Imposter<br>

You can erase players with unique abilities and tricks. <br>
Trick kills can be turned on and off by shapeshifting. <br>
#### setting
| setting name | |
| -------------------- | ----------------- |
| Cooldown (s)
|The number of tricks you can do

### Reloader

Faction: Imposter<br>
Judgment: Imposter<br>

A unique ability, reloading lowers the kill cooldown to a set value. <br>
You can change the number of times and cool time by setting. <br>

#### setting
| setting name | |
| -------------------- | ----------------- |
| Cooldown (s)
|Number of times you can reload
| Kill cool when reloading
### Madmate

Faction: Imposter<br>
Judgment: Engineer<br>
Count: Crew<br>

I belong to the Impostor faction, but Madmate doesn't know who the Impostor is. <br>
I don't even know who Madmate is from the imposter. <br>
You can't kill or sabotage, but you can enter vents. <br>

### MadGuardian

Producer/Inventor: EmptyBottle<br>

Faction: Imposter<br>
Judgment: Crewmate<br>
Count: Crew<br>

I belong to the Imposter faction, but the Mad Guardian does not know who the Imposter is. <br>
I don't even know who the mad guardian is from the imposter. <br>
However, if you complete all your tasks, you will not be killed. <br>
You can't kill, sabotage, or enter a vent. <br>

#### setting

| setting name |
| ---------------------------------- |
| You can find out who your own attempted murderer is |

### MadSnitch

Producer/Inventor: Sokun<br>

Faction: Imposter<br>
Judgment: Crewmate or Engineer<br>
Count: Crew<br>

I belong to the Impostor faction, but Mad Snitch doesn't know who the Impostor is. <br>
I don't even know who the Mad Snitch is from the imposter. <br>
After completing all the tasks, the Mad Snitch will be able to recognize the Impostor. <br>

#### setting

| setting name |
| ---------------------------- |
| Vent can be used |
| Can also be seen from the imposter |
| Number of Tasks in Mad Snitch |

### SidekickMadmate

Producer/Inventor: Tanpopo<br>

Faction: Imposter<br>
Judgment: Position before change<br>
Count: Crew<br>

This position is nominated by the closest player (excluding the imposter camp) when some shapeshifter positions transform. <br>
Positions that can be nominated are Shapeshifter, [Evil Tracker] (#EvilTracker) when the option is enabled, and [Egoist] (#Egoist). <br>
He belongs to the Imposter faction, but Sidekick Madmate doesn't know who the Imposter is. <br>
I don't even know who the sidekick madmate is from the impostor. <br>


In addition, there are common settings for Madmate titles.

| setting name |
| ---------------------------------------------- |
| Mad Mate positions can fix power outages |
| Madmate titles can fix communication problems |
| Madmate titles have imposter visibility |
| You can see the kill flash on Madmate titles |
| You can see where others vote for Madmate positions |
| The cause of death is known to a Mad Mate position |
| Madmate titles take the crew with them when they are exiled |
| Vent cooldown for Madmate titles |
| Maximum time in Vent for Madmate positions |

### Watcher

Faction: Impostor or Crewmate<br>
Judgment: Imposter or Crewmate<br>

Watchers can see who everyone voted for during the meeting. <br>

#### setting

| setting name |
| ------------------------------- |
| Probability of becoming an Evil Watcher (%) |

### Bait

Faction: Crewmate<br>
Judgment: Crewmate<br>

A role that allows you to force the killer to report your corpse when killed. <br>

### Dictator

Producer/Inventor: Sokun<br>

Faction: Crewmate<br>
Judgment: Crewmate<br>

If you vote for someone during the meeting, you can force the meeting to end and hang the vote. <br>
The dictator dies when you vote. <br>

### Doctor

Faction: Crewmate<br>
Judgment: Scientist<br>

The Doctor can tell the cause of a player's death and remotely view their vitals. <br>

#### setting
| setting name |
| ------------ |
| Charging duration |

### Lighter

Faction: Crewmate<br>
Judgment: Crewmate<br>

Completing the task will increase your field of vision and make you immune to the reduced field of view of blackouts. <br>

#### setting

| setting name |
| ------------------------------ |
| Visibility at task completion |
| Disable power failure on task completion |

### Mayor

Faction: Crewmate<br>
Judgment: Crewmate<br>

Mayers have multiple votes that can be grouped into one player or skipped. <br>

#### setting

| setting name |
|--------------------------------|
| Number of additional votes |
| Has a portable button |
| ┗ Number of times the portable button can be used |

### SabotageMaster

Producer/Inventor: EmptyBottle<br>

Faction: Crewmate<br>
Judgment: Crewmate<br>

A sabotage master can fix sabotage faster.
Reactor meltdowns, oxygen jams, and MIRA HQ communication jams can be fixed by fixing one. <br>
Power outages are all fixed when he touches one lever. <br>
Opening the doors in Polus or The Airship will open all doors in that room. <br>

#### setting

| setting name |
| ---------------------------------------- |
| Number of times repair ability can be used (excluding door closing) |
| Multiple doors can be opened at once |
| Can use abilities against reactors |
| Can use ability against oxygen interference |
| You can use your abilities against MIRA HQ's communication jamming |
| Ability can be used against blackouts |

### Seer

Creator : Masami<br>

Faction: Crewmate<br>
Judgment: Crewmate<br>

You can see when the player died. <br>
Visibility drops to 0 for a moment, and the reactor also sounds for a moment if it's not in reactor sabotage (kill flash). <br>
The host will get a red screen and a kill sound. <br>
Kill flash length can be fine-tuned in common settings (recommended: 0.3s~). <br>

#### setting

| Common Settings |
| ----------------------- |
| Kill flash length (s) |

### Sheriff

Faction: Crewmate<br>
Judgment: Impostor (host only crewmate)<br>
Count: Crew<br>

Sheriffs can kill inhumans. <br>
However, if he kills a Crewmate, he will die himself. <br>
No tasks. <br>

*For blackout countermeasures, only the person himself can see the motion of committing suicide after death at each meeting. No corpse appears. <br>

#### setting

| setting name |
| ------------------------------------------------- ----------------------------------------- |
| Kilcool|
| In the event of an accidental detonation, the target also dies |
| Number of possible kills |
| Can be killed when everyone is alive |
| Can kill [Madmate](#Madmate) |
| You can kill the third faction |
| ┣ Can kill [Arsonist](#Arsonist) |
| ┣ Can kill [Egoist](#Egoist) |
| ┣ Can kill [Schrodinger's Cat](#SchrodingerCat) (Egoist faction) |
| ┣ Can kill [Jester](#Jester) |
| ┣ Can kill [Opportunist](#Opportunist) |
| ┣ Can kill [terrorist](#Terrorist/terrorist) |
| ┣ Can kill [Executioner](#Executioner/Executioner) |
| ┣ Can kill [Jackal](#Jackal) |
| ┗ [Schrodinger's Cat](#SchrodingerCat) (Jackal camp) can be killed |

### Snitch

Faction: Crewmate<br>
Judgment: Crewmate<br>

The Snitch will change the color of the name of the killable non-human when the task is completed, and the direction will be indicated by the arrow. <br>
But when the Snitch runs low on tasks, the outsider is notified.

#### setting

| setting name |
| -------------------------------------------- |
| You can see the arrow pointing to the target |
| The color of the arrow indicates the faction |
| You can find killable positions for the third faction |

### SpeedBooster

Producer/Inventor: Yoking<br>

Faction: Crewmate<br>
Judgment: Crewmate<br>

Increases the speed of a random surviving player after completing a specified amount of tasks. <br>

#### setting

| setting name |
| ---------------------- |
| acceleration value |
| number of tasks to activate the effect |

### Trapper

Creator: Host Running<br>
Producer: Sokun<br>

Faction: Crewmate<br>
Judgment: Crewmate<br>

When killed, immobilizes the killer for a few seconds. <br>
Also, if you report while restrained, it will be canceled and the report will be done after release. <br>

#### setting

| setting name |
|----------------|
| Time to lock down movement |

### Incender

Faction: Crewmate<br>
Judgment: Crewmate<br>

Unlike Bait, Incenders will have meetings on "themselves" when killed.

### Arsonist

Faction: Third (Single)<br>
Judgment: Imposter<br>
Count: Crew<br>
Victory Condition: Apply oil to all survivors.

If you press the kill button and stay nearby for a certain amount of time, you can apply oil to your opponent. <br>
Apply oil to all survivors and enter the vent to win alone. Otherwise you will lose. <br>

*As a countermeasure against blackout, after death, only the person himself can see the motion of killing himself at each meeting. No corpse appears. <br>

#### setting

| setting name |
| ------------ |
| Coating time |
| Cooldown |

### Egoist

Creator: Shu<br>
Producer: Sokun<br>

Faction: Third (Egoist)<br>
Judgment: Shapeshifter<br>
Count: Imposter<br>
Victory Condition: After the imposter is annihilated, fulfill the victory condition of the imposter<br>

The imposter recognizes the egoist. <br>
The egoist also recognizes the imposter. <br>
Imposters and egoists are inseparable. <br>
You win when all other imposters are wiped out. <br>
If the egoist wins, the imposter loses. <br>

The defeat conditions are as follows. <br>

1. The egoist dies<br> 2. Wins an impostor victory with allies remaining<br> 3. Other third faction wins<br>

#### setting

| setting name |
|------------------------|
| Kilcool |
| You can nominate a Mad Mate |

### Executioner

Faction: Third (Single)<br>
Judgment: Crewmate<br>
Count: Crew<br>
Victory Condition: Target must be voted out<br>

The target has a diamond mark that can only be seen from here. <br>
If you banish the person with a diamond in the vote, you will win alone. <br>
If the target is killed, the role changes. <br>
If the target is a Jester, you will win an additional victory. <br>

#### setting

| setting name |
| -------------------------------------- |
| Imposters can also be targeted |
| You can also target third factions that can kill |
| Position that changes after the target is killed |

### Jackal

Creator : EmptyBottle<br>

Faction: Third (Jackal)<br>
Judgment: Imposter<br>
Count: Jackal<br>
Victory Conditions: Eliminate the Imposters and the number of Jackal Teams equals or exceeds the number of Crews<br>

A position for the third-faction Jackal team that wins by eliminating all other players. <br>
No tasks, you can kill Imposters, Crews and 3rd Factions. <br>

Notes<br>
*If certain conditions are met, even if there are people who were banished by voting, it will be displayed as ``No one was banished'' (display only and will be banished)<br>
  It will be displayed like this for the convenience of blackout countermeasures. <br>
* AutoMute will be unmuted when the imposter is hung. <br>

#### setting

| setting name |
|------------------------|
| Kilcool |
| Vent can be used |
| can use sabotage |
| Imposter field of view |

### Jackalfellow

Faction: Third (Jackal)<br>
Judgment: Crew<br>

It's a crew decision, but it's on the Jackal's side. <br>
*So-called Mad Mate Jackal camp version <br>
Vent available, no tasks. One ability can be granted by setting. <br>
You can choose from Madsnitch Watcher, Doctor Sia, <br>
### setting
| setting name |
|------------------------|
|Vent Cooldown
|Jackal can be seen On/Off
|Jackal Fellow Abilities

### Jester

Faction: Third (Single)<br>
Judgment: Crewmate<br>
Count: Crew<br>
Victory Conditions: To be expelled by vote. <br>

A position in the third faction that will win alone when voted out. <br>
You lose if the game ends without being kicked out or if you are killed. <br>

### Opportunist

Faction: Third (Other)<br>
Judgment: Crewmate<br>
Count: Crew<br>
Victory Conditions: Surviving when one side wins. <br>

It is the position of the third faction that will give you an additional victory if you survive at the end of the game. <br>
No tasks. <br>

### SchrodingerCat

Faction: Third (Other)<br>
Judgment: Crewmate<br>
Count: Crew<br>
Victory Conditions: None<br>

By default, it does not have a victory condition, and when the conditions are met, it will have a victory condition for the first time. <br>

1. If you are killed by an imposter, you will prevent the kill and become an imposter camp<br>
2. When killed by the Sheriff, prevent the kill and join the crew camp<br>
3. If killed by the 3rd faction, prevent the kill and become the 3rd faction<br>
4. If you are exiled, your position will not change and you will die without changing the victory conditions<br>
5. If you are killed by a Warlock ability, you will die without changing the victory conditions<br>
6. If you are killed by a suicide type kill (excluding vampires), you will die without changing the victory conditions<br>

Also, there are no tasks common to all Schrödinger's cats.

#### setting

| setting name |
| ------------------------------- |
| You can win with the crew faction before the position change |
| Faction changes when hung |

### Terrorist

Producer/Inventor: EmptyBottle<br>

Faction: Third (Single)<br>
Judgment: Engineer<br>
Count: Crew<br>
Victory Condition: Must die after completing all tasks.and. <br>

A position of the third faction that gives him a sole victory when he dies with all of his own tasks completed. <br>
You lose if you die without completing the task or if the match ends without dying. <br>

## attributes

### LastImpostor

Producer/Inventor: Sokun<br>

Attributes given to the last imposter. <br>
It shortens to the time set by Kilcool. <br>
Not granted to vampires, bounty hunters, and serial killers. <br>

| setting name |
|----------|
| Kilcool |

### Lovers

Producer/Inventor: Yuri<br>

Faction: Third (Lovers)<br>
Judgment : -<br>
count : -<br>
Victory Conditions: The match must end with both lovers alive. At the end of the task of all crews, even if they survive, they will be defeated. <br>

Two of all players will be cast. (duplicated in other positions)<br>
If a position with a Crew faction task becomes a lover, the task is gone. <br>
A heart mark will be attached to each other's name. <br>
If one dies, the other dies as well. <br>
If the lover dies in the vote, the other dies too and becomes a corpse that cannot be reported. <br>

Duplicate job title example: <br>
・ Terrorist Lover: Has a task, and if you die after completing the task, you win as a terrorist. <br>
・Mad Snitch Lover: Has a task, and if you complete the task, you will know the impostor. <br>
・Snitch Lover: No task, impostor remains unknown. <br>
・Sheriff Lover: You can kill imposters as usual. Whether or not you can kill is determined by the original title of the duplicate. (Imposter Koibito can be killed. Crewmate Koibito cannot be killed)<br>
Opportunist Lover: If you survive, you win. <br>
Jester Lover: If Jester Lover is banished, you win as a Jester. Jester Lover loses if Lover is voted out. <br>
Bait Lover: When a lover is killed and the bait lover follows and dies, no report is made. <br>

### Madmate

This attribute is given to crewmates other than Meyer.
Victory conditions are the same as normal Madmate.

### Anti teleporter

After the meeting ends, the action can start from the point where the meeting started.

## DisableDevices

You can disable various devices. <br>

| setting name |
|--------------------------------|
| Disabling Skeld's Device |
| ┣ Disable Admin |
| ┗ Disable camera |
| Deactivate device in Mira HQ |
| ┣ Disable Admin |
| ┗ Disable door log |
| Porous device disable |
| ┣ Disable Admin |
| ┣ Disable Camera |
| ┗ Invalidate Vitals |
| Airship device deactivation |
| ┣ Disable Admin (Cockpit) |
| ┣ Disable Admin (Archive) |
| ┣ Disable Camera |
| ┗ Invalidate Vitals |
| EXCLUSION |
| ┣ Excluding imposters |
| ┣ Excluding Madmate series |
| ┣ Excluding the third faction |
| ┣ Except Crewmates |
| ┗ Except after death |

## SabotageTimeControl

You can change the time limit for some sabotage. <br>

| setting name |
|--------------------------------|
| Sabotage Time Control |
| ┣ Porous Reactor Time Limit |
| ┗ Airship Reactor Time Limit |
## mode

### DisableTasks

Specific tasks can be disabled. <br>

| setting name |
|--------------------------|
| Disable a task |
| ┣ Card task |
| ┣ Infirmary scan task |
| ┣ Vault Tasks |
| ┣ Download Task |
| ┣ Reactor startup task |
| ┗ Breaker Reset Task |

### FallFromLadders

If you go down from a ladder, you will die with a certain probability. <br>

| setting name |
| -------------- |
| FALLING FROM A LADDER |
| ┗ Probability of falling |

### AirShipVariableElectrical

Every turn, the structure of the electrical room door changes. <br>

| setting name |
| ------------------------------ |
| Structural change of electrical room (airship) |

### HideAndSeek

Producer/Inventor: EmptyBottle<br>

#### Crewmate Faction (Blue) Victory Conditions

Complete all tasks. <br>
* Ghost tasks are not counted. <br>

#### Impostor faction (red) victory conditions

Kill all Crewmates. <br>
*Even if the number of Crewmates and Imposters is the same, the match will not end unless all Crewmates are wiped out. <br>

#### Fox (Purple) Victory Conditions

Surviving when any side wins, except the Trolls. <br>

#### Troll (Green) Victory Condition

Being killed by an imposter. <br>

#### Prohibited matter

・Sabotage<br>
・Administrator<br>
・Camera
・Acts of ghosts communicating location information to survivors<br>
- Ambush (because it may make it impossible for crewmates to win the task)<br>

#### Things impossible

・Reporting a dead body<br>
・Emergency meeting button<br>
・Sabotage<br>

#### setting

| setting name |
|--------------------------|
| Allow Door Close |
| Impostor waiting time (seconds) |
| Do not use vents |

### NoGameEnd

#### Crewmate Faction Victory Conditions

None<br>

#### Imposter Faction Victory Conditions

None<br>

#### Prohibited matter

None<br>

#### Things impossible

End of the game except for the host's SHIFT + L + Enter. <br>

This is a mode for debugging where there is no victory judgment. <br>

### RandomSpawn

Randomly change spawn positions. <br>

#### setting

| setting name |
| ------------------------------ |
| Random Spawn |
| ┗ Additional Spawn Location (Airship) |

#### Skeld

![Skeld](Images/The_Skeld_Random_Map.png)

#### Mira HQ

![MiraHQ](Images/Mira_HQ_Random_Map.png)

#### Porous

![Polus](Images/Polus_Random_Map.png)

#### Airship

![AirShip](Images/The_Airship_Random_Map.png)

If `Additional Spawn Locations (Airships)` is OFF, they will only be picked from their original spawn locations.

### RandomMapsMode

Creator: Tsugaru<br>

In this mode, the map changes randomly. <br>

#### setting

| setting name |
| -------------------- |
| Random Map Mode |
| ┣ Added The Skeld |
| ┣ Added MIRA HQ |
| ┣ Add Polus |
| ┗ Added The Airship |

### SyncButtonMode/button count synchronization mode

In this mode, the button counts of all players are synchronized. <br>

#### setting

| setting name |
|------------------------|
| Button Count Synchronization Mode |
| ┗ Total number of times buttons can be used |

### VoteMode

| Setting Name | Description |
| ------------ | ---------------------------------- |
| Voting Mode | |
| ┣ Skip | Default/Suicide/Self-Vote |
| ┣ When no vote | Default/Suicide/Self-vote/Skip |
| ┗ Tie Vote | Default/Exile All/Random Exile |

## OtherSettings


| setting name |
| ------------------------------------ |
| Meeting when everyone is alive |
| ┗ Meeting time when everyone is alive |
| Extra Emergency Button Cooldown |
| ┣ Applicable number of survivors |
| ┗ Additional Cooldowns |
| Hide-and-seek with titles |
| ┗ Standby time |
| Display match results automatically |
| Second line of name |
| Color name mode |
| Cooldown fix at initial spawn |
| Ghosts can see other people's positions |
| Ghosts can see where others vote |
| Exempt the dead man's task |
| Disable Task Win |
| GamesHide Settings |
|Kick players with mods other than RHR|

#### Client settings

## Hide Game Codes

You can hide the lobby code by activating it.

By rewriting `Hide Game Code Name` in the config file (BepInEx\config\com.sansaaaai.revolutinoaryhostroles.cfg), you can display any characters you like when HideCodes is enabled.
You can also change the color of the text as you like by rewriting `Hide Game Code Color`.

## Force Japanese

Enable to force menu to Japanese regardless of language setting.

## Japanese Role Name

By enabling it, you can display job titles in Japanese.
If the client language is set to English, this setting has no meaning unless `Force Japanese` is enabled.

## credit

[Bounty Hunter] (#BountyHunter), [Mafia] (#Mafia), [Vampire] (#Vampire), [Witch] (#Witch), [Bait] (#Bait/ Bait), [Mayor] (#Mayor), [Sheriff] (#Sheriff), [Snitch] (#Snitch), [Lighter] (#Lighter), [Seer] (#Seer/ Thea), [Jackal](#jackal), the source of the idea, and the reference source of how to create the mod : [The Other Roles](https://github.com/TheOtherRolesAU/TheOtherRoles)<br>
[Opportunist](#Opportunist/opportunist), [Watcher](#Watcher/watcher) idea source: [The Other Roles: GM Edition](https://github.com/yukinogatari/TheOtherRoles-GM)<br>
[Schrodinger's Cat](#SchrodingerCat/Schrodinger's Cat), [Evil Tracker](#EvilTracker/Evil Tracker) idea source : [The Other Roles: GM Haoming Edition](https://github.com/haoming37/TheOtherRoles -GM-Haoming)<br>
[Doctor](#Doctor/Doctor) idea source : [Nebula on the Ship](https://github.com/Dolly1016/Nebula)<br>
[Jester](#Jester/Jester)(Teru Teru) and [Madmate](#Madmate/Madmate) idea source: [au.libhalt.net](https://au.libhalt.net)<br>
[Terrorist](#Terrorist/Terrorist)(Trickstar + Joker) : [Foolers Mod](https://github.com/MengTube/Foolers-Mod)<br>
[Lovers](#lovers/lovers) : [Town-Of-Us-R](https://github.com/eDonnes124/Town-Of-Us-R)<br>
Chinese translation : fivefirex, ZeMingOH233<br>
Option tab icon created by Hanami<br>
Csv: Copyright (c) 2015 Steve Hansen [MIT License](https://raw.githubusercontent.com/stevehansen/csv/master/LICENSE)<br>

## Dear TOH Developer
<!--
Listed in chronological order of earliest mention on the developer channel.
- [Template](https://github.com/) ([Twitter](https://twitter.com/))
- [Pages other than Twitter are also possible](https://github.com/) ([Twitter](https://twitter.com/), [TheOtherPages](https://example.com/))
- [OK if nothing is needed](https://github.com/)
Note: Don't forget to add to README-EN.
-->
- [EmptyBottle](https://github.com/tukasa0001) ([Twitter](https://twitter.com/XenonBottle))
- [Tanakarina](https://github.com/tanakanira0118) <!--([Twitter](https://twitter.com/))-->
- [Shu](https://github.com/shu-TownofHost) ([Twitter](https://twitter.com/Shu_kundayo))
- [kihi](https://github.com/Kihi1120) <!--([Twitter](https://twitter.com/))-->
- [TAKU_GG](https://github.com/TAKUGG) ([Twitter](https://twitter.com/TAKUGGYouTube1), [Youtube](https://www.youtube.com/c/TAKUGG))
- [Soukun](https://github.com/soukunsandesu) ([Twitter](https://twitter.com/Soukun_Dev), [Youtube](https://www.youtube.com/channel/UCsCOqxmXBVT- BD_UKaXpUPw))
- [Mii](https://github.com/mii-47) <!--([Twitter](https://twitter.com/))-->
- [Tanpopo](https://github.com/tampopo-dandelion)([Twitter](https://twitter.com/2nomotokaicho), [Youtube](https://www.youtube.com/channel/UC8EwQ5gu -qyxVxek0jZw1Tg), [niconico](https://www.nicovideo.jp/user/124305243))
- [shell. ](https://github.com/kou-hetare) <!--([Twitter](https://twitter.com/))-->
- [Yoking](https://github.com/ykundesu) <!--([Twitter](https://twitter.com/))-->
- [Yuri's](https://github.com/yurinakira) <!--([Twitter](https://twitter.com/))-->
- [Masami](https://github.com/Masami4711) <!--([Twitter](https://twitter.com/))-->