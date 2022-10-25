# Steam_no_update
A simple .net core app that was based on Kinsi's 'BeatSaberNoUpdate' that makes Steam think that there is no update necessary for games<br />
Link to his github page:
https://github.com/kinsi55/BeatSaber_UpdateSkipper<br />
This is almost the same readme of his just slightly changed as the UI is similar but still different overall.
<p align="center">
  <img src="Ver 1.0.0.0 Main Screen.png">
</p>

# How to use

## 1. You should disable auto updating of any games either through steam or this tool before there is an update as when an update has already installed, there is no going back. This tool makes Steam think an app is updated if it already isn't

#### 2. Download the latest version of the application from Not yet available as I would like to confirm a few bugs and wait a little as I cannot contact the original author if it is ok for me to use most of his code lol, which is already allowed with MIT licenses but just in case, the following link is for his original for now:[the releases](https://github.com/kinsi55/BeatSaber_UpdateSkipper/releases)

#### 3. Whenever Steam wants you to update a game before launching, you can make use of this to prevent it from actually updating either by automatically detecting all games you have in library or manually adding a new game and entering the install folder(if it cannot automatically get depot(s) and Appid, you will need to add them too)

#### 4. Whenever a game details are up on the display, just press retrieve and press the Apply buttton. If there are multiple depots and manifests, it will show you which ones have changed and you can decide on changin certain manifests of certain depots(green means there is no update, red means it should be changed in order to bypass update):
<p align="center">
  <img src="Ver 1.0.0.0 Multi Depots Screen.png">
</p>

# And how do I actually update the game after using this?

Since Steam thinks you are on the latest version, eventho you are not, obviously your files differ from the ones that should exist for this version, so to actually do the update simply to go the properties of that game in Steam and verify the integrity of the game files. It should just start a download afterwards.
