namespace QlyBaiGuiXe.GUI.DieuHuongTrang
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCenter = new System.Windows.Forms.Button();
            this.btnr = new System.Windows.Forms.Button();
            this.btnrr = new System.Windows.Forms.Button();
            this.btnl = new System.Windows.Forms.Button();
            this.btnll = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCenter);
            this.panel1.Controls.Add(this.btnr);
            this.panel1.Controls.Add(this.btnrr);
            this.panel1.Controls.Add(this.btnl);
            this.panel1.Controls.Add(this.btnll);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(371, 41);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnCenter
            // 
            this.btnCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCenter.Location = new System.Drawing.Point(100, 0);
            this.btnCenter.Name = "btnCenter";
            this.btnCenter.Size = new System.Drawing.Size(171, 41);
            this.btnCenter.TabIndex = 4;
            this.btnCenter.Text = "button1";
            this.btnCenter.UseVisualStyleBackColor = true;
            // 
            // btnr
            // 
            this.btnr.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnr.Location = new System.Drawing.Point(271, 0);
            this.btnr.Name = "btnr";
            this.btnr.Size = new System.Drawing.Size(50, 41);
            this.btnr.TabIndex = 2;
            this.btnr.Text = ">";
            this.btnr.UseVisualStyleBackColor = true;
            this.btnr.Click += new System.EventHandler(this.btnr_Click);
            // 
            // btnrr
            // 
            this.btnrr.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnrr.Location = new System.Drawing.Point(321, 0);
            this.btnrr.Name = "btnrr";
            this.btnrr.Size = new System.Drawing.Size(50, 41);
            this.btnrr.TabIndex = 3;
            this.btnrr.Text = ">>";
            this.btnrr.UseVisualStyleBackColor = true;
            this.btnrr.Click += new System.EventHandler(this.btnrr_Click);
            // 
            // btnl
            // 
            this.btnl.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnl.Location = new System.Drawing.Point(50, 0);
            this.btnl.Name = "btnl";
            this.btnl.Size = new System.Drawing.Size(50, 41);
            this.btnl.TabIndex = 1;
            this.btnl.Text = "<";
            this.btnl.UseVisualStyleBackColor = true;
            this.btnl.Click += new System.EventHandler(this.btnl_Click);
            // 
            // btnll
            // 
            this.btnll.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnll.Location = new System.Drawing.Point(0, 0);
            this.btnll.Name = "btnll";
            this.btnll.Size = new System.Drawing.Size(50, 41);
            this.btnll.TabIndex = 0;
            this.btnll.Text = "<<";
            this.btnll.UseVisualStyleBackColor = true;
            this.btnll.Click += new System.EventHandler(this.btnll_Click);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.panel1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(375, 45);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnll;
        private System.Windows.Forms.Button btnl;
        private System.Windows.Forms.Button btnr;
        private System.Windows.Forms.Button btnrr;
        private System.Windows.Forms.Button btnCenter;
    }
}
