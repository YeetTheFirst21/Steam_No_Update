using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;

namespace Steam_no_update
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            foreach (string s in args)
                switch (s)
                {
                    case "-RESET":
                        Properties.Settings.Default.Reset();
                        
                        //im dumb alright lol:
                        //Properties.Settings.Default.initializationOver = false;
                        //Properties.Settings.Default.languagePack = Properties.Settings.Default.defaultLanguagePack;
                        //Properties.Settings.Default.alreadySetGames = new StringCollection();
                        //saveSettingsBoii();
                        break;
                    case "-REMOVEGAMES":
                        Properties.Settings.Default.alreadySetGames = new StringCollection();
                        //saveSettingsBoii();
                        break;/*
                    case "-INITIALIZATION"://I dont fell like making it more complicated than it has 2 be
                        Properties.Settings.Default.initializationOver = false;
                        saveSettingsBoii();
                        break;*/
                    case "-LANGUAGERESET":
                        Properties.Settings.Default.languagePack = Properties.Settings.Default.defaultLanguagePack;
                        //saveSettingsBoii();
                        break;
                }
            Debug.AutoFlush = true;
            Debug.Indent();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //ApplicationConfiguration.Initialize(); This was useful for C# 6.0
            Debug.Indent();
            Debug.Write("importing language settings");
            importedLangPack = Properties.Settings.Default.languagePack;
            Debug.Indent();/*
            if (!Properties.Settings.Default.initializationOver)
            {
                Form2 initialization = new Form2();
                initialization.TopMost = true;
                Debug.WriteLine("Entering initialization, starting Form2");
                Application.Run(initialization);
            }*/
            Debug.Indent();
            Debug.WriteLine("Entering Main, starting Form");
            Debug.Indent();
            Application.Run(new Form1());
            Debug.WriteLine("Exiting Main");
            Debug.Unindent();
        }

        private static StringCollection importedLangPack;

        public static string LanguagePack(int i)
        {
            if (importedLangPack.Count >= i)
            {
                string a = importedLangPack[i];
                if (a != null)
                {
                    a=a.Replace("  ", "\n");// \n doesnt work by itself so i just replace '  ' with new line
                    return a;
                }
            }//else
            return "ERR";
        }
        public static DialogResult BadForceYesNo(string str, bool addForceText)
        {
            return MessageBox.Show(str + (addForceText ? Program.LanguagePack(1) : ""), Program.LanguagePack(2), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }
        public static void Bad(string str)
        {
            MessageBox.Show(str, Program.LanguagePack(2), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void Success(string str)
        {
            MessageBox.Show(str, Program.LanguagePack(3), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void changeLanguagePack()
        {
            using (var fbd = new OpenFileDialog())
            {
                fbd.Filter = "txt files (*.txt)|*.txt";//|All files (*.*)|*.*";
                fbd.Title = Program.LanguagePack(4);
                fbd.FileName = String.Format("{0}_lang_", System.Windows.Forms.Application.ProductVersion);//System.Windows.Forms.Application.ProductVersion);//when this gets longer than 13 chars, it only shows the end
                fbd.InitialDirectory = Properties.Settings.Default.languagePath;
                fbd.RestoreDirectory = true;
                fbd.CheckFileExists = true;
                fbd.ReadOnlyChecked = true;
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    StringCollection newLanguagePack = new System.Collections.Specialized.StringCollection();// { fbd.FileName };//Directory.GetFiles(fbd.SelectedPath);            //File.ReadAllLines(@"");
                    string[] imput = File.ReadAllLines(fbd.FileName);//read all lines returns a string array but our settings use string collection
                    foreach (String s in imput)
                        newLanguagePack
                            .Add(s);
                    if (newLanguagePack.Count >= Properties.Settings.Default.defaultLanguagePack.Count)//want same or more lines, not less
                    {
                        if (newLanguagePack[0].Contains(String.Format("language pack for Steam_no_update {0}", System.Windows.Forms.Application.ProductVersion)))
                        {//Successful confirmation of the file:
                            if (Program.BadForceYesNo(String.Format(LanguagePack(76) , newLanguagePack[0]), false) == DialogResult.No)
                                return;//if selected no, this will cancel it.
                            Properties.Settings.Default.languagePack = newLanguagePack;
                            Properties.Settings.Default.languagePath = fbd.FileName;
                            importedLangPack = Properties.Settings.Default.languagePack;
                            Program.Success(string.Format(Program.LanguagePack(5), Properties.Settings.Default.languagePath));
                        }
                        else
                            Program.Bad(String.Format(Program.LanguagePack(6), "'language pack for Steam_no_update " + System.Windows.Forms.Application.ProductVersion + "'"));
                    }
                    else
                        Program.Bad(String.Format(Program.LanguagePack(7), System.Windows.Forms.Application.ProductVersion));
                }
                else
                    return;//without this it will just get stuck
            }
        }
        public static DialogResult quitTheAppAsAWhole()
        {
            return MessageBox.Show(Program.LanguagePack(8), Program.LanguagePack(9), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        }
        public static void LaunchUrl(string url)
        {
            Process.Start(new ProcessStartInfo(url)
            {
                UseShellExecute = true,
                Verb = "open"
            });
        }
        public static bool CheckFolderPath(string path, string manifestID)
        {
            if (!Directory.Exists(path))
                return false;

            if (!File.Exists(Path.Combine(path, "..", "..", string.Format("appmanifest_{0}.acf", manifestID))))
                return false;

            return true;
        }

        internal static void SearchForGamesAutomatically()
        {
            var games = Game.StringCollectionToGames(Properties.Settings.Default.alreadySetGames);
            string[] alreadyAddedGames = new string[games.Count];
            for (int i = 0; i < games.Count; i++)
            {
                if (!string.IsNullOrEmpty(alreadyAddedGames[i]))
                    alreadyAddedGames[i] = games[i].APPID;
            }
            var registryPaths = new[]{
                @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall",//32-bit registry
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"//64 bit registry
            };
            bool added = false;
            foreach (var registryPath in registryPaths)
                try
                {
                    RegistryKey uninstallers = Registry.LocalMachine.OpenSubKey(registryPath);
                    var programs = uninstallers.GetSubKeyNames();
                foreach (var program in programs)
                {
                    if (program.Contains("Steam App "))
                    {
                        string gameID = program.Substring(10);
                        bool alreadyAdded = false;
                        if(games!=null)
                            foreach (var game in games)
                                if (game.APPID.Equals(gameID))
                                {
                                    alreadyAdded = true;
                                    break;
                                }
                        if (!alreadyAdded)
                        {
                            RegistryKey gameReg = uninstallers.OpenSubKey(program);
                            string gameName = gameReg.GetValue("DisplayName", string.Empty).ToString();
                            if (true)
                            {

                                string installPath = gameReg.GetValue("InstallLocation", string.Empty).ToString();
                                string depotID = getDepotIDOfGame(installPath, gameID);


                                if (!string.IsNullOrEmpty(gameName) && !string.IsNullOrEmpty(gameID) && !string.IsNullOrEmpty(depotID) && !string.IsNullOrEmpty(installPath))
                                {
                                    games.Add(new Game(gameName, gameID, depotID, installPath, null));
                                    added = true;
                                }
                                else
                                    Program.Bad(string.Format(Program.LanguagePack(13), gameName, gameID, depotID, installPath));
                            }
                        }
                    }
                }

            }
            catch(Exception e) { Program.Bad(Program.LanguagePack(14)+"\n\n" +e.Message); }
            if (!added)
                Program.Bad(Program.LanguagePack(15));

            games.Sort();
            Properties.Settings.Default.alreadySetGames = Game.gamesToStringCollection(games);
        }

        private static string getDepotIDOfGame(string installPath, string gameID)
        {
            if(string.IsNullOrEmpty(installPath)||string.IsNullOrEmpty(gameID))
                return string.Empty;
            var p = Path.Combine(installPath, "..", "..", "appmanifest_" + gameID + ".acf");
            List<string> depots = new List<string>();
            var acf = File.ReadAllText(p);
            int depotidPlacement = acf.IndexOf("InstalledDepots\"\n\t{\n\t\t\"") + "InstalledDepots\"\n\t{\n\t\t\"".Length;
            string depotId = "faill";
            try
            {
                depotId = acf.Substring(depotidPlacement);//this string holds all the installed depots with their manifest and other properties//  \"\n\t\t{  this is the ending of each installed depots,  }\n\t\t\"   this is the start of each installed depots

                while (true)
                {
                    string outDepotId = depotId.Substring(0, depotId.IndexOf("\"\n\t\t{\n\t\t\t\"manifest\""));
                    depots.Add(outDepotId);//butun manifest ozelligi olan depotlari al
                    depotId = depotId.Substring(depotId.IndexOf("\"\n\t\t}\n\t\t\"") + "\"\n\t\t}\n\t\t\"".Length);
                }
            }
            catch
            {
                //This is used just to get out of the while loop
            }
            if (depots.Count > 0)
            {
                depotId = String.Empty;
                foreach (var depot in depots)
                    depotId += depot + ",";
            }
            return depotId.Substring(0, depotId.Length - 1);//returns them all with deleting the comma at the end
        }

        /// <summary>
        /// this creates a folder in %userprofile%\appdata\local\Company
        /// </summary>
        public static void saveSettingsBoii(bool apply)
        {
            if (apply)//saves only if u really wanna which will create a file if it already isnt added.
            {
                Properties.Settings.Default.Save();//HOLY SHIT--DO NOT USE THIS BY ITSELF WINDOWS DEFENDER WILL FREAK OUT LOL
                Properties.Settings.Default.Reload();//I LOVE THESE 2 LINES OF CODES
            }
        }
    }
}