
namespace LANDIS_II_Site
{
    partial class FormOutputBiomass
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbTimestep = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxMakeTable = new System.Windows.Forms.ComboBox();
            this.checkedListBoxSpecies = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSppMapNames = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxDeadPool = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 29);
            this.label1.TabIndex = 10;
            this.label1.Text = "Timestep";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbTimestep
            // 
            this.tbTimestep.Location = new System.Drawing.Point(98, 15);
            this.tbTimestep.Margin = new System.Windows.Forms.Padding(4);
            this.tbTimestep.Name = "tbTimestep";
            this.tbTimestep.Size = new System.Drawing.Size(52, 22);
            this.tbTimestep.TabIndex = 9;
            this.tbTimestep.Text = "10";
            this.tbTimestep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 23);
            this.label2.TabIndex = 12;
            this.label2.Text = "MakeTable";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxMakeTable
            // 
            this.comboBoxMakeTable.FormattingEnabled = true;
            this.comboBoxMakeTable.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.comboBoxMakeTable.Location = new System.Drawing.Point(98, 55);
            this.comboBoxMakeTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxMakeTable.Name = "comboBoxMakeTable";
            this.comboBoxMakeTable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxMakeTable.Size = new System.Drawing.Size(52, 24);
            this.comboBoxMakeTable.TabIndex = 51;
            // 
            // checkedListBoxSpecies
            // 
            this.checkedListBoxSpecies.FormattingEnabled = true;
            this.checkedListBoxSpecies.Items.AddRange(new object[] {
            "all"});
            this.checkedListBoxSpecies.Location = new System.Drawing.Point(98, 103);
            this.checkedListBoxSpecies.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkedListBoxSpecies.Name = "checkedListBoxSpecies";
            this.checkedListBoxSpecies.Size = new System.Drawing.Size(175, 72);
            this.checkedListBoxSpecies.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(13, 103);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 23);
            this.label3.TabIndex = 53;
            this.label3.Text = "Species";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(5, 188);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 23);
            this.label4.TabIndex = 54;
            this.label4.Text = "MapNames";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxSppMapNames
            // 
            this.textBoxSppMapNames.Enabled = false;
            this.textBoxSppMapNames.Location = new System.Drawing.Point(98, 189);
            this.textBoxSppMapNames.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSppMapNames.Name = "textBoxSppMapNames";
            this.textBoxSppMapNames.Size = new System.Drawing.Size(304, 22);
            this.textBoxSppMapNames.TabIndex = 55;
            this.textBoxSppMapNames.Text = "outputs/biomass/biomass-{species}-{timestep}.tif";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(98, 269);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(304, 22);
            this.textBox1.TabIndex = 57;
            this.textBox1.Text = "outputs/biomass/biomass-{species}-{timestep}.tif";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(5, 268);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 23);
            this.label5.TabIndex = 56;
            this.label5.Text = "MapNames";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxDeadPool
            // 
            this.comboBoxDeadPool.FormattingEnabled = true;
            this.comboBoxDeadPool.Items.AddRange(new object[] {
            "woody",
            "non-woody",
            "both"});
            this.comboBoxDeadPool.Location = new System.Drawing.Point(98, 231);
            this.comboBoxDeadPool.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxDeadPool.Name = "comboBoxDeadPool";
            this.comboBoxDeadPool.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxDeadPool.Size = new System.Drawing.Size(93, 24);
            this.comboBoxDeadPool.TabIndex = 59;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(13, 231);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 23);
            this.label6.TabIndex = 58;
            this.label6.Text = "DeadPools";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormOutputBiomass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 319);
            this.Controls.Add(this.comboBoxDeadPool);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxSppMapNames);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkedListBoxSpecies);
            this.Controls.Add(this.comboBoxMakeTable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbTimestep);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOutputBiomass";
            this.Text = "FormOutputBiomass";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tbTimestep;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox comboBoxMakeTable;
        public System.Windows.Forms.CheckedListBox checkedListBoxSpecies;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox textBoxSppMapNames;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox comboBoxDeadPool;
        private System.Windows.Forms.Label label6;
    }
}