namespace ForeignLanguageCenter.UI
{
    partial class frmTransaction
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtstartDate = new System.Windows.Forms.DateTimePicker();
            this.txtProcessedBy = new System.Windows.Forms.TextBox();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.txtTransactionID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSearch__Transaction = new System.Windows.Forms.Button();
            this.btnViewDetail = new System.Windows.Forms.Button();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtEndDate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtstartDate);
            this.groupBox1.Controls.Add(this.txtProcessedBy);
            this.groupBox1.Controls.Add(this.txtStudentID);
            this.groupBox1.Controls.Add(this.txtTotalAmount);
            this.groupBox1.Controls.Add(this.txtTransactionID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(645, 197);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transaction Information";
            // 
            // dtEndDate
            // 
            this.dtEndDate.Location = new System.Drawing.Point(449, 141);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(180, 22);
            this.dtEndDate.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(348, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "To Date:";
            // 
            // dtstartDate
            // 
            this.dtstartDate.Location = new System.Drawing.Point(127, 141);
            this.dtstartDate.Name = "dtstartDate";
            this.dtstartDate.Size = new System.Drawing.Size(180, 22);
            this.dtstartDate.TabIndex = 9;
            // 
            // txtProcessedBy
            // 
            this.txtProcessedBy.Location = new System.Drawing.Point(127, 84);
            this.txtProcessedBy.Name = "txtProcessedBy";
            this.txtProcessedBy.Size = new System.Drawing.Size(180, 22);
            this.txtProcessedBy.TabIndex = 8;
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(449, 37);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(180, 22);
            this.txtStudentID.TabIndex = 7;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(449, 87);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(180, 22);
            this.txtTotalAmount.TabIndex = 6;
            // 
            // txtTransactionID
            // 
            this.txtTransactionID.Location = new System.Drawing.Point(127, 37);
            this.txtTransactionID.Name = "txtTransactionID";
            this.txtTransactionID.Size = new System.Drawing.Size(180, 22);
            this.txtTransactionID.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(348, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Total Amount:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(348, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Student ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Processed By:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "From Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Transaction ID:";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(673, 26);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSearch__Transaction
            // 
            this.btnSearch__Transaction.Location = new System.Drawing.Point(12, 227);
            this.btnSearch__Transaction.Name = "btnSearch__Transaction";
            this.btnSearch__Transaction.Size = new System.Drawing.Size(75, 23);
            this.btnSearch__Transaction.TabIndex = 10;
            this.btnSearch__Transaction.Text = "Search";
            this.btnSearch__Transaction.UseVisualStyleBackColor = true;
            this.btnSearch__Transaction.Click += new System.EventHandler(this.btnSearch_Transaction_Click);
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.Location = new System.Drawing.Point(139, 227);
            this.btnViewDetail.Name = "btnViewDetail";
            this.btnViewDetail.Size = new System.Drawing.Size(75, 23);
            this.btnViewDetail.TabIndex = 11;
            this.btnViewDetail.Text = "Detail";
            this.btnViewDetail.UseVisualStyleBackColor = true;
            this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click);
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.Location = new System.Drawing.Point(13, 281);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.RowHeadersWidth = 51;
            this.dgvTransactions.RowTemplate.Height = 24;
            this.dgvTransactions.Size = new System.Drawing.Size(741, 148);
            this.dgvTransactions.TabIndex = 12;
            // 
            // frmTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvTransactions);
            this.Controls.Add(this.btnViewDetail);
            this.Controls.Add(this.btnSearch__Transaction);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmTransaction";
            this.Text = "frmTransaction";
            this.Load += new System.EventHandler(this.frmTransaction_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DateTimePicker dtstartDate;
        private System.Windows.Forms.TextBox txtProcessedBy;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.TextBox txtTransactionID;
        private System.Windows.Forms.Button btnSearch__Transaction;
        private System.Windows.Forms.Button btnViewDetail;
        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.Label label6;
    }
}