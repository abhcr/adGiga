namespace ShopKeeper
{
    partial class EstimateForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EstimateForm));
            this.purchaseGrid = new System.Windows.Forms.DataGridView();
            this.itemNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemEditContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.stockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taxRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todaysSaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameGroupBox = new System.Windows.Forms.GroupBox();
            this.phoneNo = new System.Windows.Forms.Label();
            this.customerDetail = new System.Windows.Forms.Label();
            this.customerName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.totalBalance = new System.Windows.Forms.LinkLabel();
            this.totalGroupBox = new System.Windows.Forms.GroupBox();
            this.currentTotal = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.eMoney = new System.Windows.Forms.CheckBox();
            this.currentPayment = new System.Windows.Forms.TextBox();
            this.remark = new System.Windows.Forms.TextBox();
            this.savePrint = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.justPrint = new System.Windows.Forms.Button();
            this.helpTips = new System.Windows.Forms.ToolTip(this.components);
            this.updateItems = new System.Windows.Forms.CheckBox();
            this.orderClosedBy = new System.Windows.Forms.TextBox();
            this.closeOrder = new System.Windows.Forms.CheckBox();
            this.receiptNo = new System.Windows.Forms.TextBox();
            this.parcelAgent = new System.Windows.Forms.TextBox();
            this.packedBy = new System.Windows.Forms.TextBox();
            this.sentDate = new System.Windows.Forms.DateTimePicker();
            this.orderDate = new System.Windows.Forms.DateTimePicker();
            this.delete = new System.Windows.Forms.Button();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.ordered = new System.Windows.Forms.CheckBox();
            this.sent = new System.Windows.Forms.CheckBox();
            this.orderStatGroup = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.quitButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.estimateDatePicker = new ShopKeeper.ColorableDatePicker();
            this.projectSelector = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseGrid)).BeginInit();
            this.itemEditContextMenu.SuspendLayout();
            this.nameGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.totalGroupBox.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.orderStatGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // purchaseGrid
            // 
            this.purchaseGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.purchaseGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.purchaseGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemNo,
            this.itemName,
            this.itemQuantity,
            this.itemRate,
            this.itemUnit,
            this.itemTotal,
            this.id,
            this.itemId});
            this.purchaseGrid.Location = new System.Drawing.Point(14, 110);
            this.purchaseGrid.MultiSelect = false;
            this.purchaseGrid.Name = "purchaseGrid";
            this.purchaseGrid.RowHeadersWidth = 25;
            this.purchaseGrid.Size = new System.Drawing.Size(674, 181);
            this.purchaseGrid.TabIndex = 1;
            this.purchaseGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.purchaseGrid_CellEndEdit);
            this.purchaseGrid.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.purchaseGrid_CellLeave);
            this.purchaseGrid.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.purchaseGrid_CellMouseDown);
            this.purchaseGrid.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.purchaseGrid_CellValidated);
            this.purchaseGrid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.purchaseGrid_CellValidating);
            this.purchaseGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.purchaseGrid_CellValueChanged);
            this.purchaseGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.purchaseGrid_EditingControlShowing);
            this.purchaseGrid.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.purchaseGrid_RowValidated);
            this.purchaseGrid.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.purchaseGrid_RowValidating);
            this.purchaseGrid.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.purchaseGrid_UserAddedRow);
            this.purchaseGrid.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.purchaseGrid_UserDeletedRow);
            // 
            // itemNo
            // 
            this.itemNo.HeaderText = "No.";
            this.itemNo.Name = "itemNo";
            this.itemNo.ReadOnly = true;
            this.itemNo.Width = 30;
            // 
            // itemName
            // 
            this.itemName.ContextMenuStrip = this.itemEditContextMenu;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.itemName.DefaultCellStyle = dataGridViewCellStyle1;
            this.itemName.HeaderText = "Item";
            this.itemName.MaxInputLength = 256;
            this.itemName.Name = "itemName";
            this.itemName.Width = 200;
            // 
            // itemEditContextMenu
            // 
            this.itemEditContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stockToolStripMenuItem,
            this.taxRateToolStripMenuItem,
            this.todaysSaleToolStripMenuItem});
            this.itemEditContextMenu.Name = "itemEditContextMenu";
            this.itemEditContextMenu.Size = new System.Drawing.Size(140, 70);
            this.itemEditContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.itemEditContextMenu_Opening);
            this.itemEditContextMenu.Opened += new System.EventHandler(this.itemEditContextMenu_Opened);
            // 
            // stockToolStripMenuItem
            // 
            this.stockToolStripMenuItem.Name = "stockToolStripMenuItem";
            this.stockToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.stockToolStripMenuItem.Text = "Stock";
            this.stockToolStripMenuItem.Click += new System.EventHandler(this.stockToolStripMenuItem_Click);
            // 
            // taxRateToolStripMenuItem
            // 
            this.taxRateToolStripMenuItem.Name = "taxRateToolStripMenuItem";
            this.taxRateToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.taxRateToolStripMenuItem.Text = "Tax Rate";
            this.taxRateToolStripMenuItem.Click += new System.EventHandler(this.taxRateToolStripMenuItem_Click);
            // 
            // todaysSaleToolStripMenuItem
            // 
            this.todaysSaleToolStripMenuItem.Name = "todaysSaleToolStripMenuItem";
            this.todaysSaleToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.todaysSaleToolStripMenuItem.Text = "Today\'s Sale";
            this.todaysSaleToolStripMenuItem.Click += new System.EventHandler(this.todaysSaleToolStripMenuItem_Click);
            // 
            // itemQuantity
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightBlue;
            this.itemQuantity.DefaultCellStyle = dataGridViewCellStyle2;
            this.itemQuantity.HeaderText = "Quantity";
            this.itemQuantity.Name = "itemQuantity";
            this.itemQuantity.Width = 60;
            // 
            // itemRate
            // 
            this.itemRate.HeaderText = "Rate";
            this.itemRate.Name = "itemRate";
            this.itemRate.Width = 65;
            // 
            // itemUnit
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Lavender;
            this.itemUnit.DefaultCellStyle = dataGridViewCellStyle3;
            this.itemUnit.HeaderText = "Unit";
            this.itemUnit.Name = "itemUnit";
            this.itemUnit.Width = 50;
            // 
            // itemTotal
            // 
            this.itemTotal.HeaderText = "Total";
            this.itemTotal.Name = "itemTotal";
            this.itemTotal.ReadOnly = true;
            this.itemTotal.Width = 90;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // itemId
            // 
            this.itemId.HeaderText = "itemId";
            this.itemId.Name = "itemId";
            this.itemId.ReadOnly = true;
            this.itemId.Visible = false;
            // 
            // nameGroupBox
            // 
            this.nameGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nameGroupBox.Controls.Add(this.phoneNo);
            this.nameGroupBox.Controls.Add(this.customerDetail);
            this.nameGroupBox.Controls.Add(this.customerName);
            this.nameGroupBox.Location = new System.Drawing.Point(6, 10);
            this.nameGroupBox.Name = "nameGroupBox";
            this.nameGroupBox.Size = new System.Drawing.Size(453, 89);
            this.nameGroupBox.TabIndex = 0;
            this.nameGroupBox.TabStop = false;
            this.nameGroupBox.Text = "Customer";
            // 
            // phoneNo
            // 
            this.phoneNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.phoneNo.AutoSize = true;
            this.phoneNo.Location = new System.Drawing.Point(314, 26);
            this.phoneNo.Name = "phoneNo";
            this.phoneNo.Size = new System.Drawing.Size(25, 15);
            this.phoneNo.TabIndex = 103;
            this.phoneNo.Text = "Ph:";
            // 
            // customerDetail
            // 
            this.customerDetail.AutoSize = true;
            this.customerDetail.Location = new System.Drawing.Point(22, 54);
            this.customerDetail.Name = "customerDetail";
            this.customerDetail.Size = new System.Drawing.Size(0, 15);
            this.customerDetail.TabIndex = 102;
            // 
            // customerName
            // 
            this.customerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.customerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.customerName.Location = new System.Drawing.Point(20, 23);
            this.customerName.Name = "customerName";
            this.customerName.Size = new System.Drawing.Size(288, 21);
            this.customerName.TabIndex = 101;
            this.customerName.TextChanged += new System.EventHandler(this.customerName_TextChanged);
            this.customerName.Enter += new System.EventHandler(this.customerName_Enter);
            this.customerName.Leave += new System.EventHandler(this.customerName_Leave);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.totalBalance);
            this.groupBox2.Location = new System.Drawing.Point(468, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 58);
            this.groupBox2.TabIndex = 100;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Total Pending";
            // 
            // totalBalance
            // 
            this.totalBalance.AutoSize = true;
            this.totalBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.totalBalance.ForeColor = System.Drawing.Color.DarkRed;
            this.totalBalance.LinkColor = System.Drawing.Color.DarkRed;
            this.totalBalance.Location = new System.Drawing.Point(9, 21);
            this.totalBalance.Name = "totalBalance";
            this.totalBalance.Size = new System.Drawing.Size(0, 24);
            this.totalBalance.TabIndex = 0;
            this.totalBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.helpTips.SetToolTip(this.totalBalance, "Payment pending for the selected customer\r\nClick to view details!");
            this.totalBalance.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.previousBalance_LinkClicked);
            // 
            // totalGroupBox
            // 
            this.totalGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.totalGroupBox.Controls.Add(this.currentTotal);
            this.totalGroupBox.Location = new System.Drawing.Point(14, 297);
            this.totalGroupBox.Name = "totalGroupBox";
            this.totalGroupBox.Size = new System.Drawing.Size(251, 77);
            this.totalGroupBox.TabIndex = 3;
            this.totalGroupBox.TabStop = false;
            this.totalGroupBox.Text = "Sale Total";
            // 
            // currentTotal
            // 
            this.currentTotal.AutoSize = true;
            this.currentTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentTotal.ForeColor = System.Drawing.Color.DarkRed;
            this.currentTotal.Location = new System.Drawing.Point(17, 28);
            this.currentTotal.Name = "currentTotal";
            this.currentTotal.Size = new System.Drawing.Size(0, 24);
            this.currentTotal.TabIndex = 0;
            this.currentTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.helpTips.SetToolTip(this.currentTotal, "Grand total of this transaction");
            this.currentTotal.TextChanged += new System.EventHandler(this.currentTotal_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.eMoney);
            this.groupBox4.Controls.Add(this.currentPayment);
            this.groupBox4.Location = new System.Drawing.Point(272, 297);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(218, 77);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Now Paying";
            // 
            // eMoney
            // 
            this.eMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.eMoney.AutoSize = true;
            this.eMoney.Location = new System.Drawing.Point(107, 53);
            this.eMoney.Name = "eMoney";
            this.eMoney.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.eMoney.Size = new System.Drawing.Size(103, 17);
            this.eMoney.TabIndex = 1;
            this.eMoney.Text = "DD &Chq Deposit";
            this.helpTips.SetToolTip(this.eMoney, "Check this if not cash");
            this.eMoney.UseVisualStyleBackColor = true;
            this.eMoney.CheckedChanged += new System.EventHandler(this.eMoney_CheckedChanged);
            // 
            // currentPayment
            // 
            this.currentPayment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.currentPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.currentPayment.ForeColor = System.Drawing.Color.DarkGreen;
            this.currentPayment.Location = new System.Drawing.Point(30, 18);
            this.currentPayment.Name = "currentPayment";
            this.currentPayment.Size = new System.Drawing.Size(180, 29);
            this.currentPayment.TabIndex = 0;
            this.currentPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.helpTips.SetToolTip(this.currentPayment, "Amount currently paying");
            this.currentPayment.TextChanged += new System.EventHandler(this.currentPayment_TextChanged);
            this.currentPayment.Enter += new System.EventHandler(this.currentPayment_Enter);
            this.currentPayment.Leave += new System.EventHandler(this.currentPayment_Leave);
            this.currentPayment.Validating += new System.ComponentModel.CancelEventHandler(this.currentPayment_Validating);
            this.currentPayment.Validated += new System.EventHandler(this.currentPayment_Validated);
            // 
            // remark
            // 
            this.remark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.remark.Location = new System.Drawing.Point(206, 396);
            this.remark.Name = "remark";
            this.remark.Size = new System.Drawing.Size(287, 21);
            this.remark.TabIndex = 3;
            this.helpTips.SetToolTip(this.remark, "Enter comments if any");
            this.remark.TextChanged += new System.EventHandler(this.remark_TextChanged);
            this.remark.Enter += new System.EventHandler(this.remark_Enter);
            this.remark.Leave += new System.EventHandler(this.remark_Leave);
            // 
            // savePrint
            // 
            this.savePrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.savePrint.Location = new System.Drawing.Point(499, 306);
            this.savePrint.Name = "savePrint";
            this.savePrint.Size = new System.Drawing.Size(112, 68);
            this.savePrint.TabIndex = 4;
            this.savePrint.Text = "Save && &Print";
            this.helpTips.SetToolTip(this.savePrint, "Save transaction, print and close window");
            this.savePrint.UseVisualStyleBackColor = true;
            this.savePrint.Click += new System.EventHandler(this.savePrint_Click);
            // 
            // save
            // 
            this.save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.save.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.save.Location = new System.Drawing.Point(618, 306);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(69, 68);
            this.save.TabIndex = 5;
            this.save.Text = "&Save";
            this.helpTips.SetToolTip(this.save, "Just save the transaction without \r\nprinting, and close the window");
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // justPrint
            // 
            this.justPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.justPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.justPrint.Enabled = false;
            this.justPrint.Location = new System.Drawing.Point(499, 380);
            this.justPrint.Name = "justPrint";
            this.justPrint.Size = new System.Drawing.Size(112, 53);
            this.justPrint.TabIndex = 7;
            this.justPrint.Text = "&Just Print";
            this.helpTips.SetToolTip(this.justPrint, "Just print without records");
            this.justPrint.UseVisualStyleBackColor = true;
            this.justPrint.Click += new System.EventHandler(this.justPrint_Click);
            // 
            // helpTips
            // 
            this.helpTips.IsBalloon = true;
            // 
            // updateItems
            // 
            this.updateItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.updateItems.AutoSize = true;
            this.updateItems.Location = new System.Drawing.Point(620, 442);
            this.updateItems.Name = "updateItems";
            this.updateItems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.updateItems.Size = new System.Drawing.Size(66, 34);
            this.updateItems.TabIndex = 102;
            this.updateItems.Text = "&Update\r\nItems";
            this.helpTips.SetToolTip(this.updateItems, "Check this box if you want to \r\nkeep the changes made to items");
            this.updateItems.UseVisualStyleBackColor = true;
            // 
            // orderClosedBy
            // 
            this.orderClosedBy.Enabled = false;
            this.orderClosedBy.Location = new System.Drawing.Point(371, 47);
            this.orderClosedBy.Name = "orderClosedBy";
            this.orderClosedBy.Size = new System.Drawing.Size(74, 21);
            this.orderClosedBy.TabIndex = 118;
            this.helpTips.SetToolTip(this.orderClosedBy, "Staff who closed order");
            // 
            // closeOrder
            // 
            this.closeOrder.AutoSize = true;
            this.closeOrder.Enabled = false;
            this.closeOrder.Location = new System.Drawing.Point(369, 21);
            this.closeOrder.Name = "closeOrder";
            this.closeOrder.Size = new System.Drawing.Size(74, 17);
            this.closeOrder.TabIndex = 117;
            this.closeOrder.Text = "&End Order";
            this.helpTips.SetToolTip(this.closeOrder, "Customer Informed");
            this.closeOrder.UseVisualStyleBackColor = true;
            this.closeOrder.CheckedChanged += new System.EventHandler(this.closeOrder_CheckedChanged);
            // 
            // receiptNo
            // 
            this.receiptNo.Enabled = false;
            this.receiptNo.Location = new System.Drawing.Point(462, 47);
            this.receiptNo.Name = "receiptNo";
            this.receiptNo.Size = new System.Drawing.Size(99, 21);
            this.receiptNo.TabIndex = 116;
            this.helpTips.SetToolTip(this.receiptNo, "Transportation Receipt No");
            // 
            // parcelAgent
            // 
            this.parcelAgent.Enabled = false;
            this.parcelAgent.Location = new System.Drawing.Point(103, 48);
            this.parcelAgent.Name = "parcelAgent";
            this.parcelAgent.Size = new System.Drawing.Size(79, 21);
            this.parcelAgent.TabIndex = 115;
            this.helpTips.SetToolTip(this.parcelAgent, "Parcel Agent Name");
            // 
            // packedBy
            // 
            this.packedBy.Enabled = false;
            this.packedBy.Location = new System.Drawing.Point(287, 47);
            this.packedBy.Name = "packedBy";
            this.packedBy.Size = new System.Drawing.Size(76, 21);
            this.packedBy.TabIndex = 112;
            this.helpTips.SetToolTip(this.packedBy, "Name of staff who packed");
            // 
            // sentDate
            // 
            this.sentDate.CustomFormat = "dd/MM/yy";
            this.sentDate.Enabled = false;
            this.sentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.sentDate.Location = new System.Drawing.Point(197, 48);
            this.sentDate.Name = "sentDate";
            this.sentDate.Size = new System.Drawing.Size(76, 21);
            this.sentDate.TabIndex = 110;
            this.helpTips.SetToolTip(this.sentDate, "Send Date");
            // 
            // orderDate
            // 
            this.orderDate.CustomFormat = "dd/MM/yy";
            this.orderDate.Enabled = false;
            this.orderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.orderDate.Location = new System.Drawing.Point(7, 48);
            this.orderDate.Name = "orderDate";
            this.orderDate.Size = new System.Drawing.Size(79, 21);
            this.orderDate.TabIndex = 109;
            this.helpTips.SetToolTip(this.orderDate, "Order Date");
            // 
            // delete
            // 
            this.delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.delete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.delete.Location = new System.Drawing.Point(618, 380);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(69, 53);
            this.delete.TabIndex = 111;
            this.delete.Text = "&Delete";
            this.helpTips.SetToolTip(this.delete, "Delete all things in this page");
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // printDocument
            // 
            this.printDocument.DocumentName = "Estimate";
            this.printDocument.OriginAtMargins = true;
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // printDialog
            // 
            this.printDialog.Document = this.printDocument;
            this.printDialog.UseEXDialog = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(517, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 104;
            this.label1.Text = "Bill Date.:";
            // 
            // ordered
            // 
            this.ordered.AutoSize = true;
            this.ordered.Location = new System.Drawing.Point(6, 22);
            this.ordered.Name = "ordered";
            this.ordered.Size = new System.Drawing.Size(64, 17);
            this.ordered.TabIndex = 106;
            this.ordered.Text = "&Ordered";
            this.ordered.UseVisualStyleBackColor = true;
            this.ordered.CheckedChanged += new System.EventHandler(this.ordered_CheckedChanged);
            // 
            // sent
            // 
            this.sent.AutoSize = true;
            this.sent.Enabled = false;
            this.sent.Location = new System.Drawing.Point(197, 22);
            this.sent.Name = "sent";
            this.sent.Size = new System.Drawing.Size(48, 17);
            this.sent.TabIndex = 107;
            this.sent.Text = "Sen&t";
            this.sent.UseVisualStyleBackColor = true;
            this.sent.CheckedChanged += new System.EventHandler(this.packedAndSent_CheckedChanged);
            // 
            // orderStatGroup
            // 
            this.orderStatGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.orderStatGroup.BackColor = System.Drawing.SystemColors.Control;
            this.orderStatGroup.Controls.Add(this.orderClosedBy);
            this.orderStatGroup.Controls.Add(this.closeOrder);
            this.orderStatGroup.Controls.Add(this.receiptNo);
            this.orderStatGroup.Controls.Add(this.parcelAgent);
            this.orderStatGroup.Controls.Add(this.label4);
            this.orderStatGroup.Controls.Add(this.label3);
            this.orderStatGroup.Controls.Add(this.packedBy);
            this.orderStatGroup.Controls.Add(this.label2);
            this.orderStatGroup.Controls.Add(this.sentDate);
            this.orderStatGroup.Controls.Add(this.orderDate);
            this.orderStatGroup.Controls.Add(this.ordered);
            this.orderStatGroup.Controls.Add(this.sent);
            this.orderStatGroup.Location = new System.Drawing.Point(14, 441);
            this.orderStatGroup.Name = "orderStatGroup";
            this.orderStatGroup.Size = new System.Drawing.Size(572, 84);
            this.orderStatGroup.TabIndex = 110;
            this.orderStatGroup.TabStop = false;
            this.orderStatGroup.Text = "Order Status";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(461, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 114;
            this.label4.Text = "Receipt No:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 113;
            this.label3.Text = "Parcel Agent:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 111;
            this.label2.Text = "Packed By:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 377);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 15);
            this.label5.TabIndex = 112;
            this.label5.Text = "Remark:";
            // 
            // quitButton
            // 
            this.quitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.quitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.quitButton.Location = new System.Drawing.Point(618, 483);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(69, 43);
            this.quitButton.TabIndex = 113;
            this.quitButton.Text = "&Close";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 377);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 15);
            this.label6.TabIndex = 116;
            this.label6.Text = "Project:";
            // 
            // estimateDatePicker
            // 
            this.estimateDatePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.estimateDatePicker.BackColor = System.Drawing.Color.Yellow;
            this.estimateDatePicker.CustomFormat = "MMM/dd/yyyy";
            this.estimateDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.estimateDatePicker.Location = new System.Drawing.Point(582, 80);
            this.estimateDatePicker.Name = "estimateDatePicker";
            this.estimateDatePicker.Size = new System.Drawing.Size(104, 21);
            this.estimateDatePicker.TabIndex = 103;
            this.estimateDatePicker.ValueChanged += new System.EventHandler(this.estimateDatePicker_ValueChanged);
            // 
            // projectSelector
            // 
            this.projectSelector.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.projectSelector.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.projectSelector.Location = new System.Drawing.Point(14, 396);
            this.projectSelector.Name = "projectSelector";
            this.projectSelector.Size = new System.Drawing.Size(175, 21);
            this.projectSelector.TabIndex = 117;
            this.projectSelector.Enter += new System.EventHandler(this.projectSelector_Enter);
            this.projectSelector.Leave += new System.EventHandler(this.projectSelector_Leave);
            // 
            // EstimateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.quitButton;
            this.ClientSize = new System.Drawing.Size(698, 535);
            this.Controls.Add(this.projectSelector);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.orderStatGroup);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.estimateDatePicker);
            this.Controls.Add(this.updateItems);
            this.Controls.Add(this.justPrint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.save);
            this.Controls.Add(this.savePrint);
            this.Controls.Add(this.remark);
            this.Controls.Add(this.purchaseGrid);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.totalGroupBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.nameGroupBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(674, 571);
            this.Name = "EstimateForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Estimate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EstimateForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EstimateForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.purchaseGrid)).EndInit();
            this.itemEditContextMenu.ResumeLayout(false);
            this.nameGroupBox.ResumeLayout(false);
            this.nameGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.totalGroupBox.ResumeLayout(false);
            this.totalGroupBox.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.orderStatGroup.ResumeLayout(false);
            this.orderStatGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView purchaseGrid;
        private System.Windows.Forms.GroupBox nameGroupBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel totalBalance;
        private System.Windows.Forms.GroupBox totalGroupBox;
        private System.Windows.Forms.Label currentTotal;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox currentPayment;
        private System.Windows.Forms.TextBox remark;
        private System.Windows.Forms.Button savePrint;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button justPrint;
        private System.Windows.Forms.ToolTip helpTips;
        private System.Windows.Forms.TextBox customerName;
        private System.Windows.Forms.CheckBox updateItems;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.PrintDialog printDialog;
        private ColorableDatePicker estimateDatePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label customerDetail;
        private System.Windows.Forms.CheckBox ordered;
        private System.Windows.Forms.CheckBox sent;
        private System.Windows.Forms.GroupBox orderStatGroup;
        private System.Windows.Forms.DateTimePicker orderDate;
        private System.Windows.Forms.DateTimePicker sentDate;
        private System.Windows.Forms.TextBox packedBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox receiptNo;
        private System.Windows.Forms.TextBox parcelAgent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox closeOrder;
        private System.Windows.Forms.TextBox orderClosedBy;
        private System.Windows.Forms.CheckBox eMoney;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Label phoneNo;
        private System.Windows.Forms.ContextMenuStrip itemEditContextMenu;
        private System.Windows.Forms.ToolStripMenuItem stockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taxRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todaysSaleToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox projectSelector;
    }
}