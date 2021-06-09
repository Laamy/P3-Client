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
            get => mem.m.ReadByte(addr + Pointers.onGround_Hex.ToString("X"));
            set => mem.m.WriteMemory(addr + Pointers.onGround_Hex.ToString("X"), "byte", value.ToString());
        }

        public bool inWater
        {
            get
            {
                if (mem.m.ReadByte(addr + Pointers.inWater_Hex.ToString("X")) == 1)
                    return true;
                else
                    return false;
            }
        }

        public string type
        {
            get => mem.m.ReadString(addr + Pointers.Type_Hex.ToString("X"), "", 32);
        }

        public bool lookingAtEntity
        {
            get
            {
                int bytert = mem.m.ReadInt(addr + Pointers.LookingEntityID_Hex.ToString("X")); // Entity id.
                if (bytert == -1)
                    return false;
                else return true;
            }
        }

        public int lookingAtEntity_ID
        {
            get
            {
                int bytert = mem.m.ReadInt(addr + Pointers.LookingEntityID_Hex.ToString("X")); // Entity id.
                return bytert;
            }
        }

        public float stepHeight
        {
            get => mem.m.ReadFloat(addr + Pointers.Step_Hex.ToString("X"));
            set => mem.m.WriteMemory(addr + Pointers.Step_Hex.ToString("X"), "float", value.ToString());
        }

        public string username
        {
            get => mem.m.ReadString(addr + Pointers.Username_Hex.ToString("X"), "", 30);
            set => mem.m.WriteMemory(addr + Pointers.Username_Hex.ToString("X"), "string", value.ToString());
        }

        public float swingingAnimation
        {
            get => mem.m.ReadFloat(addr + Pointers.SwingAn_Hex.ToString("X"));
            set => mem.m.WriteMemory(addr + Pointers.SwingAn_Hex.ToString("X"), "float", value.ToString());
        }

        public float X1
        {
            get => mem.m.ReadFloat(addr + Pointers.PositionX_Hex.ToString("X"));
            set => mem.m.WriteMemory(addr + Pointers.PositionX_Hex.ToString("X"), "float", value.ToString());
        }

        public float Y1
        {
            get => mem.m.ReadFloat(addr + (Pointers.PositionX_Hex + 4).ToString("X"));
            set => mem.m.WriteMemory(addr + (Pointers.PositionX_Hex + 4).ToString("X"), "float", value.ToString());
        }

        public float Z1
        {
            get => mem.m.ReadFloat(addr + (Pointers.PositionX_Hex + 8).ToString("X"));
            set => mem.m.WriteMemory(addr + (Pointers.PositionX_Hex + 8).ToString("X"), "float", value.ToString());
        }

        public float X2
        {
            get => mem.m.ReadFloat(addr + (Pointers.PositionX_Hex + 12).ToString("X"));
            set => mem.m.WriteMemory(addr + (Pointers.PositionX_Hex + 12).ToString("X"), "float", value.ToString());
        }

        public float Y2
        {
            get => mem.m.ReadFloat(addr + (Pointers.PositionX_Hex + 16).ToString("X"));
            set => mem.m.WriteMemory(addr + (Pointers.PositionX_Hex + 16).ToString("X"), "float", value.ToString());
        }

        public float Z2
        {
            get => mem.m.ReadFloat(addr + (Pointers.PositionX_Hex + 20).ToString("X"));
            set => mem.m.WriteMemory(addr + (Pointers.PositionX_Hex + 20).ToString("X"), "float", value.ToString());
        }

        public float velX
        {
            get => mem.m.ReadFloat(addr + Pointers.VelocityX_Hex.ToString("X"));
            set => mem.m.WriteMemory(addr + Pointers.VelocityX_Hex.ToString("X"), "float", value.ToString());
        }

        public float velY
        {
            get => mem.m.ReadFloat(addr + Pointers.VelocityY_Hex.ToString("X"));
            set => mem.m.WriteMemory(addr + Pointers.VelocityY_Hex.ToString("X"), "float", value.ToString());
        }

        public float velZ
        {
            get => mem.m.ReadFloat(addr + Pointers.VelocityZ_Hex.ToString("X"));
            set => mem.m.WriteMemory(addr + Pointers.VelocityZ_Hex.ToString("X"), "float", value.ToString());
        }

        public float yaw
        {
            get => mem.m.ReadFloat(addr + Pointers.Camera_Hex);
            set => mem.m.WriteMemory(addr + Pointers.Camera_Hex, "float", value.ToString());
        }

        public float pitch
        {
            get => mem.m.ReadFloat(addr + (Pointers.Camera_Hex + 4).ToString("X"));
            set => mem.m.WriteMemory(addr + (Pointers.Camera_Hex + 4).ToString("X"), "float", value.ToString());
        }
    }
}
