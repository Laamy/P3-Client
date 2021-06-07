using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.SDK.SDK
{
    public class Level : SDKObject
    {
        public Level(string addr) : base(addr) { }

        public Entity lookingEntity
        {
            get => new Entity("");
        }

        public ulong setLookingEnt
        {
            get => 0;
        }

        public int lookingState
        {
            get => 0;
            set { }
        }

        public int lookingBlockSide
        {
            get => 0;
            set { }
        }
        public int lookingBlockX
        {
            get => 0;
            set { }
        }
        public int lookingBlockY
        {
            get => 0;
            set { }
        }
        public int lookingBlockZ
        {
            get => 0;
            set { }
        }

        public List<Entity> getMovingEntities
        {
            get
            {
                /*
                List<Entity> Entities = new List<Entity>();
                ulong startList = MCM.readInt64(addr + 0x40);
                ulong endList = MCM.readInt64(addr + 0x48);
                for (ulong ent = startList; ent < endList; ent += 0x8)
                {
                    if (ent == startList) continue;
                    Entity entObj = new Entity(MCM.readInt64(ent));
                    if (entObj.movedTick > 1) Entities.Add(entObj);
                }
                return Entities;*/
                return new List<Entity>();
            }
        }

        public List<Entity> getAllEntities
        {
            get
            {
                /*
                List<Entity> Entities = new List<Entity>();
                ulong startList = MCM.readInt64(addr + 0x40);
                ulong endList = MCM.readInt64(addr + 0x48);
                for (ulong ent = startList; ent < endList; ent += 0x8)
                {
                    if (ent == startList) continue;
                    Entity entObj = new Entity(MCM.readInt64(ent));
                    Entities.Add(entObj);
                }
                return Entities;*/
                return new List<Entity>();
            }
        }

        /*public List<Gamerule> gamerules
        {
            get
            {
                List<Gamerule> returnRules = new List<Gamerule>();
                for (ulong ruleIndex = 0; ruleIndex < 28; ruleIndex++)
                {
                    returnRules.Add(new Gamerule(MCM.readInt64(addr + 0x340) + (ruleIndex * 176)));
                }
                return returnRules;
            }
        }*/
    }
}
