namespace QlyBaiGuiXe.GUI.VeXe
{
    partial class fBTbangGia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fBTbangGia));
            this.panel7 = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.cbbLoaiXe = new System.Windows.Forms.ComboBox();
            this.txbGia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbLoaiVe = new System.Windows.Forms.ComboBox();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.pictureBox6);
            this.panel7.Location = new System.Drawing.Point(12, 12);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(413, 40);
            this.panel7.TabIndex = 29;
            this.panel7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel7_MouseDown);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::QlyBaiGuiXe.Properties.Resources.right_arrow___Copy;
            this.pictureBox6.Location = new System.Drawing.Point(3, 3);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(20, 20);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 0;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(240, 273);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(107, 38);
            this.btnHuy.TabIndex = 37;
            this.btnHuy.Text = "Huỷ";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(89, 273);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(107, 38);
            this.btnLuu.TabIndex = 38;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // cbbLoaiXe
            // 
            this.cbbLoaiXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbLoaiXe.FormattingEnabled = true;
            this.cbbLoaiXe.Location = new System.Drawing.Point(151, 121);
            this.cbbLoaiXe.Name = "cbbLoaiXe";
            this.cbbLoaiXe.Size = new System.Drawing.Size(230, 30);
            this.cbbLoaiXe.TabIndex = 36;
            this.cbbLoaiXe.SelectedIndexChanged += new System.EventHandler(this.cbbLoaiVe_SelectedIndexChanged);
            // 
            // txbGia
            // 
            this.txbGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbGia.Location = new System.Drawing.Point(151, 210);
            this.txbGia.Name = "txbGia";
            this.txbGia.Size = new System.Drawing.Size(230, 28);
            this.txbGia.TabIndex = 34;
            this.txbGia.TextChanged += new System.EventHandler(this.txbGia_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(48, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 22);
            this.label3.TabIndex = 31;
            this.label3.Tag = "";
            this.label3.Text = "Giá";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 22);
            this.label2.TabIndex = 32;
            this.label2.Text = "Loại vé";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(48, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 22);
            this.label5.TabIndex = 33;
            this.label5.Text = "Loại xe";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 36);
            this.label1.TabIndex = 30;
            this.label1.Text = "Bảo trì bảng giá";
            // 
            // cbbLoaiVe
            // 
            this.cbbLoaiVe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbLoaiVe.FormattingEnabled = true;
            this.cbbLoaiVe.Location = new System.Drawing.Point(151, 167);
            this.cbbLoaiVe.Name = "cbbLoaiVe";
            this.cbbLoaiVe.Size = new System.Drawing.Size(230, 30);
            this.cbbLoaiVe.TabIndex = 36;
            this.cbbLoaiVe.SelectedIndexChanged += new System.EventHandler(this.cbbLoaiVe_SelectedIndexChanged);
            // 
            // fBTbangGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 341);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.cbbLoaiVe);
            this.Controls.Add(this.cbbLoaiXe);
            this.Controls.Add(this.txbGia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fBTbangGia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "fBTbangGia";
            this.Load += new System.EventHandler(this.fBTbangGia_Load);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.ComboBox cbbLoaiXe;
        private System.Windows.Forms.TextBox txbGia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbLoaiVe;
    }
}