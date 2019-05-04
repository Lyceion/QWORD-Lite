using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace QWORD_LITE
{
    public class LocalPlayerGS
    {
        private static int BaseAddress = global.processSession.ReadInt32((IntPtr)global.clientModule.moduleAddress + Hack.signatures.dwLocalPlayer);
        //
        // Gets
        //
        public static int Health
        {
            get
            {
                return global.processSession.ReadInt32((IntPtr)BaseAddress + Hack.netvars.m_iHealth);
            }
        }
        public static int Armor
        {
            get
            {
                return global.processSession.ReadInt32((IntPtr)BaseAddress + Hack.netvars.m_ArmorValue);
            }
        }
        public static bool HasHelmet
        {
            get
            {
                return global.processSession.ReadBoolean((IntPtr)BaseAddress + Hack.netvars.m_bHasHelmet);
            }
        }
        public static int myWeaponID
        {
            get
            {
                return global.processSession.ReadByte((IntPtr)BaseAddress + Hack.netvars.m_hActiveWeapon);
            }
        }
        public static int scopeLevel
        {
            get
            {
                int nxp = global.processSession.ReadInt32((IntPtr)BaseAddress + Hack.netvars.m_flNextPrimaryAttack);
                if (nxp > 89)
                {
                    return 0;
                }
                else if (nxp < 50 && nxp > 35)
                {
                    return 1;
                }
                else if (nxp < 35)
                {
                    return 2;
                }
                else
                {
                    return 3;
                }
            }
        }
        public static int FOV
        {
            get
            {
                return global.processSession.ReadInt32((IntPtr)BaseAddress + Hack.netvars.m_iFOVStart);
            }
        }
        public static int Team
        {
            get
            {
                return global.processSession.ReadInt32((IntPtr)BaseAddress + Hack.netvars.m_iTeamNum);
            }
        }
        public static bool nowDead
        {
            get
            {
                if (0 > global.processSession.ReadInt32((IntPtr)BaseAddress + Hack.netvars.m_lifeState))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static bool Spotted
        {
            get
            {
                return global.processSession.ReadBoolean((IntPtr)BaseAddress + Hack.netvars.m_bSpotted);
            }
        }
        public static bool isScoped
        {
            get
            {
                return global.processSession.ReadBoolean((IntPtr)BaseAddress + Hack.netvars.m_bIsScoped);
            }
        }
        public static float flashMaxAlpha
        {
            get
            {
                return global.processSession.ReadFloat((IntPtr)BaseAddress + Hack.netvars.m_flFlashMaxAlpha);
            }
            set
            {
                if (value <= 255 && value >= 0)
                {
                    global.processSession.WriteFloat((IntPtr)BaseAddress + Hack.netvars.m_flFlashDuration, (float)value);
                }
                else
                {
                    global.processSession.WriteFloat((IntPtr)BaseAddress + Hack.netvars.m_flFlashDuration, (float)255);
                }
            }
        }
        public static float flashDuration
        {
            get
            {
                return global.processSession.ReadFloat((IntPtr)BaseAddress + Hack.netvars.m_flFlashDuration);
            }
            set
            {
                global.processSession.WriteFloat((IntPtr)BaseAddress + Hack.netvars.m_flFlashDuration, (float)value);
            }
        }
        public static string nowPlace
        {
            get
            {
                return global.processSession.ReadStringASCII((IntPtr)BaseAddress + Hack.netvars.m_szLastPlaceName, 12);
            }
        }
        //public static global.Angle Angle
        //{
        //    get
        //    {
        //        return new global.Angle(global.processSession.ReadFloat((IntPtr)BaseAddress + Hack.netvars.m_iAngle + 0 * 0x4), global.processSession.ReadFloat((IntPtr)BaseAddress + Hack.netvars.m_iAngle + 1 * 0x4), global.processSession.ReadFloat((IntPtr)BaseAddress + Hack.netvars.m_iAngle + 2 * 0x4));
        //    }
        //    set
        //    {
        //        int pViewAngle = global.processSession.ReadInt32((IntPtr)global.engineModule.moduleAddress + Hack.signatures.dwClientState);
        //        global.processSession.WriteFloat((IntPtr)pViewAngle + Hack.signatures.dwClientState_ViewAngles + 0x4 * 0, value.pitch);
        //        global.processSession.WriteFloat((IntPtr)pViewAngle + Hack.signatures.dwClientState_ViewAngles + 0x4 * 1, value.yaw);
        //    }
        //}
        public static global.Angle PunchAngle
        {
            get
            {
                return new global.Angle(global.processSession.ReadFloat((IntPtr)BaseAddress + Hack.netvars.m_aimPunchAngle + 0 * 0x4), global.processSession.ReadFloat((IntPtr)BaseAddress + Hack.netvars.m_aimPunchAngle + 1 * 0x4), global.processSession.ReadFloat((IntPtr)BaseAddress + Hack.netvars.m_aimPunchAngle + 2 * 0x4));
            }
        }
        public static global.Position Position
        {
            get
            {
                return new global.Position(global.processSession.ReadFloat((IntPtr)BaseAddress + Hack.netvars.m_vecOrigin + 0 * 0x4), global.processSession.ReadFloat((IntPtr)BaseAddress + Hack.netvars.m_vecOrigin + 1 * 0x4), global.processSession.ReadFloat((IntPtr)BaseAddress + Hack.netvars.m_vecOrigin + 2 * 0x4));
            }
        }
    }
}

