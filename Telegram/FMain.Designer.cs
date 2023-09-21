namespace Telegram
{
    partial class FMain
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
            treeView1 = new TreeView();
            treeView2 = new TreeView();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Dock = DockStyle.Left;
            treeView1.Location = new Point(0, 0);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(164, 450);
            treeView1.TabIndex = 0;
            // 
            // treeView2
            // 
            treeView2.Dock = DockStyle.Top;
            treeView2.Location = new Point(164, 0);
            treeView2.Name = "treeView2";
            treeView2.Size = new Size(636, 354);
            treeView2.TabIndex = 1;
            // 
            // FMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(treeView2);
            Controls.Add(treeView1);
            Name = "FMain";
            Text = "Form1";
            Load += FMain_Load;
            ResumeLayout(false);
        }

        #endregion

        private TreeView treeView1;
        private TreeView treeView2;
    }
}