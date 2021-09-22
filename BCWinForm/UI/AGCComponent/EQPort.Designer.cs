namespace com.mirle.ibg3k0.bc.winform.UI.AGCComponent_DEMO
{
    partial class EQPort
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EQPort));
            this.panel29 = new System.Windows.Forms.Panel();
            this.panel30 = new System.Windows.Forms.Panel();
            this.ExitCST = new System.Windows.Forms.PictureBox();
            this.panel29.SuspendLayout();
            this.panel30.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExitCST)).BeginInit();
            this.SuspendLayout();
            // 
            // panel29
            // 
            this.panel29.BackColor = System.Drawing.Color.Green;
            this.panel29.Controls.Add(this.panel30);
            this.panel29.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel29.Location = new System.Drawing.Point(0, 0);
            this.panel29.Name = "panel29";
            this.panel29.Padding = new System.Windows.Forms.Padding(3);
            this.panel29.Size = new System.Drawing.Size(30, 30);
            this.panel29.TabIndex = 3;
            // 
            // panel30
            // 
            this.panel30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.panel30.Controls.Add(this.ExitCST);
            this.panel30.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel30.Location = new System.Drawing.Point(3, 3);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(24, 24);
            this.panel30.TabIndex = 1;
            // 
            // ExitCST
            // 
            this.ExitCST.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ExitCST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExitCST.Image = ((System.Drawing.Image)(resources.GetObject("ExitCST.Image")));
            this.ExitCST.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ExitCST.Location = new System.Drawing.Point(0, 0);
            this.ExitCST.Name = "ExitCST";
            this.ExitCST.Size = new System.Drawing.Size(24, 24);
            this.ExitCST.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ExitCST.TabIndex = 0;
            this.ExitCST.TabStop = false;
            this.ExitCST.Click += new System.EventHandler(this.ExitCST_Click);
            // 
            // EQPort
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel29);
            this.Name = "EQPort";
            this.Size = new System.Drawing.Size(30, 30);
            this.panel29.ResumeLayout(false);
            this.panel30.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ExitCST)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel29;
        private System.Windows.Forms.Panel panel30;
        private System.Windows.Forms.PictureBox ExitCST;
    }
}
