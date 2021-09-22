namespace com.mirle.ibg3k0.bc.winform.UI.UAS
{
    partial class ExitSystemPopupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExitSystemPopupForm));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.PwdTBx = new System.Windows.Forms.TextBox();
            this.UserIDTBx = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_FormTitle = new System.Windows.Forms.Label();
            this.btn_Close = new com.mirle.ibg3k0.bc.winform.UI.Controller.uc_btn_CloseButton_X();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Confirm = new com.mirle.ibg3k0.bc.winform.UI.Controller.uc_btn_ConfirmButton();
            this.btn_Cancel = new com.mirle.ibg3k0.bc.winform.UI.Controller.uc_btn_CancelButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "close-24.png");
            this.imageList1.Images.SetKeyName(1, "1430821398_Go.ico");
            this.imageList1.Images.SetKeyName(2, "confirm.png");
            this.imageList1.Images.SetKeyName(3, "cancel.png");
            // 
            // PwdTBx
            // 
            resources.ApplyResources(this.PwdTBx, "PwdTBx");
            this.PwdTBx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(37)))), ((int)(((byte)(54)))));
            this.PwdTBx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PwdTBx.ForeColor = System.Drawing.Color.White;
            this.PwdTBx.Name = "PwdTBx";
            this.PwdTBx.UseSystemPasswordChar = true;
            this.PwdTBx.TextChanged += new System.EventHandler(this.PwdTBx_TextChanged);
            this.PwdTBx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PwdTBx_KeyDown);
            // 
            // UserIDTBx
            // 
            resources.ApplyResources(this.UserIDTBx, "UserIDTBx");
            this.UserIDTBx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(37)))), ((int)(((byte)(54)))));
            this.UserIDTBx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserIDTBx.ForeColor = System.Drawing.Color.White;
            this.UserIDTBx.Name = "UserIDTBx";
            this.UserIDTBx.Click += new System.EventHandler(this.UserIDTBx_Click);
            this.UserIDTBx.TextChanged += new System.EventHandler(this.UserIDTBx_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel6.SetColumnSpan(this.tableLayoutPanel1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbl_FormTitle, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Close, 2, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UIForm_MouseDown);
            this.tableLayoutPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UIForm_MouseMove);
            // 
            // lbl_FormTitle
            // 
            this.lbl_FormTitle.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lbl_FormTitle, "lbl_FormTitle");
            this.lbl_FormTitle.ForeColor = System.Drawing.Color.White;
            this.lbl_FormTitle.Name = "lbl_FormTitle";
            this.lbl_FormTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UIForm_MouseDown);
            this.lbl_FormTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UIForm_MouseMove);
            // 
            // btn_Close
            // 
            resources.ApplyResources(this.btn_Close, "btn_Close");
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Close.Name = "btn_Close";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(37)))), ((int)(((byte)(54)))));
            resources.ApplyResources(this.tableLayoutPanel5, "tableLayoutPanel5");
            this.tableLayoutPanel5.Controls.Add(this.PwdTBx, 0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(236)))), ((int)(((byte)(252)))));
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(37)))), ((int)(((byte)(54)))));
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.Controls.Add(this.UserIDTBx, 0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(0)))), ((int)(((byte)(34)))));
            resources.ApplyResources(this.tableLayoutPanel6, "tableLayoutPanel6");
            this.tableLayoutPanel6.Controls.Add(this.label2, 1, 3);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel2, 1, 7);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel3, 1, 4);
            this.tableLayoutPanel6.Controls.Add(this.label3, 1, 6);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel7, 0, 9);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UIForm_MouseDown);
            this.tableLayoutPanel6.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UIForm_MouseMove);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.tableLayoutPanel6.SetColumnSpan(this.label1, 3);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // tableLayoutPanel7
            // 
            resources.ApplyResources(this.tableLayoutPanel7, "tableLayoutPanel7");
            this.tableLayoutPanel6.SetColumnSpan(this.tableLayoutPanel7, 3);
            this.tableLayoutPanel7.Controls.Add(this.btn_Confirm, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.btn_Cancel, 1, 0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btn_Confirm, "btn_Confirm");
            this.btn_Confirm.Name = "btn_Confirm";
            // 
            // btn_Cancel
            // 
            resources.ApplyResources(this.btn_Cancel, "btn_Cancel");
            this.btn_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.Name = "btn_Cancel";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.panel1.Controls.Add(this.tableLayoutPanel6);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // ExitSystemPopupForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExitSystemPopupForm";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.LoginPopupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginPopupForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UIForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UIForm_MouseMove);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lbl_FormTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox PwdTBx;
        private System.Windows.Forms.TextBox UserIDTBx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private Controller.uc_btn_CloseButton_X btn_Close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private Controller.uc_btn_ConfirmButton btn_Confirm;
        private Controller.uc_btn_CancelButton btn_Cancel;
        private System.Windows.Forms.Panel panel1;
    }
}