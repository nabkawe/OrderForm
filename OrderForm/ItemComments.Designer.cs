namespace OrderForm
{
    partial class ItemComments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemComments));
            this.numpad = new System.Windows.Forms.GroupBox();
            this.CheckBoxes = new System.Windows.Forms.FlowLayoutPanel();
            this.QuickCommentTB = new System.Windows.Forms.TextBox();
            this.NotesLabel = new System.Windows.Forms.Label();
            this.NoBTN = new System.Windows.Forms.Button();
            this.YesBTN = new System.Windows.Forms.Button();
            this.uButton1 = new OrderForm.UButton();
            this.FiveBTN = new OrderForm.UButton();
            this.SixBTN = new OrderForm.UButton();
            this.SevenBTN = new OrderForm.UButton();
            this.EightBTN = new OrderForm.UButton();
            this.NineBTN = new OrderForm.UButton();
            this.ZeroBTN = new OrderForm.UButton();
            this.BackSpaceBTN = new OrderForm.UButton();
            this.OneBTN = new OrderForm.UButton();
            this.TwoBTN = new OrderForm.UButton();
            this.ThreeBTN = new OrderForm.UButton();
            this.FourBTN = new OrderForm.UButton();
            this.numpad.SuspendLayout();
            this.SuspendLayout();
            // 
            // numpad
            // 
            this.numpad.Controls.Add(this.uButton1);
            this.numpad.Controls.Add(this.FiveBTN);
            this.numpad.Controls.Add(this.SixBTN);
            this.numpad.Controls.Add(this.SevenBTN);
            this.numpad.Controls.Add(this.EightBTN);
            this.numpad.Controls.Add(this.NineBTN);
            this.numpad.Controls.Add(this.ZeroBTN);
            this.numpad.Controls.Add(this.BackSpaceBTN);
            this.numpad.Controls.Add(this.OneBTN);
            this.numpad.Controls.Add(this.TwoBTN);
            this.numpad.Controls.Add(this.ThreeBTN);
            this.numpad.Controls.Add(this.FourBTN);
            this.numpad.Location = new System.Drawing.Point(441, 128);
            this.numpad.Name = "numpad";
            this.numpad.Size = new System.Drawing.Size(307, 232);
            this.numpad.TabIndex = 4;
            this.numpad.TabStop = false;
            // 
            // CheckBoxes
            // 
            this.CheckBoxes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckBoxes.AutoScroll = true;
            this.CheckBoxes.BackColor = System.Drawing.Color.GhostWhite;
            this.CheckBoxes.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxes.Location = new System.Drawing.Point(13, 80);
            this.CheckBoxes.Margin = new System.Windows.Forms.Padding(5);
            this.CheckBoxes.Name = "CheckBoxes";
            this.CheckBoxes.Padding = new System.Windows.Forms.Padding(5);
            this.CheckBoxes.Size = new System.Drawing.Size(422, 510);
            this.CheckBoxes.TabIndex = 5;
            // 
            // QuickCommentTB
            // 
            this.QuickCommentTB.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuickCommentTB.Location = new System.Drawing.Point(13, 37);
            this.QuickCommentTB.Name = "QuickCommentTB";
            this.QuickCommentTB.Size = new System.Drawing.Size(736, 36);
            this.QuickCommentTB.TabIndex = 6;
            this.QuickCommentTB.TextChanged += new System.EventHandler(this.QuickCommentTB_TextChanged);
            // 
            // NotesLabel
            // 
            this.NotesLabel.AutoSize = true;
            this.NotesLabel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NotesLabel.ForeColor = System.Drawing.Color.GhostWhite;
            this.NotesLabel.Location = new System.Drawing.Point(13, 5);
            this.NotesLabel.Name = "NotesLabel";
            this.NotesLabel.Size = new System.Drawing.Size(142, 23);
            this.NotesLabel.TabIndex = 7;
            this.NotesLabel.Text = "ملاحظة المادة:";
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
            this.NoBTN.Location = new System.Drawing.Point(498, 415);
            this.NoBTN.Margin = new System.Windows.Forms.Padding(20);
            this.NoBTN.Name = "NoBTN";
            this.NoBTN.Size = new System.Drawing.Size(199, 68);
            this.NoBTN.TabIndex = 9;
            this.NoBTN.Text = "حذف الملاحظة";
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
            this.YesBTN.Location = new System.Drawing.Point(447, 499);
            this.YesBTN.Margin = new System.Windows.Forms.Padding(20);
            this.YesBTN.Name = "YesBTN";
            this.YesBTN.Size = new System.Drawing.Size(300, 91);
            this.YesBTN.TabIndex = 8;
            this.YesBTN.Text = "إدخال الملاحظة";
            this.YesBTN.UseVisualStyleBackColor = false;
            // 
            // uButton1
            // 
            this.uButton1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.uButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.uButton1.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.uButton1.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.uButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.uButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.uButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uButton1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uButton1.ForeColor = System.Drawing.Color.White;
            this.uButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uButton1.Location = new System.Drawing.Point(206, 174);
            this.uButton1.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.uButton1.Name = "uButton1";
            this.uButton1.Size = new System.Drawing.Size(97, 51);
            this.uButton1.TabIndex = 73;
            this.uButton1.TabStop = false;
            this.uButton1.Text = "مسافة";
            this.uButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.uButton1.UseVisualStyleBackColor = false;
            this.uButton1.Click += new System.EventHandler(this.uButton1_Click);
            // 
            // FiveBTN
            // 
            this.FiveBTN.BackColor = System.Drawing.Color.LightSeaGreen;
            this.FiveBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.FiveBTN.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.FiveBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.FiveBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.FiveBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.FiveBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FiveBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FiveBTN.ForeColor = System.Drawing.Color.White;
            this.FiveBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FiveBTN.Location = new System.Drawing.Point(104, 68);
            this.FiveBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.FiveBTN.Name = "FiveBTN";
            this.FiveBTN.Size = new System.Drawing.Size(97, 50);
            this.FiveBTN.TabIndex = 72;
            this.FiveBTN.TabStop = false;
            this.FiveBTN.Text = "5";
            this.FiveBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.FiveBTN.UseVisualStyleBackColor = false;
            this.FiveBTN.Click += new System.EventHandler(this.NineBTN_Click);
            // 
            // SixBTN
            // 
            this.SixBTN.BackColor = System.Drawing.Color.LightSeaGreen;
            this.SixBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SixBTN.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.SixBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.SixBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.SixBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.SixBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SixBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SixBTN.ForeColor = System.Drawing.Color.White;
            this.SixBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SixBTN.Location = new System.Drawing.Point(206, 68);
            this.SixBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.SixBTN.Name = "SixBTN";
            this.SixBTN.Size = new System.Drawing.Size(97, 50);
            this.SixBTN.TabIndex = 71;
            this.SixBTN.TabStop = false;
            this.SixBTN.Text = "6";
            this.SixBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SixBTN.UseVisualStyleBackColor = false;
            this.SixBTN.Click += new System.EventHandler(this.NineBTN_Click);
            // 
            // SevenBTN
            // 
            this.SevenBTN.BackColor = System.Drawing.Color.LightSeaGreen;
            this.SevenBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SevenBTN.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.SevenBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.SevenBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.SevenBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.SevenBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SevenBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SevenBTN.ForeColor = System.Drawing.Color.White;
            this.SevenBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SevenBTN.Location = new System.Drawing.Point(3, 14);
            this.SevenBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.SevenBTN.Name = "SevenBTN";
            this.SevenBTN.Size = new System.Drawing.Size(97, 50);
            this.SevenBTN.TabIndex = 70;
            this.SevenBTN.TabStop = false;
            this.SevenBTN.Text = "7";
            this.SevenBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SevenBTN.UseVisualStyleBackColor = false;
            this.SevenBTN.Click += new System.EventHandler(this.NineBTN_Click);
            // 
            // EightBTN
            // 
            this.EightBTN.BackColor = System.Drawing.Color.LightSeaGreen;
            this.EightBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.EightBTN.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.EightBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.EightBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.EightBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.EightBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EightBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EightBTN.ForeColor = System.Drawing.Color.White;
            this.EightBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EightBTN.Location = new System.Drawing.Point(104, 14);
            this.EightBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.EightBTN.Name = "EightBTN";
            this.EightBTN.Size = new System.Drawing.Size(97, 50);
            this.EightBTN.TabIndex = 69;
            this.EightBTN.TabStop = false;
            this.EightBTN.Text = "8";
            this.EightBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EightBTN.UseVisualStyleBackColor = false;
            this.EightBTN.Click += new System.EventHandler(this.NineBTN_Click);
            // 
            // NineBTN
            // 
            this.NineBTN.BackColor = System.Drawing.Color.LightSeaGreen;
            this.NineBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.NineBTN.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.NineBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.NineBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.NineBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.NineBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NineBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NineBTN.ForeColor = System.Drawing.Color.White;
            this.NineBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NineBTN.Location = new System.Drawing.Point(206, 14);
            this.NineBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.NineBTN.Name = "NineBTN";
            this.NineBTN.Size = new System.Drawing.Size(97, 50);
            this.NineBTN.TabIndex = 68;
            this.NineBTN.TabStop = false;
            this.NineBTN.Text = "9";
            this.NineBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.NineBTN.UseVisualStyleBackColor = false;
            this.NineBTN.Click += new System.EventHandler(this.NineBTN_Click);
            // 
            // ZeroBTN
            // 
            this.ZeroBTN.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ZeroBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ZeroBTN.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.ZeroBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.ZeroBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.ZeroBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.ZeroBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ZeroBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZeroBTN.ForeColor = System.Drawing.Color.White;
            this.ZeroBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ZeroBTN.Location = new System.Drawing.Point(104, 174);
            this.ZeroBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.ZeroBTN.Name = "ZeroBTN";
            this.ZeroBTN.Size = new System.Drawing.Size(97, 51);
            this.ZeroBTN.TabIndex = 67;
            this.ZeroBTN.TabStop = false;
            this.ZeroBTN.Text = "0";
            this.ZeroBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ZeroBTN.UseVisualStyleBackColor = false;
            this.ZeroBTN.Click += new System.EventHandler(this.NineBTN_Click);
            // 
            // BackSpaceBTN
            // 
            this.BackSpaceBTN.BackColor = System.Drawing.Color.LightSeaGreen;
            this.BackSpaceBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BackSpaceBTN.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.BackSpaceBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.BackSpaceBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.BackSpaceBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.BackSpaceBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackSpaceBTN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackSpaceBTN.ForeColor = System.Drawing.Color.White;
            this.BackSpaceBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackSpaceBTN.Location = new System.Drawing.Point(3, 174);
            this.BackSpaceBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.BackSpaceBTN.Name = "BackSpaceBTN";
            this.BackSpaceBTN.Size = new System.Drawing.Size(97, 51);
            this.BackSpaceBTN.TabIndex = 66;
            this.BackSpaceBTN.TabStop = false;
            this.BackSpaceBTN.Text = "مسح ";
            this.BackSpaceBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BackSpaceBTN.UseVisualStyleBackColor = false;
            this.BackSpaceBTN.Click += new System.EventHandler(this.BackSpaceBTN_Click);
            // 
            // OneBTN
            // 
            this.OneBTN.BackColor = System.Drawing.Color.LightSeaGreen;
            this.OneBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OneBTN.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.OneBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.OneBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.OneBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.OneBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OneBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OneBTN.ForeColor = System.Drawing.Color.White;
            this.OneBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OneBTN.Location = new System.Drawing.Point(3, 121);
            this.OneBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.OneBTN.Name = "OneBTN";
            this.OneBTN.Size = new System.Drawing.Size(97, 50);
            this.OneBTN.TabIndex = 64;
            this.OneBTN.TabStop = false;
            this.OneBTN.Text = "1";
            this.OneBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OneBTN.UseVisualStyleBackColor = false;
            this.OneBTN.Click += new System.EventHandler(this.NineBTN_Click);
            // 
            // TwoBTN
            // 
            this.TwoBTN.BackColor = System.Drawing.Color.LightSeaGreen;
            this.TwoBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TwoBTN.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.TwoBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.TwoBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.TwoBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.TwoBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TwoBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TwoBTN.ForeColor = System.Drawing.Color.White;
            this.TwoBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TwoBTN.Location = new System.Drawing.Point(104, 121);
            this.TwoBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.TwoBTN.Name = "TwoBTN";
            this.TwoBTN.Size = new System.Drawing.Size(97, 50);
            this.TwoBTN.TabIndex = 63;
            this.TwoBTN.TabStop = false;
            this.TwoBTN.Text = "2";
            this.TwoBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.TwoBTN.UseVisualStyleBackColor = false;
            this.TwoBTN.Click += new System.EventHandler(this.NineBTN_Click);
            // 
            // ThreeBTN
            // 
            this.ThreeBTN.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ThreeBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ThreeBTN.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.ThreeBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.ThreeBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.ThreeBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.ThreeBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ThreeBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThreeBTN.ForeColor = System.Drawing.Color.White;
            this.ThreeBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ThreeBTN.Location = new System.Drawing.Point(206, 121);
            this.ThreeBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.ThreeBTN.Name = "ThreeBTN";
            this.ThreeBTN.Size = new System.Drawing.Size(97, 50);
            this.ThreeBTN.TabIndex = 62;
            this.ThreeBTN.TabStop = false;
            this.ThreeBTN.Text = "3";
            this.ThreeBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ThreeBTN.UseVisualStyleBackColor = false;
            this.ThreeBTN.Click += new System.EventHandler(this.NineBTN_Click);
            // 
            // FourBTN
            // 
            this.FourBTN.BackColor = System.Drawing.Color.LightSeaGreen;
            this.FourBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.FourBTN.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.FourBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.FourBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.FourBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.FourBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FourBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FourBTN.ForeColor = System.Drawing.Color.White;
            this.FourBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FourBTN.Location = new System.Drawing.Point(3, 68);
            this.FourBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.FourBTN.Name = "FourBTN";
            this.FourBTN.Size = new System.Drawing.Size(97, 50);
            this.FourBTN.TabIndex = 61;
            this.FourBTN.TabStop = false;
            this.FourBTN.Text = "4";
            this.FourBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.FourBTN.UseVisualStyleBackColor = false;
            this.FourBTN.Click += new System.EventHandler(this.NineBTN_Click);
            // 
            // ItemComments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(761, 601);
            this.Controls.Add(this.NoBTN);
            this.Controls.Add(this.YesBTN);
            this.Controls.Add(this.NotesLabel);
            this.Controls.Add(this.QuickCommentTB);
            this.Controls.Add(this.CheckBoxes);
            this.Controls.Add(this.numpad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemComments";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = " ";
            this.TopMost = true;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MessageForm_KeyPress);
            this.numpad.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox numpad;
        private UButton FiveBTN;
        private UButton SixBTN;
        private UButton SevenBTN;
        private UButton EightBTN;
        private UButton NineBTN;
        private UButton ZeroBTN;
        private UButton BackSpaceBTN;
        private UButton OneBTN;
        private UButton TwoBTN;
        private UButton ThreeBTN;
        private UButton FourBTN;
        private UButton uButton1;
        private System.Windows.Forms.TextBox QuickCommentTB;
        private System.Windows.Forms.Label NotesLabel;
        public System.Windows.Forms.FlowLayoutPanel CheckBoxes;
        private System.Windows.Forms.Button NoBTN;
        private System.Windows.Forms.Button YesBTN;
    }
}