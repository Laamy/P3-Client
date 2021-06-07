using Sharpads.Category;
using Sharpads.SDK.SDK;
using Sharpads.UI;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Sharpads
{
    public class KeybindHandler
    {
        public static bool isKeyDown(char key)
        {
            if (mem.mcFocused())
                return mem.GetAsyncKeyState(key);
            return false;
        }

        public static KeybindHandler handler;
        public static EventHandler<clientKeyEvent> clientKeyDownEvent;
        public static EventHandler<clientKeyEvent> clientKeyHeldEvent;
        public static EventHandler<clientKeyEvent> clientKeyUpEvent;

        Dictionary<char, uint> downBuffs = new Dictionary<char, uint>();
        Dictionary<char, bool> noKey = new Dictionary<char, bool>();

        Dictionary<char, uint> releaseBuffs = new Dictionary<char, uint>();
        Dictionary<char, bool> yesKey = new Dictionary<char, bool>();

        public KeybindHandler()
        {
            handler = this;
            Console.WriteLine("Starting key thread");
            for (char c = (char)0; c < 0xFF; c++)
            {
                downBuffs.Add(c, 0);
                noKey.Add(c, true);
            }
            for (char c = (char)0; c < 0xFF; c++)
            {
                releaseBuffs.Add(c, 0);
                yesKey.Add(c, true);
            }
            Program.mainLoop += (object sen, EventArgs e) =>
            {
                try
                {
                    if (mem.mcFocused())
                    {
                        for (char c = (char)0; c < 0xFF; c++)
                        {
                            noKey[c] = true;
                            yesKey[c] = false;
                            if (mem.GetAsyncKeyState(c))
                            {
                                if (clientKeyHeldEvent != null)
                                    clientKeyHeldEvent.Invoke(this, new clientKeyEvent(c));
                                noKey[c] = false;
                                if (downBuffs[c] > 0) continue;
                                downBuffs[c]++;
                                if (Render.handle != null)
                                    Render.handle.Invalidate();
                                try
                                {
                                    if (clientKeyDownEvent != null)
                                        clientKeyDownEvent.Invoke(this, new clientKeyEvent(c));
                                }
                                catch (Exception) { }
                            }
                            else
                            {
                                yesKey[c] = true;
                                if (releaseBuffs[c] > 0) continue;
                                releaseBuffs[c]++;
                                if (Render.handle != null)
                                    Render.handle.Invalidate();
                                if (clientKeyUpEvent != null)
                                {
                                    try
                                    {
                                        clientKeyUpEvent.Invoke(this, new clientKeyEvent(c));
                                    }
                                    catch (Exception) { }
                                }
                            }
                            if (noKey[c]) downBuffs[c] = 0;
                            if (!yesKey[c]) releaseBuffs[c] = 0;
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("KeyHandler failed a task!");
                }
            };

            clientKeyDownEvent += dispatchKeybinds;
            Console.WriteLine("Key handlers loaded");
        }

        public void dispatchKeybinds(object sender, clientKeyEvent e)
        {
            foreach (Category.Category cat in CategoryHandler.registry.categories)
                foreach (Category.Module mod in cat.modules)
                    if (mod.keybind == e.key && Minecraft.inGUI)
                        mod.enabled = !mod.enabled;
        }
    }
    public class clientKeyEvent : EventArgs
    {
        public char key;
        public clientKeyEvent(char key) => this.key = key;
    }
}
