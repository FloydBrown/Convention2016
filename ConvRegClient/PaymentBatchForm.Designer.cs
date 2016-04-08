namespace ConventionRegistration
{
    partial class PaymentBatchForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gA_Gideon_ConvDataSet = new ConventionRegistration.GA_Gideon_ConvDataSet();
            this.gAGideonConvDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.batchPaymentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.batchPaymentsTableAdapter = new ConventionRegistration.GA_Gideon_ConvDataSetTableAdapters.BatchPaymentsTableAdapter();
            this.paymentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pAYMENTMETHODDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pAYMENTDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pAYMENTTYPEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCNUMBERDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pAYMENTAMOUNTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textComment = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gA_Gideon_ConvDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gAGideonConvDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.batchPaymentsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.paymentIDDataGridViewTextBoxColumn,
            this.pAYMENTMETHODDataGridViewTextBoxColumn,
            this.pAYMENTDATEDataGridViewTextBoxColumn,
            this.pAYMENTTYPEDataGridViewTextBoxColumn,
            this.cCNUMBERDataGridViewTextBoxColumn,
            this.pAYMENTAMOUNTDataGridViewTextBoxColumn,
            this.firstNameDataGridViewTextBoxColumn,
            this.lastNameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.batchPaymentsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 73);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(748, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // gA_Gideon_ConvDataSet
            // 
            this.gA_Gideon_ConvDataSet.DataSetName = "GA_Gideon_ConvDataSet";
            this.gA_Gideon_ConvDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gAGideonConvDataSetBindingSource
            // 
            this.gAGideonConvDataSetBindingSource.DataSource = this.gA_Gideon_ConvDataSet;
            this.gAGideonConvDataSetBindingSource.Position = 0;
            // 
            // batchPaymentsBindingSource
            // 
            this.batchPaymentsBindingSource.DataMember = "BatchPayments";
            this.batchPaymentsBindingSource.DataSource = this.gAGideonConvDataSetBindingSource;
            // 
            // batchPaymentsTableAdapter
            // 
            this.batchPaymentsTableAdapter.ClearBeforeFill = true;
            // 
            // paymentIDDataGridViewTextBoxColumn
            // 
            this.paymentIDDataGridViewTextBoxColumn.DataPropertyName = "Payment_ID";
            this.paymentIDDataGridViewTextBoxColumn.FillWeight = 50F;
            this.paymentIDDataGridViewTextBoxColumn.HeaderText = "Payment_ID";
            this.paymentIDDataGridViewTextBoxColumn.Name = "paymentIDDataGridViewTextBoxColumn";
            this.paymentIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pAYMENTMETHODDataGridViewTextBoxColumn
            // 
            this.pAYMENTMETHODDataGridViewTextBoxColumn.DataPropertyName = "PAYMENT_METHOD";
            this.pAYMENTMETHODDataGridViewTextBoxColumn.FillWeight = 60F;
            this.pAYMENTMETHODDataGridViewTextBoxColumn.HeaderText = "PAYMENT_METHOD";
            this.pAYMENTMETHODDataGridViewTextBoxColumn.Name = "pAYMENTMETHODDataGridViewTextBoxColumn";
            // 
            // pAYMENTDATEDataGridViewTextBoxColumn
            // 
            this.pAYMENTDATEDataGridViewTextBoxColumn.DataPropertyName = "PAYMENT_DATE";
            this.pAYMENTDATEDataGridViewTextBoxColumn.HeaderText = "PAYMENT_DATE";
            this.pAYMENTDATEDataGridViewTextBoxColumn.Name = "pAYMENTDATEDataGridViewTextBoxColumn";
            // 
            // pAYMENTTYPEDataGridViewTextBoxColumn
            // 
            this.pAYMENTTYPEDataGridViewTextBoxColumn.DataPropertyName = "PAYMENT_TYPE";
            this.pAYMENTTYPEDataGridViewTextBoxColumn.HeaderText = "PAYMENT_TYPE";
            this.pAYMENTTYPEDataGridViewTextBoxColumn.Name = "pAYMENTTYPEDataGridViewTextBoxColumn";
            this.pAYMENTTYPEDataGridViewTextBoxColumn.Visible = false;
            // 
            // cCNUMBERDataGridViewTextBoxColumn
            // 
            this.cCNUMBERDataGridViewTextBoxColumn.DataPropertyName = "CC_NUMBER";
            this.cCNUMBERDataGridViewTextBoxColumn.HeaderText = "CC_NUMBER";
            this.cCNUMBERDataGridViewTextBoxColumn.Name = "cCNUMBERDataGridViewTextBoxColumn";
            // 
            // pAYMENTAMOUNTDataGridViewTextBoxColumn
            // 
            this.pAYMENTAMOUNTDataGridViewTextBoxColumn.DataPropertyName = "PAYMENT_AMOUNT";
            this.pAYMENTAMOUNTDataGridViewTextBoxColumn.HeaderText = "PAYMENT_AMOUNT";
            this.pAYMENTAMOUNTDataGridViewTextBoxColumn.Name = "pAYMENTAMOUNTDataGridViewTextBoxColumn";
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            this.firstNameDataGridViewTextBoxColumn.DataPropertyName = "First_Name";
            this.firstNameDataGridViewTextBoxColumn.HeaderText = "First_Name";
            this.firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            this.lastNameDataGridViewTextBoxColumn.DataPropertyName = "Last_Name";
            this.lastNameDataGridViewTextBoxColumn.HeaderText = "Last_Name";
            this.lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(26, 13);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(61, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Checks";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(26, 37);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(82, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Credit Cards";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Batch Comment:";
            // 
            // textComment
            // 
            this.textComment.Location = new System.Drawing.Point(157, 37);
            this.textComment.Name = "textComment";
            this.textComment.Size = new System.Drawing.Size(514, 20);
            this.textComment.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(288, 236);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Create New Batch";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PaymentBatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 271);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textComment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "PaymentBatchForm";
            this.Text = "PaymentBatchForm";
            this.Load += new System.EventHandler(this.PaymentBatchForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gA_Gideon_ConvDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gAGideonConvDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.batchPaymentsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pAYMENTMETHODDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pAYMENTDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pAYMENTTYPEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCNUMBERDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pAYMENTAMOUNTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource batchPaymentsBindingSource;
        private System.Windows.Forms.BindingSource gAGideonConvDataSetBindingSource;
        private GA_Gideon_ConvDataSet gA_Gideon_ConvDataSet;
        private GA_Gideon_ConvDataSetTableAdapters.BatchPaymentsTableAdapter batchPaymentsTableAdapter;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textComment;
        private System.Windows.Forms.Button button1;
    }
}