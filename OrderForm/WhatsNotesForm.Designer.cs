namespace OrderForm
{
    partial class WhatsNotesForm
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
            this.shortTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.noteRB = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // noteList
            // 
            this.noteList.DisplayMember = "Shortcut";
            this.noteList.FormattingEnabled = true;
            this.noteList.Location = new System.Drawing.Point(8, 143);
            this.noteList.Name = "noteList";
            this.noteList.ScrollAlwaysVisible = true;
            this.noteList.Size = new System.Drawing.Size(603, 290);
            this.noteList.TabIndex = 0;
            this.noteList.ValueMember = "Details";
            this.noteList.SelectedIndexChanged += new System.EventHandler(this.noteList_SelectedIndexChanged);
            this.noteList.DoubleClick += new System.EventHandler(this.noteList_DoubleClick);
            // 
            // saveBTN
            // 
            this.saveBTN.Location = new System.Drawing.Point(8, 447);
            this.saveBTN.Name = "saveBTN";
            this.saveBTN.Size = new System.Drawing.Size(75, 23);
            this.saveBTN.TabIndex = 6;
            this.saveBTN.Text = "حفظ";
            this.saveBTN.UseVisualStyleBackColor = true;
            this.saveBTN.Click += new System.EventHandler(this.saveBTN_Click);
            // 
            // cancelBTN
            // 
            this.cancelBTN.Location = new System.Drawing.Point(89, 447);
            this.cancelBTN.Name = "cancelBTN";
            this.cancelBTN.Size = new System.Drawing.Size(75, 23);
            this.cancelBTN.TabIndex = 7;
            this.cancelBTN.Text = "إلغاء الأمر";
            this.cancelBTN.UseVisualStyleBackColor = true;
            this.cancelBTN.Click += new System.EventHandler(this.cancelBTN_Click);
            // 
            // DeleteItem
            // 
            this.DeleteItem.Location = new System.Drawing.Point(524, 102);
            this.DeleteItem.Name = "DeleteItem";
            this.DeleteItem.Size = new System.Drawing.Size(87, 23);
            this.DeleteItem.TabIndex = 4;
            this.DeleteItem.TabStop = false;
            this.DeleteItem.Text = "حذف الملاحظة";
            this.DeleteItem.UseVisualStyleBackColor = true;
            this.DeleteItem.Click += new System.EventHandler(this.DeleteItem_Click);
            // 
            // AddNoteBTN
            // 
            this.AddNoteBTN.Location = new System.Drawing.Point(524, 73);
            this.AddNoteBTN.Name = "AddNoteBTN";
            this.AddNoteBTN.Size = new System.Drawing.Size(87, 23);
            this.AddNoteBTN.TabIndex = 3;
            this.AddNoteBTN.Text = "إضافة";
            this.AddNoteBTN.UseVisualStyleBackColor = true;
            this.AddNoteBTN.Click += new System.EventHandler(this.AddNoteBTN_Click_1);
            // 
            // shortTB
            // 
            this.shortTB.Location = new System.Drawing.Point(62, 17);
            this.shortTB.Multiline = true;
            this.shortTB.Name = "shortTB";
            this.shortTB.Size = new System.Drawing.Size(456, 23);
            this.shortTB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "الإختصار";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "الرسالة";
            // 
            // noteRB
            // 
            this.noteRB.Location = new System.Drawing.Point(62, 46);
            this.noteRB.Name = "noteRB";
            this.noteRB.Size = new System.Drawing.Size(456, 91);
            this.noteRB.TabIndex = 22;
            this.noteRB.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(536, 439);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "إلى الأسفل";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(455, 439);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 24;
            this.button2.Text = "إلى الأعلى";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // WhatsNotesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 484);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.noteRB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shortTB);
            this.Controls.Add(this.DeleteItem);
            this.Controls.Add(this.AddNoteBTN);
            this.Controls.Add(this.cancelBTN);
            this.Controls.Add(this.saveBTN);
            this.Controls.Add(this.noteList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WhatsNotesForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إضافة إختصار واتسآب جديد";
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
        public System.Windows.Forms.ListBox noteList;
        private System.Windows.Forms.TextBox shortTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox noteRB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}