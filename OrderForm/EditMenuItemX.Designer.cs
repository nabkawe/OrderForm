namespace OrderForm
{
    partial class EditMenuItemX
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
            this.Availables = new System.Windows.Forms.CheckBox();
            this.ChoosePicPath = new System.Windows.Forms.Button();
            this.AddSingleItem = new System.Windows.Forms.Button();
            this.Mpath = new System.Windows.Forms.TextBox();
            this.Mcal = new System.Windows.Forms.TextBox();
            this.Mdetails = new System.Windows.Forms.TextBox();
            this.MPrice = new System.Windows.Forms.TextBox();
            this.MBarcode = new System.Windows.Forms.TextBox();
            this.MnameTB = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Availables);
            this.panel1.Controls.Add(this.ChoosePicPath);
            this.panel1.Controls.Add(this.AddSingleItem);
            this.panel1.Controls.Add(this.Mpath);
            this.panel1.Controls.Add(this.Mcal);
            this.panel1.Controls.Add(this.Mdetails);
            this.panel1.Controls.Add(this.MPrice);
            this.panel1.Controls.Add(this.MBarcode);
            this.panel1.Controls.Add(this.MnameTB);
            this.panel1.Controls.Add(this.label54);
            this.panel1.Controls.Add(this.label55);
            this.panel1.Controls.Add(this.label56);
            this.panel1.Controls.Add(this.label57);
            this.panel1.Controls.Add(this.label58);
            this.panel1.Controls.Add(this.label59);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(423, 358);
            this.panel1.TabIndex = 40;
            // 
            // Availables
            // 
            this.Availables.AutoSize = true;
            this.Availables.Checked = true;
            this.Availables.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Availables.Location = new System.Drawing.Point(16, 266);
            this.Availables.Name = "Availables";
            this.Availables.Size = new System.Drawing.Size(51, 17);
            this.Availables.TabIndex = 47;
            this.Availables.Text = "متوفر";
            this.Availables.UseVisualStyleBackColor = true;
            // 
            // ChoosePicPath
            // 
            this.ChoosePicPath.BackColor = System.Drawing.Color.White;
            this.ChoosePicPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChoosePicPath.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChoosePicPath.Location = new System.Drawing.Point(365, 258);
            this.ChoosePicPath.Name = "ChoosePicPath";
            this.ChoosePicPath.Size = new System.Drawing.Size(51, 33);
            this.ChoosePicPath.TabIndex = 7;
            this.ChoosePicPath.Text = "إختيار الصورة";
            this.ChoosePicPath.UseCompatibleTextRendering = true;
            this.ChoosePicPath.UseVisualStyleBackColor = false;
            this.ChoosePicPath.Click += new System.EventHandler(this.ChoosePicPath_Click);
            // 
            // AddSingleItem
            // 
            this.AddSingleItem.BackColor = System.Drawing.Color.White;
            this.AddSingleItem.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AddSingleItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddSingleItem.Location = new System.Drawing.Point(228, 310);
            this.AddSingleItem.Name = "AddSingleItem";
            this.AddSingleItem.Size = new System.Drawing.Size(187, 41);
            this.AddSingleItem.TabIndex = 8;
            this.AddSingleItem.Text = "حفظ تعديل المادة";
            this.AddSingleItem.UseVisualStyleBackColor = false;
            this.AddSingleItem.Click += new System.EventHandler(this.AddSingleItem_Click);
            // 
            // Mpath
            // 
            this.Mpath.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mpath.Location = new System.Drawing.Point(73, 258);
            this.Mpath.Name = "Mpath";
            this.Mpath.Size = new System.Drawing.Size(285, 33);
            this.Mpath.TabIndex = 6;
            this.Mpath.TabStop = false;
            // 
            // Mcal
            // 
            this.Mcal.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mcal.Location = new System.Drawing.Point(16, 211);
            this.Mcal.Name = "Mcal";
            this.Mcal.Size = new System.Drawing.Size(400, 33);
            this.Mcal.TabIndex = 5;
            // 
            // Mdetails
            // 
            this.Mdetails.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mdetails.Location = new System.Drawing.Point(16, 164);
            this.Mdetails.Name = "Mdetails";
            this.Mdetails.Size = new System.Drawing.Size(400, 33);
            this.Mdetails.TabIndex = 4;
            // 
            // MPrice
            // 
            this.MPrice.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MPrice.Location = new System.Drawing.Point(16, 117);
            this.MPrice.Name = "MPrice";
            this.MPrice.Size = new System.Drawing.Size(400, 33);
            this.MPrice.TabIndex = 3;
            // 
            // MBarcode
            // 
            this.MBarcode.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MBarcode.Location = new System.Drawing.Point(16, 70);
            this.MBarcode.Name = "MBarcode";
            this.MBarcode.Size = new System.Drawing.Size(400, 33);
            this.MBarcode.TabIndex = 2;
            // 
            // MnameTB
            // 
            this.MnameTB.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MnameTB.Location = new System.Drawing.Point(16, 23);
            this.MnameTB.Name = "MnameTB";
            this.MnameTB.Size = new System.Drawing.Size(400, 33);
            this.MnameTB.TabIndex = 1;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.ForeColor = System.Drawing.Color.Gray;
            this.label54.Location = new System.Drawing.Point(358, 102);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(58, 13);
            this.label54.TabIndex = 30;
            this.label54.Text = "سعر المادة";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.ForeColor = System.Drawing.Color.Gray;
            this.label55.Location = new System.Drawing.Point(336, 242);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(80, 13);
            this.label55.TabIndex = 33;
            this.label55.Text = "رابط صورة المادة";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.ForeColor = System.Drawing.Color.Gray;
            this.label56.Location = new System.Drawing.Point(266, 196);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(150, 13);
            this.label56.TabIndex = 32;
            this.label56.Text = "معلومات السعرات و الحساسية";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.ForeColor = System.Drawing.Color.Gray;
            this.label57.Location = new System.Drawing.Point(357, 149);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(59, 13);
            this.label57.TabIndex = 31;
            this.label57.Text = "شرح المادة";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.ForeColor = System.Drawing.Color.Gray;
            this.label58.Location = new System.Drawing.Point(355, 55);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(61, 13);
            this.label58.TabIndex = 29;
            this.label58.Text = "باركود المادة";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.ForeColor = System.Drawing.Color.Gray;
            this.label59.Location = new System.Drawing.Point(358, 8);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(58, 13);
            this.label59.TabIndex = 28;
            this.label59.Text = "اسم المادة";
            // 
            // EditMenuItemX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 380);
            this.Controls.Add(this.panel1);
            this.Name = "EditMenuItemX";
            this.Text = "EditMenuItemX";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox Availables;
        private System.Windows.Forms.Button ChoosePicPath;
        private System.Windows.Forms.Button AddSingleItem;
        private System.Windows.Forms.TextBox Mpath;
        private System.Windows.Forms.TextBox Mcal;
        private System.Windows.Forms.TextBox Mdetails;
        private System.Windows.Forms.TextBox MPrice;
        private System.Windows.Forms.TextBox MBarcode;
        private System.Windows.Forms.TextBox MnameTB;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label59;
    }
}