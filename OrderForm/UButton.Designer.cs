using System.Windows.Forms;

namespace OrderForm
{
    partial class UButton
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // UnfocusableButton
            // 
            this.Name = "UnfocusableButton";
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Margin = new Padding(1);
            this.TabStop = false;
            this.TabIndex = 1000;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.White;
            this.FlatAppearance.BorderSize = 1;
            this.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.TextImageRelation = TextImageRelation.Overlay;
            this.BackgroundImageLayout = ImageLayout.Center;
            this.ResumeLayout(false);
            
        }

        #endregion
    }
}
