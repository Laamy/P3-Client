using Sharpads.SDK;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Sharpads
{
    public class Game
    {
        public static string gameWindowTitle = "Minecraft";
        public static string gameWindowHost = "ApplicationFrameHost";
        public static string gameExecutableHost = "Minecraft.Windows.exe";
    }
    class mem
    {
        public static Mem m = new Mem();
        public static IntPtr mcWinHandle;
        public static uint mcWinProcId;

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hWnd, out Rect lpRect);
        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        public static extern bool GetAsyncKeyState(char vKey);

        public struct Rect
        {
            public int Left, Top, Right, Bottom;
        }
        public static Rect getMinecraftRect()
        {
            Rect rectMC = new Rect();
            GetWindowRect(mcWinHandle, out rectMC);
            return rectMC;
        }
        public static bool mcFocused()
        {
            StringBuilder sb = new StringBuilder(Game.gameWindowTitle.Length + 1);
            GetWindowText(GetForegroundWindow(), sb, Game.gameWindowTitle.Length + 1);
            return sb.ToString().CompareTo(Game.gameWindowTitle) == 0;
        }
        public static IntPtr isMinecraftFocusedInsert()
        {
            StringBuilder sb = new StringBuilder(Game.gameWindowTitle.Length + 1);
            GetWindowText(GetForegroundWindow(), sb, Game.gameWindowTitle.Length + 1);
            if (sb.ToString() == Game.gameWindowTitle)
                return (IntPtr)(-1);
            else
                return (IntPtr)(-2);
        }
        public static void openProcess()
        {
            mem.m = new SDK.Mem();
            mem.m.OpenProcess(mem.m.GetProcIdFromName("Minecraft.Windows.exe"));
            Process[] procs = Process.GetProcessesByName(Game.gameWindowHost);
            mcWinHandle = procs[0].MainWindowHandle;
            mcWinProcId = (uint)procs[0].Id;
        }
    }
}
