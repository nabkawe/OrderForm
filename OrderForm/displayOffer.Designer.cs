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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dvItems2 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.unfocusableButton2 = new OrderForm.UnfocusableButton();
            this.Price = new OrderForm.UnfocusableButton();
            this.unfocusableButton3 = new OrderForm.UnfocusableButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ClientDate = new OrderForm.UnfocusableButton();
            this.DateTitle = new OrderForm.UnfocusableButton();
            this.ClientPhone = new OrderForm.UnfocusableButton();
            this.PhoneTitle = new OrderForm.UnfocusableButton();
            this.ClientName = new OrderForm.UnfocusableButton();
            this.ClientTitle = new OrderForm.UnfocusableButton();
            this.unfocusableButton4 = new OrderForm.UnfocusableButton();
            ((System.ComponentModel.ISupportInitialize)(this.dvItems2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.dvItems2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dvItems2.CausesValidation = false;
            this.dvItems2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dvItems2.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dvItems2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dvItems2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dvItems2.ColumnHeadersHeight = 30;
            this.dvItems2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dvItems2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvItems2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dvItems2.EnableHeadersVisualStyles = false;
            this.dvItems2.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dvItems2.Location = new System.Drawing.Point(0, 93);
            this.dvItems2.Margin = new System.Windows.Forms.Padding(0);
            this.dvItems2.MultiSelect = false;
            this.dvItems2.Name = "dvItems2";
            this.dvItems2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvItems2.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dvItems2.RowHeadersVisible = false;
            this.dvItems2.RowHeadersWidth = 10;
            this.dvItems2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.NullValue = null;
            this.dvItems2.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dvItems2.RowTemplate.Height = 30;
            this.dvItems2.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dvItems2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dvItems2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvItems2.ShowCellErrors = false;
            this.dvItems2.ShowCellToolTips = false;
            this.dvItems2.ShowEditingIcon = false;
            this.dvItems2.ShowRowErrors = false;
            this.dvItems2.Size = new System.Drawing.Size(1004, 926);
            this.dvItems2.TabIndex = 31;
            this.dvItems2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.unfocusableButton2);
            this.panel1.Controls.Add(this.Price);
            this.panel1.Controls.Add(this.unfocusableButton3);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 899);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 120);
            this.panel1.TabIndex = 37;
            // 
            // unfocusableButton2
            // 
            this.unfocusableButton2.BackColor = System.Drawing.Color.White;
            this.unfocusableButton2.Dock = System.Windows.Forms.DockStyle.Right;
            this.unfocusableButton2.FlatAppearance.BorderSize = 0;
            this.unfocusableButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unfocusableButton2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unfocusableButton2.Location = new System.Drawing.Point(1, 0);
            this.unfocusableButton2.Name = "unfocusableButton2";
            this.unfocusableButton2.Size = new System.Drawing.Size(84, 120);
            this.unfocusableButton2.TabIndex = 43;
            this.unfocusableButton2.Text = "ريال\r\nسعودي\r\n\r\nSaudi\r\n Riyal\r\n";
            this.unfocusableButton2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.unfocusableButton2.UseVisualStyleBackColor = false;
            // 
            // Price
            // 
            this.Price.BackColor = System.Drawing.Color.White;
            this.Price.Dock = System.Windows.Forms.DockStyle.Right;
            this.Price.FlatAppearance.BorderSize = 0;
            this.Price.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Price.Font = new System.Drawing.Font("Tahoma", 46F);
            this.Price.ForeColor = System.Drawing.Color.Black;
            this.Price.Location = new System.Drawing.Point(85, 0);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(334, 120);
            this.Price.TabIndex = 42;
            this.Price.Text = "0.00";
            this.Price.UseVisualStyleBackColor = false;
            // 
            // unfocusableButton3
            // 
            this.unfocusableButton3.BackColor = System.Drawing.Color.White;
            this.unfocusableButton3.Dock = System.Windows.Forms.DockStyle.Right;
            this.unfocusableButton3.FlatAppearance.BorderSize = 0;
            this.unfocusableButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unfocusableButton3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unfocusableButton3.Location = new System.Drawing.Point(419, 0);
            this.unfocusableButton3.Name = "unfocusableButton3";
            this.unfocusableButton3.Size = new System.Drawing.Size(134, 120);
            this.unfocusableButton3.TabIndex = 44;
            this.unfocusableButton3.Text = "المبلغ الإجمالي\r\n\r\n\r\nTotal Amount";
            this.unfocusableButton3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.unfocusableButton3.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = global::OrderForm.Properties.Resources.Mada;
            this.pictureBox1.Location = new System.Drawing.Point(553, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(451, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ClientDate);
            this.panel2.Controls.Add(this.DateTitle);
            this.panel2.Controls.Add(this.ClientPhone);
            this.panel2.Controls.Add(this.PhoneTitle);
            this.panel2.Controls.Add(this.ClientName);
            this.panel2.Controls.Add(this.ClientTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 828);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1004, 71);
            this.panel2.TabIndex = 38;
            // 
            // ClientDate
            // 
            this.ClientDate.BackColor = System.Drawing.Color.White;
            this.ClientDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.ClientDate.FlatAppearance.BorderSize = 0;
            this.ClientDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClientDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientDate.Location = new System.Drawing.Point(-51, 0);
            this.ClientDate.Name = "ClientDate";
            this.ClientDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ClientDate.Size = new System.Drawing.Size(333, 71);
            this.ClientDate.TabIndex = 56;
            this.ClientDate.UseVisualStyleBackColor = false;
            // 
            // DateTitle
            // 
            this.DateTitle.BackColor = System.Drawing.Color.White;
            this.DateTitle.Dock = System.Windows.Forms.DockStyle.Right;
            this.DateTitle.FlatAppearance.BorderSize = 0;
            this.DateTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DateTitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTitle.Location = new System.Drawing.Point(282, 0);
            this.DateTitle.Name = "DateTitle";
            this.DateTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DateTitle.Size = new System.Drawing.Size(134, 71);
            this.DateTitle.TabIndex = 55;
            this.DateTitle.Text = "موعد التنفيذ";
            this.DateTitle.UseVisualStyleBackColor = false;
            // 
            // ClientPhone
            // 
            this.ClientPhone.BackColor = System.Drawing.Color.White;
            this.ClientPhone.Dock = System.Windows.Forms.DockStyle.Right;
            this.ClientPhone.FlatAppearance.BorderSize = 0;
            this.ClientPhone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClientPhone.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientPhone.Location = new System.Drawing.Point(416, 0);
            this.ClientPhone.Name = "ClientPhone";
            this.ClientPhone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ClientPhone.Size = new System.Drawing.Size(134, 71);
            this.ClientPhone.TabIndex = 54;
            this.ClientPhone.UseVisualStyleBackColor = false;
            // 
            // PhoneTitle
            // 
            this.PhoneTitle.BackColor = System.Drawing.Color.White;
            this.PhoneTitle.Dock = System.Windows.Forms.DockStyle.Right;
            this.PhoneTitle.FlatAppearance.BorderSize = 0;
            this.PhoneTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PhoneTitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneTitle.Location = new System.Drawing.Point(550, 0);
            this.PhoneTitle.Name = "PhoneTitle";
            this.PhoneTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PhoneTitle.Size = new System.Drawing.Size(134, 71);
            this.PhoneTitle.TabIndex = 53;
            this.PhoneTitle.Text = "رقم الهاتف:";
            this.PhoneTitle.UseVisualStyleBackColor = false;
            // 
            // ClientName
            // 
            this.ClientName.BackColor = System.Drawing.Color.White;
            this.ClientName.Dock = System.Windows.Forms.DockStyle.Right;
            this.ClientName.FlatAppearance.BorderSize = 0;
            this.ClientName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClientName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientName.Location = new System.Drawing.Point(684, 0);
            this.ClientName.Name = "ClientName";
            this.ClientName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ClientName.Size = new System.Drawing.Size(186, 71);
            this.ClientName.TabIndex = 52;
            this.ClientName.UseVisualStyleBackColor = false;
            // 
            // ClientTitle
            // 
            this.ClientTitle.BackColor = System.Drawing.Color.White;
            this.ClientTitle.Dock = System.Windows.Forms.DockStyle.Right;
            this.ClientTitle.FlatAppearance.BorderSize = 0;
            this.ClientTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClientTitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientTitle.Location = new System.Drawing.Point(870, 0);
            this.ClientTitle.Name = "ClientTitle";
            this.ClientTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ClientTitle.Size = new System.Drawing.Size(134, 71);
            this.ClientTitle.TabIndex = 51;
            this.ClientTitle.Text = "إسم العميل:";
            this.ClientTitle.UseVisualStyleBackColor = false;
            // 
            // unfocusableButton4
            // 
            this.unfocusableButton4.BackColor = System.Drawing.Color.White;
            this.unfocusableButton4.BackgroundImage = global::OrderForm.Properties.Resources.logo;
            this.unfocusableButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.unfocusableButton4.CausesValidation = false;
            this.unfocusableButton4.Dock = System.Windows.Forms.DockStyle.Top;
            this.unfocusableButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unfocusableButton4.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unfocusableButton4.ForeColor = System.Drawing.Color.Black;
            this.unfocusableButton4.Location = new System.Drawing.Point(0, 0);
            this.unfocusableButton4.Margin = new System.Windows.Forms.Padding(1);
            this.unfocusableButton4.Name = "unfocusableButton4";
            this.unfocusableButton4.Size = new System.Drawing.Size(1004, 93);
            this.unfocusableButton4.TabIndex = 36;
            this.unfocusableButton4.Text = "Review your order:                          :مـلـخـص الطـلـب";
            this.unfocusableButton4.UseVisualStyleBackColor = false;
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
            this.Controls.Add(this.unfocusableButton4);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView dvItems2;
        private UnfocusableButton unfocusableButton4;
        private System.Windows.Forms.Panel panel1;
        private UnfocusableButton unfocusableButton2;
        private UnfocusableButton unfocusableButton3;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel2;
        private UnfocusableButton ClientDate;
        private UnfocusableButton DateTitle;
        private UnfocusableButton ClientPhone;
        private UnfocusableButton PhoneTitle;
        private UnfocusableButton ClientName;
        private UnfocusableButton ClientTitle;
        public UnfocusableButton Price;
    }
}