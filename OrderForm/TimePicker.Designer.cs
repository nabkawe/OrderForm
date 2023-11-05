namespace OrderForm
{
    partial class TimePicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimePicker));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.NoBTN = new System.Windows.Forms.Button();
            this.YesBTN = new System.Windows.Forms.Button();
            this.morningRadioButton = new System.Windows.Forms.RadioButton();
            this.noonRadioButton = new System.Windows.Forms.RadioButton();
            this.launchRadioButton = new System.Windows.Forms.RadioButton();
            this.nightRadioButton = new System.Windows.Forms.RadioButton();
            this.eveningRadioButton = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.Color.GhostWhite;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TimeLabel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Location = new System.Drawing.Point(19, 21);
            this.panel1.Margin = new System.Windows.Forms.Padding(10);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(447, 318);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.GhostWhite;
            this.label1.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(13, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 77);
            this.label1.TabIndex = 7;
            this.label1.Text = "صباحا";
            // 
            // TimeLabel
            // 
            this.TimeLabel.BackColor = System.Drawing.Color.GhostWhite;
            this.TimeLabel.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLabel.Location = new System.Drawing.Point(212, 226);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(222, 77);
            this.TimeLabel.TabIndex = 6;
            this.TimeLabel.Text = "00:00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(309, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "اختر الوقت:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(384, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "الدقيقة";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(382, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "الساعة";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "00",
            "05",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55"});
            this.comboBox2.Location = new System.Drawing.Point(13, 160);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(421, 50);
            this.comboBox2.TabIndex = 1;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.comboBox1.Location = new System.Drawing.Point(13, 81);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(421, 50);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
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
            this.NoBTN.Location = new System.Drawing.Point(278, 433);
            this.NoBTN.Margin = new System.Windows.Forms.Padding(20);
            this.NoBTN.Name = "NoBTN";
            this.NoBTN.Size = new System.Drawing.Size(133, 68);
            this.NoBTN.TabIndex = 2;
            this.NoBTN.Text = "تجاهل";
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
            this.YesBTN.Location = new System.Drawing.Point(79, 433);
            this.YesBTN.Margin = new System.Windows.Forms.Padding(20);
            this.YesBTN.Name = "YesBTN";
            this.YesBTN.Size = new System.Drawing.Size(186, 68);
            this.YesBTN.TabIndex = 1;
            this.YesBTN.Text = "موافق";
            this.YesBTN.UseVisualStyleBackColor = false;
            // 
            // morningRadioButton
            // 
            this.morningRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.morningRadioButton.BackColor = System.Drawing.Color.LightSeaGreen;
            this.morningRadioButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.morningRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.morningRadioButton.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.morningRadioButton.ForeColor = System.Drawing.Color.White;
            this.morningRadioButton.Location = new System.Drawing.Point(379, 352);
            this.morningRadioButton.Name = "morningRadioButton";
            this.morningRadioButton.Size = new System.Drawing.Size(85, 67);
            this.morningRadioButton.TabIndex = 3;
            this.morningRadioButton.Text = "صباحاً";
            this.morningRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.morningRadioButton.UseVisualStyleBackColor = false;
            this.morningRadioButton.CheckedChanged += new System.EventHandler(this.allRadioButton_CheckedChanged);
            // 
            // noonRadioButton
            // 
            this.noonRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.noonRadioButton.BackColor = System.Drawing.Color.LightSeaGreen;
            this.noonRadioButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.noonRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.noonRadioButton.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noonRadioButton.ForeColor = System.Drawing.Color.White;
            this.noonRadioButton.Location = new System.Drawing.Point(289, 352);
            this.noonRadioButton.Name = "noonRadioButton";
            this.noonRadioButton.Size = new System.Drawing.Size(85, 67);
            this.noonRadioButton.TabIndex = 4;
            this.noonRadioButton.Text = "ظهراً";
            this.noonRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.noonRadioButton.UseVisualStyleBackColor = false;
            this.noonRadioButton.CheckedChanged += new System.EventHandler(this.allRadioButton_CheckedChanged);
            // 
            // launchRadioButton
            // 
            this.launchRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.launchRadioButton.BackColor = System.Drawing.Color.LightSeaGreen;
            this.launchRadioButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.launchRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.launchRadioButton.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.launchRadioButton.ForeColor = System.Drawing.Color.White;
            this.launchRadioButton.Location = new System.Drawing.Point(199, 352);
            this.launchRadioButton.Name = "launchRadioButton";
            this.launchRadioButton.Size = new System.Drawing.Size(85, 67);
            this.launchRadioButton.TabIndex = 5;
            this.launchRadioButton.Text = "عصراً";
            this.launchRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.launchRadioButton.UseVisualStyleBackColor = false;
            this.launchRadioButton.CheckedChanged += new System.EventHandler(this.allRadioButton_CheckedChanged);
            // 
            // nightRadioButton
            // 
            this.nightRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.nightRadioButton.BackColor = System.Drawing.Color.LightSeaGreen;
            this.nightRadioButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.nightRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nightRadioButton.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nightRadioButton.ForeColor = System.Drawing.Color.White;
            this.nightRadioButton.Location = new System.Drawing.Point(19, 352);
            this.nightRadioButton.Name = "nightRadioButton";
            this.nightRadioButton.Size = new System.Drawing.Size(85, 67);
            this.nightRadioButton.TabIndex = 6;
            this.nightRadioButton.Text = "ليلاً";
            this.nightRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.nightRadioButton.UseVisualStyleBackColor = false;
            this.nightRadioButton.CheckedChanged += new System.EventHandler(this.allRadioButton_CheckedChanged);
            // 
            // eveningRadioButton
            // 
            this.eveningRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.eveningRadioButton.BackColor = System.Drawing.Color.LightSeaGreen;
            this.eveningRadioButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.eveningRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eveningRadioButton.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eveningRadioButton.ForeColor = System.Drawing.Color.White;
            this.eveningRadioButton.Location = new System.Drawing.Point(109, 352);
            this.eveningRadioButton.Name = "eveningRadioButton";
            this.eveningRadioButton.Size = new System.Drawing.Size(85, 67);
            this.eveningRadioButton.TabIndex = 7;
            this.eveningRadioButton.Text = "مساءً";
            this.eveningRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.eveningRadioButton.UseVisualStyleBackColor = false;
            this.eveningRadioButton.CheckedChanged += new System.EventHandler(this.allRadioButton_CheckedChanged);
            // 
            // TimePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(485, 512);
            this.Controls.Add(this.eveningRadioButton);
            this.Controls.Add(this.nightRadioButton);
            this.Controls.Add(this.launchRadioButton);
            this.Controls.Add(this.noonRadioButton);
            this.Controls.Add(this.morningRadioButton);
            this.Controls.Add(this.NoBTN);
            this.Controls.Add(this.YesBTN);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TimePicker";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = " ";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.TimePicker_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MessageForm_KeyPress);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button NoBTN;
        private System.Windows.Forms.Button YesBTN;
        private System.Windows.Forms.RadioButton morningRadioButton;
        private System.Windows.Forms.RadioButton noonRadioButton;
        private System.Windows.Forms.RadioButton launchRadioButton;
        private System.Windows.Forms.RadioButton nightRadioButton;
        private System.Windows.Forms.RadioButton eveningRadioButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label TimeLabel;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label1;
    }
}