namespace OrderForm
{

    partial class Orders
    {
        /// <summary>
        /// Required designer variabl
        /// 
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


        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Orders));
            this.rightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteBTN = new System.Windows.Forms.ToolStripMenuItem();
            this.sep = new System.Windows.Forms.ToolStripSeparator();
            this.commentBTN = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomComment = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemNameTag = new System.Windows.Forms.ToolStripMenuItem();
            this.SalahTMR = new System.Windows.Forms.Timer(this.components);
            this.InvoiceNumberID = new System.Windows.Forms.TextBox();
            this.ItemsPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SectionsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.AmountLBL = new System.Windows.Forms.Label();
            this.NameTB = new System.Windows.Forms.TextBox();
            this.MobileTB = new System.Windows.Forms.TextBox();
            this.dvItems = new System.Windows.Forms.DataGridView();
            this.PrintSave = new System.Windows.Forms.Button();
            this.CommentTB = new System.Windows.Forms.TextBox();
            this.MobileLBL = new System.Windows.Forms.Label();
            this.NameLBL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CommentLBL = new System.Windows.Forms.Label();
            this.OrdersPanel = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PrintedInvoices = new System.Windows.Forms.FlowLayoutPanel();
            this.sortType = new System.Windows.Forms.GroupBox();
            this.GroupSave = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AllDays = new System.Windows.Forms.RadioButton();
            this.History = new System.Windows.Forms.RadioButton();
            this.SearchLBL = new System.Windows.Forms.Label();
            this.Sat = new System.Windows.Forms.RadioButton();
            this.SearchTB = new System.Windows.Forms.TextBox();
            this.Sun = new System.Windows.Forms.RadioButton();
            this.Mon = new System.Windows.Forms.RadioButton();
            this.Fri = new System.Windows.Forms.RadioButton();
            this.Tue = new System.Windows.Forms.RadioButton();
            this.Thu = new System.Windows.Forms.RadioButton();
            this.Wed = new System.Windows.Forms.RadioButton();
            this.HeldPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.xLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.jahezPrice = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.HoldInvoice = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ItemCount = new System.Windows.Forms.Label();
            this.DeleteInvoice = new System.Windows.Forms.Button();
            this.SaveInvoice = new System.Windows.Forms.Button();
            this.DOWTB = new System.Windows.Forms.TextBox();
            this.TimeTB = new System.Windows.Forms.TextBox();
            this.AmountPriceLBL = new System.Windows.Forms.Label();
            this.InvoiceTypeOptions = new System.Windows.Forms.ToolStrip();
            this.TelButton = new System.Windows.Forms.ToolStripButton();
            this.ToGoButton = new System.Windows.Forms.ToolStripButton();
            this.DineButton = new System.Windows.Forms.ToolStripButton();
            this.AppsButton = new System.Windows.Forms.ToolStripButton();
            this.OrderStatus = new System.Windows.Forms.Button();
            this.DayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.HourPicker = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MinutesPicker = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TODPicker = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SalahTimes = new System.Windows.Forms.FlowLayoutPanel();
            this.MenuSelection = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.FastComment = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuTimeOut = new System.Windows.Forms.Timer(this.components);
            this.printComment = new System.Windows.Forms.PrintDialog();
            this.WhatsSend = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Search = new OrderForm.UnfocusableButton();
            this.unfocusableButton5 = new OrderForm.UnfocusableButton();
            this.ShowMenuBTN = new OrderForm.UnfocusableButton();
            this.unfocusableButton6 = new OrderForm.UnfocusableButton();
            this.OrderCut = new OrderForm.UnfocusableButton();
            this.LastOrder = new OrderForm.UnfocusableButton();
            this.RepeatOrder = new OrderForm.UnfocusableButton();
            this.NewBTN = new OrderForm.UnfocusableButton();
            this.DeleteTouchBTN = new OrderForm.UnfocusableButton();
            this.FiveBTN = new OrderForm.UnfocusableButton();
            this.SixBTN = new OrderForm.UnfocusableButton();
            this.SevenBTN = new OrderForm.UnfocusableButton();
            this.EightBTN = new OrderForm.UnfocusableButton();
            this.NineBTN = new OrderForm.UnfocusableButton();
            this.ZeroBTN = new OrderForm.UnfocusableButton();
            this.BackSpaceBTN = new OrderForm.UnfocusableButton();
            this.EnterBTN = new OrderForm.UnfocusableButton();
            this.UpBTN = new OrderForm.UnfocusableButton();
            this.DownBTN = new OrderForm.UnfocusableButton();
            this.OneBTN = new OrderForm.UnfocusableButton();
            this.TwoBTN = new OrderForm.UnfocusableButton();
            this.ThreeBTN = new OrderForm.UnfocusableButton();
            this.FourBTN = new OrderForm.UnfocusableButton();
            this.TimeInfo = new OrderForm.UnfocusableButton();
            this.WhatAppBTN = new OrderForm.UnfocusableButton();
            this.DayMenuBTN = new OrderForm.UnfocusableButton();
            this.MainMenu = new OrderForm.UnfocusableButton();
            this.OrdersPage = new OrderForm.UnfocusableButton();
            this.unfocusableButton3 = new OrderForm.UnfocusableButton();
            this.TimeLeftLBL = new OrderForm.UnfocusableButton();
            this.TimeTillCountdown = new OrderForm.UnfocusableButton();
            this.DhuhrLBL = new OrderForm.UnfocusableButton();
            this.DhuhrBTN = new OrderForm.UnfocusableButton();
            this.AsrLBL = new OrderForm.UnfocusableButton();
            this.AsrBTN = new OrderForm.UnfocusableButton();
            this.MaghribLBL = new OrderForm.UnfocusableButton();
            this.MaghribBTN = new OrderForm.UnfocusableButton();
            this.IshaLBL = new OrderForm.UnfocusableButton();
            this.IshaBTN = new OrderForm.UnfocusableButton();
            this.DateLBL = new OrderForm.UnfocusableButton();
            this.DayLBL = new OrderForm.UnfocusableButton();
            this.TimeButton = new OrderForm.UnfocusableButton();
            this.CopyInvoice = new OrderForm.UnfocusableButton();
            this.SettingsPage = new OrderForm.UnfocusableButton();
            this.rightClickMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvItems)).BeginInit();
            this.OrdersPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.sortType.SuspendLayout();
            this.InvoiceTypeOptions.SuspendLayout();
            this.SalahTimes.SuspendLayout();
            this.MenuSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // rightClickMenu
            // 
            this.rightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteBTN,
            this.sep,
            this.commentBTN,
            this.ItemNameTag});
            this.rightClickMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.rightClickMenu.Name = "rightClickMenu";
            this.rightClickMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rightClickMenu.ShowImageMargin = false;
            this.rightClickMenu.ShowItemToolTips = false;
            this.rightClickMenu.Size = new System.Drawing.Size(122, 76);
            // 
            // DeleteBTN
            // 
            this.DeleteBTN.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.DeleteBTN.AutoSize = false;
            this.DeleteBTN.BackColor = System.Drawing.Color.Red;
            this.DeleteBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.DeleteBTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DeleteBTN.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBTN.ForeColor = System.Drawing.Color.White;
            this.DeleteBTN.Name = "DeleteBTN";
            this.DeleteBTN.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DeleteBTN.Size = new System.Drawing.Size(180, 22);
            this.DeleteBTN.Text = "حذف المادة";
            this.DeleteBTN.Click += new System.EventHandler(this.DeleteBTN_Click);
            // 
            // sep
            // 
            this.sep.Name = "sep";
            this.sep.Size = new System.Drawing.Size(118, 6);
            // 
            // commentBTN
            // 
            this.commentBTN.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.commentBTN.DoubleClickEnabled = true;
            this.commentBTN.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CustomComment});
            this.commentBTN.Name = "commentBTN";
            this.commentBTN.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.commentBTN.Size = new System.Drawing.Size(121, 22);
            this.commentBTN.Text = "ملاحظة المادة:";
            this.commentBTN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CustomComment
            // 
            this.CustomComment.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.CustomComment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CustomComment.Name = "CustomComment";
            this.CustomComment.ShowShortcutKeys = false;
            this.CustomComment.Size = new System.Drawing.Size(151, 22);
            this.CustomComment.Text = "ملاحظة مخصصة";
            this.CustomComment.Click += new System.EventHandler(this.CustomComment_Click);
            // 
            // ItemNameTag
            // 
            this.ItemNameTag.Name = "ItemNameTag";
            this.ItemNameTag.Size = new System.Drawing.Size(121, 22);
            this.ItemNameTag.Click += new System.EventHandler(this.ItemNameTag_Click);
            // 
            // SalahTMR
            // 
            this.SalahTMR.Enabled = true;
            this.SalahTMR.Interval = 1000;
            this.SalahTMR.Tick += new System.EventHandler(this.SalahTMR_Tick);
            // 
            // InvoiceNumberID
            // 
            this.InvoiceNumberID.BackColor = System.Drawing.Color.GhostWhite;
            this.InvoiceNumberID.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvoiceNumberID.Location = new System.Drawing.Point(139, 2);
            this.InvoiceNumberID.Name = "InvoiceNumberID";
            this.InvoiceNumberID.ReadOnly = true;
            this.InvoiceNumberID.Size = new System.Drawing.Size(77, 33);
            this.InvoiceNumberID.TabIndex = 42;
            this.InvoiceNumberID.TabStop = false;
            this.InvoiceNumberID.Text = "0";
            // 
            // ItemsPanel1
            // 
            this.ItemsPanel1.BackColor = System.Drawing.Color.GhostWhite;
            this.ItemsPanel1.Location = new System.Drawing.Point(563, 36);
            this.ItemsPanel1.Name = "ItemsPanel1";
            this.ItemsPanel1.Size = new System.Drawing.Size(387, 578);
            this.ItemsPanel1.TabIndex = 22;
            // 
            // SectionsPanel
            // 
            this.SectionsPanel.BackColor = System.Drawing.Color.GhostWhite;
            this.SectionsPanel.Location = new System.Drawing.Point(459, 36);
            this.SectionsPanel.Name = "SectionsPanel";
            this.SectionsPanel.Size = new System.Drawing.Size(98, 529);
            this.SectionsPanel.TabIndex = 24;
            // 
            // AmountLBL
            // 
            this.AmountLBL.BackColor = System.Drawing.Color.GhostWhite;
            this.AmountLBL.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmountLBL.Location = new System.Drawing.Point(146, 566);
            this.AmountLBL.Name = "AmountLBL";
            this.AmountLBL.Size = new System.Drawing.Size(104, 39);
            this.AmountLBL.TabIndex = 28;
            this.AmountLBL.Text = "0";
            this.AmountLBL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AmountLBL.UseCompatibleTextRendering = true;
            // 
            // NameTB
            // 
            this.NameTB.AllowDrop = true;
            this.NameTB.BackColor = System.Drawing.Color.GhostWhite;
            this.NameTB.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.NameTB.HideSelection = false;
            this.NameTB.Location = new System.Drawing.Point(653, 673);
            this.NameTB.Margin = new System.Windows.Forms.Padding(0);
            this.NameTB.Name = "NameTB";
            this.NameTB.Size = new System.Drawing.Size(289, 43);
            this.NameTB.TabIndex = 26;
            this.NameTB.WordWrap = false;
            this.NameTB.TextChanged += new System.EventHandler(this.MobileTB_TextChanged);
            this.NameTB.DragDrop += new System.Windows.Forms.DragEventHandler(this.NameTB_DragDrop);
            this.NameTB.DragEnter += new System.Windows.Forms.DragEventHandler(this.NameTB_DragEnter);
            this.NameTB.Enter += new System.EventHandler(this.NameTB_Enter);
            this.NameTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MobileTB_KeyDown);
            this.NameTB.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MobileTB_PreviewKeyDown);
            // 
            // MobileTB
            // 
            this.MobileTB.AllowDrop = true;
            this.MobileTB.BackColor = System.Drawing.Color.GhostWhite;
            this.MobileTB.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.MobileTB.Location = new System.Drawing.Point(744, 624);
            this.MobileTB.Margin = new System.Windows.Forms.Padding(0);
            this.MobileTB.Name = "MobileTB";
            this.MobileTB.Size = new System.Drawing.Size(198, 43);
            this.MobileTB.TabIndex = 23;
            this.MobileTB.WordWrap = false;
            this.MobileTB.TextChanged += new System.EventHandler(this.MobileTB_TextChanged);
            this.MobileTB.DragDrop += new System.Windows.Forms.DragEventHandler(this.NameTB_DragDrop);
            this.MobileTB.DragEnter += new System.Windows.Forms.DragEventHandler(this.NameTB_DragEnter);
            this.MobileTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MobileTB_KeyDown);
            this.MobileTB.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MobileTB_PreviewKeyDown);
            // 
            // dvItems
            // 
            this.dvItems.AllowDrop = true;
            this.dvItems.AllowUserToAddRows = false;
            this.dvItems.AllowUserToOrderColumns = true;
            this.dvItems.AllowUserToResizeColumns = false;
            this.dvItems.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dvItems.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dvItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dvItems.CausesValidation = false;
            this.dvItems.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dvItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvItems.DefaultCellStyle = dataGridViewCellStyle6;
            this.dvItems.Location = new System.Drawing.Point(11, 36);
            this.dvItems.MultiSelect = false;
            this.dvItems.Name = "dvItems";
            this.dvItems.RowHeadersVisible = false;
            this.dvItems.RowHeadersWidth = 10;
            this.dvItems.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dvItems.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dvItems.RowTemplate.Height = 30;
            this.dvItems.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dvItems.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvItems.Size = new System.Drawing.Size(442, 529);
            this.dvItems.TabIndex = 30;
            this.dvItems.TabStop = false;
            this.dvItems.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DvItems_CellEndEdit);
            this.dvItems.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DvItems_CellEnter);
            this.dvItems.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DvItems_CellMouseClick);
            this.dvItems.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DvItems_DataError);
            this.dvItems.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DataGridView1_EditingControlShowing);
            this.dvItems.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.DvItems_RowsRemoved);
            this.dvItems.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DvItems_UserDeletingRow);
            this.dvItems.DragDrop += new System.Windows.Forms.DragEventHandler(this.DvItems_DragDrop);
            this.dvItems.DragOver += new System.Windows.Forms.DragEventHandler(this.dvItems_DragOver);
            this.dvItems.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DvItems_MouseDown);
            // 
            // PrintSave
            // 
            this.PrintSave.BackColor = System.Drawing.Color.SteelBlue;
            this.PrintSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrintSave.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintSave.ForeColor = System.Drawing.Color.White;
            this.PrintSave.Location = new System.Drawing.Point(174, 876);
            this.PrintSave.Name = "PrintSave";
            this.PrintSave.Size = new System.Drawing.Size(164, 47);
            this.PrintSave.TabIndex = 48;
            this.PrintSave.TabStop = false;
            this.PrintSave.Text = "طباعة و تحضير";
            this.PrintSave.UseVisualStyleBackColor = false;
            this.PrintSave.Click += new System.EventHandler(this.PrintSave_Click);
            this.PrintSave.MouseLeave += new System.EventHandler(this.PrintSave_MouseLeave);
            // 
            // CommentTB
            // 
            this.CommentTB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CommentTB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.CommentTB.BackColor = System.Drawing.Color.GhostWhite;
            this.CommentTB.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommentTB.Location = new System.Drawing.Point(653, 816);
            this.CommentTB.Margin = new System.Windows.Forms.Padding(0);
            this.CommentTB.Name = "CommentTB";
            this.CommentTB.Size = new System.Drawing.Size(289, 33);
            this.CommentTB.TabIndex = 150;
            this.CommentTB.WordWrap = false;
            this.CommentTB.TextChanged += new System.EventHandler(this.MobileTB_TextChanged);
            this.CommentTB.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MobileTB_PreviewKeyDown);
            // 
            // MobileLBL
            // 
            this.MobileLBL.AutoSize = true;
            this.MobileLBL.BackColor = System.Drawing.Color.GhostWhite;
            this.MobileLBL.Enabled = false;
            this.MobileLBL.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MobileLBL.ForeColor = System.Drawing.Color.Silver;
            this.MobileLBL.Location = new System.Drawing.Point(850, 636);
            this.MobileLBL.Name = "MobileLBL";
            this.MobileLBL.Size = new System.Drawing.Size(67, 17);
            this.MobileLBL.TabIndex = 50;
            this.MobileLBL.Text = "رقم العميل";
            // 
            // NameLBL
            // 
            this.NameLBL.AutoSize = true;
            this.NameLBL.BackColor = System.Drawing.Color.GhostWhite;
            this.NameLBL.Enabled = false;
            this.NameLBL.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLBL.ForeColor = System.Drawing.Color.Silver;
            this.NameLBL.Location = new System.Drawing.Point(847, 685);
            this.NameLBL.Name = "NameLBL";
            this.NameLBL.Size = new System.Drawing.Size(70, 17);
            this.NameLBL.TabIndex = 51;
            this.NameLBL.Text = "إسم العميل";
            this.NameLBL.Click += new System.EventHandler(this.NameLBL_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.GhostWhite;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(845, 733);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 52;
            this.label1.Text = "وقت الطلب";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // CommentLBL
            // 
            this.CommentLBL.AutoSize = true;
            this.CommentLBL.BackColor = System.Drawing.Color.GhostWhite;
            this.CommentLBL.Enabled = false;
            this.CommentLBL.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommentLBL.ForeColor = System.Drawing.Color.Silver;
            this.CommentLBL.Location = new System.Drawing.Point(826, 822);
            this.CommentLBL.Name = "CommentLBL";
            this.CommentLBL.Size = new System.Drawing.Size(91, 17);
            this.CommentLBL.TabIndex = 53;
            this.CommentLBL.Text = "ملاحظة  الطلب";
            this.CommentLBL.Click += new System.EventHandler(this.CommentLBL_Click);
            // 
            // OrdersPanel
            // 
            this.OrdersPanel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.OrdersPanel.Controls.Add(this.splitContainer1);
            this.OrdersPanel.Controls.Add(this.xLabel);
            this.OrdersPanel.Controls.Add(this.label3);
            this.OrdersPanel.Controls.Add(this.CommentLBL);
            this.OrdersPanel.Controls.Add(this.label1);
            this.OrdersPanel.Controls.Add(this.NameLBL);
            this.OrdersPanel.Controls.Add(this.MobileLBL);
            this.OrdersPanel.Controls.Add(this.ShowMenuBTN);
            this.OrdersPanel.Controls.Add(this.ItemsPanel1);
            this.OrdersPanel.Controls.Add(this.unfocusableButton6);
            this.OrdersPanel.Controls.Add(this.OrderCut);
            this.OrdersPanel.Controls.Add(this.jahezPrice);
            this.OrdersPanel.Controls.Add(this.AmountLBL);
            this.OrdersPanel.Controls.Add(this.dvItems);
            this.OrdersPanel.Controls.Add(this.LastOrder);
            this.OrdersPanel.Controls.Add(this.RepeatOrder);
            this.OrdersPanel.Controls.Add(this.checkBox1);
            this.OrdersPanel.Controls.Add(this.HoldInvoice);
            this.OrdersPanel.Controls.Add(this.label7);
            this.OrdersPanel.Controls.Add(this.label5);
            this.OrdersPanel.Controls.Add(this.label6);
            this.OrdersPanel.Controls.Add(this.ItemCount);
            this.OrdersPanel.Controls.Add(this.DeleteInvoice);
            this.OrdersPanel.Controls.Add(this.SaveInvoice);
            this.OrdersPanel.Controls.Add(this.NewBTN);
            this.OrdersPanel.Controls.Add(this.InvoiceNumberID);
            this.OrdersPanel.Controls.Add(this.PrintSave);
            this.OrdersPanel.Controls.Add(this.DeleteTouchBTN);
            this.OrdersPanel.Controls.Add(this.FiveBTN);
            this.OrdersPanel.Controls.Add(this.SixBTN);
            this.OrdersPanel.Controls.Add(this.SevenBTN);
            this.OrdersPanel.Controls.Add(this.EightBTN);
            this.OrdersPanel.Controls.Add(this.NineBTN);
            this.OrdersPanel.Controls.Add(this.ZeroBTN);
            this.OrdersPanel.Controls.Add(this.BackSpaceBTN);
            this.OrdersPanel.Controls.Add(this.EnterBTN);
            this.OrdersPanel.Controls.Add(this.UpBTN);
            this.OrdersPanel.Controls.Add(this.DownBTN);
            this.OrdersPanel.Controls.Add(this.OneBTN);
            this.OrdersPanel.Controls.Add(this.TwoBTN);
            this.OrdersPanel.Controls.Add(this.ThreeBTN);
            this.OrdersPanel.Controls.Add(this.FourBTN);
            this.OrdersPanel.Controls.Add(this.SectionsPanel);
            this.OrdersPanel.Controls.Add(this.DOWTB);
            this.OrdersPanel.Controls.Add(this.TimeTB);
            this.OrdersPanel.Controls.Add(this.TimeInfo);
            this.OrdersPanel.Controls.Add(this.CommentTB);
            this.OrdersPanel.Controls.Add(this.WhatAppBTN);
            this.OrdersPanel.Controls.Add(this.MobileTB);
            this.OrdersPanel.Controls.Add(this.NameTB);
            this.OrdersPanel.Controls.Add(this.DayMenuBTN);
            this.OrdersPanel.Controls.Add(this.AmountPriceLBL);
            this.OrdersPanel.Controls.Add(this.InvoiceTypeOptions);
            this.OrdersPanel.Controls.Add(this.OrderStatus);
            this.OrdersPanel.Location = new System.Drawing.Point(0, 70);
            this.OrdersPanel.Name = "OrdersPanel";
            this.OrdersPanel.Size = new System.Drawing.Size(961, 939);
            this.OrdersPanel.TabIndex = 21;
            this.OrdersPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.OrdersPanel_Paint);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.splitContainer1.Location = new System.Drawing.Point(2, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.LightSlateGray;
            this.splitContainer1.Panel2.Controls.Add(this.HeldPanel);
            this.splitContainer1.Panel2.Controls.Add(this.unfocusableButton5);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(958, 934);
            this.splitContainer1.SplitterDistance = 790;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 62;
            this.splitContainer1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.Controls.Add(this.PrintedInvoices);
            this.panel1.Controls.Add(this.Search);
            this.panel1.Controls.Add(this.sortType);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.AllDays);
            this.panel1.Controls.Add(this.History);
            this.panel1.Controls.Add(this.SearchLBL);
            this.panel1.Controls.Add(this.Sat);
            this.panel1.Controls.Add(this.SearchTB);
            this.panel1.Controls.Add(this.Sun);
            this.panel1.Controls.Add(this.Mon);
            this.panel1.Controls.Add(this.Fri);
            this.panel1.Controls.Add(this.Tue);
            this.panel1.Controls.Add(this.Thu);
            this.panel1.Controls.Add(this.Wed);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(958, 790);
            this.panel1.TabIndex = 51;
            this.panel1.Visible = false;
            this.panel1.VisibleChanged += new System.EventHandler(this.panel1_VisibleChanged);
            // 
            // PrintedInvoices
            // 
            this.PrintedInvoices.AllowDrop = true;
            this.PrintedInvoices.AutoScroll = true;
            this.PrintedInvoices.BackColor = System.Drawing.Color.GhostWhite;
            this.PrintedInvoices.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.PrintedInvoices.Location = new System.Drawing.Point(-2, 73);
            this.PrintedInvoices.Name = "PrintedInvoices";
            this.PrintedInvoices.Size = new System.Drawing.Size(963, 718);
            this.PrintedInvoices.TabIndex = 41;
            // 
            // sortType
            // 
            this.sortType.Controls.Add(this.GroupSave);
            this.sortType.Controls.Add(this.label8);
            this.sortType.Location = new System.Drawing.Point(54, -2);
            this.sortType.Name = "sortType";
            this.sortType.Size = new System.Drawing.Size(143, 67);
            this.sortType.TabIndex = 59;
            this.sortType.TabStop = false;
            // 
            // GroupSave
            // 
            this.GroupSave.Appearance = System.Windows.Forms.Appearance.Button;
            this.GroupSave.BackColor = System.Drawing.Color.GhostWhite;
            this.GroupSave.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.GroupSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GroupSave.Location = new System.Drawing.Point(4, 10);
            this.GroupSave.Name = "GroupSave";
            this.GroupSave.Size = new System.Drawing.Size(135, 23);
            this.GroupSave.TabIndex = 63;
            this.GroupSave.Text = "وضع التخزين المتعدد";
            this.GroupSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.GroupSave.UseVisualStyleBackColor = false;
            this.GroupSave.CheckedChanged += new System.EventHandler(this.GroupSave_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(10, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 26);
            this.label8.TabIndex = 60;
            this.label8.Text = "اختر الفواتير التي تريد\r\n تخزينها بالزر الأيمن للفأرة";
            this.label8.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(828, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 13);
            this.label4.TabIndex = 58;
            this.label4.Text = "الفواتير المطبوعة للتحضير:";
            // 
            // AllDays
            // 
            this.AllDays.Appearance = System.Windows.Forms.Appearance.Button;
            this.AllDays.BackColor = System.Drawing.Color.GhostWhite;
            this.AllDays.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.AllDays.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.AllDays.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.AllDays.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.AllDays.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AllDays.Location = new System.Drawing.Point(199, 5);
            this.AllDays.Name = "AllDays";
            this.AllDays.Size = new System.Drawing.Size(65, 52);
            this.AllDays.TabIndex = 50;
            this.AllDays.TabStop = true;
            this.AllDays.Text = "جميع الطلبات";
            this.AllDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AllDays.UseVisualStyleBackColor = false;
            this.AllDays.CheckedChanged += new System.EventHandler(this.Fri_CheckedChanged);
            // 
            // History
            // 
            this.History.Appearance = System.Windows.Forms.Appearance.Button;
            this.History.BackColor = System.Drawing.Color.GhostWhite;
            this.History.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.History.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.History.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.History.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.History.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.History.Location = new System.Drawing.Point(2, 5);
            this.History.Name = "History";
            this.History.Size = new System.Drawing.Size(50, 52);
            this.History.TabIndex = 53;
            this.History.TabStop = true;
            this.History.Text = "التاريخ";
            this.History.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.History.UseVisualStyleBackColor = false;
            this.History.CheckedChanged += new System.EventHandler(this.Fri_CheckedChanged);
            // 
            // SearchLBL
            // 
            this.SearchLBL.AutoSize = true;
            this.SearchLBL.ForeColor = System.Drawing.Color.White;
            this.SearchLBL.Location = new System.Drawing.Point(890, -3);
            this.SearchLBL.Name = "SearchLBL";
            this.SearchLBL.Size = new System.Drawing.Size(66, 13);
            this.SearchLBL.TabIndex = 51;
            this.SearchLBL.Text = "بحث الفواتير:";
            // 
            // Sat
            // 
            this.Sat.Appearance = System.Windows.Forms.Appearance.Button;
            this.Sat.BackColor = System.Drawing.Color.GhostWhite;
            this.Sat.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Sat.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.Sat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Sat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Sat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Sat.Location = new System.Drawing.Point(710, 10);
            this.Sat.Name = "Sat";
            this.Sat.Size = new System.Drawing.Size(74, 42);
            this.Sat.TabIndex = 49;
            this.Sat.TabStop = true;
            this.Sat.Text = "السبت";
            this.Sat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Sat.UseVisualStyleBackColor = false;
            this.Sat.CheckedChanged += new System.EventHandler(this.Fri_CheckedChanged);
            // 
            // SearchTB
            // 
            this.SearchTB.BackColor = System.Drawing.Color.GhostWhite;
            this.SearchTB.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchTB.Location = new System.Drawing.Point(786, 14);
            this.SearchTB.Name = "SearchTB";
            this.SearchTB.Size = new System.Drawing.Size(168, 35);
            this.SearchTB.TabIndex = 42;
            this.SearchTB.TextChanged += new System.EventHandler(this.SearchTB_TextChanged);
            this.SearchTB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchTB_KeyUp);
            // 
            // Sun
            // 
            this.Sun.Appearance = System.Windows.Forms.Appearance.Button;
            this.Sun.BackColor = System.Drawing.Color.GhostWhite;
            this.Sun.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Sun.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.Sun.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Sun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Sun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Sun.Location = new System.Drawing.Point(636, 10);
            this.Sun.Name = "Sun";
            this.Sun.Size = new System.Drawing.Size(74, 42);
            this.Sun.TabIndex = 48;
            this.Sun.TabStop = true;
            this.Sun.Text = "الأحد";
            this.Sun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Sun.UseVisualStyleBackColor = false;
            this.Sun.CheckedChanged += new System.EventHandler(this.Fri_CheckedChanged);
            // 
            // Mon
            // 
            this.Mon.Appearance = System.Windows.Forms.Appearance.Button;
            this.Mon.BackColor = System.Drawing.Color.GhostWhite;
            this.Mon.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Mon.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.Mon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Mon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Mon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Mon.Location = new System.Drawing.Point(562, 10);
            this.Mon.Name = "Mon";
            this.Mon.Size = new System.Drawing.Size(74, 42);
            this.Mon.TabIndex = 47;
            this.Mon.TabStop = true;
            this.Mon.Text = "الإثنين";
            this.Mon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Mon.UseVisualStyleBackColor = false;
            this.Mon.CheckedChanged += new System.EventHandler(this.Fri_CheckedChanged);
            // 
            // Fri
            // 
            this.Fri.Appearance = System.Windows.Forms.Appearance.Button;
            this.Fri.BackColor = System.Drawing.Color.GhostWhite;
            this.Fri.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Fri.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.Fri.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Fri.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Fri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Fri.Location = new System.Drawing.Point(266, 10);
            this.Fri.Name = "Fri";
            this.Fri.Size = new System.Drawing.Size(74, 42);
            this.Fri.TabIndex = 43;
            this.Fri.TabStop = true;
            this.Fri.Text = "الجمعة";
            this.Fri.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Fri.UseVisualStyleBackColor = false;
            this.Fri.CheckedChanged += new System.EventHandler(this.Fri_CheckedChanged);
            this.Fri.Click += new System.EventHandler(this.Fri_Click);
            // 
            // Tue
            // 
            this.Tue.Appearance = System.Windows.Forms.Appearance.Button;
            this.Tue.BackColor = System.Drawing.Color.GhostWhite;
            this.Tue.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Tue.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.Tue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Tue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Tue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Tue.Location = new System.Drawing.Point(488, 10);
            this.Tue.Name = "Tue";
            this.Tue.Size = new System.Drawing.Size(74, 42);
            this.Tue.TabIndex = 46;
            this.Tue.TabStop = true;
            this.Tue.Text = "الثلاثاء";
            this.Tue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Tue.UseVisualStyleBackColor = false;
            this.Tue.CheckedChanged += new System.EventHandler(this.Fri_CheckedChanged);
            // 
            // Thu
            // 
            this.Thu.Appearance = System.Windows.Forms.Appearance.Button;
            this.Thu.BackColor = System.Drawing.Color.GhostWhite;
            this.Thu.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Thu.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.Thu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Thu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Thu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Thu.Location = new System.Drawing.Point(340, 10);
            this.Thu.Name = "Thu";
            this.Thu.Size = new System.Drawing.Size(74, 42);
            this.Thu.TabIndex = 44;
            this.Thu.TabStop = true;
            this.Thu.Text = "الخميس";
            this.Thu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Thu.UseVisualStyleBackColor = false;
            this.Thu.CheckedChanged += new System.EventHandler(this.Fri_CheckedChanged);
            // 
            // Wed
            // 
            this.Wed.Appearance = System.Windows.Forms.Appearance.Button;
            this.Wed.BackColor = System.Drawing.Color.GhostWhite;
            this.Wed.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Wed.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.Wed.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Wed.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Wed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Wed.Location = new System.Drawing.Point(414, 10);
            this.Wed.Name = "Wed";
            this.Wed.Size = new System.Drawing.Size(74, 42);
            this.Wed.TabIndex = 45;
            this.Wed.TabStop = true;
            this.Wed.Text = "الأربعاء";
            this.Wed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Wed.UseVisualStyleBackColor = false;
            this.Wed.CheckedChanged += new System.EventHandler(this.Fri_CheckedChanged);
            // 
            // HeldPanel
            // 
            this.HeldPanel.AutoScroll = true;
            this.HeldPanel.BackColor = System.Drawing.Color.LightSlateGray;
            this.HeldPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.HeldPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.HeldPanel.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.HeldPanel.Location = new System.Drawing.Point(83, 0);
            this.HeldPanel.Name = "HeldPanel";
            this.HeldPanel.Size = new System.Drawing.Size(875, 143);
            this.HeldPanel.TabIndex = 40;
            this.HeldPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.HeldPanel_Paint);
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.BackColor = System.Drawing.Color.GhostWhite;
            this.xLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel.Location = new System.Drawing.Point(920, 732);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(11, 21);
            this.xLabel.TabIndex = 0;
            this.xLabel.Text = "x";
            this.xLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xLabel.UseCompatibleTextRendering = true;
            this.xLabel.Click += new System.EventHandler(this.xLabel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.GhostWhite;
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(852, 781);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 103;
            this.label3.Text = "يوم الطلب";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // jahezPrice
            // 
            this.jahezPrice.BackColor = System.Drawing.Color.Red;
            this.jahezPrice.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jahezPrice.ForeColor = System.Drawing.Color.White;
            this.jahezPrice.Location = new System.Drawing.Point(145, 566);
            this.jahezPrice.Name = "jahezPrice";
            this.jahezPrice.Size = new System.Drawing.Size(106, 39);
            this.jahezPrice.TabIndex = 168;
            this.jahezPrice.Text = "0";
            this.jahezPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.jahezPrice.UseCompatibleTextRendering = true;
            this.jahezPrice.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(86, 854);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(85, 15);
            this.checkBox1.TabIndex = 166;
            this.checkBox1.Text = "طباعة أمر التسليم";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // HoldInvoice
            // 
            this.HoldInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.HoldInvoice.Cursor = System.Windows.Forms.Cursors.Default;
            this.HoldInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HoldInvoice.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HoldInvoice.ForeColor = System.Drawing.Color.White;
            this.HoldInvoice.Location = new System.Drawing.Point(288, 3);
            this.HoldInvoice.Name = "HoldInvoice";
            this.HoldInvoice.Size = new System.Drawing.Size(156, 32);
            this.HoldInvoice.TabIndex = 163;
            this.HoldInvoice.TabStop = false;
            this.HoldInvoice.Text = "تعليق الطلب";
            this.HoldInvoice.UseVisualStyleBackColor = false;
            this.HoldInvoice.Click += new System.EventHandler(this.HoldInvoice_click);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.GhostWhite;
            this.label7.Location = new System.Drawing.Point(459, 603);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 26);
            this.label7.TabIndex = 160;
            this.label7.Text = "V";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.GhostWhite;
            this.label5.Location = new System.Drawing.Point(459, 573);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 26);
            this.label5.TabIndex = 159;
            this.label5.Text = "^";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.Label5_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.GhostWhite;
            this.label6.Location = new System.Drawing.Point(72, 570);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 26);
            this.label6.TabIndex = 158;
            this.label6.Text = "عدد المواد";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ItemCount
            // 
            this.ItemCount.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ItemCount.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.ItemCount.ForeColor = System.Drawing.Color.GhostWhite;
            this.ItemCount.Location = new System.Drawing.Point(24, 565);
            this.ItemCount.Name = "ItemCount";
            this.ItemCount.Size = new System.Drawing.Size(81, 34);
            this.ItemCount.TabIndex = 157;
            this.ItemCount.Text = "0";
            this.ItemCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DeleteInvoice
            // 
            this.DeleteInvoice.BackColor = System.Drawing.Color.White;
            this.DeleteInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteInvoice.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteInvoice.ForeColor = System.Drawing.Color.Red;
            this.DeleteInvoice.Location = new System.Drawing.Point(14, 875);
            this.DeleteInvoice.Name = "DeleteInvoice";
            this.DeleteInvoice.Size = new System.Drawing.Size(52, 47);
            this.DeleteInvoice.TabIndex = 154;
            this.DeleteInvoice.TabStop = false;
            this.DeleteInvoice.Text = "X";
            this.DeleteInvoice.UseVisualStyleBackColor = false;
            this.DeleteInvoice.Click += new System.EventHandler(this.DeleteInvoice_Click);
            // 
            // SaveInvoice
            // 
            this.SaveInvoice.BackColor = System.Drawing.Color.White;
            this.SaveInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveInvoice.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveInvoice.ForeColor = System.Drawing.Color.Blue;
            this.SaveInvoice.Location = new System.Drawing.Point(79, 875);
            this.SaveInvoice.Name = "SaveInvoice";
            this.SaveInvoice.Size = new System.Drawing.Size(91, 48);
            this.SaveInvoice.TabIndex = 153;
            this.SaveInvoice.TabStop = false;
            this.SaveInvoice.Text = "تخزين الطلب";
            this.SaveInvoice.UseVisualStyleBackColor = false;
            this.SaveInvoice.Click += new System.EventHandler(this.SaveInvoice_Click);
            this.SaveInvoice.MouseLeave += new System.EventHandler(this.SaveInvoice_MouseLeave);
            // 
            // DOWTB
            // 
            this.DOWTB.BackColor = System.Drawing.Color.GhostWhite;
            this.DOWTB.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.DOWTB.Location = new System.Drawing.Point(829, 769);
            this.DOWTB.Margin = new System.Windows.Forms.Padding(0);
            this.DOWTB.Name = "DOWTB";
            this.DOWTB.Size = new System.Drawing.Size(113, 43);
            this.DOWTB.TabIndex = 104;
            this.DOWTB.WordWrap = false;
            this.DOWTB.TextChanged += new System.EventHandler(this.DOWTB_TextChanged);
            this.DOWTB.DoubleClick += new System.EventHandler(this.DOWTB_DoubleClick);
            this.DOWTB.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MobileTB_PreviewKeyDown);
            // 
            // TimeTB
            // 
            this.TimeTB.BackColor = System.Drawing.Color.GhostWhite;
            this.TimeTB.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.TimeTB.Location = new System.Drawing.Point(829, 722);
            this.TimeTB.Margin = new System.Windows.Forms.Padding(0);
            this.TimeTB.Name = "TimeTB";
            this.TimeTB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TimeTB.Size = new System.Drawing.Size(113, 43);
            this.TimeTB.TabIndex = 100;
            this.TimeTB.WordWrap = false;
            this.TimeTB.TextChanged += new System.EventHandler(this.TimeTB_TextChanged);
            this.TimeTB.DoubleClick += new System.EventHandler(this.TimeTB_DoubleClick);
            this.TimeTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TimeTB_KeyPress);
            this.TimeTB.Leave += new System.EventHandler(this.TimeTB_Leave);
            this.TimeTB.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MobileTB_PreviewKeyDown);
            // 
            // AmountPriceLBL
            // 
            this.AmountPriceLBL.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmountPriceLBL.ForeColor = System.Drawing.Color.GhostWhite;
            this.AmountPriceLBL.Location = new System.Drawing.Point(22, 564);
            this.AmountPriceLBL.Name = "AmountPriceLBL";
            this.AmountPriceLBL.Size = new System.Drawing.Size(300, 39);
            this.AmountPriceLBL.TabIndex = 156;
            this.AmountPriceLBL.Text = "     السعر";
            this.AmountPriceLBL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InvoiceTypeOptions
            // 
            this.InvoiceTypeOptions.AllowMerge = false;
            this.InvoiceTypeOptions.AutoSize = false;
            this.InvoiceTypeOptions.BackColor = System.Drawing.Color.GhostWhite;
            this.InvoiceTypeOptions.CanOverflow = false;
            this.InvoiceTypeOptions.Dock = System.Windows.Forms.DockStyle.None;
            this.InvoiceTypeOptions.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvoiceTypeOptions.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.InvoiceTypeOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TelButton,
            this.ToGoButton,
            this.DineButton,
            this.AppsButton});
            this.InvoiceTypeOptions.Location = new System.Drawing.Point(354, 874);
            this.InvoiceTypeOptions.Name = "InvoiceTypeOptions";
            this.InvoiceTypeOptions.Padding = new System.Windows.Forms.Padding(0);
            this.InvoiceTypeOptions.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.InvoiceTypeOptions.ShowItemToolTips = false;
            this.InvoiceTypeOptions.Size = new System.Drawing.Size(250, 56);
            this.InvoiceTypeOptions.TabIndex = 172;
            // 
            // TelButton
            // 
            this.TelButton.AutoSize = false;
            this.TelButton.Checked = true;
            this.TelButton.CheckOnClick = true;
            this.TelButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TelButton.ForeColor = System.Drawing.Color.LightSlateGray;
            this.TelButton.Image = ((System.Drawing.Image)(resources.GetObject("TelButton.Image")));
            this.TelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TelButton.Name = "TelButton";
            this.TelButton.Size = new System.Drawing.Size(60, 52);
            this.TelButton.Text = "هاتف";
            this.TelButton.ToolTipText = "هاتف";
            this.TelButton.Click += new System.EventHandler(this.TelButton_Click_1);
            // 
            // ToGoButton
            // 
            this.ToGoButton.AutoSize = false;
            this.ToGoButton.CheckOnClick = true;
            this.ToGoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToGoButton.ForeColor = System.Drawing.Color.LightSlateGray;
            this.ToGoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToGoButton.Name = "ToGoButton";
            this.ToGoButton.Size = new System.Drawing.Size(60, 52);
            this.ToGoButton.Text = "سفري";
            this.ToGoButton.Click += new System.EventHandler(this.TelButton_Click_1);
            // 
            // DineButton
            // 
            this.DineButton.AutoSize = false;
            this.DineButton.AutoToolTip = false;
            this.DineButton.CheckOnClick = true;
            this.DineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DineButton.ForeColor = System.Drawing.Color.LightSlateGray;
            this.DineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DineButton.Name = "DineButton";
            this.DineButton.Size = new System.Drawing.Size(60, 52);
            this.DineButton.Text = "محلي";
            this.DineButton.ToolTipText = "محلي";
            this.DineButton.Click += new System.EventHandler(this.TelButton_Click_1);
            // 
            // AppsButton
            // 
            this.AppsButton.AutoSize = false;
            this.AppsButton.CheckOnClick = true;
            this.AppsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AppsButton.ForeColor = System.Drawing.Color.LightSlateGray;
            this.AppsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AppsButton.Name = "AppsButton";
            this.AppsButton.Size = new System.Drawing.Size(60, 52);
            this.AppsButton.Text = "تطبيقات";
            this.AppsButton.Click += new System.EventHandler(this.TelButton_Click_1);
            // 
            // OrderStatus
            // 
            this.OrderStatus.BackColor = System.Drawing.Color.White;
            this.OrderStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OrderStatus.Location = new System.Drawing.Point(472, 816);
            this.OrderStatus.Name = "OrderStatus";
            this.OrderStatus.Size = new System.Drawing.Size(97, 36);
            this.OrderStatus.TabIndex = 151;
            this.OrderStatus.TabStop = false;
            this.OrderStatus.UseVisualStyleBackColor = false;
            this.OrderStatus.Visible = false;
            this.OrderStatus.TextChanged += new System.EventHandler(this.MobileTB_TextChanged);
            // 
            // DayMenu
            // 
            this.DayMenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DayMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.DayMenu.Name = "DayMenu";
            this.DayMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DayMenu.ShowImageMargin = false;
            this.DayMenu.ShowItemToolTips = false;
            this.DayMenu.Size = new System.Drawing.Size(36, 4);
            this.DayMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.DayMenu_ItemClicked);
            // 
            // HourPicker
            // 
            this.HourPicker.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HourPicker.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.HourPicker.Name = "DayMenu";
            this.HourPicker.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.HourPicker.ShowImageMargin = false;
            this.HourPicker.ShowItemToolTips = false;
            this.HourPicker.Size = new System.Drawing.Size(36, 4);
            this.HourPicker.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.TimePicker_ItemClicked);
            // 
            // MinutesPicker
            // 
            this.MinutesPicker.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinutesPicker.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.MinutesPicker.Name = "DayMenu";
            this.MinutesPicker.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MinutesPicker.ShowImageMargin = false;
            this.MinutesPicker.ShowItemToolTips = false;
            this.MinutesPicker.Size = new System.Drawing.Size(36, 4);
            this.MinutesPicker.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MinutesPicker_ItemClicked);
            // 
            // TODPicker
            // 
            this.TODPicker.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TODPicker.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.TODPicker.Name = "DayMenu";
            this.TODPicker.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TODPicker.ShowImageMargin = false;
            this.TODPicker.ShowItemToolTips = false;
            this.TODPicker.Size = new System.Drawing.Size(36, 4);
            this.TODPicker.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.TODPicker_ItemClicked);
            // 
            // SalahTimes
            // 
            this.SalahTimes.Controls.Add(this.unfocusableButton3);
            this.SalahTimes.Controls.Add(this.TimeLeftLBL);
            this.SalahTimes.Controls.Add(this.TimeTillCountdown);
            this.SalahTimes.Controls.Add(this.DhuhrLBL);
            this.SalahTimes.Controls.Add(this.DhuhrBTN);
            this.SalahTimes.Controls.Add(this.AsrLBL);
            this.SalahTimes.Controls.Add(this.AsrBTN);
            this.SalahTimes.Controls.Add(this.MaghribLBL);
            this.SalahTimes.Controls.Add(this.MaghribBTN);
            this.SalahTimes.Controls.Add(this.IshaLBL);
            this.SalahTimes.Controls.Add(this.IshaBTN);
            this.SalahTimes.Controls.Add(this.DateLBL);
            this.SalahTimes.Controls.Add(this.DayLBL);
            this.SalahTimes.Controls.Add(this.TimeButton);
            this.SalahTimes.Controls.Add(this.CopyInvoice);
            this.SalahTimes.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.SalahTimes.Location = new System.Drawing.Point(216, 5);
            this.SalahTimes.Name = "SalahTimes";
            this.SalahTimes.Size = new System.Drawing.Size(710, 64);
            this.SalahTimes.TabIndex = 25;
            // 
            // MenuSelection
            // 
            this.MenuSelection.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuSelection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.MenuSelection.Name = "MenuSelection";
            this.MenuSelection.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MenuSelection.Size = new System.Drawing.Size(252, 34);
            this.MenuSelection.Opening += new System.ComponentModel.CancelEventHandler(this.MenuSelection_Opening);
            this.MenuSelection.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuSelection_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(251, 30);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // FastComment
            // 
            this.FastComment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FastComment.Name = "FastComment";
            this.FastComment.ShowImageMargin = false;
            this.FastComment.ShowItemToolTips = false;
            this.FastComment.Size = new System.Drawing.Size(36, 4);
            this.FastComment.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.FastComment_Closed);
            this.FastComment.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.FastComment_ItemClicked);
            // 
            // MenuTimeOut
            // 
            this.MenuTimeOut.Interval = 60000;
            this.MenuTimeOut.Tick += new System.EventHandler(this.MenuTimeOut_Tick);
            // 
            // printComment
            // 
            this.printComment.UseEXDialog = true;
            // 
            // WhatsSend
            // 
            this.WhatsSend.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WhatsSend.Name = "FastComment";
            this.WhatsSend.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.WhatsSend.ShowImageMargin = false;
            this.WhatsSend.ShowItemToolTips = false;
            this.WhatsSend.Size = new System.Drawing.Size(36, 4);
            this.WhatsSend.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.WhatsSend_ItemClicked);
            // 
            // Search
            // 
            this.Search.BackColor = System.Drawing.Color.White;
            this.Search.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Search.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.Search.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.Search.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Search.Location = new System.Drawing.Point(786, 13);
            this.Search.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(39, 37);
            this.Search.TabIndex = 41;
            this.Search.Text = "بحث";
            this.Search.UseVisualStyleBackColor = false;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // unfocusableButton5
            // 
            this.unfocusableButton5.BackColor = System.Drawing.Color.GhostWhite;
            this.unfocusableButton5.Dock = System.Windows.Forms.DockStyle.Left;
            this.unfocusableButton5.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.unfocusableButton5.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.unfocusableButton5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.unfocusableButton5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.unfocusableButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unfocusableButton5.Font = new System.Drawing.Font("Tahoma", 7F);
            this.unfocusableButton5.Location = new System.Drawing.Point(0, 0);
            this.unfocusableButton5.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.unfocusableButton5.Name = "unfocusableButton5";
            this.unfocusableButton5.Size = new System.Drawing.Size(83, 143);
            this.unfocusableButton5.TabIndex = 61;
            this.unfocusableButton5.Text = "فتح الفواتير المعلقة (غير المطبوعة)";
            this.unfocusableButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.unfocusableButton5.UseCompatibleTextRendering = true;
            this.unfocusableButton5.UseVisualStyleBackColor = false;
            this.unfocusableButton5.Click += new System.EventHandler(this.unfocusableButton5_Click_1);
            // 
            // ShowMenuBTN
            // 
            this.ShowMenuBTN.BackColor = System.Drawing.Color.White;
            this.ShowMenuBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ShowMenuBTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ShowMenuBTN.FlatAppearance.BorderSize = 0;
            this.ShowMenuBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.ShowMenuBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.ShowMenuBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ShowMenuBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowMenuBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowMenuBTN.Image = global::OrderForm.Properties.Resources.bill_receipt_icon__1_1;
            this.ShowMenuBTN.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ShowMenuBTN.Location = new System.Drawing.Point(385, 816);
            this.ShowMenuBTN.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.ShowMenuBTN.Name = "ShowMenuBTN";
            this.ShowMenuBTN.Size = new System.Drawing.Size(188, 36);
            this.ShowMenuBTN.TabIndex = 171;
            this.ShowMenuBTN.Text = "عرض الفاتورة";
            this.ShowMenuBTN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ShowMenuBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.ShowMenuBTN.UseCompatibleTextRendering = true;
            this.ShowMenuBTN.UseVisualStyleBackColor = false;
            this.ShowMenuBTN.Click += new System.EventHandler(this.ShowMenuBTN_Click);
            // 
            // unfocusableButton6
            // 
            this.unfocusableButton6.BackColor = System.Drawing.Color.White;
            this.unfocusableButton6.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.unfocusableButton6.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.unfocusableButton6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.unfocusableButton6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.unfocusableButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unfocusableButton6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unfocusableButton6.Location = new System.Drawing.Point(766, 853);
            this.unfocusableButton6.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.unfocusableButton6.Name = "unfocusableButton6";
            this.unfocusableButton6.Size = new System.Drawing.Size(83, 27);
            this.unfocusableButton6.TabIndex = 170;
            this.unfocusableButton6.Text = " الطلب منشف ";
            this.unfocusableButton6.UseCompatibleTextRendering = true;
            this.unfocusableButton6.UseVisualStyleBackColor = false;
            this.unfocusableButton6.Click += new System.EventHandler(this.OrderCut_Click);
            // 
            // OrderCut
            // 
            this.OrderCut.BackColor = System.Drawing.Color.White;
            this.OrderCut.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.OrderCut.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.OrderCut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.OrderCut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.OrderCut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OrderCut.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderCut.Location = new System.Drawing.Point(852, 853);
            this.OrderCut.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.OrderCut.Name = "OrderCut";
            this.OrderCut.Size = new System.Drawing.Size(88, 27);
            this.OrderCut.TabIndex = 169;
            this.OrderCut.Text = " الطلب مقطع ";
            this.OrderCut.UseCompatibleTextRendering = true;
            this.OrderCut.UseVisualStyleBackColor = false;
            this.OrderCut.Click += new System.EventHandler(this.OrderCut_Click);
            // 
            // LastOrder
            // 
            this.LastOrder.BackColor = System.Drawing.Color.White;
            this.LastOrder.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.LastOrder.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.LastOrder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.LastOrder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.LastOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LastOrder.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastOrder.Location = new System.Drawing.Point(572, 673);
            this.LastOrder.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.LastOrder.Name = "LastOrder";
            this.LastOrder.Size = new System.Drawing.Size(76, 43);
            this.LastOrder.TabIndex = 167;
            this.LastOrder.Text = "إدخال آخر طلب";
            this.LastOrder.UseCompatibleTextRendering = true;
            this.LastOrder.UseVisualStyleBackColor = false;
            this.LastOrder.Visible = false;
            this.LastOrder.Click += new System.EventHandler(this.LastOrder_Click);
            // 
            // RepeatOrder
            // 
            this.RepeatOrder.BackColor = System.Drawing.Color.DarkTurquoise;
            this.RepeatOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RepeatOrder.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RepeatOrder.ForeColor = System.Drawing.Color.White;
            this.RepeatOrder.Location = new System.Drawing.Point(193, 834);
            this.RepeatOrder.Name = "RepeatOrder";
            this.RepeatOrder.Size = new System.Drawing.Size(125, 35);
            this.RepeatOrder.TabIndex = 0;
            this.RepeatOrder.Text = "إعادة تحضير الطلب";
            this.RepeatOrder.UseVisualStyleBackColor = false;
            this.RepeatOrder.Visible = false;
            this.RepeatOrder.Click += new System.EventHandler(this.RepeatOrder_Click);
            // 
            // NewBTN
            // 
            this.NewBTN.BackColor = System.Drawing.Color.White;
            this.NewBTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.NewBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.NewBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.NewBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.NewBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewBTN.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.NewBTN.Location = new System.Drawing.Point(38, 3);
            this.NewBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.NewBTN.Name = "NewBTN";
            this.NewBTN.Size = new System.Drawing.Size(96, 30);
            this.NewBTN.TabIndex = 41;
            this.NewBTN.Text = "طلبية جديدة";
            this.NewBTN.UseVisualStyleBackColor = false;
            this.NewBTN.Click += new System.EventHandler(this.NewBTN_Click);
            // 
            // DeleteTouchBTN
            // 
            this.DeleteTouchBTN.BackColor = System.Drawing.Color.Red;
            this.DeleteTouchBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.DeleteTouchBTN.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteTouchBTN.ForeColor = System.Drawing.Color.White;
            this.DeleteTouchBTN.Location = new System.Drawing.Point(332, 564);
            this.DeleteTouchBTN.Name = "DeleteTouchBTN";
            this.DeleteTouchBTN.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DeleteTouchBTN.Size = new System.Drawing.Size(113, 50);
            this.DeleteTouchBTN.TabIndex = 0;
            this.DeleteTouchBTN.Text = "حذف المادة";
            this.DeleteTouchBTN.UseVisualStyleBackColor = false;
            this.DeleteTouchBTN.Click += new System.EventHandler(this.DeleteTouchBTN_Click);
            // 
            // FiveBTN
            // 
            this.FiveBTN.BackColor = System.Drawing.Color.White;
            this.FiveBTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.FiveBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.FiveBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.FiveBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.FiveBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FiveBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FiveBTN.Location = new System.Drawing.Point(123, 661);
            this.FiveBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.FiveBTN.Name = "FiveBTN";
            this.FiveBTN.Size = new System.Drawing.Size(97, 50);
            this.FiveBTN.TabIndex = 47;
            this.FiveBTN.Text = "5";
            this.FiveBTN.UseVisualStyleBackColor = false;
            this.FiveBTN.Click += new System.EventHandler(this.NumberBTN_Click);
            // 
            // SixBTN
            // 
            this.SixBTN.BackColor = System.Drawing.Color.White;
            this.SixBTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.SixBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.SixBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.SixBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.SixBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SixBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SixBTN.Location = new System.Drawing.Point(225, 665);
            this.SixBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.SixBTN.Name = "SixBTN";
            this.SixBTN.Size = new System.Drawing.Size(97, 50);
            this.SixBTN.TabIndex = 46;
            this.SixBTN.Text = "6";
            this.SixBTN.UseVisualStyleBackColor = false;
            this.SixBTN.Click += new System.EventHandler(this.NumberBTN_Click);
            // 
            // SevenBTN
            // 
            this.SevenBTN.BackColor = System.Drawing.Color.White;
            this.SevenBTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.SevenBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.SevenBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.SevenBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.SevenBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SevenBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SevenBTN.Location = new System.Drawing.Point(22, 611);
            this.SevenBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.SevenBTN.Name = "SevenBTN";
            this.SevenBTN.Size = new System.Drawing.Size(97, 50);
            this.SevenBTN.TabIndex = 45;
            this.SevenBTN.Text = "7";
            this.SevenBTN.UseVisualStyleBackColor = false;
            this.SevenBTN.Click += new System.EventHandler(this.NumberBTN_Click);
            // 
            // EightBTN
            // 
            this.EightBTN.BackColor = System.Drawing.Color.White;
            this.EightBTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.EightBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.EightBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.EightBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.EightBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EightBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EightBTN.Location = new System.Drawing.Point(123, 611);
            this.EightBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.EightBTN.Name = "EightBTN";
            this.EightBTN.Size = new System.Drawing.Size(97, 50);
            this.EightBTN.TabIndex = 44;
            this.EightBTN.Text = "8";
            this.EightBTN.UseVisualStyleBackColor = false;
            this.EightBTN.Click += new System.EventHandler(this.NumberBTN_Click);
            // 
            // NineBTN
            // 
            this.NineBTN.BackColor = System.Drawing.Color.White;
            this.NineBTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.NineBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.NineBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.NineBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.NineBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NineBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NineBTN.Location = new System.Drawing.Point(225, 611);
            this.NineBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.NineBTN.Name = "NineBTN";
            this.NineBTN.Size = new System.Drawing.Size(97, 50);
            this.NineBTN.TabIndex = 43;
            this.NineBTN.Text = "9";
            this.NineBTN.UseVisualStyleBackColor = false;
            this.NineBTN.Click += new System.EventHandler(this.NumberBTN_Click);
            // 
            // ZeroBTN
            // 
            this.ZeroBTN.BackColor = System.Drawing.Color.White;
            this.ZeroBTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ZeroBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.ZeroBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.ZeroBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.ZeroBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ZeroBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZeroBTN.Location = new System.Drawing.Point(123, 771);
            this.ZeroBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.ZeroBTN.Name = "ZeroBTN";
            this.ZeroBTN.Size = new System.Drawing.Size(97, 51);
            this.ZeroBTN.TabIndex = 42;
            this.ZeroBTN.Text = "0";
            this.ZeroBTN.UseVisualStyleBackColor = false;
            this.ZeroBTN.Click += new System.EventHandler(this.NumberBTN_Click);
            // 
            // BackSpaceBTN
            // 
            this.BackSpaceBTN.BackColor = System.Drawing.Color.FloralWhite;
            this.BackSpaceBTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BackSpaceBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.BackSpaceBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.BackSpaceBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.BackSpaceBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackSpaceBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackSpaceBTN.Location = new System.Drawing.Point(22, 771);
            this.BackSpaceBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.BackSpaceBTN.Name = "BackSpaceBTN";
            this.BackSpaceBTN.Size = new System.Drawing.Size(97, 51);
            this.BackSpaceBTN.TabIndex = 41;
            this.BackSpaceBTN.Text = "مسح ";
            this.BackSpaceBTN.UseVisualStyleBackColor = false;
            this.BackSpaceBTN.Click += new System.EventHandler(this.NumberBTN_Click);
            // 
            // EnterBTN
            // 
            this.EnterBTN.BackColor = System.Drawing.Color.LawnGreen;
            this.EnterBTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.EnterBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.EnterBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.EnterBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.EnterBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EnterBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterBTN.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EnterBTN.Location = new System.Drawing.Point(225, 771);
            this.EnterBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.EnterBTN.Name = "EnterBTN";
            this.EnterBTN.Size = new System.Drawing.Size(97, 51);
            this.EnterBTN.TabIndex = 40;
            this.EnterBTN.Text = "إدخال";
            this.EnterBTN.UseVisualStyleBackColor = false;
            this.EnterBTN.Click += new System.EventHandler(this.NumberBTN_Click);
            // 
            // UpBTN
            // 
            this.UpBTN.BackColor = System.Drawing.Color.White;
            this.UpBTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.UpBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.UpBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.UpBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.UpBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpBTN.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpBTN.Location = new System.Drawing.Point(332, 665);
            this.UpBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.UpBTN.Name = "UpBTN";
            this.UpBTN.Size = new System.Drawing.Size(113, 50);
            this.UpBTN.TabIndex = 39;
            this.UpBTN.Text = "+";
            this.UpBTN.UseCompatibleTextRendering = true;
            this.UpBTN.UseVisualStyleBackColor = false;
            this.UpBTN.Click += new System.EventHandler(this.PlusBTN_Click);
            this.UpBTN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PlusBTN_MouseUp);
            // 
            // DownBTN
            // 
            this.DownBTN.BackColor = System.Drawing.Color.White;
            this.DownBTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.DownBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.DownBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.DownBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.DownBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownBTN.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownBTN.Location = new System.Drawing.Point(332, 718);
            this.DownBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.DownBTN.Name = "DownBTN";
            this.DownBTN.Size = new System.Drawing.Size(113, 50);
            this.DownBTN.TabIndex = 38;
            this.DownBTN.Text = "-";
            this.DownBTN.UseCompatibleTextRendering = true;
            this.DownBTN.UseVisualStyleBackColor = false;
            this.DownBTN.Click += new System.EventHandler(this.DownBTN_Click);
            this.DownBTN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DownBTN_MouseUp);
            // 
            // OneBTN
            // 
            this.OneBTN.BackColor = System.Drawing.Color.White;
            this.OneBTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.OneBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.OneBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.OneBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.OneBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OneBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OneBTN.Location = new System.Drawing.Point(22, 718);
            this.OneBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.OneBTN.Name = "OneBTN";
            this.OneBTN.Size = new System.Drawing.Size(97, 50);
            this.OneBTN.TabIndex = 34;
            this.OneBTN.Text = "1";
            this.OneBTN.UseVisualStyleBackColor = false;
            this.OneBTN.Click += new System.EventHandler(this.NumberBTN_Click);
            // 
            // TwoBTN
            // 
            this.TwoBTN.BackColor = System.Drawing.Color.White;
            this.TwoBTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.TwoBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.TwoBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.TwoBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.TwoBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TwoBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TwoBTN.Location = new System.Drawing.Point(123, 718);
            this.TwoBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.TwoBTN.Name = "TwoBTN";
            this.TwoBTN.Size = new System.Drawing.Size(97, 50);
            this.TwoBTN.TabIndex = 33;
            this.TwoBTN.Text = "2";
            this.TwoBTN.UseVisualStyleBackColor = false;
            this.TwoBTN.Click += new System.EventHandler(this.NumberBTN_Click);
            // 
            // ThreeBTN
            // 
            this.ThreeBTN.BackColor = System.Drawing.Color.White;
            this.ThreeBTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ThreeBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.ThreeBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.ThreeBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.ThreeBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ThreeBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThreeBTN.Location = new System.Drawing.Point(225, 718);
            this.ThreeBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.ThreeBTN.Name = "ThreeBTN";
            this.ThreeBTN.Size = new System.Drawing.Size(97, 50);
            this.ThreeBTN.TabIndex = 32;
            this.ThreeBTN.Text = "3";
            this.ThreeBTN.UseVisualStyleBackColor = false;
            this.ThreeBTN.Click += new System.EventHandler(this.NumberBTN_Click);
            // 
            // FourBTN
            // 
            this.FourBTN.BackColor = System.Drawing.Color.White;
            this.FourBTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.FourBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.FourBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.FourBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.FourBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FourBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FourBTN.Location = new System.Drawing.Point(22, 661);
            this.FourBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.FourBTN.Name = "FourBTN";
            this.FourBTN.Size = new System.Drawing.Size(97, 50);
            this.FourBTN.TabIndex = 31;
            this.FourBTN.Text = "4";
            this.FourBTN.UseVisualStyleBackColor = false;
            this.FourBTN.Click += new System.EventHandler(this.NumberBTN_Click);
            // 
            // TimeInfo
            // 
            this.TimeInfo.BackColor = System.Drawing.Color.White;
            this.TimeInfo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.TimeInfo.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.TimeInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.TimeInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.TimeInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TimeInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeInfo.Location = new System.Drawing.Point(650, 722);
            this.TimeInfo.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.TimeInfo.Name = "TimeInfo";
            this.TimeInfo.Size = new System.Drawing.Size(172, 40);
            this.TimeInfo.TabIndex = 54;
            this.TimeInfo.Text = "الآن";
            this.TimeInfo.UseVisualStyleBackColor = false;
            this.TimeInfo.TextChanged += new System.EventHandler(this.MobileTB_TextChanged);
            this.TimeInfo.Click += new System.EventHandler(this.TimeInfo_Click);
            // 
            // WhatAppBTN
            // 
            this.WhatAppBTN.AllowDrop = true;
            this.WhatAppBTN.BackColor = System.Drawing.Color.Green;
            this.WhatAppBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.WhatAppBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WhatAppBTN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WhatAppBTN.ForeColor = System.Drawing.Color.White;
            this.WhatAppBTN.Location = new System.Drawing.Point(653, 624);
            this.WhatAppBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.WhatAppBTN.Name = "WhatAppBTN";
            this.WhatAppBTN.Size = new System.Drawing.Size(86, 40);
            this.WhatAppBTN.TabIndex = 29;
            this.WhatAppBTN.Text = "WhatsApp";
            this.WhatAppBTN.UseVisualStyleBackColor = false;
            this.WhatAppBTN.Click += new System.EventHandler(this.WhatsAppBTN_Click);
            this.WhatAppBTN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WhatAppBTN_MouseUp);
            // 
            // DayMenuBTN
            // 
            this.DayMenuBTN.BackColor = System.Drawing.Color.White;
            this.DayMenuBTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.DayMenuBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.DayMenuBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.DayMenuBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.DayMenuBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DayMenuBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DayMenuBTN.Location = new System.Drawing.Point(650, 770);
            this.DayMenuBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.DayMenuBTN.Name = "DayMenuBTN";
            this.DayMenuBTN.Size = new System.Drawing.Size(172, 40);
            this.DayMenuBTN.TabIndex = 55;
            this.DayMenuBTN.Text = "اليوم";
            this.DayMenuBTN.UseVisualStyleBackColor = false;
            this.DayMenuBTN.TextChanged += new System.EventHandler(this.MobileTB_TextChanged);
            this.DayMenuBTN.Click += new System.EventHandler(this.DayBTN_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.White;
            this.MainMenu.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.MainMenu.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.MainMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.MainMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.MainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MainMenu.Location = new System.Drawing.Point(10, 6);
            this.MainMenu.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(96, 62);
            this.MainMenu.TabIndex = 40;
            this.MainMenu.Text = "الرئيسية";
            this.MainMenu.UseVisualStyleBackColor = false;
            this.MainMenu.Click += new System.EventHandler(this.MainMenu_Click);
            // 
            // OrdersPage
            // 
            this.OrdersPage.BackColor = System.Drawing.Color.White;
            this.OrdersPage.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.OrdersPage.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.OrdersPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.OrdersPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.OrdersPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OrdersPage.Location = new System.Drawing.Point(111, 6);
            this.OrdersPage.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.OrdersPage.Name = "OrdersPage";
            this.OrdersPage.Size = new System.Drawing.Size(96, 62);
            this.OrdersPage.TabIndex = 39;
            this.OrdersPage.Text = "الطلبات";
            this.OrdersPage.UseVisualStyleBackColor = false;
            this.OrdersPage.Click += new System.EventHandler(this.OrdersPage_Click);
            // 
            // unfocusableButton3
            // 
            this.unfocusableButton3.BackColor = System.Drawing.Color.White;
            this.unfocusableButton3.ContextMenuStrip = this.MenuSelection;
            this.unfocusableButton3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.unfocusableButton3.FlatAppearance.BorderSize = 0;
            this.unfocusableButton3.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.unfocusableButton3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.unfocusableButton3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.unfocusableButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unfocusableButton3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unfocusableButton3.Image = global::OrderForm.Properties.Resources.recipe_book_icon2;
            this.unfocusableButton3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.unfocusableButton3.Location = new System.Drawing.Point(560, 1);
            this.unfocusableButton3.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.unfocusableButton3.Name = "unfocusableButton3";
            this.unfocusableButton3.Size = new System.Drawing.Size(145, 58);
            this.unfocusableButton3.TabIndex = 20;
            this.unfocusableButton3.Text = "تغيير القائمة";
            this.unfocusableButton3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.unfocusableButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.unfocusableButton3.UseCompatibleTextRendering = true;
            this.unfocusableButton3.UseVisualStyleBackColor = false;
            this.unfocusableButton3.Click += new System.EventHandler(this.unfocusableButton3_Click);
            // 
            // TimeLeftLBL
            // 
            this.TimeLeftLBL.BackColor = System.Drawing.Color.White;
            this.TimeLeftLBL.Enabled = false;
            this.TimeLeftLBL.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.TimeLeftLBL.FlatAppearance.BorderSize = 0;
            this.TimeLeftLBL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TimeLeftLBL.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLeftLBL.Location = new System.Drawing.Point(496, 1);
            this.TimeLeftLBL.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.TimeLeftLBL.Name = "TimeLeftLBL";
            this.TimeLeftLBL.Size = new System.Drawing.Size(63, 35);
            this.TimeLeftLBL.TabIndex = 19;
            this.TimeLeftLBL.Text = "متبقي للصلاة";
            this.TimeLeftLBL.UseCompatibleTextRendering = true;
            this.TimeLeftLBL.UseVisualStyleBackColor = false;
            // 
            // TimeTillCountdown
            // 
            this.TimeTillCountdown.BackColor = System.Drawing.Color.White;
            this.TimeTillCountdown.Enabled = false;
            this.TimeTillCountdown.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.TimeTillCountdown.FlatAppearance.BorderSize = 0;
            this.TimeTillCountdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TimeTillCountdown.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeTillCountdown.Location = new System.Drawing.Point(496, 37);
            this.TimeTillCountdown.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.TimeTillCountdown.Name = "TimeTillCountdown";
            this.TimeTillCountdown.Size = new System.Drawing.Size(63, 26);
            this.TimeTillCountdown.TabIndex = 10;
            this.TimeTillCountdown.Text = "TimeTillCountdown";
            this.TimeTillCountdown.UseCompatibleTextRendering = true;
            this.TimeTillCountdown.UseVisualStyleBackColor = false;
            // 
            // DhuhrLBL
            // 
            this.DhuhrLBL.BackColor = System.Drawing.Color.White;
            this.DhuhrLBL.Enabled = false;
            this.DhuhrLBL.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.DhuhrLBL.FlatAppearance.BorderSize = 0;
            this.DhuhrLBL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DhuhrLBL.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DhuhrLBL.Location = new System.Drawing.Point(432, 1);
            this.DhuhrLBL.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.DhuhrLBL.Name = "DhuhrLBL";
            this.DhuhrLBL.Size = new System.Drawing.Size(63, 35);
            this.DhuhrLBL.TabIndex = 9;
            this.DhuhrLBL.Text = "الظهر";
            this.DhuhrLBL.UseCompatibleTextRendering = true;
            this.DhuhrLBL.UseVisualStyleBackColor = false;
            // 
            // DhuhrBTN
            // 
            this.DhuhrBTN.BackColor = System.Drawing.Color.White;
            this.DhuhrBTN.Enabled = false;
            this.DhuhrBTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.DhuhrBTN.FlatAppearance.BorderSize = 0;
            this.DhuhrBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DhuhrBTN.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DhuhrBTN.Location = new System.Drawing.Point(432, 37);
            this.DhuhrBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.DhuhrBTN.Name = "DhuhrBTN";
            this.DhuhrBTN.Size = new System.Drawing.Size(63, 26);
            this.DhuhrBTN.TabIndex = 15;
            this.DhuhrBTN.Text = "DhuhrBTN";
            this.DhuhrBTN.UseCompatibleTextRendering = true;
            this.DhuhrBTN.UseVisualStyleBackColor = false;
            // 
            // AsrLBL
            // 
            this.AsrLBL.BackColor = System.Drawing.Color.White;
            this.AsrLBL.Enabled = false;
            this.AsrLBL.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.AsrLBL.FlatAppearance.BorderSize = 0;
            this.AsrLBL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AsrLBL.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AsrLBL.Location = new System.Drawing.Point(368, 1);
            this.AsrLBL.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.AsrLBL.Name = "AsrLBL";
            this.AsrLBL.Size = new System.Drawing.Size(63, 35);
            this.AsrLBL.TabIndex = 8;
            this.AsrLBL.Text = "العصر";
            this.AsrLBL.UseCompatibleTextRendering = true;
            this.AsrLBL.UseVisualStyleBackColor = false;
            this.AsrLBL.Click += new System.EventHandler(this.AsrLBL_Click);
            // 
            // AsrBTN
            // 
            this.AsrBTN.BackColor = System.Drawing.Color.White;
            this.AsrBTN.Enabled = false;
            this.AsrBTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.AsrBTN.FlatAppearance.BorderSize = 0;
            this.AsrBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AsrBTN.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AsrBTN.Location = new System.Drawing.Point(368, 37);
            this.AsrBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.AsrBTN.Name = "AsrBTN";
            this.AsrBTN.Size = new System.Drawing.Size(63, 26);
            this.AsrBTN.TabIndex = 7;
            this.AsrBTN.Text = "AsrBTN";
            this.AsrBTN.UseCompatibleTextRendering = true;
            this.AsrBTN.UseVisualStyleBackColor = false;
            // 
            // MaghribLBL
            // 
            this.MaghribLBL.BackColor = System.Drawing.Color.White;
            this.MaghribLBL.Enabled = false;
            this.MaghribLBL.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.MaghribLBL.FlatAppearance.BorderSize = 0;
            this.MaghribLBL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MaghribLBL.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaghribLBL.Location = new System.Drawing.Point(304, 1);
            this.MaghribLBL.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.MaghribLBL.Name = "MaghribLBL";
            this.MaghribLBL.Size = new System.Drawing.Size(63, 35);
            this.MaghribLBL.TabIndex = 16;
            this.MaghribLBL.Text = "المغرب";
            this.MaghribLBL.UseCompatibleTextRendering = true;
            this.MaghribLBL.UseVisualStyleBackColor = false;
            // 
            // MaghribBTN
            // 
            this.MaghribBTN.BackColor = System.Drawing.Color.White;
            this.MaghribBTN.Enabled = false;
            this.MaghribBTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.MaghribBTN.FlatAppearance.BorderSize = 0;
            this.MaghribBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MaghribBTN.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaghribBTN.Location = new System.Drawing.Point(304, 37);
            this.MaghribBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.MaghribBTN.Name = "MaghribBTN";
            this.MaghribBTN.Size = new System.Drawing.Size(63, 26);
            this.MaghribBTN.TabIndex = 6;
            this.MaghribBTN.Text = "MaghribBTN";
            this.MaghribBTN.UseCompatibleTextRendering = true;
            this.MaghribBTN.UseVisualStyleBackColor = false;
            // 
            // IshaLBL
            // 
            this.IshaLBL.BackColor = System.Drawing.Color.White;
            this.IshaLBL.Enabled = false;
            this.IshaLBL.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.IshaLBL.FlatAppearance.BorderSize = 0;
            this.IshaLBL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IshaLBL.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IshaLBL.Location = new System.Drawing.Point(240, 1);
            this.IshaLBL.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.IshaLBL.Name = "IshaLBL";
            this.IshaLBL.Size = new System.Drawing.Size(63, 35);
            this.IshaLBL.TabIndex = 17;
            this.IshaLBL.Text = "العشاء";
            this.IshaLBL.UseCompatibleTextRendering = true;
            this.IshaLBL.UseVisualStyleBackColor = false;
            // 
            // IshaBTN
            // 
            this.IshaBTN.BackColor = System.Drawing.Color.White;
            this.IshaBTN.Enabled = false;
            this.IshaBTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.IshaBTN.FlatAppearance.BorderSize = 0;
            this.IshaBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IshaBTN.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IshaBTN.Location = new System.Drawing.Point(240, 37);
            this.IshaBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.IshaBTN.Name = "IshaBTN";
            this.IshaBTN.Size = new System.Drawing.Size(63, 26);
            this.IshaBTN.TabIndex = 14;
            this.IshaBTN.Text = "IshaBTN";
            this.IshaBTN.UseCompatibleTextRendering = true;
            this.IshaBTN.UseVisualStyleBackColor = false;
            // 
            // DateLBL
            // 
            this.DateLBL.BackColor = System.Drawing.Color.White;
            this.DateLBL.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.DateLBL.FlatAppearance.BorderSize = 0;
            this.DateLBL.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.DateLBL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.DateLBL.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.DateLBL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DateLBL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.DateLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DateLBL.Location = new System.Drawing.Point(114, 1);
            this.DateLBL.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.DateLBL.Name = "DateLBL";
            this.DateLBL.Size = new System.Drawing.Size(125, 26);
            this.DateLBL.TabIndex = 11;
            this.DateLBL.Text = "Date";
            this.DateLBL.UseCompatibleTextRendering = true;
            this.DateLBL.UseVisualStyleBackColor = false;
            // 
            // DayLBL
            // 
            this.DayLBL.BackColor = System.Drawing.Color.White;
            this.DayLBL.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.DayLBL.FlatAppearance.BorderSize = 0;
            this.DayLBL.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.DayLBL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.DayLBL.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.DayLBL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DayLBL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.DayLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DayLBL.Location = new System.Drawing.Point(114, 28);
            this.DayLBL.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.DayLBL.Name = "DayLBL";
            this.DayLBL.Size = new System.Drawing.Size(125, 31);
            this.DayLBL.TabIndex = 12;
            this.DayLBL.Text = "DayOfTheWeek";
            this.DayLBL.UseCompatibleTextRendering = true;
            this.DayLBL.UseVisualStyleBackColor = false;
            // 
            // TimeButton
            // 
            this.TimeButton.BackColor = System.Drawing.Color.White;
            this.TimeButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.TimeButton.FlatAppearance.BorderSize = 0;
            this.TimeButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.TimeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.TimeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.TimeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TimeButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TimeButton.Location = new System.Drawing.Point(0, 1);
            this.TimeButton.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.TimeButton.Name = "TimeButton";
            this.TimeButton.Size = new System.Drawing.Size(113, 26);
            this.TimeButton.TabIndex = 13;
            this.TimeButton.Text = "Time";
            this.TimeButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.TimeButton.UseCompatibleTextRendering = true;
            this.TimeButton.UseMnemonic = false;
            this.TimeButton.UseVisualStyleBackColor = false;
            // 
            // CopyInvoice
            // 
            this.CopyInvoice.BackColor = System.Drawing.Color.White;
            this.CopyInvoice.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.CopyInvoice.FlatAppearance.BorderSize = 0;
            this.CopyInvoice.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.CopyInvoice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.CopyInvoice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.CopyInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CopyInvoice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CopyInvoice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CopyInvoice.Location = new System.Drawing.Point(-2, 28);
            this.CopyInvoice.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.CopyInvoice.Name = "CopyInvoice";
            this.CopyInvoice.Size = new System.Drawing.Size(115, 32);
            this.CopyInvoice.TabIndex = 22;
            this.CopyInvoice.Text = "نسخ الفاتورة";
            this.CopyInvoice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CopyInvoice.UseCompatibleTextRendering = true;
            this.CopyInvoice.UseMnemonic = false;
            this.CopyInvoice.UseVisualStyleBackColor = false;
            this.CopyInvoice.Click += new System.EventHandler(this.TimeButton_Click);
            // 
            // SettingsPage
            // 
            this.SettingsPage.BackColor = System.Drawing.Color.White;
            this.SettingsPage.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.SettingsPage.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.SettingsPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.SettingsPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SettingsPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsPage.Font = new System.Drawing.Font("Wingdings", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.SettingsPage.Location = new System.Drawing.Point(929, 5);
            this.SettingsPage.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.SettingsPage.Name = "SettingsPage";
            this.SettingsPage.Size = new System.Drawing.Size(30, 62);
            this.SettingsPage.TabIndex = 38;
            this.SettingsPage.Text = ":";
            this.SettingsPage.UseCompatibleTextRendering = true;
            this.SettingsPage.UseVisualStyleBackColor = false;
            this.SettingsPage.Click += new System.EventHandler(this.SettingsPage_Click);
            // 
            // Orders
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(961, 1009);
            this.Controls.Add(this.OrdersPanel);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.OrdersPage);
            this.Controls.Add(this.SalahTimes);
            this.Controls.Add(this.SettingsPage);
            this.HelpButton = true;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(945, 0);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(977, 1048);
            this.MinimumSize = new System.Drawing.Size(977, 1038);
            this.Name = "Orders";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "برنامج تسجيل طلبات ليبرا";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Orders_FormClosing);
            this.Load += new System.EventHandler(this.Orders_Load);
            this.rightClickMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvItems)).EndInit();
            this.OrdersPanel.ResumeLayout(false);
            this.OrdersPanel.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.sortType.ResumeLayout(false);
            this.sortType.PerformLayout();
            this.InvoiceTypeOptions.ResumeLayout(false);
            this.InvoiceTypeOptions.PerformLayout();
            this.SalahTimes.ResumeLayout(false);
            this.MenuSelection.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.ContextMenuStrip rightClickMenu;
        public System.Windows.Forms.Timer SalahTMR;
        private System.Windows.Forms.ToolStripMenuItem ItemNameTag;
        private System.Windows.Forms.ToolStripSeparator sep;
        private System.Windows.Forms.ToolStripMenuItem commentBTN;
        private System.Windows.Forms.ToolStripMenuItem DeleteBTN;
        private System.Windows.Forms.ToolStripMenuItem CustomComment;
        private UnfocusableButton OrdersPage;
        private UnfocusableButton SettingsPage;
        private UnfocusableButton NewBTN;
        private System.Windows.Forms.FlowLayoutPanel ItemsPanel1;
        private System.Windows.Forms.FlowLayoutPanel SectionsPanel;
        private System.Windows.Forms.TextBox MobileTB;
        private UnfocusableButton WhatAppBTN;
        public System.Windows.Forms.DataGridView dvItems;
        private UnfocusableButton FourBTN;
        private UnfocusableButton ThreeBTN;
        private UnfocusableButton TwoBTN;
        private UnfocusableButton OneBTN;
        private UnfocusableButton DownBTN;
        private UnfocusableButton UpBTN;
        private UnfocusableButton EnterBTN;
        private UnfocusableButton BackSpaceBTN;
        private UnfocusableButton ZeroBTN;
        private UnfocusableButton NineBTN;
        private UnfocusableButton EightBTN;
        private UnfocusableButton SevenBTN;
        private UnfocusableButton SixBTN;
        private UnfocusableButton FiveBTN;
        private UnfocusableButton DeleteTouchBTN;
        private System.Windows.Forms.Button PrintSave;
        private System.Windows.Forms.Label MobileLBL;
        private System.Windows.Forms.Label NameLBL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CommentLBL;
        private System.Windows.Forms.Panel OrdersPanel;
        private UnfocusableButton MainMenu;
        private UnfocusableButton TimeInfo;
        private UnfocusableButton DayMenuBTN;
        private System.Windows.Forms.TextBox TimeTB;
        private System.Windows.Forms.ContextMenuStrip DayMenu;
        private System.Windows.Forms.ContextMenuStrip HourPicker;
        private System.Windows.Forms.ContextMenuStrip MinutesPicker;
        private System.Windows.Forms.ContextMenuStrip TODPicker;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox DOWTB;
        public UnfocusableButton TimeButton;
        private UnfocusableButton DateLBL;
        private UnfocusableButton DayLBL;
        private UnfocusableButton IshaBTN;
        private UnfocusableButton IshaLBL;
        private UnfocusableButton MaghribBTN;
        private UnfocusableButton MaghribLBL;
        private UnfocusableButton AsrBTN;
        private UnfocusableButton AsrLBL;
        private UnfocusableButton DhuhrBTN;
        private UnfocusableButton DhuhrLBL;
        private UnfocusableButton TimeTillCountdown;
        private UnfocusableButton TimeLeftLBL;
        private System.Windows.Forms.FlowLayoutPanel SalahTimes;
        public System.Windows.Forms.TextBox NameTB;
        public System.Windows.Forms.TextBox CommentTB;
        private System.Windows.Forms.ContextMenuStrip FastComment;
        private System.Windows.Forms.Button SaveInvoice;
        private System.Windows.Forms.Button OrderStatus;
        private System.Windows.Forms.Button DeleteInvoice;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton AllDays;
        private System.Windows.Forms.RadioButton History;
        private System.Windows.Forms.Label SearchLBL;
        private System.Windows.Forms.RadioButton Sat;
        private System.Windows.Forms.FlowLayoutPanel PrintedInvoices;
        private System.Windows.Forms.TextBox SearchTB;
        private System.Windows.Forms.RadioButton Sun;
        private System.Windows.Forms.FlowLayoutPanel HeldPanel;
        private System.Windows.Forms.RadioButton Mon;
        private System.Windows.Forms.RadioButton Fri;
        private System.Windows.Forms.RadioButton Tue;
        private System.Windows.Forms.RadioButton Thu;
        private System.Windows.Forms.RadioButton Wed;
        public System.Windows.Forms.GroupBox sortType;
        private System.Windows.Forms.CheckBox GroupSave;
        public System.Windows.Forms.TextBox InvoiceNumberID;
        private System.Windows.Forms.Label AmountPriceLBL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label ItemCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button HoldInvoice;
        private UnfocusableButton unfocusableButton3;
        private System.Windows.Forms.ContextMenuStrip MenuSelection;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        public System.Windows.Forms.Timer MenuTimeOut;
        private System.Windows.Forms.CheckBox checkBox1;
        private UnfocusableButton RepeatOrder;
        private UnfocusableButton LastOrder;
        private System.Windows.Forms.Label jahezPrice;
        private UnfocusableButton Search;
        private UnfocusableButton OrderCut;
        private UnfocusableButton unfocusableButton5;
        private UnfocusableButton unfocusableButton6;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PrintDialog printComment;
        public UnfocusableButton CopyInvoice;
        private System.Windows.Forms.ContextMenuStrip WhatsSend;
        public System.Windows.Forms.Label AmountLBL;
        private UnfocusableButton ShowMenuBTN;
        public System.Windows.Forms.ToolStrip InvoiceTypeOptions;
        private System.Windows.Forms.ToolStripButton TelButton;
        private System.Windows.Forms.ToolStripButton ToGoButton;
        private System.Windows.Forms.ToolStripButton DineButton;
        private System.Windows.Forms.ToolStripButton AppsButton;
    }
}