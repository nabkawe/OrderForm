namespace OrderForm
{
    partial class MessageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Message = new System.Windows.Forms.RichTextBox();
            this.NoBTN = new System.Windows.Forms.Button();
            this.YesBTN = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.Color.GhostWhite;
            this.panel1.Controls.Add(this.Message);
            this.panel1.Location = new System.Drawing.Point(12, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(10);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(630, 210);
            this.panel1.TabIndex = 0;
            // 
            // Message
            // 
            this.Message.BackColor = System.Drawing.Color.GhostWhite;
            this.Message.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Message.Cursor = System.Windows.Forms.Cursors.Default;
            this.Message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Message.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Message.Location = new System.Drawing.Point(10, 10);
            this.Message.Name = "Message";
            this.Message.ReadOnly = true;
            this.Message.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.Message.Size = new System.Drawing.Size(610, 190);
            this.Message.TabIndex = 0;
            this.Message.TabStop = false;
            this.Message.Text = "مضمون الرسالة";
            // 
            // NoBTN
            // 
            this.NoBTN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NoBTN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NoBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.NoBTN.DialogResult = System.Windows.Forms.DialogResult.No;
            this.NoBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.NoBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.NoBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NoBTN.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoBTN.ForeColor = System.Drawing.Color.GhostWhite;
            this.NoBTN.Location = new System.Drawing.Point(12, 290);
            this.NoBTN.Margin = new System.Windows.Forms.Padding(20);
            this.NoBTN.Name = "NoBTN";
            this.NoBTN.Size = new System.Drawing.Size(630, 68);
            this.NoBTN.TabIndex = 2;
            this.NoBTN.Text = "لا";
            this.NoBTN.UseVisualStyleBackColor = false;
            // 
            // YesBTN
            // 
            this.YesBTN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.YesBTN.BackColor = System.Drawing.Color.LightSeaGreen;
            this.YesBTN.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.YesBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.YesBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.YesBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.YesBTN.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YesBTN.ForeColor = System.Drawing.Color.GhostWhite;
            this.YesBTN.Location = new System.Drawing.Point(12, 218);
            this.YesBTN.Margin = new System.Windows.Forms.Padding(20);
            this.YesBTN.Name = "YesBTN";
            this.YesBTN.Size = new System.Drawing.Size(630, 68);
            this.YesBTN.TabIndex = 1;
            this.YesBTN.Text = "نعم";
            this.YesBTN.UseVisualStyleBackColor = false;
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(652, 364);
            this.Controls.Add(this.NoBTN);
            this.Controls.Add(this.YesBTN);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessageForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = " ";
            this.TopMost = true;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MessageForm_KeyPress);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button NoBTN;
        private System.Windows.Forms.Button YesBTN;
        private System.Windows.Forms.RichTextBox Message;
    }
}