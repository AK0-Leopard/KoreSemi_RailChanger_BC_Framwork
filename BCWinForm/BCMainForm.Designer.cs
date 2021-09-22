using com.mirle.ibg3k0.bc.winform.App;
using System;
namespace com.mirle.ibg3k0.bc.winform
{
    partial class BCMainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BCMainForm));
            this.startConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.uc_MirleLogo1 = new MirleGO_UIFrameWork.UI.Layout.uc_MirleLogo();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MainSignalBackGround2 = new System.Windows.Forms.TableLayoutPanel();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.MainSignalBackGround2.SuspendLayout();
            this.SuspendLayout();
            // 
            // startConnectionToolStripMenuItem
            // 
            this.startConnectionToolStripMenuItem.Name = "startConnectionToolStripMenuItem";
            resources.ApplyResources(this.startConnectionToolStripMenuItem, "startConnectionToolStripMenuItem");
            // 
            // stopConnectionToolStripMenuItem
            // 
            this.stopConnectionToolStripMenuItem.Name = "stopConnectionToolStripMenuItem";
            resources.ApplyResources(this.stopConnectionToolStripMenuItem, "stopConnectionToolStripMenuItem");
            // 
            // testToolStripMenuItem1
            // 
            this.testToolStripMenuItem1.Name = "testToolStripMenuItem1";
            resources.ApplyResources(this.testToolStripMenuItem1, "testToolStripMenuItem1");
            // 
            // uc_MirleLogo1
            // 
            this.uc_MirleLogo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(93)))), ((int)(((byte)(190)))));
            resources.ApplyResources(this.uc_MirleLogo1, "uc_MirleLogo1");
            this.uc_MirleLogo1.Name = "uc_MirleLogo1";
            // 
            // notifyIcon1
            // 
            resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // MainSignalBackGround2
            // 
            resources.ApplyResources(this.MainSignalBackGround2, "MainSignalBackGround2");
            this.MainSignalBackGround2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.MainSignalBackGround2.Controls.Add(this.menuStrip1, 0, 0);
            this.MainSignalBackGround2.Name = "MainSignalBackGround2";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            resources.ApplyResources(this.testToolStripMenuItem, "testToolStripMenuItem");
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // BCMainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(184)))));
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.uc_MirleLogo1);
            this.Controls.Add(this.MainSignalBackGround2);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "BCMainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BCMainForm_FormClosing_New);
            this.Load += new System.EventHandler(this.BCMainForm_Load);
            this.Resize += new System.EventHandler(this.BCMainForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.MainSignalBackGround2.ResumeLayout(false);
            this.MainSignalBackGround2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem startConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem1;




        private MirleGO_UIFrameWork.UI.Layout.uc_MirleLogo uc_MirleLogo1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel MainSignalBackGround2;
    }

    /// <summary>
    /// 來用排序Alarm His 在Data Grid View 的順序
    /// </summary>
    public class AuthorityCheck : Attribute
    {
        //public AlarmOrder();

        public string FUNCode { get; set; }

    }
}

