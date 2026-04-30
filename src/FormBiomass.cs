using CsvHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ZedGraph;

namespace LANDIS_II_Site
{
    //public FormOutput OutputForm = new FormOutput();
    public partial class FormBiomass : Form
    {
        public FormOutputBiomass OutputForm = new FormOutputBiomass();

        private string InterDirectory

        {
            get { return InterDir(); }
        }
        private string InputDirectory
        {
            get { return InputDir(); }
        }

        private string OutputFolder = @"\output";
        private string ResultSiteName;
        private string ResultSppName;

        public FormBiomass()
        {
            InitializeComponent();

            //FormOutputBiomass OutputForm = new FormOutputBiomass();

            InitializeComponentPlus();
        }




        private void InitializeComponentPlus()
        {
            // set default values for some components

            ResultSiteName = "Biomass-succession-log.csv"; // default result file name for site level output
            ResultSppName = "spp-biomass-log.csv"; // default result file name for species level output


            // load the example for initilization
            string fileName = "Site_input_example.csv";
            string FileExample = Path.Combine(InterDirectory, fileName);
            LoadInputFromCsv(FileExample);

            // Set default selected tab (carbon)

            tabControlGraph.SelectedTab = tabPageCarbon; //             

            checkedListBoxClimate.SetItemChecked(0, true);
            checkedListBoxCarbon.SetItemChecked(2, true);
            checkedListBoxComposition.SetItemChecked(0, true);

            //comboBoxCohortName.SelectedIndex = 0;
            //comboBoxCohortVar.SelectedIndex = 0;
            comboBoxCalibrationVar.SelectedIndex = 0;



            checkBoxCalibration.Checked = false;
            checkBoxCalibaration_CheckedChanged(checkBoxCalibration, EventArgs.Empty);  // manurally set

            //cbOutputBiomass.Checked = false;
            //cbOutputBiomass_CheckedChanged(cbOutputBiomass, EventArgs.Empty);  // manurally set
            //OutputForm.Hide();// hide it when open the app
        }


        private void SetDefaultCharts()
        {
            checkedListBoxClimate.SetItemChecked(0, true);
        }


        public void RunSiteTool(string InputSuccession = "Biomass")
        {
            if (!cbReplicate.Checked) // single run
            {
                BuildLandisInput();                    // build landis package

                RunLandis();                         // run the model in the traditional landis way

                CopyResultsFromLandis();              //  copy the results to the sitetool output

                LoadResultSite();                     // load site results from the sitetool output

                tabControlGraphSite();                // update the chart tabs

            }
            else
            {
                RunSiteToolReplicate(); // replicate runs
            }


        }
        private string StoreReplicate(int rep)
        {

            string SourceDirectory = OutputParentDir();
            string RepDirectory = OutputParentDir(false);    // Site Tool default output folder
                                                             //List<string> StoredDir = new List<string>();
                                                             // if (Directory.Exists(RepDirectory))Directory.Delete(RepDirectory, true); // true to delete recursively
                                                             //Directory.CreateDirectory(RepDirectory);
            RepDirectory = RepDirectory + "\\Output" + rep.ToString();
            CopyDirectory(SourceDirectory, RepDirectory);

            return RepDirectory;
        }

        private void DeletNonReplicate(List<string> StoredDir)
        {

            string targetDirectory = OutputParentDir(false);    // Site Tool default output folder
            foreach (string dir in Directory.GetDirectories(targetDirectory))
            {
                //string dirName = new DirectoryInfo(dir).Name;
                if (!StoredDir.Contains(dir, StringComparer.OrdinalIgnoreCase))
                {
                    Directory.Delete(dir, true); // true to delete recursively

                }
            }

        }


        private void RunSiteToolReplicate()
        {

            int repnum = int.Parse(tbReplicateNum.Text);
            List<string> StoredDir = new List<string>();

            BuildLandisInput();                    // build landis package 
            for (int i = 0; i < repnum; i++)
            {
                RunLandis();                            // run the model in the traditional landis way
                CopyResultsFromLandis();              //  copy the results to the sitetool output
                StoredDir.Add(StoreReplicate(i + 1)); //store sitetool output 


            }
            DeletNonReplicate(StoredDir);

            LoadResultSiteRep(ResultSiteName);                     // load site results from the sitetool output

            tabControlGraphSite();                // update the chart tabs

        }


        private void RunLandis()
        {

            string InputDirectory = InputDir();// get the current succesion input directory
            // Get the case file generated by the win interface
            string batFilePath = InputDirectory + "\\site_run.bat";

            // Create a new process
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = batFilePath,   // Specify the .bat file
                    UseShellExecute = false, // Do not use the OS shell
                    CreateNoWindow = true,   // Hide the command prompt window
                    RedirectStandardOutput = true, // Capture the output
                    RedirectStandardError = true   // Capture error messages
                }
            };

            // Start the process
            process.Start();

            // Optionally, read the output
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            // Wait for the process to finish
            //process.WaitForExit();

            // Display the output or errors in a message box
            //MessageBox.Show($"Output:\n{output}\n\nError:\n{error}", "Batch File Execution");

            // MessageBox.Show($"Model running ends", "Batch File Execution");         


        }

        private void CopyResultsFromLandis()
        {
            //string InputDirectory = InputDir();// get the current succesion input directory            
            string ResultDirectory = InputDirectory; //+ "\\output";  // Landis results

            // copy Landis results to Output directory
            string OutputDirectory = @".\Output";   // Site Tool output folder



            if (checkBoxCalibration.Checked)  // if calibration, save to a different location
            {
                OutputDirectory = OutputParentDir(false);
                CopyDirectory(ResultDirectory, OutputDirectory);

              //  LoadRecordsCalOne(OutputDirectory, ResultSiteName);

            }
            else
            {
                OutputDirectory = OutputParentDir();    // Site Tool default output folder
                CopyDirectory(ResultDirectory, OutputDirectory);

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






        private void btClimate_Click(object sender, EventArgs e)
        {
            OpenFileDialog ClimateDialog = new OpenFileDialog();
            DialogResult result = ClimateDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbClimateFile.Text = ClimateDialog.FileName;

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






        private void btAddSppLifeHistoryPara_Click(object sender, EventArgs e)
        {

            // Prompt user for column name
            string columnName = Prompt("Enter parameter name:", "Add Parameter");

            if (!string.IsNullOrEmpty(columnName))
            {
                // Add a new column to the DataGridView
                dataGridViewSppLifeHistory.Columns.Add(columnName, columnName);
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



        // initialize dataGridViewSppLifeHistory
        private void InitializeDataGridViewSppLifeHistory()
        {
            // set default values for cbSppGenericPara

            // read the data file
            string filePath = @".\Inter\Biomass\Site_Species_LH.txt"; // Path to the text file 

            if (File.Exists(filePath))
            {
                // Clear any existing items in the ComboBox
                //cbSppGenericPara.Items.Clear();

                // Read all lines from the file
                string[] lines = File.ReadAllLines(filePath);

                string[] columns = (lines[1].Trim()).Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string col in columns)
                {
                    dataGridViewSppLifeHistory.Columns.Add(col, col);
                }
                // Skip the first two lines
                for (int i = 2; i < lines.Length; i++)
                {
                    string[] records = (lines[i].Trim()).Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    dataGridViewSppLifeHistory.Rows.Add(records);
                }

            }
            else
            {
                MessageBox.Show($"{filePath} does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void btDeleteSppLifeHistoryPara_Click(object sender, EventArgs e)
        {
            if (dataGridViewSppLifeHistory.SelectedCells.Count > 0)
            {
                int selectedColumnIndex = dataGridViewSppLifeHistory.SelectedCells[0].ColumnIndex;

                if (selectedColumnIndex >= 0)
                {
                    string columnName = dataGridViewSppLifeHistory.Columns[selectedColumnIndex].Name;
                    dataGridViewSppLifeHistory.Columns.RemoveAt(selectedColumnIndex);
                    MessageBox.Show($"Column '{columnName}' has been deleted.");
                }
            }
            else
            {
                MessageBox.Show("No column selected.");
            }

        }

        private void btAddSppLifeHistorySpp_Click(object sender, EventArgs e)
        {
            dataGridViewSppLifeHistory.Rows.Add();
        }

        private void btDeleteSppLifeHistorySpp_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dataGridViewSppLifeHistory.SelectedRows.Count > 0)
            {
                // Delete the selected rows
                foreach (DataGridViewRow row in dataGridViewSppLifeHistory.SelectedRows)
                {
                    if (!row.IsNewRow) // Ensure it is not the "new row" placeholder
                    {
                        dataGridViewSppLifeHistory.Rows.Remove(row);
                    }
                }

                // Update row numbers after deletion
                //UpdateRowNumbers();
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Delete Row", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        // initialize dataGridViewSppEcophysi
        private void InitializeDataGridViewSppEcophysi()
        {
            // set default values for cbSppGenericPara

            // read the data file
            string filePath = @".\Inter\Biomass\site_Species_Phy.csv"; // Path to the text file

            if (File.Exists(filePath))
            {

                // Read all lines from the file
                string[] lines = File.ReadAllLines(filePath);

                string[] columns = (lines[0].Trim()).Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);  // note. It starts with line 0

                foreach (string col in columns)
                {
                    dataGridViewSppEcophysi.Columns.Add(col, col);
                }
                // Skip the first two lines
                for (int i = 2; i < lines.Length; i++)
                {
                    string[] records = (lines[i].Trim()).Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    dataGridViewSppEcophysi.Rows.Add(records);
                }

            }
            else
            {
                MessageBox.Show($"{filePath}does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void btAddSppEcophysiPara_Click(object sender, EventArgs e)
        {

            // Prompt user for column name
            string columnName = Prompt("Enter parameter name:", "Add Parameter");

            if (!string.IsNullOrEmpty(columnName))
            {
                // Add a new column to the DataGridView
                dataGridViewSppEcophysi.Columns.Add(columnName, columnName);
            }

        }

        private void btDeleteSppEcophysiPara_Click(object sender, EventArgs e)
        {
            if (dataGridViewSppEcophysi.SelectedCells.Count > 0)
            {
                int selectedColumnIndex = dataGridViewSppEcophysi.SelectedCells[0].ColumnIndex;

                if (selectedColumnIndex >= 0)
                {
                    string columnName = dataGridViewSppEcophysi.Columns[selectedColumnIndex].Name;
                    dataGridViewSppEcophysi.Columns.RemoveAt(selectedColumnIndex);
                    MessageBox.Show($"Column '{columnName}' has been deleted.");
                }
            }
            else
            {
                MessageBox.Show("No column selected.");
            }
        }

        private void btAddSppEcophysiSpp_Click(object sender, EventArgs e)
        {
            dataGridViewSppEcophysi.Rows.Add();
        }

        private void btDeleteSppEcophysiSpp_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dataGridViewSppEcophysi.SelectedRows.Count > 0)
            {
                // Delete the selected rows
                foreach (DataGridViewRow row in dataGridViewSppEcophysi.SelectedRows)
                {
                    if (!row.IsNewRow) // Ensure it is not the "new row" placeholder
                    {
                        dataGridViewSppEcophysi.Rows.Remove(row);
                    }
                }

                // Update row numbers after deletion
                //UpdateRowNumbers();
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Delete Row", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
                string error = filePath + " not found.";
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return records;
        }


        List<Dictionary<string, object>> RecordsSite = new List<Dictionary<string, object>>();
        List<Dictionary<string, object>> RecordsCohort = new List<Dictionary<string, object>>();
        List<Dictionary<string, object>> RecordsRef = new List<Dictionary<string, object>>();
        List<Dictionary<string, object>> RecordsCalOne = new List<Dictionary<string, object>>();
        List<Dictionary<string, object>> RecordsCohCalOne = new List<Dictionary<string, object>>();
        public void LoadResultSite(string sitename = "Site.csv")
        {
            string OutputDirectory = OutputDir();// get the current succesion output directory

            //sitename = "spp-biomass-log.csv";
            sitename = ResultSiteName;

            string filePath = Path.Combine(OutputDirectory, sitename);

            //var allresults = ReadCsvAsDictionary(filePath);
            RecordsSite = ReadCsvAsDictionary(filePath);

            if (checkBoxCalibration.Checked)  // if calibration, save to a different location
            {
                OutputDirectory = OutputParentDir(false);                

                LoadRecordsCalOne(OutputDirectory, ResultSiteName);


            }



        }

        private void LoadResultSiteRep(string sitename = "Site.csv")
        {
            //string OutputDirectory = OutputDir(cbSuccessionOption);// get the current succesion output directory


            
            string OutputDirectory = OutputParentDir(false);


            List<Dictionary<string, double>> numericalData = new List<Dictionary<string, double>>();
            List<string> headers = new List<string>();

            List<dynamic[]> allRecords = new List<dynamic[]>(); // Store all rows from each CSV file

            int repnum = int.Parse(tbReplicateNum.Text);
            //List<string> StoredDir = new List<string>();

            for (int i = 0; i < repnum; i++)
            {

                //StoredDir.Add(StoreReplicate(i + 1)); //store sitetool output 
                string RepDirectory = OutputDirectory + "\\Output" + (i + 1).ToString();
                string filePath = RepDirectory;
                //sitename = "spp-biomass-log.csv";

                filePath = Path.Combine(filePath, sitename);

                using (var reader = new StreamReader(filePath))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var records = csv.GetRecords<dynamic>().ToList();

                        if (records.Count > 0)
                        {
                            headers = ((IDictionary<string, object>)records.FirstOrDefault()).Keys.ToList(); // Get column names
                            allRecords.Add(records.ToArray());
                        }
                    }
                }
            }
            if (allRecords.Count == 0)
            {
                //Console.WriteLine("No data found.");
                return;
            }
            int numFiles = allRecords.Count;
            int numRows = allRecords[0].Length; // Assuming all files have the same row count

            // Dictionary to store sum of numeric fields
            List<Dictionary<string, double>> rowSums = new List<Dictionary<string, double>>();

            for (int i = 0; i < numRows; i++)
            {
                rowSums.Add(new Dictionary<string, double>());

                foreach (string column in headers)
                {
                    rowSums[i][column] = 0; // Initialize with zero
                }
            }

            // Aggregate numeric values row-wise
            foreach (var fileRecords in allRecords)
            {
                for (int rowIndex = 0; rowIndex < fileRecords.Length; rowIndex++)
                {
                    var row = (IDictionary<string, object>)fileRecords[rowIndex];

                    foreach (var key in headers)
                    {
                        if (double.TryParse(row[key]?.ToString(), out double value)) // Only sum numeric values
                        {
                            rowSums[rowIndex][key] += value;
                        }
                    }
                }
            }


            // Compute averages
            //Console.WriteLine("Averaged Data:");
            foreach (var row in rowSums)
            {
                var keys = row.Keys.ToList(); // Make a copy of keys to avoid modifying during iteration
                foreach (var key in keys)
                {
                    if (double.TryParse(row[key].ToString(), out _)) // Ignore string fields
                    {
                        row[key] /= numFiles;
                    }
                }

            }

            //RecordsSite = (List < Dictionary<string, object> >) rowSums.Select(row => row.ToDictionary(kvp => kvp.Key, kvp => (object)kvp.Value)).ToList();
            string filePath2 = OutputDirectory + "\\output.csv";

            SaveToCsv(rowSums, filePath2);
            RecordsSite = ReadCsvAsDictionary(filePath2);

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



        private void LoadRecordsCalOne(string OutputDirectory, string sitename = "Site.csv")
        {
            
            string OutputDirectory2 = @".\Output";
            //sitename = "spp-biomass-log.csv";

            OutputDirectory2 = OutputDirectory;
            string filePath = Path.Combine(OutputDirectory2, sitename);
            RecordsCalOne = ReadCsvAsDictionary(filePath);
            RecordsCohCalOne= ReadCsvAsDictionary(Path.Combine(OutputDirectory2, ResultSppName));

        }




        private GraphPane CreateGraph(ZedGraphControl zgc, string yLabel, List<Dictionary<string, object>> records, string Xvar, string Yvar, Color c, string LegendLabel = "Default")
        {
            GraphPane myPane = zgc.GraphPane;

            // Set the titles and axis labels

            myPane.XAxis.Title.Text = "Time";
            myPane.YAxis.Title.Text = yLabel;

            PointPairList list = new PointPairList();


            foreach (var record in records)
            {
                double _x, _y;
                double.TryParse((string)record[Xvar], out _x);
                double.TryParse((string)record[Yvar], out _y);
                //PointPair _pointPair = new PointPair(double.TryParse(Value, out OutVal)(]), (double)record[Yvar]);
                list.Add(_x, _y);

            }
            //c = Color.FromArgb(2, 0, 0, 0);
            if (LegendLabel == "Default") LegendLabel = Yvar;
            LineItem curve = myPane.AddCurve(LegendLabel, list, c, SymbolType.None);

            zgc.AxisChange();
            zgc.Invalidate();
            return myPane;
        }

        private void checkedListBoxClimate_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ZedGraphControl zgc = zedGraphControlClimate;  // carbon zgc pane
            CheckedListBox myclb = checkedListBoxClimate;    // carbon checked List Box

            var mypane = zgc.GraphPane;
            mypane.Title.Text = string.Empty;

            string Xvar = "Time";
            // Check which item is toggled
            string selectedItem = myclb.Items[e.Index].ToString();

            if (e.NewValue == CheckState.Checked)
            {
                // Show Temperature in Chart
                Color c = colorPalette[e.Index];
                mypane = CreateGraph(zgc, selectedItem, RecordsSite, Xvar, selectedItem, c);
            }
            else
            {
                // Clear Temperature Data
                CurveItem curve = mypane.CurveList[selectedItem];
                // Remove the curve from the list
                mypane.CurveList.Remove(curve);

                // Refresh the graph
                zgc.AxisChange();
                zgc.Invalidate();

            }

        }

        static Color[] colorPalette = new Color[]
        {
               Color.Red, Color.Blue,Color.Green, Color.Orange,Color.Purple,Color.Black, Color.Brown,Color.Gray,Color.Navy,Color.Magenta,

               Color.Maroon,Color.LightGreen,Color.LightGray,Color.LightSteelBlue,Color.LightYellow,Color.Violet,Color.Pink,Color.Cyan,Color.Crimson,

               Color.Coral,Color.Chocolate,Color.Chartreuse,Color.Beige,Color.BurlyWood,Color.Indigo,Color.DarkOrange,Color.Gold,Color.DarkRed,Color.CornflowerBlue,
               Color.Salmon, Color.RoyalBlue,Color.RosyBrown, Color.Sienna,Color.SeaShell,Color.Tomato, Color.Tan,Color.Lime,Color.MediumBlue,Color.MediumPurple,
               Color.Red, Color.Blue,Color.Green, Color.Orange,Color.Purple,Color.Black, Color.Brown,Color.Gray,Color.Navy,Color.Magenta,
               Color.Red, Color.Blue,Color.Green, Color.Orange,Color.Purple,Color.Black, Color.Brown,Color.Gray,Color.Navy,Color.Magenta,
               Color.Red, Color.Blue,Color.Green, Color.Orange,Color.Purple,Color.Black, Color.Brown,Color.Gray,Color.Navy,Color.Magenta,

        };
        private void checkedListBoxCarbon_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ZedGraphControl zgc = zedGraphControlCarbon;  // carbon zgc pane
            CheckedListBox myclb = checkedListBoxCarbon;    // carbon checked List Box

            var mypane = zgc.GraphPane;

            mypane.Title.Text = string.Empty;

            string Xvar = "Time";

            // Check which item is toggled
            string selectedItem = myclb.Items[e.Index].ToString();

            if (e.NewValue == CheckState.Checked)
            {
                // Show Temperature in Chart
                Color c = colorPalette[e.Index];
                mypane = CreateGraph(zgc, selectedItem, RecordsSite, Xvar, selectedItem, c);
            }
            else
            {
                // Clear Temperature Data
                CurveItem curve = mypane.CurveList[selectedItem];
                // Remove the curve from the list
                mypane.CurveList.Remove(curve);

                // Refresh the graph
                zgc.AxisChange();
                zgc.Invalidate();

            }

        }


        private void checkedListBoxWater_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ZedGraphControl zgc = zedGraphControlWater;  // carbon zgc pane
            CheckedListBox myclb = checkedListBoxWater;    // carbon checked List Box

            var mypane = zgc.GraphPane;

            mypane.Title.Text = string.Empty;

            string Xvar = "Time";

            // Check which item is toggled
            string selectedItem = myclb.Items[e.Index].ToString();

            if (e.NewValue == CheckState.Checked)
            {
                // Show Temperature in Chart
                Color c = colorPalette[e.Index];
                mypane = CreateGraph(zgc, selectedItem, RecordsSite, Xvar, selectedItem, c);
            }
            else
            {
                // Clear Temperature Data
                CurveItem curve = mypane.CurveList[selectedItem];
                // Remove the curve from the list
                mypane.CurveList.Remove(curve);

                // Refresh the graph
                zgc.AxisChange();
                zgc.Invalidate();

            }

        }

        private void btClearGraph_Click(object sender, EventArgs e)
        {


            for (int i = 0; i < checkedListBoxClimate.Items.Count; i++)
            {
                checkedListBoxClimate.SetItemChecked(i, false); // Uncheck the item
            }


            for (int i = 0; i < checkedListBoxCarbon.Items.Count; i++)
            {
                checkedListBoxCarbon.SetItemChecked(i, false); // Uncheck the item
            }
            zedGraphControlCarbon.GraphPane.CurveList.Clear();
            // Update the graph
            zedGraphControlCarbon.GraphPane.GraphObjList.Clear(); // Clear any additional objects like titles or markers
            zedGraphControlCarbon.AxisChange();
            zedGraphControlCarbon.Invalidate();

            for (int i = 0; i < checkedListBoxWater.Items.Count; i++)
            {
                checkedListBoxWater.SetItemChecked(i, false); // Uncheck the item
            }
            zedGraphControlWater.GraphPane.CurveList.Clear();
            // Update the graph
            zedGraphControlWater.GraphPane.GraphObjList.Clear(); // Clear any additional objects like titles or markers
            zedGraphControlWater.AxisChange();
            zedGraphControlWater.Invalidate();






            for (int i = 0; i < checkedListBoxComposition.Items.Count; i++)
            {
                checkedListBoxComposition.SetItemChecked(i, false); // Uncheck the item
            }

            for (int i = 0; i < checkedListBoxCompare.Items.Count; i++)
            {
                checkedListBoxCompare.SetItemChecked(i, false); // Uncheck the item
            }

            zedGraphControlCohorts.GraphPane.CurveList.Clear();
            // Update the graph
            zedGraphControlCohorts.GraphPane.GraphObjList.Clear(); // Clear any additional objects like titles or markers
            zedGraphControlCohorts.AxisChange();
            zedGraphControlCohorts.Invalidate();

            zedGraphControlCalibration.GraphPane.CurveList.Clear();
            // Update the graph
            zedGraphControlCalibration.GraphPane.GraphObjList.Clear(); // Clear any additional objects like titles or markers
            zedGraphControlCalibration.AxisChange();
            zedGraphControlCalibration.Invalidate();


            for (int i = 0; i < checkedListBoxReference.Items.Count; i++)
            {
                checkedListBoxReference.SetItemChecked(i, false); // Uncheck the item
            }

        }

        public void SaveInputSite(string filePath = @"Inter\Site_input.csv")
        {
            //filePath = "Inter\Site_input.csv"; // Path to the file
            string SuccessionOption = "Biomass"; // set for different succession extension

            string Fieldname = " ";

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Write the header row
                string csvheader = "LANDIS-II-Site-input";
                string strseperater = "<<<<<<<<<<<<<<<<<";
                writer.WriteLine(csvheader);


                ///////////////// Succession Extension
                writer.WriteLine(strseperater + "Succession Extension");
                writer.WriteLine("SuccessionExtension," + SuccessionOption);  // specific for 

                ///////////////// Disturbance Extensions
                writer.WriteLine(strseperater + "Disturbance Extension");
                foreach (var item in checkedListBoxDisturbance.CheckedItems)
                {
                    Fieldname = "Disturb";
                    string value = item.ToString();

                    int index = checkedListBoxDisturbance.Items.IndexOf(value);
                    //int index = item.IndexOf(value);
                    string strout = Fieldname + index.ToString() + "," + value;
                    writer.WriteLine(strout);
                }

                ///////////////// Output Extensions
                writer.WriteLine(strseperater + "Output Extension");

                string strtemp = cbOutputBiomass.Checked ? "Yes" : "No";
                writer.WriteLine("OutputExtension," + strtemp);
                //writer.WriteLine("RandomSeedSet," + tbRandSeed.Text);  // 


                ///////////////// Other Extensions
                writer.WriteLine(strseperater + "Other Extension");
                foreach (var item in checkedListBoxExtensionOther.CheckedItems)
                {
                    Fieldname = "OtherExtension";
                    string value = item.ToString();

                    int index = checkedListBoxExtensionOther.Items.IndexOf(value);
                    //int index = item.IndexOf(value);
                    string strout = Fieldname + index.ToString() + "," + value;
                    writer.WriteLine(strout);
                }
                /// 
                ////////////////// Simulation Parameters
                writer.WriteLine(strseperater + "Simulation Parameters");

                writer.WriteLine("SimulationYears," + tbSimYears.Text);  // simulation years
                //writer.WriteLine("StartYear," + tbStartYr.Text);  // 
                writer.WriteLine("TimeStep," + tbTimestep.Text);  // 
                writer.WriteLine("SeedingAlgorithm," + cbSeedingAlg.Text);  // 

                strtemp = cbRandSeed.Checked ? "Yes" : "No";
                writer.WriteLine("RandomSeedCheck," + strtemp);
                writer.WriteLine("RandomSeedSet," + tbRandSeed.Text);  // 

                strtemp = cbReplicate.Checked ? "Yes" : "No";
                writer.WriteLine("ReplicateCheck," + strtemp);
                writer.WriteLine("ReplicateNum," + tbReplicateNum.Text);  // 

                /////////////////save Ecoregion data
                writer.WriteLine(strseperater + "Ecoregion Parameters");
                writer.WriteLine("ClimateFile," + tbClimateFile.Text);  //
                writer.WriteLine("AET(mm)," + tbAET.Text);  //

                // SaveDataGridViewToCsv(writer, dataGridViewLightTable, false);  // save all table data

                /////////////////save Initial communities 
                writer.WriteLine(strseperater + "Initial communities");
                SaveDataGridViewToCsv(writer, dataGridViewInitialComm);  // save all table data


                /////////////////save Sufficient Light Table
                writer.WriteLine(strseperater + "Sufficient Light Table");
                // SaveDataGridViewToCsv(writer, dataGridViewLightTable, false);  // save all table data
                SaveDataGridViewToCsv(writer, dataGridViewLightTable);  // save all table data

                /////////////////save Minimum Biomass by Shade
                writer.WriteLine(strseperater + "Minimum Biomass by Shade");
                SaveDataGridViewToCsv(writer, dataGridViewMinRelativeBiomass);  // save all table data

                /////////////////save FireReductionParameters
                writer.WriteLine(strseperater + "FireReductionParameters");
                SaveDataGridViewToCsv(writer, dataGridViewFireRemove);  // save all table data

                /////////////////save HarvestReductionParameters
                writer.WriteLine(strseperater + "HarvestReductionParameters");
                SaveDataGridViewToCsv(writer, dataGridViewHarvestRemove);  // save all table data

                ///////////////// save species life history data from the table
                writer.WriteLine(strseperater + "Species Life History Parameters");
                SaveDataGridViewToCsv(writer, dataGridViewSppLifeHistory);

                //////////////// save species Ecophysiological data from the table
                writer.WriteLine(strseperater + "Species Ecophysiological Parameters");
                SaveDataGridViewToCsv(writer, dataGridViewSppEcophysi);



            }
            //MessageBox.Show("Data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void SaveDataGridViewToCsv(StreamWriter writer, DataGridView dataGridView, Boolean writeheader = true, string sep = ",")
        {

            // Write the header row
            if (writeheader)
            {
                for (int i = 0; i < dataGridView.ColumnCount; i++)
                {
                    writer.Write(dataGridView.Columns[i].HeaderText);
                    if (i < dataGridView.ColumnCount - 1) writer.Write(sep);
                }
                writer.WriteLine();

            }


            // Write the data rows
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!row.IsNewRow) // Skip the placeholder row
                {
                    for (int i = 0; i < dataGridView.ColumnCount; i++)
                    {
                        writer.Write(row.Cells[i].Value);
                        if (i < dataGridView.ColumnCount - 1) writer.Write(sep);
                    }
                    writer.WriteLine();
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
                LoadInputFromCsv(openFileDialog.FileName);
            }
        }

        public void LoadInputFromCsv(string filePath)
        {
            try
            {

                string[] lines = File.ReadAllLines(filePath);


                // Succession extension
                string[] values = lines[2].Split(','); // succession extension
                                                       // cbSuccessionOption.SelectedItem = values[1];  ZZX

                string searchPhrase = "<<";



                // Disturbance

                int startline = 4;
                int index = 0;

                for (int ii = 0; ii < checkedListBoxDisturbance.Items.Count; ii++) checkedListBoxDisturbance.SetItemChecked(ii, false);
                for (int i = startline; i < lines.Length; i++)
                {
                    if (lines[i].Contains(searchPhrase))
                    {

                        startline = i + 1;  // new start line
                        break;
                    }

                    values = lines[i].Split(',');
                    index = checkedListBoxDisturbance.Items.IndexOf(values[1]);
                    if (index >= 0)
                    {
                        checkedListBoxDisturbance.SetItemChecked(index, true);
                    }

                }

                // Output extension

                for (int i = startline; i < lines.Length; i++)
                {
                    if (lines[i].Contains(searchPhrase))
                    {
                        //cbOutputBiomass.Checked = false;
                        startline = i + 1;  // new start line
                        break;
                    }

                    values = lines[i].Split(',');
                    if (values[0] == "OutputExtension") cbOutputBiomass.Checked = values[1].Equals("Yes");


                }
                // Other extension
                for (int ii = 0; ii < checkedListBoxExtensionOther.Items.Count; ii++) checkedListBoxExtensionOther.SetItemChecked(ii, false);
                for (int i = startline; i < lines.Length; i++)
                {
                    if (lines[i].Contains(searchPhrase))
                    {
                        // for (int ii = 0; ii < checkedListBoxExtensionOther.Items.Count; ii++) checkedListBoxExtensionOther.SetItemChecked(ii, false);
                        startline = i + 1;  // new start line
                        break;
                    }

                    values = lines[i].Split(',');
                    index = checkedListBoxExtensionOther.Items.IndexOf(values[1]);
                    if (index >= 0)
                    {
                        checkedListBoxExtensionOther.SetItemChecked(index, true);
                    }

                }

                // Simulation Parameters
                for (int i = startline; i < lines.Length; i++)
                {
                    if (lines[i].Contains(searchPhrase))
                    {
                        startline = i + 1;  // new start line
                        break;
                    }

                    values = lines[i].Split(',');
                    if (values[0] == "SimulationYears") tbSimYears.Text = values[1];
                    //if (values[0] == "StartYear") tbStartYr.Text = values[1];
                    if (values[0] == "TimeStep") tbTimestep.Text = values[1];

                    if (values[0] == "SeedingAlgorithm") cbSeedingAlg.SelectedItem = values[1];
                    if (values[0] == "RandomSeedCheck") cbRandSeed.Checked = values[1].Equals("Yes");
                    if (values[0] == "RandomSeedSet") tbRandSeed.Text = values[1];
                    if (values[0] == "ReplicateCheck") cbReplicate.Checked = values[1].Equals("Yes");
                    if (values[0] == "ReplicateNum") tbReplicateNum.Text = values[1];

                }

                //var record = new Dictionary<string, object>();

                // Ecoregion Parameters

                //dataGridViewEcoPara.Rows.Clear();
                for (int i = startline; i < lines.Length; i++)
                {
                    if (lines[i].Contains(searchPhrase))
                    {
                        startline = i + 1;  // new start line
                        break;
                    }

                    values = lines[i].Split(',');
                    if (values[0] == "ClimateFile") tbClimateFile.Text = values[1];
                    if (values[0] == "AET(mm)") tbAET.Text = values[1];

                    // if (i > startline + 1) dataGridViewEcoPara.Rows.Add(values); // skip two lines above     

                }

                // Initial communities

                dataGridViewInitialComm.Rows.Clear();
                dataGridViewInitialComm.Columns.Clear();

                for (int i = startline; i < lines.Length; i++)
                {
                    if (lines[i].Contains(searchPhrase))
                    {
                        startline = i + 1;  // new start line
                        break;
                    }

                    values = lines[i].Split(',');
                    if (i == startline)
                    {
                        foreach (string col in values)
                        {
                            dataGridViewInitialComm.Columns.Add(col, col);
                        }// first line is the headers for column names
                    }
                    else dataGridViewInitialComm.Rows.Add(values);
                }
                dataGridViewInitialComm.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // SufficientLight table

                dataGridViewLightTable.Rows.Clear();
                dataGridViewLightTable.Columns.Clear();
                for (int i = startline; i < lines.Length; i++)
                {
                    if (lines[i].Contains(searchPhrase))
                    {
                        startline = i + 1;  // new start line
                        break;
                    }

                    values = lines[i].Split(',');
                    if (i == startline)
                    {
                        foreach (string col in values)
                        {
                            dataGridViewLightTable.Columns.Add(col, col);
                        }// first line is the headers for column names
                    }
                    else dataGridViewLightTable.Rows.Add(values);

                }

                dataGridViewLightTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;

                // MinRelativeBiomass table
                /**/
                dataGridViewMinRelativeBiomass.Rows.Clear();
                dataGridViewMinRelativeBiomass.Columns.Clear();
                for (int i = startline; i < lines.Length; i++)
                {
                    if (lines[i].Contains(searchPhrase))
                    {
                        startline = i + 1;  // new start line
                        break;
                    }

                    values = lines[i].Split(',');
                    if (i == startline)
                    {
                        foreach (string col in values)
                        {
                            dataGridViewMinRelativeBiomass.Columns.Add(col, col);
                        }// first line is the headers for column names
                    }
                    else dataGridViewMinRelativeBiomass.Rows.Add(values);

                }

                dataGridViewMinRelativeBiomass.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;

                // Fire FireReductionParameters 
                dataGridViewFireRemove.Rows.Clear();
                dataGridViewFireRemove.Columns.Clear();
                for (int i = startline; i < lines.Length; i++)
                {
                    if (lines[i].Contains(searchPhrase))
                    {
                        startline = i + 1;  // new start line
                        break;
                    }

                    values = lines[i].Split(',');
                    if (i == startline)
                    {
                        foreach (string col in values)
                        {
                            dataGridViewFireRemove.Columns.Add(col, col);
                        }// first line is the headers for column names
                    }
                    else dataGridViewFireRemove.Rows.Add(values);

                }

                dataGridViewFireRemove.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;

                // HarvestReductionParameters
                dataGridViewHarvestRemove.Rows.Clear();
                dataGridViewHarvestRemove.Columns.Clear();
                for (int i = startline; i < lines.Length; i++)
                {
                    if (lines[i].Contains(searchPhrase))
                    {
                        startline = i + 1;  // new start line
                        break;
                    }

                    values = lines[i].Split(',');

                    if (i == startline)
                    {
                        foreach (string col in values)
                        {
                            dataGridViewHarvestRemove.Columns.Add(col, col);
                        }// first line is the headers for column names
                    }
                    else dataGridViewHarvestRemove.Rows.Add(values);

                }

                dataGridViewHarvestRemove.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // Species Life History Parameters

                dataGridViewSppLifeHistory.Rows.Clear();
                dataGridViewSppLifeHistory.Columns.Clear();

                for (int i = startline; i < lines.Length; i++)
                {
                    if (lines[i].Contains(searchPhrase))
                    {
                        startline = i + 1;  // new start line
                        break;
                    }

                    values = lines[i].Split(',');
                    if (i == startline)
                    {
                        foreach (string col in values)
                        {
                            dataGridViewSppLifeHistory.Columns.Add(col, col);
                        }// first line is the headers for column names
                    }
                    else dataGridViewSppLifeHistory.Rows.Add(values);
                }
                dataGridViewSppLifeHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // Species Ecophysiological Parameters

                dataGridViewSppEcophysi.Rows.Clear();
                dataGridViewSppEcophysi.Columns.Clear();
                //DataTable table = new DataTable();

                for (int i = startline; i < lines.Length; i++)
                {
                    if (lines[i].Contains(searchPhrase))
                    {
                        startline = i + 1;  // new start line
                        break;
                    }

                    values = lines[i].Split(',');
                    if (i == startline)
                    {
                        foreach (string col in values)
                        {
                            dataGridViewSppEcophysi.Columns.Add(col, col);
                            //table.Columns.Add(col);
                        }// first line is the headers for column names
                    }
                    else dataGridViewSppEcophysi.Rows.Add(values);

                }
                //dataGridViewSppEcophysi.DataSource = table;
                dataGridViewSppEcophysi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                // MessageBox.Show(zzx, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string InputDir(string InputSuccession = "Biomass")
        {
            string InputDirectory = @".\Input";
            InputDirectory = InputDirectory + "\\" + InputSuccession;
            return InputDirectory;

        }
        private string InterDir(string InputSuccession = "Biomass")
        {
            string InterDirectory = @".\Inter";
            InterDirectory = InterDirectory + "\\" + InputSuccession;
            return InterDirectory;

        }
        private void MenuBuildLandisInput_Click(object sender, EventArgs e)
        {

            BuildLandisInput(); // build the input package


            string strSuccession = "Biomass";  // get the current succesion Extension            

            string InputDirectory = InputDir();// get the current succesion input directory


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


        private void BuildRunBatch()
        {
            string fileName = "site_run.bat";
            string filePath = Path.Combine(InputDirectory, fileName);

            //string InterDirectory = @".\Inter";
            string Sourcefile = Path.Combine(InterDirectory, fileName); ;

            File.Copy(Sourcefile, filePath, true);


            fileName = "site_run_console.bat";
            filePath = Path.Combine(InputDirectory, fileName);
            Sourcefile = Path.Combine(InterDirectory, fileName); ;

            File.Copy(Sourcefile, filePath, true);


        }

        private void BuildSuccessionScenario()
        {
            //////////////////// build site_Scenario.txt
            string fileName = "site_Scenario.txt";
            string filePath = Path.Combine(InputDirectory, fileName);
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Write the header row
                writer.WriteLine("LandisData  \"Scenario\"");

                writer.WriteLine(); // empty line

                writer.WriteLine($"Duration  {tbSimYears.Text}");

                writer.WriteLine(); // empty line

                writer.WriteLine("Species         site_SpeciesCore.txt");
                writer.WriteLine("Ecoregions      site_Ecoregions.txt");
                writer.WriteLine("EcoregionsMap   site_EcoregionsMap.img");
                writer.WriteLine("CellLength  100 << meters, 100 x 100 m = 1 ha");

                writer.WriteLine(); // empty line

                writer.WriteLine(">> Succession Extension     Initialization File");
                writer.WriteLine(">> --------------------     -------------------");

                string successiontext = "Biomass Succession";


                writer.WriteLine("\"" + successiontext + "\"" + "    site_Succession.txt");

                writer.WriteLine(); // empty line
                writer.WriteLine(">> Disturbance Extensions     Initialization File");
                writer.WriteLine(">> --------------------     -------------------");
                foreach (var item in checkedListBoxDisturbance.CheckedItems)
                {
                    string value = item.ToString();
                    string strout = "\"" + value + "\"" + "     " + "site_" + value + ".txt";
                    writer.WriteLine(strout);
                }

                // if (cbRandSeed.Checked) writer.WriteLine($"DisturbancesRandomOrder  {tbRandSeed.Text}");

                writer.WriteLine(); // empty line
                writer.WriteLine(">> Output Extensions     Initialization File");
                writer.WriteLine(">> --------------------     -------------------");
                /*
                foreach (var item in checkedListBoxOutput.CheckedItems)
                {
                    string value = item.ToString();
                    string strout = "\"" + value + "\"" + "     " + "site_Output_Extension.txt";
                    writer.WriteLine(strout);
                }
                */
                if (cbOutputBiomass.Checked) writer.WriteLine("\"Output Biomass\"" + "     " + "site_Output_Extension.txt");
                writer.WriteLine(); // empty line
                if (cbRandSeed.Checked) writer.WriteLine($"RandomNumberSeed  {tbRandSeed.Text}");
                ///////////////////////////////////// end of site_Scenario.txt
                ///
            }

        }
        private void BuildSuccessionSuccession()
        {
            //////////////////// build site_Succession.txt
            string fileName = "site_Succession.txt";
            string filePath = Path.Combine(InputDirectory, fileName);
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Write the header row
                writer.WriteLine("LandisData  \"Biomass Succession\"");

                writer.WriteLine(); // empty line

                writer.WriteLine(">>-------------------------------------");
                writer.WriteLine($"Timestep          {tbTimestep.Text}");

                writer.WriteLine($"SeedingAlgorithm  {cbSeedingAlg.Text}");



                writer.WriteLine(); // empty line



                writer.WriteLine("InitialCommunities      site_InitialCommunities.csv");
                writer.WriteLine("InitialCommunitiesMap   site_InitialCommunitiesMap.img");

                writer.WriteLine(); // empty line

                writer.WriteLine("ClimateConfigFile		site_ClimateGenerator.txt");

                writer.WriteLine(); // empty line

                writer.WriteLine(">> CalibrateMode 		yes");
                ////  LIFE HISTORY PARAMETERS
                writer.WriteLine(">> LIFE HISTORY PARAMETERS");
                writer.WriteLine(">>-------------------------------------");
                writer.WriteLine(); // empty line
                // MinRelativeBiomass
                writer.WriteLine("MinRelativeBiomass");
                writer.WriteLine(">> Shading %MaxBiomass");
                writer.WriteLine(">>-------------------------------------");
                writer.WriteLine("     eco999");
                SaveDataGridViewToCsv(writer, dataGridViewMinRelativeBiomass, false, "   ");
                writer.WriteLine(); // empty line

                // SufficientLight
                writer.WriteLine("SufficientLight");
                writer.WriteLine(">> ShadeTol.,Shading0,Shading1,Shading2,Shading3,Shading4,Shading5");
                writer.WriteLine(">>-------------------------------------");
                SaveDataGridViewToCsv(writer, dataGridViewLightTable, false, "   ");
                writer.WriteLine(); // empty line

                writer.WriteLine("SpeciesDataFile site_SpeciesPhysiology.csv");
                writer.WriteLine(); // empty line

                writer.WriteLine("EcoregionParameters");
                writer.WriteLine(">>	AET (mm)");
                writer.WriteLine($"eco999   {tbAET.Text}");
                writer.WriteLine(); // empty line

                writer.WriteLine("SpeciesEcoregionDataFile   site_SppEcoregionData.csv");
                writer.WriteLine(); // empty line

                writer.WriteLine("FireReductionParameters");
                writer.WriteLine(">> Severity WoodLitterRemove LitterRemove");
                writer.WriteLine(">>-------------------------------------");
                SaveDataGridViewToCsv(writer, dataGridViewFireRemove, false, "   ");
                writer.WriteLine(); // empty line

                writer.WriteLine("HarvestReductionParameters");
                writer.WriteLine(">> Method WoodLitterRemove LitterRemove WoodRemove LeafRemove");
                writer.WriteLine(">>-------------------------------------");
                SaveDataGridViewToCsv(writer, dataGridViewHarvestRemove, false, "   ");
                writer.WriteLine(); // empty line

                ///////////////////////////////////// end of site_Succession.txt
                ///
            }

        }



        private void BuildSuccessionSpecies()
        {
            //////////////////// build site_Species.txt
            string fileName = "site_SpeciesCore.txt";
            string filePath = Path.Combine(InputDirectory, fileName);
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Write the header row
                writer.WriteLine("LandisData  Species");

                writer.WriteLine(); // empty line

                writer.WriteLine(">>species Longevity sex_Maturity seed_disper_Effective seed_disp_Maximum veg_ReprodProb sprout_age_Min sprout_age_Max post_fire_Regen");
                writer.WriteLine(">>---------------------------------------------------");


                SaveDataGridViewToCsv(writer, dataGridViewSppLifeHistory, false, "   ");

                ///////////////////////////////////// end of site_Species.txt
                ///
            }

        }

        private DataGridView SubsetDataGridView(DataGridView dataGridView, string[] selectedColumns)
        {
            DataGridView dataGridViewSubset = new DataGridView();

            // Add selected columns to the new table
            foreach (string colName in selectedColumns)
            {
                dataGridViewSubset.Columns.Add(colName, colName);
            }

            // Copy data row by row
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                DataGridViewRow newRowLeft = new DataGridViewRow();
                newRowLeft.CreateCells(dataGridViewSubset);
                foreach (string colName in selectedColumns)
                {
                    int colIndex = dataGridView.Columns[colName].Index;
                    int colIndex1 = dataGridViewSubset.Columns[colName].Index;
                    newRowLeft.Cells[colIndex1].Value = row.Cells[colIndex].Value;
                }
                dataGridViewSubset.Rows.Add(newRowLeft);
            }

            return dataGridViewSubset;


        }


        private void BuildSuccessionSpeciesPhysiology()
        {




            // Choose the column names you want to include
            // SpeciesCode,LeafLongevity,WoodDecayRate,MortalityCurve,GrowthCurve,LeafLignin,ShadeTolerance,FireTolerance,
            string[] selectedColumns = { "SpeciesCode", "LeafLongevity", "WoodDecayRate" , "MortalityCurve",
                                        "GrowthCurve", "LeafLignin", "ShadeTolerance", "FireTolerance"};
            // "ShadeTolerance", "FireTolerance","ProbEstablish","ProbMortality"};


            //////////////////// build site_PnETSpeciesParameters.txt
            string fileName = "site_SpeciesPhysiology.csv";
            string filePath = Path.Combine(InputDirectory, fileName);
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                SaveDataGridViewToCsv(writer, SubsetDataGridView(dataGridViewSppEcophysi, selectedColumns), true, ",");

            }

            ///////////////////////////////////// end of site_PnETSpeciesParameters.txt
        }

        private void BuildSuccessionSppEcoregionData()
        {
            // Choose the column names you want to include
            // SpeciesCode,LeafLongevity,WoodDecayRate,MortalityCurve,GrowthCurve,LeafLignin,ShadeTolerance,FireTolerance,
            string[] selectedColumns = { "SpeciesCode", "ProbEstablish", "ProbMortality", "ANPPmax", "BiomassMax" };

            var dataGridView = dataGridViewSppEcophysi;

            DataGridView dataGridViewSubset = new DataGridView();
            dataGridViewSubset = SubsetDataGridView(dataGridViewSppEcophysi, selectedColumns);
            int insertIndex = 0;
            dataGridViewSubset.Columns.Insert(insertIndex, new DataGridViewTextBoxColumn
            {
                Name = "Year",
                HeaderText = "Year",
                ValueType = typeof(int)
            });
            insertIndex = 1;

            dataGridViewSubset.Columns.Insert(insertIndex, new DataGridViewTextBoxColumn
            {
                Name = "EcoregionName",
                HeaderText = "EcoregionName",
                ValueType = typeof(string)
            });
            //dataGridViewSubset.Columns.Add("EcoregionName", "EcoregionName");
            foreach (DataGridViewRow row in dataGridViewSubset.Rows)
            {
                if (!row.IsNewRow) // skip the empty row for new input
                {
                    row.Cells["Year"].Value = 0;
                    row.Cells["EcoregionName"].Value = "eco999";
                }
            }


            //////////////////// build site_PnETSpeciesParameters.txt
            string fileName = "site_SppEcoregionData.csv";
            string filePath = Path.Combine(InputDirectory, fileName);
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                SaveDataGridViewToCsv(writer, dataGridViewSubset, true, ",");

            }

            ///////////////////////////////////// end of site_PnETSpeciesParameters.txt
        }

        private void BuildSuccessionInitialComm()
        {
            //////////////////// build site_InitialCommunities
            string fileName = "site_InitialCommunities.csv";
            string filePath = Path.Combine(InputDirectory, fileName);
            using (StreamWriter writer = new StreamWriter(filePath))
            {

                writer.WriteLine("MapCode,SpeciesName,CohortAge,CohortBiomass");


                // Write the data rows
                var dataGridView = dataGridViewInitialComm;

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (!row.IsNewRow) // Skip the placeholder row
                    {
                        writer.Write("10,");
                        for (int i = 0; i < dataGridView.ColumnCount; i++)
                        {
                            writer.Write(row.Cells[i].Value);
                            if (i < dataGridView.ColumnCount - 1) writer.Write(",");
                        }
                        writer.WriteLine();
                    }
                }



                ///////////////////////////////////// end of BuildPnetSuccessionInitialComm.txt
                ///
            }

        }

        private void BuildSuccessionClimate()
        {
            //////////////////// build site_climate.txt
            string fileName = "site_climate.csv";
            string filePath = Path.Combine(InputDirectory, fileName);

            string Sourcefile = tbClimateFile.Text;

            File.Copy(Sourcefile, filePath, true);


            //////////////////// build site_ClimateGenerator.txt
            fileName = "site_ClimateGenerator.txt";
            filePath = Path.Combine(InputDirectory, fileName);


            string InterDirectory = InterDir();// get the current succesion inter directory
                                               //string fileName = "Site_Site.csv";
            Sourcefile = Path.Combine(InterDirectory, fileName);



            File.Copy(Sourcefile, filePath, true);

            ///////////////////////////////////// end of site_climate.txt
        }

        private void BuildSuccessionGISMap()
        {
            string InterDirectory = InterDir();// get the current succesion inter directory
            //////////////////// EcoregionsMap.img
            string fileName = "site_EcoregionsMap.img";
            string filePath = Path.Combine(InputDirectory, fileName);

            string Sourcefile = Path.Combine(InterDirectory, fileName); ;

            File.Copy(Sourcefile, filePath, true);

            //////////////////// site_Ecoregions.txt
            fileName = "site_Ecoregions.txt";
            filePath = Path.Combine(InputDirectory, fileName);

            Sourcefile = Path.Combine(InterDirectory, fileName); ;

            File.Copy(Sourcefile, filePath, true);

            //////////////////// build InitialCommunitiesMap.img
            fileName = "site_InitialCommunitiesMap.img";
            filePath = Path.Combine(InputDirectory, fileName);

            Sourcefile = Path.Combine(InterDirectory, fileName);

            File.Copy(Sourcefile, filePath, true);

            ///////////////////////////////////// end of 
        }


        private void BuildOutputExtension()
        {
            //////////////////// site_Output_Extension.txt
            string fileName = "site_Output_Extension.txt";
            string filePath = Path.Combine(InputDirectory, fileName);
            using (StreamWriter writer = new StreamWriter(filePath))
            {

                // Write the header row
                writer.WriteLine("LandisData  \"Output Biomass\"");

                writer.WriteLine(); // empty line
                writer.WriteLine($"Timestep   {OutputForm.tbTimestep.Text}"); // empty line

                writer.WriteLine($"MakeTable   {OutputForm.comboBoxMakeTable.Text}"); // empty line
                writer.WriteLine($"Species   all"); // empty line


                writer.WriteLine("MapNames  outputs/biomass/biomass-{species}-{timestep}.tif"); // empty line

                writer.WriteLine($"DeadPools   {OutputForm.comboBoxDeadPool.Text}"); // empty line
                writer.WriteLine("MapNames  outputs/biomass/biomass-{pool}-{timestep}.tif"); // empty line
            }


            ///////////////////////////////////// end of

        }

        public void BuildLandisInput()
        {

            //string InputDirectory = InputDir();// get the current succesion input directory

            BuildRunBatch();  // build the running batch file
            BuildSuccessionScenario();                        // build scenario file

            BuildSuccessionSuccession();                      // build Succession file

            BuildSuccessionClimate();                         // build climate file
            BuildSuccessionGISMap();                          // build ecoregion and initial community maps

            BuildSuccessionSpecies();                         // build Species life history file

            BuildSuccessionSpeciesPhysiology();           // build Species physiology file
            BuildSuccessionInitialComm();                     // build initial community file
            BuildSuccessionSppEcoregionData();                // build ecoregion spp file

            //
            BuildOutputExtension();                // build ecoregion spp file


        }



        private void btAddCohortSpp_Click(object sender, EventArgs e)
        {
            dataGridViewInitialComm.Rows.Add();
        }

        private void btDeleteCohortSpp_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dataGridViewInitialComm.SelectedRows.Count > 0)
            {
                // Delete the selected rows
                foreach (DataGridViewRow row in dataGridViewInitialComm.SelectedRows)
                {
                    if (!row.IsNewRow) // Ensure it is not the "new row" placeholder
                    {
                        dataGridViewInitialComm.Rows.Remove(row);
                    }
                }

                // Update row numbers after deletion
                //UpdateRowNumbers();
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Delete Row", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btAddCohortAge_Click(object sender, EventArgs e)
        {

            int colnum = dataGridViewInitialComm.Columns.Count;
            if (colnum > 1)
            {
                for (int i = 0; i < colnum - 1; i++)
                {
                    string headername = $"Age{i + 1}";
                    dataGridViewInitialComm.Columns[i + 1].HeaderText = headername;
                }

            }
            string columnName = $"Age{colnum}";
            dataGridViewInitialComm.Columns.Add(columnName, columnName);


        }

        private void btDeleteCohortAge_Click(object sender, EventArgs e)
        {
            if (dataGridViewInitialComm.SelectedCells.Count > 0)
            {
                int selectedColumnIndex = dataGridViewInitialComm.SelectedCells[0].ColumnIndex;

                if (selectedColumnIndex > 0)
                {
                    string columnName = dataGridViewInitialComm.Columns[selectedColumnIndex].Name;
                    dataGridViewInitialComm.Columns.RemoveAt(selectedColumnIndex);
                    MessageBox.Show($"Column '{columnName}' has been deleted.");
                }

                int colnum = dataGridViewInitialComm.Columns.Count;
                if (colnum > 1)
                {
                    for (int i = 0; i < colnum - 1; i++)
                    {
                        string headername = $"Age{i + 1}";
                        dataGridViewInitialComm.Columns[i + 1].HeaderText = headername;
                    }

                }

            }
            else
            {
                MessageBox.Show("No column or first column selected.");
            }

        }

        private void btAddReference_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                Title = "Open CSV File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                RecordsRef = ReadCsvAsDictionary(openFileDialog.FileName);

                string Xvar = "Time";
                int i = 0;
                checkedListBoxReference.Items.Clear();

                foreach (var key in RecordsRef[0].Keys)
                {
                    if (key.Contains('_'))
                    {
                        string[] para = key.Split('_');
                        Color c = colorPalette[i];
                        string item = para[0] + "_ref";
                        //CreateGraphRef(RecordsRef, Xvar, key, c,para[1]);// create dot graph
                        checkedListBoxReference.Items.Add(key);
                    }
                    i++;
                }

                for (i = 0; i < checkedListBoxReference.Items.Count; i++)
                {
                    checkedListBoxReference.SetItemChecked(i, true); // Set each item as checked
                }


            }






        }

        private ZedGraphControl MatchZedGraph(string tab)
        {
            ZedGraphControl zgc = new ZedGraphControl();
            if (tab == "2")
            {
                zgc = zedGraphControlCarbon;
            }

            if (tab == "3")
            {
                zgc = zedGraphControlWater;
            }



            if (tab == "5")
            {
                zgc = zedGraphControlCompare;
            }

            //GraphPane myPane = zgc.GraphPane;
            return zgc;

        }
        private GraphPane CreateGraphRef(List<Dictionary<string, object>> records, string Xvar, string Yvar, Color c, string tab)
        {

            // get the zed
            ZedGraphControl zgc = MatchZedGraph(tab);
            GraphPane myPane = zgc.GraphPane;

            // Set the titles and axis labels

            myPane.XAxis.Title.Text = "Time";
            myPane.YAxis.Title.Text = Yvar;

            PointPairList list = new PointPairList();


            foreach (var record in records)
            {
                double _x, _y;
                double.TryParse((string)record[Xvar], out _x);
                double.TryParse((string)record[Yvar], out _y);
                list.Add(_x, _y);

            }
            //c = Color.FromArgb(2, 0, 0, 0);
            LineItem myCurve = myPane.AddCurve(Yvar, list, c, SymbolType.Circle);
            // 3. Customize appearance: show points only, hide lines
            myCurve.Line.IsVisible = false;             // Disable line connection
            //myCurve.Symbol.Fill = new Fill(c); // Fill the symbols
            myCurve.Symbol.Size = 8;                   // Symbol size

            zgc.AxisChange();
            zgc.Invalidate();
            return myPane;
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

        // for Random seed
        private void cbRandSeed_CheckedChanged(object sender, EventArgs e)
        {
            // Set the TextBox to enabled/disabled based on CheckBox's checked state
            tbRandSeed.Enabled = cbRandSeed.Checked;
        }

        private void cbReplicate_CheckedChanged(object sender, EventArgs e)
        {
            // Set the TextBox to enabled/disabled based on CheckBox's checked state
            tbReplicateNum.Enabled = cbReplicate.Checked;
            //cbRandSeed.Checked = !cbReplicate.Checked;            
            //cbRandSeed.Enabled = !cbReplicate.Checked;
            //Boolean randseedstatus = cbRandSeed.Checked;

            if (cbReplicate.Checked)
            {
                //tbReplicateNum.Enabled = false;
                cbRandSeed.Checked = false;
                cbRandSeed.Enabled = false;

                checkBoxCalibration.Checked = false;
                checkBoxCalibration.Enabled = false;
            }
            else
            {
                cbRandSeed.Enabled = true;
                //cbRandSeed.Checked = randseedstatus;
                checkBoxCalibration.Enabled = true;
            }


        }


        // for climate libary
        private void checkedListBoxExtensionOther_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Check if the specific item ("Climate") is being checked/unchecked
            if (checkedListBoxExtensionOther.Items[e.Index].ToString() == "Climate")
            {
                // e.NewValue shows the *upcoming* state of the item (Checked or Unchecked)
                // Disable both TextBox and Button based on upcoming check state
                bool controlsEnabled = (e.NewValue != CheckState.Checked);
                btClimate.Enabled = controlsEnabled;
                tbClimateFile.Enabled = (e.NewValue != CheckState.Checked);
            }
        }


        private void Get_tabControlGraphSite_selection()
        {

            // Store checked indexes for each CheckedListBox in separate lists
            List<int> Climate = GetCheckedIndexes(checkedListBoxClimate);
            List<int> Carbon = GetCheckedIndexes(checkedListBoxCarbon);
            List<int> Water = GetCheckedIndexes(checkedListBoxWater);



            List<int> Composition = GetCheckedIndexes(checkedListBoxComposition);
            List<int> Compare = GetCheckedIndexes(checkedListBoxCompare);

            List<int> Reference = GetCheckedIndexes(checkedListBoxReference);

            List<int> addnew = new List<int>();




        }




        private List<int> GetCheckedIndexes(CheckedListBox checkedListBox)
        {
            List<int> checkedIndexes = new List<int>();
            foreach (int index in checkedListBox.CheckedIndices)
            {
                checkedIndexes.Add(index);
            }
            return checkedIndexes;
        }


        private void SetCheckedIndexes(CheckedListBox checkedListBox, List<int> indexesToCheck)
        {
            // Uncheck all first (optional)
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetItemChecked(i, false);
            }

            // Check specific items based on index
            foreach (int index in indexesToCheck)
            {
                if (index >= 0 && index < checkedListBox.Items.Count) // Ensure index is within range
                {
                    checkedListBox.SetItemChecked(index, true);
                }
            }

        }
        // load the tab graphs variables
        private void tabControlGraphSite()
        {

            tabControlGraphSiteBiomass();


        }
        private void tabControlGraphSiteBiomass()
        {

            //clear the graphs first 

            btClearGraph_Click(null, EventArgs.Empty);


            // read the data file
            string InterDirectory = InterDir();// get the current succesion inter directory
            string fileName = "Site_Site.csv";
            string filePath = Path.Combine(InterDirectory, fileName);
            Dictionary<string, string> sitevars = new Dictionary<string, string>();



            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                // Read the keys from the first line
                string[] keys = lines[0].Trim().Split(',');
                string[] values = lines[1].Trim().Split(',');
                //sitevars.Add();
                // Process each data row
                for (int i = 0; i < keys.Length; i++) // 
                {
                    sitevars[keys[i]] = values[i];

                    //records.Add(record);
                }
                ///////////////////////////////////////////
                // populate climate tab
                ////////////////////////////////////////////

                // List of values to match
                List<string> valuesToFind = new List<string> { "1" };
                tabControlGraphSiteTab(sitevars, checkedListBoxClimate, valuesToFind);
                //checkedListBoxClimate.SetItemChecked(0, true);  // show default chart

                // populate carbon tab
                // List of values to match
                valuesToFind = new List<string> { "2" };   //
             /*   List<string> speciesList = new List<string>();
                foreach (DataGridViewRow row in dataGridViewInitialComm.Rows) // Get species from initial communities
                {
                    // Skip the new row placeholder (the empty row at the end)
                    if (row.IsNewRow) continue;

                    // Get the value from the "Species" column
                    var cellValue = row.Cells["Species"].Value;

                    if (cellValue != null)
                    {
                        string speciesName = cellValue.ToString().Trim();

                        // Add to list if not empty
                        if (!string.IsNullOrEmpty(speciesName))
                        {
                            speciesList.Add(speciesName);
                        }
                    }
                }

                // Update all matching keys
                foreach (var key in sitevars.Keys.ToList()) // Use ToList() to avoid modifying during iteration
                {
                    if (speciesList.Any(s => key.Contains(s)))
                    {
                        sitevars[key] = "2";
                    }
                }
             */
                tabControlGraphSiteTab(sitevars, checkedListBoxCarbon, valuesToFind);
                //checkedListBoxClimate.SetItemChecked(0, true);  // show default chart

                ///////////////////////////////////////////
                // populate water tab
                ////////////////////////////////////////////
                // List of values to match
                valuesToFind = new List<string> { "3" };   // 
                tabControlGraphSiteTab(sitevars, checkedListBoxWater, valuesToFind);

                /*
                // populate nitrogen tab
                valuesToFind = new List<string> { "4" };   // 
                tabControlGraphSiteTab(sitevars, checkedListBoxNitrogen, valuesToFind);
*/
                // populate composition tab
                //checkedListBoxComposition.Items.Clear();
                CohortComposition();// get the composition based on wood biomasss
                // if (checkedListBoxComposition.Items.Count > 0) checkedListBoxComposition.SetItemChecked(0, true);  // show default chart


                // populate cohort tab
                // List of values to match
               // comboBoxCohortNameFill();


                // populate compare tab

                // Clear the CheckedListBox
                checkedListBoxCompare.Items.Clear();

                valuesToFind = new List<string> { "1","2","3","4" };   // 
                tabControlGraphSiteTab(sitevars, checkedListBoxCompare, valuesToFind);

                /*
                ICollection<string> compkeys = sitevars.Keys;// Retrieve all the keys
                foreach (string item in compkeys)
                {
                    checkedListBoxCompare.Items.Add(item);
                }
                //  if (checkedListBoxCompare.Items.Count > 0) checkedListBoxCompare.SetItemChecked(0, true);  // show default chart

                */

                // populate diagnosis tab
                comboBoxCalibrationVarFill();



            }
            else
            {
                string error = filePath + " not found.";
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void tabControlGraphSiteTab(Dictionary<string, string> sitevars, CheckedListBox checkedListBoxTab, List<string> valuesToFind)
        {
            //List<string> valuesToFind = new List<string> { "1" };
            // Find keys whose values match the list
            var matchingKeys = sitevars
                .Where(pair => valuesToFind.Contains(pair.Value)) // Filter based on values
                .Select(pair => pair.Key) // Select the keys
                .ToList();
            // Clear the CheckedListBox
            checkedListBoxTab.Items.Clear();
            //checkedListBoxClimate.Items.Add(matchingKeys);
            // Add new items
            foreach (string item in matchingKeys)
            {
                checkedListBoxTab.Items.Add(item);
            }

            // if (checkedListBoxTab.Items.Count > 0) checkedListBoxTab.SetItemChecked(0, true);  // show default chart

        }




        private void checkedListBoxCompare_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ZedGraphControl zgc = zedGraphControlCompare;  // carbon zgc pane
            CheckedListBox myclb = checkedListBoxCompare;    // carbon checked List Box

            var mypane = zgc.GraphPane;

            mypane.Title.Text = string.Empty;

            string Xvar = "Time";

            // Check which item is toggled
            string selectedItem = myclb.Items[e.Index].ToString();

            if (e.NewValue == CheckState.Checked)
            {
                // Show  in Chart
                Color c = colorPalette[e.Index];
                mypane = CreateGraph(zgc, selectedItem, RecordsSite, Xvar, selectedItem, c);
            }
            else
            {
                // Clear  Data
                CurveItem curve = mypane.CurveList[selectedItem];
                // Remove the curve from the list
                mypane.CurveList.Remove(curve);

                // Refresh the graph
                zgc.AxisChange();
                zgc.Invalidate();

            }

        }

        // get output directory based on succession extentsion
        private string OutputDir()
        {

            string OutputDirectory = OutputParentDir();

            return OutputDirectory;

        }

        private string OutputParentDir(Boolean control = true, string InputSuccession = "Biomass")
        {


            string OutputDirectory = @".\Output\Output";

            if (checkBoxCalibration.Checked)
            {
                //GetSelectedDiagRadioButton();
                if (radioButtonOnePara.Checked)

                {
                    OutputDirectory = @".\Output\Output_CalOne";   // Site Tool default output folder
                }
                if (radioButtonMultiple.Checked)

                {
                    OutputDirectory = @".\Output\Output_CalMul";   // Site Tool default output folder
                }
                if (radioButtonBayesian.Checked)
                {
                    OutputDirectory = @".\Output\Output_CalBay";   // Site Tool default output folder
                }


            }
            else
            {
                if (cbReplicate.Checked)
                {
                    OutputDirectory = @".\Output\Output_Rep"; // Replication
                }
                else
                {
                    OutputDirectory = @".\Output\Output";   // Site Tool default output folder
                }
            }


            if (control) OutputDirectory = @".\Output\Output";

            return OutputDirectory;

        }
        private void comboBoxCohortVarFill()
        {
            // set default values for cbSppGenericPara

            // read the data file

            string OutputDirectory = OutputDir();// get the current succesion output directory
            string fileName = comboBoxCohortName.Text;
            string filePath = Path.Combine(OutputDirectory, fileName);


            if (File.Exists(filePath))
            {
                // Clear any existing items in the ComboBox
                comboBoxCohortVar.Items.Clear();

                // Read all lines from the file
                string[] lines = File.ReadAllLines(filePath);
                string[] keys = lines[0].Trim().Split(',');
                for (int i = 0; i < keys.Length; i++) // 
                {
                    comboBoxCohortVar.Items.Add(keys[i]);

                }

                comboBoxCohortVar.Sorted = true; // Automatically sorts items alphabetically
            }
            else
            {
                MessageBox.Show($"{filePath} does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            comboBoxCohortVar.SelectedIndex = 1;  // set default


        }

        private void comboBoxCohortNameFill()
        {
            // set default values             

            string OutputDirectory = OutputDir();// get the current succesion output directory

            comboBoxCohortName.Items.Clear();
            // get all files name and add to the combo box
            foreach (string file in Directory.GetFiles(OutputDirectory))
            {
                string fileName = Path.GetFileName(file);
                if (fileName.Contains("Cohort")) comboBoxCohortName.Items.Add(fileName);

            }
            comboBoxCohortName.Sorted = true; // Automatically sorts items alphabetically
            comboBoxCohortName.SelectedIndex = 0;  // set default    
            comboBoxCohortVarFill(); // fill the variable name
            CohortComposition("Wood(gDW)");// get the composition based on wood biomasss

        }
        // read cohort data file
        private List<Dictionary<string, object>> LoadResultCohort(string ChortName)
        {
            // Read data from the CSV file

            string OutputDirectory = OutputDir();// get the current succesion output directory
            //string fileName = comboBoxCohortName.Text;
            string filePath = Path.Combine(OutputDirectory, ChortName);
            var Records = ReadCsvAsDictionary(filePath);
            return Records;
        }

        private void comboBoxCohortName_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecordsCohort = LoadResultCohort(comboBoxCohortName.Text);
            comboBoxCohortVar_SelectedIndexChanged(sender, e); // update the ploting
        }

        private void comboBoxCohortVar_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZedGraphControl zgc = zedGraphControlCohorts;  //  zgc pane
            //CheckedListBox myclb = checkedListBoxNitrogen;    // carbon checked List Box

            var mypane = zgc.GraphPane;

            mypane.Title.Text = string.Empty;

            string Xvar = "Time";

            mypane.CurveList.Clear();
            // Check which item is toggled
            string selectedItem = comboBoxCohortVar.Text;
            Color c = Color.Red;
            mypane = CreateGraph(zgc, selectedItem, RecordsCohort, Xvar, selectedItem, c);

        }


        private void comboBoxCalibrationVar_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZedGraphControl zgc = zedGraphControlCalibration;  //  zgc pane            

            var mypane = zgc.GraphPane;

            mypane.Title.Text = string.Empty;

            string Xvar = "Time";

            mypane.CurveList.Clear();
            // Check which item is toggled
            string selectedItem = comboBoxCalibrationVar.Text;
            Color c = Color.Red;

            mypane = CreateGraph(zgc, selectedItem, RecordsSite, Xvar, selectedItem, c, "Control");  // control
            mypane = CreateGraph(zgc, selectedItem, RecordsCalOne, Xvar, selectedItem, Color.Blue, "Calibrated");  // control


        }

        private void comboBoxCalibrationSppVar_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZedGraphControl zgc = zedGraphControlCalibration;  //  zgc pane            

            var mypane = zgc.GraphPane;

            mypane.Title.Text = string.Empty;

            string Xvar = "Time";

            mypane.CurveList.Clear();
            // Check which item is toggled
            string selectedItem = comboBoxCalibrationSppVar.Text;
            Color c = Color.Red;

            mypane = CreateGraph(zgc, selectedItem, RecordsCohort, Xvar, selectedItem, c, "Control");  // control
            mypane = CreateGraph(zgc, selectedItem, RecordsCohCalOne, Xvar, selectedItem, Color.Blue, "Calibrated");  // control


        }


        // get the species composition based on Yvar value
        private void CohortComposition(string Yvar="")
        {
            List<Dictionary<string, object>> RecordscohortYvar = new List<Dictionary<string, object>>();


            //create a list of all cohorts with establishment year and last alive year in the simulation
            List<Dictionary<string, object>> Cohortlist = new List<Dictionary<string, object>>();


            RecordsCohort = LoadResultCohort(ResultSppName);
            const string prefixagb = "AboveGroundBiomass_";
            const string prefixpercent = "percent_";

            if (RecordsCohort == null || RecordsCohort.Count == 0)
            {
                // Nothing to do
                return;
            }
            // For each time-step record compute totals and percentages, then append percent_ keys to  the same record
            foreach (var record in RecordsCohort)
            {
                // Collect keys that correspond to species biomass (do not modify dictionary while enumerating keys)
                var agbKeys = record.Keys.Where(k => k != null && k.StartsWith(prefixagb, StringComparison.OrdinalIgnoreCase)).ToList();
                double total = 0.0;
                var speciesValues = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase);

                // Sum numeric biomass values for this time step
                foreach (var key in agbKeys)
                {
                    var raw = record.ContainsKey(key) ? record[key]?.ToString() : null;
                    if (double.TryParse(raw, NumberStyles.Any, CultureInfo.InvariantCulture, out double val))
                    {
                        speciesValues[key] = val;
                        total += val;
                    }
                    else
                    {
                        speciesValues[key] = 0.0;
                    }
                }

                // Determine year string (fall back to "Time" or "Year" or empty)
                string yearStr = "";
                if (record.ContainsKey("Time")) yearStr = record["Time"]?.ToString() ?? "";
                else if (record.ContainsKey("Year")) yearStr = record["Year"]?.ToString() ?? "";

                // Compute percentages and append new keys to the original record
                foreach (var kv in speciesValues)
                {
                    string agbKey = kv.Key;
                    double val = kv.Value;
                    double percent = (total > 0.0) ? (val / total) * 100.0 : 0.0;

                    // Extract species name from key after prefix
                    string speciesName = agbKey.Substring(prefixagb.Length);

                    string percentKey = prefixpercent + speciesName;

                    // Store percent as string using invariant culture with two decimals (consistent with other string values)
                   // record[percentKey] = percent.ToString("F2", CultureInfo.InvariantCulture);

                    // Also prepare composition csv row: lowercase headers expected by the composition reader
                    var compRow = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
                    {
                        ["year"] = yearStr,
                        ["species"] = speciesName,
                        ["percent"] = percent.ToString("F2", CultureInfo.InvariantCulture)
                    };
                    RecordscohortYvar.Add(compRow);
                }
            }   





            //var zz = RecordscohortYvar;
            // Specify the file path
            string filePath = Path.Combine(InterDirectory, "composition.csv");

            // Save the list of dictionaries to a CSV file
            ListDictionaryToCsv(RecordscohortYvar, filePath);

            //filePath = Path.Combine(InterDirectory, "composition2.csv");

            // Save the list of dictionaries to a CSV file
           // ListDictionaryToCsv(RecordsCohort, filePath);
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

        private void checkedListBoxComposition_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ZedGraphControl zgc = zedGraphControlComp;  //  zgc pane
            CheckedListBox myclb = checkedListBoxComposition;    //  checked List Box
            //CreateStackedBarGraph(ZedGraphControl zedGraph)
            var mypane = zgc.GraphPane;
            mypane.Title.Text = "Composition Over Years";
            mypane.XAxis.Title.Text = "Year";
            mypane.YAxis.Title.Text = "Percentage (%)";

            // 1. Read and parse the data
            string filePath = Path.Combine(InterDirectory, "composition.csv");
            var data = ReadCsvAsDictionary(filePath);


            // 2. Organize data: Create unique years and species mapping
            var years = data.Select(d => d["year"].ToString()).Distinct().ToList();
            var species = data.Select(d => d["species"].ToString()).Distinct().ToList();

            // Create a dictionary to hold stacked bar values for each species per year
            var speciesData = new Dictionary<string, List<double>>();

            foreach (var sp in species)
            {
                speciesData[sp] = new List<double>();

                foreach (var year in years)
                {
                    var value = data
                        .Where(d => d["species"].ToString() == sp && d["year"].ToString() == year)
                        .Select(d => Convert.ToDouble(d["percent"]))
                        .FirstOrDefault();
                    speciesData[sp].Add(value);
                }
            }

            // 3. Add stacked bars for each species

            int colorIndex = 0;
            if (e.NewValue == CheckState.Checked)
            {
                foreach (var sp in species)
                {
                    Color c = colorPalette[colorIndex];
                    BarItem bar = mypane.AddBar(sp, null, speciesData[sp].ToArray(), c);
                    colorIndex++;
                }


                // 4. Set X-Axis labels (years)
                mypane.XAxis.Type = AxisType.Text;
                mypane.XAxis.Scale.TextLabels = years.ToArray();
                //mypane.XAxis.Scale.FontSpec.Size = 12;

                // Adjust settings for stacked bars
                mypane.BarSettings.Type = BarType.Stack;
                mypane.Legend.IsVisible = true;

            }
            else
            {
                // Clear  Data
                mypane.CurveList.Clear();
                mypane.GraphObjList.Clear(); // Clear any additional objects like titles or markers          

            }
            // Refresh the graph
            zgc.AxisChange();
            zgc.Invalidate();

        }


        private void checkedListBoxReference_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            CheckedListBox myclb = checkedListBoxReference;    // carbon checked List Box

            string Xvar = "Time";

            // Check which item is toggled
            string selectedItem = myclb.Items[e.Index].ToString();

            if (e.NewValue == CheckState.Checked)
            {
                Color c = colorPalette[e.Index];
                string[] para = selectedItem.Split('_');
                CreateGraphRef(RecordsRef, Xvar, selectedItem, c, para[1]);// create dot graph
            }
            else
            {
                // Clear Data
                string[] para = selectedItem.Split('_');

                ZedGraphControl zgc = MatchZedGraph(para[1]);
                GraphPane myPane = zgc.GraphPane;

                CurveItem curve = myPane.CurveList[selectedItem];
                // Remove the curve from the list
                myPane.CurveList.Remove(curve);

                // Refresh the graph
                zgc.AxisChange();
                zgc.Invalidate();

            }

        }


        private void checkBoxCalibaration_CheckedChanged(object sender, EventArgs e)
        {
            // Set the TextBox to enabled/disabled based on CheckBox's checked state
            foreach (Control control in groupBoxDiagnosis.Controls)
            {
                if (control != checkBoxCalibration) control.Enabled = checkBoxCalibration.Checked;
            }

            if (checkBoxCalibration.Checked == true) tabControlGraph.SelectedTab = tabPageDiagnosis;
            else tabControlGraph.SelectedTab = tabPageCarbon;
        }

        private void comboBoxCalibrationVarFill()
        {
            // set default values for cbSppGenericPara

            // read the data file

          //  string OutputDirectory = OutputDir();// get the current succesion output directory
           // string fileName = "spp-biomass-log.csv";
           // string filePath = Path.Combine(OutputDirectory, fileName);

            comboBoxCalibrationVar.Items.Clear();
            // Track pixel width of longest item text
            int maxTextWidth = 0;

            foreach (var item in checkedListBoxCompare.Items)
            {
                string key = Convert.ToString(item);
                comboBoxCalibrationVar.Items.Add(key);
                // Measure text width for the current font
                var sz = TextRenderer.MeasureText(key, comboBoxCalibrationVar.Font);
                if (sz.Width > maxTextWidth) maxTextWidth = sz.Width;
            }
            comboBoxCalibrationVar.DropDownWidth = Math.Max(comboBoxCalibrationVar.DropDownWidth, maxTextWidth + 1);
            comboBoxCalibrationVar.Sorted = true; // Automatically sorts items alphabetically
            //comboBoxCalibrationVar.SelectedIndex = 0;  // set default


            comboBoxCalibrationSppVar.Items.Clear();
            // Track pixel width of longest item text
            //int maxTextWidth = 0;
            const string prefixagb = "AboveGroundBiomass_";
        
            // Ensure RecordsCohort has at least one record to read keys from
            if (RecordsCohort != null && RecordsCohort.Count > 0)
            {
                var firstRecord = RecordsCohort.First();

                // Find keys that start with the prefix and add the full key (e.g. "AboveGroundBiomass_acerrubr")
                var agbKeys = firstRecord.Keys
                    .Where(k => !string.IsNullOrEmpty(k) && k.StartsWith(prefixagb, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                foreach (var key in agbKeys)
                {
                    comboBoxCalibrationSppVar.Items.Add(key);
                    var sz = TextRenderer.MeasureText(key, comboBoxCalibrationSppVar.Font);
                    if (sz.Width > maxTextWidth) maxTextWidth = sz.Width;
                }
            }

            
            comboBoxCalibrationSppVar.DropDownWidth = Math.Max(comboBoxCalibrationSppVar.DropDownWidth, maxTextWidth + 1);
            comboBoxCalibrationSppVar.Sorted = true; // Automatically sorts items alphabetically
            




        }


        public void cbOutputBiomass_CheckedChanged(object sender, EventArgs e)
        {
            //OutputForm.Visible = cbOutputBiomass.Checked;
            if (cbOutputBiomass.Checked)
            {
                /*if (OutputForm == null || OutputForm.IsDisposed)
                 {
                     OutputForm = new FormOutputBiomass();
                     OutputForm.Show();
                 }*/


                OutputForm.StartPosition = FormStartPosition.CenterScreen;
                //OutputForm.Owner = this;       // 'this' is the parent form
                //form2.Show();
                OutputForm.Show();
                OutputForm.BringToFront();

            }
            else
            {
                if (OutputForm != null && OutputForm.Visible)
                {
                    OutputForm.Hide();

                }


            }

        }

        private void buttonResetInput_Click(object sender, EventArgs e)
        {
            // load the example for initilization
            string fileName = "Site_input_example.csv";
            string FileExample = Path.Combine(InterDirectory, fileName);
            LoadInputFromCsv(FileExample);

        }

    }
}
