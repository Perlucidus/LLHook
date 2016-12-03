using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static LLHook.HookAPI;

namespace LLHook.Mouse
{
    public class LowLevelMouseHook
    {
        public class MouseActionEventArgs : EventArgs
        {
            public MouseAction Action;
            public MouseEventData Data;
            public bool IsCancelled;
        }
        public event EventHandler<MouseActionEventArgs> MouseAction;

        private IntPtr m_hhook;
        private HookProc m_hookProc;

        public LowLevelMouseHook()
        {
            m_hhook = IntPtr.Zero;
            m_hookProc = LLKeyboardProc;
        }

        public void Start()
        {
            if (m_hhook != IntPtr.Zero)
                return;
            m_hhook = SetHook(m_hookProc);
        }

        public void Stop()
        {
            if (m_hhook == IntPtr.Zero)
                return;
            UnhookWindowsHookEx(m_hhook);
            m_hhook = IntPtr.Zero;
        }

        private IntPtr SetHook(HookProc lpfn)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
                return SetWindowsHookEx((int)WindowsHook.WH_MOUSE_LL, lpfn, Kernel32.GetModuleHandle(curModule.ModuleName), 0);
        }

        private IntPtr LLKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            MouseActionEventArgs eventArgs = new MouseActionEventArgs { IsCancelled = false };
            if (nCode >= 0)
            {
                eventArgs.Action = (MouseAction)wParam.ToInt32();
                eventArgs.Data = Marshal.PtrToStructure<MouseEventData>(lParam);
                try
                {
                    MouseAction?.Invoke(this, eventArgs);
                }
                catch { }
            }
            return eventArgs.IsCancelled ? (IntPtr)1 : CallNextHookEx(m_hhook, nCode, wParam, lParam);
        }
    }
}
