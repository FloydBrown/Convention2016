namespace ConventionRegistration
{
    partial class BadgeForm
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
            this.badgeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gAGideonConvDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gA_Gideon_ConvDataSet = new ConventionRegistration.GA_Gideon_ConvDataSet();
            this.badgeTableAdapter = new ConventionRegistration.GA_Gideon_ConvDataSetTableAdapters.BadgeTableAdapter();
            this.badgeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oldBadgeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.middleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.badgeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.badgeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gAGideonConvDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gA_Gideon_ConvDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.badgeIDDataGridViewTextBoxColumn,
            this.Title,
            this.oldBadgeName,
            this.firstName,
            this.middleName,
            this.lastName,
            this.badgeName,
            this.City});
            this.dataGridView1.DataSource = this.badgeBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(639, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // badgeBindingSource
            // 
            this.badgeBindingSource.DataMember = "Badge";
            this.badgeBindingSource.DataSource = this.gAGideonConvDataSetBindingSource;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(398, 186);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save Badges";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(147, 186);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add Badge";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gAGideonConvDataSetBindingSource
            // 
            this.gAGideonConvDataSetBindingSource.DataSource = this.gA_Gideon_ConvDataSet;
            this.gAGideonConvDataSetBindingSource.Position = 0;
            // 
            // gA_Gideon_ConvDataSet
            // 
            this.gA_Gideon_ConvDataSet.DataSetName = "GA_Gideon_ConvDataSet";
            this.gA_Gideon_ConvDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // badgeTableAdapter
            // 
            this.badgeTableAdapter.ClearBeforeFill = true;
            // 
            // badgeIDDataGridViewTextBoxColumn
            // 
            this.badgeIDDataGridViewTextBoxColumn.DataPropertyName = "Badge_ID";
            this.badgeIDDataGridViewTextBoxColumn.HeaderText = "Badge_ID";
            this.badgeIDDataGridViewTextBoxColumn.Name = "badgeIDDataGridViewTextBoxColumn";
            this.badgeIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // Title
            // 
            this.Title.DataPropertyName = "Title";
            this.Title.FillWeight = 60F;
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            // 
            // oldBadgeName
            // 
            this.oldBadgeName.DataPropertyName = "Old_Badge_Name";
            this.oldBadgeName.HeaderText = "Old Badge Name";
            this.oldBadgeName.Name = "oldBadgeName";
            this.oldBadgeName.ReadOnly = true;
            this.oldBadgeName.Visible = false;
            // 
            // firstName
            // 
            this.firstName.DataPropertyName = "First_Name";
            this.firstName.HeaderText = "First Name";
            this.firstName.Name = "firstName";
            // 
            // middleName
            // 
            this.middleName.DataPropertyName = "Middle_Name";
            this.middleName.HeaderText = "Middle Name";
            this.middleName.Name = "middleName";
            // 
            // lastName
            // 
            this.lastName.DataPropertyName = "Last_Name";
            this.lastName.HeaderText = "Last Name";
            this.lastName.Name = "lastName";
            // 
            // badgeName
            // 
            this.badgeName.DataPropertyName = "Badge_Name";
            this.badgeName.HeaderText = "Badge_Name";
            this.badgeName.Name = "badgeName";
            // 
            // City
            // 
            this.City.DataPropertyName = "City";
            this.City.HeaderText = "City";
            this.City.Name = "City";
            // 
            // BadgeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 232);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dataGridView1);
            this.Name = "BadgeForm";
            this.Text = "BadgeForm";
            this.Load += new System.EventHandler(this.BadgeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.badgeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gAGideonConvDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gA_Gideon_ConvDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource badgeBindingSource;
        private System.Windows.Forms.BindingSource gAGideonConvDataSetBindingSource;
        private GA_Gideon_ConvDataSet gA_Gideon_ConvDataSet;
        private GA_Gideon_ConvDataSetTableAdapters.BadgeTableAdapter badgeTableAdapter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn badgeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn oldBadgeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn middleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn badgeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
    }
}