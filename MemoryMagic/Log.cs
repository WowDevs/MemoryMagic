using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MemoryMagic
{
    public static class Log
    {
        private const int WM_VSCROLL = 0x115;
        private const int SB_BOTTOM = 7;
        private static readonly string LogPath;

        static Log()
        {
            var logFolder = Path.Combine(TempPath, "Logs");
            if (!Directory.Exists(logFolder))
                Directory.CreateDirectory(logFolder);
            LogPath = Path.Combine(logFolder, $"Log[{DateTime.Now:yyyy-MM-dd_hh-mm-ss}].txt");
        }

        private static string TempPath => Path.GetTempPath();

        public static void Write(string format, params object[] args)
        {
            Write(Color.Black, format, args);
        }

        public static void Debug(string format, params object[] args)
        {
            Debug(Color.Black, format, args);
        }

        private static void Write(Color color, string format, params object[] args)
        {
            if (MainWindow.Instance == null)
                return;

            MainWindow.Instance.Invoke(
                new Action(() =>
                {
                    InternalWrite(color, string.Format(format, args));
                    WriteToLog(format, args);
                }));
        }

        private static void Debug(Color color, string format, params object[] args)
        {
            if (MainWindow.Instance == null)
                return;

            MainWindow.Instance.BeginInvoke(
                new Action(() =>
                {
                    InternalWrite(color, string.Format(format, args));
                    WriteToLog(format, args);
                }));
        }

        private static void InternalWrite(Color color, string text)
        {
            try
            {
                var rtb = MainWindow.Instance.LogTextBox;

                var maxsize = 10000;
                var dropsize = maxsize/100; // maxsize / 4;

                if (rtb.Text.Length > maxsize)
                {
                    // this method preserves the text colouring
                    // find the first end-of-line past the endmarker

                    var endmarker = rtb.Text.IndexOf('\n', dropsize) + 1;
                    if (endmarker < dropsize)
                        endmarker = dropsize;

                    rtb.Select(0, endmarker);
                    rtb.SelectedText = "";
                }

                rtb.SelectionStart = rtb.Text.Length;
                rtb.SelectionLength = 0;
                rtb.SelectionColor = color;
                rtb.AppendText($"[{DateTime.Now:T}] {text}\r");

                rtb.ClearUndo();

                ScrollToBottom(rtb);
            }
            catch
            {
                // ignored
            }
        }

        public static void WriteToLog(string format, params object[] args)
        {
            try
            {
                using (var logStringWriter = new StreamWriter(LogPath, true))
                {
                    logStringWriter.WriteLine("[" + DateTime.Now.ToString(CultureInfo.InvariantCulture) + "] " + format, args);
                }
            }
            catch
            {
                // ignored
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        ///     Scrolls the vertical scroll bar of a multi-line text box to the bottom.
        /// </summary>
        /// <param name="tb">The text box to scroll</param>
        private static void ScrollToBottom(RichTextBox tb)
        {
            if (Environment.OSVersion.Platform != PlatformID.Unix)
                SendMessage(tb.Handle, WM_VSCROLL, new IntPtr(SB_BOTTOM), IntPtr.Zero);
        }
    }
}