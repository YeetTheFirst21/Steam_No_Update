﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Steam_no_update.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.3.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool initializationOver {
            get {
                return ((bool)(this["initializationOver"]));
            }
            set {
                this["initializationOver"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string languagePath {
            get {
                return ((string)(this["languagePath"]));
            }
            set {
                this["languagePath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Specialized.StringCollection alreadySetGames {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["alreadySetGames"]));
            }
            set {
                this["alreadySetGames"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfString xmlns:xsd=\"http://www.w3." +
            "org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n  <s" +
            "tring>ENGLISH language pack for Steam_no_update 1.0.0.0 //    this line is free " +
            "to use other than putting \'language pack for Steam_no_update 1.0.0.0\' with the v" +
            "ersion of the app anywhere on this line. And will also be shown while changing t" +
            "he language file. Also, if there are any {} with numbers in them, keep them as i" +
            "s while translating, otherwise they will create issues.  Also double spaces are " +
            "new Line/Enter so keep them as is.</string>\r\n  <string> Force Continue?</string>" +
            "\r\n  <string>Error</string>\r\n  <string>Success</string>\r\n  <string>load a languag" +
            "e pack(.txt)</string>\r\n  <string>Successfully changed the language pack to {0}, " +
            "if you save this, you can always reset to default by writing -RESET as an argume" +
            "nt while starting the app or just changing the directory of the .exe as the conf" +
            "igs are for the exes in specific directories</string>\r\n  <string>The file given " +
            "does not contain {0} in the first line</string>\r\n  <string>The file given has le" +
            "ss lines than ({0}) this version ({1}) of the app uses</string>\r\n  <string>NOT U" +
            "SED (NU)</string>\r\n  <string>NU</string>\r\n  <string>NU</string>\r\n  <string>NU</s" +
            "tring>\r\n  <string>NU</string>\r\n  <string>Failed to add game automatically from u" +
            "ninstallers: Name:{0},ID:{1},Depot:{2},Path:{3}</string>\r\n  <string>A game add f" +
            "ailed but not sure why lol im lazy:</string>\r\n  <string>No (New if they have alr" +
            "eady been added) Steam game was found!</string>\r\n  <string>Select which game to " +
            "stop updating, double click to edit its properties</string>\r\n  <string>Select wh" +
            "ich Manifests to change</string>\r\n  <string>The last time this game was stopped " +
            "from being updated</string>\r\n  <string>Link to the original Creator Website</str" +
            "ing>\r\n  <string>Link to the modifier Github page</string>\r\n  <string>Link to the" +
            " website used for the Icons</string>\r\n  <string>Apply The Depot ManifestID Chang" +
            "e</string>\r\n  <string>Find the folder the game files are located in</string>\r\n  " +
            "<string>Click to get the corresponding manifest(s) to the depot id(s) from Steam" +
            "</string>\r\n  <string>Click to get information regarding the app</string>\r\n  <str" +
            "ing>Click to search for games automatically</string>\r\n  <string>Click to save th" +
            "e added games to your local files--THIS WILL CREATE FOLDERS AND A FILE-BE AWARE!" +
            "</string>\r\n  <string>Add a new game</string>\r\n  <string>Remove the selected game" +
            "</string>\r\n  <string>{0} install Folder:</string>\r\n  <string>Latest {0} Manifest" +
            " ID(s)</string>\r\n  <string>Select All</string>\r\n  <string>De/Select all choices<" +
            "/string>\r\n  <string>Choose the folder where the game is under the Steam\\steamapp" +
            "s\\common folder</string>\r\n  <string>It seems like the Folder you selected is inc" +
            "orrect. You can go to the properties of the game in Steam and click on \'Browse G" +
            "ame files\' for an easy method to get the correct path</string>\r\n  <string>Steam " +
            "seems to be running, please exit it to apply the patch</string>\r\n  <string>The M" +
            "anifest ID you entered is incorrect. It should be a long number with somwhere be" +
            "tween 15 and 20 digits (i hope). Make sure to not accidently enter any spaces</s" +
            "tring>\r\n  <string>Seems like this update is already applied. I\'ll apply it again" +
            " for good measure</string>\r\n  <string>There aren\'t the same number of Manifests " +
            "to correspond with all of the Depots</string>\r\n  <string>The manifests box has l" +
            "etters in it which is not right!</string>\r\n  <string>Click again without selecti" +
            "ng anything to cancel</string>\r\n  <string>Only turned off auto update</string>\r\n" +
            "  <string>No change applied!</string>\r\n  <string>Apply The Depot ManifestID Chan" +
            "ge</string>\r\n  <string>Patch applied. Steam might still claim that an update ava" +
            "ilable, but it should not actually download anything.  In doubt, create a backup" +
            ".  To actually update your game at a later point, go to the properties of the ga" +
            "me in Steam and verify the game integrity.    **Just simply installing an update" +
            " at a later point without verifying the game integrity will probably break your " +
            "game**</string>\r\n  <string>This tool modifies a config file of Steam to make it " +
            "think that you already have the last version (Indicated by the correct Manifest " +
            "ID) eventho you are not.  You will need to redo this whenever an Update is relea" +
            "sed (Basically whenever Steam prompts you to Update to start the game you use th" +
            "is tool instead to fake that you did update)</string>\r\n  <string>no Depot or App" +
            " Id entered!</string>\r\n  <string>Loading..</string>\r\n  <string>Automatically ret" +
            "reiving the Manifest ID failed. Copy the latest \'Manifest ID\' from the site. Mak" +
            "e sure that \'Last update\' under the \'Creation date\' looks correct, to confirm th" +
            "e site has already spotted the latest update! Open the website?</string>\r\n  <str" +
            "ing>failed retrieving depot {0},</string>\r\n  <string>Retrieve</string>\r\n  <strin" +
            "g>{0} install Folder:</string>\r\n  <string>Latest {0} Manifest ID(s)</string>\r\n  " +
            "<string>Change the name of the game? Press OK to save and edit appID</string>\r\n " +
            " <string>Edit Game Name</string>\r\n  <string>Change the appID of the game? Press " +
            "OK to save and edit depotID</string>\r\n  <string>Edit Game ID</string>\r\n  <string" +
            ">Change the depotID of the game? Press OK to save and edit Installation Path</st" +
            "ring>\r\n  <string>Edit Game depotID</string>\r\n  <string>You can only write number" +
            "s and \',\' to seperate them</string>\r\n  <string>You can only write numbers for AP" +
            "PID</string>\r\n  <string>Choose which ManifestIDs of Depots to Change</string>\r\n " +
            " <string>This will save the current state and create a physical file in </string" +
            ">\r\n  <string>  and will also continue saving untill you press again and cancel o" +
            "r delete the save file    Continue Anyways?</string>\r\n  <string>This will stop a" +
            "utosaving into the file but will NOT delete the file in </string>\r\n  <string>, a" +
            "re you sure?</string>\r\n  <string>Would you like to search for games automaticall" +
            "y?</string>\r\n  <string>Update Never Cancelled</string>\r\n  <string>the following " +
            "game failed to load:{0}  should it be deleted to prevent this same error in the " +
            "future?</string>\r\n  <string>Apply</string>\r\n  <string>Choose &amp; Apply</string" +
            ">\r\n  <string>Apply Selected</string>\r\n  <string>ALL Installed Depots</string>\r\n " +
            " <string>Disable Autoupdate</string>\r\n  <string>Selected Game</string>\r\n  <strin" +
            "g>Are you sure you would like to use this file (No to cancel):   {0}</string>\r\n<" +
            "/ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection defaultLanguagePack {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["defaultLanguagePack"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfString xmlns:xsd=\"http://www.w3." +
            "org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n  <s" +
            "tring>ENGLISH language pack for Steam_no_update 1.0.0.0 //    this line is free " +
            "to use other than putting \'language pack for Steam_no_update 1.0.0.0\' with the v" +
            "ersion of the app anywhere on this line. And will also be shown while changing t" +
            "he language file. Also, if there are any {} with numbers in them, keep them as i" +
            "s while translating, otherwise they will create issues.  Also double spaces are " +
            "new Line/Enter so keep them as is.</string>\r\n  <string> Force Continue?</string>" +
            "\r\n  <string>Error</string>\r\n  <string>Success</string>\r\n  <string>load a languag" +
            "e pack(.txt)</string>\r\n  <string>Successfully changed the language pack to {0}, " +
            "if you save this, you can always reset to default by writing -RESET as an argume" +
            "nt while starting the app or just changing the directory of the .exe as the conf" +
            "igs are for the exes in specific directories</string>\r\n  <string>The file given " +
            "does not contain {0} in the first line</string>\r\n  <string>The file given has le" +
            "ss lines than ({0}) this version ({1}) of the app uses</string>\r\n  <string>NOT U" +
            "SED (NU)</string>\r\n  <string>NU</string>\r\n  <string>NU</string>\r\n  <string>NU</s" +
            "tring>\r\n  <string>NU</string>\r\n  <string>Failed to add game automatically from u" +
            "ninstallers: Name:{0},ID:{1},Depot:{2},Path:{3}</string>\r\n  <string>A game add f" +
            "ailed but not sure why lol im lazy:</string>\r\n  <string>No (New if they have alr" +
            "eady been added) Steam game was found!</string>\r\n  <string>Select which game to " +
            "stop updating, double click to edit its properties</string>\r\n  <string>Select wh" +
            "ich Manifests to change</string>\r\n  <string>The last time this game was stopped " +
            "from being updated</string>\r\n  <string>Link to the original Creator Website</str" +
            "ing>\r\n  <string>Link to the modifier Github page</string>\r\n  <string>Link to the" +
            " website used for the Icons</string>\r\n  <string>Apply The Depot ManifestID Chang" +
            "e</string>\r\n  <string>Find the folder the game files are located in</string>\r\n  " +
            "<string>Click to get the corresponding manifest(s) to the depot id(s) from Steam" +
            "</string>\r\n  <string>Click to get information regarding the app</string>\r\n  <str" +
            "ing>Click to search for games automatically</string>\r\n  <string>Click to save th" +
            "e added games to your local files--THIS WILL CREATE FOLDERS AND A FILE-BE AWARE!" +
            "</string>\r\n  <string>Add a new game</string>\r\n  <string>Remove the selected game" +
            "</string>\r\n  <string>{0} install Folder:</string>\r\n  <string>Latest {0} Manifest" +
            " ID(s)</string>\r\n  <string>Select All</string>\r\n  <string>De/Select all choices<" +
            "/string>\r\n  <string>Choose the folder where the game is under the Steam\\steamapp" +
            "s\\common folder</string>\r\n  <string>It seems like the Folder you selected is inc" +
            "orrect. You can go to the properties of the game in Steam and click on \'Browse G" +
            "ame files\' for an easy method to get the correct path</string>\r\n  <string>Steam " +
            "seems to be running, please exit it to apply the patch</string>\r\n  <string>The M" +
            "anifest ID you entered is incorrect. It should be a long number with somwhere be" +
            "tween 15 and 20 digits (i hope). Make sure to not accidently enter any spaces</s" +
            "tring>\r\n  <string>Seems like this update is already applied. I\'ll apply it again" +
            " for good measure</string>\r\n  <string>There aren\'t the same number of Manifests " +
            "to correspond with all of the Depots</string>\r\n  <string>The manifests box has l" +
            "etters in it which is not right!</string>\r\n  <string>Click again without selecti" +
            "ng anything to cancel</string>\r\n  <string>Only turned off auto update</string>\r\n" +
            "  <string>No change applied!</string>\r\n  <string>Apply The Depot ManifestID Chan" +
            "ge</string>\r\n  <string>Patch applied. Steam might still claim that an update ava" +
            "ilable, but it should not actually download anything.  In doubt, create a backup" +
            ".  To actually update your game at a later point, go to the properties of the ga" +
            "me in Steam and verify the game integrity.    **Just simply installing an update" +
            " at a later point without verifying the game integrity will probably break your " +
            "game**</string>\r\n  <string>This tool modifies a config file of Steam to make it " +
            "think that you already have the last version (Indicated by the correct Manifest " +
            "ID) eventho you are not.  You will need to redo this whenever an Update is relea" +
            "sed (Basically whenever Steam prompts you to Update to start the game you use th" +
            "is tool instead to fake that you did update)</string>\r\n  <string>no Depot or App" +
            " Id entered!</string>\r\n  <string>Loading..</string>\r\n  <string>Automatically ret" +
            "reiving the Manifest ID failed. Copy the latest \'Manifest ID\' from the site. Mak" +
            "e sure that \'Last update\' under the \'Creation date\' looks correct, to confirm th" +
            "e site has already spotted the latest update! Open the website?</string>\r\n  <str" +
            "ing>failed retrieving depot {0},</string>\r\n  <string>Retrieve</string>\r\n  <strin" +
            "g>{0} install Folder:</string>\r\n  <string>Latest {0} Manifest ID(s)</string>\r\n  " +
            "<string>Change the name of the game? Press OK to save and edit appID</string>\r\n " +
            " <string>Edit Game Name</string>\r\n  <string>Change the appID of the game? Press " +
            "OK to save and edit depotID</string>\r\n  <string>Edit Game ID</string>\r\n  <string" +
            ">Change the depotID of the game? Press OK to save and edit Installation Path</st" +
            "ring>\r\n  <string>Edit Game depotID</string>\r\n  <string>You can only write number" +
            "s and \',\' to seperate them</string>\r\n  <string>You can only write numbers for AP" +
            "PID</string>\r\n  <string>Choose which ManifestIDs of Depots to Change</string>\r\n " +
            " <string>This will save the current state and create a physical file in </string" +
            ">\r\n  <string>  and will also continue saving untill you press again and cancel o" +
            "r delete the save file    Continue Anyways?</string>\r\n  <string>This will stop a" +
            "utosaving into the file but will NOT delete the file in </string>\r\n  <string>, a" +
            "re you sure?</string>\r\n  <string>Would you like to search for games automaticall" +
            "y?</string>\r\n  <string>Update Never Cancelled</string>\r\n  <string>the following " +
            "game failed to load:{0}  should it be deleted to prevent this same error in the " +
            "future?</string>\r\n  <string>Apply</string>\r\n  <string>Choose &amp; Apply</string" +
            ">\r\n  <string>Apply Selected</string>\r\n  <string>ALL Installed Depots</string>\r\n " +
            " <string>Disable Autoupdate</string>\r\n  <string>Selected Game</string>\r\n  <strin" +
            "g>Are you sure you would like to use this file (No to cancel):   {0}</string>\r\n<" +
            "/ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection languagePack {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["languagePack"]));
            }
            set {
                this["languagePack"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool SavingTurnedOn {
            get {
                return ((bool)(this["SavingTurnedOn"]));
            }
            set {
                this["SavingTurnedOn"] = value;
            }
        }
    }
}
