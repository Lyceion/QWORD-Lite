using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QWORD_LITE
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        //
        //Form Sabitleri
        //
        public static string proccess = "csgo";
        //
        //Initializing Area
        //
        public Login()
        {
            InitializeComponent();
        }
        //
        //Form Load
        //
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Hack hck = new Hack();
            this.Hide();
            hck.Show();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Process[] p = Process.GetProcessesByName(proccess);

                if (p.Length > 0)
                {
                    timer2.Start();
                    timer1.Stop();
                }
            }
            catch
            {

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Thread.Sleep(7000);
            this.Hide();
            Hack hck = new Hack();
            hck.Show();
            timer2.Stop();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {

        }
    }
}
