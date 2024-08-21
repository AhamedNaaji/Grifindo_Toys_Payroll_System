using System.Windows.Forms;

namespace Grifindo_Toys_Payroll_System
{
    partial class Leave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Leave));
            this.txtReason = new System.Windows.Forms.TextBox();
            this.dgvLeave = new System.Windows.Forms.DataGridView();
            this.dtpLeaveEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpLeaveStartDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNoOfDays = new System.Windows.Forms.Label();
            this.CmbEmpID = new System.Windows.Forms.ComboBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblRemainingLeaves = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeave)).BeginInit();
            this.SuspendLayout();
            // 
            // txtReason
            // 
            this.txtReason.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReason.Location = new System.Drawing.Point(540, 146);
            this.txtReason.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(313, 29);
            this.txtReason.TabIndex = 70;
            this.txtReason.TextChanged += new System.EventHandler(this.txtReason_TextChanged);
            // 
            // dgvLeave
            // 
            this.dgvLeave.BackgroundColor = System.Drawing.Color.Bisque;
            this.dgvLeave.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLeave.Location = new System.Drawing.Point(17, 271);
            this.dgvLeave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvLeave.Name = "dgvLeave";
            this.dgvLeave.ReadOnly = true;
            this.dgvLeave.RowHeadersWidth = 51;
            this.dgvLeave.RowTemplate.Height = 24;
            this.dgvLeave.Size = new System.Drawing.Size(1035, 268);
            this.dgvLeave.TabIndex = 63;
            this.dgvLeave.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLeave_CellContentClick);
            // 
            // dtpLeaveEndDate
            // 
            this.dtpLeaveEndDate.CustomFormat = "yyyy-MM-dd";
            this.dtpLeaveEndDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpLeaveEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLeaveEndDate.Location = new System.Drawing.Point(218, 218);
            this.dtpLeaveEndDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpLeaveEndDate.Name = "dtpLeaveEndDate";
            this.dtpLeaveEndDate.Size = new System.Drawing.Size(141, 32);
            this.dtpLeaveEndDate.TabIndex = 60;
            this.dtpLeaveEndDate.ValueChanged += new System.EventHandler(this.dtpLeaveEndDate_ValueChanged);
            // 
            // dtpLeaveStartDate
            // 
            this.dtpLeaveStartDate.CustomFormat = "yyyy-MM-dd";
            this.dtpLeaveStartDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpLeaveStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLeaveStartDate.Location = new System.Drawing.Point(218, 158);
            this.dtpLeaveStartDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpLeaveStartDate.Name = "dtpLeaveStartDate";
            this.dtpLeaveStartDate.Size = new System.Drawing.Size(141, 32);
            this.dtpLeaveStartDate.TabIndex = 59;
            this.dtpLeaveStartDate.Value = new System.DateTime(2024, 1, 2, 12, 24, 11, 0);
            this.dtpLeaveStartDate.ValueChanged += new System.EventHandler(this.dtpLeaveStartDate_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Tan;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(402, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 29);
            this.label5.TabIndex = 58;
            this.label5.Text = "Reason";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Tan;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(402, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 29);
            this.label4.TabIndex = 57;
            this.label4.Text = "No oF Days";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Tan;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 29);
            this.label3.TabIndex = 56;
            this.label3.Text = "Leave End Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Tan;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 29);
            this.label2.TabIndex = 55;
            this.label2.Text = "Leave Start Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Tan;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 29);
            this.label1.TabIndex = 72;
            this.label1.Text = "Emp ID";
            // 
            // lblNoOfDays
            // 
            this.lblNoOfDays.BackColor = System.Drawing.Color.Bisque;
            this.lblNoOfDays.Location = new System.Drawing.Point(709, 209);
            this.lblNoOfDays.Name = "lblNoOfDays";
            this.lblNoOfDays.Size = new System.Drawing.Size(144, 36);
            this.lblNoOfDays.TabIndex = 73;
            // 
            // CmbEmpID
            // 
            this.CmbEmpID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEmpID.FormattingEnabled = true;
            this.CmbEmpID.Location = new System.Drawing.Point(135, 91);
            this.CmbEmpID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CmbEmpID.Name = "CmbEmpID";
            this.CmbEmpID.Size = new System.Drawing.Size(224, 32);
            this.CmbEmpID.TabIndex = 74;
            this.CmbEmpID.SelectedIndexChanged += new System.EventHandler(this.CmbEmpID_SelectedIndexChanged);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.Transparent;
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnNew.FlatAppearance.BorderSize = 2;
            this.btnNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnNew.Font = new System.Drawing.Font("Candara", 19.8F, System.Drawing.FontStyle.Bold);
            this.btnNew.ForeColor = System.Drawing.Color.SlateGray;
            this.btnNew.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNew.Location = new System.Drawing.Point(807, 566);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(245, 55);
            this.btnNew.TabIndex = 78;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnDelete.FlatAppearance.BorderSize = 2;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnDelete.Font = new System.Drawing.Font("Candara", 19.8F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDelete.Location = new System.Drawing.Point(541, 566);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(197, 55);
            this.btnDelete.TabIndex = 77;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnUpdate.FlatAppearance.BorderSize = 2;
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnUpdate.Font = new System.Drawing.Font("Candara", 19.8F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.Blue;
            this.btnUpdate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUpdate.Location = new System.Drawing.Point(277, 566);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(206, 55);
            this.btnUpdate.TabIndex = 76;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click_1);
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.Transparent;
            this.btnInsert.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnInsert.FlatAppearance.BorderSize = 2;
            this.btnInsert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnInsert.Font = new System.Drawing.Font("Candara", 19.8F, System.Drawing.FontStyle.Bold);
            this.btnInsert.ForeColor = System.Drawing.Color.Lime;
            this.btnInsert.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnInsert.Location = new System.Drawing.Point(17, 566);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(205, 55);
            this.btnInsert.TabIndex = 75;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click_1);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Bisque;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1064, 62);
            this.label6.TabIndex = 79;
            this.label6.Text = "Leave Details";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRemainingLeaves
            // 
            this.lblRemainingLeaves.BackColor = System.Drawing.Color.Bisque;
            this.lblRemainingLeaves.Location = new System.Drawing.Point(709, 90);
            this.lblRemainingLeaves.Name = "lblRemainingLeaves";
            this.lblRemainingLeaves.Size = new System.Drawing.Size(144, 36);
            this.lblRemainingLeaves.TabIndex = 80;
            this.lblRemainingLeaves.Click += new System.EventHandler(this.lblRemainingLeaves_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Tan;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(402, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(281, 29);
            this.label8.TabIndex = 81;
            this.label8.Text = "Remaining No Of Leaves";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Image = global::Grifindo_Toys_Payroll_System.Properties.Resources.leave;
            this.label7.Location = new System.Drawing.Point(928, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 86);
            this.label7.TabIndex = 83;
            // 
            // Leave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1064, 634);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblRemainingLeaves);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.CmbEmpID);
            this.Controls.Add(this.lblNoOfDays);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.dgvLeave);
            this.Controls.Add(this.dtpLeaveEndDate);
            this.Controls.Add(this.dtpLeaveStartDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Leave";
            this.Text = "Leave";
            this.Load += new System.EventHandler(this.Leave_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.DataGridView dgvLeave;
        private System.Windows.Forms.DateTimePicker dtpLeaveEndDate;
        private System.Windows.Forms.DateTimePicker dtpLeaveStartDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNoOfDays;
        private System.Windows.Forms.ComboBox CmbEmpID;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblRemainingLeaves;
        private System.Windows.Forms.Label label8;
        private Label label7;
    }
}