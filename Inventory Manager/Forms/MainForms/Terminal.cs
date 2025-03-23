using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class Terminal : Form
    {
        #region Essential Data
        private const string Prompt = "PayTek Inventory Management System@{0}(developer mode):~$ ";
        readonly Color defaultColor = Color.White;
        readonly Color errorColor = Color.Red;
        private readonly Dictionary<string, string> commandsWithDescription = new Dictionary<string, string>();
        bool clearCommadIsAlreadyCalled = false;
        bool exitCommandIsTyped = false;
        public Terminal()
        {
            InitializeComponent();
            InitializeTerminal();
            InitializeCommands();
            Shared.FadeInEffect(this);
            Shared.ConnectionInitializer();
        }
        private void InitializeTerminal()
        {
            AppendText(string.Format(Prompt, Environment.MachineName), Color.Green);
            cmdBox.Focus();
        }
        #endregion

        #region Startup Functions
        private void InitializeCommands()
        {
            commandsWithDescription.Add("bk", "Create a backup of the database");
            commandsWithDescription.Add("clear", "Clear the terminal");
            commandsWithDescription.Add("describe", "Describe what command can do");
            commandsWithDescription.Add("dir", "Show directory of the products's images");
            commandsWithDescription.Add("ed", "Password Encryptor Decryptor");
            commandsWithDescription.Add("forcePasswordUpdate", "Update developer password");
            commandsWithDescription.Add("list", "Show list of the commands");
            commandsWithDescription.Add("restore", "Restore database from a .bak file");
            commandsWithDescription.Add("terminal", "Open a new terminal window");
        }

        private void CmdBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string command = cmdBox.Text.Substring(cmdBox.Text.LastIndexOf('$') + 1).Trim();
                ProcessCommand(command);
                if (!clearCommadIsAlreadyCalled && cmdBox.Text != "")
                    cmdBox.AppendText(Environment.NewLine);
                AppendText(string.Format(Prompt, Environment.MachineName), Color.Green);
                e.SuppressKeyPress = true;
                clearCommadIsAlreadyCalled = false;
            }
        }

        private async void ProcessCommand(string command)
        {
            if (command != "")
            {
                if (commandsWithDescription.ContainsKey(command) || command.StartsWith("describe"))
                {
                    if (command == "list")
                    {
                        AppendText($"\nCommands:", defaultColor);
                        foreach (var item in commandsWithDescription.Keys)
                        {
                            AppendText($"\n\t{item}", defaultColor);
                        }
                        return;
                    }
                    if (command == "clear")
                    {
                        cmdBox.Text = "";
                        clearCommadIsAlreadyCalled = true;
                    }
                    if (command.StartsWith("describe"))
                    {
                        string[] explainedCommand = command.Split(' ');
                        if (explainedCommand.Length < 2)
                            AppendText("\nError: incorrect syntax\nCorrect Syntax : describe command_name\nExample : describe list", errorColor);
                        else
                            if (commandsWithDescription.ContainsKey(explainedCommand[1]))
                            AppendText("\n" + commandsWithDescription[explainedCommand[1]], Color.Yellow);
                        else
                            AppendText("\nError: command not found", errorColor);
                    }
                    if (command == "forcePasswordUpdate")
                    {

                        try
                        {
                            await Task.Run(() => Shared.DeveloperPasswordSetter(true));
                            AppendText("\nThe password were updated Successfully!\n", defaultColor);
                            AppendText(string.Format(Prompt, Environment.MachineName), Color.Green);
                            return;
                        }
                        catch (Exception exc)
                        {
                            AppendText("\n" + exc.Message, errorColor);
                        }
                    }
                    if (command == "terminal")
                    {
                        var a = new Terminal();
                        a.Show();
                    }
                    if (command == "dir")
                    {
                        string path = $@"{Shared.documentsPath}\{Shared.programDirectoryName}\";
                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);
                        Process.Start(@"explorer.exe", path);
                    }
                    if (command == "bk")
                        AppendText($"{Shared.CreateDBBackup("Public")}", defaultColor);
                    if (command == "ed")
                    {
                        var EncryptorDecryptor = new EncryptorDecryptor();
                        EncryptorDecryptor.Show();
                        AppendText("\nOpened Encryptor Decryptor Tool Successfully", defaultColor);
                    }
                    if (command == "restore")
                        AppendText(Shared.RestoreDBFromBakFile("Public"), defaultColor);

                }
                else
                    AppendText("\nError: command not found\nto show list of the commands type: list", errorColor);
            }
            else
                AppendText("\nError: you did not type a command\nto show list of the commands type: list", errorColor);
        }

        private void AppendText(string text, Color color)
        {
            if (!exitCommandIsTyped)
            {
                cmdBox.SelectionStart = cmdBox.Text.Length;
                cmdBox.SelectionLength = 0;
                cmdBox.SelectionColor = color;
                cmdBox.AppendText(text);
                cmdBox.SelectionColor = cmdBox.ForeColor;
                cmdBox.ScrollToCaret();
            }
        }
        #endregion
    }
}