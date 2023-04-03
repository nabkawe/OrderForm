namespace OrderForm
{
    partial class CalLog
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddNumberToForm = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.AddSingleItem = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.phoneLogLB = new System.Windows.Forms.ListBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AddNumberToForm);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.phoneLogLB);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(704, 490);
            this.panel1.TabIndex = 40;
            // 
            // AddNumberToForm
            // 
            this.AddNumberToForm.BackColor = System.Drawing.Color.BlueViolet;
            this.AddNumberToForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AddNumberToForm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AddNumberToForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddNumberToForm.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNumberToForm.ForeColor = System.Drawing.Color.White;
            this.AddNumberToForm.Location = new System.Drawing.Point(5, 380);
            this.AddNumberToForm.Margin = new System.Windows.Forms.Padding(0);
            this.AddNumberToForm.Name = "AddNumberToForm";
            this.AddNumberToForm.Size = new System.Drawing.Size(694, 49);
            this.AddNumberToForm.TabIndex = 11;
            this.AddNumberToForm.Text = "إستخدام الرقم المحدد";
            this.AddNumberToForm.UseVisualStyleBackColor = false;
            this.AddNumberToForm.Click += new System.EventHandler(this.AddNumberToForm_Click);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Enabled = false;
            this.panel3.Location = new System.Drawing.Point(5, 429);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(694, 10);
            this.panel3.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.AddSingleItem);
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(5, 439);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.panel2.Size = new System.Drawing.Size(694, 46);
            this.panel2.TabIndex = 12;
            // 
            // AddSingleItem
            // 
            this.AddSingleItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddSingleItem.BackColor = System.Drawing.Color.White;
            this.AddSingleItem.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AddSingleItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddSingleItem.Location = new System.Drawing.Point(306, 0);
            this.AddSingleItem.Margin = new System.Windows.Forms.Padding(10);
            this.AddSingleItem.Name = "AddSingleItem";
            this.AddSingleItem.Size = new System.Drawing.Size(388, 46);
            this.AddSingleItem.TabIndex = 13;
            this.AddSingleItem.Text = "عرض المزيد";
            this.AddSingleItem.UseVisualStyleBackColor = false;
            this.AddSingleItem.Click += new System.EventHandler(this.LoadLastNo_Click_1);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown1.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(0, 0);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.numericUpDown1.Size = new System.Drawing.Size(278, 46);
            this.numericUpDown1.TabIndex = 14;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // phoneLogLB
            // 
            this.phoneLogLB.ColumnWidth = 100;
            this.phoneLogLB.Dock = System.Windows.Forms.DockStyle.Top;
            this.phoneLogLB.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneLogLB.FormattingEnabled = true;
            this.phoneLogLB.ItemHeight = 33;
            this.phoneLogLB.Location = new System.Drawing.Point(5, 5);
            this.phoneLogLB.Name = "phoneLogLB";
            this.phoneLogLB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.phoneLogLB.Size = new System.Drawing.Size(694, 367);
            this.phoneLogLB.TabIndex = 9;
            this.phoneLogLB.DoubleClick += new System.EventHandler(this.phoneLogLB_DoubleClick);
            // 
            // CalLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 500);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalLog";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Phone Log سجل الإتصالات";
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.CalLog_Deactivate);
            this.Load += new System.EventHandler(this.CalLog_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox phoneLogLB;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button AddNumberToForm;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button AddSingleItem;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Panel panel3;
    }
}