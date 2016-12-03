# LLHook
Low level mouse and keyboard hook library

## Usage

### Hook Keyboard
```C#
LowLevelKeyboardHook LLKH = new LowLevelKeyboardHook();
LLKH.KeyboardAction += OnKeyboardAction;
LLKH.Start();

void OnKeyboardAction(object sender, KeyboardActionEventArgs e)
{
    Keys key = (Keys)e.Data.VirtualKeyCode;
    switch (e.Action)
    {
        case KeyboardAction.KeyDown:
        case KeyboardAction.SysKeyDown:
            if (key == Keys.G)
                Console.WriteLine("G is held");
            break;
        case KeyboardAction.KeyUp:
        case KeyboardAction.SysKeyUp:
            if (key == Keys.G)
                Console.WriteLine("G is released")
            break;
    }
}
```

### Hook Mouse
```C#
LowLevelMouseHook LLMH = new LowLevelMouseHook();
LLMH.KeyboardAction += OnMouseAction;
LLMH.Start();

void OnMouseAction(object sender, MouseActionEventArgs e)
{
    if (e.Action == MouseAction.WM_LBUTTONDOWN)
        Console.WriteLine("Left mouse button is down");
}
```
