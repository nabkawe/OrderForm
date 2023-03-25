namespace OrderForm
{
    partial class displayOffer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dvItems2 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ItemCount = new OrderForm.UnfocusableButton();
            this.unfocusableButton2 = new OrderForm.UnfocusableButton();
            this.Price = new OrderForm.UnfocusableButton();
            this.unfocusableButton3 = new OrderForm.UnfocusableButton();
            this.Payment = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ClientName = new OrderForm.UnfocusableButton();
            this.ClientTitle = new OrderForm.UnfocusableButton();
            this.PhoneTitle = new OrderForm.UnfocusableButton();
            this.ClientPhone = new OrderForm.UnfocusableButton();
            this.DateTitle = new OrderForm.UnfocusableButton();
            this.ClientDate = new OrderForm.UnfocusableButton();
            this.LogoPic = new OrderForm.UnfocusableButton();
            ((System.ComponentModel.ISupportInitialize)(this.dvItems2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Payment)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.T_Tick);
            // 
            // dvItems2
            // 
            this.dvItems2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dvItems2.AllowUserToAddRows = false;
            this.dvItems2.AllowUserToDeleteRows = false;
            this.dvItems2.AllowUserToResizeColumns = false;
            this.dvItems2.AllowUserToResizeRows = false;
            this.dvItems2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dvItems2.BackgroundColor = System.Drawing.Color.White;
            this.dvItems2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dvItems2.CausesValidation = false;
            this.dvItems2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dvItems2.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dvItems2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dvItems2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dvItems2.ColumnHeadersHeight = 30;
            this.dvItems2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dvItems2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dvItems2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dvItems2.EnableHeadersVisualStyles = false;
            this.dvItems2.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dvItems2.Location = new System.Drawing.Point(0, 299);
            this.dvItems2.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.dvItems2.MultiSelect = false;
            this.dvItems2.Name = "dvItems2";
            this.dvItems2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvItems2.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dvItems2.RowHeadersVisible = false;
            this.dvItems2.RowHeadersWidth = 10;
            this.dvItems2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.NullValue = null;
            this.dvItems2.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dvItems2.RowTemplate.Height = 30;
            this.dvItems2.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dvItems2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dvItems2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvItems2.ShowCellErrors = false;
            this.dvItems2.ShowCellToolTips = false;
            this.dvItems2.ShowEditingIcon = false;
            this.dvItems2.ShowRowErrors = false;
            this.dvItems2.Size = new System.Drawing.Size(1004, 559);
            this.dvItems2.TabIndex = 31;
            this.dvItems2.TabStop = false;
            this.dvItems2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvItems2_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ItemCount);
            this.panel1.Controls.Add(this.unfocusableButton2);
            this.panel1.Controls.Add(this.Price);
            this.panel1.Controls.Add(this.unfocusableButton3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 858);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 177);
            this.panel1.TabIndex = 37;
            // 
            // ItemCount
            // 
            this.ItemCount.BackColor = System.Drawing.Color.White;
            this.ItemCount.Dock = System.Windows.Forms.DockStyle.Right;
            this.ItemCount.FlatAppearance.BorderSize = 0;
            this.ItemCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ItemCount.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemCount.Location = new System.Drawing.Point(-57, 0);
            this.ItemCount.Name = "ItemCount";
            this.ItemCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ItemCount.Size = new System.Drawing.Size(223, 177);
            this.ItemCount.TabIndex = 45;
            this.ItemCount.UseVisualStyleBackColor = false;
            // 
            // unfocusableButton2
            // 
            this.unfocusableButton2.BackColor = System.Drawing.Color.White;
            this.unfocusableButton2.Dock = System.Windows.Forms.DockStyle.Right;
            this.unfocusableButton2.FlatAppearance.BorderSize = 0;
            this.unfocusableButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unfocusableButton2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.unfocusableButton2.Location = new System.Drawing.Point(166, 0);
            this.unfocusableButton2.Name = "unfocusableButton2";
            this.unfocusableButton2.Size = new System.Drawing.Size(142, 177);
            this.unfocusableButton2.TabIndex = 43;
            this.unfocusableButton2.Text = "ريال سعودي\r\n\r\nSaudi Riyal\r\n";
            this.unfocusableButton2.UseVisualStyleBackColor = false;
            // 
            // Price
            // 
            this.Price.BackColor = System.Drawing.Color.White;
            this.Price.Dock = System.Windows.Forms.DockStyle.Right;
            this.Price.FlatAppearance.BorderSize = 0;
            this.Price.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Price.Font = new System.Drawing.Font("Segoe UI", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Price.ForeColor = System.Drawing.Color.Red;
            this.Price.Location = new System.Drawing.Point(308, 0);
            this.Price.Margin = new System.Windows.Forms.Padding(0);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(471, 177);
            this.Price.TabIndex = 42;
            this.Price.Text = "0.00";
            this.Price.UseVisualStyleBackColor = true;
            // 
            // unfocusableButton3
            // 
            this.unfocusableButton3.BackColor = System.Drawing.Color.White;
            this.unfocusableButton3.Dock = System.Windows.Forms.DockStyle.Right;
            this.unfocusableButton3.FlatAppearance.BorderSize = 0;
            this.unfocusableButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unfocusableButton3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unfocusableButton3.Location = new System.Drawing.Point(779, 0);
            this.unfocusableButton3.Name = "unfocusableButton3";
            this.unfocusableButton3.Size = new System.Drawing.Size(225, 177);
            this.unfocusableButton3.TabIndex = 44;
            this.unfocusableButton3.Text = "المبلغ الإجمالي\r\n\r\nTotal Amount";
            this.unfocusableButton3.UseVisualStyleBackColor = false;
            // 
            // Payment
            // 
            this.Payment.BackColor = System.Drawing.Color.White;
            this.Payment.Dock = System.Windows.Forms.DockStyle.Top;
            this.Payment.Image = global::OrderForm.Properties.Resources.Mada;
            this.Payment.Location = new System.Drawing.Point(0, 125);
            this.Payment.Margin = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.Payment.Name = "Payment";
            this.Payment.Size = new System.Drawing.Size(1004, 174);
            this.Payment.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Payment.TabIndex = 41;
            this.Payment.TabStop = false;
            this.Payment.Click += new System.EventHandler(this.Payment_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.GhostWhite;
            this.panel2.Controls.Add(this.ClientName);
            this.panel2.Controls.Add(this.ClientTitle);
            this.panel2.Controls.Add(this.PhoneTitle);
            this.panel2.Controls.Add(this.ClientPhone);
            this.panel2.Controls.Add(this.DateTitle);
            this.panel2.Controls.Add(this.ClientDate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 1035);
            this.panel2.Margin = new System.Windows.Forms.Padding(1);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(1004, 71);
            this.panel2.TabIndex = 38;
            // 
            // ClientName
            // 
            this.ClientName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientName.BackColor = System.Drawing.Color.White;
            this.ClientName.Dock = System.Windows.Forms.DockStyle.Right;
            this.ClientName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClientName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientName.Location = new System.Drawing.Point(711, 5);
            this.ClientName.Name = "ClientName";
            this.ClientName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ClientName.Size = new System.Drawing.Size(191, 61);
            this.ClientName.TabIndex = 52;
            this.ClientName.UseVisualStyleBackColor = false;
            // 
            // ClientTitle
            // 
            this.ClientTitle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientTitle.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientTitle.Dock = System.Windows.Forms.DockStyle.Right;
            this.ClientTitle.FlatAppearance.BorderSize = 0;
            this.ClientTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClientTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientTitle.Location = new System.Drawing.Point(902, 5);
            this.ClientTitle.Name = "ClientTitle";
            this.ClientTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ClientTitle.Size = new System.Drawing.Size(97, 61);
            this.ClientTitle.TabIndex = 51;
            this.ClientTitle.Text = "إسم العميل:";
            this.ClientTitle.UseVisualStyleBackColor = false;
            // 
            // PhoneTitle
            // 
            this.PhoneTitle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PhoneTitle.BackColor = System.Drawing.Color.GhostWhite;
            this.PhoneTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.PhoneTitle.FlatAppearance.BorderSize = 0;
            this.PhoneTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PhoneTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneTitle.Location = new System.Drawing.Point(508, 5);
            this.PhoneTitle.Name = "PhoneTitle";
            this.PhoneTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PhoneTitle.Size = new System.Drawing.Size(95, 61);
            this.PhoneTitle.TabIndex = 53;
            this.PhoneTitle.Text = "رقم الهاتف:";
            this.PhoneTitle.UseVisualStyleBackColor = false;
            // 
            // ClientPhone
            // 
            this.ClientPhone.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientPhone.BackColor = System.Drawing.Color.White;
            this.ClientPhone.Dock = System.Windows.Forms.DockStyle.Left;
            this.ClientPhone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClientPhone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientPhone.Location = new System.Drawing.Point(317, 5);
            this.ClientPhone.Name = "ClientPhone";
            this.ClientPhone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ClientPhone.Size = new System.Drawing.Size(191, 61);
            this.ClientPhone.TabIndex = 54;
            this.ClientPhone.UseVisualStyleBackColor = false;
            // 
            // DateTitle
            // 
            this.DateTitle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DateTitle.BackColor = System.Drawing.Color.GhostWhite;
            this.DateTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.DateTitle.FlatAppearance.BorderSize = 0;
            this.DateTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DateTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTitle.Location = new System.Drawing.Point(216, 5);
            this.DateTitle.Name = "DateTitle";
            this.DateTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DateTitle.Size = new System.Drawing.Size(101, 61);
            this.DateTitle.TabIndex = 55;
            this.DateTitle.Text = "موعد التنفيذ:";
            this.DateTitle.UseVisualStyleBackColor = false;
            // 
            // ClientDate
            // 
            this.ClientDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientDate.BackColor = System.Drawing.Color.White;
            this.ClientDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.ClientDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClientDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientDate.Location = new System.Drawing.Point(5, 5);
            this.ClientDate.Margin = new System.Windows.Forms.Padding(0);
            this.ClientDate.Name = "ClientDate";
            this.ClientDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ClientDate.Size = new System.Drawing.Size(211, 61);
            this.ClientDate.TabIndex = 56;
            this.ClientDate.UseVisualStyleBackColor = false;
            // 
            // LogoPic
            // 
            this.LogoPic.BackColor = System.Drawing.Color.White;
            this.LogoPic.BackgroundImage = global::OrderForm.Properties.Resources.logo;
            this.LogoPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.LogoPic.CausesValidation = false;
            this.LogoPic.Dock = System.Windows.Forms.DockStyle.Top;
            this.LogoPic.FlatAppearance.BorderSize = 0;
            this.LogoPic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogoPic.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogoPic.ForeColor = System.Drawing.Color.Black;
            this.LogoPic.Location = new System.Drawing.Point(0, 0);
            this.LogoPic.Margin = new System.Windows.Forms.Padding(1);
            this.LogoPic.Name = "LogoPic";
            this.LogoPic.Size = new System.Drawing.Size(1004, 125);
            this.LogoPic.TabIndex = 36;
            this.LogoPic.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LogoPic.UseVisualStyleBackColor = false;
            // 
            // displayOffer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1004, 1019);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dvItems2);
            this.Controls.Add(this.Payment);
            this.Controls.Add(this.LogoPic);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "displayOffer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "مراجعة الفاتورة";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.displayOffer_FormClosed);
            this.Load += new System.EventHandler(this.displayOffer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvItems2)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Payment)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView dvItems2;
        private System.Windows.Forms.Panel panel1;
        private UnfocusableButton unfocusableButton2;
        private UnfocusableButton unfocusableButton3;
        private System.Windows.Forms.PictureBox Payment;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel2;
        private UnfocusableButton ClientDate;
        private UnfocusableButton DateTitle;
        private UnfocusableButton ClientPhone;
        private UnfocusableButton PhoneTitle;
        private UnfocusableButton ClientName;
        private UnfocusableButton ClientTitle;
        private UnfocusableButton Price;
        private UnfocusableButton ItemCount;
        private UnfocusableButton LogoPic;
    }
}