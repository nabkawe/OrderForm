namespace OrderForm
{
    partial class SureMsg
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
            this.DeleteBTN = new System.Windows.Forms.Button();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // DeleteBTN
            // 
            this.DeleteBTN.BackColor = System.Drawing.Color.Red;
            this.DeleteBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteBTN.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBTN.ForeColor = System.Drawing.Color.White;
            this.DeleteBTN.Location = new System.Drawing.Point(4, 1);
            this.DeleteBTN.Name = "DeleteBTN";
            this.DeleteBTN.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DeleteBTN.Size = new System.Drawing.Size(69, 37);
            this.DeleteBTN.TabIndex = 0;
            this.DeleteBTN.Text = "حذف";
            this.DeleteBTN.UseVisualStyleBackColor = false;
            this.DeleteBTN.Click += new System.EventHandler(this.DeleteBTN_Click);
            this.DeleteBTN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DeleteBTN_MouseUp);
            // 
            // tmr
            // 
            this.tmr.Interval = 800;
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // SureMsg
            // 
            this.AcceptButton = this.DeleteBTN;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Fuchsia;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(77, 41);
            this.ControlBox = false;
            this.Controls.Add(this.DeleteBTN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SureMsg";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "هل تريد حذف المادة؟";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.SureMsg_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DeleteBTN;
        private System.Windows.Forms.Timer tmr;
    }
}