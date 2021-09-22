namespace com.mirle.ibg3k0.bc.winform.UI
{
    partial class ProgressBarDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressBarDialog));
            this.m_processLbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnl_LoadingBackground = new System.Windows.Forms.Panel();
            this.m_msgTm = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnl_LoadingBackground.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_processLbl
            // 
            this.m_processLbl.BackColor = System.Drawing.Color.Transparent;
            this.m_processLbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_processLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.m_processLbl.ForeColor = System.Drawing.Color.White;
            this.m_processLbl.Location = new System.Drawing.Point(0, 159);
            this.m_processLbl.Name = "m_processLbl";
            this.m_processLbl.Size = new System.Drawing.Size(488, 62);
            this.m_processLbl.TabIndex = 1;
            this.m_processLbl.Text = "Process Message";
            this.m_processLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.m_processLbl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ProgressBarDialog_MouseDown);
            this.m_processLbl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ProgressBarDialog_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::com.mirle.ibg3k0.bc.winform.Properties.Resources.gif_Mirle_Logo_Loading;
            this.pictureBox1.Location = new System.Drawing.Point(125, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(239, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ProgressBarDialog_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ProgressBarDialog_MouseMove);
            // 
            // pnl_LoadingBackground
            // 
            this.pnl_LoadingBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.pnl_LoadingBackground.Controls.Add(this.pictureBox1);
            this.pnl_LoadingBackground.Controls.Add(this.m_processLbl);
            this.pnl_LoadingBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_LoadingBackground.Location = new System.Drawing.Point(1, 1);
            this.pnl_LoadingBackground.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_LoadingBackground.Name = "pnl_LoadingBackground";
            this.pnl_LoadingBackground.Size = new System.Drawing.Size(488, 221);
            this.pnl_LoadingBackground.TabIndex = 3;
            this.pnl_LoadingBackground.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ProgressBarDialog_MouseDown);
            this.pnl_LoadingBackground.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ProgressBarDialog_MouseMove);
            // 
            // m_msgTm
            // 
            this.m_msgTm.Interval = 1000;
            this.m_msgTm.Tick += new System.EventHandler(this.m_msgTm_Tick);
            // 
            // ProgressBarDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(490, 223);
            this.ControlBox = false;
            this.Controls.Add(this.pnl_LoadingBackground);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProgressBarDialog";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnl_LoadingBackground.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label m_processLbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnl_LoadingBackground;
        private System.Windows.Forms.Timer m_msgTm;

    }
}