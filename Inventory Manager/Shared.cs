using ClosedXML.Excel;
using Guna.UI2.WinForms;
using static System.Environment;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Windows.Forms;
using static System.Math;
using System.Media;

namespace Inventory_Manager
{
    class FormTimerFadeEffectNeeds
    {
        public Form form;
        public Timer timer = new Timer();
        public FormTimerFadeEffectNeeds(Form f , int interval)
        {
            timer.Interval = interval;
            form = f;
        }
    }
    public enum UserType
    {
        Developer,
        Admin,
        User
    }
    internal class Shared
    {
        public static SqlConnection conn = new SqlConnection();
        public static SqlCommand cmd = new SqlCommand();
        public static UserType defaultUserType = UserType.User;
        public static string currentUserName = "";
        public static string currentUserPassword = "";
        public static string currentUserType = "";
        public static readonly string documentsPath = GetFolderPath(SpecialFolder.MyDocuments);
        public static string programDirectoryName = "PayTek Inventory Management System";
        static readonly string reportsAuthor = currentUserName;
        static readonly string reportsManager = "Mansour Alset & Waseem Alshmaa";
        public static bool isVisibleForDeveloper = false;
        public static bool isVisibleForAdmin = false;
        public static bool isVisibleForUser = false;
        public static bool isJustVisibleForNonUserType = false;
        public static void HideComponentsByUserType()
        {
            isVisibleForDeveloper =
            isVisibleForAdmin =
            isJustVisibleForNonUserType =
            isVisibleForUser = false;
            switch (defaultUserType)
            {
                case UserType.Developer:
                    isJustVisibleForNonUserType =
                    isVisibleForDeveloper = true;
                    break;
                case UserType.Admin:
                    isJustVisibleForNonUserType =
                    isVisibleForAdmin = true;
                    break;
                case UserType.User:
                    isVisibleForUser = true;
                    break;
            }
        }

        public static string NoticeModifier(string target)
        {
            return $@"Notice: You don't have to enter the {target}'s id while saving a new {target}  , you can use it to:
Delete and Edit a {target}";
        }

        public static void KeysShortcuts(object sender, KeyEventArgs e, Form window, bool enableFullScreenShortcut = true)
        {
            if (enableFullScreenShortcut && e.Control && e.KeyCode == Keys.F)
            {
                if (window.FormBorderStyle == FormBorderStyle.None)
                {
                    window.FormBorderStyle = FormBorderStyle.Sizable;
                    window.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    window.FormBorderStyle = FormBorderStyle.None;
                    window.WindowState = FormWindowState.Normal;
                    window.Location = new System.Drawing.Point(0, 0);
                    window.Size = Screen.PrimaryScreen.Bounds.Size;
                }
                e.SuppressKeyPress = true;
                return;
            }

            if (e.Control && e.KeyCode == Keys.E)
            {
                FadeOutEffect(window);
                e.SuppressKeyPress = true;
                return;
            }

            if (e.Control && e.KeyCode == Keys.M)
            {
                window.WindowState = FormWindowState.Minimized;
                e.SuppressKeyPress = true;
                return;
            }

            e.SuppressKeyPress = false;
        }
        public static void ShowToast(string message, object window)
        {
            var thisWindow = window as Form;
            ToolTip toast = new ToolTip();
            int screenWidth = Screen.PrimaryScreen.Bounds.Width,
            screenHeight = Screen.PrimaryScreen.Bounds.Height,
            toastWidth = 110,
            toastHeight = 50,
            x = (screenWidth - toastWidth) / 2,
            y = screenHeight - toastHeight - 150;
            toast.Show(message, thisWindow, x, y, 2500);
        }

        public static string ProductBarcodeGetter(string targetColumn, TextBox tb)
        {

            cmd = conn.CreateCommand();
            cmd.CommandText = $@"SELECT  barcode
                                             FROM Product
                                             WHERE
                                             {$"\"{targetColumn}\""} = N'{tb.Text}'";
            if (cmd.ExecuteScalar() != null)
                return cmd.ExecuteScalar().ToString();
            return null;
        }

        public static void ConnectionInitializer()
        {
            conn.Close();
            if (conn.State != ConnectionState.Open)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Inventory_Manager.Properties.Settings.PublicConnectionString"].ConnectionString;
                conn.ConnectionString = connectionString.Replace("{MachineName}", Environment.MachineName);
                conn.Close();
                conn.Open();
            }
            cmd.Parameters.Clear();
        }

        public static void ResetFields(GroupBox gp)
        {
            foreach (Control c in gp.Controls)
                if (c is TextBox t)
                    t.Text = "";
                else if (c is RichTextBox rb)
                    rb.Text = "";
                else if (c is CheckBox ch)
                    ch.Checked = false;
        }

        public static void GeneralConnectionInitializer()
        {
            if (conn.State != ConnectionState.Open)
            {
                string connectionString = $"Data Source={Environment.MachineName};Initial Catalog= ;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";
                conn.ConnectionString = connectionString;
                conn.Close();
                conn.Open();
            }
        }

        public static void ShowAllTableData(DataGridView target, string tableName, string orderBy, bool excludeRow = false, string excludedBy = "", string excludedValue = "")
        {
            ConnectionInitializer();
            cmd = conn.CreateCommand();
            if (excludeRow)
                cmd.CommandText = $@"SELECT * FROM {tableName} WHERE ""{excludedBy}"" != '{excludedValue}' ORDER BY ""{orderBy}""";
            else
                cmd.CommandText = $@"SELECT * FROM {tableName} ORDER BY ""{orderBy}""";
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            target.DataSource = dt;
        }

        public static void ShowAllInventoryReportTableDataWithDate(DataGridView target, string orderBy, Guna2DateTimePicker startDate, Guna2DateTimePicker endDate)

        {
            DateValidityChecker(startDate, endDate);
            ConnectionInitializer();
            cmd = conn.CreateCommand();
            cmd.Parameters.AddWithValue("@startDate", startDate.Value);
            cmd.Parameters.AddWithValue("@endDate", endDate.Value);
            cmd.CommandText = $@"SELECT  ""Product ID"" , ""Product Barcode"" , ""Product Name"" , SUM(quantity) AS quantity , CAST (@EndDate as date) as date
                                      FROM InventoryReport
                                      WHERE date 
                                      BETWEEN @startDate
                                      AND @endDate
                                      GROUP BY  ""Product ID"" , ""Product Barcode"" , ""Product Name""
                                      ORDER BY ""{orderBy}""";
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            target.DataSource = dt;
            cmd.Parameters.Clear();
        }

        public static void ShowAllProductReportTableDataWithDate(DataGridView target, string orderBy, Guna2DateTimePicker startDate, Guna2DateTimePicker endDate)

        {
            DateValidityChecker(startDate, endDate);
            ConnectionInitializer();
            cmd = conn.CreateCommand();
            cmd.Parameters.AddWithValue("@startDate", startDate.Value);
            cmd.Parameters.AddWithValue("@endDate", endDate.Value);
            cmd.CommandText = $@"SELECT  ""Product ID"" , ""Product Barcode"" , ""Product Name"" , Status , SUM(quantity) AS quantity , CAST (@EndDate as date) as date
                                      FROM  ProductReport
                                      WHERE date 
                                      BETWEEN @startDate
                                      AND @endDate
                                      GROUP BY  ""Product ID"" , ""Product Barcode"" , ""Product Name"" , Status
                                      ORDER BY ""{orderBy}""";
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            target.DataSource = dt;
            cmd.Parameters.Clear();
        }

        public static bool IsTextBoxHasNotEnoughData(TextBox tb)
        {
            return tb.Text == "" || tb.Text.StartsWith(" ");
        }

        public static void SaveDataGridViewASExcelFile(string reportTitle, DataGridView target, Guna2DateTimePicker startDate, Guna2DateTimePicker endDate)
        {
            DataTable dataTable = target.DataSource as DataTable;

            if (dataTable != null)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files|*.xlsx";
                    saveFileDialog.Title = "Save an Excel File";
                    saveFileDialog.FileName = $"{reportTitle}.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            workbook.Properties.Author = reportsAuthor;
                            workbook.Properties.Manager = reportsManager;
                            workbook.Properties.Category = "Reports";
                            workbook.Properties.Title = reportTitle;
                            workbook.Properties.Comments = $@"Report:
from: {startDate.Value.ToShortDateString()}
to: {endDate.Value.ToShortDateString()} ";
                            workbook.Properties.Company = "PayTek Company";
                            workbook.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                            workbook.RowHeight = 33;
                            workbook.ColumnWidth = 28;
                            workbook.Style.Font.FontSize = 28;
                            workbook.Worksheets.Add(dataTable, "Sheet1");
                            workbook.SaveAs(saveFileDialog.FileName);
                        }

                        MessageBox.Show("Excel file created successfully at: \n" + saveFileDialog.FileName, "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("No data available to export.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string SearchCommandGenerator(TextBox tb, string targetTable, string targetColumn , string orderby, bool skipCheckNumericDataValidation = true, string ItemNameForErrorMessage = "", string excludedBy = "", string excludedValue = "")
        {
            if(excludedBy!= "")
            {
                return $@"SELECT  *
                                     FROM ""{targetTable}""
                                     WHERE ""{targetColumn}""
                                     LIKE N'%{tb.Text}%'
                                     AND ""{excludedBy}"" != '{excludedValue}'
                                     ORDER BY ""{orderby}""";
            }
            if (skipCheckNumericDataValidation || int.TryParse("0" + tb.Text, out int outputValue) && outputValue >= 0)
            {
                return $@"SELECT  *
                                     FROM ""{targetTable}""
                                     WHERE ""{targetColumn}""
                                     LIKE N'%{tb.Text}%'
                                     ORDER BY ""{orderby}""";
            }
            else
            {
                ErrorOccuredMessageBox($"Enter a valid value for {ItemNameForErrorMessage}");
                tb.Text = "";
                return "";
            }
        }

        public static void SearchCommandApply(DataGridView targetTable, string command)
        {
            ConnectionInitializer();
            cmd = conn.CreateCommand();
            cmd.CommandText = command;
            if (command != "")
            {
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                targetTable.DataSource = dt;
            }
            cmd.Parameters.Clear();
            cmd.Dispose();
        }


        public static void SearchCommandAssembler(DataGridView targetTable, TextBox tb, string tableName, string targetColumn, string orderBy, bool skipCheckNumericDataValidation = true, string ErrorParsing = "" , bool excludeRow = false, string excludedBy = "", string excludedValue = "")
        {
            if (IsTextBoxHasNotEnoughData(tb))
            {
                ShowAllTableData(targetTable, tableName, orderBy , excludeRow , excludedBy , excludedValue);
                return;
            }

            var command = SearchCommandGenerator(tb, tableName, targetColumn, orderBy ,skipCheckNumericDataValidation, ErrorParsing , excludedBy , excludedValue);
                SearchCommandApply(targetTable, command);
        }

        public static string SearchCommandGeneratorWithDateForProductReport(TextBox tb, string targetTable, string targetColumn, bool skipCheckNumericDataValidation = true, string ItemNameForErrorMessage = "")
        {
            if (skipCheckNumericDataValidation)
            {
                return $@"SELECT  ""Product ID"" , ""Product Barcode"" , ""Product Name"" , Status , SUM(quantity) AS quantity , CAST (@EndDate as date) as date
                                      FROM  ""{targetTable}""
                                      WHERE ""{targetColumn}""
                                      LIKE N'%{tb.Text}%'
                                      AND  date 
                                      BETWEEN @StartDate
                                      AND @EndDate
                                      GROUP BY  ""Product ID"" , ""Product Barcode"" , ""Product Name"" , Status
                                      ORDER BY ""Product ID""";
            }
            else if (int.TryParse("0" + tb.Text, out int outputValue) && outputValue >= 0)
            {
                return $@"SELECT  ""Product ID"" , ""Product Barcode"" , ""Product Name"" , Status , SUM(quantity) AS quantity , CAST (@EndDate as date) as date
                                      FROM  ""{targetTable}""
                                      WHERE ""{targetColumn}""
                                      LIKE N'{tb.Text}%'
                                      AND  date 
                                      BETWEEN @StartDate
                                      AND @EndDate
                                      GROUP BY  ""Product ID"" , ""Product Barcode"" , ""Product Name"" , Status
                                      ORDER BY ""Product ID""";
            }
            else
            {
                MessageBox.Show($"Enter a valid value for {ItemNameForErrorMessage}");
                tb.Text = "";
                return "";
            }
        }

        public static string SearchCommandGeneratorWithDateForInventoryReport(TextBox tb, string targetTable, string targetColumn, bool skipCheckNumericDataValidation = true, string ItemNameForErrorMessage = "")
        {
            if (skipCheckNumericDataValidation)
            {
                return $@"SELECT  ""Product ID"" , ""Product Barcode"" , ""Product Name"" , SUM(quantity) AS quantity , CAST (@EndDate as date) as date
                                      FROM ""{targetTable}""
                                      WHERE ""{targetColumn}""
                                      LIKE N'%{tb.Text}%'
                                      AND  date 
                                      BETWEEN @StartDate
                                      AND @EndDate
                                      GROUP BY  ""Product ID"" , ""Product Barcode"" , ""Product Name""
                                      ORDER BY ""Product ID""";
            }
            else if (int.TryParse("0" + tb.Text, out int outputValue) && outputValue >= 0)
            {
                return $@"SELECT  ""Product ID"" , ""Product Barcode"" , ""Product Name"" , SUM(quantity) AS quantity , CAST (@EndDate as date) as date
                                      FROM ""{targetTable}""
                                      WHERE ""{targetColumn}""
                                      LIKE N'{tb.Text}%'
                                      AND  date 
                                      BETWEEN @StartDate
                                      AND @EndDate
                                      GROUP BY  ""Product ID"" , ""Product Barcode"" , ""Product Name""
                                      ORDER BY ""Product ID""";
            }
            else
            {
                MessageBox.Show($"Enter a valid value for {ItemNameForErrorMessage}");
                tb.Text = "";
                return "";
            }
        }

        public static void SearchCommandApplyWithDate(DataGridView targetTable, string command, Guna2DateTimePicker startDate, Guna2DateTimePicker endDate)
        {
            ConnectionInitializer();
            cmd = conn.CreateCommand();
            cmd.Parameters.AddWithValue("@StartDate", startDate.Value);
            cmd.Parameters.AddWithValue("@EndDate", endDate.Value);
            cmd.CommandText = command;
            if (command != "")
            {
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                targetTable.DataSource = dt;
            }
            cmd.Parameters.Clear();
            cmd.Dispose();
        }

        public static void SearchCommandWitDateAssembler(DataGridView targetTable, TextBox tb, string tableName, string targetColumn, string orderBy, Guna2DateTimePicker startDate, Guna2DateTimePicker endDate, bool skipCheckNumericDataValidation = true, string ErrorParsing = "", bool ProductReport = true)
        {
            if (IsTextBoxHasNotEnoughData(tb))
            {
                ShowAllTableData(targetTable, tableName, orderBy);
                return;
            }
            string command;
            if (ProductReport)
                command = SearchCommandGeneratorWithDateForProductReport(tb, tableName, targetColumn, skipCheckNumericDataValidation, ErrorParsing);
            else
                command = SearchCommandGeneratorWithDateForInventoryReport(tb, tableName, targetColumn, skipCheckNumericDataValidation, ErrorParsing);
            SearchCommandApplyWithDate(targetTable, command, startDate, endDate);
        }

        public static void DateValidityChecker(Guna2DateTimePicker startDate, Guna2DateTimePicker endDate)
        {
            if (startDate.Value > endDate.Value)
            {
                startDate.Value = endDate.Value.AddDays(-1);
                return;
            }
        }

        public static bool CheckIfDataBaseAlreadyExists()
        {
            GeneralConnectionInitializer();
            cmd.Connection = conn;
            cmd.CommandText = $@"IF DB_ID('public') IS NOT NULL
                                SELECT 'true'
                                ELSE 
                                SELECT 'false'";
            return bool.Parse(cmd.ExecuteScalar().ToString());
        }

        public static bool IsUserExists(string username)
        {
            ConnectionInitializer();
            cmd.Parameters.AddWithValue("@usrname", username);
            cmd.Connection = conn;
            cmd.CommandText = $@"IF (SELECT username 
                                        FROM Roles
                                        WHERE username = @usrname) = @usrname
                            SELECT 'true'
                            ELSE 
                            SELECT 'false'";
            return bool.Parse(cmd.ExecuteScalar().ToString());
        }

        public static bool DoesUserWantToInstallFromSpecificBakFile()
        {
            DialogResult wantFromSpecificFile;
            wantFromSpecificFile = MessageBox.Show($"Do you want to install data from a backup instead of installing the default version ", "Inventory Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return wantFromSpecificFile == DialogResult.Yes;
        }

        public static void CreateDBIfNotExists()
        {
            if (!CheckIfDataBaseAlreadyExists())
            {
                try
                {
                    GeneralConnectionInitializer();
                    cmd.Connection = conn;
                    cmd.CommandText = @"IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Public')
                                BEGIN
                                    CREATE DATABASE [Public];
                                END";
                    cmd.ExecuteNonQuery();
                    string RestoreFromBakFileMessage = "";
                    if (DoesUserWantToInstallFromSpecificBakFile())
                    {
                        RestoreFromBakFileMessage = RestoreDBFromBakFile("Public");
                        MessageBox.Show(RestoreFromBakFileMessage);
                    }
                    if (RestoreFromBakFileMessage != "\nDatabase restored successfully!")
                    {
                        Assembly assembly = Assembly.GetExecutingAssembly();
                        string resourceName = "Inventory_Manager.DBTemplate.TemplateScript.sql";
                        using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                        {
                            if (stream != null)
                                using (StreamReader reader = new StreamReader(stream))
                                {
                                    cmd.CommandText = reader.ReadToEnd().Replace("GO", "");
                                    cmd.ExecuteNonQuery();
                                }
                            else
                                MessageBox.Show("The SQL file resource was not found.", "Resource Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }


                catch (Exception ex)
                {
                    MessageBox.Show("Error reading SQL file: " + ex.Message);
                }
            }
        }

        public static Stream FileGetterFromAssembly(string folderName, string fileName, string imageExtension)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = $"Inventory_Manager.{folderName}.{fileName}.{imageExtension}";
            Stream stream = assembly.GetManifestResourceStream(resourceName);
            if (stream != null)
                return stream;
            else
                return null;
        }

        public static void TextBoxAutoCompleteFromColumn(string table, string columnName, TextBox tb)
        {
            ConnectionInitializer();
            cmd.CommandText = $@"SELECT ""{columnName}""
                                FROM {table}";
            var suggestion = new AutoCompleteStringCollection();
            using (SqlDataReader myreader = cmd.ExecuteReader())
                while (myreader.Read())
                    suggestion.Add(myreader.GetValue(0).ToString());

            tb.AutoCompleteCustomSource = suggestion;
            tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tb.AutoCompleteMode = AutoCompleteMode.Suggest;
        }
        public static void TextBoxAutoCompleteFromColumnGuna(string table, string columnName, Guna2TextBox tb)
        {
            ConnectionInitializer();
            cmd.CommandText = $@"SELECT ""{columnName}""
                                FROM {table}";
            var suggestion = new AutoCompleteStringCollection();
            using (SqlDataReader myreader = cmd.ExecuteReader())
                while (myreader.Read())
                    suggestion.Add(myreader.GetValue(0).ToString());

            tb.AutoCompleteCustomSource = suggestion;
            tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tb.AutoCompleteMode = AutoCompleteMode.Suggest;
        }

        public static void SetDirPerminssionForSavingDB(string dirPath)
        {
            var serviceAccount = @"NT SERVICE\MSSQLSERVER";
            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);

            DirectoryInfo directoryInfo = new DirectoryInfo(dirPath);
            DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();
            directorySecurity.AddAccessRule(new FileSystemAccessRule(serviceAccount, FileSystemRights.FullControl, AccessControlType.Allow));
            directoryInfo.SetAccessControl(directorySecurity);
        }

        public static void PlaySound(Stream sound)
        {
            if (sound != null)
                using (SoundPlayer player = new SoundPlayer(sound))
                    player.Play();
        }

        public static void ProcessIsDoneMessageBox(string target , string doneProcess)
        {
            PlaySuccededSound();
            MessageBox.Show($"The {target} has been {doneProcess} successfully!" , "Done");
        }

        public static void ErrorOccuredMessageBox(string message)
        {
            PlayFailedSound();
            MessageBox.Show(message , "An error occured");
        }

        public static void IgnoredProcess(string message)
        {
            PlayNotificationSound();
            MessageBox.Show(message , "Ignored");
        }

        public static void PlayWrongPasswordSound()
        {
            PlaySound(FileGetterFromAssembly("Sounds", "ErrorLogIN", "wav"));
        }

        public static void PlaySuccededSound()
        {
            PlaySound(FileGetterFromAssembly("Sounds", "Successed", "wav"));
        }

        public static void PlayStartupSound()
        {
            PlaySound(FileGetterFromAssembly("Sounds", "StartUp", "wav"));
        }

        public static void PlayNotificationSound()
        {
            PlaySound(FileGetterFromAssembly("Sounds", "Notification", "wav"));
        }

        public static void PlayClickSound()

        {
            PlaySound(FileGetterFromAssembly("Sounds", "Click", "wav"));
        }

        public static void PlayFailedSound()
        {
            PlaySound(FileGetterFromAssembly("Sounds", "Error", "wav"));
        }

        public static void SetFilePermissionReading(string filePath)
        {
            string sqlServiceAccount = @"NT SERVICE\MSSQLSERVER";
            FileSecurity fileSecurity = File.GetAccessControl(filePath);
            fileSecurity.AddAccessRule(new FileSystemAccessRule(sqlServiceAccount, FileSystemRights.Read, AccessControlType.Allow));
            File.SetAccessControl(filePath, fileSecurity);
        }

        public static string CreateDBBackup(string targetDB)
        {
            try
            {
                ConnectionInitializer();
                cmd = conn.CreateCommand();
                var targetPath = $@"{documentsPath}\{programDirectoryName}\backups";
                var file = $@"PayTekDbBackupAt{DateTime.Now
                                            .ToShortDateString()
                                            .Replace('/', '-')}.bak";
                SetDirPerminssionForSavingDB(targetPath);
                if (File.Exists($@"{targetPath}\{file}"))
                    File.Delete($@"{targetPath}\{file}");
                cmd.CommandText = $@"BACKUP DATABASE 
                                                    [{targetDB}] TO DISK = 
                                                    '{targetPath}\{file}'
                                                    WITH FORMAT, INIT ;";
                cmd.ExecuteNonQuery();
                return $"\nSaved backup successfully at {targetPath}";
            }
            catch (Exception exc)
            {
                return $"\n{exc.Message}";
            }
        }

        public static string RestoreDBFromBakFile(string DBName)
        {
            GeneralConnectionInitializer();
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Backup files (*.bak)|*.bak|All files (*.*)|*.*";
                openFileDialog.Title = "Select a Backup File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string backupFilePath = openFileDialog.FileName;
                    SetFilePermissionReading(backupFilePath);

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
                        {
                            connection.Open();

                            using (SqlCommand cmd = new SqlCommand($@"USE master; 
                                                                      ALTER DATABASE ""{DBName}"" 
                                                                      SET SINGLE_USER WITH ROLLBACK IMMEDIATE;", connection))
                            {
                                cmd.ExecuteNonQuery();
                            }

                            using (SqlCommand cmd = new SqlCommand($@"USE master; 
                                                                     RESTORE DATABASE ""{DBName}"" 
                                                                     FROM DISK = '{backupFilePath}' WITH REPLACE;", connection))
                            {
                                cmd.ExecuteNonQuery();
                            }

                            using (SqlCommand cmd = new SqlCommand($@"USE master; 
                                                                      ALTER DATABASE ""{DBName}"" 
                                                                      SET MULTI_USER;", connection))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }

                        return $"\nDatabase restored successfully!";
                    }
                    catch (Exception exc)
                    {
                        return $"\n{exc.Message}";
                    }
                }
                else
                    return "\nYou did not choose a .bak file";
            }

        }

        private static void fadeInTimer_Tick_1(object sender, EventArgs e)
        {
            var targetForm = sender as FormTimerFadeEffectNeeds;
            if (targetForm.form.Opacity < 1)
                targetForm.form.Opacity += 0.025;
            else targetForm.timer.Stop();
        }

        public static void FadeInEffect(Form f, int interval = 5)
        {
            var fadeNeeds = new FormTimerFadeEffectNeeds(f, interval);
            fadeNeeds.timer.Tick += new EventHandler((object sender, EventArgs e) => fadeInTimer_Tick_1(fadeNeeds, e));
            fadeNeeds.timer.Start();
        }

        private static void fadeOutTimer_Tick_1(object sender, EventArgs e)
        {
            var targetForm = sender as FormTimerFadeEffectNeeds;
            if (targetForm.form.Opacity > 0)
                targetForm.form.Opacity -= 0.025;
            else
            {
                targetForm.timer.Stop();
                targetForm.form.Close();
            }
        }

        public static void FadeOutEffect(Form f, int interval = 5)
        {
            var fadeNeeds = new FormTimerFadeEffectNeeds(f, interval);
            fadeNeeds.timer.Tick += new EventHandler((object sender, EventArgs e) => fadeOutTimer_Tick_1(fadeNeeds, e));
            fadeNeeds.timer.Start();
        }

        #region password algorithms
        public static string Encrypt(string plaintext, int shift = 3)
        {
            StringBuilder asciiValues = new StringBuilder();

            foreach (char c in plaintext)
            {
                char encryptedChar;

                if (char.IsUpper(c))
                {
                    encryptedChar = (char)(((c + shift - 'A') % 26) + 'A');
                }
                else if (char.IsLower(c))
                {
                    encryptedChar = (char)(((c + shift - 'a') % 26) + 'a');
                }
                else
                {
                    encryptedChar = c;
                }

                asciiValues.Append((int)encryptedChar + " ");
            }

            return asciiValues.ToString().Trim();
        }

        public static string Decrypt(string asciiValues, int shift = 3)
        {
            StringBuilder decryptedText = new StringBuilder();
            string[] asciiArray = asciiValues.Split(' ');

            foreach (string asciiValue in asciiArray)
            {
                if (int.TryParse(asciiValue, out int value))
                {
                    char decryptedChar;

                    if (value >= 'A' && value <= 'Z')
                    {
                        decryptedChar = (char)((((value - 'A') - shift + 26) % 26) + 'A');
                    }
                    else if (value >= 'a' && value <= 'z')
                    {
                        decryptedChar = (char)((((value - 'a') - shift + 26) % 26) + 'a');
                    }
                    else
                    {
                        decryptedChar = (char)value; // Non-alphabetic characters remain unchanged
                    }

                    decryptedText.Append(decryptedChar);
                }
            }

            return decryptedText.ToString(); // Return the decrypted string
        }

        private static bool DeveloperPasswordMustBeUpdated()
        {
            if (!IsUserExists("malek"))
            {
                cmd.Parameters.AddWithValue("@username", "malek");
                cmd.Parameters.AddWithValue("@pass", Encrypt("anders"));
                cmd.Parameters.AddWithValue("@usertype", "Developer");
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.CommandText = @"INSERT INTO ROLES
                                    VALUES(@username , @pass , @usertype , @date)";
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return false;
            }

            ConnectionInitializer();
            cmd.Connection = conn;

            cmd.CommandText = @"SELECT ""Last modified"" 
                                FROM Roles
                                WHERE usertype = 'developer' ";
            var lastTimeOfGettingPrivatePasswordFromWeb =
                DateTime.Parse(cmd.ExecuteScalar().ToString());

            var TimeOfNow = DateTime.Now;

            var DifferenceBetwenLastUpdateOfPrivatePasswordAndNow = Abs
                ((TimeOfNow - lastTimeOfGettingPrivatePasswordFromWeb).TotalDays);

            return DifferenceBetwenLastUpdateOfPrivatePasswordAndNow > 30;
        }

        public static void DeveloperPasswordSetter(bool forceUpdate = false)
        {
            var inputToDataBasePrivatePassword = "";

            if (DeveloperPasswordMustBeUpdated() || forceUpdate)
            {
                string path = $@"{documentsPath}\{programDirectoryName}\";
                var file = $@"{path}private.txt";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var a = new WebClient();
                a.DownloadFile("https://drive.google.com/uc?export=download&id=1rBeJ9wz3WI6A4Ut-Vcyul-1BUzHYHU5d", file);

                var k = new StreamReader(file);

                inputToDataBasePrivatePassword = Encrypt(k.ReadToEnd());

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE Roles
                                        SET password = @password
                                        WHERE usertype = 'developer' ";
                cmd.Parameters.AddWithValue("@password", inputToDataBasePrivatePassword);
                cmd.ExecuteNonQuery();


                cmd.CommandText = @"UPDATE Roles
                                        SET ""last modified"" = @UpDate
                                        WHERE usertype = 'developer' ";
                cmd.Parameters.AddWithValue("@UpDate", DateTime.Now);
                cmd.ExecuteNonQuery();


                cmd.Parameters.Clear();
                k.Dispose();

                File.Delete(file);
            }


        }
        #endregion

    }
}
