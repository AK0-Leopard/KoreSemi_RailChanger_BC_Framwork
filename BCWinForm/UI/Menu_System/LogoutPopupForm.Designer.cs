namespace com.mirle.ibg3k0.bc.winform.UI
{
    partial class LogoutPopupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogoutPopupForm));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_FormTitle = new System.Windows.Forms.Label();
            this.btn_Close_X = new com.mirle.ibg3k0.bc.winform.UI.Controller.uc_btn_CloseButton_X();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.uc_btn_Yes = new com.mirle.ibg3k0.bc.winform.UI.Controller.uc_btn_YesButton();
            this.uc_btn_No = new com.mirle.ibg3k0.bc.winform.UI.Controller.uc_btn_NoButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbl_FormTitle, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Close_X, 2, 0);
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
            // btn_Close_X
            // 
            resources.ApplyResources(this.btn_Close_X, "btn_Close_X");
            this.btn_Close_X.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close_X.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Close_X.Name = "btn_Close_X";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UIForm_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UIForm_MouseMove);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(0)))), ((int)(((byte)(34)))));
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UIForm_MouseDown);
            this.tableLayoutPanel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UIForm_MouseMove);
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel3, 3);
            this.tableLayoutPanel3.Controls.Add(this.uc_btn_Yes, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.uc_btn_No, 1, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // uc_btn_Yes
            // 
            this.uc_btn_Yes.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.uc_btn_Yes, "uc_btn_Yes");
            this.uc_btn_Yes.Name = "uc_btn_Yes";
            // 
            // uc_btn_No
            // 
            resources.ApplyResources(this.uc_btn_No, "uc_btn_No");
            this.uc_btn_No.BackColor = System.Drawing.Color.Transparent;
            this.uc_btn_No.Name = "uc_btn_No";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // LogoutPopupForm
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
            this.Name = "LogoutPopupForm";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.LogoutPopupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LogoutPopupForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UIForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UIForm_MouseMove);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl_FormTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Controller.uc_btn_CloseButton_X btn_Close_X;
        private Controller.uc_btn_YesButton uc_btn_Yes;
        private Controller.uc_btn_NoButton uc_btn_No;
        private System.Windows.Forms.Panel panel1;
    }
}