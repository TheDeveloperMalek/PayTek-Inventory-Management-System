using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Inventory_Manager
{
    public partial class terminal : Form
    {
        private const string Prompt = "PayTek Inventory Management System@{0}:~$ ";
        Color defaultColor = Color.White;
        Color errorColor = Color.Red;
        private Dictionary<string, string> commandsWithDescription = new Dictionary<string, string>();
        bool clearCommadIsAlreadyCalled = false;
        bool exitCommandIsTyped = false;
        public terminal()
        {
            InitializeComponent();
            InitializeTerminal();
            InitializeCommands();
        }
        private void InitializeTerminal()
        {
            AppendText(string.Format(Prompt, Environment.MachineName), Color.Green);
            cmdBox.Focus();
        }

        private void InitializeCommands()
        {
            commandsWithDescription.Add("clear", "Clear the terminal");
            commandsWithDescription.Add("describe", "Describe what command can do");
            commandsWithDescription.Add("dir", "Show directory of the products's images");
            commandsWithDescription.Add("exit" , "Exit the terminal");
            commandsWithDescription.Add("forcePasswordUpdate", "Update developer password");
            commandsWithDescription.Add("getAdmin", "Get admin's password");
            commandsWithDescription.Add("getUser", "Get user's password");
            commandsWithDescription.Add("list", "Show list of the commands");
            commandsWithDescription.Add("terminal", "Open a new terminal window");
        }

        private void cmdBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string command = cmdBox.Text.Substring(cmdBox.Text.LastIndexOf('$') + 1).Trim();
                ProcessCommand(command);
                if (!clearCommadIsAlreadyCalled && cmdBox.Text != "")
                {
                    cmdBox.AppendText(Environment.NewLine);
                }
                AppendText(string.Format(Prompt, Environment.MachineName), Color.Green);
                e.SuppressKeyPress = true;
                clearCommadIsAlreadyCalled = false;
            }
        }

        private void ProcessCommand(string command)
        {
            if(command != "")
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
                        {
                            if (commandsWithDescription.ContainsKey(explainedCommand[1]))
                                AppendText("\n" + commandsWithDescription[explainedCommand[1]], Color.Yellow);
                            else
                                AppendText("\nError: command not found", errorColor);
                        }
                    }
                    if (command == "forcePasswordUpdate")
                    {

                        try
                        {
                            ChangeUsersPassword.PrivatePassSetter(true);
                            Authorization.privatePassword = ChangeUsersPassword.PrivatePassGetter();
                            AppendText("\nThe password were updated Successfully!", defaultColor);
                            return;
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show(exc.Message);
                        }
                    }
                    if (command == "exit")
                    {
                        exitCommandIsTyped = true;
                        this.Dispose();
                    }

                    if (command == "terminal")
                    {
                        var a = new terminal();
                        a.Show();
                    }

                    if(command == "dir")
                    {
                        string path = $@"{Products.storeDataDirectory}\{Products.DirectoryName}\";
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        Process.Start(@"explorer.exe" , path);
                    }

                    if (command == "getUser")
                    {
                        AppendText("\nUser password: " + Authorization.newUserPassword , defaultColor);
                    }
                    if (command == "getAdmin")
                    {
                        AppendText("\nAdmin password: " + Authorization.newAdminPassword, defaultColor);
                    }
                }
                else
                    AppendText("\nError: command not found\nto show list of the commands type: list", errorColor);
            }
            else
                AppendText("\nError: you did not type a command\nto show list of the commands type: list", errorColor);
        }

        private void AppendText(string text, Color color)
        {
            if(!exitCommandIsTyped)
            {
            cmdBox.SelectionStart = cmdBox.Text.Length;
            cmdBox.SelectionLength = 0;
            cmdBox.SelectionColor = color;
            cmdBox.AppendText(text);
            cmdBox.SelectionColor = cmdBox.ForeColor; 
            cmdBox.ScrollToCaret(); 
            }
        }
    }

}
