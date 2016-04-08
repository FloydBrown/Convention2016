namespace ConventionRegistration
{
    partial class CheckinFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.eventBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gA_Gideon_ConvDataSet = new ConventionRegistration.GA_Gideon_ConvDataSet();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            this.eventTableAdapter = new ConventionRegistration.GA_Gideon_ConvDataSetTableAdapters.EventTableAdapter();
            this.btnBadge = new System.Windows.Forms.Button();
            this.eventIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textTotal = new System.Windows.Forms.TextBox();
            this.txtPayments = new System.Windows.Forms.TextBox();
            this.textDue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gA_Gideon_ConvDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.eventIDDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.eventNameDataGridViewTextBoxColumn,
            this.costDataGridViewTextBoxColumn,
            this.Count2,
            this.Cost});
            this.dataGridView1.DataSource = this.eventBindingSource;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridView1.Location = new System.Drawing.Point(13, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(501, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // eventBindingSource
            // 
            this.eventBindingSource.DataMember = "Event";
            this.eventBindingSource.DataSource = this.gA_Gideon_ConvDataSet;
            // 
            // gA_Gideon_ConvDataSet
            // 
            this.gA_Gideon_ConvDataSet.DataSetName = "GA_Gideon_ConvDataSet";
            this.gA_Gideon_ConvDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 13);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(284, 67);
            this.textBox1.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(321, 242);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(174, 242);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(75, 23);
            this.btnPay.TabIndex = 3;
            this.btnPay.Text = "Payment";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // eventTableAdapter
            // 
            this.eventTableAdapter.ClearBeforeFill = true;
            // 
            // btnBadge
            // 
            this.btnBadge.Location = new System.Drawing.Point(47, 242);
            this.btnBadge.Name = "btnBadge";
            this.btnBadge.Size = new System.Drawing.Size(75, 23);
            this.btnBadge.TabIndex = 4;
            this.btnBadge.Text = "Badges";
            this.btnBadge.UseVisualStyleBackColor = true;
            this.btnBadge.Click += new System.EventHandler(this.btnBadge_Click);
            // 
            // eventIDDataGridViewTextBoxColumn
            // 
            this.eventIDDataGridViewTextBoxColumn.DataPropertyName = "Event_ID";
            this.eventIDDataGridViewTextBoxColumn.FillWeight = 50F;
            this.eventIDDataGridViewTextBoxColumn.HeaderText = "Event";
            this.eventIDDataGridViewTextBoxColumn.Name = "eventIDDataGridViewTextBoxColumn";
            this.eventIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.eventIDDataGridViewTextBoxColumn.Visible = false;
            this.eventIDDataGridViewTextBoxColumn.Width = 50;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Count1";
            this.dataGridViewTextBoxColumn1.HeaderText = "Count";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // eventNameDataGridViewTextBoxColumn
            // 
            this.eventNameDataGridViewTextBoxColumn.DataPropertyName = "Event_Name";
            this.eventNameDataGridViewTextBoxColumn.FillWeight = 200F;
            this.eventNameDataGridViewTextBoxColumn.HeaderText = "Event Name";
            this.eventNameDataGridViewTextBoxColumn.Name = "eventNameDataGridViewTextBoxColumn";
            this.eventNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.eventNameDataGridViewTextBoxColumn.Width = 200;
            // 
            // costDataGridViewTextBoxColumn
            // 
            this.costDataGridViewTextBoxColumn.DataPropertyName = "Cost";
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.costDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.costDataGridViewTextBoxColumn.FillWeight = 80F;
            this.costDataGridViewTextBoxColumn.HeaderText = "Price";
            this.costDataGridViewTextBoxColumn.Name = "costDataGridViewTextBoxColumn";
            this.costDataGridViewTextBoxColumn.ReadOnly = true;
            this.costDataGridViewTextBoxColumn.Width = 80;
            // 
            // Count2
            // 
            this.Count2.DataPropertyName = "Count2";
            this.Count2.HeaderText = "Count";
            this.Count2.Name = "Count2";
            // 
            // Cost
            // 
            this.Cost.DataPropertyName = "Ext_Cost";
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.Cost.DefaultCellStyle = dataGridViewCellStyle4;
            this.Cost.FillWeight = 80F;
            this.Cost.HeaderText = "Cost";
            this.Cost.Name = "Cost";
            this.Cost.Width = 80;
            // 
            // textTotal
            // 
            this.textTotal.Location = new System.Drawing.Point(395, 7);
            this.textTotal.Name = "textTotal";
            this.textTotal.ReadOnly = true;
            this.textTotal.Size = new System.Drawing.Size(100, 20);
            this.textTotal.TabIndex = 5;
            // 
            // txtPayments
            // 
            this.txtPayments.Location = new System.Drawing.Point(395, 33);
            this.txtPayments.Name = "txtPayments";
            this.txtPayments.ReadOnly = true;
            this.txtPayments.Size = new System.Drawing.Size(100, 20);
            this.txtPayments.TabIndex = 6;
            // 
            // textDue
            // 
            this.textDue.Location = new System.Drawing.Point(395, 59);
            this.textDue.Name = "textDue";
            this.textDue.ReadOnly = true;
            this.textDue.Size = new System.Drawing.Size(100, 20);
            this.textDue.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(318, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Total Cost:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Total Paid:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(318, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Total Due:";
            // 
            // CheckinFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 267);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textDue);
            this.Controls.Add(this.txtPayments);
            this.Controls.Add(this.textTotal);
            this.Controls.Add(this.btnBadge);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "CheckinFrm";
            this.Text = "Georgia Convention Check-in";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gA_Gideon_ConvDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private GA_Gideon_ConvDataSet gA_Gideon_ConvDataSet;
        private System.Windows.Forms.BindingSource eventBindingSource;
        private GA_Gideon_ConvDataSetTableAdapters.EventTableAdapter eventTableAdapter;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnBadge;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.TextBox textTotal;
        private System.Windows.Forms.TextBox txtPayments;
        private System.Windows.Forms.TextBox textDue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}