using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace MemoryMagic
{
    [SuppressMessage("ReSharper", "FunctionNeverReturns")]
    public partial class MainWindow : Form
    {
        private static Lua lua;
        private Hook wowHook;

        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
        }

        public static MainWindow Instance { get; private set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            var firstRun = !File.Exists(Application.StartupPath + "\\config.ini");

            ConfigFile.Initialize();
            if (firstRun)
            {
                ConfigFile.WriteValue("MemoryMagic", "UserEmail", "");
                ConfigFile.WriteValue("MemoryMagic", "UserPassword", "");
            }

            Log.Write("Attempting to connect to running WoW.exe process...", Color.Black);

            var proc = Process.GetProcessesByName("WoW").FirstOrDefault();

            while (proc == null)
            {
                MessageBox.Show("Please open WoW, and login, and select your character before using the bot.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                proc = Process.GetProcessesByName("WoW").FirstOrDefault();
            }

            wowHook = new Hook(proc);
            wowHook.InstallHook();
            lua = new Lua(wowHook);

            Log.Write("Connected to process with ID = " + proc.Id, Color.Black);

            // Log.Write("Player Name: " + wowHook.Memory.ReadString(Offsets.PlayerNameOffset, Encoding.UTF8), Color.Black);

            CheckForIllegalCrossThreadCalls = false;

            var pulse = new Thread(delegate()
            {
                while (true)
                {
                    if (wowHook.Memory.Read<byte>(Offsets.GameState, true) == 1)
                    {
                        cmdLogin.Enabled = false;
                        cmdDance.Enabled = true;
                        cmdShoot.Enabled = true;
                    }
                    else
                    {
                        cmdLogin.Enabled = true;
                        cmdDance.Enabled = false;
                        cmdShoot.Enabled = false;
                    }
                    Thread.Sleep(100);
                }
            }) {IsBackground = true};
            pulse.Start();
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        { 
            lua.DoString($"AccountLogin.UI.AccountEditBox:SetText('{Security.UserEmail}')");
            lua.DoString($"AccountLogin.UI.PasswordEditBox:SetText('{Security.UserPassword}')");
            lua.DoString("AccountLogin_Login()");
        }

        private void cmdDance_Click(object sender, EventArgs e)
        {
            lua.DoString("DoEmote('Dance')");
        }

        private void cmdShoot_Click(object sender, EventArgs e)
        {
            lua.CastSpellByName("Steady Shot");
        }

        private void cmdSmite_Click(object sender, EventArgs e)
        {
            lua.CastSpellByName("Smite");
        }
    }
}