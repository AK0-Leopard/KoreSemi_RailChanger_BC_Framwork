namespace com.mirle.ibg3k0.bc.winform.UI.AGCComponent_DEMO
{
    partial class Vehicle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Vehicle));
            this.lab_carrierID = new System.Windows.Forms.Label();
            this.CST = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CST)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lab_carrierID
            // 
            this.lab_carrierID.AutoSize = true;
            this.lab_carrierID.Font = new System.Drawing.Font("Arial", 11F);
            this.lab_carrierID.ForeColor = System.Drawing.Color.White;
            this.lab_carrierID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lab_carrierID.Location = new System.Drawing.Point(75, 41);
            this.lab_carrierID.Name = "lab_carrierID";
            this.lab_carrierID.Size = new System.Drawing.Size(242, 17);
            this.lab_carrierID.TabIndex = 4;
            this.lab_carrierID.Text = "AAAAAAAAAABBBBBBBBBBCCCC";
            this.lab_carrierID.Click += new System.EventHandler(this.lab_carrierID_Click);
            // 
            // CST
            // 
            this.CST.Image = ((System.Drawing.Image)(resources.GetObject("CST.Image")));
            this.CST.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CST.Location = new System.Drawing.Point(22, 8);
            this.CST.Name = "CST";
            this.CST.Size = new System.Drawing.Size(35, 35);
            this.CST.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CST.TabIndex = 2;
            this.CST.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(9, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Vehicle
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.Controls.Add(this.lab_carrierID);
            this.Controls.Add(this.CST);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Vehicle";
            this.Size = new System.Drawing.Size(760, 358);
            ((System.ComponentModel.ISupportInitialize)(this.CST)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_carrierID;
        private System.Windows.Forms.PictureBox CST;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
