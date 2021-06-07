using Microsoft.VisualBasic;
using Sharpads.SDK.SDK;
using System;

namespace Sharpads.Category.Modules
{
    public class YEditor : Module
    {
        public YEditor() : base("YEditor", CategoryHandler.registry.categories[4], (char)0x07, false) { }
        public override void onEnable()
        {
            base.onEnable();
            base.onDisable();
            Minecraft.ci.lp.teleport(Minecraft.ci.lp.X1, float.Parse(Interaction.InputBox("Please enter your new Y Position", "YEditor")), Minecraft.ci.lp.Z1);
        }
    }
}
