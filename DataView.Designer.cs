namespace EvaluationSys
{
    partial class DataView
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column15 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_selectAll = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.endAge = new System.Windows.Forms.NumericUpDown();
            this.startAge = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Idcard = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_analyse = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startAge)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column15,
            this.Column1,
            this.Column18,
            this.Column17,
            this.Column14,
            this.Column13,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column20,
            this.Column19,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column21,
            this.Column16});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(788, 176);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column15
            // 
            this.Column15.Frozen = true;
            this.Column15.HeaderText = "选择";
            this.Column15.Name = "Column15";
            this.Column15.Width = 40;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "PersonName";
            this.Column1.HeaderText = "姓名";
            this.Column1.Name = "Column1";
            // 
            // Column18
            // 
            this.Column18.DataPropertyName = "CtrlYear";
            this.Column18.HeaderText = "管制工龄";
            this.Column18.Name = "Column18";
            // 
            // Column17
            // 
            this.Column17.DataPropertyName = "idcard";
            this.Column17.HeaderText = "身份证号";
            this.Column17.Name = "Column17";
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "Date";
            this.Column14.HeaderText = "评估时间";
            this.Column14.Name = "Column14";
            this.Column14.Width = 150;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "Total";
            this.Column13.HeaderText = "总分";
            this.Column13.Name = "Column13";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "graedu";
            this.Column2.HeaderText = "学历分数";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "graold";
            this.Column3.HeaderText = "年龄分数";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "graPermit";
            this.Column4.HeaderText = "执照分数";
            this.Column4.Name = "Column4";
            // 
            // Column20
            // 
            this.Column20.DataPropertyName = "CtrlDuty";
            this.Column20.HeaderText = "检查员和教员得分";
            this.Column20.Name = "Column20";
            // 
            // Column19
            // 
            this.Column19.DataPropertyName = "HighPost";
            this.Column19.HeaderText = "行政职务分数";
            this.Column19.Name = "Column19";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "graWordate";
            this.Column5.HeaderText = "工作年限分数";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "graLevel";
            this.Column6.HeaderText = "等级分数";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "graEnglish";
            this.Column7.HeaderText = "英语分数";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "graCheckbody";
            this.Column8.HeaderText = "体检分数";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "graDuty";
            this.Column9.HeaderText = "职务分数";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "gratrainDuty";
            this.Column10.HeaderText = "岗位培训分数";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "gratrainAboard";
            this.Column11.HeaderText = "赴外培训分数";
            this.Column11.Name = "Column11";
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "graAdd";
            this.Column12.HeaderText = "奖励加分";
            this.Column12.Name = "Column12";
            // 
            // Column21
            // 
            this.Column21.DataPropertyName = "PermitCheck";
            this.Column21.HeaderText = "放单分数";
            this.Column21.Name = "Column21";
            // 
            // Column16
            // 
            this.Column16.DataPropertyName = "PersonID";
            this.Column16.HeaderText = "PersonID";
            this.Column16.Name = "Column16";
            this.Column16.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_selectAll);
            this.panel1.Controls.Add(this.btn_save);
            this.panel1.Controls.Add(this.endAge);
            this.panel1.Controls.Add(this.startAge);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txt_Idcard);
            this.panel1.Controls.Add(this.txt_name);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_analyse);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(788, 66);
            this.panel1.TabIndex = 0;
            // 
            // btn_selectAll
            // 
            this.btn_selectAll.Enabled = false;
            this.btn_selectAll.Location = new System.Drawing.Point(650, 22);
            this.btn_selectAll.Name = "btn_selectAll";
            this.btn_selectAll.Size = new System.Drawing.Size(47, 21);
            this.btn_selectAll.TabIndex = 7;
            this.btn_selectAll.Text = "全选";
            this.btn_selectAll.UseVisualStyleBackColor = true;
            this.btn_selectAll.Click += new System.EventHandler(this.btn_selectAll_Click);
            // 
            // btn_save
            // 
            this.btn_save.Enabled = false;
            this.btn_save.Location = new System.Drawing.Point(703, 22);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(47, 21);
            this.btn_save.TabIndex = 7;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // endAge
            // 
            this.endAge.Enabled = false;
            this.endAge.Location = new System.Drawing.Point(508, 25);
            this.endAge.Name = "endAge";
            this.endAge.Size = new System.Drawing.Size(52, 21);
            this.endAge.TabIndex = 6;
            this.endAge.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // startAge
            // 
            this.startAge.Enabled = false;
            this.startAge.Location = new System.Drawing.Point(431, 25);
            this.startAge.Name = "startAge";
            this.startAge.Size = new System.Drawing.Size(52, 21);
            this.startAge.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(489, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "--";
            // 
            // txt_Idcard
            // 
            this.txt_Idcard.Location = new System.Drawing.Point(261, 25);
            this.txt_Idcard.Name = "txt_Idcard";
            this.txt_Idcard.Size = new System.Drawing.Size(116, 21);
            this.txt_Idcard.TabIndex = 3;
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(80, 28);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(100, 21);
            this.txt_name.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(394, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "年龄";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(200, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "身份证号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "姓名";
            // 
            // btn_analyse
            // 
            this.btn_analyse.Location = new System.Drawing.Point(590, 23);
            this.btn_analyse.Name = "btn_analyse";
            this.btn_analyse.Size = new System.Drawing.Size(54, 21);
            this.btn_analyse.TabIndex = 0;
            this.btn_analyse.Text = "分析";
            this.btn_analyse.UseVisualStyleBackColor = true;
            this.btn_analyse.Click += new System.EventHandler(this.btn_analyse_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(788, 176);
            this.panel2.TabIndex = 1;
            // 
            // DataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 242);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "DataView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "人员评估";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startAge)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_analyse;
        private System.Windows.Forms.TextBox txt_Idcard;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.NumericUpDown endAge;
        private System.Windows.Forms.NumericUpDown startAge;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_selectAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column20;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
    }
}