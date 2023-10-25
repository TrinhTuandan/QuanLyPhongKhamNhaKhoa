namespace GUI
{
    partial class DataKhamChua
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTenPhong = new System.Windows.Forms.Label();
            this.dtgvTT = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.rbtnTatCa = new System.Windows.Forms.RadioButton();
            this.rbtnDaKham = new System.Windows.Forms.RadioButton();
            this.rbtnChoKham = new System.Windows.Forms.RadioButton();
            this.btnReload = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTT)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.lblTenPhong);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1606, 97);
            this.panel1.TabIndex = 1;
            // 
            // lblTenPhong
            // 
            this.lblTenPhong.AutoSize = true;
            this.lblTenPhong.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenPhong.Location = new System.Drawing.Point(575, 39);
            this.lblTenPhong.Name = "lblTenPhong";
            this.lblTenPhong.Size = new System.Drawing.Size(375, 32);
            this.lblTenPhong.TabIndex = 1;
            this.lblTenPhong.Text = "PHÒNG CHỜ KHÁM BỆNH";
            // 
            // dtgvTT
            // 
            this.dtgvTT.AllowUserToAddRows = false;
            this.dtgvTT.AllowUserToDeleteRows = false;
            this.dtgvTT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvTT.BackgroundColor = System.Drawing.Color.Silver;
            this.dtgvTT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvTT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dtgvTT.Location = new System.Drawing.Point(0, 183);
            this.dtgvTT.Name = "dtgvTT";
            this.dtgvTT.ReadOnly = true;
            this.dtgvTT.RowHeadersWidth = 51;
            this.dtgvTT.RowTemplate.Height = 24;
            this.dtgvTT.Size = new System.Drawing.Size(1606, 705);
            this.dtgvTT.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "SoPhieu";
            this.Column1.FillWeight = 50F;
            this.Column1.HeaderText = "Số Phiếu";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "HoTen";
            this.Column2.FillWeight = 200F;
            this.Column2.HeaderText = "Họ Tên";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ChiDinh";
            this.Column3.HeaderText = "Chỉ Định Khám";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 50F;
            this.Column4.HeaderText = "Khám";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column4.Text = "Khám bệnh";
            this.Column4.UseColumnTextForButtonValue = true;
            // 
            // rbtnTatCa
            // 
            this.rbtnTatCa.AutoSize = true;
            this.rbtnTatCa.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnTatCa.Location = new System.Drawing.Point(354, 122);
            this.rbtnTatCa.Name = "rbtnTatCa";
            this.rbtnTatCa.Size = new System.Drawing.Size(97, 29);
            this.rbtnTatCa.TabIndex = 14;
            this.rbtnTatCa.Text = "Tất cả";
            this.rbtnTatCa.UseVisualStyleBackColor = true;
            // 
            // rbtnDaKham
            // 
            this.rbtnDaKham.AutoSize = true;
            this.rbtnDaKham.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnDaKham.Location = new System.Drawing.Point(211, 123);
            this.rbtnDaKham.Name = "rbtnDaKham";
            this.rbtnDaKham.Size = new System.Drawing.Size(124, 29);
            this.rbtnDaKham.TabIndex = 13;
            this.rbtnDaKham.Text = "Đã khám";
            this.rbtnDaKham.UseVisualStyleBackColor = true;
            // 
            // rbtnChoKham
            // 
            this.rbtnChoKham.AutoSize = true;
            this.rbtnChoKham.Checked = true;
            this.rbtnChoKham.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnChoKham.Location = new System.Drawing.Point(56, 123);
            this.rbtnChoKham.Name = "rbtnChoKham";
            this.rbtnChoKham.Size = new System.Drawing.Size(138, 29);
            this.rbtnChoKham.TabIndex = 12;
            this.rbtnChoKham.TabStop = true;
            this.rbtnChoKham.Text = "Chờ khám";
            this.rbtnChoKham.UseVisualStyleBackColor = true;
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.White;
            this.btnReload.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.Location = new System.Drawing.Point(1089, 110);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(149, 51);
            this.btnReload.TabIndex = 11;
            this.btnReload.Text = "Reload";
            this.btnReload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReload.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(874, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Phòng khám";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(510, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Ngày khám";
            // 
            // DataKhamChua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1606, 900);
            this.Controls.Add(this.rbtnTatCa);
            this.Controls.Add(this.rbtnDaKham);
            this.Controls.Add(this.rbtnChoKham);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtgvTT);
            this.Controls.Add(this.panel1);
            this.Name = "DataKhamChua";
            this.Text = "DataKhamChua";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTenPhong;
        private System.Windows.Forms.DataGridView dtgvTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
        private System.Windows.Forms.RadioButton rbtnTatCa;
        private System.Windows.Forms.RadioButton rbtnDaKham;
        private System.Windows.Forms.RadioButton rbtnChoKham;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}