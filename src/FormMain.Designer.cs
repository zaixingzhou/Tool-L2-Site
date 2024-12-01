﻿namespace LANDIS_II_Site
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuProject = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRun = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportInputForLANDISIIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plotResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuUserGuide = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripRun = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonExportOutput = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonUserGuide = new System.Windows.Forms.ToolStripButton();
            this.groupBoxPara = new System.Windows.Forms.GroupBox();
            this.cbRandSeed = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbRandSeed = new System.Windows.Forms.TextBox();
            this.cbSeedingAlg = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbStartYr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTimestep = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.tbSimYears = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.cbExtensionOption = new System.Windows.Forms.ComboBox();
            this.labelSuccession = new System.Windows.Forms.Label();
            this.groupBoxExtensions = new System.Windows.Forms.GroupBox();
            this.labelDisturbance = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.groupBoxEcoPara = new System.Windows.Forms.GroupBox();
            this.btDeleteEcoPara = new System.Windows.Forms.Button();
            this.cbEcoPara = new System.Windows.Forms.ComboBox();
            this.btAddEcoPara = new System.Windows.Forms.Button();
            this.dataGridViewEcoPara = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbClimateFile = new System.Windows.Forms.TextBox();
            this.btClimate = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cbSppGenericPara = new System.Windows.Forms.ComboBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.dataGridViewSppLifeHistory = new System.Windows.Forms.DataGridView();
            this.btAddSppLifeHistorySpp = new System.Windows.Forms.Button();
            this.btAddSppLifeHistoryPara = new System.Windows.Forms.Button();
            this.groupBoxAddEcoPara = new System.Windows.Forms.GroupBox();
            this.btDeleteSppGeneric = new System.Windows.Forms.Button();
            this.dataGridViewSppGeneric = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btAddSpeciesGenericPara = new System.Windows.Forms.Button();
            this.btDeleteSppLifeHistoryPara = new System.Windows.Forms.Button();
            this.btDeleteSppLifeHistorySpp = new System.Windows.Forms.Button();
            this.groupBoxSppLifeHistory = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btDeleteSppEcophysiSpp = new System.Windows.Forms.Button();
            this.btAddSppEcophysiSpp = new System.Windows.Forms.Button();
            this.btDeleteSppEcophysiPara = new System.Windows.Forms.Button();
            this.dataGridViewSppEcophysi = new System.Windows.Forms.DataGridView();
            this.btAddSppEcophysiPara = new System.Windows.Forms.Button();
            this.tabControlGraph = new System.Windows.Forms.TabControl();
            this.tabPageClimate = new System.Windows.Forms.TabPage();
            this.checkedListBoxClimate = new System.Windows.Forms.CheckedListBox();
            this.zedGraphControlClimate = new ZedGraph.ZedGraphControl();
            this.tabPageCarbon = new System.Windows.Forms.TabPage();
            this.checkedListBoxCarbon = new System.Windows.Forms.CheckedListBox();
            this.zedGraphControlCarbon = new ZedGraph.ZedGraphControl();
            this.tabPageWater = new System.Windows.Forms.TabPage();
            this.tabPageNitrogen = new System.Windows.Forms.TabPage();
            this.tabPageCohorts = new System.Windows.Forms.TabPage();
            this.tabPageCompare = new System.Windows.Forms.TabPage();
            this.buttonRunModel = new System.Windows.Forms.Button();
            this.buttonClearGraph = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.groupBoxPara.SuspendLayout();
            this.groupBoxExtensions.SuspendLayout();
            this.groupBoxEcoPara.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEcoPara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSppLifeHistory)).BeginInit();
            this.groupBoxAddEcoPara.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSppGeneric)).BeginInit();
            this.groupBoxSppLifeHistory.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSppEcophysi)).BeginInit();
            this.tabControlGraph.SuspendLayout();
            this.tabPageClimate.SuspendLayout();
            this.tabPageCarbon.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuProject,
            this.toolsToolStripMenuItem,
            this.outputToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(832, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // MenuProject
            // 
            this.MenuProject.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuOpen,
            this.MenuSave,
            this.MenuRun,
            this.toolStripSeparator1,
            this.MenuExit});
            this.MenuProject.Name = "MenuProject";
            this.MenuProject.Size = new System.Drawing.Size(56, 20);
            this.MenuProject.Text = "&Project";
            // 
            // MenuOpen
            // 
            this.MenuOpen.Name = "MenuOpen";
            this.MenuOpen.Size = new System.Drawing.Size(112, 22);
            this.MenuOpen.Text = "&Open...";
            // 
            // MenuSave
            // 
            this.MenuSave.Name = "MenuSave";
            this.MenuSave.Size = new System.Drawing.Size(112, 22);
            this.MenuSave.Text = "&Save...";
            // 
            // MenuRun
            // 
            this.MenuRun.Name = "MenuRun";
            this.MenuRun.Size = new System.Drawing.Size(112, 22);
            this.MenuRun.Text = "&Run";
            this.MenuRun.Click += new System.EventHandler(this.MenuRun_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(109, 6);
            // 
            // MenuExit
            // 
            this.MenuExit.Name = "MenuExit";
            this.MenuExit.Size = new System.Drawing.Size(112, 22);
            this.MenuExit.Text = "&Exit";
            this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportInputForLANDISIIToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // exportInputForLANDISIIToolStripMenuItem
            // 
            this.exportInputForLANDISIIToolStripMenuItem.Name = "exportInputForLANDISIIToolStripMenuItem";
            this.exportInputForLANDISIIToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.exportInputForLANDISIIToolStripMenuItem.Text = "&Export Input for LANDIS-II...";
            // 
            // outputToolStripMenuItem
            // 
            this.outputToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportOutputToolStripMenuItem,
            this.plotResultsToolStripMenuItem});
            this.outputToolStripMenuItem.Name = "outputToolStripMenuItem";
            this.outputToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.outputToolStripMenuItem.Text = "&Output";
            // 
            // exportOutputToolStripMenuItem
            // 
            this.exportOutputToolStripMenuItem.Name = "exportOutputToolStripMenuItem";
            this.exportOutputToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.exportOutputToolStripMenuItem.Text = "&Export Output...";
            this.exportOutputToolStripMenuItem.Click += new System.EventHandler(this.saveOutputToolStripMenuItem_Click);
            // 
            // plotResultsToolStripMenuItem
            // 
            this.plotResultsToolStripMenuItem.Name = "plotResultsToolStripMenuItem";
            this.plotResultsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.plotResultsToolStripMenuItem.Text = "&Plot Results";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuUserGuide,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // MenuUserGuide
            // 
            this.MenuUserGuide.Name = "MenuUserGuide";
            this.MenuUserGuide.Size = new System.Drawing.Size(131, 22);
            this.MenuUserGuide.Text = "&User Guide";
            this.MenuUserGuide.Click += new System.EventHandler(this.MenuUserGuide_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripOpen,
            this.toolStripSave,
            this.toolStripSeparator2,
            this.toolStripRun,
            this.toolStripSeparator3,
            this.toolStripButtonExportOutput,
            this.toolStripSeparator4,
            this.toolStripButtonUserGuide});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(832, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip";
            // 
            // toolStripOpen
            // 
            this.toolStripOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripOpen.Image")));
            this.toolStripOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripOpen.Name = "toolStripOpen";
            this.toolStripOpen.Size = new System.Drawing.Size(40, 22);
            this.toolStripOpen.Text = "Open";
            // 
            // toolStripSave
            // 
            this.toolStripSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSave.Image")));
            this.toolStripSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSave.Name = "toolStripSave";
            this.toolStripSave.Size = new System.Drawing.Size(35, 22);
            this.toolStripSave.Text = "Save";
            this.toolStripSave.Click += new System.EventHandler(this.toolStripSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripRun
            // 
            this.toolStripRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripRun.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRun.Image")));
            this.toolStripRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRun.Name = "toolStripRun";
            this.toolStripRun.Size = new System.Drawing.Size(32, 22);
            this.toolStripRun.Text = "Run";
            this.toolStripRun.Click += new System.EventHandler(this.MenuRun_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonExportOutput
            // 
            this.toolStripButtonExportOutput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonExportOutput.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonExportOutput.Image")));
            this.toolStripButtonExportOutput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExportOutput.Name = "toolStripButtonExportOutput";
            this.toolStripButtonExportOutput.Size = new System.Drawing.Size(86, 22);
            this.toolStripButtonExportOutput.Text = "Export Output";
            this.toolStripButtonExportOutput.ToolTipText = "Export output results";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonUserGuide
            // 
            this.toolStripButtonUserGuide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonUserGuide.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonUserGuide.Image")));
            this.toolStripButtonUserGuide.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUserGuide.Name = "toolStripButtonUserGuide";
            this.toolStripButtonUserGuide.Size = new System.Drawing.Size(68, 22);
            this.toolStripButtonUserGuide.Text = "User Guide";
            this.toolStripButtonUserGuide.Click += new System.EventHandler(this.MenuUserGuide_Click);
            // 
            // groupBoxPara
            // 
            this.groupBoxPara.Controls.Add(this.cbRandSeed);
            this.groupBoxPara.Controls.Add(this.label4);
            this.groupBoxPara.Controls.Add(this.tbRandSeed);
            this.groupBoxPara.Controls.Add(this.cbSeedingAlg);
            this.groupBoxPara.Controls.Add(this.label2);
            this.groupBoxPara.Controls.Add(this.tbStartYr);
            this.groupBoxPara.Controls.Add(this.label1);
            this.groupBoxPara.Controls.Add(this.tbTimestep);
            this.groupBoxPara.Controls.Add(this.label39);
            this.groupBoxPara.Controls.Add(this.tbSimYears);
            this.groupBoxPara.Controls.Add(this.label13);
            this.groupBoxPara.Location = new System.Drawing.Point(218, 48);
            this.groupBoxPara.Name = "groupBoxPara";
            this.groupBoxPara.Size = new System.Drawing.Size(176, 147);
            this.groupBoxPara.TabIndex = 2;
            this.groupBoxPara.TabStop = false;
            this.groupBoxPara.Text = "Simulation Parameters";
            // 
            // cbRandSeed
            // 
            this.cbRandSeed.AutoSize = true;
            this.cbRandSeed.Location = new System.Drawing.Point(6, 124);
            this.cbRandSeed.Name = "cbRandSeed";
            this.cbRandSeed.Size = new System.Drawing.Size(15, 14);
            this.cbRandSeed.TabIndex = 100;
            this.cbRandSeed.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(20, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 19);
            this.label4.TabIndex = 30;
            this.label4.Text = "Random Seed";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbRandSeed
            // 
            this.tbRandSeed.Location = new System.Drawing.Point(100, 120);
            this.tbRandSeed.Name = "tbRandSeed";
            this.tbRandSeed.Size = new System.Drawing.Size(72, 20);
            this.tbRandSeed.TabIndex = 29;
            this.tbRandSeed.Text = "617788279";
            this.tbRandSeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.tbRandSeed, "Years for each time step");
            // 
            // cbSeedingAlg
            // 
            this.cbSeedingAlg.FormattingEnabled = true;
            this.cbSeedingAlg.Items.AddRange(new object[] {
            "1 WardSeedDispersal",
            "2 UniversalDispersal "});
            this.cbSeedingAlg.Location = new System.Drawing.Point(70, 94);
            this.cbSeedingAlg.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbSeedingAlg.Name = "cbSeedingAlg";
            this.cbSeedingAlg.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbSeedingAlg.Size = new System.Drawing.Size(99, 21);
            this.cbSeedingAlg.TabIndex = 28;
            this.toolTip.SetToolTip(this.cbSeedingAlg, "Seeding method");
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 30);
            this.label2.TabIndex = 11;
            this.label2.Text = "Seeding Algorithm";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbStartYr
            // 
            this.tbStartYr.Location = new System.Drawing.Point(100, 46);
            this.tbStartYr.Name = "tbStartYr";
            this.tbStartYr.Size = new System.Drawing.Size(40, 20);
            this.tbStartYr.TabIndex = 9;
            this.tbStartYr.Text = "2000";
            this.tbStartYr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.tbStartYr, "Year when simulation starts");
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "Timestep";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbTimestep
            // 
            this.tbTimestep.Location = new System.Drawing.Point(100, 68);
            this.tbTimestep.Name = "tbTimestep";
            this.tbTimestep.Size = new System.Drawing.Size(40, 20);
            this.tbTimestep.TabIndex = 7;
            this.tbTimestep.Text = "10";
            this.tbTimestep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.tbTimestep, "Years for each time step");
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(6, 46);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(56, 19);
            this.label39.TabIndex = 6;
            this.label39.Text = "Start Year";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbSimYears
            // 
            this.tbSimYears.Location = new System.Drawing.Point(100, 25);
            this.tbSimYears.Name = "tbSimYears";
            this.tbSimYears.Size = new System.Drawing.Size(40, 20);
            this.tbSimYears.TabIndex = 5;
            this.tbSimYears.Text = "50";
            this.tbSimYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.tbSimYears, "Length of simulation in years");
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(6, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 16);
            this.label13.TabIndex = 4;
            this.label13.Text = "Simulation Years";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 19);
            this.label3.TabIndex = 13;
            this.label3.Text = "Latitude";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(58, 48);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(40, 20);
            this.textBox2.TabIndex = 12;
            this.textBox2.Text = "42";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.textBox2, "Site latitude (degree)");
            // 
            // cbExtensionOption
            // 
            this.cbExtensionOption.FormattingEnabled = true;
            this.cbExtensionOption.Items.AddRange(new object[] {
            "PnET-Succession",
            "PnET-CN-Succession",
            "Age only",
            "Biomass"});
            this.cbExtensionOption.Location = new System.Drawing.Point(69, 20);
            this.cbExtensionOption.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbExtensionOption.Name = "cbExtensionOption";
            this.cbExtensionOption.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbExtensionOption.Size = new System.Drawing.Size(132, 21);
            this.cbExtensionOption.TabIndex = 3;
            // 
            // labelSuccession
            // 
            this.labelSuccession.Location = new System.Drawing.Point(4, 20);
            this.labelSuccession.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelSuccession.Name = "labelSuccession";
            this.labelSuccession.Size = new System.Drawing.Size(65, 15);
            this.labelSuccession.TabIndex = 25;
            this.labelSuccession.Text = "Succession";
            this.labelSuccession.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBoxExtensions
            // 
            this.groupBoxExtensions.Controls.Add(this.labelDisturbance);
            this.groupBoxExtensions.Controls.Add(this.checkedListBox1);
            this.groupBoxExtensions.Controls.Add(this.labelSuccession);
            this.groupBoxExtensions.Controls.Add(this.cbExtensionOption);
            this.groupBoxExtensions.Location = new System.Drawing.Point(3, 48);
            this.groupBoxExtensions.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxExtensions.Name = "groupBoxExtensions";
            this.groupBoxExtensions.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxExtensions.Size = new System.Drawing.Size(210, 125);
            this.groupBoxExtensions.TabIndex = 26;
            this.groupBoxExtensions.TabStop = false;
            this.groupBoxExtensions.Text = "Extensions";
            // 
            // labelDisturbance
            // 
            this.labelDisturbance.Location = new System.Drawing.Point(4, 45);
            this.labelDisturbance.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelDisturbance.Name = "labelDisturbance";
            this.labelDisturbance.Size = new System.Drawing.Size(65, 15);
            this.labelDisturbance.TabIndex = 27;
            this.labelDisturbance.Text = "Disturbance";
            this.labelDisturbance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Base Fire",
            "Base Wind",
            "Base Harvest",
            "Base BDA"});
            this.checkedListBox1.Location = new System.Drawing.Point(69, 45);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(132, 64);
            this.checkedListBox1.TabIndex = 26;
            // 
            // groupBoxEcoPara
            // 
            this.groupBoxEcoPara.Controls.Add(this.btDeleteEcoPara);
            this.groupBoxEcoPara.Controls.Add(this.textBox2);
            this.groupBoxEcoPara.Controls.Add(this.label3);
            this.groupBoxEcoPara.Controls.Add(this.cbEcoPara);
            this.groupBoxEcoPara.Controls.Add(this.btAddEcoPara);
            this.groupBoxEcoPara.Controls.Add(this.dataGridViewEcoPara);
            this.groupBoxEcoPara.Controls.Add(this.tbClimateFile);
            this.groupBoxEcoPara.Controls.Add(this.btClimate);
            this.groupBoxEcoPara.Location = new System.Drawing.Point(400, 48);
            this.groupBoxEcoPara.Name = "groupBoxEcoPara";
            this.groupBoxEcoPara.Size = new System.Drawing.Size(202, 184);
            this.groupBoxEcoPara.TabIndex = 27;
            this.groupBoxEcoPara.TabStop = false;
            this.groupBoxEcoPara.Text = "Ecoregion Parameters";
            // 
            // btDeleteEcoPara
            // 
            this.btDeleteEcoPara.Location = new System.Drawing.Point(136, 67);
            this.btDeleteEcoPara.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btDeleteEcoPara.Name = "btDeleteEcoPara";
            this.btDeleteEcoPara.Size = new System.Drawing.Size(53, 23);
            this.btDeleteEcoPara.TabIndex = 39;
            this.btDeleteEcoPara.Text = "Delete";
            this.btDeleteEcoPara.UseVisualStyleBackColor = true;
            this.btDeleteEcoPara.Click += new System.EventHandler(this.btDeleteEcoPara_Click);
            // 
            // cbEcoPara
            // 
            this.cbEcoPara.FormattingEnabled = true;
            this.cbEcoPara.Location = new System.Drawing.Point(58, 70);
            this.cbEcoPara.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbEcoPara.Name = "cbEcoPara";
            this.cbEcoPara.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbEcoPara.Size = new System.Drawing.Size(72, 21);
            this.cbEcoPara.TabIndex = 38;
            this.toolTip.SetToolTip(this.cbEcoPara, "Ecoregion Parameters");
            // 
            // btAddEcoPara
            // 
            this.btAddEcoPara.Location = new System.Drawing.Point(10, 67);
            this.btAddEcoPara.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btAddEcoPara.Name = "btAddEcoPara";
            this.btAddEcoPara.Size = new System.Drawing.Size(43, 23);
            this.btAddEcoPara.TabIndex = 32;
            this.btAddEcoPara.Text = "Add";
            this.btAddEcoPara.UseVisualStyleBackColor = true;
            this.btAddEcoPara.Click += new System.EventHandler(this.btAddEcoPara_Click);
            // 
            // dataGridViewEcoPara
            // 
            this.dataGridViewEcoPara.AllowUserToAddRows = false;
            this.dataGridViewEcoPara.AllowUserToOrderColumns = true;
            this.dataGridViewEcoPara.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEcoPara.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEcoPara.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridViewEcoPara.Location = new System.Drawing.Point(6, 96);
            this.dataGridViewEcoPara.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewEcoPara.Name = "dataGridViewEcoPara";
            this.dataGridViewEcoPara.RowHeadersWidth = 51;
            this.dataGridViewEcoPara.RowTemplate.Height = 24;
            this.dataGridViewEcoPara.Size = new System.Drawing.Size(190, 83);
            this.dataGridViewEcoPara.TabIndex = 37;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Parameter";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Value";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // tbClimateFile
            // 
            this.tbClimateFile.Location = new System.Drawing.Point(84, 23);
            this.tbClimateFile.Name = "tbClimateFile";
            this.tbClimateFile.Size = new System.Drawing.Size(116, 20);
            this.tbClimateFile.TabIndex = 29;
            this.tbClimateFile.Text = "site_climate.txt";
            this.toolTip.SetToolTip(this.tbClimateFile, "Climate File Path");
            // 
            // btClimate
            // 
            this.btClimate.Location = new System.Drawing.Point(6, 21);
            this.btClimate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btClimate.Name = "btClimate";
            this.btClimate.Size = new System.Drawing.Size(76, 22);
            this.btClimate.TabIndex = 36;
            this.btClimate.Text = "Load Climate";
            this.btClimate.UseVisualStyleBackColor = true;
            this.btClimate.Click += new System.EventHandler(this.btClimate_Click);
            // 
            // cbSppGenericPara
            // 
            this.cbSppGenericPara.FormattingEnabled = true;
            this.cbSppGenericPara.Items.AddRange(new object[] {
            "Customize",
            "SoilType",
            "RootingDepth",
            "PreLossFrac",
            "SnowSublimFrac",
            "LeakageFrac",
            "Kho"});
            this.cbSppGenericPara.Location = new System.Drawing.Point(59, 25);
            this.cbSppGenericPara.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbSppGenericPara.Name = "cbSppGenericPara";
            this.cbSppGenericPara.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbSppGenericPara.Size = new System.Drawing.Size(72, 21);
            this.cbSppGenericPara.TabIndex = 42;
            this.toolTip.SetToolTip(this.cbSppGenericPara, "Parameters");
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // dataGridViewSppLifeHistory
            // 
            this.dataGridViewSppLifeHistory.AllowUserToAddRows = false;
            this.dataGridViewSppLifeHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSppLifeHistory.Location = new System.Drawing.Point(10, 17);
            this.dataGridViewSppLifeHistory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewSppLifeHistory.Name = "dataGridViewSppLifeHistory";
            this.dataGridViewSppLifeHistory.RowHeadersWidth = 51;
            this.dataGridViewSppLifeHistory.RowTemplate.Height = 24;
            this.dataGridViewSppLifeHistory.Size = new System.Drawing.Size(686, 122);
            this.dataGridViewSppLifeHistory.TabIndex = 28;
            // 
            // btAddSppLifeHistorySpp
            // 
            this.btAddSppLifeHistorySpp.Location = new System.Drawing.Point(701, 72);
            this.btAddSppLifeHistorySpp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btAddSppLifeHistorySpp.Name = "btAddSppLifeHistorySpp";
            this.btAddSppLifeHistorySpp.Size = new System.Drawing.Size(101, 22);
            this.btAddSppLifeHistorySpp.TabIndex = 29;
            this.btAddSppLifeHistorySpp.Text = "Add Species";
            this.btAddSppLifeHistorySpp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAddSppLifeHistorySpp.UseVisualStyleBackColor = true;
            this.btAddSppLifeHistorySpp.Click += new System.EventHandler(this.btAddSppLifeHistorySpp_Click);
            // 
            // btAddSppLifeHistoryPara
            // 
            this.btAddSppLifeHistoryPara.Location = new System.Drawing.Point(701, 16);
            this.btAddSppLifeHistoryPara.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btAddSppLifeHistoryPara.Name = "btAddSppLifeHistoryPara";
            this.btAddSppLifeHistoryPara.Size = new System.Drawing.Size(99, 22);
            this.btAddSppLifeHistoryPara.TabIndex = 30;
            this.btAddSppLifeHistoryPara.Text = "Add Parameter";
            this.btAddSppLifeHistoryPara.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAddSppLifeHistoryPara.UseVisualStyleBackColor = true;
            this.btAddSppLifeHistoryPara.Click += new System.EventHandler(this.btAddSppLifeHistoryPara_Click);
            // 
            // groupBoxAddEcoPara
            // 
            this.groupBoxAddEcoPara.Controls.Add(this.btDeleteSppGeneric);
            this.groupBoxAddEcoPara.Controls.Add(this.dataGridViewSppGeneric);
            this.groupBoxAddEcoPara.Controls.Add(this.cbSppGenericPara);
            this.groupBoxAddEcoPara.Controls.Add(this.btAddSpeciesGenericPara);
            this.groupBoxAddEcoPara.Location = new System.Drawing.Point(608, 48);
            this.groupBoxAddEcoPara.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxAddEcoPara.Name = "groupBoxAddEcoPara";
            this.groupBoxAddEcoPara.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxAddEcoPara.Size = new System.Drawing.Size(200, 184);
            this.groupBoxAddEcoPara.TabIndex = 31;
            this.groupBoxAddEcoPara.TabStop = false;
            this.groupBoxAddEcoPara.Text = "Species:Generic";
            // 
            // btDeleteSppGeneric
            // 
            this.btDeleteSppGeneric.Location = new System.Drawing.Point(138, 23);
            this.btDeleteSppGeneric.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btDeleteSppGeneric.Name = "btDeleteSppGeneric";
            this.btDeleteSppGeneric.Size = new System.Drawing.Size(53, 23);
            this.btDeleteSppGeneric.TabIndex = 43;
            this.btDeleteSppGeneric.Text = "Delete";
            this.btDeleteSppGeneric.UseVisualStyleBackColor = true;
            this.btDeleteSppGeneric.Click += new System.EventHandler(this.btDeleteSppGeneric_Click);
            // 
            // dataGridViewSppGeneric
            // 
            this.dataGridViewSppGeneric.AllowUserToAddRows = false;
            this.dataGridViewSppGeneric.AllowUserToOrderColumns = true;
            this.dataGridViewSppGeneric.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSppGeneric.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSppGeneric.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dataGridViewSppGeneric.Location = new System.Drawing.Point(10, 54);
            this.dataGridViewSppGeneric.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewSppGeneric.Name = "dataGridViewSppGeneric";
            this.dataGridViewSppGeneric.RowHeadersWidth = 51;
            this.dataGridViewSppGeneric.RowTemplate.Height = 24;
            this.dataGridViewSppGeneric.Size = new System.Drawing.Size(181, 126);
            this.dataGridViewSppGeneric.TabIndex = 41;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Parameter";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Value";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // btAddSpeciesGenericPara
            // 
            this.btAddSpeciesGenericPara.Location = new System.Drawing.Point(12, 23);
            this.btAddSpeciesGenericPara.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btAddSpeciesGenericPara.Name = "btAddSpeciesGenericPara";
            this.btAddSpeciesGenericPara.Size = new System.Drawing.Size(43, 23);
            this.btAddSpeciesGenericPara.TabIndex = 40;
            this.btAddSpeciesGenericPara.Text = "Add";
            this.btAddSpeciesGenericPara.UseVisualStyleBackColor = true;
            this.btAddSpeciesGenericPara.Click += new System.EventHandler(this.btAddSpeciesGenericPara_Click);
            // 
            // btDeleteSppLifeHistoryPara
            // 
            this.btDeleteSppLifeHistoryPara.Location = new System.Drawing.Point(701, 43);
            this.btDeleteSppLifeHistoryPara.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btDeleteSppLifeHistoryPara.Name = "btDeleteSppLifeHistoryPara";
            this.btDeleteSppLifeHistoryPara.Size = new System.Drawing.Size(101, 24);
            this.btDeleteSppLifeHistoryPara.TabIndex = 32;
            this.btDeleteSppLifeHistoryPara.Text = "Delete Parameter";
            this.btDeleteSppLifeHistoryPara.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDeleteSppLifeHistoryPara.UseVisualStyleBackColor = true;
            this.btDeleteSppLifeHistoryPara.Click += new System.EventHandler(this.btDeleteSppLifeHistoryPara_Click);
            // 
            // btDeleteSppLifeHistorySpp
            // 
            this.btDeleteSppLifeHistorySpp.Location = new System.Drawing.Point(701, 99);
            this.btDeleteSppLifeHistorySpp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btDeleteSppLifeHistorySpp.Name = "btDeleteSppLifeHistorySpp";
            this.btDeleteSppLifeHistorySpp.Size = new System.Drawing.Size(101, 24);
            this.btDeleteSppLifeHistorySpp.TabIndex = 32;
            this.btDeleteSppLifeHistorySpp.Text = "Delete Species";
            this.btDeleteSppLifeHistorySpp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDeleteSppLifeHistorySpp.UseVisualStyleBackColor = true;
            this.btDeleteSppLifeHistorySpp.Click += new System.EventHandler(this.btDeleteSppLifeHistorySpp_Click);
            // 
            // groupBoxSppLifeHistory
            // 
            this.groupBoxSppLifeHistory.Controls.Add(this.btDeleteSppLifeHistorySpp);
            this.groupBoxSppLifeHistory.Controls.Add(this.btAddSppLifeHistorySpp);
            this.groupBoxSppLifeHistory.Controls.Add(this.btDeleteSppLifeHistoryPara);
            this.groupBoxSppLifeHistory.Controls.Add(this.dataGridViewSppLifeHistory);
            this.groupBoxSppLifeHistory.Controls.Add(this.btAddSppLifeHistoryPara);
            this.groupBoxSppLifeHistory.Location = new System.Drawing.Point(3, 232);
            this.groupBoxSppLifeHistory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxSppLifeHistory.Name = "groupBoxSppLifeHistory";
            this.groupBoxSppLifeHistory.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxSppLifeHistory.Size = new System.Drawing.Size(805, 148);
            this.groupBoxSppLifeHistory.TabIndex = 40;
            this.groupBoxSppLifeHistory.TabStop = false;
            this.groupBoxSppLifeHistory.Text = "Species:Life History";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btDeleteSppEcophysiSpp);
            this.groupBox1.Controls.Add(this.btAddSppEcophysiSpp);
            this.groupBox1.Controls.Add(this.btDeleteSppEcophysiPara);
            this.groupBox1.Controls.Add(this.dataGridViewSppEcophysi);
            this.groupBox1.Controls.Add(this.btAddSppEcophysiPara);
            this.groupBox1.Location = new System.Drawing.Point(3, 382);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(805, 148);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Species:Ecophysiological";
            // 
            // btDeleteSppEcophysiSpp
            // 
            this.btDeleteSppEcophysiSpp.Location = new System.Drawing.Point(701, 99);
            this.btDeleteSppEcophysiSpp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btDeleteSppEcophysiSpp.Name = "btDeleteSppEcophysiSpp";
            this.btDeleteSppEcophysiSpp.Size = new System.Drawing.Size(101, 24);
            this.btDeleteSppEcophysiSpp.TabIndex = 32;
            this.btDeleteSppEcophysiSpp.Text = "Delete Species";
            this.btDeleteSppEcophysiSpp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDeleteSppEcophysiSpp.UseVisualStyleBackColor = true;
            this.btDeleteSppEcophysiSpp.Click += new System.EventHandler(this.btDeleteSppEcophysiSpp_Click);
            // 
            // btAddSppEcophysiSpp
            // 
            this.btAddSppEcophysiSpp.Location = new System.Drawing.Point(701, 72);
            this.btAddSppEcophysiSpp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btAddSppEcophysiSpp.Name = "btAddSppEcophysiSpp";
            this.btAddSppEcophysiSpp.Size = new System.Drawing.Size(101, 22);
            this.btAddSppEcophysiSpp.TabIndex = 29;
            this.btAddSppEcophysiSpp.Text = "Add Species";
            this.btAddSppEcophysiSpp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAddSppEcophysiSpp.UseVisualStyleBackColor = true;
            this.btAddSppEcophysiSpp.Click += new System.EventHandler(this.btAddSppEcophysiSpp_Click);
            // 
            // btDeleteSppEcophysiPara
            // 
            this.btDeleteSppEcophysiPara.Location = new System.Drawing.Point(701, 43);
            this.btDeleteSppEcophysiPara.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btDeleteSppEcophysiPara.Name = "btDeleteSppEcophysiPara";
            this.btDeleteSppEcophysiPara.Size = new System.Drawing.Size(101, 24);
            this.btDeleteSppEcophysiPara.TabIndex = 32;
            this.btDeleteSppEcophysiPara.Text = "Delete Parameter";
            this.btDeleteSppEcophysiPara.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDeleteSppEcophysiPara.UseVisualStyleBackColor = true;
            this.btDeleteSppEcophysiPara.Click += new System.EventHandler(this.btDeleteSppEcophysiPara_Click);
            // 
            // dataGridViewSppEcophysi
            // 
            this.dataGridViewSppEcophysi.AllowUserToAddRows = false;
            this.dataGridViewSppEcophysi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSppEcophysi.Location = new System.Drawing.Point(10, 17);
            this.dataGridViewSppEcophysi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewSppEcophysi.Name = "dataGridViewSppEcophysi";
            this.dataGridViewSppEcophysi.RowHeadersWidth = 51;
            this.dataGridViewSppEcophysi.RowTemplate.Height = 24;
            this.dataGridViewSppEcophysi.Size = new System.Drawing.Size(686, 122);
            this.dataGridViewSppEcophysi.TabIndex = 28;
            // 
            // btAddSppEcophysiPara
            // 
            this.btAddSppEcophysiPara.Location = new System.Drawing.Point(701, 16);
            this.btAddSppEcophysiPara.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btAddSppEcophysiPara.Name = "btAddSppEcophysiPara";
            this.btAddSppEcophysiPara.Size = new System.Drawing.Size(99, 22);
            this.btAddSppEcophysiPara.TabIndex = 30;
            this.btAddSppEcophysiPara.Text = "Add Parameter";
            this.btAddSppEcophysiPara.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAddSppEcophysiPara.UseVisualStyleBackColor = true;
            this.btAddSppEcophysiPara.Click += new System.EventHandler(this.btAddSppEcophysiPara_Click);
            // 
            // tabControlGraph
            // 
            this.tabControlGraph.Controls.Add(this.tabPageClimate);
            this.tabControlGraph.Controls.Add(this.tabPageCarbon);
            this.tabControlGraph.Controls.Add(this.tabPageWater);
            this.tabControlGraph.Controls.Add(this.tabPageNitrogen);
            this.tabControlGraph.Controls.Add(this.tabPageCohorts);
            this.tabControlGraph.Controls.Add(this.tabPageCompare);
            this.tabControlGraph.Location = new System.Drawing.Point(3, 534);
            this.tabControlGraph.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControlGraph.Name = "tabControlGraph";
            this.tabControlGraph.SelectedIndex = 0;
            this.tabControlGraph.Size = new System.Drawing.Size(700, 280);
            this.tabControlGraph.TabIndex = 42;
            // 
            // tabPageClimate
            // 
            this.tabPageClimate.Controls.Add(this.checkedListBoxClimate);
            this.tabPageClimate.Controls.Add(this.zedGraphControlClimate);
            this.tabPageClimate.Location = new System.Drawing.Point(4, 22);
            this.tabPageClimate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageClimate.Name = "tabPageClimate";
            this.tabPageClimate.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageClimate.Size = new System.Drawing.Size(692, 254);
            this.tabPageClimate.TabIndex = 0;
            this.tabPageClimate.Tag = "";
            this.tabPageClimate.Text = "Climate";
            this.tabPageClimate.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxClimate
            // 
            this.checkedListBoxClimate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxClimate.FormattingEnabled = true;
            this.checkedListBoxClimate.Items.AddRange(new object[] {
            "Tmax(C)",
            "Tmin(C)",
            "Precip(mm/mo)",
            "PAR0"});
            this.checkedListBoxClimate.Location = new System.Drawing.Point(602, 13);
            this.checkedListBoxClimate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkedListBoxClimate.Name = "checkedListBoxClimate";
            this.checkedListBoxClimate.Size = new System.Drawing.Size(84, 60);
            this.checkedListBoxClimate.TabIndex = 43;
            this.checkedListBoxClimate.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxClimate_ItemCheck);
            // 
            // zedGraphControlClimate
            // 
            this.zedGraphControlClimate.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControlClimate.Name = "zedGraphControlClimate";
            this.zedGraphControlClimate.ScrollGrace = 0D;
            this.zedGraphControlClimate.ScrollMaxX = 0D;
            this.zedGraphControlClimate.ScrollMaxY = 0D;
            this.zedGraphControlClimate.ScrollMaxY2 = 0D;
            this.zedGraphControlClimate.ScrollMinX = 0D;
            this.zedGraphControlClimate.ScrollMinY = 0D;
            this.zedGraphControlClimate.ScrollMinY2 = 0D;
            this.zedGraphControlClimate.Size = new System.Drawing.Size(584, 251);
            this.zedGraphControlClimate.TabIndex = 44;
            // 
            // tabPageCarbon
            // 
            this.tabPageCarbon.Controls.Add(this.checkedListBoxCarbon);
            this.tabPageCarbon.Controls.Add(this.zedGraphControlCarbon);
            this.tabPageCarbon.Location = new System.Drawing.Point(4, 22);
            this.tabPageCarbon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageCarbon.Name = "tabPageCarbon";
            this.tabPageCarbon.Size = new System.Drawing.Size(692, 254);
            this.tabPageCarbon.TabIndex = 2;
            this.tabPageCarbon.Text = "Carbon";
            this.tabPageCarbon.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxCarbon
            // 
            this.checkedListBoxCarbon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxCarbon.FormattingEnabled = true;
            this.checkedListBoxCarbon.Items.AddRange(new object[] {
            "Wood(gDW)",
            "Root(gDW)",
            "Fol(gDW)",
            "CWD(gDW_m2)",
            "NSC(gC)",
            "HOM",
            "GrossPsn(gC_m2_mo)"});
            this.checkedListBoxCarbon.Location = new System.Drawing.Point(602, 13);
            this.checkedListBoxCarbon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkedListBoxCarbon.Name = "checkedListBoxCarbon";
            this.checkedListBoxCarbon.Size = new System.Drawing.Size(91, 120);
            this.checkedListBoxCarbon.TabIndex = 45;
            this.checkedListBoxCarbon.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxCarbon_ItemCheck);
            // 
            // zedGraphControlCarbon
            // 
            this.zedGraphControlCarbon.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControlCarbon.Name = "zedGraphControlCarbon";
            this.zedGraphControlCarbon.ScrollGrace = 0D;
            this.zedGraphControlCarbon.ScrollMaxX = 0D;
            this.zedGraphControlCarbon.ScrollMaxY = 0D;
            this.zedGraphControlCarbon.ScrollMaxY2 = 0D;
            this.zedGraphControlCarbon.ScrollMinX = 0D;
            this.zedGraphControlCarbon.ScrollMinY = 0D;
            this.zedGraphControlCarbon.ScrollMinY2 = 0D;
            this.zedGraphControlCarbon.Size = new System.Drawing.Size(584, 251);
            this.zedGraphControlCarbon.TabIndex = 44;
            // 
            // tabPageWater
            // 
            this.tabPageWater.Location = new System.Drawing.Point(4, 22);
            this.tabPageWater.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageWater.Name = "tabPageWater";
            this.tabPageWater.Size = new System.Drawing.Size(692, 254);
            this.tabPageWater.TabIndex = 3;
            this.tabPageWater.Text = "Water";
            this.tabPageWater.UseVisualStyleBackColor = true;
            // 
            // tabPageNitrogen
            // 
            this.tabPageNitrogen.Location = new System.Drawing.Point(4, 22);
            this.tabPageNitrogen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageNitrogen.Name = "tabPageNitrogen";
            this.tabPageNitrogen.Size = new System.Drawing.Size(692, 254);
            this.tabPageNitrogen.TabIndex = 4;
            this.tabPageNitrogen.Text = "Nitrogen";
            this.tabPageNitrogen.UseVisualStyleBackColor = true;
            // 
            // tabPageCohorts
            // 
            this.tabPageCohorts.Location = new System.Drawing.Point(4, 22);
            this.tabPageCohorts.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageCohorts.Name = "tabPageCohorts";
            this.tabPageCohorts.Size = new System.Drawing.Size(692, 254);
            this.tabPageCohorts.TabIndex = 5;
            this.tabPageCohorts.Text = "Cohorts";
            this.tabPageCohorts.UseVisualStyleBackColor = true;
            // 
            // tabPageCompare
            // 
            this.tabPageCompare.Location = new System.Drawing.Point(4, 22);
            this.tabPageCompare.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageCompare.Name = "tabPageCompare";
            this.tabPageCompare.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageCompare.Size = new System.Drawing.Size(692, 254);
            this.tabPageCompare.TabIndex = 6;
            this.tabPageCompare.Text = "Compare";
            this.tabPageCompare.UseVisualStyleBackColor = true;
            // 
            // buttonRunModel
            // 
            this.buttonRunModel.Location = new System.Drawing.Point(724, 554);
            this.buttonRunModel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonRunModel.Name = "buttonRunModel";
            this.buttonRunModel.Size = new System.Drawing.Size(51, 32);
            this.buttonRunModel.TabIndex = 43;
            this.buttonRunModel.Text = "Run";
            this.buttonRunModel.UseVisualStyleBackColor = true;
            this.buttonRunModel.Click += new System.EventHandler(this.MenuRun_Click);
            // 
            // buttonClearGraph
            // 
            this.buttonClearGraph.Location = new System.Drawing.Point(724, 592);
            this.buttonClearGraph.Name = "buttonClearGraph";
            this.buttonClearGraph.Size = new System.Drawing.Size(76, 26);
            this.buttonClearGraph.TabIndex = 44;
            this.buttonClearGraph.Text = "Clear Graphs";
            this.buttonClearGraph.UseVisualStyleBackColor = true;
            this.buttonClearGraph.Click += new System.EventHandler(this.buttonClearGraph_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(832, 817);
            this.Controls.Add(this.buttonClearGraph);
            this.Controls.Add(this.buttonRunModel);
            this.Controls.Add(this.tabControlGraph);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxAddEcoPara);
            this.Controls.Add(this.groupBoxEcoPara);
            this.Controls.Add(this.groupBoxExtensions);
            this.Controls.Add(this.groupBoxPara);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.groupBoxSppLifeHistory);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormMain";
            this.Text = "LANDIS-II-SiteV3.0";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.groupBoxPara.ResumeLayout(false);
            this.groupBoxPara.PerformLayout();
            this.groupBoxExtensions.ResumeLayout(false);
            this.groupBoxEcoPara.ResumeLayout(false);
            this.groupBoxEcoPara.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEcoPara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSppLifeHistory)).EndInit();
            this.groupBoxAddEcoPara.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSppGeneric)).EndInit();
            this.groupBoxSppLifeHistory.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSppEcophysi)).EndInit();
            this.tabControlGraph.ResumeLayout(false);
            this.tabPageClimate.ResumeLayout(false);
            this.tabPageCarbon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuProject;
        private System.Windows.Forms.ToolStripMenuItem MenuOpen;
        private System.Windows.Forms.ToolStripMenuItem MenuSave;
        private System.Windows.Forms.ToolStripMenuItem MenuRun;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuExit;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripOpen;
        private System.Windows.Forms.ToolStripButton toolStripSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripRun;
        private System.Windows.Forms.GroupBox groupBoxPara;
        private System.Windows.Forms.TextBox tbTimestep;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox tbSimYears;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbExtensionOption;
        private System.Windows.Forms.Label labelSuccession;
        private System.Windows.Forms.GroupBox groupBoxExtensions;
        private System.Windows.Forms.Label labelDisturbance;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.TextBox tbStartYr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSeedingAlg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxEcoPara;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button btClimate;
        private System.Windows.Forms.TextBox tbClimateFile;
        private System.Windows.Forms.ToolStripMenuItem MenuUserGuide;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonUserGuide;
        private System.Windows.Forms.ToolStripMenuItem outputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportOutputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem plotResultsToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewSppLifeHistory;
        private System.Windows.Forms.Button btAddSppLifeHistorySpp;
        private System.Windows.Forms.Button btAddSppLifeHistoryPara;
        private System.Windows.Forms.Button btAddEcoPara;
        private System.Windows.Forms.DataGridView dataGridViewEcoPara;
        private System.Windows.Forms.GroupBox groupBoxAddEcoPara;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.ComboBox cbEcoPara;
        private System.Windows.Forms.Button btDeleteEcoPara;
        private System.Windows.Forms.Button btDeleteSppLifeHistoryPara;
        private System.Windows.Forms.Button btDeleteSppLifeHistorySpp;
        private System.Windows.Forms.GroupBox groupBoxSppLifeHistory;
        private System.Windows.Forms.Button btDeleteSppGeneric;
        private System.Windows.Forms.DataGridView dataGridViewSppGeneric;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.ComboBox cbSppGenericPara;
        private System.Windows.Forms.Button btAddSpeciesGenericPara;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbRandSeed;
        private System.Windows.Forms.CheckBox cbRandSeed;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btDeleteSppEcophysiSpp;
        private System.Windows.Forms.Button btAddSppEcophysiSpp;
        private System.Windows.Forms.Button btDeleteSppEcophysiPara;
        private System.Windows.Forms.DataGridView dataGridViewSppEcophysi;
        private System.Windows.Forms.Button btAddSppEcophysiPara;
        private System.Windows.Forms.TabControl tabControlGraph;
        private System.Windows.Forms.TabPage tabPageClimate;
        private ZedGraph.ZedGraphControl zedGraphControlClimate;
        private System.Windows.Forms.TabPage tabPageCarbon;
        private System.Windows.Forms.TabPage tabPageWater;
        private System.Windows.Forms.TabPage tabPageNitrogen;
        private System.Windows.Forms.TabPage tabPageCohorts;
        private System.Windows.Forms.CheckedListBox checkedListBoxClimate;
        private System.Windows.Forms.CheckedListBox checkedListBoxCarbon;
        private ZedGraph.ZedGraphControl zedGraphControlCarbon;
        private System.Windows.Forms.TabPage tabPageCompare;
        private System.Windows.Forms.ToolStripMenuItem exportInputForLANDISIIToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonExportOutput;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Button buttonRunModel;
        private System.Windows.Forms.Button buttonClearGraph;
    }
}

