using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using Sharpads.Category;

namespace Sharpads.UI
{
    public partial class Render : Form
    {
        public static Render handle;

        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        public delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);
        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);
        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr voidProcessId);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);
        private struct WINDOWPLACEMENT
        {
            public int length, flags, showCmd;
            public Point ptMinPosition, ptMaxPosition;
            public Rectangle rcNormalPosition;
        }

        public static event EventHandler postOverlayLoad;
        public delegate void fixSizeDel();

        public float rainbowProg = 0f;

        WinEventDelegate overDel;

        IntPtr hWnd;
        public int x = 0;
        public int y = 0;
        public int width = 0;
        public int height = 0;
        public int fullScOff = 0;
        public SolidBrush rainbow
        { get => new SolidBrush(Rainbow(rainbowProg)); }

        public Font font = new Font("Arial", 16, FontStyle.Regular);

        public Render()
        {
            InitializeComponent();
            ShowInTaskbar = false;
            FormClosing += new FormClosingEventHandler(OverlayHost_FormClosing);
            AutoScaleMode = AutoScaleMode.None;
            handle = this;
            TopMost = true;
            Console.WriteLine("Starting Tab GUI...");
            FormBorderStyle = FormBorderStyle.None;
            TransparencyKey = Color.FromArgb(77, 77, 77);
            BackColor = TransparencyKey;
            Location = new Point(0, 0);
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            hWnd = Handle;
            overDel = new WinEventDelegate(adjustOverlay);
            SetWinEventHook((uint)SWEH_Events.EVENT_OBJECT_LOCATIONCHANGE, (uint)SWEH_Events.EVENT_OBJECT_LOCATIONCHANGE, IntPtr.Zero, overDel, (uint)mem.mcWinProcId, GetWindowThreadProcessId(mem.mcWinHandle, IntPtr.Zero), (uint)SWEH_dwFlags.WINEVENT_OUTOFCONTEXT | (uint)SWEH_dwFlags.WINEVENT_SKIPOWNPROCESS | (uint)SWEH_dwFlags.WINEVENT_SKIPOWNTHREAD);
            SetWinEventHook((uint)SWEH_Events.EVENT_SYSTEM_FOREGROUND, (uint)SWEH_Events.EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, overDel, 0, 0, (uint)SWEH_dwFlags.WINEVENT_OUTOFCONTEXT | (uint)SWEH_dwFlags.WINEVENT_SKIPOWNPROCESS | (uint)SWEH_dwFlags.WINEVENT_SKIPOWNTHREAD);
            if (postOverlayLoad != null) postOverlayLoad.Invoke(this, new EventArgs());
            Paint += OverlayHost_Paint;
            Paint += Program.Update;
        }

        private void OverlayHost_Paint(object sender, PaintEventArgs e)
        {
            foreach (Category.Category cat in CategoryHandler.registry.categories)
                foreach (Module mod in cat.modules)
                    if (mod.enabled && mod is VisualModule)
                        ((VisualModule)mod).onDraw(e.Graphics);
        }

        public void adjustOverlay(IntPtr ghfgh, uint gfh, IntPtr gnhbd, int hfkjmn, int jgh, uint tfujh, uint jhfuy)
        {
            WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
            GetWindowPlacement(mem.mcWinHandle, ref placement);
            if (placement.showCmd == 3)
            {
                fullScOff = 8;
                TopMost = true;
                WindowState = FormWindowState.Maximized;
            }
            else fullScOff = 0;
            mem.Rect mcRect = mem.getMinecraftRect();
            x = mcRect.Left + 9;
            y = mcRect.Top + 34 + fullScOff;
            width = mcRect.Right - mcRect.Left - 18;
            height = mcRect.Bottom - mcRect.Top - 43 - fullScOff;
            SetWindowPos(hWnd, mem.isMinecraftFocusedInsert(), x, y, width, height, 0x0040);
        }

        public static Color Rainbow(float progress)
        {
            float div = (Math.Abs(progress % 1) * 6);
            int ascending = (int)((div % 1) * 255);
            int descending = 255 - ascending;

            switch ((int)div)
            {
                case 0: return Color.FromArgb(255, 255, ascending, 0);
                case 1: return Color.FromArgb(255, descending, 255, 0);
                case 2: return Color.FromArgb(255, 0, 255, ascending);
                case 3: return Color.FromArgb(255, 0, descending, 255);
                case 4: return Color.FromArgb(255, ascending, 0, 255);
                default: return Color.FromArgb(255, 255, 0, descending);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new Size(284, 261);
            this.Name = "OverlayHost";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);

        }

        private void OverlayHost_FormClosing(object sender, FormClosingEventArgs e) { }
    }
}
