using System;

namespace Department.UI
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tv_Departments = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_empEDIT = new System.Windows.Forms.Button();
            this.btn_remEmp = new System.Windows.Forms.Button();
            this.btn_addEmp = new System.Windows.Forms.Button();
            this.dg_Employee = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Employee)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.tv_Departments);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 418);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Подразделения";
            this.groupBox1.Leave += new System.EventHandler(this.groupBox1_Leave);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(85, 384);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(57, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "-";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 384);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tv_Departments
            // 
            this.tv_Departments.Location = new System.Drawing.Point(15, 19);
            this.tv_Departments.Name = "tv_Departments";
            this.tv_Departments.Size = new System.Drawing.Size(192, 359);
            this.tv_Departments.TabIndex = 0;
            this.tv_Departments.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_Departments_AfterSelect);
            this.tv_Departments.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_Departments_NodeMouseClick);
            this.tv_Departments.Leave += new System.EventHandler(this.tv_Departments_Leave);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_empEDIT);
            this.groupBox2.Controls.Add(this.btn_remEmp);
            this.groupBox2.Controls.Add(this.btn_addEmp);
            this.groupBox2.Controls.Add(this.dg_Employee);
            this.groupBox2.Location = new System.Drawing.Point(231, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(979, 418);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Работники";
            // 
            // btn_empEDIT
            // 
            this.btn_empEDIT.Enabled = false;
            this.btn_empEDIT.Location = new System.Drawing.Point(779, 389);
            this.btn_empEDIT.Name = "btn_empEDIT";
            this.btn_empEDIT.Size = new System.Drawing.Size(67, 23);
            this.btn_empEDIT.TabIndex = 3;
            this.btn_empEDIT.Text = "Изменить";
            this.btn_empEDIT.UseVisualStyleBackColor = true;
            this.btn_empEDIT.Click += new System.EventHandler(this.btn_empEDIT_Click);
            // 
            // btn_remEmp
            // 
            this.btn_remEmp.Enabled = false;
            this.btn_remEmp.Location = new System.Drawing.Point(852, 389);
            this.btn_remEmp.Name = "btn_remEmp";
            this.btn_remEmp.Size = new System.Drawing.Size(57, 23);
            this.btn_remEmp.TabIndex = 2;
            this.btn_remEmp.Text = "-";
            this.btn_remEmp.UseVisualStyleBackColor = true;
            this.btn_remEmp.Click += new System.EventHandler(this.btn_remEmp_Click);
            // 
            // btn_addEmp
            // 
            this.btn_addEmp.Enabled = false;
            this.btn_addEmp.Location = new System.Drawing.Point(915, 389);
            this.btn_addEmp.Name = "btn_addEmp";
            this.btn_addEmp.Size = new System.Drawing.Size(58, 23);
            this.btn_addEmp.TabIndex = 1;
            this.btn_addEmp.Text = "+";
            this.btn_addEmp.UseVisualStyleBackColor = true;
            this.btn_addEmp.Click += new System.EventHandler(this.btn_addEmp_Click);
            // 
            // dg_Employee
            // 
            this.dg_Employee.AllowUserToAddRows = false;
            this.dg_Employee.AllowUserToDeleteRows = false;
            this.dg_Employee.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_Employee.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dg_Employee.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dg_Employee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Employee.Location = new System.Drawing.Point(6, 19);
            this.dg_Employee.MultiSelect = false;
            this.dg_Employee.Name = "dg_Employee";
            this.dg_Employee.ReadOnly = true;
            this.dg_Employee.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dg_Employee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Employee.Size = new System.Drawing.Size(967, 364);
            this.dg_Employee.TabIndex = 0;
            this.dg_Employee.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_Employee_CellValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 434);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Управление составом подразделений";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Employee)).EndInit();
            this.ResumeLayout(false);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TreeView tv_Departments;
        private System.Windows.Forms.Button btn_addEmp;
        private System.Windows.Forms.DataGridView dg_Employee;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_remEmp;
        private System.Windows.Forms.Button btn_empEDIT;
    }
}

