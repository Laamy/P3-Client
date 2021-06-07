using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sharpads.SDK.SDK
{
    public class EntityRegistry : SDKObject
    {
        public EntityRegistry(string addr) : base(addr) { }
        public List<Entity> Entities
        {
            get
            {
                List<Entity> entityList = new List<Entity>();
                for (int index = 0; index < 256; index++)
                {
                    Entity mob = new Entity(addr + (0x8 * index) + ",");
                    if (mob.type != "" && mob.type != "player") entityList.Add(mob);
                }
                return entityList;
            }
        }
        public List<Entity> Players
        {
            get
            {
                List<Entity> entityList = new List<Entity>();
                for (int index = 0; index < 256; index++)
                {
                    Entity mob = new Entity(addr + (0x8 * index) + ",");
                    if (mob.type == "player") entityList.Add(mob);
                }
                return entityList;
            }
        }
        public List<Entity> Everything
        {
            get
            {
                List<Entity> entityList = new List<Entity>();
                for (int index = 0; index < 256; index++)
                    entityList.Add(new Entity(addr + (0x8 * index) + ","));
                return entityList;
            }
        }
    }
}
