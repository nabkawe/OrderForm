namespace OrderForm
{
    partial class MyMatReport
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
            this.StartDate = new System.Windows.Forms.DateTimePicker();
            this.EndDate = new System.Windows.Forms.DateTimePicker();
            this.dvReport = new System.Windows.Forms.DataGridView();
            this.totalSales = new System.Windows.Forms.TextBox();
            this.FindAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.OrderDirection = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.toGo = new System.Windows.Forms.RadioButton();
            this.All = new System.Windows.Forms.RadioButton();
            this.Phone = new System.Windows.Forms.RadioButton();
            this.Jahez = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.eatIn = new System.Windows.Forms.RadioButton();
            this.PaymentMethods = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.MatTotalSales = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dvReport)).BeginInit();
            this.panel1.SuspendLayout();
            this.PaymentMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartDate
            // 
            this.StartDate.CustomFormat = "dddd d/MM/yyyy  -  hh:mm:sstt";
            this.StartDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StartDate.Location = new System.Drawing.Point(462, 19);
            this.StartDate.Name = "StartDate";
            this.StartDate.Size = new System.Drawing.Size(274, 23);
            this.StartDate.TabIndex = 0;
            this.StartDate.Value = new System.DateTime(2023, 1, 8, 14, 0, 0, 0);
            // 
            // EndDate
            // 
            this.EndDate.CustomFormat = "dddd d/MM/yyyy  -  hh:mm:sstt";
            this.EndDate.Font = new System.Drawing.Font("Tahoma", 9F);
            this.EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EndDate.Location = new System.Drawing.Point(462, 52);
            this.EndDate.Name = "EndDate";
            this.EndDate.Size = new System.Drawing.Size(274, 22);
            this.EndDate.TabIndex = 1;
            // 
            // dvReport
            // 
            this.dvReport.AllowUserToAddRows = false;
            this.dvReport.AllowUserToDeleteRows = false;
            this.dvReport.AllowUserToOrderColumns = true;
            this.dvReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dvReport.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dvReport.BackgroundColor = System.Drawing.Color.White;
            this.dvReport.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvReport.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dvReport.Location = new System.Drawing.Point(0, 93);
            this.dvReport.Name = "dvReport";
            this.dvReport.ReadOnly = true;
            this.dvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvReport.Size = new System.Drawing.Size(800, 422);
            this.dvReport.TabIndex = 2;
            // 
            // totalSales
            // 
            this.totalSales.Dock = System.Windows.Forms.DockStyle.Left;
            this.totalSales.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalSales.Location = new System.Drawing.Point(0, 0);
            this.totalSales.Name = "totalSales";
            this.totalSales.ReadOnly = true;
            this.totalSales.Size = new System.Drawing.Size(131, 30);
            this.totalSales.TabIndex = 3;
            this.totalSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FindAll
            // 
            this.FindAll.Location = new System.Drawing.Point(658, 19);
            this.FindAll.Name = "FindAll";
            this.FindAll.Size = new System.Drawing.Size(110, 23);
            this.FindAll.TabIndex = 4;
            this.FindAll.Text = "بحث بين الفترتين";
            this.FindAll.UseVisualStyleBackColor = true;
            this.FindAll.Click += new System.EventHandler(this.FindAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(740, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "بداية";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(740, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "نهاية";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.OrderDirection);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.toGo);
            this.panel1.Controls.Add(this.All);
            this.panel1.Controls.Add(this.Phone);
            this.panel1.Controls.Add(this.Jahez);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.eatIn);
            this.panel1.Controls.Add(this.EndDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.StartDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 87);
            this.panel1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(375, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "البحث عن المادة";
            // 
            // OrderDirection
            // 
            this.OrderDirection.AutoSize = true;
            this.OrderDirection.Location = new System.Drawing.Point(12, 36);
            this.OrderDirection.Name = "OrderDirection";
            this.OrderDirection.Size = new System.Drawing.Size(54, 17);
            this.OrderDirection.TabIndex = 18;
            this.OrderDirection.Text = "تنازلي";
            this.OrderDirection.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(335, 54);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 20;
            // 
            // toGo
            // 
            this.toGo.AutoSize = true;
            this.toGo.Location = new System.Drawing.Point(208, 42);
            this.toGo.Name = "toGo";
            this.toGo.Size = new System.Drawing.Size(57, 17);
            this.toGo.TabIndex = 16;
            this.toGo.Text = "سفري";
            this.toGo.UseVisualStyleBackColor = true;
            // 
            // All
            // 
            this.All.AutoSize = true;
            this.All.Checked = true;
            this.All.Location = new System.Drawing.Point(144, 19);
            this.All.Name = "All";
            this.All.Size = new System.Drawing.Size(116, 17);
            this.All.TabIndex = 17;
            this.All.TabStop = true;
            this.All.Text = "كل الطلبات مع جاهز";
            this.All.UseVisualStyleBackColor = true;
            // 
            // Phone
            // 
            this.Phone.AutoSize = true;
            this.Phone.Location = new System.Drawing.Point(277, 42);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(49, 17);
            this.Phone.TabIndex = 15;
            this.Phone.Text = "هاتف";
            this.Phone.UseVisualStyleBackColor = true;
            // 
            // Jahez
            // 
            this.Jahez.AutoSize = true;
            this.Jahez.Location = new System.Drawing.Point(275, 19);
            this.Jahez.Name = "Jahez";
            this.Jahez.Size = new System.Drawing.Size(53, 17);
            this.Jahez.TabIndex = 14;
            this.Jahez.Text = "Jahez";
            this.Jahez.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "ترتيب حسب السعر";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ByPriceDescending);
            // 
            // eatIn
            // 
            this.eatIn.AutoSize = true;
            this.eatIn.Location = new System.Drawing.Point(144, 42);
            this.eatIn.Name = "eatIn";
            this.eatIn.Size = new System.Drawing.Size(53, 17);
            this.eatIn.TabIndex = 13;
            this.eatIn.Text = "محلي";
            this.eatIn.UseVisualStyleBackColor = true;
            // 
            // PaymentMethods
            // 
            this.PaymentMethods.Controls.Add(this.label5);
            this.PaymentMethods.Controls.Add(this.MatTotalSales);
            this.PaymentMethods.Controls.Add(this.label3);
            this.PaymentMethods.Controls.Add(this.totalSales);
            this.PaymentMethods.Controls.Add(this.FindAll);
            this.PaymentMethods.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PaymentMethods.Location = new System.Drawing.Point(0, 521);
            this.PaymentMethods.Name = "PaymentMethods";
            this.PaymentMethods.Size = new System.Drawing.Size(800, 54);
            this.PaymentMethods.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(171, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "سعر المادة";
            // 
            // MatTotalSales
            // 
            this.MatTotalSales.Dock = System.Windows.Forms.DockStyle.Left;
            this.MatTotalSales.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MatTotalSales.Location = new System.Drawing.Point(131, 0);
            this.MatTotalSales.Name = "MatTotalSales";
            this.MatTotalSales.ReadOnly = true;
            this.MatTotalSales.Size = new System.Drawing.Size(131, 30);
            this.MatTotalSales.TabIndex = 21;
            this.MatTotalSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "عدد المادة";
            // 
            // MyMatReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 575);
            this.Controls.Add(this.PaymentMethods);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dvReport);
            this.Name = "MyMatReport";
            this.Text = "MyReport";
            ((System.ComponentModel.ISupportInitialize)(this.dvReport)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PaymentMethods.ResumeLayout(false);
            this.PaymentMethods.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker StartDate;
        private System.Windows.Forms.DateTimePicker EndDate;
        public System.Windows.Forms.DataGridView dvReport;
        private System.Windows.Forms.TextBox totalSales;
        private System.Windows.Forms.Button FindAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton eatIn;
        private System.Windows.Forms.RadioButton Jahez;
        private System.Windows.Forms.RadioButton Phone;
        private System.Windows.Forms.RadioButton toGo;
        private System.Windows.Forms.RadioButton All;
        private System.Windows.Forms.CheckBox OrderDirection;
        private System.Windows.Forms.Panel PaymentMethods;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox MatTotalSales;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}