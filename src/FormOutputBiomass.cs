using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LANDIS_II_Site
{
    public partial class FormOutputBiomass : Form
    {
        public FormOutputBiomass()
        {
            InitializeComponent();
            comboBoxMakeTable.SelectedIndex= 0;
            comboBoxDeadPool.SelectedIndex = 2;
            checkedListBoxSpecies.SetItemChecked(0, true);

        }

        // override the close (X) button behavior so that the form is hidden (not disposed)
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Intercept the user closing the form (via the X button or Alt+F4)
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;    // Cancel the close
                this.Hide();        // Hide instead of disposing
            }
        }
    }
}
