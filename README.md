# Steam_no_update

A simple .net core app that was based on Kinsi's 'BeatSaberNoUpdate' that makes Steam think that there is no update necessary for games <br />
Link to his github page:
https://github.com/kinsi55/BeatSaber_UpdateSkipper <br />

<p align="center">
  <img src="tutorial_Images\Ver 1.0.0.0 Main Screen.png">
</p>

# How to use

## 0. After noticing that steam requires an update, you should not start the update, get back to this tool and start following these steps. (If the game was already updated, it is too late to be using this app.)

#### 1. Download the latest version of the exe from :[the releases](https://github.com/YeetTheFirst21/Steam_No_Update/releases)

<p align="center">
  <img src="tutorial_Images\Tutorial01.png">
</p>

#### 2. After launching the .exe, you can either add new games using the green add button to the list, or automatically add them pressing the magnifying glass and confirming the add of the games

<p align="center">
  <img src="tutorial_Images\Tutorial02.png">
</p>

<p align="center">
  <img src="tutorial_Images\Tutorial03.png">
</p>

#### 3. With the games loaded on the right side, you can click on the one you want to stop from updating. Press the Retrieve button after choosing the game and the app will try to load the Manifest ID(s) corresponding to the Depot(s) of the game.

<p align="center">
  <img src="tutorial_Images\Tutorial04.png">
</p>

#### 4. Now you can select if you want to stop Steam from automatically updating this game in order to be able to do the same procedures without having Steam update it behind your back in the future. Check the checkbox 'Disable Autoupdate' if you do not want to manually stop Steam from updating in the future.

<p align="center">
  <img src="tutorial_Images\Tutorial05.png">
</p>

#### 4.1  When 'Choose & Apply'  is pressed for a game with multiple Depots, it will show which Manifest ID(s) of the game have changed and allows you to select which ones to change (automatically selects the ones that have changed). After clicking 'Apply Selected' choosing the Depots that need update, assuming that nothing went wrong and a success message was shown, Steam will no longer want you to update the game and you can start it, also assuming that this game does not connect to an online server that checks the game version.

<p align="center">
  <img src="tutorial_Images\Tutorial05_1.png">
</p>

#### 4.2 When 'Apply'  is pressed for a game with a single Depot, it will change the Manifest ID in the .acf file and assuming that nothing went wrong and a success message was shown, Steam will no longer want you to update the game and you can start it, also assuming that this game does not connect to an online server that checks the game version.

<p align="center">
  <img src="tutorial_Images\Tutorial05_2.png">
</p>

# And how do I actually update the game after using this?

Since Steam thinks you are on the latest version, eventho you are not, obviously your files differ from the ones that should exist for this version, so to actually do the update simply to go the properties of that game in Steam and verify the integrity of the game files. It should just start a download afterwards.

# Properties of buttons with icons:

<p align="center">
  <img src="tutorial_Images\Tutorial06.png">
</p>

#### Left most button (❓)<br />

This button will show you an information regarding what the app does:

<p align="center">
  <img src="tutorial_Images\Tutorial07.png">
</p>

#### Second button from left (🔍)<br />

This button will search for games using the uninstaller data Windows holds (Windows holds the data of the games for when you want to uninstall them and they are acessible via the registry editor):

<p align="center">
  <img src="tutorial_Images\Tutorial08.png">
</p>

#### Third button from left (🌐)<br />

This button will allow you to select a .txt file for changing the language of the app and will hold it in the memory for next time if saved:

<p align="center">
  <img src="tutorial_Images\Tutorial09_1.png">
</p>
<p align="center">
  <img src="tutorial_Images\Tutorial09_2.png">
</p>

#### Fourth button from left (💾)<br />

This button will allow you to create a .config file in your computers files to save the already found games and their update dates and the language pack changes you might have possibly made. Clicking it again after turning on saving will turn it off but not save the files it has created.<br />

You can find them in 'C:\Users\%username%\AppData\Local\YeetTheFirst21' Assuming you have the .exe of this app in your C drive:

<p align="center">
  <img src="tutorial_Images\Tutorial10_1.png">
</p>

<p align="center">
  <img src="tutorial_Images\Tutorial10_2.png">
</p>

#### Second button from right (➕)<br />

This button will allow you to manually add games to the list. To do this, firstly you will need to get the 'APPID' of the game (This can be found on the store link such as : <br />
'https://store.steampowered.com/app/1091500/Cyberpunk_2077/' or the shortcut created by steam will show this id when you hover over it. 1091500 is the APPID of Cyberpunk 2077),

<p align="center">
  <img src="tutorial_Images\Tutorial11_0_shortcut.png">
</p>

secondly you will need to find the installed depots form the .acf file. to do this, you will need to  locate your game download file. Which for me and my copy of Cyberpunk 2077 is : 'C:\Program Files (x86)\Steam\steamapps\common\Cyberpunk 2077',<br />

then open'C:\Program Files (x86)\Steam\steamapps\appmanifest_1091500.acf' by changing '1091500' to the APPID of your game.<br />
Using notepad, you should look for '"InstalledDepots"' and add all the main numbers within its bracket({}). Different games will have different amount of depots so you should either add the only one available or all of the ones with a ',' seperating them.<br />

The input screens will ask you these in order of: Name, appID, depotID, folder location.<br />

The same edit options will also appear if you double click an already existing game from the list to edit it.

<p align="center">
  <img src="tutorial_Images\Tutorial11_1.png">
</p>

<p align="center">
  <img src="tutorial_Images\Tutorial11_2.png">
</p>
<p align="center">
  <img src="tutorial_Images\Tutorial11_2_acfFile.png">
</p>
<p align="center">
  <img src="tutorial_Images\Tutorial11_3.png">
</p>
<p align="center">
  <img src="tutorial_Images\Tutorial11_4.png">
</p>

#### Most right button (➖)<br />

This button will allow you to remove any selected game from the list. as long as a game is added to the list and is selected, this button should remove it from the list.

<br />

# Possible Errors and why they appear:

Auto game add fails: <br />

#### 'Failed to add game automatically from uninstallers: Name:,ID:,Depot:,Path:'<br />

this fail will show up if the uninstaller does not contain all the necessary info. E.g. this happened to me because I installed Rocket League on another device and then moved the files to this computer and made steam check the files, therefore it does not have an uninstaller on this device. <br />

SOLUTION: Just add the failed games manually as explained above if you want to stop Steam from updating them.

<p align="center">
  <img src="tutorial_Images\Tutorial12_gameAdd.png">
</p>

#### 'Automatically retreiving the Manifest ID failed. Copy the latest 'Manifest ID' from the site. Make sure that 'Last update under the 'Creation date' looks correct, to confirm the site has already spotted the update! Open the website?'<br />

This fail will show up if by any reason Steamkit2 (the piece of software that connects to Steam servers) failed to get the latest manifest ID. This is most likely caused by internet issues where the network you are connected to is blocking you from accessing the Steam servers (maybe even bad internet). Other possibility is that the software no longer works as intended with Steam Servers/Steam Servers are down or idk lol im not a god.

<p align="center">
  <img src="tutorial_Images\Tutorial13_Manifest_retrieve_fail.png">
</p>

SOLUTION: Either change your network or to manually add them after clicking 'Yes' which will load all of the necessary pages for the manifests in your default browser. If adding manually, you should order the Manifest IDs with the Depot IDs when applying multiple ones as the app compares at the old manifest IDs of the Depots in the same order.<br />

E.g. for Cyberpunk 2077, if the Depot IDs go 'x,1091501,z', the Manifet IDs should go 'Latest_manifest_for_x,9024153387735370035,Latest_manifest_for_z'.<br />

 Also make sure that the Last Update date is close to current time/later than the last time you updated the game or the Manifest ID might be the same old one and this app might not work.

<p align="center">
  <img src="tutorial_Images\Tutorial13_Manifestt_Online.png">
</p>
