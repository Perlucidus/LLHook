using System;
using System.Runtime.InteropServices;

namespace LLHook.Mouse
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MouseEventData
    {
        public POINT Location;
        public uint Data;
        public MouseState Flags;
        public uint Timestamp;
        public IntPtr ExtraInfo;
    }
}
