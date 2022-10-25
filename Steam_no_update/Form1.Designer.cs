using System.Windows.Forms;

namespace Steam_no_update
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.installFolderLabel = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.textbox_path = new System.Windows.Forms.TextBox();
            this.manifestIdLabel = new System.Windows.Forms.Label();
            this.textbox_manifest = new System.Windows.Forms.TextBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.aboutButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.getManifestButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.depotsLabel = new System.Windows.Forms.Label();
            this.textBoxDepots = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonLanguage = new System.Windows.Forms.Button();
            this.textBoxAPPID = new System.Windows.Forms.TextBox();
            this.labelAPPID = new System.Windows.Forms.Label();
            this.labelLastUpdateCancel = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(365, 178);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 30);
            this.button1.TabIndex = 13;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // installFolderLabel
            // 
            this.installFolderLabel.AutoSize = true;
            this.installFolderLabel.Location = new System.Drawing.Point(13, 10);
            this.installFolderLabel.Name = "installFolderLabel";
            this.installFolderLabel.Size = new System.Drawing.Size(157, 16);
            this.installFolderLabel.TabIndex = 0;
            this.installFolderLabel.Text = "Beat Saber install Folder:";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(283, 26);
            this.browseButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(80, 25);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Browse...";
            this.browseButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // textbox_path
            // 
            this.textbox_path.Location = new System.Drawing.Point(13, 26);
            this.textbox_path.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textbox_path.MaxLength = 0;
            this.textbox_path.Name = "textbox_path";
            this.textbox_path.Size = new System.Drawing.Size(265, 22);
            this.textbox_path.TabIndex = 1;
            // 
            // manifestIdLabel
            // 
            this.manifestIdLabel.AutoSize = true;
            this.manifestIdLabel.Location = new System.Drawing.Point(13, 108);
            this.manifestIdLabel.Name = "manifestIdLabel";
            this.manifestIdLabel.Size = new System.Drawing.Size(183, 16);
            this.manifestIdLabel.TabIndex = 0;
            this.manifestIdLabel.Text = "Latest Beat Saber Manifest ID";
            // 
            // textbox_manifest
            // 
            this.textbox_manifest.Location = new System.Drawing.Point(13, 126);
            this.textbox_manifest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textbox_manifest.MaxLength = 0;
            this.textbox_manifest.Name = "textbox_manifest";
            this.textbox_manifest.Size = new System.Drawing.Size(265, 22);
            this.textbox_manifest.TabIndex = 5;
            this.textbox_manifest.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_manifest_KeyPress);
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(13, 178);
            this.applyButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(155, 30);
            this.applyButton.TabIndex = 8;
            this.applyButton.Text = "Apply";
            this.applyButton.UseMnemonic = false;
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label3.Location = new System.Drawing.Point(-1, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(450, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Created by Kinsi for BeatSaber, Modified by YeetTheFirst21 for all games";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(543, 208);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(33, 16);
            this.linkLabel2.TabIndex = 16;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "#AD";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // aboutButton
            // 
            this.aboutButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.aboutButton.Image = ((System.Drawing.Image)(resources.GetObject("aboutButton.Image")));
            this.aboutButton.Location = new System.Drawing.Point(187, 174);
            this.aboutButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(37, 34);
            this.aboutButton.TabIndex = 9;
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(13, 154);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(148, 20);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Disable Autoupdate";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // getManifestButton
            // 
            this.getManifestButton.Location = new System.Drawing.Point(283, 126);
            this.getManifestButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.getManifestButton.Name = "getManifestButton";
            this.getManifestButton.Size = new System.Drawing.Size(80, 25);
            this.getManifestButton.TabIndex = 6;
            this.getManifestButton.Text = "Retrieve";
            this.getManifestButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.getManifestButton.UseVisualStyleBackColor = true;
            this.getManifestButton.Click += new System.EventHandler(this.getManifestButton_ClickAsync);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(365, 10);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(247, 164);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(365, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(248, 166);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Confirm to change manifests:";
            this.groupBox1.Visible = false;
            // 
            // depotsLabel
            // 
            this.depotsLabel.AutoSize = true;
            this.depotsLabel.Location = new System.Drawing.Point(13, 58);
            this.depotsLabel.Name = "depotsLabel";
            this.depotsLabel.Size = new System.Drawing.Size(130, 16);
            this.depotsLabel.TabIndex = 0;
            this.depotsLabel.Text = "ALL Installed Depots";
            // 
            // textBoxDepots
            // 
            this.textBoxDepots.Location = new System.Drawing.Point(13, 78);
            this.textBoxDepots.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxDepots.MaxLength = 0;
            this.textBoxDepots.Name = "textBoxDepots";
            this.textBoxDepots.Size = new System.Drawing.Size(265, 22);
            this.textBoxDepots.TabIndex = 3;
            this.textBoxDepots.TextChanged += new System.EventHandler(this.textBoxDepots_TextChanged);
            this.textBoxDepots.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDepots_KeyPress);
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(497, 178);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 30);
            this.button2.TabIndex = 14;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonLanguage
            // 
            this.buttonLanguage.Image = ((System.Drawing.Image)(resources.GetObject("buttonLanguage.Image")));
            this.buttonLanguage.Location = new System.Drawing.Point(273, 174);
            this.buttonLanguage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonLanguage.Name = "buttonLanguage";
            this.buttonLanguage.Size = new System.Drawing.Size(37, 34);
            this.buttonLanguage.TabIndex = 11;
            this.buttonLanguage.UseVisualStyleBackColor = true;
            this.buttonLanguage.Click += new System.EventHandler(this.buttonLanguage_Click);
            // 
            // textBoxAPPID
            // 
            this.textBoxAPPID.Location = new System.Drawing.Point(283, 78);
            this.textBoxAPPID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxAPPID.MaxLength = 19;
            this.textBoxAPPID.Name = "textBoxAPPID";
            this.textBoxAPPID.Size = new System.Drawing.Size(79, 22);
            this.textBoxAPPID.TabIndex = 4;
            this.textBoxAPPID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAPPID_KeyPress);
            // 
            // labelAPPID
            // 
            this.labelAPPID.AutoSize = true;
            this.labelAPPID.Location = new System.Drawing.Point(283, 58);
            this.labelAPPID.Name = "labelAPPID";
            this.labelAPPID.Size = new System.Drawing.Size(47, 16);
            this.labelAPPID.TabIndex = 14;
            this.labelAPPID.Text = "APPID";
            // 
            // labelLastUpdateCancel
            // 
            this.labelLastUpdateCancel.AutoSize = true;
            this.labelLastUpdateCancel.Location = new System.Drawing.Point(180, 155);
            this.labelLastUpdateCancel.Name = "labelLastUpdateCancel";
            this.labelLastUpdateCancel.Size = new System.Drawing.Size(44, 16);
            this.labelLastUpdateCancel.TabIndex = 15;
            this.labelLastUpdateCancel.Text = "DATE";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(499, 208);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(33, 16);
            this.linkLabel1.TabIndex = 15;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "#AD";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(588, 208);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(33, 16);
            this.linkLabel3.TabIndex = 17;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "#AD";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(316, 174);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(37, 34);
            this.button3.TabIndex = 12;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(230, 174);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(37, 34);
            this.button4.TabIndex = 10;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 230);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonLanguage);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.labelLastUpdateCancel);
            this.Controls.Add(this.labelAPPID);
            this.Controls.Add(this.textBoxAPPID);
            this.Controls.Add(this.textBoxDepots);
            this.Controls.Add(this.depotsLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.getManifestButton);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.textbox_manifest);
            this.Controls.Add(this.manifestIdLabel);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.textbox_path);
            this.Controls.Add(this.installFolderLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0.96D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steam_no_update";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private System.Windows.Forms.Label installFolderLabel;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox textbox_path;
        private System.Windows.Forms.Label manifestIdLabel;
        private System.Windows.Forms.TextBox textbox_manifest;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button getManifestButton;
        private ListBox listBox1;
        private ToolTip toolTip1;
        private GroupBox groupBox1;
        private Label depotsLabel;
        private TextBox textBoxDepots;
        private Button button2;
        private Button buttonLanguage;
        private TextBox textBoxAPPID;
        private Label labelAPPID;
        private Label labelLastUpdateCancel;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel3;
        private Button button3;
        private Button button4;
    }
}