using System.Collections.Generic;
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Reflection;
using System.Threading;

namespace Steam_no_update
{
    public partial class Form1 : Form
    {
        Game selectedGame = new Game(Program.LanguagePack(75), "", "", "", "");// = new Game("Game Name","APPID","DEPOTID","PATH","Last Change Date");
        List<Game> games;
        CheckBox[] forMultipleDepots;

        public Form1()
        {
            InitializeComponent();
            games = Game.StringCollectionToGames(Properties.Settings.Default.alreadySetGames);//uses the initialized list to get the games from preferneces if saved
            games.Add(selectedGame);//Just to show a game in the list
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(buttonLanguage, Program.LanguagePack(4));
            toolTip1.SetToolTip(listBox1, Program.LanguagePack(16));
            toolTip1.SetToolTip(groupBox1, Program.LanguagePack(17));
            toolTip1.SetToolTip(labelLastUpdateCancel, Program.LanguagePack(18));
            toolTip1.SetToolTip(linkLabel1, Program.LanguagePack(19));
            toolTip1.SetToolTip(linkLabel2, Program.LanguagePack(20));
            toolTip1.SetToolTip(linkLabel3, Program.LanguagePack(21));
            toolTip1.SetToolTip(applyButton, Program.LanguagePack(22));
            toolTip1.SetToolTip(browseButton, Program.LanguagePack(23));
            toolTip1.SetToolTip(getManifestButton, Program.LanguagePack(24));
            toolTip1.SetToolTip(aboutButton, Program.LanguagePack(25));
            toolTip1.SetToolTip(button4, Program.LanguagePack(26));
            toolTip1.SetToolTip(button3, Program.LanguagePack(27));
            toolTip1.SetToolTip(button1, Program.LanguagePack(28));
            toolTip1.SetToolTip(button2, Program.LanguagePack(29));

            //Set all of the bubble tooltips

            installFolderLabel.Text = string.Format(Program.LanguagePack(30), selectedGame.Name);
            manifestIdLabel.Text = string.Format(Program.LanguagePack(31), selectedGame.Name);
            depotsLabel.Text = Program.LanguagePack(73);
            checkBox1.Text = Program.LanguagePack(74);
            applyButton.Text.Equals("Apply");//Meh easy fix for apply button when the language change button is pressed when a game with a single depot is selected
                applyButton.Text = Program.LanguagePack(70);

            listBox1.DataSource = games;
            listBox1.FormattingEnabled = false;//without this it will call the tostring method of the object
            listBox1.DisplayMember = "Name";//dont know why but it still doesnt work so i just changed the tostring to the name love VS 2022 just wow. Shoulda used 2015 but noo
            
            //CustomizedToolTip myToolTip = new CustomizedToolTip();//https://www.codeproject.com/Articles/42050/ToolTip-With-Image-C might add game icons (they are available in the uninstaller regs) in the future but meh
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addNewGame();//could have just put it here instead of a new method but meh could be useful in the future
        }

        private CheckBox[] showDepotsInsteadOfGamesList(string depots, string manifests)
        {
            groupBox1.Controls.Clear();//if any panel has been set before by other games, this will clear it
            Panel panel1 = new Panel();//panels have an automatic slider function while groupbox doesn't soo instead of working more I just modified it a bit
            toolTip1.SetToolTip(panel1, toolTip1.GetToolTip(groupBox1));//apply same hints to the panel
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;//think this is the default option but why not make sure lol
            panel1.AutoScroll = true;//if anything flows out, scrollbars are enabled which is moslty the reason why i put checkboxes inside of a panel


            CheckBox[] allCheckboxes = new CheckBox[depots.ToCharArray().Count(c => c == ',') + 2];//e.g. depots:123,456 ==> 2 depots ==>(','count=1)+1= and another one for select/deselect all checkbox, overall = ',' count +1 +1
            string manifest = manifests;
            string depot = depots;
            bool continuee = true;
            bool allNeedsChange = true;
            bool[] changed = new bool[allCheckboxes.Length];
            string[] depotS = new string[allCheckboxes.Length];
            string[] actualDepots = new string[allCheckboxes.Length];
            int i = 1;
            var p = Path.Combine(textbox_path.Text, "..", "..", "appmanifest_" + textBoxAPPID.Text + ".acf");

            var acf = File.ReadAllText(p);//already installed manifest numbers will be here

            //I am not going to comment this place its a bit rough but it just compares the existing manifest id of depots with the new ones and creates a new panel with checkboxes to show which ones changed and allow for specific changes

            while (continuee)//This place is cursed i sometimes mix depots with manifests. My sanity is not as good as it used to be.
            {
                continuee = manifest.Contains(',');//exits when the last depot number is processed
                string singleDepot;
                if (continuee)
                    singleDepot = manifest.Substring(0,manifest.IndexOf(","));
                else
                    singleDepot = manifest;
                if (acf.Contains(singleDepot))//Compares if they have changed or not
                {
                    allNeedsChange = false;
                }
                else
                    changed[i] = true;
                depotS[i] = singleDepot;
                i++;
                manifest = manifest.Substring((manifest.IndexOf(",") + 1));
            }
            continuee = true;
            i = 1;
            while (continuee)//This place is cursed i sometimes mix depots with manifests. My sanity is not as good as it used to be.
            {
                continuee = depot.Contains(',');//exits when the last depot number is processed
                string singleDepot;
                if (continuee)
                    singleDepot = depot.Substring(0,depot.IndexOf(","));
                else
                    singleDepot = depot;
                actualDepots[i] = singleDepot;
                i++;
                depot = depot.Substring((depot.IndexOf(",") + 1));
            }
            
            i = 1;
            while (i < allCheckboxes.Length)//Creates them all with properties and then adds the listener
            {
                allCheckboxes[i] = new CheckBox() { Enabled = true, Checked = true, AutoSize = true, Text = depotS[i], ForeColor = Color.Red, Location = new Point(5, 21 * i) };
                if (!changed[i])
                {
                    allCheckboxes[i].Checked = false;
                    allCheckboxes[i].ForeColor = Color.Green;
                }
                allCheckboxes[i].CheckedChanged += allOtherCheckBoxes_CheckedChanged;
                toolTip1.SetToolTip(allCheckboxes[i], actualDepots[i]);
                i++;
            }

            //De/Select button properties:
            allCheckboxes[0] = new CheckBox() { Enabled = true, Checked = false, AutoSize = true, Text = Program.LanguagePack(32), ForeColor = Color.BlueViolet, Location = new Point(5, 0) };
            toolTip1.SetToolTip(allCheckboxes[0], Program.LanguagePack(33));

            if (allNeedsChange)
                allCheckboxes[0].Checked = true;
            allCheckboxes[0].CheckedChanged += SelectDeselectAll_CheckedChanged;
            foreach (CheckBox checkBox in allCheckboxes)
                panel1.Controls.Add(checkBox);
            groupBox1.Controls.Add(panel1);
            listBox1.Visible = false;//not needed but interferes with the tab movement in tab indexes if not done
            groupBox1.Visible = true;
            return allCheckboxes;
        }

        private bool autoSelectAllUnselected = false;//Used for De/Select all button
        private void allOtherCheckBoxes_CheckedChanged(object sender, EventArgs e)//The listener for all checkboxes other than De/Select button in order to make sure whether they are checked or not
        {

            if (!(sender as CheckBox).Checked)
            {
                if (forMultipleDepots[0].Checked)
                {
                    autoSelectAllUnselected = true;
                    forMultipleDepots[0].Checked = false;
                }
            }
            else
            {
                bool allSelected = true;
                for (int i = 1; i < forMultipleDepots.Length && allSelected; i++)
                {
                    allSelected = forMultipleDepots[i].Checked;
                }
                if (allSelected)
                    forMultipleDepots[0].Checked = true;
            }
        }

        private void SelectDeselectAll_CheckedChanged(object sender, System.EventArgs e)//Selects all unchecked boxes if Select all is checked
        {
            Debug.Write("De/Select");
            if (!autoSelectAllUnselected)
            {
                if ((sender as CheckBox).Checked)
                    foreach (CheckBox select in forMultipleDepots)
                        select.Checked = true;
                else
                    foreach (CheckBox select in forMultipleDepots)
                        select.Checked = false;
            }
            else
                autoSelectAllUnselected = false;
        }

        private void addNewGame()
        {
            Game addNewGame = new Game("Game Name", "APPID", "DEPOTID", "C:\\Program Files (x86)\\Steam\\steamapps\\common", null);
            editGamePreferences(addNewGame);
            for (int i = 0; i < games.Count; i++)//inserting in the true compareto order
            {
                if (games[i].CompareTo(addNewGame) > 0)
                {
                    games.Insert(i, addNewGame);
                    updateGames();
                    listBox1.SelectedIndex = i;
                    return;
                }
            }
            games.Add(addNewGame);//if it isn't already inserted just add it
            updateGames();
        }

        /// <summary>
        /// update the collection and the settings
        /// </summary>
        private void updateGames()
        {
            Properties.Settings.Default.alreadySetGames = Game.gamesToStringCollection(games);
            listBox1.DataSource = null;//listboxes are dumb since they dont have a refresh data sort of thing so nulling it and coming back works??? sure
            listBox1.DataSource = games;
        }


        private void browseButton_Click(object sender, EventArgs e)//lets you pick the game location on main menu
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = Program.LanguagePack(34);
                //dialog.UseDescriptionForTitle = true;//Used for c# 6.0
                dialog.ShowNewFolderButton = false;

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                textbox_path.Text = dialog.SelectedPath;
                textbox_path.SelectionStart = textbox_path.Text.Length;
            }
        }

        private void applyButton_Click(object sender, EventArgs e)// when the apply button is pressed, it looks at all of the possible values the button can get and goes from there
        {
            if (!Program.CheckFolderPath(textbox_path.Text, textBoxAPPID.Text))//Checks if the folder exists or not
            {
                Program.Bad(Program.LanguagePack(35));
                return;
            }

            if (Process.GetProcesses().Any(x => x.ProcessName.ToLower() == "steam"))//Checks if steam is on or not
            {
                if (Program.BadForceYesNo(Program.LanguagePack(36), true) != DialogResult.Yes)
                    return;
            }

            var p = Path.Combine(textbox_path.Text, "..", "..", "appmanifest_" + textBoxAPPID.Text + ".acf");//path of the manifest(s) file

            var acf = File.ReadAllText(p);//Manifest file as text

            if (applyButton.Text.Equals(Program.LanguagePack(70)))//Apply
            {
                if (!Regex.IsMatch(textbox_manifest.Text, "[0-9]{15,20}"))//Checks for the length and number state
                {
                    if (Program.BadForceYesNo(Program.LanguagePack(37), true) != DialogResult.Yes)
                        return;
                }

                if (acf.Contains(textbox_manifest.Text))
                    Program.Bad(Program.LanguagePack(38));

                acf = Regex.Replace(acf, "(\"" + textBoxDepots.Text + "\".*?\"manifest\"\\s*?)\"[0-9]{15,20}\"", $"$1\"{textbox_manifest.Text}\"", RegexOptions.Singleline | RegexOptions.IgnoreCase);

                doSHit(p, acf, false);

            }
            else if (applyButton.Text.Equals(Program.LanguagePack(71)))//Choose & Apply
            {
                if (textBoxDepots.Text.ToCharArray().Count(c => c == ',') != textbox_manifest.Text.ToCharArray().Count(c => c == ','))//Compares the amount of manifests to the depots
                {
                    Program.Bad(Program.LanguagePack(39));
                    return;
                }
                if (textbox_manifest.Text.Any(char.IsLetter))
                {
                    if (Program.BadForceYesNo(Program.LanguagePack(40), true) != DialogResult.Yes)
                        return;
                }
                forMultipleDepots = showDepotsInsteadOfGamesList(textBoxDepots.Text, textbox_manifest.Text);
                applyButton.Text = Program.LanguagePack(72);
                browseButton.Enabled = false;
                getManifestButton.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                buttonLanguage.Enabled = false;
                textbox_path.Enabled = false;
                textBoxDepots.Enabled = false;
                textBoxAPPID.Enabled = false;
                textbox_manifest.Enabled = false;
                //checkBox1.Enabled = false;
                toolTip1.SetToolTip(applyButton, Program.LanguagePack(41));

            }
            else if (applyButton.Text.Equals(Program.LanguagePack(72)))//Apply Selected
            {
                bool anyChecked = false;
                for (int i = 1; i < forMultipleDepots.Length; i++)//Applies only the selected depot changes, none if nothing has been set
                    if (forMultipleDepots[i].Checked)
                    {
                        acf = Regex.Replace(acf, "(\"" + toolTip1.GetToolTip(forMultipleDepots[i]) + "\".*?\"manifest\"\\s*?)\"[0-9]{15,20}\"", $"$1\"{forMultipleDepots[i].Text}\"", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                        anyChecked = true;
                    }

                applyButton.Text = Program.LanguagePack(71);
                groupBox1.Visible = false;
                listBox1.Visible = true;
                if (anyChecked)
                    doSHit(p, acf, false);
                else if (checkBox1.Checked)
                {
                    doSHit(p, acf, true);
                    Program.Success(Program.LanguagePack(42));
                }
                else
                    Program.Bad(Program.LanguagePack(43));
                browseButton.Enabled = true;
                getManifestButton.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                buttonLanguage.Enabled = true;
                textbox_path.Enabled = true;
                textBoxDepots.Enabled = true;
                textBoxAPPID.Enabled = true;
                textbox_manifest.Enabled = true;
                //checkBox1.Enabled = true;
                toolTip1.SetToolTip(applyButton, Program.LanguagePack(44));

            }


            /*
            switch (applyButton.Text)//THis is sad, switch case wants a hard wired solution where strings are constants rip
            {
                case "Apply":
                    {
                        if (!Regex.IsMatch(textbox_manifest.Text, "[0-9]{15,20}"))
                        {
                            if (Program.BadForceYesNo(Program.LanguagePack(37), true) != DialogResult.Yes)
                                return;
                        }

                        if (acf.Contains(textbox_manifest.Text))
                            Program.Bad(Program.LanguagePack(38));

                        acf = Regex.Replace(acf, "(\"" + textBoxDepots.Text + "\".*?\"manifest\"\\s*?)\"[0-9]{15,20}\"", $"$1\"{textbox_manifest.Text}\"", RegexOptions.Singleline | RegexOptions.IgnoreCase);

                        doSHit(p, acf,false);
                    }
                    break;
                case "Choose & Apply":
                    {
                        if (textBoxDepots.Text.ToCharArray().Count(c => c == ',') != textbox_manifest.Text.ToCharArray().Count(c => c == ','))
                        {
                            Program.Bad(Program.LanguagePack(39));
                            return;
                        }
                        if (textbox_manifest.Text.Any(char.IsLetter))
                        {
                            if (Program.BadForceYesNo(Program.LanguagePack(40), true) != DialogResult.Yes)
                                return;
                        }
                        forMultipleDepots = showDepotsInsteadOfGamesList(textBoxDepots.Text, textbox_manifest.Text);
                        applyButton.Text = "Apply Selected";
                        browseButton.Enabled = false;
                        getManifestButton.Enabled = false;
                        button1.Enabled = false;
                        button2.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        buttonLanguage.Enabled = false;
                        textbox_path.Enabled = false;
                        textBoxDepots.Enabled = false;
                        textBoxAPPID.Enabled = false;
                        textbox_manifest.Enabled = false;
                        //checkBox1.Enabled = false;
                        toolTip1.SetToolTip(applyButton, Program.LanguagePack(41));
                    }
                    break;
                case "Apply Selected":
                    {
                        bool anyChecked = false;
                        for (int i = 1; i < forMultipleDepots.Length; i++)
                            if (forMultipleDepots[i].Checked)
                            {
                                acf = Regex.Replace(acf, "(\"" + toolTip1.GetToolTip(forMultipleDepots[i]) + "\".*?\"manifest\"\\s*?)\"[0-9]{15,20}\"", $"$1\"{forMultipleDepots[i].Text}\"", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                                anyChecked = true;
                            }

                        applyButton.Text = "Choose & Apply";
                        groupBox1.Visible = false;
                        listBox1.Visible = true;
                        if (anyChecked)
                            doSHit(p, acf,false);
                        else if (checkBox1.Checked)
                        {
                            doSHit(p, acf, true);
                            Program.Success(Program.LanguagePack(42));
                        }
                        else
                            Program.Bad(Program.LanguagePack(43));
                        browseButton.Enabled = true;
                        getManifestButton.Enabled = true;
                        button1.Enabled = true;
                        button2.Enabled = true;
                        button3.Enabled = true;
                        button4.Enabled = true;
                        buttonLanguage.Enabled = true;
                        textbox_path.Enabled = true;
                        textBoxDepots.Enabled = true;
                        textBoxAPPID.Enabled = true;
                        textbox_manifest.Enabled = true;
                        //checkBox1.Enabled = true;
                        toolTip1.SetToolTip(applyButton, Program.LanguagePack(44));
                    }
                    break;

            }*/
        }
        private void doSHit(string path, string content,bool onlyAutoUpdate)//does the actual modification of the file and saves it
        {
            if (!onlyAutoUpdate)
            {
                SetKv(ref content, "ScheduledAutoUpdate", "0");
                SetKv(ref content, "LastUpdated", ((uint)DateTimeOffset.Now.ToUnixTimeSeconds()).ToString());
                SetKv(ref content, "StateFlags", "4");
                SetKv(ref content, "UpdateResult", "0");
            }

            // Disable Autoupdate if its not already (1 is NOT "enable auto updates"; its "Only update this game when I launch it")
            if (checkBox1.Checked)
                SetKv(ref content, "AutoUpdateBehavior", "1");

            File.WriteAllText(path, content);
            if(!onlyAutoUpdate)
                Program.Success(Program.LanguagePack(45));

            selectedGame.LastChanged = DateTime.Now.ToString();
            updateGames();
            labelLastUpdateCancel.Text = selectedGame.LastChanged;
        }

        void SetKv(ref string input, string key, string val)
        {
            input = Regex.Replace(input, $"\"{key}\".*", $"\"{key}\"\t\"{val}\"", RegexOptions.IgnoreCase);
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            Program.Success(Program.LanguagePack(46));
        }

        private async void getManifestButton_ClickAsync(object sender, EventArgs e)//goes online through SteamKit2 to get manifest id(s)
        {
            if(textBoxAPPID.Text.Equals(string.Empty)| textBoxDepots.Text.Equals(string.Empty))
            {
                Program.Bad(Program.LanguagePack(47));
                return;
            }
            getManifestButton.Enabled = false;
            getManifestButton.Text = Program.LanguagePack(48);

            AppInfo appInfo = new AppInfo();
            string manifestS = await appInfo.TryRetrieve(textBoxAPPID.Text, textBoxDepots.Text);

            // if successful fill in textbox
            if (!string.IsNullOrEmpty(manifestS))
            {
                textbox_manifest.Text = manifestS;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.Activate();//as it sometimes takes ages for it to fail, this makes it come to foreground if it was minimized.
                if (Program.BadForceYesNo(Program.LanguagePack(49), false) == DialogResult.Yes)
                //MessageBox.Show("Automatically retreiving the Manifest ID failed. Copy the latest 'Manifest ID' from the site. Make sure that 'Last update' looks correct, to confirm the site has already spotted the latest update!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                {
                    if(!textBoxDepots.Text.Contains(','))
                        Program.LaunchUrl($"https://steamdb.info/depot/{textBoxDepots.Text}/manifests");
                    else
                    {
                        bool justDoItLol = true;
                        string tempLol = textBoxDepots.Text;
                        while (justDoItLol)
                        {
                            int indexo = tempLol.IndexOf(',');
                            if (indexo != -1)
                                Program.LaunchUrl($"https://steamdb.info/depot/{tempLol.Substring(0, indexo)}/manifests");
                            if (tempLol.Contains(','))
                                tempLol = tempLol.Substring(indexo+1);
                            else
                            {
                                Program.LaunchUrl($"https://steamdb.info/depot/{tempLol}/manifests");
                                justDoItLol=false;
                            }
                            Thread.Sleep(500);//make it easier on slow computer maybe??
                        }
                    }
                }
                textbox_manifest.Text += string.Format(Program.LanguagePack(50), textBoxDepots.Text);
            }

            getManifestButton.Enabled = true;
            getManifestButton.Text = Program.LanguagePack(51);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (selectedGame != games[listBox1.SelectedIndex])
                {
                    selectedGame = games[listBox1.SelectedIndex];

                    labelLastUpdateCancel.Text = selectedGame.LastChanged;
                    textBoxAPPID.Text = selectedGame.APPID;
                    textBoxDepots.Text = selectedGame.DepotIDs;
                    textbox_path.Text = selectedGame.InstallPath;
                    textbox_path.SelectionStart = textbox_path.Text.Length;
                    textbox_manifest.Text = String.Empty;
                    installFolderLabel.Text = string.Format(Program.LanguagePack(52), selectedGame.Name);
                    manifestIdLabel.Text = string.Format(Program.LanguagePack(53), selectedGame.Name);
                }
            }
            catch
            {
                //this is here because when the data source is set to null this gives an error sooo yeah instead of solving it i just stuck this here voila
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)//editing of a game if double clicked
        {
            int index = listBox1.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)//https://stackoverflow.com/questions/69825389/double-click-on-listbox-item-c-sharp
            {
                editGamePreferences(listBox1.SelectedItem);
            }
        }

        private void editGamePreferences(object selectedGameObject)//Actual edit popups, saves the hint if not modified and edits the next property if ok is pressed
        {
            Game gameOfChoice = (Game)selectedGameObject;
            bool continuee;
            gameOfChoice.Name = IsNullOrEmptyDefaultValue(Interaction.InputBox(Program.LanguagePack(54), Program.LanguagePack(55), gameOfChoice.Name), gameOfChoice.Name, out continuee);
            if (continuee)
                gameOfChoice.APPID = IsNullOrEmptyDefaultValue(Microsoft.VisualBasic.Interaction.InputBox(Program.LanguagePack(56), Program.LanguagePack(57) , gameOfChoice.APPID), gameOfChoice.APPID, out continuee);
            if (continuee)
                gameOfChoice.DepotIDs = IsNullOrEmptyDefaultValue(Microsoft.VisualBasic.Interaction.InputBox(Program.LanguagePack(58), Program.LanguagePack(59), gameOfChoice.DepotIDs), gameOfChoice.DepotIDs, out continuee);
            if (continuee)
                using (var dialog = new FolderBrowserDialog())
                {
                    dialog.SelectedPath = gameOfChoice.InstallPath;
                    dialog.Description = Program.LanguagePack(34);//"Choose the folder where the game is under the Steam\\steamapps\\common folder";
                    //dialog.UseDescriptionForTitle = true;//For c# 6.0
                    dialog.ShowNewFolderButton = false;
                    if (dialog.ShowDialog() == DialogResult.OK)
                        gameOfChoice.InstallPath = dialog.SelectedPath;
                }
            updateGames();
        }

        private string IsNullOrEmptyDefaultValue(string input, string defaultValue, out bool continuation)//a simple method for editing of the game properties
        {
            continuation = false;
            if (string.IsNullOrEmpty(input))
                return defaultValue;

            continuation = true;
            return input;
        }

        private void buttonLanguage_Click(object sender, EventArgs e)
        {
            Program.changeLanguagePack();
            Form1_Load(null,null);//This will reload/update most of the text if language pack has been changed
        }

        private void button2_Click(object sender, EventArgs e)//remove game button
        {
            int index = listBox1.SelectedIndex;
            games.Remove(selectedGame);
            updateGames();
            if(index<listBox1.Items.Count&& index > 0)//Whenever a game is deleted, it reselects a new one as long as there is one left.
                listBox1.SelectedIndex = index;
            else if(index > 0)
                listBox1.SelectedIndex = index-1;
        }

        private void textBoxDepots_KeyPress(object sender, KeyPressEventArgs e)//blocks u from inputting letters
        {//https://stackoverflow.com/questions/463299/how-do-i-make-a-textbox-that-only-accepts-numbers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            // only allow a comma if it wasnt last to avoid duplicates
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.LastIndexOf(',') != (sender as TextBox).Text.Length - 1))
            {
                e.Handled = false;
            }
            if (e.Handled)
            {
                toolTip1.Show(String.Empty, textBoxDepots, 0);
                toolTip1.Show(Program.LanguagePack(60), textBoxDepots, 2400);
            }
        }

        private void textbox_manifest_KeyPress(object sender, KeyPressEventArgs e)//blocks u from inputting letters
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            //&&(e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow a comma if it wasnt last to avoid duplicates
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.LastIndexOf(',') != (sender as TextBox).Text.Length - 1))
            {
                e.Handled = false;
            }
            if (e.Handled)
            {
                toolTip1.Show(String.Empty, textbox_manifest, 0);
                toolTip1.Show(Program.LanguagePack(60), textbox_manifest, 2400);
            }
        }

        private void textBoxAPPID_KeyPress(object sender, KeyPressEventArgs e)//blocks u from inputting letters
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                toolTip1.Show(String.Empty, textBoxAPPID, 0);
                toolTip1.Show(Program.LanguagePack(61), textBoxAPPID, 2400);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Program.LaunchUrl("https://kinsi.me/bsmods.html");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //second link button which is for me lol
            Program.LaunchUrl("https://github.com/YeetTheFirst21");
        }


        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //third link button which is for the Globe and Add Icon I used
            Program.LaunchUrl("https://www.iconpacks.net/about/");
        }

        private void textBoxDepots_TextChanged(object sender, EventArgs e)
        {
            if (textBoxDepots.Text.Contains(','))//To change the apply button
            {
                applyButton.Text = Program.LanguagePack(71);// "Choose & Apply";
                toolTip1.SetToolTip(applyButton, Program.LanguagePack(62));
            }
            else
            {
                applyButton.Text = Program.LanguagePack(70);//"Apply";
                toolTip1.SetToolTip(applyButton, Program.LanguagePack(44));//"Apply The Depot ManifestID Change");
            }
        }

        private void button3_Click(object sender, EventArgs e)//Save mode change button
        {
            if (!Properties.Settings.Default.SavingTurnedOn)
            {
                if (Program.BadForceYesNo(Program.LanguagePack(63) + Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) + "\\Local\\" + FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location).CompanyName + Program.LanguagePack(64), false) == DialogResult.Yes)
                {
                    Properties.Settings.Default.SavingTurnedOn = true;
                    Program.saveSettingsBoii(Properties.Settings.Default.SavingTurnedOn);
                }
            }else
                if (Program.BadForceYesNo(Program.LanguagePack(65) + Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) + "\\Local\\" + FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location).CompanyName + Program.LanguagePack(66), false) == DialogResult.Yes)
                {
                    Properties.Settings.Default.SavingTurnedOn = false;
                    Program.saveSettingsBoii(true);
                }
        }

        private void button4_Click(object sender, EventArgs e)//Search fo games
        {
            if (Program.BadForceYesNo(Program.LanguagePack(67), false) == DialogResult.Yes)
            {
                Program.SearchForGamesAutomatically();
                games = Game.StringCollectionToGames(Properties.Settings.Default.alreadySetGames);
                updateGames();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.saveSettingsBoii(Properties.Settings.Default.SavingTurnedOn);//save settings if autoSave is turned on//put it in closing so that it would be possible to add a cancel close without save if u want
        }
    }

    /// <summary>
    /// simple game class to easily turn them into string list for the properties.
    /// </summary>
    partial class Game : IComparable<Game>
    {
        public string Name;
        public string APPID;
        public string DepotIDs;
        public string InstallPath;
        public string LastChanged;
        public Game(string name, string aPPID, string dEPOTIDs, string installPath, string time)
        {
            Name = name;
            APPID = aPPID;
            DepotIDs = dEPOTIDs;
            InstallPath = installPath;
            if (string.IsNullOrEmpty(time))
            {
                LastChanged = Program.LanguagePack(68);
                //LastChanged = DateTime.Now.ToString();
            }
            else
                LastChanged = time;
        }
        static public StringCollection gamesToStringCollection(List<Game> games)
        {
            StringCollection collection = new StringCollection();
            foreach (Game game in games)
                collection.Add(game.Name + "//" + game.APPID + "//" + game.DepotIDs + "//" + game.InstallPath + "//" + game.LastChanged);
            return collection;
        }
        static public List<Game> StringCollectionToGames(StringCollection gamesStringCollection)
        {
            List<Game> gameS = new List<Game>();
            if (gamesStringCollection != null)
                for (int i = 0; i < gamesStringCollection.Count; i++)
                {
                    if (!string.IsNullOrEmpty(gamesStringCollection[i]))
                    {
                        try
                        {
                            string leftover = gamesStringCollection[i];
                            int index = leftover.IndexOf("//");
                            string name = leftover.Substring(0, index);
                            leftover = leftover.Substring(index + 2);
                            index = leftover.IndexOf("//");
                            string appID = leftover.Substring(0, index);
                            leftover = leftover.Substring(index + 2);
                            index = leftover.IndexOf("//");
                            string depotIds = leftover.Substring(0, index);
                            leftover = leftover.Substring(index + 2);
                            index = leftover.IndexOf("//");
                            string installPath = leftover.Substring(0, index);
                            string time = leftover.Substring(index + 2);
                            gameS.Add(new Game(name, appID, depotIds, installPath, time));
                        }
                        catch
                        {
                            if (Program.BadForceYesNo(string.Format(Program.LanguagePack(69), gamesStringCollection[i]), false) == DialogResult.Yes)
                                gamesStringCollection[i] = string.Empty;
                        }

                    }
                }
            return gameS;
        }

        /// <summary>
        /// Sorting is easy with dis when game objects are in a list
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Game other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return Name;//This is used for the listbox so i just left it like this
            //return base.ToString() + ":" + Name + APPID + InstallPath + LastChanged;
        }

    }
}