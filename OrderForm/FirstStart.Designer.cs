namespace OrderForm
{
    partial class FirstStart
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FirstRestTB = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.FirstLogoTB = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.FileOpen = new System.Windows.Forms.OpenFileDialog();
            this.ServerPC = new System.Windows.Forms.RadioButton();
            this.clientPC = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.clientPC);
            this.groupBox1.Controls.Add(this.ServerPC);
            this.groupBox1.Controls.Add(this.FirstRestTB);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.FirstLogoTB);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(368, 212);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "إعدادات الإسم والشعار";
            // 
            // FirstRestTB
            // 
            this.FirstRestTB.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstRestTB.Location = new System.Drawing.Point(6, 32);
            this.FirstRestTB.Name = "FirstRestTB";
            this.FirstRestTB.Size = new System.Drawing.Size(209, 33);
            this.FirstRestTB.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(221, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 33);
            this.button2.TabIndex = 2;
            this.button2.Text = "إسم المطعم";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // FirstLogoTB
            // 
            this.FirstLogoTB.AllowDrop = true;
            this.FirstLogoTB.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstLogoTB.Location = new System.Drawing.Point(6, 74);
            this.FirstLogoTB.Name = "FirstLogoTB";
            this.FirstLogoTB.Size = new System.Drawing.Size(209, 33);
            this.FirstLogoTB.TabIndex = 1;
            this.FirstLogoTB.DragDrop += new System.Windows.Forms.DragEventHandler(this.FirstLogoTB_DragDrop);
            this.FirstLogoTB.DragOver += new System.Windows.Forms.DragEventHandler(this.FirstLogoTB_DragOver);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(221, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "شعار المطعم";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(245, 225);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(135, 33);
            this.button3.TabIndex = 4;
            this.button3.Text = "حفظ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(104, 225);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(135, 33);
            this.button4.TabIndex = 5;
            this.button4.Text = "خروج";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // FileOpen
            // 
            this.FileOpen.Title = "إختر صورة شعار المطعم";
            // 
            // ServerPC
            // 
            this.ServerPC.AutoSize = true;
            this.ServerPC.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerPC.Location = new System.Drawing.Point(6, 179);
            this.ServerPC.Name = "ServerPC";
            this.ServerPC.Size = new System.Drawing.Size(208, 27);
            this.ServerPC.TabIndex = 6;
            this.ServerPC.Text = "كمبيوتر رئيسي Server";
            this.ServerPC.UseVisualStyleBackColor = true;
            // 
            // clientPC
            // 
            this.clientPC.AutoSize = true;
            this.clientPC.Checked = true;
            this.clientPC.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientPC.Location = new System.Drawing.Point(220, 179);
            this.clientPC.Name = "clientPC";
            this.clientPC.Size = new System.Drawing.Size(136, 27);
            this.clientPC.TabIndex = 7;
            this.clientPC.TabStop = true;
            this.clientPC.Text = "كمبيوتر فرعي";
            this.clientPC.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 8;
            // 
            // FirstStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 261);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FirstStart";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الإعدادات الأولية";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FirstStart_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox FirstRestTB;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox FirstLogoTB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.OpenFileDialog FileOpen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton clientPC;
        private System.Windows.Forms.RadioButton ServerPC;
    }
}