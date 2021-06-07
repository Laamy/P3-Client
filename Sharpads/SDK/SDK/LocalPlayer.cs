using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.SDK.SDK
{
    public class LocalPlayer : Actor // Ends at 27F8
    {
        public LocalPlayer(string addr) : base(addr) { }

        public int hitting
        {
            get => mem.m.ReadByte(Pointers.hitting);
            set => mem.m.WriteMemory(Pointers.hitting, "byte", value.ToString());
        }
        public int sprinting
        {
            get => mem.m.ReadByte(Pointers.sprinting);
            set => mem.m.WriteMemory(Pointers.sprinting, "byte", value.ToString());
        }

        public EntityRegistry Level
        {
            get => new EntityRegistry(addr + "358,58,");
        }

        public void teleport(float x, float y, float z)
        {
            X1 = x;
            X2 = x + 0.6f;
            Y1 = y;
            Y2 = y + 1.8f;
            Z1 = z;
            Z2 = z + 0.6f;
        }

        public Utils.Vec3f lookingVec
        { get => Utils.directionalVector((Minecraft.ci.lp.yaw + 89.9f) * (float)Math.PI / 178F, Minecraft.ci.lp.pitch * (float)Math.PI / 178F); }

        public double velocityXZ
        { get => Math.Sqrt(velX * velX + velZ * velZ); }

        public double velocityXYZ
        { get => Math.Sqrt(velX * velX + velY * velY + velZ * velZ); }

        public int onGround
        {
            get => mem.m.ReadByte(addr + "1C0");
            set => mem.m.WriteMemory(addr + "1C0", "byte", value.ToString());
        }

        public bool inWater
        {
            get
            {
                if (mem.m.ReadByte(addr + "245") == 1)
                    return true;
                else
                    return false;
            }
        }

        public float hitboxWidth
        {
            get => mem.m.ReadFloat(addr + "4BC");
            set => mem.m.WriteMemory(addr + "4BC", "float", value.ToString());
        }

        public float hitboxHeight
        {
            get => mem.m.ReadFloat(addr + "4C0");
            set => mem.m.WriteMemory(addr + "4C0", "float", value.ToString());
        }

        public string type
        {
            get => mem.m.ReadString(addr + "3F0", "", 32);
        }

        public bool lookingAtEntity
        {
            get
            {
                int bytert = mem.m.ReadInt(addr + "1000"); // Entity id.
                if (bytert == -1)
                    return false;
                else return true;
            }
        }

        public int lookingAtEntity_ID
        {
            get
            {
                int bytert = mem.m.ReadInt(addr + "1000"); // Entity id.
                return bytert;
            }
        }

        public float stepHeight
        {
            get => mem.m.ReadFloat(addr + "220");
            set => mem.m.WriteMemory(addr + "220", "float", value.ToString());
        }

        public string username
        {
            get => mem.m.ReadString(addr + "888", "", 30);
            set => mem.m.WriteMemory(addr + "888", "string", value.ToString());
        }

        public float swingingAnimation
        {
            get => mem.m.ReadFloat(addr + "708");
            set => mem.m.WriteMemory(addr + "708", "float", value.ToString());
        }

        public float X1
        {
            get => mem.m.ReadFloat(addr + "4A0");
            set => mem.m.WriteMemory(addr + "4A0", "float", value.ToString());
        }

        public float Y1
        {
            get => mem.m.ReadFloat(addr + "4A4");
            set => mem.m.WriteMemory(addr + "4A4", "float", value.ToString());
        }

        public float Z1
        {
            get => mem.m.ReadFloat(addr + "4A8");
            set => mem.m.WriteMemory(addr + "4A8", "float", value.ToString());
        }

        public float X2
        {
            get => mem.m.ReadFloat(addr + "4AC");
            set => mem.m.WriteMemory(addr + "4AC", "float", value.ToString());
        }

        public float Y2
        {
            get => mem.m.ReadFloat(addr + "4B0");
            set => mem.m.WriteMemory(addr + "4B0", "float", value.ToString());
        }

        public float Z2
        {
            get => mem.m.ReadFloat(addr + "4B4");
            set => mem.m.WriteMemory(addr + "4B4", "float", value.ToString());
        }

        public float velX
        {
            get => mem.m.ReadFloat(addr + "4DC");
            set => mem.m.WriteMemory(addr + "4DC", "float", value.ToString());
        }

        public float velY
        {
            get => mem.m.ReadFloat(addr + "4E0");
            set => mem.m.WriteMemory(addr + "4E0", "float", value.ToString());
        }

        public float velZ
        {
            get => mem.m.ReadFloat(addr + "4E4");
            set => mem.m.WriteMemory(addr + "4E4", "float", value.ToString());
        }

        public float yaw
        {
            get => mem.m.ReadFloat(addr + "124");
            set => mem.m.WriteMemory(addr + "124", "float", value.ToString());
        }

        public float pitch
        {
            get => mem.m.ReadFloat(addr + "128");
            set => mem.m.WriteMemory(addr + "128", "float", value.ToString());
        }
    }
}
