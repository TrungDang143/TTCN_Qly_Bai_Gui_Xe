namespace QlyBaiGuiXe.GUI
{
    partial class ucThongKe
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
            this.lbVeThang = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnHN = new System.Windows.Forms.Button();
            this.btnTuan = new System.Windows.Forms.Button();
            this.btnThang = new System.Windows.Forms.Button();
            this.btnNam = new System.Windows.Forms.Button();
            this.btnVeThang = new System.Windows.Forms.Button();
            this.btnVeLuot = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.dtpk = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbVeThang
            // 
            this.lbVeThang.AutoSize = true;
            this.lbVeThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVeThang.Location = new System.Drawing.Point(25, 54);
            this.lbVeThang.Name = "lbVeThang";
            this.lbVeThang.Size = new System.Drawing.Size(256, 22);
            this.lbVeThang.TabIndex = 0;
            this.lbVeThang.Text = "Số lượng vé tháng đăng ký mới";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(29, 169);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1263, 608);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnHN
            // 
            this.btnHN.BackColor = System.Drawing.Color.Lavender;
            this.btnHN.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnHN.FlatAppearance.BorderSize = 2;
            this.btnHN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHN.ForeColor = System.Drawing.Color.Black;
            this.btnHN.Location = new System.Drawing.Point(29, 114);
            this.btnHN.Name = "btnHN";
            this.btnHN.Size = new System.Drawing.Size(102, 37);
            this.btnHN.TabIndex = 2;
            this.btnHN.Text = "Hôm nay";
            this.btnHN.UseVisualStyleBackColor = false;
            this.btnHN.Click += new System.EventHandler(this.btnNgay_Click);
            // 
            // btnTuan
            // 
            this.btnTuan.BackColor = System.Drawing.Color.Lavender;
            this.btnTuan.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnTuan.FlatAppearance.BorderSize = 2;
            this.btnTuan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTuan.ForeColor = System.Drawing.Color.Black;
            this.btnTuan.Location = new System.Drawing.Point(131, 114);
            this.btnTuan.Name = "btnTuan";
            this.btnTuan.Size = new System.Drawing.Size(102, 37);
            this.btnTuan.TabIndex = 2;
            this.btnTuan.Text = "Tuần";
            this.btnTuan.UseVisualStyleBackColor = false;
            this.btnTuan.Click += new System.EventHandler(this.btnTuan_Click);
            // 
            // btnThang
            // 
            this.btnThang.BackColor = System.Drawing.Color.Lavender;
            this.btnThang.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnThang.FlatAppearance.BorderSize = 2;
            this.btnThang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThang.ForeColor = System.Drawing.Color.Black;
            this.btnThang.Location = new System.Drawing.Point(233, 114);
            this.btnThang.Name = "btnThang";
            this.btnThang.Size = new System.Drawing.Size(102, 37);
            this.btnThang.TabIndex = 2;
            this.btnThang.Text = "Tháng";
            this.btnThang.UseVisualStyleBackColor = false;
            this.btnThang.Click += new System.EventHandler(this.btnThang_Click);
            // 
            // btnNam
            // 
            this.btnNam.BackColor = System.Drawing.Color.Lavender;
            this.btnNam.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnNam.FlatAppearance.BorderSize = 2;
            this.btnNam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNam.ForeColor = System.Drawing.Color.Black;
            this.btnNam.Location = new System.Drawing.Point(335, 114);
            this.btnNam.Name = "btnNam";
            this.btnNam.Size = new System.Drawing.Size(102, 37);
            this.btnNam.TabIndex = 2;
            this.btnNam.Text = "Năm";
            this.btnNam.UseVisualStyleBackColor = false;
            this.btnNam.Click += new System.EventHandler(this.btnNam_Click);
            // 
            // btnVeThang
            // 
            this.btnVeThang.BackColor = System.Drawing.Color.Lavender;
            this.btnVeThang.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnVeThang.FlatAppearance.BorderSize = 2;
            this.btnVeThang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVeThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVeThang.ForeColor = System.Drawing.Color.Black;
            this.btnVeThang.Location = new System.Drawing.Point(1190, 114);
            this.btnVeThang.Name = "btnVeThang";
            this.btnVeThang.Size = new System.Drawing.Size(102, 37);
            this.btnVeThang.TabIndex = 3;
            this.btnVeThang.Text = "Vé tháng";
            this.btnVeThang.UseVisualStyleBackColor = false;
            this.btnVeThang.Click += new System.EventHandler(this.btnVeThang_Click);
            // 
            // btnVeLuot
            // 
            this.btnVeLuot.BackColor = System.Drawing.Color.Lavender;
            this.btnVeLuot.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnVeLuot.FlatAppearance.BorderSize = 2;
            this.btnVeLuot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVeLuot.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVeLuot.ForeColor = System.Drawing.Color.Black;
            this.btnVeLuot.Location = new System.Drawing.Point(1088, 114);
            this.btnVeLuot.Name = "btnVeLuot";
            this.btnVeLuot.Size = new System.Drawing.Size(102, 37);
            this.btnVeLuot.TabIndex = 4;
            this.btnVeLuot.Text = "Vé lượt";
            this.btnVeLuot.UseVisualStyleBackColor = false;
            this.btnVeLuot.Click += new System.EventHandler(this.btnVeLuot_Click);
            // 
            // btnAll
            // 
            this.btnAll.BackColor = System.Drawing.Color.Lavender;
            this.btnAll.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAll.FlatAppearance.BorderSize = 2;
            this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAll.ForeColor = System.Drawing.Color.Black;
            this.btnAll.Location = new System.Drawing.Point(986, 114);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(102, 37);
            this.btnAll.TabIndex = 4;
            this.btnAll.Text = "Tất cả";
            this.btnAll.UseVisualStyleBackColor = false;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // dtpk
            // 
            this.dtpk.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpk.Location = new System.Drawing.Point(514, 115);
            this.dtpk.Name = "dtpk";
            this.dtpk.Size = new System.Drawing.Size(382, 28);
            this.dtpk.TabIndex = 5;
            this.dtpk.ValueChanged += new System.EventHandler(this.dtpk_ValueChanged);
            // 
            // ucThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtpk);
            this.Controls.Add(this.btnVeThang);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnVeLuot);
            this.Controls.Add(this.btnNam);
            this.Controls.Add(this.btnThang);
            this.Controls.Add(this.btnTuan);
            this.Controls.Add(this.btnHN);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lbVeThang);
            this.Name = "ucThongKe";
            this.Size = new System.Drawing.Size(1328, 811);
            this.Load += new System.EventHandler(this.ucThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbVeThang;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnHN;
        private System.Windows.Forms.Button btnTuan;
        private System.Windows.Forms.Button btnThang;
        private System.Windows.Forms.Button btnNam;
        private System.Windows.Forms.Button btnVeThang;
        private System.Windows.Forms.Button btnVeLuot;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.DateTimePicker dtpk;
    }
}
