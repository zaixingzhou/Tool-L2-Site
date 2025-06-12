using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using ZedGraph;
using System.IO.Compression;
using CsvHelper;
using System.Globalization;


using System.Windows.Forms;

namespace LANDIS_II_Site
{
    public partial class FormMain : Form
    {
        
        public FormBiomass GUIBiomass = new FormBiomass();
        public FormPnET GUIPnET = new FormPnET();
        public FormMain()
        {
            InitializeComponent();



            // set default values for some components
            cbSuccessionOption.SelectedIndex = 1;  // PnET-Extension
            

        }

        private void MenuExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void RunSiteTool()
        {
            string InputSuccession = cbSuccessionOption.Text;

            if (InputSuccession == "Biomass")
            {
                GUIBiomass.RunSiteTool();

            }           

        }
  
        private string OutputParentDir(ComboBox cbSuccession, Boolean control = true)
        {

            string InputSuccession = cbSuccession.Text;
            string OutputDirectory = @".\Output\Output";



            if (control) OutputDirectory = @".\Output\Output";

            return OutputDirectory;

        }


        private void MenuRun_Click(object sender, EventArgs e)
        {
            string message = "Run complete!";

 
            try 
            {
                RunSiteTool();
                MessageBox.Show(message, "Success");           
            }

            
             catch (Exception ex)
             {
                // Handle exceptions
                MessageBox.Show($"An error occurred: {ex.Message}", "Error");
             }

            

        }


             

        static void CopyDirectory(string sourceDir, string destinationDir, bool overwrite = true)
        {
            // Ensure the source directory exists
            if (!Directory.Exists(sourceDir))
            {
                throw new DirectoryNotFoundException($"Source directory does not exist: {sourceDir}");
            }

            if (Directory.Exists(destinationDir))
            {
                Directory.Delete(destinationDir, true); // true to delete recursively

            }
      
            Directory.CreateDirectory(destinationDir);
            
            

            // Copy all files
            
            foreach (string file in Directory.GetFiles(sourceDir))
            {
                string fileName = Path.GetFileName(file);
                string destFile = Path.Combine(destinationDir, fileName);
                File.Copy(file, destFile, overwrite);
            }

   


            // Copy all subdirectories
            foreach (string subDir in Directory.GetDirectories(sourceDir))
            {
                string subDirName = Path.GetFileName(subDir);
                string destSubDir = Path.Combine(destinationDir, subDirName);
                CopyDirectory(subDir, destSubDir, overwrite);
            }
        }




        private void MenuSave_Click(object sender, EventArgs e)
        {
            string selectedItem = cbSuccessionOption.Text;
            if (selectedItem == "Biomass") GUIBiomass.SaveInputSite();
            //if (selectedItem == "PnET-Succession") GUIPnET.SaveInputSite();
           // if (selectedItem == "PnET-CN-Succession") GUI_PnET();

            //SaveInputSite(); // to @"Inter\Site_input.csv"

            // Open the SaveFileDialog to get the file path
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                saveFileDialog.DefaultExt = "csv";
                saveFileDialog.AddExtension = true;
                saveFileDialog.Title = "Save Input CSV File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    //SaveInputSite(filePath);

                    string sourceFilePath = @"Inter\Site_input.csv"; // Source file path                    
                    File.Copy(sourceFilePath, filePath, overwrite: true);
                }
            }


        }



        private void MenuUserGuide_Click(object sender, EventArgs e)
        {
            //string currentDirectory = Directory.GetCurrentDirectory();
            // Specify the path to user guide PDF file
            string pdfFilePath = @".\Inter\LANDIS-II-Site User Guide.pdf";

            //MessageBox.Show($"Current Directory: {pdfFilePath}", "Message");
            try
            {

                // Open the PDF file using the default application
                Process.Start(new ProcessStartInfo
                {
                    FileName = pdfFilePath,
                    UseShellExecute = true // Ensures the file opens with the default viewer
                });
            }
            catch (Exception ex)
            {
                // Handle errors (e.g., file not found)
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show a MessageBox with "About" information
            MessageBox.Show(
                "LANDIS-II-Site Tool Version 3.0\n Brian R. Miranda; Brian R.Sturtevant; Zaixing Zhou" +
                "\n© 2024 USDA Forest Service",
                "About",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
        }

        private void MenuSaveOutput_Click(object sender, EventArgs e)
        {
            // Get the output directory where all output files generated by Landis-ii model
            string OutputDirectory = @".\Output";


            // set current directory as default
            string defaultPath = Directory.GetCurrentDirectory();

            FolderBrowserDialog SaveResultsDialog = new FolderBrowserDialog();
            SaveResultsDialog.Description = "Select a folder to save your files";
            SaveResultsDialog.SelectedPath = defaultPath;

            DialogResult result = SaveResultsDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string SaveResultsDir = SaveResultsDialog.SelectedPath;

                SaveResultsDir = SaveResultsDir + "\\Output";

                CopyDirectory(OutputDirectory, SaveResultsDir);


                //MessageBox.Show($"Current Directory: {SaveResultsDirectory}", "Message");

            }

        }

        private string Prompt(string text, string caption)
        {
            // Create a prompt dialog to get input from the user
            Form prompt = new Form
            {
                Width = 400,
                Height = 150,
                Text = caption
            };

            System.Windows.Forms.Label textLabel = new System.Windows.Forms.Label { Left = 20, Top = 20, Text = text, AutoSize = true };
            TextBox inputBox = new TextBox { Left = 20, Top = 50, Width = 340 };
            Button confirmationButton = new Button
            {
                Text = "OK",
                Left = 270,
                Width = 90,
                Top = 80,
                DialogResult = DialogResult.OK
            };

            confirmationButton.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(confirmationButton);
            prompt.AcceptButton = confirmationButton;

            return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text : null;
        }

        
        public static List<Dictionary<string, object>> ReadCsvAsDictionary(string filePath)
        {
            var records = new List<Dictionary<string, object>>();

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                // Read the headers from the first line
                string[] headers = lines[0].Split(',');

                // Process each data row
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] values = lines[i].Split(',');
                    var record = new Dictionary<string, object>();

                    for (int j = 0; j < headers.Length; j++)
                    {
                        record[headers[j]] = values[j];
                    }

                    records.Add(record);
                }
            }
            else
            {
                MessageBox.Show("CSV file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return records;
        }


  


        private static void SaveToCsv(List<Dictionary<string, double>> data, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                if (data.Count == 0)
                {
                   // Console.WriteLine("No data to write.");
                    return;
                }

                // Write headers (column names)
                var headers = data.First().Keys;
                foreach (var header in headers)
                {
                    csv.WriteField(header);
                }
                csv.NextRecord();

                // Write data rows
                foreach (var row in data)
                {
                    foreach (var key in headers)
                    {
                        csv.WriteField(row[key]);
                    }
                    csv.NextRecord();
                }
            }
        }



 
        private void MenuOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                Title = "Open CSV File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //LoadInputFromCsv(openFileDialog.FileName);
            }
        }

        private string InputDir(ComboBox cbSuccession)
        {

            string InputSuccession = cbSuccession.Text;
            string InputDirectory = @".\Input";
            InputDirectory = InputDirectory + "\\" + InputSuccession;
            return InputDirectory;

        }
        private string InterDir(ComboBox cbSuccession)
        {

            string InputSuccession = cbSuccession.Text;
            string InterDirectory = @".\Inter";
            InterDirectory = InterDirectory + "\\" + InputSuccession;
            return InterDirectory;

        }
        private void MenuBuildLandisInput_Click(object sender, EventArgs e)
        {

            
            string strSuccession = cbSuccessionOption.Text;  // get the current succesion Extension            

            string InputDirectory = InputDir(cbSuccessionOption);// get the current succesion input directory
            if (strSuccession == "Biomass") GUIBiomass.BuildLandisInput();

            // set current directory as default
            string defaultPath = Directory.GetCurrentDirectory();

            FolderBrowserDialog SaveResultsDialog = new FolderBrowserDialog();
            SaveResultsDialog.Description = "Select a folder to save your files";
            SaveResultsDialog.SelectedPath = defaultPath;
            //SaveResultsDialog.

            DialogResult result = SaveResultsDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string SaveResultsDir = SaveResultsDialog.SelectedPath;
                SaveResultsDir = SaveResultsDir + "\\" + strSuccession;

                Directory.CreateDirectory(SaveResultsDir);

                // Copy all files
                foreach (string file in Directory.GetFiles(InputDirectory))
                {
                    string fileName = Path.GetFileName(file);
                    string destFile = Path.Combine(SaveResultsDir, fileName);
                    File.Copy(file, destFile, true);
                }
            }



        }

 


        private void MenuScenarios_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                Title = "Open CSV File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    string[] lines = File.ReadAllLines(filePath);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

          
       
        // get output directory based on succession extentsion
        private string OutputDir(ComboBox cbSuccession)
        {

            string InputSuccession = cbSuccession.Text;
            string OutputDirectory = OutputParentDir(cbSuccession);

            if (InputSuccession == "PnET-Succession")
            {
                OutputDirectory = OutputDirectory + @"\PNEToutputsites\Site1";
            }
            if (InputSuccession == "Biomass")
            {
                OutputDirectory = OutputDirectory;
            }

            return OutputDirectory;

        }

      

        static void ListDictionaryToCsv(List<Dictionary<string, object>> data, string filePath)
        {
            // Check if the list is empty
            if (data == null || !data.Any())
            {
                Console.WriteLine("No data to save.");
                return;
            }
            //Console.WriteLine("No data to save.");

            // Get all unique keys as headers
            var headers = data.SelectMany(dict => dict.Keys)
                              .Distinct()
                              .ToList();

            // Write to the CSV file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Write the headers (column names)
                writer.WriteLine(string.Join(",", headers));

                // Write each dictionary as a row
                foreach (var dict in data)
                {
                    var row = headers.Select(header => dict.ContainsKey(header)
                                        ? dict[header]?.ToString() ?? "" // Handle null values
                                        : "");
                    writer.WriteLine(string.Join(",", row));
                }
            }
        }


        private void ToolStripMenuItemLUI_Click(object sender, EventArgs e)
        {
            try
            {
                // Path to the LUI .exe file you want to run
                string exePath = @".\Inter\Landis_User_Interface\LandisUserInterface.exe";

                // Configure process start information
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = exePath,
                    WindowStyle = ProcessWindowStyle.Normal // Normal window size (not maximized or minimized)
                };

                // Start the process
                Process.Start(exePath);
            }
            catch (Exception ex)
            {
                // Display any errors
                MessageBox.Show($"Failed to run the application.\n\nError: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void cbSuccessionOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = cbSuccessionOption.Text;
            if (selectedItem == "Biomass") GUI_Biommass();
            if (selectedItem == "PnET-Succession") GUI_PnET();
            if (selectedItem == "PnET-CN-Succession") GUI_PnET();
        }

        private void GUI_Biommass()
        {
            LoadFormIntoPanel(GUIBiomass);
        }

        private void GUI_PnET()
        {

            LoadFormIntoPanel(GUIPnET);
        }


        private void LoadFormIntoPanel(Form form)
        {
            
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;

            // Add form to panel
            panelExtension.Controls.Clear();
            panelExtension.Controls.Add(form);
            form.Show();

            // Resize panel to match form
            panelExtension.Size = form.Size;

            // Optional: Also resize parent form if needed
            //this.ClientSize = panelExtension.Size;
        }

     
    }
}



