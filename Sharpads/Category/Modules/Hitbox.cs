using Sharpads.SDK.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sharpads.Category.Modules
{
    public class Hitbox : Module
    {
        public Hitbox() : base("Hitbox", CategoryHandler.registry.categories[0], (char)0x07, false) { }

        public override void onEnable()
        {
            base.onEnable();
            List<Entity> elPlrs = Minecraft.ci.lp.Level.Players;
            foreach (Entity ent in elPlrs)
                if (ent.username == "EchoHackCmd" || ent.username == "PringleCPP6986")
                    ent.username = "Local MILF!";
                else if (ent.username == "whatsbrawlhalla")
                    ent.username = "Local EPIC PERSON!!!!!";
        }
    }
}
