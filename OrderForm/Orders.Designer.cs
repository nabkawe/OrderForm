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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Orders));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteBTN = new System.Windows.Forms.ToolStripMenuItem();
            this.sep = new System.Windows.Forms.ToolStripSeparator();
            this.commentBTN = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomComment = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemNameTag = new System.Windows.Forms.ToolStripMenuItem();
            this.SalahTMR = new System.Windows.Forms.Timer(this.components);
            this.OrdersPanel = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Draft = new System.Windows.Forms.RadioButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.PrintMultiTool = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveJahezAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MultiSave_ = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.OrdersReady = new System.Windows.Forms.ToolStripButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.InvoicesDG = new System.Windows.Forms.DataGridView();
            this.GroupSave = new System.Windows.Forms.CheckBox();
            this.Wed = new System.Windows.Forms.RadioButton();
            this.AllDays = new System.Windows.Forms.RadioButton();
            this.Thu = new System.Windows.Forms.RadioButton();
            this.History = new System.Windows.Forms.RadioButton();
            this.Tue = new System.Windows.Forms.RadioButton();
            this.SearchLBL = new System.Windows.Forms.Label();
            this.Fri = new System.Windows.Forms.RadioButton();
            this.Sat = new System.Windows.Forms.RadioButton();
            this.Mon = new System.Windows.Forms.RadioButton();
            this.SearchTB = new System.Windows.Forms.TextBox();
            this.Sun = new System.Windows.Forms.RadioButton();
            this.xLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CommentLBL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NameLBL = new System.Windows.Forms.Label();
            this.MobileLBL = new System.Windows.Forms.Label();
            this.ItemsPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.AmountLBL = new System.Windows.Forms.Label();
            this.dvItems = new System.Windows.Forms.DataGridView();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.HoldInvoice = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ItemCount = new System.Windows.Forms.Label();
            this.DeleteInvoice = new System.Windows.Forms.Button();
            this.SaveInvoice = new System.Windows.Forms.Button();
            this.InvoiceNumberID = new System.Windows.Forms.TextBox();
            this.PrintSave = new System.Windows.Forms.Button();
            this.SectionsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.DOWTB = new System.Windows.Forms.TextBox();
            this.TimeTB = new System.Windows.Forms.TextBox();
            this.CommentTB = new System.Windows.Forms.TextBox();
            this.MobileTB = new System.Windows.Forms.TextBox();
            this.NameTB = new System.Windows.Forms.TextBox();
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
            this.MenuSelection = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.FastComment = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuTimeOut = new System.Windows.Forms.Timer(this.components);
            this.printComment = new System.Windows.Forms.PrintDialog();
            this.WhatsSend = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Api_Health = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.SalahTimes = new System.Windows.Forms.FlowLayoutPanel();
            this.langCheck = new System.Windows.Forms.CheckBox();
            this.CIDWorker = new System.ComponentModel.BackgroundWorker();
            this.OrdersPage = new OrderForm.UButton();
            this.MainMenu = new OrderForm.UButton();
            this.changeMenu = new OrderForm.UButton();
            this.TimeLeftLBL = new OrderForm.UButton();
            this.TimeTillCountdown = new OrderForm.UButton();
            this.DhuhrLBL = new OrderForm.UButton();
            this.DhuhrBTN = new OrderForm.UButton();
            this.AsrLBL = new OrderForm.UButton();
            this.AsrBTN = new OrderForm.UButton();
            this.MaghribLBL = new OrderForm.UButton();
            this.MaghribBTN = new OrderForm.UButton();
            this.IshaLBL = new OrderForm.UButton();
            this.IshaBTN = new OrderForm.UButton();
            this.DateLBL = new OrderForm.UButton();
            this.DayLBL = new OrderForm.UButton();
            this.TimeButton = new OrderForm.UButton();
            this.CopyInvoice = new OrderForm.UButton();
            this.SettingsPage = new OrderForm.UButton();
            this.Search = new OrderForm.UButton();
            this.CallerIDBTN = new OrderForm.UButton();
            this.ShowMenuBTN = new OrderForm.UButton();
            this.unfocusableButton6 = new OrderForm.UButton();
            this.OrderCut = new OrderForm.UButton();
            this.LastOrder = new OrderForm.UButton();
            this.RepeatOrder = new OrderForm.UButton();
            this.NewBTN = new OrderForm.UButton();
            this.DeleteTouchBTN = new OrderForm.UButton();
            this.FiveBTN = new OrderForm.UButton();
            this.SixBTN = new OrderForm.UButton();
            this.SevenBTN = new OrderForm.UButton();
            this.EightBTN = new OrderForm.UButton();
            this.NineBTN = new OrderForm.UButton();
            this.ZeroBTN = new OrderForm.UButton();
            this.BackSpaceBTN = new OrderForm.UButton();
            this.EnterBTN = new OrderForm.UButton();
            this.UpBTN = new OrderForm.UButton();
            this.DownBTN = new OrderForm.UButton();
            this.OneBTN = new OrderForm.UButton();
            this.TwoBTN = new OrderForm.UButton();
            this.ThreeBTN = new OrderForm.UButton();
            this.FourBTN = new OrderForm.UButton();
            this.TimeInfo = new OrderForm.UButton();
            this.WhatAppBTN = new OrderForm.UButton();
            this.DayMenuBTN = new OrderForm.UButton();
            this.rightClickMenu.SuspendLayout();
            this.OrdersPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InvoicesDG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvItems)).BeginInit();
            this.InvoiceTypeOptions.SuspendLayout();
            this.MenuSelection.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SalahTimes.SuspendLayout();
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
            // OrdersPanel
            // 
            this.OrdersPanel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.OrdersPanel.Controls.Add(this.splitContainer1);
            this.OrdersPanel.Controls.Add(this.CallerIDBTN);
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
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.splitContainer1.Panel1.Controls.Add(this.Draft);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.Search);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.Wed);
            this.splitContainer1.Panel1.Controls.Add(this.AllDays);
            this.splitContainer1.Panel1.Controls.Add(this.Thu);
            this.splitContainer1.Panel1.Controls.Add(this.History);
            this.splitContainer1.Panel1.Controls.Add(this.Tue);
            this.splitContainer1.Panel1.Controls.Add(this.SearchLBL);
            this.splitContainer1.Panel1.Controls.Add(this.Fri);
            this.splitContainer1.Panel1.Controls.Add(this.Sat);
            this.splitContainer1.Panel1.Controls.Add(this.Mon);
            this.splitContainer1.Panel1.Controls.Add(this.SearchTB);
            this.splitContainer1.Panel1.Controls.Add(this.Sun);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.LightSlateGray;
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(961, 939);
            this.splitContainer1.SplitterDistance = 801;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 62;
            this.splitContainer1.Visible = false;
            // 
            // Draft
            // 
            this.Draft.Appearance = System.Windows.Forms.Appearance.Button;
            this.Draft.BackColor = System.Drawing.Color.GhostWhite;
            this.Draft.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Draft.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.Draft.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Draft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Draft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Draft.Location = new System.Drawing.Point(82, 39);
            this.Draft.Name = "Draft";
            this.Draft.Size = new System.Drawing.Size(69, 39);
            this.Draft.TabIndex = 175;
            this.Draft.TabStop = true;
            this.Draft.Text = "فواتير معلقة";
            this.Draft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Draft.UseVisualStyleBackColor = false;
            this.Draft.CheckedChanged += new System.EventHandler(this.Fri_CheckedChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowMerge = false;
            this.toolStrip1.BackColor = System.Drawing.Color.GhostWhite;
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PrintMultiTool,
            this.toolStripSeparator1,
            this.SaveJahezAll,
            this.toolStripSeparator2,
            this.MultiSave_,
            this.toolStripSeparator3,
            this.OrdersReady});
            this.toolStrip1.Location = new System.Drawing.Point(11, 5);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip1.ShowItemToolTips = false;
            this.toolStrip1.Size = new System.Drawing.Size(499, 28);
            this.toolStrip1.TabIndex = 174;
            // 
            // PrintMultiTool
            // 
            this.PrintMultiTool.BackColor = System.Drawing.Color.Lavender;
            this.PrintMultiTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.PrintMultiTool.Image = ((System.Drawing.Image)(resources.GetObject("PrintMultiTool.Image")));
            this.PrintMultiTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PrintMultiTool.Name = "PrintMultiTool";
            this.PrintMultiTool.Size = new System.Drawing.Size(104, 25);
            this.PrintMultiTool.Text = "طباعة متعددة";
            this.PrintMultiTool.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.PrintMultiTool.Click += new System.EventHandler(this.PrintMulti_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // SaveJahezAll
            // 
            this.SaveJahezAll.BackColor = System.Drawing.Color.Lavender;
            this.SaveJahezAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SaveJahezAll.Image = ((System.Drawing.Image)(resources.GetObject("SaveJahezAll.Image")));
            this.SaveJahezAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveJahezAll.Name = "SaveJahezAll";
            this.SaveJahezAll.Size = new System.Drawing.Size(164, 25);
            this.SaveJahezAll.Text = "تخزين جميع فواتير جاهز";
            this.SaveJahezAll.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.SaveJahezAll.Click += new System.EventHandler(this.SaveAllJahez_Click);
            this.SaveJahezAll.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SaveAllJahez_MouseUp);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // MultiSave_
            // 
            this.MultiSave_.BackColor = System.Drawing.Color.Lavender;
            this.MultiSave_.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MultiSave_.Image = ((System.Drawing.Image)(resources.GetObject("MultiSave_.Image")));
            this.MultiSave_.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MultiSave_.Name = "MultiSave_";
            this.MultiSave_.Size = new System.Drawing.Size(95, 25);
            this.MultiSave_.Text = "تخزين متعدد";
            this.MultiSave_.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.MultiSave_.Click += new System.EventHandler(this.MultiSave_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // OrdersReady
            // 
            this.OrdersReady.BackColor = System.Drawing.Color.Lavender;
            this.OrdersReady.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.OrdersReady.Image = ((System.Drawing.Image)(resources.GetObject("OrdersReady.Image")));
            this.OrdersReady.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OrdersReady.Name = "OrdersReady";
            this.OrdersReady.Size = new System.Drawing.Size(107, 25);
            this.OrdersReady.Text = "الطلبات جاهزة";
            this.OrdersReady.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.OrdersReady.ToolTipText = "حدد حالة الطلب (زهري للإشارة إلى جاهزيته)";
            this.OrdersReady.Click += new System.EventHandler(this.OrdersReady_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.GhostWhite;
            this.label2.Location = new System.Drawing.Point(830, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 61;
            this.label2.Text = "x";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.InvoicesDG);
            this.panel1.Controls.Add(this.GroupSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 85);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(961, 854);
            this.panel1.TabIndex = 51;
            this.panel1.Visible = false;
            // 
            // InvoicesDG
            // 
            this.InvoicesDG.AllowUserToAddRows = false;
            this.InvoicesDG.AllowUserToDeleteRows = false;
            this.InvoicesDG.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.InvoicesDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.InvoicesDG.DefaultCellStyle = dataGridViewCellStyle1;
            this.InvoicesDG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InvoicesDG.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.InvoicesDG.Location = new System.Drawing.Point(0, 0);
            this.InvoicesDG.Name = "InvoicesDG";
            this.InvoicesDG.ReadOnly = true;
            this.InvoicesDG.RowTemplate.Height = 35;
            this.InvoicesDG.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.InvoicesDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InvoicesDG.ShowCellErrors = false;
            this.InvoicesDG.ShowEditingIcon = false;
            this.InvoicesDG.ShowRowErrors = false;
            this.InvoicesDG.Size = new System.Drawing.Size(961, 854);
            this.InvoicesDG.TabIndex = 0;
            this.InvoicesDG.TabStop = false;
            this.InvoicesDG.DataSourceChanged += new System.EventHandler(this.InvoicesDG_DataSourceChanged);
            this.InvoicesDG.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InvoicesDG_CellClick);
            this.InvoicesDG.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InvoicesDG_CellDoubleClick);
            this.InvoicesDG.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.InvoicesDG_CellFormatting);
            this.InvoicesDG.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.InvoicesDG_CellToolTipTextNeeded);
            this.InvoicesDG.SelectionChanged += new System.EventHandler(this.InvoicesDG_SelectionChanged);
            // 
            // GroupSave
            // 
            this.GroupSave.Appearance = System.Windows.Forms.Appearance.Button;
            this.GroupSave.BackColor = System.Drawing.Color.Gold;
            this.GroupSave.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.GroupSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GroupSave.Location = new System.Drawing.Point(38, 148);
            this.GroupSave.Name = "GroupSave";
            this.GroupSave.Size = new System.Drawing.Size(90, 23);
            this.GroupSave.TabIndex = 63;
            this.GroupSave.Text = "للكب";
            this.GroupSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.GroupSave.UseVisualStyleBackColor = false;
            this.GroupSave.CheckedChanged += new System.EventHandler(this.GroupSave_CheckedChanged);
            this.GroupSave.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GroupSave_MouseUp);
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
            this.Wed.Location = new System.Drawing.Point(432, 37);
            this.Wed.Name = "Wed";
            this.Wed.Size = new System.Drawing.Size(71, 42);
            this.Wed.TabIndex = 45;
            this.Wed.TabStop = true;
            this.Wed.Text = "الأربعاء";
            this.Wed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Wed.UseVisualStyleBackColor = false;
            this.Wed.CheckedChanged += new System.EventHandler(this.Fri_CheckedChanged);
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
            this.AllDays.Location = new System.Drawing.Point(221, 39);
            this.AllDays.Name = "AllDays";
            this.AllDays.Size = new System.Drawing.Size(65, 38);
            this.AllDays.TabIndex = 50;
            this.AllDays.TabStop = true;
            this.AllDays.Text = "جميع الطلبات";
            this.AllDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AllDays.UseVisualStyleBackColor = false;
            this.AllDays.CheckedChanged += new System.EventHandler(this.Fri_CheckedChanged);
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
            this.Thu.Location = new System.Drawing.Point(361, 37);
            this.Thu.Name = "Thu";
            this.Thu.Size = new System.Drawing.Size(71, 42);
            this.Thu.TabIndex = 44;
            this.Thu.TabStop = true;
            this.Thu.Text = "الخميس";
            this.Thu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Thu.UseVisualStyleBackColor = false;
            this.Thu.CheckedChanged += new System.EventHandler(this.Fri_CheckedChanged);
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
            this.History.Location = new System.Drawing.Point(9, 39);
            this.History.Name = "History";
            this.History.Size = new System.Drawing.Size(69, 39);
            this.History.TabIndex = 53;
            this.History.TabStop = true;
            this.History.Text = "التاريخ";
            this.History.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.History.UseVisualStyleBackColor = false;
            this.History.CheckedChanged += new System.EventHandler(this.Fri_CheckedChanged);
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
            this.Tue.Location = new System.Drawing.Point(503, 37);
            this.Tue.Name = "Tue";
            this.Tue.Size = new System.Drawing.Size(71, 42);
            this.Tue.TabIndex = 46;
            this.Tue.TabStop = true;
            this.Tue.Text = "الثلاثاء";
            this.Tue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Tue.UseVisualStyleBackColor = false;
            this.Tue.CheckedChanged += new System.EventHandler(this.Fri_CheckedChanged);
            // 
            // SearchLBL
            // 
            this.SearchLBL.AutoSize = true;
            this.SearchLBL.ForeColor = System.Drawing.Color.White;
            this.SearchLBL.Location = new System.Drawing.Point(892, 24);
            this.SearchLBL.Name = "SearchLBL";
            this.SearchLBL.Size = new System.Drawing.Size(66, 13);
            this.SearchLBL.TabIndex = 51;
            this.SearchLBL.Text = "بحث الفواتير:";
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
            this.Fri.Location = new System.Drawing.Point(290, 37);
            this.Fri.Name = "Fri";
            this.Fri.Size = new System.Drawing.Size(71, 42);
            this.Fri.TabIndex = 43;
            this.Fri.TabStop = true;
            this.Fri.Text = "الجمعة";
            this.Fri.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Fri.UseVisualStyleBackColor = false;
            this.Fri.CheckedChanged += new System.EventHandler(this.Fri_CheckedChanged);
            this.Fri.Click += new System.EventHandler(this.Fri_Click);
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
            this.Sat.Location = new System.Drawing.Point(716, 37);
            this.Sat.Name = "Sat";
            this.Sat.Size = new System.Drawing.Size(71, 42);
            this.Sat.TabIndex = 49;
            this.Sat.TabStop = true;
            this.Sat.Text = "السبت";
            this.Sat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Sat.UseVisualStyleBackColor = false;
            this.Sat.CheckedChanged += new System.EventHandler(this.Fri_CheckedChanged);
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
            this.Mon.Location = new System.Drawing.Point(574, 37);
            this.Mon.Name = "Mon";
            this.Mon.Size = new System.Drawing.Size(71, 42);
            this.Mon.TabIndex = 47;
            this.Mon.TabStop = true;
            this.Mon.Text = "الإثنين";
            this.Mon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Mon.UseVisualStyleBackColor = false;
            this.Mon.CheckedChanged += new System.EventHandler(this.Fri_CheckedChanged);
            // 
            // SearchTB
            // 
            this.SearchTB.BackColor = System.Drawing.Color.GhostWhite;
            this.SearchTB.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchTB.Location = new System.Drawing.Point(788, 41);
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
            this.Sun.Location = new System.Drawing.Point(645, 37);
            this.Sun.Name = "Sun";
            this.Sun.Size = new System.Drawing.Size(71, 42);
            this.Sun.TabIndex = 48;
            this.Sun.TabStop = true;
            this.Sun.Text = "الأحد";
            this.Sun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Sun.UseVisualStyleBackColor = false;
            this.Sun.CheckedChanged += new System.EventHandler(this.Fri_CheckedChanged);
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.BackColor = System.Drawing.Color.GhostWhite;
            this.xLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel.Location = new System.Drawing.Point(924, 732);
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
            this.label3.Location = new System.Drawing.Point(852, 783);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 103;
            this.label3.Text = "يوم الطلب";
            // 
            // CommentLBL
            // 
            this.CommentLBL.AutoSize = true;
            this.CommentLBL.BackColor = System.Drawing.Color.GhostWhite;
            this.CommentLBL.Enabled = false;
            this.CommentLBL.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommentLBL.ForeColor = System.Drawing.Color.Silver;
            this.CommentLBL.Location = new System.Drawing.Point(826, 829);
            this.CommentLBL.Name = "CommentLBL";
            this.CommentLBL.Size = new System.Drawing.Size(91, 17);
            this.CommentLBL.TabIndex = 53;
            this.CommentLBL.Text = "ملاحظة  الطلب";
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
            // ItemsPanel1
            // 
            this.ItemsPanel1.BackColor = System.Drawing.Color.GhostWhite;
            this.ItemsPanel1.Location = new System.Drawing.Point(563, 3);
            this.ItemsPanel1.Name = "ItemsPanel1";
            this.ItemsPanel1.Size = new System.Drawing.Size(387, 611);
            this.ItemsPanel1.TabIndex = 22;
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
            // dvItems
            // 
            this.dvItems.AllowDrop = true;
            this.dvItems.AllowUserToAddRows = false;
            this.dvItems.AllowUserToOrderColumns = true;
            this.dvItems.AllowUserToResizeColumns = false;
            this.dvItems.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dvItems.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dvItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dvItems.CausesValidation = false;
            this.dvItems.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dvItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvItems.DefaultCellStyle = dataGridViewCellStyle4;
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
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(12, 838);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(137, 15);
            this.checkBox1.TabIndex = 166;
            this.checkBox1.Text = "طباعة أمر التسليم لجميع الطلبات";
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
            // SectionsPanel
            // 
            this.SectionsPanel.BackColor = System.Drawing.Color.GhostWhite;
            this.SectionsPanel.Location = new System.Drawing.Point(459, 3);
            this.SectionsPanel.Name = "SectionsPanel";
            this.SectionsPanel.Size = new System.Drawing.Size(98, 562);
            this.SectionsPanel.TabIndex = 24;
            // 
            // DOWTB
            // 
            this.DOWTB.BackColor = System.Drawing.Color.GhostWhite;
            this.DOWTB.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.DOWTB.Location = new System.Drawing.Point(795, 772);
            this.DOWTB.Margin = new System.Windows.Forms.Padding(0);
            this.DOWTB.Name = "DOWTB";
            this.DOWTB.Size = new System.Drawing.Size(147, 43);
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
            this.TimeTB.Location = new System.Drawing.Point(795, 722);
            this.TimeTB.Margin = new System.Windows.Forms.Padding(0);
            this.TimeTB.Name = "TimeTB";
            this.TimeTB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TimeTB.Size = new System.Drawing.Size(147, 43);
            this.TimeTB.TabIndex = 100;
            this.TimeTB.WordWrap = false;
            this.TimeTB.TextChanged += new System.EventHandler(this.TimeTB_TextChanged);
            this.TimeTB.DoubleClick += new System.EventHandler(this.TimeTB_DoubleClick);
            this.TimeTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TimeTB_KeyPress);
            this.TimeTB.Leave += new System.EventHandler(this.TimeTB_Leave);
            this.TimeTB.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MobileTB_PreviewKeyDown);
            // 
            // CommentTB
            // 
            this.CommentTB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CommentTB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.CommentTB.BackColor = System.Drawing.Color.GhostWhite;
            this.CommentTB.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommentTB.Location = new System.Drawing.Point(671, 823);
            this.CommentTB.Margin = new System.Windows.Forms.Padding(0);
            this.CommentTB.Name = "CommentTB";
            this.CommentTB.Size = new System.Drawing.Size(271, 33);
            this.CommentTB.TabIndex = 150;
            this.CommentTB.WordWrap = false;
            this.CommentTB.TextChanged += new System.EventHandler(this.MobileTB_TextChanged);
            this.CommentTB.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MobileTB_PreviewKeyDown);
            // 
            // MobileTB
            // 
            this.MobileTB.AllowDrop = true;
            this.MobileTB.BackColor = System.Drawing.Color.GhostWhite;
            this.MobileTB.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.MobileTB.Location = new System.Drawing.Point(726, 624);
            this.MobileTB.Margin = new System.Windows.Forms.Padding(0);
            this.MobileTB.Name = "MobileTB";
            this.MobileTB.Size = new System.Drawing.Size(216, 43);
            this.MobileTB.TabIndex = 23;
            this.MobileTB.WordWrap = false;
            this.MobileTB.TextChanged += new System.EventHandler(this.MobileTB_TextChanged);
            this.MobileTB.DragDrop += new System.Windows.Forms.DragEventHandler(this.NameTB_DragDrop);
            this.MobileTB.DragEnter += new System.Windows.Forms.DragEventHandler(this.NameTB_DragEnter);
            this.MobileTB.DoubleClick += new System.EventHandler(this.MobileTB_DoubleClick);
            this.MobileTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MobileTB_KeyDown);
            this.MobileTB.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MobileTB_PreviewKeyDown);
            // 
            // NameTB
            // 
            this.NameTB.AllowDrop = true;
            this.NameTB.BackColor = System.Drawing.Color.GhostWhite;
            this.NameTB.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.NameTB.HideSelection = false;
            this.NameTB.Location = new System.Drawing.Point(623, 673);
            this.NameTB.Margin = new System.Windows.Forms.Padding(0);
            this.NameTB.Name = "NameTB";
            this.NameTB.Size = new System.Drawing.Size(319, 43);
            this.NameTB.TabIndex = 26;
            this.NameTB.WordWrap = false;
            this.NameTB.TextChanged += new System.EventHandler(this.MobileTB_TextChanged);
            this.NameTB.DragDrop += new System.Windows.Forms.DragEventHandler(this.NameTB_DragDrop);
            this.NameTB.DragEnter += new System.Windows.Forms.DragEventHandler(this.NameTB_DragEnter);
            this.NameTB.Enter += new System.EventHandler(this.NameTB_Enter);
            this.NameTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MobileTB_KeyDown);
            this.NameTB.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MobileTB_PreviewKeyDown);
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
            this.InvoiceTypeOptions.Size = new System.Drawing.Size(320, 56);
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
            this.TelButton.Size = new System.Drawing.Size(80, 52);
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
            this.ToGoButton.Size = new System.Drawing.Size(80, 52);
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
            this.DineButton.Size = new System.Drawing.Size(80, 52);
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
            this.AppsButton.Size = new System.Drawing.Size(80, 52);
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
            // Api_Health
            // 
            this.Api_Health.Enabled = true;
            this.Api_Health.Interval = 30000;
            this.Api_Health.Tick += new System.EventHandler(this.Api_Health_Tick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.OrdersPage);
            this.panel2.Controls.Add(this.MainMenu);
            this.panel2.Controls.Add(this.SalahTimes);
            this.panel2.Controls.Add(this.SettingsPage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel2.Size = new System.Drawing.Size(961, 69);
            this.panel2.TabIndex = 0;
            // 
            // SalahTimes
            // 
            this.SalahTimes.BackColor = System.Drawing.Color.LightSlateGray;
            this.SalahTimes.Controls.Add(this.langCheck);
            this.SalahTimes.Controls.Add(this.changeMenu);
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
            this.SalahTimes.Location = new System.Drawing.Point(39, 5);
            this.SalahTimes.Name = "SalahTimes";
            this.SalahTimes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SalahTimes.Size = new System.Drawing.Size(710, 64);
            this.SalahTimes.TabIndex = 25;
            // 
            // langCheck
            // 
            this.langCheck.AutoSize = true;
            this.langCheck.Checked = true;
            this.langCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.langCheck.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.langCheck.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.langCheck.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.langCheck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.langCheck.ForeColor = System.Drawing.Color.White;
            this.langCheck.Location = new System.Drawing.Point(622, 3);
            this.langCheck.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.langCheck.Name = "langCheck";
            this.langCheck.Size = new System.Drawing.Size(78, 17);
            this.langCheck.TabIndex = 23;
            this.langCheck.Text = "قائمة عربية";
            this.langCheck.UseVisualStyleBackColor = true;
            this.langCheck.CheckedChanged += new System.EventHandler(this.langCheck_CheckedChanged);
            // 
            // CIDWorker
            // 
            this.CIDWorker.WorkerReportsProgress = true;
            this.CIDWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CIDWorker_DoWork);
            // 
            // OrdersPage
            // 
            this.OrdersPage.BackColor = System.Drawing.Color.LightSlateGray;
            this.OrdersPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OrdersPage.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.OrdersPage.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.OrdersPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.OrdersPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.OrdersPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OrdersPage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.OrdersPage.ForeColor = System.Drawing.Color.White;
            this.OrdersPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OrdersPage.Location = new System.Drawing.Point(753, 6);
            this.OrdersPage.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.OrdersPage.Name = "OrdersPage";
            this.OrdersPage.Size = new System.Drawing.Size(96, 62);
            this.OrdersPage.TabIndex = 39;
            this.OrdersPage.TabStop = false;
            this.OrdersPage.Text = "الطلبات";
            this.OrdersPage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OrdersPage.UseVisualStyleBackColor = false;
            this.OrdersPage.Click += new System.EventHandler(this.OrdersPage_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.LightSlateGray;
            this.MainMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MainMenu.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.MainMenu.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.MainMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.MainMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.MainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MainMenu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.MainMenu.ForeColor = System.Drawing.Color.White;
            this.MainMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MainMenu.Location = new System.Drawing.Point(858, 6);
            this.MainMenu.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(96, 62);
            this.MainMenu.TabIndex = 40;
            this.MainMenu.TabStop = false;
            this.MainMenu.Text = "الرئيسية";
            this.MainMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.MainMenu.UseVisualStyleBackColor = false;
            this.MainMenu.Click += new System.EventHandler(this.MainMenu_Click);
            // 
            // changeMenu
            // 
            this.changeMenu.BackColor = System.Drawing.Color.LightSlateGray;
            this.changeMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.changeMenu.ContextMenuStrip = this.MenuSelection;
            this.changeMenu.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.changeMenu.FlatAppearance.BorderSize = 0;
            this.changeMenu.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.changeMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.changeMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.changeMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changeMenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeMenu.ForeColor = System.Drawing.Color.White;
            this.changeMenu.Image = global::OrderForm.Properties.Resources.recipe_book_icon2;
            this.changeMenu.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.changeMenu.Location = new System.Drawing.Point(588, 24);
            this.changeMenu.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.changeMenu.Name = "changeMenu";
            this.changeMenu.Size = new System.Drawing.Size(117, 35);
            this.changeMenu.TabIndex = 20;
            this.changeMenu.TabStop = false;
            this.changeMenu.Text = "تغيير القائمة";
            this.changeMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.changeMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.changeMenu.UseCompatibleTextRendering = true;
            this.changeMenu.UseVisualStyleBackColor = false;
            this.changeMenu.Click += new System.EventHandler(this.unfocusableButton3_Click);
            // 
            // TimeLeftLBL
            // 
            this.TimeLeftLBL.BackColor = System.Drawing.Color.LightSlateGray;
            this.TimeLeftLBL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TimeLeftLBL.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.TimeLeftLBL.FlatAppearance.BorderSize = 0;
            this.TimeLeftLBL.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.TimeLeftLBL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.TimeLeftLBL.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.TimeLeftLBL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TimeLeftLBL.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLeftLBL.ForeColor = System.Drawing.Color.White;
            this.TimeLeftLBL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TimeLeftLBL.Location = new System.Drawing.Point(524, 1);
            this.TimeLeftLBL.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.TimeLeftLBL.Name = "TimeLeftLBL";
            this.TimeLeftLBL.Size = new System.Drawing.Size(63, 35);
            this.TimeLeftLBL.TabIndex = 19;
            this.TimeLeftLBL.TabStop = false;
            this.TimeLeftLBL.Text = "متبقي للصلاة";
            this.TimeLeftLBL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.TimeLeftLBL.UseCompatibleTextRendering = true;
            this.TimeLeftLBL.UseVisualStyleBackColor = false;
            // 
            // TimeTillCountdown
            // 
            this.TimeTillCountdown.BackColor = System.Drawing.Color.LightSlateGray;
            this.TimeTillCountdown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TimeTillCountdown.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.TimeTillCountdown.FlatAppearance.BorderSize = 0;
            this.TimeTillCountdown.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.TimeTillCountdown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.TimeTillCountdown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.TimeTillCountdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TimeTillCountdown.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeTillCountdown.ForeColor = System.Drawing.Color.White;
            this.TimeTillCountdown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TimeTillCountdown.Location = new System.Drawing.Point(524, 37);
            this.TimeTillCountdown.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.TimeTillCountdown.Name = "TimeTillCountdown";
            this.TimeTillCountdown.Size = new System.Drawing.Size(63, 26);
            this.TimeTillCountdown.TabIndex = 10;
            this.TimeTillCountdown.TabStop = false;
            this.TimeTillCountdown.Text = "TimeTillCountdown";
            this.TimeTillCountdown.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.TimeTillCountdown.UseCompatibleTextRendering = true;
            this.TimeTillCountdown.UseVisualStyleBackColor = false;
            // 
            // DhuhrLBL
            // 
            this.DhuhrLBL.BackColor = System.Drawing.Color.LightSlateGray;
            this.DhuhrLBL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DhuhrLBL.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.DhuhrLBL.FlatAppearance.BorderSize = 0;
            this.DhuhrLBL.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.DhuhrLBL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.DhuhrLBL.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.DhuhrLBL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DhuhrLBL.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DhuhrLBL.ForeColor = System.Drawing.Color.White;
            this.DhuhrLBL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DhuhrLBL.Location = new System.Drawing.Point(460, 1);
            this.DhuhrLBL.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.DhuhrLBL.Name = "DhuhrLBL";
            this.DhuhrLBL.Size = new System.Drawing.Size(63, 35);
            this.DhuhrLBL.TabIndex = 9;
            this.DhuhrLBL.TabStop = false;
            this.DhuhrLBL.Text = "الظهر";
            this.DhuhrLBL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DhuhrLBL.UseCompatibleTextRendering = true;
            this.DhuhrLBL.UseVisualStyleBackColor = false;
            // 
            // DhuhrBTN
            // 
            this.DhuhrBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.DhuhrBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DhuhrBTN.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.DhuhrBTN.FlatAppearance.BorderSize = 0;
            this.DhuhrBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.DhuhrBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.DhuhrBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.DhuhrBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DhuhrBTN.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DhuhrBTN.ForeColor = System.Drawing.Color.White;
            this.DhuhrBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DhuhrBTN.Location = new System.Drawing.Point(460, 37);
            this.DhuhrBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.DhuhrBTN.Name = "DhuhrBTN";
            this.DhuhrBTN.Size = new System.Drawing.Size(63, 26);
            this.DhuhrBTN.TabIndex = 15;
            this.DhuhrBTN.TabStop = false;
            this.DhuhrBTN.Text = "DhuhrBTN";
            this.DhuhrBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DhuhrBTN.UseCompatibleTextRendering = true;
            this.DhuhrBTN.UseVisualStyleBackColor = false;
            // 
            // AsrLBL
            // 
            this.AsrLBL.BackColor = System.Drawing.Color.LightSlateGray;
            this.AsrLBL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AsrLBL.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.AsrLBL.FlatAppearance.BorderSize = 0;
            this.AsrLBL.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.AsrLBL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.AsrLBL.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.AsrLBL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AsrLBL.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AsrLBL.ForeColor = System.Drawing.Color.White;
            this.AsrLBL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AsrLBL.Location = new System.Drawing.Point(396, 1);
            this.AsrLBL.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.AsrLBL.Name = "AsrLBL";
            this.AsrLBL.Size = new System.Drawing.Size(63, 35);
            this.AsrLBL.TabIndex = 8;
            this.AsrLBL.TabStop = false;
            this.AsrLBL.Text = "العصر";
            this.AsrLBL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AsrLBL.UseCompatibleTextRendering = true;
            this.AsrLBL.UseVisualStyleBackColor = false;
            // 
            // AsrBTN
            // 
            this.AsrBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.AsrBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AsrBTN.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.AsrBTN.FlatAppearance.BorderSize = 0;
            this.AsrBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.AsrBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.AsrBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.AsrBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AsrBTN.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AsrBTN.ForeColor = System.Drawing.Color.White;
            this.AsrBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AsrBTN.Location = new System.Drawing.Point(396, 37);
            this.AsrBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.AsrBTN.Name = "AsrBTN";
            this.AsrBTN.Size = new System.Drawing.Size(63, 26);
            this.AsrBTN.TabIndex = 7;
            this.AsrBTN.TabStop = false;
            this.AsrBTN.Text = "AsrBTN";
            this.AsrBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AsrBTN.UseCompatibleTextRendering = true;
            this.AsrBTN.UseVisualStyleBackColor = false;
            // 
            // MaghribLBL
            // 
            this.MaghribLBL.BackColor = System.Drawing.Color.LightSlateGray;
            this.MaghribLBL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MaghribLBL.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.MaghribLBL.FlatAppearance.BorderSize = 0;
            this.MaghribLBL.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.MaghribLBL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.MaghribLBL.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.MaghribLBL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MaghribLBL.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaghribLBL.ForeColor = System.Drawing.Color.White;
            this.MaghribLBL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MaghribLBL.Location = new System.Drawing.Point(332, 1);
            this.MaghribLBL.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.MaghribLBL.Name = "MaghribLBL";
            this.MaghribLBL.Size = new System.Drawing.Size(63, 35);
            this.MaghribLBL.TabIndex = 16;
            this.MaghribLBL.TabStop = false;
            this.MaghribLBL.Text = "المغرب";
            this.MaghribLBL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.MaghribLBL.UseCompatibleTextRendering = true;
            this.MaghribLBL.UseVisualStyleBackColor = false;
            // 
            // MaghribBTN
            // 
            this.MaghribBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.MaghribBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MaghribBTN.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.MaghribBTN.FlatAppearance.BorderSize = 0;
            this.MaghribBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.MaghribBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.MaghribBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.MaghribBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MaghribBTN.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaghribBTN.ForeColor = System.Drawing.Color.White;
            this.MaghribBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MaghribBTN.Location = new System.Drawing.Point(332, 37);
            this.MaghribBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.MaghribBTN.Name = "MaghribBTN";
            this.MaghribBTN.Size = new System.Drawing.Size(63, 26);
            this.MaghribBTN.TabIndex = 6;
            this.MaghribBTN.TabStop = false;
            this.MaghribBTN.Text = "MaghribBTN";
            this.MaghribBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.MaghribBTN.UseCompatibleTextRendering = true;
            this.MaghribBTN.UseVisualStyleBackColor = false;
            // 
            // IshaLBL
            // 
            this.IshaLBL.BackColor = System.Drawing.Color.LightSlateGray;
            this.IshaLBL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.IshaLBL.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.IshaLBL.FlatAppearance.BorderSize = 0;
            this.IshaLBL.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.IshaLBL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.IshaLBL.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.IshaLBL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IshaLBL.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IshaLBL.ForeColor = System.Drawing.Color.White;
            this.IshaLBL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.IshaLBL.Location = new System.Drawing.Point(268, 1);
            this.IshaLBL.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.IshaLBL.Name = "IshaLBL";
            this.IshaLBL.Size = new System.Drawing.Size(63, 35);
            this.IshaLBL.TabIndex = 17;
            this.IshaLBL.TabStop = false;
            this.IshaLBL.Text = "العشاء";
            this.IshaLBL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.IshaLBL.UseCompatibleTextRendering = true;
            this.IshaLBL.UseVisualStyleBackColor = false;
            // 
            // IshaBTN
            // 
            this.IshaBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.IshaBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.IshaBTN.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.IshaBTN.FlatAppearance.BorderSize = 0;
            this.IshaBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.IshaBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.IshaBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.IshaBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IshaBTN.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IshaBTN.ForeColor = System.Drawing.Color.White;
            this.IshaBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.IshaBTN.Location = new System.Drawing.Point(268, 37);
            this.IshaBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.IshaBTN.Name = "IshaBTN";
            this.IshaBTN.Size = new System.Drawing.Size(63, 26);
            this.IshaBTN.TabIndex = 14;
            this.IshaBTN.TabStop = false;
            this.IshaBTN.Text = "IshaBTN";
            this.IshaBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.IshaBTN.UseCompatibleTextRendering = true;
            this.IshaBTN.UseVisualStyleBackColor = false;
            // 
            // DateLBL
            // 
            this.DateLBL.BackColor = System.Drawing.Color.LightSlateGray;
            this.DateLBL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DateLBL.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.DateLBL.FlatAppearance.BorderSize = 0;
            this.DateLBL.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.DateLBL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.DateLBL.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.DateLBL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DateLBL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.DateLBL.ForeColor = System.Drawing.Color.White;
            this.DateLBL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DateLBL.Location = new System.Drawing.Point(142, 1);
            this.DateLBL.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.DateLBL.Name = "DateLBL";
            this.DateLBL.Size = new System.Drawing.Size(125, 26);
            this.DateLBL.TabIndex = 11;
            this.DateLBL.TabStop = false;
            this.DateLBL.Text = "Date";
            this.DateLBL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DateLBL.UseCompatibleTextRendering = true;
            this.DateLBL.UseVisualStyleBackColor = false;
            this.DateLBL.Click += new System.EventHandler(this.DateLBL_Click);
            // 
            // DayLBL
            // 
            this.DayLBL.BackColor = System.Drawing.Color.LightSlateGray;
            this.DayLBL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DayLBL.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.DayLBL.FlatAppearance.BorderSize = 0;
            this.DayLBL.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.DayLBL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.DayLBL.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.DayLBL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DayLBL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.DayLBL.ForeColor = System.Drawing.Color.White;
            this.DayLBL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DayLBL.Location = new System.Drawing.Point(142, 28);
            this.DayLBL.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.DayLBL.Name = "DayLBL";
            this.DayLBL.Size = new System.Drawing.Size(125, 31);
            this.DayLBL.TabIndex = 12;
            this.DayLBL.TabStop = false;
            this.DayLBL.Text = "DayOfTheWeek";
            this.DayLBL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DayLBL.UseCompatibleTextRendering = true;
            this.DayLBL.UseVisualStyleBackColor = false;
            this.DayLBL.Click += new System.EventHandler(this.DayLBL_Click);
            // 
            // TimeButton
            // 
            this.TimeButton.BackColor = System.Drawing.Color.LightSlateGray;
            this.TimeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TimeButton.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.TimeButton.FlatAppearance.BorderSize = 0;
            this.TimeButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.TimeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.TimeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.TimeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TimeButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeButton.ForeColor = System.Drawing.Color.White;
            this.TimeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TimeButton.Location = new System.Drawing.Point(28, 1);
            this.TimeButton.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.TimeButton.Name = "TimeButton";
            this.TimeButton.Size = new System.Drawing.Size(113, 26);
            this.TimeButton.TabIndex = 13;
            this.TimeButton.TabStop = false;
            this.TimeButton.Text = "Time";
            this.TimeButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.TimeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.TimeButton.UseCompatibleTextRendering = true;
            this.TimeButton.UseMnemonic = false;
            this.TimeButton.UseVisualStyleBackColor = false;
            // 
            // CopyInvoice
            // 
            this.CopyInvoice.BackColor = System.Drawing.Color.LightSlateGray;
            this.CopyInvoice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CopyInvoice.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.CopyInvoice.FlatAppearance.BorderSize = 0;
            this.CopyInvoice.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.CopyInvoice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.CopyInvoice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.CopyInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CopyInvoice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CopyInvoice.ForeColor = System.Drawing.Color.White;
            this.CopyInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CopyInvoice.Location = new System.Drawing.Point(26, 28);
            this.CopyInvoice.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.CopyInvoice.Name = "CopyInvoice";
            this.CopyInvoice.Size = new System.Drawing.Size(115, 32);
            this.CopyInvoice.TabIndex = 22;
            this.CopyInvoice.TabStop = false;
            this.CopyInvoice.Text = "نسخ الفاتورة";
            this.CopyInvoice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CopyInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CopyInvoice.UseCompatibleTextRendering = true;
            this.CopyInvoice.UseMnemonic = false;
            this.CopyInvoice.UseVisualStyleBackColor = false;
            this.CopyInvoice.Click += new System.EventHandler(this.TimeButton_Click);
            this.CopyInvoice.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CopyInvoice_MouseDown);
            // 
            // SettingsPage
            // 
            this.SettingsPage.BackColor = System.Drawing.Color.LightSlateGray;
            this.SettingsPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SettingsPage.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.SettingsPage.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.SettingsPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.SettingsPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SettingsPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsPage.Font = new System.Drawing.Font("Wingdings", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.SettingsPage.ForeColor = System.Drawing.Color.White;
            this.SettingsPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SettingsPage.Location = new System.Drawing.Point(5, 6);
            this.SettingsPage.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.SettingsPage.Name = "SettingsPage";
            this.SettingsPage.Size = new System.Drawing.Size(30, 62);
            this.SettingsPage.TabIndex = 38;
            this.SettingsPage.TabStop = false;
            this.SettingsPage.Text = ":";
            this.SettingsPage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SettingsPage.UseCompatibleTextRendering = true;
            this.SettingsPage.UseVisualStyleBackColor = false;
            this.SettingsPage.Click += new System.EventHandler(this.SettingsPage_Click);
            // 
            // Search
            // 
            this.Search.BackColor = System.Drawing.Color.White;
            this.Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Search.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Search.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.Search.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.Search.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Search.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Search.ForeColor = System.Drawing.Color.Black;
            this.Search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Search.Location = new System.Drawing.Point(788, 40);
            this.Search.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(39, 37);
            this.Search.TabIndex = 41;
            this.Search.TabStop = false;
            this.Search.Text = "بحث";
            this.Search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Search.UseVisualStyleBackColor = false;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // CallerIDBTN
            // 
            this.CallerIDBTN.AllowDrop = true;
            this.CallerIDBTN.BackColor = System.Drawing.Color.Green;
            this.CallerIDBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CallerIDBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.CallerIDBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CallerIDBTN.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CallerIDBTN.ForeColor = System.Drawing.Color.White;
            this.CallerIDBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CallerIDBTN.Location = new System.Drawing.Point(686, 624);
            this.CallerIDBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.CallerIDBTN.Name = "CallerIDBTN";
            this.CallerIDBTN.Size = new System.Drawing.Size(38, 40);
            this.CallerIDBTN.TabIndex = 173;
            this.CallerIDBTN.TabStop = false;
            this.CallerIDBTN.Text = "#";
            this.CallerIDBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CallerIDBTN.UseVisualStyleBackColor = false;
            this.CallerIDBTN.Click += new System.EventHandler(this.CallerIDBTN_Click);
            this.CallerIDBTN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CallerIDBTN_MouseUp);
            // 
            // ShowMenuBTN
            // 
            this.ShowMenuBTN.BackColor = System.Drawing.Color.SlateGray;
            this.ShowMenuBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ShowMenuBTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ShowMenuBTN.FlatAppearance.BorderSize = 0;
            this.ShowMenuBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.ShowMenuBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.ShowMenuBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ShowMenuBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowMenuBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowMenuBTN.ForeColor = System.Drawing.Color.White;
            this.ShowMenuBTN.Image = global::OrderForm.Properties.Resources.bill_receipt_icon__1_1;
            this.ShowMenuBTN.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ShowMenuBTN.Location = new System.Drawing.Point(408, 797);
            this.ShowMenuBTN.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.ShowMenuBTN.Name = "ShowMenuBTN";
            this.ShowMenuBTN.Size = new System.Drawing.Size(188, 44);
            this.ShowMenuBTN.TabIndex = 171;
            this.ShowMenuBTN.TabStop = false;
            this.ShowMenuBTN.Text = "عرض الفاتورة";
            this.ShowMenuBTN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ShowMenuBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.ShowMenuBTN.UseCompatibleTextRendering = true;
            this.ShowMenuBTN.UseVisualStyleBackColor = false;
            this.ShowMenuBTN.Click += new System.EventHandler(this.ShowMenuBTN_Click);
            // 
            // unfocusableButton6
            // 
            this.unfocusableButton6.BackColor = System.Drawing.Color.LightSlateGray;
            this.unfocusableButton6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.unfocusableButton6.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.unfocusableButton6.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.unfocusableButton6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.unfocusableButton6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.unfocusableButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unfocusableButton6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unfocusableButton6.ForeColor = System.Drawing.Color.White;
            this.unfocusableButton6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.unfocusableButton6.Location = new System.Drawing.Point(766, 863);
            this.unfocusableButton6.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.unfocusableButton6.Name = "unfocusableButton6";
            this.unfocusableButton6.Size = new System.Drawing.Size(83, 27);
            this.unfocusableButton6.TabIndex = 170;
            this.unfocusableButton6.TabStop = false;
            this.unfocusableButton6.Text = " الطلب منشف ";
            this.unfocusableButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.unfocusableButton6.UseCompatibleTextRendering = true;
            this.unfocusableButton6.UseVisualStyleBackColor = false;
            this.unfocusableButton6.Click += new System.EventHandler(this.OrderCut_Click);
            // 
            // OrderCut
            // 
            this.OrderCut.BackColor = System.Drawing.Color.LightSlateGray;
            this.OrderCut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OrderCut.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.OrderCut.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.OrderCut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.OrderCut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.OrderCut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OrderCut.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderCut.ForeColor = System.Drawing.Color.White;
            this.OrderCut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OrderCut.Location = new System.Drawing.Point(852, 863);
            this.OrderCut.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.OrderCut.Name = "OrderCut";
            this.OrderCut.Size = new System.Drawing.Size(88, 27);
            this.OrderCut.TabIndex = 169;
            this.OrderCut.TabStop = false;
            this.OrderCut.Text = " الطلب مقطع ";
            this.OrderCut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OrderCut.UseCompatibleTextRendering = true;
            this.OrderCut.UseVisualStyleBackColor = false;
            this.OrderCut.Click += new System.EventHandler(this.OrderCut_Click);
            // 
            // LastOrder
            // 
            this.LastOrder.BackColor = System.Drawing.Color.LightSlateGray;
            this.LastOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.LastOrder.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.LastOrder.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.LastOrder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.LastOrder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.LastOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LastOrder.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastOrder.ForeColor = System.Drawing.Color.White;
            this.LastOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LastOrder.Location = new System.Drawing.Point(543, 673);
            this.LastOrder.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.LastOrder.Name = "LastOrder";
            this.LastOrder.Size = new System.Drawing.Size(76, 43);
            this.LastOrder.TabIndex = 167;
            this.LastOrder.TabStop = false;
            this.LastOrder.Text = "إدخال آخر طلب";
            this.LastOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.LastOrder.UseCompatibleTextRendering = true;
            this.LastOrder.UseVisualStyleBackColor = false;
            this.LastOrder.Visible = false;
            this.LastOrder.Click += new System.EventHandler(this.LastOrder_Click);
            // 
            // RepeatOrder
            // 
            this.RepeatOrder.BackColor = System.Drawing.Color.DarkTurquoise;
            this.RepeatOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RepeatOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RepeatOrder.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RepeatOrder.ForeColor = System.Drawing.Color.White;
            this.RepeatOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RepeatOrder.Location = new System.Drawing.Point(193, 834);
            this.RepeatOrder.Margin = new System.Windows.Forms.Padding(1);
            this.RepeatOrder.Name = "RepeatOrder";
            this.RepeatOrder.Size = new System.Drawing.Size(125, 35);
            this.RepeatOrder.TabIndex = 0;
            this.RepeatOrder.TabStop = false;
            this.RepeatOrder.Text = "إعادة تحضير الطلب";
            this.RepeatOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.RepeatOrder.UseVisualStyleBackColor = false;
            this.RepeatOrder.Visible = false;
            this.RepeatOrder.Click += new System.EventHandler(this.RepeatOrder_Click);
            // 
            // NewBTN
            // 
            this.NewBTN.BackColor = System.Drawing.Color.SlateGray;
            this.NewBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.NewBTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.NewBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.NewBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.NewBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.NewBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewBTN.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.NewBTN.ForeColor = System.Drawing.Color.White;
            this.NewBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NewBTN.Location = new System.Drawing.Point(38, 3);
            this.NewBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.NewBTN.Name = "NewBTN";
            this.NewBTN.Size = new System.Drawing.Size(96, 30);
            this.NewBTN.TabIndex = 41;
            this.NewBTN.TabStop = false;
            this.NewBTN.Text = "طلبية جديدة";
            this.NewBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.NewBTN.UseVisualStyleBackColor = false;
            this.NewBTN.Click += new System.EventHandler(this.NewBTN_Click);
            // 
            // DeleteTouchBTN
            // 
            this.DeleteTouchBTN.BackColor = System.Drawing.Color.Red;
            this.DeleteTouchBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.DeleteTouchBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteTouchBTN.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteTouchBTN.ForeColor = System.Drawing.Color.White;
            this.DeleteTouchBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteTouchBTN.Location = new System.Drawing.Point(332, 564);
            this.DeleteTouchBTN.Margin = new System.Windows.Forms.Padding(1);
            this.DeleteTouchBTN.Name = "DeleteTouchBTN";
            this.DeleteTouchBTN.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DeleteTouchBTN.Size = new System.Drawing.Size(113, 50);
            this.DeleteTouchBTN.TabIndex = 0;
            this.DeleteTouchBTN.TabStop = false;
            this.DeleteTouchBTN.Text = "حذف المادة";
            this.DeleteTouchBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DeleteTouchBTN.UseVisualStyleBackColor = false;
            this.DeleteTouchBTN.Click += new System.EventHandler(this.DeleteTouchBTN_Click);
            // 
            // FiveBTN
            // 
            this.FiveBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.FiveBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.FiveBTN.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.FiveBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.FiveBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.FiveBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.FiveBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FiveBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FiveBTN.ForeColor = System.Drawing.Color.White;
            this.FiveBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FiveBTN.Location = new System.Drawing.Point(123, 665);
            this.FiveBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.FiveBTN.Name = "FiveBTN";
            this.FiveBTN.Size = new System.Drawing.Size(97, 50);
            this.FiveBTN.TabIndex = 47;
            this.FiveBTN.TabStop = false;
            this.FiveBTN.Text = "5";
            this.FiveBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.FiveBTN.UseVisualStyleBackColor = false;
            this.FiveBTN.Click += new System.EventHandler(this.NumberBTN_Click);
            // 
            // SixBTN
            // 
            this.SixBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.SixBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SixBTN.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.SixBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.SixBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.SixBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.SixBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SixBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SixBTN.ForeColor = System.Drawing.Color.White;
            this.SixBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SixBTN.Location = new System.Drawing.Point(225, 665);
            this.SixBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.SixBTN.Name = "SixBTN";
            this.SixBTN.Size = new System.Drawing.Size(97, 50);
            this.SixBTN.TabIndex = 46;
            this.SixBTN.TabStop = false;
            this.SixBTN.Text = "6";
            this.SixBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SixBTN.UseVisualStyleBackColor = false;
            this.SixBTN.Click += new System.EventHandler(this.NumberBTN_Click);
            // 
            // SevenBTN
            // 
            this.SevenBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.SevenBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SevenBTN.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.SevenBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.SevenBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.SevenBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.SevenBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SevenBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SevenBTN.ForeColor = System.Drawing.Color.White;
            this.SevenBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SevenBTN.Location = new System.Drawing.Point(22, 611);
            this.SevenBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.SevenBTN.Name = "SevenBTN";
            this.SevenBTN.Size = new System.Drawing.Size(97, 50);
            this.SevenBTN.TabIndex = 45;
            this.SevenBTN.TabStop = false;
            this.SevenBTN.Text = "7";
            this.SevenBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SevenBTN.UseVisualStyleBackColor = false;
            this.SevenBTN.Click += new System.EventHandler(this.NumberBTN_Click);
            // 
            // EightBTN
            // 
            this.EightBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.EightBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.EightBTN.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.EightBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.EightBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.EightBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.EightBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EightBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EightBTN.ForeColor = System.Drawing.Color.White;
            this.EightBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EightBTN.Location = new System.Drawing.Point(123, 611);
            this.EightBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.EightBTN.Name = "EightBTN";
            this.EightBTN.Size = new System.Drawing.Size(97, 50);
            this.EightBTN.TabIndex = 44;
            this.EightBTN.TabStop = false;
            this.EightBTN.Text = "8";
            this.EightBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EightBTN.UseVisualStyleBackColor = false;
            this.EightBTN.Click += new System.EventHandler(this.NumberBTN_Click);
            // 
            // NineBTN
            // 
            this.NineBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.NineBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.NineBTN.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.NineBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.NineBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.NineBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.NineBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NineBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NineBTN.ForeColor = System.Drawing.Color.White;
            this.NineBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NineBTN.Location = new System.Drawing.Point(225, 611);
            this.NineBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.NineBTN.Name = "NineBTN";
            this.NineBTN.Size = new System.Drawing.Size(97, 50);
            this.NineBTN.TabIndex = 43;
            this.NineBTN.TabStop = false;
            this.NineBTN.Text = "9";
            this.NineBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.NineBTN.UseVisualStyleBackColor = false;
            this.NineBTN.Click += new System.EventHandler(this.NumberBTN_Click);
            // 
            // ZeroBTN
            // 
            this.ZeroBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.ZeroBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ZeroBTN.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.ZeroBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.ZeroBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.ZeroBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.ZeroBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ZeroBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZeroBTN.ForeColor = System.Drawing.Color.White;
            this.ZeroBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ZeroBTN.Location = new System.Drawing.Point(123, 771);
            this.ZeroBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.ZeroBTN.Name = "ZeroBTN";
            this.ZeroBTN.Size = new System.Drawing.Size(97, 51);
            this.ZeroBTN.TabIndex = 42;
            this.ZeroBTN.TabStop = false;
            this.ZeroBTN.Text = "0";
            this.ZeroBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ZeroBTN.UseVisualStyleBackColor = false;
            this.ZeroBTN.Click += new System.EventHandler(this.NumberBTN_Click);
            // 
            // BackSpaceBTN
            // 
            this.BackSpaceBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.BackSpaceBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BackSpaceBTN.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.BackSpaceBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.BackSpaceBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.BackSpaceBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.BackSpaceBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackSpaceBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackSpaceBTN.ForeColor = System.Drawing.Color.White;
            this.BackSpaceBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackSpaceBTN.Location = new System.Drawing.Point(22, 771);
            this.BackSpaceBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.BackSpaceBTN.Name = "BackSpaceBTN";
            this.BackSpaceBTN.Size = new System.Drawing.Size(97, 51);
            this.BackSpaceBTN.TabIndex = 41;
            this.BackSpaceBTN.TabStop = false;
            this.BackSpaceBTN.Text = "مسح ";
            this.BackSpaceBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BackSpaceBTN.UseVisualStyleBackColor = false;
            this.BackSpaceBTN.Click += new System.EventHandler(this.NumberBTN_Click);
            // 
            // EnterBTN
            // 
            this.EnterBTN.BackColor = System.Drawing.Color.LawnGreen;
            this.EnterBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.EnterBTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.EnterBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.EnterBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.EnterBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.EnterBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EnterBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterBTN.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EnterBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EnterBTN.Location = new System.Drawing.Point(225, 771);
            this.EnterBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.EnterBTN.Name = "EnterBTN";
            this.EnterBTN.Size = new System.Drawing.Size(97, 51);
            this.EnterBTN.TabIndex = 40;
            this.EnterBTN.TabStop = false;
            this.EnterBTN.Text = "إدخال";
            this.EnterBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EnterBTN.UseVisualStyleBackColor = false;
            this.EnterBTN.Click += new System.EventHandler(this.NumberBTN_Click);
            // 
            // UpBTN
            // 
            this.UpBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.UpBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.UpBTN.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.UpBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.UpBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.UpBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.UpBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpBTN.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpBTN.ForeColor = System.Drawing.Color.White;
            this.UpBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UpBTN.Location = new System.Drawing.Point(332, 639);
            this.UpBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.UpBTN.Name = "UpBTN";
            this.UpBTN.Size = new System.Drawing.Size(113, 50);
            this.UpBTN.TabIndex = 39;
            this.UpBTN.TabStop = false;
            this.UpBTN.Text = "+";
            this.UpBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.UpBTN.UseCompatibleTextRendering = true;
            this.UpBTN.UseVisualStyleBackColor = false;
            this.UpBTN.Click += new System.EventHandler(this.PlusBTN_Click);
            this.UpBTN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PlusBTN_MouseUp);
            // 
            // DownBTN
            // 
            this.DownBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.DownBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DownBTN.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.DownBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.DownBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.DownBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.DownBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownBTN.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownBTN.ForeColor = System.Drawing.Color.White;
            this.DownBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DownBTN.Location = new System.Drawing.Point(332, 692);
            this.DownBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.DownBTN.Name = "DownBTN";
            this.DownBTN.Size = new System.Drawing.Size(113, 50);
            this.DownBTN.TabIndex = 38;
            this.DownBTN.TabStop = false;
            this.DownBTN.Text = "-";
            this.DownBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DownBTN.UseCompatibleTextRendering = true;
            this.DownBTN.UseVisualStyleBackColor = false;
            this.DownBTN.Click += new System.EventHandler(this.DownBTN_Click);
            this.DownBTN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DownBTN_MouseUp);
            // 
            // OneBTN
            // 
            this.OneBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.OneBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OneBTN.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.OneBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.OneBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.OneBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.OneBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OneBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OneBTN.ForeColor = System.Drawing.Color.White;
            this.OneBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OneBTN.Location = new System.Drawing.Point(22, 718);
            this.OneBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.OneBTN.Name = "OneBTN";
            this.OneBTN.Size = new System.Drawing.Size(97, 50);
            this.OneBTN.TabIndex = 34;
            this.OneBTN.TabStop = false;
            this.OneBTN.Text = "1";
            this.OneBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OneBTN.UseVisualStyleBackColor = false;
            this.OneBTN.Click += new System.EventHandler(this.NumberBTN_Click);
            // 
            // TwoBTN
            // 
            this.TwoBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.TwoBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TwoBTN.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.TwoBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.TwoBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.TwoBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.TwoBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TwoBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TwoBTN.ForeColor = System.Drawing.Color.White;
            this.TwoBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TwoBTN.Location = new System.Drawing.Point(123, 718);
            this.TwoBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.TwoBTN.Name = "TwoBTN";
            this.TwoBTN.Size = new System.Drawing.Size(97, 50);
            this.TwoBTN.TabIndex = 33;
            this.TwoBTN.TabStop = false;
            this.TwoBTN.Text = "2";
            this.TwoBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.TwoBTN.UseVisualStyleBackColor = false;
            this.TwoBTN.Click += new System.EventHandler(this.NumberBTN_Click);
            // 
            // ThreeBTN
            // 
            this.ThreeBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.ThreeBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ThreeBTN.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.ThreeBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.ThreeBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.ThreeBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.ThreeBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ThreeBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThreeBTN.ForeColor = System.Drawing.Color.White;
            this.ThreeBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ThreeBTN.Location = new System.Drawing.Point(225, 718);
            this.ThreeBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.ThreeBTN.Name = "ThreeBTN";
            this.ThreeBTN.Size = new System.Drawing.Size(97, 50);
            this.ThreeBTN.TabIndex = 32;
            this.ThreeBTN.TabStop = false;
            this.ThreeBTN.Text = "3";
            this.ThreeBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ThreeBTN.UseVisualStyleBackColor = false;
            this.ThreeBTN.Click += new System.EventHandler(this.NumberBTN_Click);
            // 
            // FourBTN
            // 
            this.FourBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.FourBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.FourBTN.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.FourBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.FourBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.FourBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.FourBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FourBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FourBTN.ForeColor = System.Drawing.Color.White;
            this.FourBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FourBTN.Location = new System.Drawing.Point(22, 665);
            this.FourBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.FourBTN.Name = "FourBTN";
            this.FourBTN.Size = new System.Drawing.Size(97, 50);
            this.FourBTN.TabIndex = 31;
            this.FourBTN.TabStop = false;
            this.FourBTN.Text = "4";
            this.FourBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.FourBTN.UseVisualStyleBackColor = false;
            this.FourBTN.Click += new System.EventHandler(this.NumberBTN_Click);
            // 
            // TimeInfo
            // 
            this.TimeInfo.BackColor = System.Drawing.Color.LightSlateGray;
            this.TimeInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TimeInfo.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.TimeInfo.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.TimeInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.TimeInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.TimeInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TimeInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeInfo.ForeColor = System.Drawing.Color.White;
            this.TimeInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TimeInfo.Location = new System.Drawing.Point(623, 722);
            this.TimeInfo.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.TimeInfo.Name = "TimeInfo";
            this.TimeInfo.Size = new System.Drawing.Size(163, 43);
            this.TimeInfo.TabIndex = 54;
            this.TimeInfo.TabStop = false;
            this.TimeInfo.Text = "الآن";
            this.TimeInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.TimeInfo.UseVisualStyleBackColor = false;
            this.TimeInfo.TextChanged += new System.EventHandler(this.MobileTB_TextChanged);
            this.TimeInfo.Click += new System.EventHandler(this.TimeInfo_Click);
            // 
            // WhatAppBTN
            // 
            this.WhatAppBTN.AllowDrop = true;
            this.WhatAppBTN.BackColor = System.Drawing.Color.Green;
            this.WhatAppBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.WhatAppBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.WhatAppBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WhatAppBTN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WhatAppBTN.ForeColor = System.Drawing.Color.White;
            this.WhatAppBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.WhatAppBTN.Location = new System.Drawing.Point(589, 624);
            this.WhatAppBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.WhatAppBTN.Name = "WhatAppBTN";
            this.WhatAppBTN.Size = new System.Drawing.Size(96, 40);
            this.WhatAppBTN.TabIndex = 29;
            this.WhatAppBTN.TabStop = false;
            this.WhatAppBTN.Text = "WhatsApp";
            this.WhatAppBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.WhatAppBTN.UseVisualStyleBackColor = false;
            this.WhatAppBTN.Click += new System.EventHandler(this.WhatsAppBTN_Click);
            this.WhatAppBTN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WhatAppBTN_MouseUp);
            // 
            // DayMenuBTN
            // 
            this.DayMenuBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.DayMenuBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DayMenuBTN.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.DayMenuBTN.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.DayMenuBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.DayMenuBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.DayMenuBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DayMenuBTN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DayMenuBTN.ForeColor = System.Drawing.Color.White;
            this.DayMenuBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DayMenuBTN.Location = new System.Drawing.Point(622, 772);
            this.DayMenuBTN.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.DayMenuBTN.Name = "DayMenuBTN";
            this.DayMenuBTN.Size = new System.Drawing.Size(163, 43);
            this.DayMenuBTN.TabIndex = 55;
            this.DayMenuBTN.TabStop = false;
            this.DayMenuBTN.Text = "اليوم";
            this.DayMenuBTN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DayMenuBTN.UseVisualStyleBackColor = false;
            this.DayMenuBTN.TextChanged += new System.EventHandler(this.MobileTB_TextChanged);
            this.DayMenuBTN.Click += new System.EventHandler(this.DayBTN_Click);
            // 
            // Orders
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(961, 1009);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.OrdersPanel);
            this.DoubleBuffered = true;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(945, 0);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(977, 1048);
            this.MinimumSize = new System.Drawing.Size(977, 1038);
            this.Name = "Orders";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Orders_FormClosing);
            this.Load += new System.EventHandler(this.Orders_Load);
            this.rightClickMenu.ResumeLayout(false);
            this.OrdersPanel.ResumeLayout(false);
            this.OrdersPanel.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InvoicesDG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvItems)).EndInit();
            this.InvoiceTypeOptions.ResumeLayout(false);
            this.InvoiceTypeOptions.PerformLayout();
            this.MenuSelection.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.SalahTimes.ResumeLayout(false);
            this.SalahTimes.PerformLayout();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.ContextMenuStrip rightClickMenu;
        public System.Windows.Forms.Timer SalahTMR;
        private System.Windows.Forms.ToolStripMenuItem ItemNameTag;
        private System.Windows.Forms.ToolStripSeparator sep;
        private System.Windows.Forms.ToolStripMenuItem commentBTN;
        private System.Windows.Forms.ToolStripMenuItem DeleteBTN;
        private System.Windows.Forms.ToolStripMenuItem CustomComment;
        private System.Windows.Forms.Panel OrdersPanel;
        private System.Windows.Forms.ContextMenuStrip DayMenu;
        private System.Windows.Forms.ContextMenuStrip HourPicker;
        private System.Windows.Forms.ContextMenuStrip MinutesPicker;
        private System.Windows.Forms.ContextMenuStrip TODPicker;
        private System.Windows.Forms.ContextMenuStrip FastComment;
        private System.Windows.Forms.ContextMenuStrip MenuSelection;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        public System.Windows.Forms.Timer MenuTimeOut;
        private System.Windows.Forms.PrintDialog printComment;
        private System.Windows.Forms.ContextMenuStrip WhatsSend;
        private System.Windows.Forms.Timer Api_Health;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private UButton Search;
        private System.Windows.Forms.CheckBox GroupSave;
        private System.Windows.Forms.RadioButton AllDays;
        private System.Windows.Forms.RadioButton History;
        private System.Windows.Forms.Label SearchLBL;
        private System.Windows.Forms.RadioButton Sat;
        private System.Windows.Forms.TextBox SearchTB;
        private System.Windows.Forms.RadioButton Sun;
        private System.Windows.Forms.RadioButton Mon;
        private System.Windows.Forms.RadioButton Fri;
        private System.Windows.Forms.RadioButton Tue;
        private System.Windows.Forms.RadioButton Thu;
        private System.Windows.Forms.RadioButton Wed;
        private System.Windows.Forms.Panel panel2;
        private UButton OrdersPage;
        private UButton MainMenu;
        private System.Windows.Forms.FlowLayoutPanel SalahTimes;
        private System.Windows.Forms.CheckBox langCheck;
        private UButton changeMenu;
        private UButton TimeLeftLBL;
        private UButton TimeTillCountdown;
        private UButton DhuhrLBL;
        private UButton DhuhrBTN;
        private UButton AsrLBL;
        private UButton AsrBTN;
        private UButton MaghribLBL;
        private UButton MaghribBTN;
        private UButton IshaLBL;
        private UButton IshaBTN;
        private UButton DateLBL;
        private UButton DayLBL;
        public UButton TimeButton;
        public UButton CopyInvoice;
        private UButton SettingsPage;
        private System.ComponentModel.BackgroundWorker CIDWorker;
        private UButton CallerIDBTN;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label CommentLBL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label NameLBL;
        private System.Windows.Forms.Label MobileLBL;
        private UButton ShowMenuBTN;
        private System.Windows.Forms.FlowLayoutPanel ItemsPanel1;
        private UButton unfocusableButton6;
        private UButton OrderCut;
        public System.Windows.Forms.Label AmountLBL;
        public System.Windows.Forms.DataGridView dvItems;
        private UButton LastOrder;
        private UButton RepeatOrder;
        public System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button HoldInvoice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label ItemCount;
        private System.Windows.Forms.Button DeleteInvoice;
        private System.Windows.Forms.Button SaveInvoice;
        private UButton NewBTN;
        public System.Windows.Forms.TextBox InvoiceNumberID;
        private System.Windows.Forms.Button PrintSave;
        private UButton DeleteTouchBTN;
        private UButton FiveBTN;
        private UButton SixBTN;
        private UButton SevenBTN;
        private UButton EightBTN;
        private UButton NineBTN;
        private UButton ZeroBTN;
        private UButton BackSpaceBTN;
        private UButton EnterBTN;
        private UButton UpBTN;
        private UButton DownBTN;
        private UButton OneBTN;
        private UButton TwoBTN;
        private UButton ThreeBTN;
        private UButton FourBTN;
        private System.Windows.Forms.FlowLayoutPanel SectionsPanel;
        public System.Windows.Forms.TextBox DOWTB;
        private System.Windows.Forms.TextBox TimeTB;
        private UButton TimeInfo;
        public System.Windows.Forms.TextBox CommentTB;
        private UButton WhatAppBTN;
        public System.Windows.Forms.TextBox MobileTB;
        public System.Windows.Forms.TextBox NameTB;
        private UButton DayMenuBTN;
        private System.Windows.Forms.Label AmountPriceLBL;
        public System.Windows.Forms.ToolStrip InvoiceTypeOptions;
        private System.Windows.Forms.ToolStripButton TelButton;
        private System.Windows.Forms.ToolStripButton ToGoButton;
        private System.Windows.Forms.ToolStripButton DineButton;
        private System.Windows.Forms.ToolStripButton AppsButton;
        private System.Windows.Forms.Button OrderStatus;
        internal System.Windows.Forms.DataGridView InvoicesDG;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton PrintMultiTool;
        private System.Windows.Forms.ToolStripButton MultiSave_;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton SaveJahezAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.RadioButton Draft;
        private System.Windows.Forms.ToolStripButton OrdersReady;
    }
}