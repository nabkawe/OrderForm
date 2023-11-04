namespace OrderForm
{
    partial class Discounnt
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
            this.DiscountRB = new System.Windows.Forms.RadioButton();
            this.errorRB = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CancelOrder = new System.Windows.Forms.Button();
            this.ApplyDiscount = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.GhostWhite;
            this.panel1.Controls.Add(this.DiscountRB);
            this.panel1.Controls.Add(this.errorRB);
            this.panel1.Location = new System.Drawing.Point(12, 86);
            this.panel1.Margin = new System.Windows.Forms.Padding(10);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(470, 113);
            this.panel1.TabIndex = 0;
            // 
            // DiscountRB
            // 
            this.DiscountRB.Appearance = System.Windows.Forms.Appearance.Button;
            this.DiscountRB.BackColor = System.Drawing.Color.LightSlateGray;
            this.DiscountRB.Dock = System.Windows.Forms.DockStyle.Top;
            this.DiscountRB.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.DiscountRB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DiscountRB.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.DiscountRB.ForeColor = System.Drawing.Color.GhostWhite;
            this.DiscountRB.Location = new System.Drawing.Point(10, 57);
            this.DiscountRB.Name = "DiscountRB";
            this.DiscountRB.Size = new System.Drawing.Size(450, 47);
            this.DiscountRB.TabIndex = 5;
            this.DiscountRB.Text = "خصم كميات";
            this.DiscountRB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DiscountRB.UseVisualStyleBackColor = false;
            // 
            // errorRB
            // 
            this.errorRB.Appearance = System.Windows.Forms.Appearance.Button;
            this.errorRB.BackColor = System.Drawing.Color.LightSlateGray;
            this.errorRB.Checked = true;
            this.errorRB.Dock = System.Windows.Forms.DockStyle.Top;
            this.errorRB.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.errorRB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.errorRB.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.errorRB.ForeColor = System.Drawing.Color.GhostWhite;
            this.errorRB.Location = new System.Drawing.Point(10, 10);
            this.errorRB.Name = "errorRB";
            this.errorRB.Size = new System.Drawing.Size(450, 47);
            this.errorRB.TabIndex = 4;
            this.errorRB.TabStop = true;
            this.errorRB.Text = "تعويض عن خطأ سابق";
            this.errorRB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.errorRB.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "ما هو سبب الخصم؟";
            // 
            // dc
            // 
            this.dc.BackColor = System.Drawing.Color.GhostWhite;
            this.dc.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dc.Location = new System.Drawing.Point(212, 21);
            this.dc.Name = "dc";
            this.dc.Size = new System.Drawing.Size(94, 36);
            this.dc.TabIndex = 2;
            this.dc.Text = "0";
            this.dc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dc_KeyDown);
            this.dc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(149, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "الخصم:";
            // 
            // CancelOrder
            // 
            this.CancelOrder.BackColor = System.Drawing.Color.LightSlateGray;
            this.CancelOrder.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelOrder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CancelOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelOrder.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelOrder.ForeColor = System.Drawing.Color.GhostWhite;
            this.CancelOrder.Location = new System.Drawing.Point(0, 264);
            this.CancelOrder.Margin = new System.Windows.Forms.Padding(20);
            this.CancelOrder.Name = "CancelOrder";
            this.CancelOrder.Size = new System.Drawing.Size(494, 44);
            this.CancelOrder.TabIndex = 8;
            this.CancelOrder.Text = "الغاء الخصم";
            this.CancelOrder.UseVisualStyleBackColor = false;
            this.CancelOrder.Click += new System.EventHandler(this.button1_Click);
            // 
            // ApplyDiscount
            // 
            this.ApplyDiscount.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ApplyDiscount.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ApplyDiscount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ApplyDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ApplyDiscount.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplyDiscount.ForeColor = System.Drawing.Color.GhostWhite;
            this.ApplyDiscount.Location = new System.Drawing.Point(0, 216);
            this.ApplyDiscount.Margin = new System.Windows.Forms.Padding(20);
            this.ApplyDiscount.Name = "ApplyDiscount";
            this.ApplyDiscount.Size = new System.Drawing.Size(494, 48);
            this.ApplyDiscount.TabIndex = 7;
            this.ApplyDiscount.Text = "تطبيق الخصم";
            this.ApplyDiscount.UseVisualStyleBackColor = false;
            this.ApplyDiscount.Click += new System.EventHandler(this.button3_Click);
            // 
            // Discounnt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(494, 308);
            this.Controls.Add(this.ApplyDiscount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CancelOrder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Discounnt";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AreYouSure";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Discounnt_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton DiscountRB;
        private System.Windows.Forms.RadioButton errorRB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CancelOrder;
        private System.Windows.Forms.Button ApplyDiscount;
        public System.Windows.Forms.TextBox dc;
    }
}