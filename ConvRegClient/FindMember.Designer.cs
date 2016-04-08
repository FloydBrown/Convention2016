namespace ConventionRegistration
{
    partial class FindMember
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
            this.members1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gA_Gideon_ConvDataSet = new ConventionRegistration.GA_Gideon_ConvDataSet();
            this.members1TableAdapter = new ConventionRegistration.GA_Gideon_ConvDataSetTableAdapters.Members1TableAdapter();
            this.accountIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Registration_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.middleNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.campNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.campNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.members1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gA_Gideon_ConvDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.accountIDDataGridViewTextBoxColumn,
            this.Registration_ID,
            this.titleDataGridViewTextBoxColumn,
            this.firstNameDataGridViewTextBoxColumn,
            this.middleNameDataGridViewTextBoxColumn,
            this.lastNameDataGridViewTextBoxColumn,
            this.campNumberDataGridViewTextBoxColumn,
            this.campNameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.members1BindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(13, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(695, 206);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // members1BindingSource
            // 
            this.members1BindingSource.DataMember = "Members1";
            this.members1BindingSource.DataSource = this.gA_Gideon_ConvDataSet;
            // 
            // gA_Gideon_ConvDataSet
            // 
            this.gA_Gideon_ConvDataSet.DataSetName = "GA_Gideon_ConvDataSet";
            this.gA_Gideon_ConvDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // members1TableAdapter
            // 
            this.members1TableAdapter.ClearBeforeFill = true;
            // 
            // accountIDDataGridViewTextBoxColumn
            // 
            this.accountIDDataGridViewTextBoxColumn.DataPropertyName = "Account ID";
            this.accountIDDataGridViewTextBoxColumn.HeaderText = "Member ID";
            this.accountIDDataGridViewTextBoxColumn.Name = "accountIDDataGridViewTextBoxColumn";
            this.accountIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Registration_ID
            // 
            this.Registration_ID.DataPropertyName = "Reg_ID";
            this.Registration_ID.HeaderText = "Reg_ID";
            this.Registration_ID.Name = "Registration_ID";
            this.Registration_ID.ReadOnly = true;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            this.firstNameDataGridViewTextBoxColumn.DataPropertyName = "First Name";
            this.firstNameDataGridViewTextBoxColumn.HeaderText = "First Name";
            this.firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            this.firstNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // middleNameDataGridViewTextBoxColumn
            // 
            this.middleNameDataGridViewTextBoxColumn.DataPropertyName = "Middle Name";
            this.middleNameDataGridViewTextBoxColumn.HeaderText = "Middle Name";
            this.middleNameDataGridViewTextBoxColumn.Name = "middleNameDataGridViewTextBoxColumn";
            this.middleNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.middleNameDataGridViewTextBoxColumn.Visible = false;
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            this.lastNameDataGridViewTextBoxColumn.DataPropertyName = "Last Name";
            this.lastNameDataGridViewTextBoxColumn.HeaderText = "Last Name";
            this.lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            this.lastNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // campNumberDataGridViewTextBoxColumn
            // 
            this.campNumberDataGridViewTextBoxColumn.DataPropertyName = "Camp Number";
            this.campNumberDataGridViewTextBoxColumn.HeaderText = "Camp Number";
            this.campNumberDataGridViewTextBoxColumn.Name = "campNumberDataGridViewTextBoxColumn";
            this.campNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // campNameDataGridViewTextBoxColumn
            // 
            this.campNameDataGridViewTextBoxColumn.DataPropertyName = "Camp Name";
            this.campNameDataGridViewTextBoxColumn.FillWeight = 150F;
            this.campNameDataGridViewTextBoxColumn.HeaderText = "Camp Name";
            this.campNameDataGridViewTextBoxColumn.Name = "campNameDataGridViewTextBoxColumn";
            this.campNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.campNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // FindMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 261);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FindMember";
            this.Text = "Select A Member";
            this.Load += new System.EventHandler(this.FindMember_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.members1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gA_Gideon_ConvDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource members1BindingSource;
        private GA_Gideon_ConvDataSet gA_Gideon_ConvDataSet;
        private GA_Gideon_ConvDataSetTableAdapters.Members1TableAdapter members1TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Registration_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn middleNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn campNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn campNameDataGridViewTextBoxColumn;
    }
}