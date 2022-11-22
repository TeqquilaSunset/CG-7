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
            this.holst = new Tao.Platform.Windows.SimpleOpenGlControl();
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
            this.holst.Location = new System.Drawing.Point(0, 0);
            this.holst.Margin = new System.Windows.Forms.Padding(4);
            this.holst.Name = "holst";
            this.holst.Size = new System.Drawing.Size(845, 752);
            this.holst.StencilBits = ((byte)(0));
            this.holst.TabIndex = 0;
            this.holst.KeyDown += new System.Windows.Forms.KeyEventHandler(this.holst_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 752);
            this.Controls.Add(this.holst);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl holst;
    }
}

