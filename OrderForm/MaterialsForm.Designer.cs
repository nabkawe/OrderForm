namespace OrderForm
{
    partial class MaterialsForm
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
            this.Back = new System.Windows.Forms.SplitContainer();
            this.MDG = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pOSItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Back)).BeginInit();
            this.Back.Panel1.SuspendLayout();
            this.Back.Panel2.SuspendLayout();
            this.Back.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MDG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pOSItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // Back
            // 
            this.Back.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Back.Location = new System.Drawing.Point(0, 0);
            this.Back.Name = "Back";
            // 
            // Back.Panel1
            // 
            this.Back.Panel1.Controls.Add(this.textBox1);
            this.Back.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // Back.Panel2
            // 
            this.Back.Panel2.Controls.Add(this.MDG);
            this.Back.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Back.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Back.Size = new System.Drawing.Size(800, 450);
            this.Back.SplitterDistance = 361;
            this.Back.SplitterWidth = 10;
            this.Back.TabIndex = 1;
            // 
            // MDG
            // 
            this.MDG.AllowUserToAddRows = false;
            this.MDG.AllowUserToDeleteRows = false;
            this.MDG.AllowUserToResizeRows = false;
            this.MDG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MDG.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.MDG.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MDG.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.MDG.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.MDG.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.MDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MDG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MDG.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.MDG.GridColor = System.Drawing.Color.DimGray;
            this.MDG.Location = new System.Drawing.Point(0, 0);
            this.MDG.Name = "MDG";
            this.MDG.ReadOnly = true;
            this.MDG.RowHeadersVisible = false;
            this.MDG.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.MDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MDG.ShowCellErrors = false;
            this.MDG.ShowCellToolTips = false;
            this.MDG.ShowEditingIcon = false;
            this.MDG.ShowRowErrors = false;
            this.MDG.Size = new System.Drawing.Size(429, 450);
            this.MDG.TabIndex = 0;
            this.MDG.TabStop = false;
            this.MDG.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.MDG_CellFormatting);
            this.MDG.DoubleClick += new System.EventHandler(this.MDG_DoubleClick);
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "Name", true));
            this.textBox1.Location = new System.Drawing.Point(91, 55);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(230, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "\r\n";
            // 
            // pOSItemsBindingSource
            // 
            this.pOSItemsBindingSource.DataSource = typeof(sharedCode.POSItems);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(sharedCode.POSItems);
            // 
            // MaterialsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Back);
            this.Name = "MaterialsForm";
            this.Text = "MaterialsForm";
            this.Back.Panel1.ResumeLayout(false);
            this.Back.Panel1.PerformLayout();
            this.Back.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Back)).EndInit();
            this.Back.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MDG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pOSItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer Back;
        private System.Windows.Forms.DataGridView MDG;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.BindingSource pOSItemsBindingSource;
    }
}