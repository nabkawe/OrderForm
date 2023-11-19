namespace OrderForm
{
    partial class NotesForm
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
            this.noteList = new System.Windows.Forms.ListBox();
            this.saveBTN = new System.Windows.Forms.Button();
            this.cancelBTN = new System.Windows.Forms.Button();
            this.DeleteItem = new System.Windows.Forms.Button();
            this.AddNoteBTN = new System.Windows.Forms.Button();
            this.noteTB = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // noteList
            // 
            this.noteList.FormattingEnabled = true;
            this.noteList.Location = new System.Drawing.Point(8, 67);
            this.noteList.Name = "noteList";
            this.noteList.Size = new System.Drawing.Size(279, 238);
            this.noteList.TabIndex = 0;
            // 
            // saveBTN
            // 
            this.saveBTN.Location = new System.Drawing.Point(8, 320);
            this.saveBTN.Name = "saveBTN";
            this.saveBTN.Size = new System.Drawing.Size(75, 23);
            this.saveBTN.TabIndex = 1;
            this.saveBTN.Text = "حفظ";
            this.saveBTN.UseVisualStyleBackColor = true;
            this.saveBTN.Click += new System.EventHandler(this.saveBTN_Click);
            // 
            // cancelBTN
            // 
            this.cancelBTN.Location = new System.Drawing.Point(89, 320);
            this.cancelBTN.Name = "cancelBTN";
            this.cancelBTN.Size = new System.Drawing.Size(75, 23);
            this.cancelBTN.TabIndex = 2;
            this.cancelBTN.Text = "إلغاء الأمر";
            this.cancelBTN.UseVisualStyleBackColor = true;
            this.cancelBTN.Click += new System.EventHandler(this.cancelBTN_Click);
            // 
            // DeleteItem
            // 
            this.DeleteItem.Location = new System.Drawing.Point(199, 38);
            this.DeleteItem.Name = "DeleteItem";
            this.DeleteItem.Size = new System.Drawing.Size(87, 23);
            this.DeleteItem.TabIndex = 4;
            this.DeleteItem.Text = "حذف الملاحظة";
            this.DeleteItem.UseVisualStyleBackColor = true;
            this.DeleteItem.Click += new System.EventHandler(this.DeleteItem_Click);
            // 
            // AddNoteBTN
            // 
            this.AddNoteBTN.Location = new System.Drawing.Point(199, 12);
            this.AddNoteBTN.Name = "AddNoteBTN";
            this.AddNoteBTN.Size = new System.Drawing.Size(87, 23);
            this.AddNoteBTN.TabIndex = 3;
            this.AddNoteBTN.Text = "إضافة";
            this.AddNoteBTN.UseVisualStyleBackColor = true;
            this.AddNoteBTN.Click += new System.EventHandler(this.AddNoteBTN_Click_1);
            // 
            // noteTB
            // 
            this.noteTB.Location = new System.Drawing.Point(8, 12);
            this.noteTB.Name = "noteTB";
            this.noteTB.Size = new System.Drawing.Size(184, 20);
            this.noteTB.TabIndex = 5;
            this.noteTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(250, 320);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "ت";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(210, 320);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(36, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "أ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // NotesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 350);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.noteTB);
            this.Controls.Add(this.DeleteItem);
            this.Controls.Add(this.AddNoteBTN);
            this.Controls.Add(this.cancelBTN);
            this.Controls.Add(this.saveBTN);
            this.Controls.Add(this.noteList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NotesForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إضافة ملاحظات لمواد القسم: ";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.NotesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button saveBTN;
        private System.Windows.Forms.Button cancelBTN;
        private System.Windows.Forms.Button DeleteItem;
        private System.Windows.Forms.Button AddNoteBTN;
        private System.Windows.Forms.TextBox noteTB;
        public System.Windows.Forms.ListBox noteList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}