using Sharpads.Category.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.Category
{
    public class ModuleHandler
    {
        public static ModuleHandler registry;
        public ModuleHandler()
        {
            registry = this;
            Console.WriteLine("Registering modules");

            // Combat
            new BoostHit();
            new Hitbox();
            new QuerkBot();
            new RapidClick();
            new Reach();
            new TriggerBot();

            // Movement
            new AutoSprint();
            new AutoWalk();
            new Bhop();
            new BounceFly();
            new CubeCraftFly();
            new Jetpack();
            new JitterFly();
            new MineplexFly();
            new Sex_Lifeboat_Staff();
            new TPFlight();
            new WaterSpeed();

            // Player
            new AirJump();
            new Glide();
            new HighJump();
            new Jesus();
            new LBSlowFall();
            new PlayerSpeed();
            new StepHeight();
            new Velocity();
            new YBoost();

            // Visual
            new AlwaysDay();
            new ArrayList();
            new ExtraMods();
            new Nightmode();
            new NoSwing();
            new Zoom();

            // World
            new FixHitbox();
            new Lagcall();
            new GMSpoof();
            new Noclip();
            new SelfKick();
            new Phase();
            new Recall();
            new YEditor();

            // Other
            new Eject();
            new Limiter();
            new TestModule();
            // new LBSF();

            Console.WriteLine("Modules registered!");
            startModuleThread();
        }

        public void tickModuleThread()
        {
            foreach (Category category in CategoryHandler.registry.categories)
            {
                foreach (Module module in category.modules)
                {
                    try
                    {
                        module.onLoop().ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.StackTrace);
                    }
                }
            }
        }
        public void startModuleThread()
        {
            Console.WriteLine("Starting module thread..");
            Program.mainLoop += (object sen, EventArgs e) => { tickModuleThread(); };
            Console.WriteLine("Module thread started!");
        }
    }
}
