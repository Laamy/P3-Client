using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sharpads.Category.Modules
{
    public class Limiter : Module
    {
        public Limiter() : base("Limiter", CategoryHandler.registry.categories[5], (char)0x07, false) { }

        public override void onEnable() => Program.limiter = true;
        public override void onDisable() => Program.limiter = false;
    }
}
