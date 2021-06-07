using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sharpads.Category.Modules
{
    public class Eject : Module
    {
        public Eject() : base("Eject", CategoryHandler.registry.categories[5], (char)0x07, false) { }

        public override void onEnable() => Process.GetCurrentProcess().Kill();
    }
}
