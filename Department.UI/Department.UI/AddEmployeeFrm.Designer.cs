namespace Department.UI
{
    partial class AddEmployeeFrm
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
            this.tb_name = new System.Windows.Forms.TextBox();
            this.tb_surname = new System.Windows.Forms.TextBox();
            this.tb_middle = new System.Windows.Forms.TextBox();
            this.tb_prof = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_age = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_tH = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rb_male = new System.Windows.Forms.RadioButton();
            this.rb_female = new System.Windows.Forms.RadioButton();
            this.tb_bith = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(83, 62);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(156, 20);
            this.tb_name.TabIndex = 0;
            this.tb_name.Validating += new System.ComponentModel.CancelEventHandler(this.tb_name_Validating);
            // 
            // tb_surname
            // 
            this.tb_surname.Location = new System.Drawing.Point(83, 114);
            this.tb_surname.Name = "tb_surname";
            this.tb_surname.Size = new System.Drawing.Size(156, 20);
            this.tb_surname.TabIndex = 1;
            this.tb_surname.Validating += new System.ComponentModel.CancelEventHandler(this.tb_surname_Validating);
            // 
            // tb_middle
            // 
            this.tb_middle.Location = new System.Drawing.Point(83, 166);
            this.tb_middle.Name = "tb_middle";
            this.tb_middle.Size = new System.Drawing.Size(156, 20);
            this.tb_middle.TabIndex = 2;
            this.tb_middle.TextChanged += new System.EventHandler(this.tb_middle_TextChanged);
            // 
            // tb_prof
            // 
            this.tb_prof.Location = new System.Drawing.Point(83, 227);
            this.tb_prof.Name = "tb_prof";
            this.tb_prof.Size = new System.Drawing.Size(156, 20);
            this.tb_prof.TabIndex = 3;
            this.tb_prof.Validating += new System.ComponentModel.CancelEventHandler(this.tb_prof_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Constantia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(139, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Constantia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(114, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Фамилия";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Constantia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(112, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "Отчество";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Constantia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(108, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "Профессия";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Constantia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(139, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 26);
            this.label5.TabIndex = 9;
            this.label5.Text = "Пол";
            // 
            // tb_age
            // 
            this.tb_age.Location = new System.Drawing.Point(117, 332);
            this.tb_age.Name = "tb_age";
            this.tb_age.Size = new System.Drawing.Size(83, 20);
            this.tb_age.TabIndex = 10;
            this.tb_age.Validating += new System.ComponentModel.CancelEventHandler(this.tb_age_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Constantia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(114, 303);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 26);
            this.label6.TabIndex = 11;
            this.label6.Text = "Возраст";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Constantia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(78, 355);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(184, 26);
            this.label7.TabIndex = 12;
            this.label7.Text = "Табельный номер";
            // 
            // tb_tH
            // 
            this.tb_tH.Location = new System.Drawing.Point(83, 384);
            this.tb_tH.Name = "tb_tH";
            this.tb_tH.Size = new System.Drawing.Size(167, 20);
            this.tb_tH.TabIndex = 13;
            this.tb_tH.Validating += new System.ComponentModel.CancelEventHandler(this.tb_tH_Validating);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 33);
            this.button1.TabIndex = 14;
            this.button1.Text = "✓";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rb_male
            // 
            this.rb_male.AutoSize = true;
            this.rb_male.Checked = true;
            this.rb_male.Location = new System.Drawing.Point(83, 283);
            this.rb_male.Name = "rb_male";
            this.rb_male.Size = new System.Drawing.Size(71, 17);
            this.rb_male.TabIndex = 15;
            this.rb_male.TabStop = true;
            this.rb_male.Text = "Мужской";
            this.rb_male.UseVisualStyleBackColor = true;
            // 
            // rb_female
            // 
            this.rb_female.AutoSize = true;
            this.rb_female.Location = new System.Drawing.Point(165, 283);
            this.rb_female.Name = "rb_female";
            this.rb_female.Size = new System.Drawing.Size(72, 17);
            this.rb_female.TabIndex = 16;
            this.rb_female.Text = "Женский";
            this.rb_female.UseVisualStyleBackColor = true;
            // 
            // tb_bith
            // 
            this.tb_bith.Location = new System.Drawing.Point(117, 459);
            this.tb_bith.Mask = "00/00/0000";
            this.tb_bith.Name = "tb_bith";
            this.tb_bith.Size = new System.Drawing.Size(83, 20);
            this.tb_bith.TabIndex = 17;
            this.tb_bith.ValidatingType = typeof(System.DateTime);
            this.tb_bith.Validating += new System.ComponentModel.CancelEventHandler(this.tb_bith_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Constantia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(84, 418);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 26);
            this.label8.TabIndex = 18;
            this.label8.Text = "Дата Рождения";
            // 
            // AddEmployeeFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 509);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tb_bith);
            this.Controls.Add(this.rb_female);
            this.Controls.Add(this.rb_male);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_tH);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_age);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_prof);
            this.Controls.Add(this.tb_middle);
            this.Controls.Add(this.tb_surname);
            this.Controls.Add(this.tb_name);
            this.Name = "AddEmployeeFrm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddEmployeeFrm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.TextBox tb_surname;
        private System.Windows.Forms.TextBox tb_middle;
        private System.Windows.Forms.TextBox tb_prof;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_age;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_tH;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rb_male;
        private System.Windows.Forms.RadioButton rb_female;
        private System.Windows.Forms.MaskedTextBox tb_bith;
        private System.Windows.Forms.Label label8;
    }
}