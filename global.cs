using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Media;

namespace QWORD_LITE
{
    public static class global
    {
        public struct Colorize
        {
            public int red;
            public int green;
            public int blue;
            public double opacity;
            public Colorize(int red_, int green_, int blue_, double opacity_)
            {
                red = red_;
                green = green_;
                blue = blue_;
                opacity = opacity_ / 1000.0f;
            }
        }
        public struct Position
        {
            public float x;
            public float y;
            public float z;
            public Position(float x_, float y_, float z_)
            {
                x = x_;
                y = y_;
                z = z_;
            }
        }
        public struct Vector3
        {
            public float x;
            public float y;
            public float z;
            public Vector3(float x_, float y_, float z_)
            {
                x = x_;
                y = y_;
                z = z_;
            }
        }
        public struct Vector2
        {
            public float x;
            public float y;
            public Vector2(float x_, float y_)
            {
                x = x_;
                y = y_;
            }
        }
        public struct Angle
        {
            public float pitch;
            public float yaw;
            public float roll;
            public Angle(float pitch_, float yaw_, float roll_)
            {
                pitch = pitch_;
                yaw = yaw_;
                roll = roll_;
            }
        }
        public struct Module
        {
            public string moduleName;
            public int moduleAddress;
            public bool fp;
            public Module(string moduleName_)
            {
                moduleName = moduleName_;
                moduleAddress = 0x000000;
                try
                {
                    Process[] p = Process.GetProcessesByName(global.process);

                    if (p.Length > 0)
                    {
                        foreach (ProcessModule m in p[0].Modules)
                        {
                            if (m.ModuleName == moduleName_)
                            {
                                moduleAddress = (Int32)m.BaseAddress;
                                Debug.Print(moduleAddress.ToString());
                                fp = true;
                            }
                        }
                        fp = true;

                    }
                    else
                    {
                        fp = false;
                    }
                }
                catch
                {
                    fp = false;
                }
            }
        }
        public static string Version = "[BETA-0.4]";
        public static string process = "csgo";
        public static Module clientModule = new Module("client.dll");
        public static Module engineModule = new Module("engine.dll");
        public static VAMemory processSession = new VAMemory(process);
    }
}
