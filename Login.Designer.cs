namespace QWORD_LITE
{
    partial class Login
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.NotAvaliable = new MetroFramework.Controls.MetroLabel();
            this.metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
            this.HideControlBox = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.sinir = new System.Windows.Forms.Label();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HideControlBox)).BeginInit();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.NotAvaliable);
            this.metroPanel1.Controls.Add(this.metroProgressSpinner1);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(7, 63);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(304, 154);
            this.metroPanel1.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // NotAvaliable
            // 
            this.NotAvaliable.AutoSize = true;
            this.NotAvaliable.Cursor = System.Windows.Forms.Cursors.No;
            this.NotAvaliable.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.NotAvaliable.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.NotAvaliable.ForeColor = System.Drawing.Color.Orange;
            this.NotAvaliable.Location = new System.Drawing.Point(73, 118);
            this.NotAvaliable.Name = "NotAvaliable";
            this.NotAvaliable.Size = new System.Drawing.Size(163, 25);
            this.NotAvaliable.Style = MetroFramework.MetroColorStyle.Orange;
            this.NotAvaliable.TabIndex = 3;
            this.NotAvaliable.Text = "Wating For CS:GO";
            this.NotAvaliable.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.NotAvaliable.UseCustomForeColor = true;
            // 
            // metroProgressSpinner1
            // 
            this.metroProgressSpinner1.Location = new System.Drawing.Point(102, 3);
            this.metroProgressSpinner1.Maximum = 100;
            this.metroProgressSpinner1.Name = "metroProgressSpinner1";
            this.metroProgressSpinner1.Size = new System.Drawing.Size(104, 99);
            this.metroProgressSpinner1.Speed = 3F;
            this.metroProgressSpinner1.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroProgressSpinner1.TabIndex = 2;
            this.metroProgressSpinner1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroProgressSpinner1.UseSelectable = true;
            // 
            // HideControlBox
            // 
            this.HideControlBox.Location = new System.Drawing.Point(253, 5);
            this.HideControlBox.Name = "HideControlBox";
            this.HideControlBox.Size = new System.Drawing.Size(69, 23);
            this.HideControlBox.TabIndex = 6;
            this.HideControlBox.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // sinir
            // 
            this.sinir.AutoSize = true;
            this.sinir.ForeColor = System.Drawing.Color.White;
            this.sinir.Location = new System.Drawing.Point(4, 15);
            this.sinir.Name = "sinir";
            this.sinir.Size = new System.Drawing.Size(35, 13);
            this.sinir.TabIndex = 7;
            this.sinir.Text = "label1";
            this.sinir.Visible = false;
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 229);
            this.Controls.Add(this.sinir);
            this.Controls.Add(this.HideControlBox);
            this.Controls.Add(this.metroPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Login";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "Login";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HideControlBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.PictureBox HideControlBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner1;
        private MetroFramework.Controls.MetroLabel NotAvaliable;
        private System.Windows.Forms.Label sinir;
        private System.Windows.Forms.Timer timer3;
    }
}

