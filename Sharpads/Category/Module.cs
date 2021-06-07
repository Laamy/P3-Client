using System;
using System.Threading.Tasks;
using System.Timers;

namespace Sharpads.Category
{
    public abstract class Module
    {
        public string name;
        public bool enabled;
        public bool selected;
        public int keybind;

        private bool wasEnabled = false;
        public EventHandler toggleEvent;

        public Module(string name, Category category, int keybind, bool enabled)
        {
            this.name = name;
            this.keybind = keybind;
            this.enabled = enabled;
            category.modules.Add(this);
            bool succ = false;
        }

        public void startTimer(int millis)
        {
            Timer timer = new Timer();
            timer.Interval = millis;
            timer.Elapsed += (object send, ElapsedEventArgs arg) =>
            {
                if (enabled)
                {
                    onTimedTick();
                }
            };
            timer.Start();
        }


        public virtual void onEnable()
        {
        }
        public virtual void onDisable()
        {
        }
        //Called like a loop when enabled
        public virtual void onTick()
        {

        }
        //Called no matter what
        public virtual async Task onLoop()
        {
            if (wasEnabled != enabled)
            {
                if (enabled == false)
                {
                    onDisable();
                    try
                    {
                        if (toggleEvent != null)
                            toggleEvent.Invoke(this, new EventArgs());
                    }
                    catch (Exception) { }
                }
                else
                {
                    onEnable();
                    try
                    {
                        if (toggleEvent != null)
                            toggleEvent.Invoke(this, new EventArgs());
                    }
                    catch (Exception) { }
                }
                wasEnabled = enabled;
            }
            if (enabled)
            {
                try
                {
                    onTick();
                }
                catch (Exception) { }
            }
            return;
        }

        //Called at a defined time repeatedly
        public virtual void onTimedTick()
        {

        }
    }
}
