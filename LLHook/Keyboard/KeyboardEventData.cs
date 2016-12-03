using System;
using System.Runtime.InteropServices;

namespace LLHook.Keyboard
{
    [StructLayout(LayoutKind.Sequential)]
    public struct KeyboardEventData
    {
        public uint VirtualKeyCode;
        public uint HardwareScanCode;
        public KeyState Flags;
        public uint Timestamp;
        public IntPtr ExtraInfo;
    }
}
