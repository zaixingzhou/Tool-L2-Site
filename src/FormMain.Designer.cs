namespace LANDIS_II_Site
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
            this.outputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSaveOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBuildLandisInput = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuScenarios = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemLUI = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuUserGuide = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonExportOutput = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonUserGuide = new System.Windows.Forms.ToolStripButton();
            this.cbSuccessionOption = new System.Windows.Forms.ComboBox();
            this.labelSuccession = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonRunModel = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.panelExtension = new System.Windows.Forms.Panel();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuProject,
            this.outputToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1300, 28);
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
            this.MenuProject.Size = new System.Drawing.Size(69, 24);
            this.MenuProject.Text = "&Project";
            // 
            // MenuOpen
            // 
            this.MenuOpen.Name = "MenuOpen";
            this.MenuOpen.Size = new System.Drawing.Size(137, 26);
            this.MenuOpen.Text = "&Open...";
            this.MenuOpen.Click += new System.EventHandler(this.MenuOpen_Click);
            // 
            // MenuSave
            // 
            this.MenuSave.Name = "MenuSave";
            this.MenuSave.Size = new System.Drawing.Size(137, 26);
            this.MenuSave.Text = "&Save...";
            this.MenuSave.Click += new System.EventHandler(this.MenuSave_Click);
            // 
            // MenuRun
            // 
            this.MenuRun.Name = "MenuRun";
            this.MenuRun.Size = new System.Drawing.Size(137, 26);
            this.MenuRun.Text = "&Run";
            this.MenuRun.Click += new System.EventHandler(this.MenuRun_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(134, 6);
            // 
            // MenuExit
            // 
            this.MenuExit.Name = "MenuExit";
            this.MenuExit.Size = new System.Drawing.Size(137, 26);
            this.MenuExit.Text = "&Exit";
            this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
            // 
            // outputToolStripMenuItem
            // 
            this.outputToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuSaveOutput});
            this.outputToolStripMenuItem.Name = "outputToolStripMenuItem";
            this.outputToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.outputToolStripMenuItem.Text = "&Output";
            // 
            // MenuSaveOutput
            // 
            this.MenuSaveOutput.Name = "MenuSaveOutput";
            this.MenuSaveOutput.Size = new System.Drawing.Size(194, 26);
            this.MenuSaveOutput.Text = "&Export Output...";
            this.MenuSaveOutput.Click += new System.EventHandler(this.MenuSaveOutput_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuBuildLandisInput,
            this.MenuScenarios,
            this.ToolStripMenuItemLUI});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // MenuBuildLandisInput
            // 
            this.MenuBuildLandisInput.Name = "MenuBuildLandisInput";
            this.MenuBuildLandisInput.Size = new System.Drawing.Size(286, 26);
            this.MenuBuildLandisInput.Text = "&Build LANDIS Input Package...";
            this.MenuBuildLandisInput.Click += new System.EventHandler(this.MenuBuildLandisInput_Click);
            // 
            // MenuScenarios
            // 
            this.MenuScenarios.Name = "MenuScenarios";
            this.MenuScenarios.Size = new System.Drawing.Size(286, 26);
            this.MenuScenarios.Text = "&Scenarios";
            this.MenuScenarios.Click += new System.EventHandler(this.MenuScenarios_Click);
            // 
            // ToolStripMenuItemLUI
            // 
            this.ToolStripMenuItemLUI.Name = "ToolStripMenuItemLUI";
            this.ToolStripMenuItemLUI.Size = new System.Drawing.Size(286, 26);
            this.ToolStripMenuItemLUI.Text = "&Landis User Interface";
            this.ToolStripMenuItemLUI.Click += new System.EventHandler(this.ToolStripMenuItemLUI_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuUserGuide,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // MenuUserGuide
            // 
            this.MenuUserGuide.Name = "MenuUserGuide";
            this.MenuUserGuide.Size = new System.Drawing.Size(164, 26);
            this.MenuUserGuide.Text = "&User Guide";
            this.MenuUserGuide.Click += new System.EventHandler(this.MenuUserGuide_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
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
            this.toolStripButtonExportOutput,
            this.toolStripSeparator4,
            this.toolStripButtonUserGuide});
            this.toolStrip.Location = new System.Drawing.Point(0, 28);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1300, 27);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip";
            // 
            // toolStripOpen
            // 
            this.toolStripOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripOpen.Image")));
            this.toolStripOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripOpen.Name = "toolStripOpen";
            this.toolStripOpen.Size = new System.Drawing.Size(49, 24);
            this.toolStripOpen.Text = "Open";
            this.toolStripOpen.Click += new System.EventHandler(this.MenuOpen_Click);
            // 
            // toolStripSave
            // 
            this.toolStripSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSave.Image")));
            this.toolStripSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSave.Name = "toolStripSave";
            this.toolStripSave.Size = new System.Drawing.Size(44, 24);
            this.toolStripSave.Text = "Save";
            this.toolStripSave.Click += new System.EventHandler(this.MenuSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButtonExportOutput
            // 
            this.toolStripButtonExportOutput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonExportOutput.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonExportOutput.Image")));
            this.toolStripButtonExportOutput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExportOutput.Name = "toolStripButtonExportOutput";
            this.toolStripButtonExportOutput.Size = new System.Drawing.Size(106, 24);
            this.toolStripButtonExportOutput.Text = "Export Output";
            this.toolStripButtonExportOutput.ToolTipText = "Export output results";
            this.toolStripButtonExportOutput.Click += new System.EventHandler(this.MenuSaveOutput_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButtonUserGuide
            // 
            this.toolStripButtonUserGuide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonUserGuide.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonUserGuide.Image")));
            this.toolStripButtonUserGuide.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUserGuide.Name = "toolStripButtonUserGuide";
            this.toolStripButtonUserGuide.Size = new System.Drawing.Size(85, 24);
            this.toolStripButtonUserGuide.Text = "User Guide";
            this.toolStripButtonUserGuide.Click += new System.EventHandler(this.MenuUserGuide_Click);
            // 
            // cbSuccessionOption
            // 
            this.cbSuccessionOption.FormattingEnabled = true;
            this.cbSuccessionOption.Items.AddRange(new object[] {
            "PnET-Succession",
            "Biomass"});
            this.cbSuccessionOption.Location = new System.Drawing.Point(104, 71);
            this.cbSuccessionOption.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSuccessionOption.Name = "cbSuccessionOption";
            this.cbSuccessionOption.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbSuccessionOption.Size = new System.Drawing.Size(179, 24);
            this.cbSuccessionOption.TabIndex = 3;
            this.cbSuccessionOption.SelectedIndexChanged += new System.EventHandler(this.cbSuccessionOption_SelectedIndexChanged);
            // 
            // labelSuccession
            // 
            this.labelSuccession.Location = new System.Drawing.Point(13, 70);
            this.labelSuccession.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelSuccession.Name = "labelSuccession";
            this.labelSuccession.Size = new System.Drawing.Size(87, 22);
            this.labelSuccession.TabIndex = 25;
            this.labelSuccession.Text = "Succession";
            this.labelSuccession.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonRunModel
            // 
            this.buttonRunModel.Location = new System.Drawing.Point(306, 67);
            this.buttonRunModel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRunModel.Name = "buttonRunModel";
            this.buttonRunModel.Size = new System.Drawing.Size(82, 30);
            this.buttonRunModel.TabIndex = 43;
            this.buttonRunModel.Text = "Run";
            this.toolTip.SetToolTip(this.buttonRunModel, "Run the model");
            this.buttonRunModel.UseVisualStyleBackColor = true;
            this.buttonRunModel.Click += new System.EventHandler(this.MenuRun_Click);
            // 
            // panelExtension
            // 
            this.panelExtension.Location = new System.Drawing.Point(13, 97);
            this.panelExtension.Name = "panelExtension";
            this.panelExtension.Size = new System.Drawing.Size(1265, 1086);
            this.panelExtension.TabIndex = 49;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1300, 1200);
            this.Controls.Add(this.cbSuccessionOption);
            this.Controls.Add(this.labelSuccession);
            this.Controls.Add(this.panelExtension);
            this.Controls.Add(this.buttonRunModel);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMain";
            this.Text = "LANDIS-II-SiteV3.0";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
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
        private System.Windows.Forms.ComboBox cbSuccessionOption;
        private System.Windows.Forms.Label labelSuccession;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem MenuUserGuide;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonUserGuide;
        private System.Windows.Forms.ToolStripMenuItem outputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuSaveOutput;
        private System.Windows.Forms.ToolStripMenuItem MenuBuildLandisInput;
        private System.Windows.Forms.ToolStripButton toolStripButtonExportOutput;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Button buttonRunModel;
        private System.Windows.Forms.ToolStripMenuItem MenuScenarios;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemLUI;
        private System.Windows.Forms.Panel panelExtension;
    }
}

