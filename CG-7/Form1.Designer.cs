namespace CG_7
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.holst = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.материалToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ambientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diffuseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emissionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ambientTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.светToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.левоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.правоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сВерхуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вариант1GreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dfdfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // holst
            // 
            this.holst.AccumBits = ((byte)(0));
            this.holst.AutoCheckErrors = false;
            this.holst.AutoFinish = false;
            this.holst.AutoMakeCurrent = true;
            this.holst.AutoSwapBuffers = true;
            this.holst.BackColor = System.Drawing.Color.Black;
            this.holst.ColorBits = ((byte)(32));
            this.holst.DepthBits = ((byte)(16));
            this.holst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.holst.Location = new System.Drawing.Point(0, 28);
            this.holst.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.holst.Name = "holst";
            this.holst.Size = new System.Drawing.Size(845, 724);
            this.holst.StencilBits = ((byte)(0));
            this.holst.TabIndex = 0;
            this.holst.KeyDown += new System.Windows.Forms.KeyEventHandler(this.holst_KeyDown);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.материалToolStripMenuItem,
            this.светToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(845, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // материалToolStripMenuItem
            // 
            this.материалToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ambientToolStripMenuItem,
            this.diffuseToolStripMenuItem,
            this.specularToolStripMenuItem,
            this.emissionToolStripMenuItem,
            this.ambientTestToolStripMenuItem,
            this.speToolStripMenuItem,
            this.dfdfToolStripMenuItem});
            this.материалToolStripMenuItem.Name = "материалToolStripMenuItem";
            this.материалToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.материалToolStripMenuItem.Text = "Материал";
            // 
            // ambientToolStripMenuItem
            // 
            this.ambientToolStripMenuItem.Name = "ambientToolStripMenuItem";
            this.ambientToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.ambientToolStripMenuItem.Text = "Rubby";
            this.ambientToolStripMenuItem.Click += new System.EventHandler(this.ambientToolStripMenuItem_Click);
            // 
            // diffuseToolStripMenuItem
            // 
            this.diffuseToolStripMenuItem.Name = "diffuseToolStripMenuItem";
            this.diffuseToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.diffuseToolStripMenuItem.Text = "Gold";
            this.diffuseToolStripMenuItem.Click += new System.EventHandler(this.diffuseToolStripMenuItem_Click);
            // 
            // specularToolStripMenuItem
            // 
            this.specularToolStripMenuItem.Name = "specularToolStripMenuItem";
            this.specularToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.specularToolStripMenuItem.Text = "Ambient off";
            this.specularToolStripMenuItem.Click += new System.EventHandler(this.specularToolStripMenuItem_Click);
            // 
            // emissionToolStripMenuItem
            // 
            this.emissionToolStripMenuItem.Name = "emissionToolStripMenuItem";
            this.emissionToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.emissionToolStripMenuItem.Text = "Emission";
            this.emissionToolStripMenuItem.Click += new System.EventHandler(this.emissionToolStripMenuItem_Click);
            // 
            // ambientTestToolStripMenuItem
            // 
            this.ambientTestToolStripMenuItem.Name = "ambientTestToolStripMenuItem";
            this.ambientTestToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.ambientTestToolStripMenuItem.Text = "Ambient test";
            this.ambientTestToolStripMenuItem.Click += new System.EventHandler(this.ambientTestToolStripMenuItem_Click);
            // 
            // светToolStripMenuItem
            // 
            this.светToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.левоToolStripMenuItem,
            this.правоToolStripMenuItem,
            this.сВерхуToolStripMenuItem,
            this.offToolStripMenuItem,
            this.xToolStripMenuItem,
            this.yToolStripMenuItem,
            this.zToolStripMenuItem,
            this.вариант1GreenToolStripMenuItem});
            this.светToolStripMenuItem.Name = "светToolStripMenuItem";
            this.светToolStripMenuItem.Size = new System.Drawing.Size(54, 24);
            this.светToolStripMenuItem.Text = "Свет";
            // 
            // левоToolStripMenuItem
            // 
            this.левоToolStripMenuItem.Name = "левоToolStripMenuItem";
            this.левоToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.левоToolStripMenuItem.Text = "Вариант 1";
            this.левоToolStripMenuItem.Click += new System.EventHandler(this.левоToolStripMenuItem_Click);
            // 
            // правоToolStripMenuItem
            // 
            this.правоToolStripMenuItem.Name = "правоToolStripMenuItem";
            this.правоToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.правоToolStripMenuItem.Text = "Вариант 2";
            this.правоToolStripMenuItem.Click += new System.EventHandler(this.правоToolStripMenuItem_Click);
            // 
            // сВерхуToolStripMenuItem
            // 
            this.сВерхуToolStripMenuItem.Name = "сВерхуToolStripMenuItem";
            this.сВерхуToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.сВерхуToolStripMenuItem.Text = "С верху";
            this.сВерхуToolStripMenuItem.Click += new System.EventHandler(this.сВерхуToolStripMenuItem_Click);
            // 
            // offToolStripMenuItem
            // 
            this.offToolStripMenuItem.Name = "offToolStripMenuItem";
            this.offToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.offToolStripMenuItem.Text = "off";
            this.offToolStripMenuItem.Click += new System.EventHandler(this.offToolStripMenuItem_Click);
            // 
            // xToolStripMenuItem
            // 
            this.xToolStripMenuItem.Name = "xToolStripMenuItem";
            this.xToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.xToolStripMenuItem.Text = "X";
            this.xToolStripMenuItem.Click += new System.EventHandler(this.xToolStripMenuItem_Click);
            // 
            // yToolStripMenuItem
            // 
            this.yToolStripMenuItem.Name = "yToolStripMenuItem";
            this.yToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.yToolStripMenuItem.Text = "Y";
            this.yToolStripMenuItem.Click += new System.EventHandler(this.yToolStripMenuItem_Click);
            // 
            // zToolStripMenuItem
            // 
            this.zToolStripMenuItem.Name = "zToolStripMenuItem";
            this.zToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.zToolStripMenuItem.Text = "Z";
            this.zToolStripMenuItem.Click += new System.EventHandler(this.zToolStripMenuItem_Click);
            // 
            // вариант1GreenToolStripMenuItem
            // 
            this.вариант1GreenToolStripMenuItem.Name = "вариант1GreenToolStripMenuItem";
            this.вариант1GreenToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.вариант1GreenToolStripMenuItem.Text = "Вариант 1 green";
            this.вариант1GreenToolStripMenuItem.Click += new System.EventHandler(this.вариант1GreenToolStripMenuItem_Click);
            // 
            // speToolStripMenuItem
            // 
            this.speToolStripMenuItem.Name = "speToolStripMenuItem";
            this.speToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.speToolStripMenuItem.Text = "Specular";
            this.speToolStripMenuItem.Click += new System.EventHandler(this.speToolStripMenuItem_Click);
            // 
            // dfdfToolStripMenuItem
            // 
            this.dfdfToolStripMenuItem.Name = "dfdfToolStripMenuItem";
            this.dfdfToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.dfdfToolStripMenuItem.Text = "dfdf";
            this.dfdfToolStripMenuItem.Click += new System.EventHandler(this.dfdfToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 752);
            this.Controls.Add(this.holst);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl holst;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem материалToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ambientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diffuseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem specularToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emissionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem светToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem левоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem правоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сВерхуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem offToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ambientTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вариант1GreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dfdfToolStripMenuItem;
    }
}

