namespace OrderForm
{
    partial class Headers
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
            this.Save = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AddHeader = new System.Windows.Forms.Button();
            this.MenuTitle = new System.Windows.Forms.Label();
            this.headerLocation = new System.Windows.Forms.NumericUpDown();
            this.headerHeight = new System.Windows.Forms.NumericUpDown();
            this.Fonts = new System.Windows.Forms.Button();
            this.BackColor = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.titleBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.MoveDown = new System.Windows.Forms.Button();
            this.MoveUp = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerHeight)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(8, 418);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 0;
            this.Save.Text = "حفظ";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(89, 418);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "إلغاء الأمر";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AddHeader);
            this.groupBox1.Controls.Add(this.MenuTitle);
            this.groupBox1.Controls.Add(this.headerLocation);
            this.groupBox1.Controls.Add(this.headerHeight);
            this.groupBox1.Controls.Add(this.Fonts);
            this.groupBox1.Controls.Add(this.BackColor);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.titleBox);
            this.groupBox1.Location = new System.Drawing.Point(403, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 394);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "إضافة أو تعديل";
            // 
            // AddHeader
            // 
            this.AddHeader.Location = new System.Drawing.Point(6, 365);
            this.AddHeader.Name = "AddHeader";
            this.AddHeader.Size = new System.Drawing.Size(157, 23);
            this.AddHeader.TabIndex = 33;
            this.AddHeader.Text = "إضافة/تعديل";
            this.AddHeader.UseVisualStyleBackColor = true;
            this.AddHeader.Click += new System.EventHandler(this.AddHeader_Click);
            // 
            // MenuTitle
            // 
            this.MenuTitle.AutoSize = true;
            this.MenuTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.MenuTitle.Location = new System.Drawing.Point(3, 16);
            this.MenuTitle.Name = "MenuTitle";
            this.MenuTitle.Size = new System.Drawing.Size(53, 21);
            this.MenuTitle.TabIndex = 32;
            this.MenuTitle.Text = "القائمة";
            // 
            // headerLocation
            // 
            this.headerLocation.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.headerLocation.Location = new System.Drawing.Point(165, 183);
            this.headerLocation.Maximum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.headerLocation.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.headerLocation.Name = "headerLocation";
            this.headerLocation.Size = new System.Drawing.Size(86, 29);
            this.headerLocation.TabIndex = 30;
            this.headerLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.headerLocation.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // headerHeight
            // 
            this.headerHeight.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.headerHeight.Location = new System.Drawing.Point(165, 148);
            this.headerHeight.Maximum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.headerHeight.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.headerHeight.Name = "headerHeight";
            this.headerHeight.Size = new System.Drawing.Size(86, 29);
            this.headerHeight.TabIndex = 29;
            this.headerHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.headerHeight.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // Fonts
            // 
            this.Fonts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.Fonts.Location = new System.Drawing.Point(18, 253);
            this.Fonts.Name = "Fonts";
            this.Fonts.Size = new System.Drawing.Size(233, 29);
            this.Fonts.TabIndex = 28;
            this.Fonts.Text = "نوع الخط، حجم الخط ولون الخط";
            this.Fonts.UseVisualStyleBackColor = true;
            this.Fonts.Click += new System.EventHandler(this.Fonts_Click);
            // 
            // BackColor
            // 
            this.BackColor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.BackColor.Location = new System.Drawing.Point(18, 218);
            this.BackColor.Name = "BackColor";
            this.BackColor.Size = new System.Drawing.Size(233, 29);
            this.BackColor.TabIndex = 26;
            this.BackColor.Text = "لون الخلفية";
            this.BackColor.UseVisualStyleBackColor = true;
            this.BackColor.Click += new System.EventHandler(this.BackColor_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(260, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 21);
            this.label6.TabIndex = 25;
            this.label6.Text = "مكان العنوان:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(257, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 21);
            this.label7.TabIndex = 24;
            this.label7.Text = "ارتفاع العنوان:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(258, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 21);
            this.label1.TabIndex = 23;
            this.label1.Text = "العـــــنـــــوان  :";
            // 
            // titleBox
            // 
            this.titleBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.titleBox.Location = new System.Drawing.Point(18, 113);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(233, 29);
            this.titleBox.TabIndex = 22;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(8, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(375, 394);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "العناوين";
            // 
            // MoveDown
            // 
            this.MoveDown.Location = new System.Drawing.Point(14, 5);
            this.MoveDown.Name = "MoveDown";
            this.MoveDown.Size = new System.Drawing.Size(52, 23);
            this.MoveDown.TabIndex = 5;
            this.MoveDown.Text = "تحت";
            this.MoveDown.UseVisualStyleBackColor = true;
            this.MoveDown.Click += new System.EventHandler(this.MoveDown_Click);
            // 
            // MoveUp
            // 
            this.MoveUp.Location = new System.Drawing.Point(72, 5);
            this.MoveUp.Name = "MoveUp";
            this.MoveUp.Size = new System.Drawing.Size(52, 23);
            this.MoveUp.TabIndex = 6;
            this.MoveUp.Text = "فوق";
            this.MoveUp.UseVisualStyleBackColor = true;
            this.MoveUp.Click += new System.EventHandler(this.MoveUp_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridView1.Location = new System.Drawing.Point(6, 16);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(366, 375);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // Headers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MoveDown);
            this.Controls.Add(this.MoveUp);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Save);
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Name = "Headers";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "تعديل عنواين القائمة :";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Headers_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerHeight)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown headerLocation;
        private System.Windows.Forms.NumericUpDown headerHeight;
        private System.Windows.Forms.Button Fonts;
        private System.Windows.Forms.Button BackColor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label MenuTitle;
        private System.Windows.Forms.Button AddHeader;
        private System.Windows.Forms.Button MoveDown;
        private System.Windows.Forms.Button MoveUp;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}