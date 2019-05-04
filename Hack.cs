using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QWORD_LITE
{

    public partial class Hack : MetroFramework.Forms.MetroForm
    {
        public static int BaseAddress = global.processSession.ReadInt32((IntPtr)global.clientModule.moduleAddress + signatures.dwLocalPlayer);
        //
        //Form Sabitleri
        //


        public static string proccess = "csgo";
        public static VAMemory vam = new VAMemory(proccess);
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetAsyncKeyState(int vKey);
        public static int Client;
        public static int Engine;
        Thread thread_wall = new Thread(new ThreadStart(dwWallhack));
        Thread thread_bhop = new Thread(new ThreadStart(dwBunnyHop));
        Thread thread_tbot = new Thread(new ThreadStart(dwTriggerBot));
        Thread thread_aflash = new Thread(new ThreadStart(dwAntiFlash));
        public class HackStats
        {
            public static bool wallhack_use = false;
            public static bool bunnyhop_use = false;
            public static bool triggetbot_use = false;
            public static bool antiflash_use = false;
            public static bool fov_use = false;
            public static bool gui = false;
        }
        public struct GlowStruct
        {
            public float r;
            public float g;
            public float b;
            public float a;
            public bool rwo;
            public bool rwuo;
        }
        static bool GetModuleAddress()
        {

            try
            {
                Process[] p = Process.GetProcessesByName(proccess);

                if (p.Length > 0)
                {
                    foreach (ProcessModule m in p[0].Modules)
                    {
                        if (m.ModuleName == "client.dll")
                        {
                            Client = (int)m.BaseAddress;
                            return true;
                        }
                        if (m.ModuleName == "engine.dll")
                        {
                            Engine = (int)m.BaseAddress;
                        }
                    }
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        //
        //Initialize Components
        //
        public Hack()
        {
            InitializeComponent();
        }
        //
        //Form Load
        //
        private void Hack_Load(object sender, EventArgs e)
        {
            //Language Setting
            //Hile Kismi
            HackTab.Text = "| HACK |";
            WallHackLabel.Text = "WallHack =>";
            BunnyLabel.Text = "BunnyHop =>";
            TriggerLabel.Text = "TriggerBot =>";
            information.Text = "F1 => Hide Trainer\n-------------------------\nF8 => Show Trainer\nF9 => Exit Cheat";
            //Profil Bilgi Kismi
            InfoProfil.Text = "| Profile Information |";
            NotAvaliable.Text = "Not Avaliable In LITE / LITE+";
            NotAvaliable.Location = new Point(90, 114);
            //Hakkinda Kismi
            About.Text = "| About |";
            CreditsLabel.Text = " QWORD HACK\n          BY\n H4Space TEAM";
            //Language Ending
            thread_wall.Start();
            thread_bhop.Start();
            thread_tbot.Start();
            thread_aflash.Start();
        }
        //
        //Dil Secenekleri 
        //
        private void TR_Click(object sender, EventArgs e)
        {
            //Hile Kismi
            HackTab.Text = "| Hileler |";
            WallHackLabel.Text = "Duvardan Görüş =>";
            BunnyLabel.Text = "Bunny Hop Hilesi =>";
            TriggerLabel.Text = "Otomatik Atış =>";
            information.Text = "F1 => Menüyü Gizle\n-------------------------\nF8 => Menüyü Göster\nF9 => Hileden Çık";
            //Profil Bilgi Kismi
            InfoProfil.Text = "| Profil Bilgileri |";
            NotAvaliable.Text = "QWORD LITE / LITE+ Sürümlerinde Kapalı!";
            NotAvaliable.Location = new Point(35, 114);
            //Hakkinda Kismi
            About.Text = "| Hakkında |";
            CreditsLabel.Text = " QWORD HACK\n           BY\nH4Space Takımı";
        }

        private void ENG_Click(object sender, EventArgs e)
        {
            //Hile Kismi
            HackTab.Text = "| HACK |";
            WallHackLabel.Text = "WallHack =>";
            BunnyLabel.Text = "BunnyHop =>";
            TriggerLabel.Text = "TriggerBot =>";
            information.Text = "F1 => Hide Trainer\n-------------------------\nF8 => Show Trainer\nF9 => Exit Cheat";
            //Profil Bilgi Kismi
            InfoProfil.Text = "| Profile Information |";
            NotAvaliable.Text = "Not Avaliable In LITE / LITE+";
            NotAvaliable.Location = new Point(90, 114);
            //Hakkinda Kismi
            About.Text = "| About |";
            CreditsLabel.Text = " QWORD HACK\n          BY\n H4Space TEAM";
        }
        //
        //HACKS
        //
        public static void dwWallhack()
        {
            if (GetModuleAddress())
            {

                while (true)
                {
                    if (HackStats.wallhack_use)
                    {
                        GlowStruct Enemy = new GlowStruct()
                        {
                            r = 1,
                            g = 0,
                            b = 0,
                            a = 1f,
                            rwo = true,
                            rwuo = true
                        };

                        GlowStruct Team = new GlowStruct()
                        {
                            r = 1,
                            g = 1,
                            b = 1,
                            a = 0.800f,
                            rwo = true,
                            rwuo = true
                        };

                        int address;
                        int i = 1;

                        do
                        {
                            address = Client + signatures.dwLocalPlayer;

                            int Player = vam.ReadInt32((IntPtr)address);

                            address = Player + netvars.m_iTeamNum;
                            int MyTeam = vam.ReadInt32((IntPtr)address);

                            address = Client + signatures.dwEntityList + (i - 1) * 0x10;
                            int EntityList = vam.ReadInt32((IntPtr)address);

                            address = EntityList + netvars.m_iTeamNum;
                            int HisTeam = vam.ReadInt32((IntPtr)address);

                            address = EntityList + netvars.m_iDormant;

                            if (!vam.ReadBoolean((IntPtr)address))
                            {
                                address = EntityList + netvars.m_iGlowIndex;

                                int GlowIndex = vam.ReadInt32((IntPtr)address);

                                if (MyTeam == HisTeam)
                                {
                                    address = Client + signatures.dwGlowObject;
                                    int GlowObject = vam.ReadInt32((IntPtr)address);

                                    int calculation = GlowIndex * 0x38 + 0x4;
                                    int current = GlowObject + calculation;
                                    vam.WriteFloat((IntPtr)current, Team.r);

                                    calculation = GlowIndex * 0x38 + 0x8;
                                    current = GlowObject + calculation;
                                    vam.WriteFloat((IntPtr)current, Team.g);

                                    calculation = GlowIndex * 0x38 + 0xC;
                                    current = GlowObject + calculation;
                                    vam.WriteFloat((IntPtr)current, Team.b);

                                    calculation = GlowIndex * 0x38 + 0x10;
                                    current = GlowObject + calculation;
                                    vam.WriteFloat((IntPtr)current, Team.a);

                                    calculation = GlowIndex * 0x38 + 0x24;
                                    current = GlowObject + calculation;
                                    vam.WriteBoolean((IntPtr)current, Team.rwo);

                                    calculation = GlowIndex * 0x38 + 0x25;
                                    current = GlowObject + calculation;
                                    vam.WriteBoolean((IntPtr)current, Team.rwuo);
                                }
                                else
                                {
                                    address = Client + signatures.dwGlowObject;
                                    int GlowObject = vam.ReadInt32((IntPtr)address);

                                    int calculation = GlowIndex * 0x38 + 0x4;
                                    int current = GlowObject + calculation;
                                    vam.WriteFloat((IntPtr)current, Enemy.r);

                                    calculation = GlowIndex * 0x38 + 0x8;
                                    current = GlowObject + calculation;
                                    vam.WriteFloat((IntPtr)current, Enemy.g);

                                    calculation = GlowIndex * 0x38 + 0xC;
                                    current = GlowObject + calculation;
                                    vam.WriteFloat((IntPtr)current, Enemy.b);

                                    calculation = GlowIndex * 0x38 + 0x10;
                                    current = GlowObject + calculation;
                                    vam.WriteFloat((IntPtr)current, Enemy.a);

                                    calculation = GlowIndex * 0x38 + 0x24;
                                    current = GlowObject + calculation;
                                    vam.WriteBoolean((IntPtr)current, Enemy.rwo);

                                    calculation = GlowIndex * 0x38 + 0x25;
                                    current = GlowObject + calculation;
                                    vam.WriteBoolean((IntPtr)current, Enemy.rwuo);
                                }
                            }

                            i++;
                        } while (i < 65);

                        Thread.Sleep(10);
                    }
                }
            }
        }
        public static void dwBunnyHop()
        {
            int aLocalPlayer = 0xAAFFFC;
            if (GetModuleAddress())
            {
                int fJump = Client + signatures.dwForceJump;
                aLocalPlayer = Client + signatures.dwLocalPlayer;
                int LocalPlayer = vam.ReadInt32((IntPtr)aLocalPlayer);
                int aFlags = LocalPlayer + netvars.m_fFlags;

                while (true)
                {
                    if (HackStats.bunnyhop_use)
                    {
                        int spacekey = GetAsyncKeyState(32);
                        if (spacekey <= -32768)
                        {
                            if (vam.ReadInt32((IntPtr)aFlags) == 257)
                            {
                                vam.WriteInt32((IntPtr)fJump, 5);
                                Thread.Sleep(10);
                                vam.WriteInt32((IntPtr)fJump, 4);
                            }
                        }
                    }
                    Thread.Sleep(1);

                }
            }

        }
        public static void dwTriggerBot()
        {
            if (GetModuleAddress())
            {
                int fAttack = Client + signatures.dwForceAttack;
                Random random = new Random();
                while (true)
                {
                    if (HackStats.triggetbot_use)
                    {
                        int address = Client + signatures.dwLocalPlayer;
                        int LocalPlayer = vam.ReadInt32((IntPtr)address);

                        address = LocalPlayer + netvars.m_iTeamNum;
                        int MyTeam = vam.ReadInt32((IntPtr)address);

                        address = LocalPlayer + netvars.m_iCrosshairId;
                        int PlayerInCross = vam.ReadInt32((IntPtr)address);

                        if (PlayerInCross > 0 && PlayerInCross < 65)
                        {
                            address = Client + signatures.dwEntityList + (PlayerInCross - 1) * 0x0000010;
                            int PtrToPIC = vam.ReadInt32((IntPtr)address);

                            address = PtrToPIC + netvars.m_iHealth;
                            int PICHealth = vam.ReadInt32((IntPtr)address);

                            address = PtrToPIC + netvars.m_iTeamNum;
                            int PICTeam = vam.ReadInt32((IntPtr)address);
                            Debug.Print(PICHealth.ToString());

                            if ((PICTeam != MyTeam) && (PICTeam > 1) && (PICHealth > 0))
                            {
                                for (int i = 0; i < 2; i++)
                                {
                                    vam.WriteInt32((IntPtr)fAttack, 1);
                                    Thread.Sleep(20);
                                    vam.WriteInt32((IntPtr)fAttack, 4);
                                }
                            }
                        }
                        Thread.Sleep(10);
                    }
                }
            }
        }
        public static void CrossHair()
        {
            int screen_width = 1400;
            int screen_height = 900;
            string anan = @"C:\resimler\Crosshair.png";
            // Your image..
            var crosshair_bitmap = (Bitmap)Image.FromFile(anan);
            Graphics g = Graphics.FromHwnd(Process.GetProcesses("csgo")[0].MainWindowHandle);
            g.DrawImage(crosshair_bitmap, new Point((screen_width - crosshair_bitmap.Width) / 2, (screen_height - crosshair_bitmap.Height) / 2)); ;
        }
        public static void dwAntiFlash()
        {
            if (GetModuleAddress())
            {
                int fFlashAlpha = signatures.dwLocalPlayer + netvars.m_flFlashMaxAlpha;
                while (true)
                {
                    if (HackStats.antiflash_use)
                    {
                        vam.WriteFloat((IntPtr)fFlashAlpha, 0);
                        Thread.Sleep(1);
                    }
                }
            }
        }
        //
        //Random Metin Olusturucu
        //
        public static string RandomString(int length)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            string input = ">£#$½{[]}|!'^+%&/()=?\\_}{][ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var chars = Enumerable.Range(0, length).Select(x => input[random.Next(0, input.Length)]);
            return new string(chars.ToArray());
        }

        //
        //Timers
        //
        private void WallHack_Tick(object sender, EventArgs e)
        {
            int keyState_0 = GetAsyncKeyState(112);
            int keyState_1 = GetAsyncKeyState(119);
            int keyState_2 = GetAsyncKeyState(113);
            int keyState_3 = GetAsyncKeyState(120);
            int keyState_4 = GetAsyncKeyState(45);
            int keyState_5 = GetAsyncKeyState(34);
            if (keyState_0 < -32765)
            {
                Console.Beep();
                this.Hide();
            }
            else if (keyState_1 < -32765)
            {
                Console.Beep();
                this.Show();
            }
            else if (keyState_3 < -32765)
            {
                Console.Beep();
                Environment.Exit(0);
            }
        }
        private void TitleChanger_Tick(object sender, EventArgs e)
        {
            this.Text = "QWORD LITE+                                                                                               " + RandomString(30);
        }

        private void WallHackToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (!HackStats.wallhack_use)
            {
                HackStats.wallhack_use = true;
                Console.Beep();
            }
            else
            {
                HackStats.wallhack_use = false;
                Console.Beep();
            }
        }

        private void BunnyToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (!HackStats.bunnyhop_use)
            {
                HackStats.bunnyhop_use = true;
                Console.Beep();
            }
            else
            {
                HackStats.bunnyhop_use = false;
                Console.Beep();
            }
        }

        private void TriggerToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (!HackStats.triggetbot_use)
            {
                HackStats.triggetbot_use = true;
                Console.Beep();
            }
            else
            {
                HackStats.triggetbot_use = false;
                Console.Beep();
            }
        }

        private void BunnyHop_Tick(object sender, EventArgs e)
        {

        }

        private void HackTab_Click(object sender, EventArgs e)
        {

        }

        public static class netvars
        {
            public const Int32 m_ArmorValue = 0xB238;
            public const Int32 m_Collision = 0x318;
            public const Int32 m_CollisionGroup = 0x470;
            public const Int32 m_Local = 0x2FAC;
            public const Int32 m_MoveType = 0x258;
            public const Int32 m_OriginalOwnerXuidHigh = 0x316C;
            public const Int32 m_OriginalOwnerXuidLow = 0x3168;
            public const Int32 m_aimPunchAngle = 0x301C;
            public const Int32 m_aimPunchAngleVel = 0x3028;
            public const Int32 m_bGunGameImmunity = 0x3894;
            public const Int32 m_bHasDefuser = 0xB248;
            public const Int32 m_bHasHelmet = 0xB22C;
            public const Int32 m_bInReload = 0x3245;
            public const Int32 m_bIsDefusing = 0x3888;
            public const Int32 m_bIsScoped = 0x387E;
            public const Int32 m_bSpotted = 0x939;
            public const Int32 m_bSpottedByMask = 0x97C;
            public const Int32 m_dwBoneMatrix = 0x2698;
            public const Int32 m_fAccuracyPenalty = 0x32B0;
            public const Int32 m_fFlags = 0x100;
            public const Int32 m_flFallbackWear = 0x3178;
            public const Int32 m_flFlashDuration = 0xA2F8;
            public const Int32 m_flFlashMaxAlpha = 0xA2F4;
            public const Int32 m_flNextPrimaryAttack = 0x31D8;
            public const Int32 m_hActiveWeapon = 0x2EE8;
            public const Int32 m_hMyWeapons = 0x2DE8;
            public const Int32 m_hObserverTarget = 0x3360;
            public const Int32 m_hOwner = 0x29BC;
            public const Int32 m_hOwnerEntity = 0x148;
            public const Int32 m_iAccountID = 0x2FA8;
            public const Int32 m_iClip1 = 0x3204;
            public const Int32 m_iCompetitiveRanking = 0x1A44;
            public const Int32 m_iCompetitiveWins = 0x1B48;
            public const Int32 m_iCrosshairId = 0xB2A4;
            public const Int32 m_iEntityQuality = 0x2F8C;
            public const Int32 m_iFOVStart = 0x31D8;
            public const Int32 m_iGlowIndex = 0xA310;
            public const Int32 m_iHealth = 0xFC;
            public const Int32 m_iItemDefinitionIndex = 0x2F88;
            public const Int32 m_iItemIDHigh = 0x2FA0;
            public const Int32 m_iObserverMode = 0x334C;
            public const Int32 m_iShotsFired = 0xA2B0;
            public const Int32 m_iState = 0x31F8;
            public const Int32 m_iTeamNum = 0xF0;
            public const Int32 m_lifeState = 0x25B;
            public const Int32 m_nFallbackPaintKit = 0x3170;
            public const Int32 m_nFallbackSeed = 0x3174;
            public const Int32 m_nFallbackStatTrak = 0x317C;
            public const Int32 m_nForceBone = 0x267C;
            public const Int32 m_nTickBase = 0x3404;
            public const Int32 m_rgflCoordinateFrame = 0x440;
            public const Int32 m_szCustomName = 0x301C;
            public const Int32 m_szLastPlaceName = 0x3588;
            public const Int32 m_vecOrigin = 0x134;
            public const Int32 m_vecVelocity = 0x110;
            public const Int32 m_vecViewOffset = 0x104;
            public const Int32 m_viewPunchAngle = 0x3010;
            public const Int32 m_iDormant = 0xE9;
        }
        public static class signatures
        {
            public const Int32 dwClientState = 0x57B7EC;
            public const Int32 dwClientState_GetLocalPlayer = 0x180;
            public const Int32 dwClientState_Map = 0x28C;
            public const Int32 dwClientState_MapDirectory = 0x188;
            public const Int32 dwClientState_MaxPlayer = 0x310;
            public const Int32 dwClientState_PlayerInfo = 0x5240;
            public const Int32 dwClientState_State = 0x108;
            public const Int32 dwClientState_ViewAngles = 0x4D10;
            public const Int32 dwClientState_IsHLTV = 0x4CC8;
            public const Int32 dwEntityList = 0x4A78BA4;
            public const Int32 dwForceAttack = 0x2EBAF64;
            public const Int32 dwForceAttack2 = 0x2EBAF70;
            public const Int32 dwForceBackward = 0x2EBAF4C;
            public const Int32 dwForceForward = 0x2EBAF40;
            public const Int32 dwForceJump = 0x4F0FE0C;
            public const Int32 dwForceLeft = 0x2EBAF28;
            public const Int32 dwForceRight = 0x2EBAF34;
            public const Int32 dwGameDir = 0x619068;
            public const Int32 dwGameRulesProxy = 0x4F7A154;
            public const Int32 dwGetAllClasses = 0x4F7A224;
            public const Int32 dwGlobalVars = 0x57B4F0;
            public const Int32 dwGlowObjectManager = 0x4F959F0;
            public const Int32 dwInput = 0x4EC3768;
            public const Int32 dwInterfaceLinkList = 0x6DA8F4;
            public const Int32 dwLocalPlayer = 0xA9BDDC;
            public const Int32 dwMouseEnable = 0xAA1640;
            public const Int32 dwMouseEnablePtr = 0xAA1610;
            public const Int32 dwPlayerResource = 0x2EB92AC;
            public const Int32 dwRadarBase = 0x4EAD89C;
            public const Int32 dwSensitivity = 0xAA14DC;
            public const Int32 dwSensitivityPtr = 0xAA14B0;
            public const Int32 dwViewMatrix = 0x4A6A614;
            public const Int32 dwWeaponTable = 0x4EC4364;
            public const Int32 dwWeaponTableIndex = 0x31FC;
            public const Int32 dwYawPtr = 0xAA12A0;
            public const Int32 dwZoomSensitivityRatioPtr = 0xAA6308;
            public const Int32 dwbSendPackets = 0xCCD5A;
            public const Int32 dwppDirect3DDevice9 = 0xA1F40;
            public const Int32 dwSetClanTag = 0x869D0;
            public const Int32 m_pStudioHdr = 0x293C;
            public const Int32 dwGlowObject = 0x4F959F0;
        }

        private void anan_Tick(object sender, EventArgs e)
        {
            if (LocalPlayerGS.flashMaxAlpha == 255)
            {
                LocalPlayerGS.flashMaxAlpha = 0;
            }
            if (!antiFlashH.Checked)
            {
                LocalPlayerGS.flashMaxAlpha = 255;
            }
        }

        private void antiFlashH_CheckedChanged(object sender, EventArgs e)
        {
            Console.Beep();
        }
        
        private void ClanTagger_Tick(object sender, EventArgs e)
        {
            
        }

        private void TriggerBot_Tick(object sender, EventArgs e)
        {

        }
    }
}
