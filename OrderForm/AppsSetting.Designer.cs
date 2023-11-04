namespace OrderForm
{
    partial class AppsSetting
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
            this.cancelSave = new System.Windows.Forms.Button();
            this.dvApps = new System.Windows.Forms.DataGridView();
            this.LoadList = new System.Windows.Forms.Button();
            this.lb = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SaveAppsNames = new System.Windows.Forms.Button();
            this.addAppsGroup = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.AppSetsLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvApps)).BeginInit();
            this.addAppsGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelSave
            // 
            this.cancelSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cancelSave.Location = new System.Drawing.Point(0, 561);
            this.cancelSave.Name = "cancelSave";
            this.cancelSave.Size = new System.Drawing.Size(1039, 38);
            this.cancelSave.TabIndex = 1;
            this.cancelSave.Text = "إلغاء الأمر";
            this.cancelSave.UseVisualStyleBackColor = true;
            // 
            // dvApps
            // 
            this.dvApps.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvApps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvApps.Dock = System.Windows.Forms.DockStyle.Left;
            this.dvApps.Location = new System.Drawing.Point(0, 0);
            this.dvApps.Name = "dvApps";
            this.dvApps.Size = new System.Drawing.Size(461, 561);
            this.dvApps.TabIndex = 3;
            this.dvApps.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvApps_CellDoubleClick);
            // 
            // LoadList
            // 
            this.LoadList.Location = new System.Drawing.Point(6, 19);
            this.LoadList.Name = "LoadList";
            this.LoadList.Size = new System.Drawing.Size(127, 23);
            this.LoadList.TabIndex = 4;
            this.LoadList.Text = "نسخ القائمة من الحافظة";
            this.LoadList.UseVisualStyleBackColor = true;
            this.LoadList.Click += new System.EventHandler(this.LoadList_Click_1);
            // 
            // lb
            // 
            this.lb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lb.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb.FormattingEnabled = true;
            this.lb.ItemHeight = 18;
            this.lb.Location = new System.Drawing.Point(302, 62);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(215, 126);
            this.lb.TabIndex = 5;
            this.lb.SelectedIndexChanged += new System.EventHandler(this.lb_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(452, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "اسم التطبيق";
            // 
            // SaveAppsNames
            // 
            this.SaveAppsNames.Location = new System.Drawing.Point(303, 219);
            this.SaveAppsNames.Name = "SaveAppsNames";
            this.SaveAppsNames.Size = new System.Drawing.Size(217, 23);
            this.SaveAppsNames.TabIndex = 7;
            this.SaveAppsNames.Text = "حفظ التعديلات على التطبيقات";
            this.SaveAppsNames.UseVisualStyleBackColor = true;
            this.SaveAppsNames.Click += new System.EventHandler(this.SaveAppsNames_Click);
            // 
            // addAppsGroup
            // 
            this.addAppsGroup.Controls.Add(this.button5);
            this.addAppsGroup.Controls.Add(this.button4);
            this.addAppsGroup.Controls.Add(this.AppSetsLabel);
            this.addAppsGroup.Controls.Add(this.LoadList);
            this.addAppsGroup.Controls.Add(this.button1);
            this.addAppsGroup.Controls.Add(this.textBox1);
            this.addAppsGroup.Controls.Add(this.lb);
            this.addAppsGroup.Controls.Add(this.SaveAppsNames);
            this.addAppsGroup.Controls.Add(this.label1);
            this.addAppsGroup.Location = new System.Drawing.Point(492, 12);
            this.addAppsGroup.Name = "addAppsGroup";
            this.addAppsGroup.Size = new System.Drawing.Size(535, 254);
            this.addAppsGroup.TabIndex = 8;
            this.addAppsGroup.TabStop = false;
            this.addAppsGroup.Text = "إضافة تطبيقات جديدة";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 219);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(151, 23);
            this.button5.TabIndex = 16;
            this.button5.Text = "حفظ التعديلات على الأسماء";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(226, 219);
            this.button4.Name = "button4";
            this.button4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button4.Size = new System.Drawing.Size(71, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = " حذف التطبيق";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // AppSetsLabel
            // 
            this.AppSetsLabel.AutoSize = true;
            this.AppSetsLabel.Location = new System.Drawing.Point(47, 203);
            this.AppSetsLabel.Name = "AppSetsLabel";
            this.AppSetsLabel.Size = new System.Drawing.Size(68, 13);
            this.AppSetsLabel.TabIndex = 12;
            this.AppSetsLabel.Text = "اسم التطبيق";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(298, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "إضافة";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(374, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(146, 19);
            this.textBox1.TabIndex = 8;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Tahoma", 15F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.ItemHeight = 24;
            this.comboBox1.Location = new System.Drawing.Point(47, 122);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(360, 32);
            this.comboBox1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "اختر المادة لربطها مع الإسم عبر الباركود";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(135, 93);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(184, 23);
            this.textBox2.TabIndex = 11;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(289, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "بحث";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(92, 93);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(37, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(109, 160);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(210, 37);
            this.button3.TabIndex = 14;
            this.button3.Text = "ربط الباركود مع العنصر المحدد";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(498, 292);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(535, 254);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(297, 225);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(136, 23);
            this.button7.TabIndex = 16;
            this.button7.Text = "استعادة نسخ احتياطية";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(439, 225);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(90, 23);
            this.button6.TabIndex = 15;
            this.button6.Text = "نسخ إحتياطي";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // AppsSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 599);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.addAppsGroup);
            this.Controls.Add(this.dvApps);
            this.Controls.Add(this.cancelSave);
            this.MinimizeBox = false;
            this.Name = "AppsSetting";
            this.ShowIcon = false;
            this.Text = "إعدادات التطبيقات";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AppsSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvApps)).EndInit();
            this.addAppsGroup.ResumeLayout(false);
            this.addAppsGroup.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cancelSave;
        private System.Windows.Forms.DataGridView dvApps;
        private System.Windows.Forms.Button LoadList;
        private System.Windows.Forms.ListBox lb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SaveAppsNames;
        private System.Windows.Forms.GroupBox addAppsGroup;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label AppSetsLabel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
    }
}