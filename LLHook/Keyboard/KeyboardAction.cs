using System;

namespace LLHook.Keyboard
{
    public enum KeyboardAction : UInt32
    {
        KeyDown = 0x0100,
        KeyUp = 0x0101,
        SysKeyDown = 0x0104,
        SysKeyUp = 0x0105
    }
}
