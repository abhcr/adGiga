namespace ShopKeeper
{
    partial class Main
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.mainTab = new System.Windows.Forms.TabControl();
            this.salesTab = new System.Windows.Forms.TabPage();
            this.paymentMade = new System.Windows.Forms.Button();
            this.newPurchaseButton = new System.Windows.Forms.Button();
            this.salePayment = new System.Windows.Forms.Button();
            this.modify = new System.Windows.Forms.Button();
            this.newSale = new System.Windows.Forms.Button();
            this.saleSummaryGrid = new System.Windows.Forms.DataGridView();
            this.estimateno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saleTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstimateTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayPending = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.summaryRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expenseTab = new System.Windows.Forms.TabPage();
            this.expenseGrid = new System.Windows.Forms.DataGridView();
            this.slno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expenseTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectsTab = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.projectProfit = new System.Windows.Forms.Label();
            this.totalProjectIncome = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.projectSaleGrid = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalProjectCost = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.projectPurchaseGrid = new System.Windows.Forms.DataGridView();
            this.transTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.projectList = new System.Windows.Forms.ListView();
            this.projectDetailsGroup = new System.Windows.Forms.GroupBox();
            this.projectRemarkText = new System.Windows.Forms.TextBox();
            this.projectDelete = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.projectUpdate = new System.Windows.Forms.Button();
            this.projectNameText = new System.Windows.Forms.TextBox();
            this.projectStatusSelector = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.projectEndDateSelector = new ShopKeeper.ColorableDatePicker();
            this.projectStartDateSelector = new ShopKeeper.ColorableDatePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.reportsTab = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.reportDate = new System.Windows.Forms.DateTimePicker();
            this.eodCashFlow = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.stockReport = new System.Windows.Forms.Button();
            this.expenses = new System.Windows.Forms.Button();
            this.creditors = new System.Windows.Forms.Button();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.customerWiseSalesAnalysis = new System.Windows.Forms.Button();
            this.itemWiseSalesAnalysis = new System.Windows.Forms.Button();
            this.reportText = new System.Windows.Forms.TextBox();
            this.maintenanceTab = new System.Windows.Forms.TabPage();
            this.projectAssembly = new System.Windows.Forms.Button();
            this.dataChange = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.Button();
            this.purge = new System.Windows.Forms.Button();
            this.customerEditButton = new System.Windows.Forms.Button();
            this.itemEditButton = new System.Windows.Forms.Button();
            this.mailBackup = new System.Windows.Forms.Button();
            this.cashDisplay = new System.Windows.Forms.Label();
            this.cashbox = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.time = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.totalPaymentsReceived = new System.Windows.Forms.LinkLabel();
            this.totalExpenseForDay = new System.Windows.Forms.LinkLabel();
            this.helpTips = new System.Windows.Forms.ToolTip(this.components);
            this.totalSaleForDay = new System.Windows.Forms.LinkLabel();
            this.about = new System.Windows.Forms.Button();
            this.totalPurchaseOfDay = new System.Windows.Forms.LinkLabel();
            this.totalPaymentsMade = new System.Windows.Forms.LinkLabel();
            this.secondTimer = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cacheRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.refresh = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mainTab.SuspendLayout();
            this.salesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saleSummaryGrid)).BeginInit();
            this.expenseTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expenseGrid)).BeginInit();
            this.projectsTab.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectSaleGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectPurchaseGrid)).BeginInit();
            this.projectDetailsGroup.SuspendLayout();
            this.reportsTab.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.maintenanceTab.SuspendLayout();
            this.cashbox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTab
            // 
            this.mainTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTab.Controls.Add(this.salesTab);
            this.mainTab.Controls.Add(this.expenseTab);
            this.mainTab.Controls.Add(this.projectsTab);
            this.mainTab.Controls.Add(this.reportsTab);
            this.mainTab.Controls.Add(this.maintenanceTab);
            this.mainTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainTab.Location = new System.Drawing.Point(0, 90);
            this.mainTab.Multiline = true;
            this.mainTab.Name = "mainTab";
            this.mainTab.SelectedIndex = 0;
            this.mainTab.Size = new System.Drawing.Size(857, 526);
            this.mainTab.TabIndex = 3;
            // 
            // salesTab
            // 
            this.salesTab.BackColor = System.Drawing.Color.Green;
            this.salesTab.Controls.Add(this.paymentMade);
            this.salesTab.Controls.Add(this.newPurchaseButton);
            this.salesTab.Controls.Add(this.salePayment);
            this.salesTab.Controls.Add(this.modify);
            this.salesTab.Controls.Add(this.newSale);
            this.salesTab.Controls.Add(this.saleSummaryGrid);
            this.salesTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salesTab.Location = new System.Drawing.Point(4, 24);
            this.salesTab.Name = "salesTab";
            this.salesTab.Padding = new System.Windows.Forms.Padding(3);
            this.salesTab.Size = new System.Drawing.Size(849, 498);
            this.salesTab.TabIndex = 1;
            this.salesTab.Text = "Sales&Purchase";
            // 
            // paymentMade
            // 
            this.paymentMade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.paymentMade.Location = new System.Drawing.Point(702, 305);
            this.paymentMade.Name = "paymentMade";
            this.paymentMade.Size = new System.Drawing.Size(141, 66);
            this.paymentMade.TabIndex = 8;
            this.paymentMade.Text = "&Payment\r\nMade";
            this.paymentMade.UseVisualStyleBackColor = true;
            this.paymentMade.Click += new System.EventHandler(this.paymentMade_Click);
            // 
            // newPurchaseButton
            // 
            this.newPurchaseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newPurchaseButton.Location = new System.Drawing.Point(701, 229);
            this.newPurchaseButton.Name = "newPurchaseButton";
            this.newPurchaseButton.Size = new System.Drawing.Size(142, 70);
            this.newPurchaseButton.TabIndex = 6;
            this.newPurchaseButton.Text = "&New\r\nPurchase";
            this.newPurchaseButton.UseVisualStyleBackColor = true;
            this.newPurchaseButton.Click += new System.EventHandler(this.newPurchaseButton_Click);
            // 
            // salePayment
            // 
            this.salePayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.salePayment.Location = new System.Drawing.Point(702, 157);
            this.salePayment.Name = "salePayment";
            this.salePayment.Size = new System.Drawing.Size(141, 66);
            this.salePayment.TabIndex = 3;
            this.salePayment.Text = "&Payment\r\nReceived";
            this.salePayment.UseVisualStyleBackColor = true;
            this.salePayment.Click += new System.EventHandler(this.paymentReceived_Click);
            // 
            // modify
            // 
            this.modify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.modify.Enabled = false;
            this.modify.Location = new System.Drawing.Point(701, 82);
            this.modify.Name = "modify";
            this.modify.Size = new System.Drawing.Size(142, 69);
            this.modify.TabIndex = 2;
            this.modify.Text = "&Modify";
            this.modify.UseVisualStyleBackColor = true;
            this.modify.Click += new System.EventHandler(this.modify_Click);
            // 
            // newSale
            // 
            this.newSale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newSale.Location = new System.Drawing.Point(701, 6);
            this.newSale.Name = "newSale";
            this.newSale.Size = new System.Drawing.Size(142, 70);
            this.newSale.TabIndex = 1;
            this.newSale.Text = "&New\r\nSale";
            this.newSale.UseVisualStyleBackColor = true;
            this.newSale.Click += new System.EventHandler(this.newSale_Click);
            // 
            // saleSummaryGrid
            // 
            this.saleSummaryGrid.AllowUserToAddRows = false;
            this.saleSummaryGrid.AllowUserToDeleteRows = false;
            this.saleSummaryGrid.AllowUserToResizeRows = false;
            this.saleSummaryGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.saleSummaryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.saleSummaryGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.estimateno,
            this.saleTime,
            this.Customer,
            this.EstimateTotal,
            this.Payed,
            this.PayPending,
            this.summaryRemark});
            this.saleSummaryGrid.Location = new System.Drawing.Point(6, 6);
            this.saleSummaryGrid.MultiSelect = false;
            this.saleSummaryGrid.Name = "saleSummaryGrid";
            this.saleSummaryGrid.ReadOnly = true;
            this.saleSummaryGrid.RowHeadersWidth = 30;
            this.saleSummaryGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.saleSummaryGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.saleSummaryGrid.Size = new System.Drawing.Size(687, 484);
            this.saleSummaryGrid.TabIndex = 0;
            this.saleSummaryGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.saleSummaryGrid_CellDoubleClick);
            this.saleSummaryGrid.SelectionChanged += new System.EventHandler(this.saleSummaryGrid_SelectionChanged);
            // 
            // estimateno
            // 
            this.estimateno.HeaderText = "No.";
            this.estimateno.Name = "estimateno";
            this.estimateno.ReadOnly = true;
            this.estimateno.Width = 40;
            // 
            // saleTime
            // 
            this.saleTime.HeaderText = "Time";
            this.saleTime.Name = "saleTime";
            this.saleTime.ReadOnly = true;
            this.saleTime.ToolTipText = "Time of Sale";
            this.saleTime.Width = 80;
            // 
            // Customer
            // 
            this.Customer.HeaderText = "Customer";
            this.Customer.Name = "Customer";
            this.Customer.ReadOnly = true;
            this.Customer.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Customer.ToolTipText = "Customer\'s Name";
            this.Customer.Width = 160;
            // 
            // EstimateTotal
            // 
            this.EstimateTotal.HeaderText = "Total";
            this.EstimateTotal.Name = "EstimateTotal";
            this.EstimateTotal.ReadOnly = true;
            this.EstimateTotal.ToolTipText = "Total Bill Amount";
            this.EstimateTotal.Width = 70;
            // 
            // Payed
            // 
            this.Payed.HeaderText = "Payed";
            this.Payed.Name = "Payed";
            this.Payed.ReadOnly = true;
            this.Payed.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Payed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Payed.ToolTipText = "Amount Payed by customer";
            this.Payed.Width = 70;
            // 
            // PayPending
            // 
            this.PayPending.HeaderText = "Pending";
            this.PayPending.Name = "PayPending";
            this.PayPending.ReadOnly = true;
            this.PayPending.ToolTipText = "Cumulative Pending Amount of the Customer";
            this.PayPending.Width = 70;
            // 
            // summaryRemark
            // 
            this.summaryRemark.HeaderText = "Remark";
            this.summaryRemark.Name = "summaryRemark";
            this.summaryRemark.ReadOnly = true;
            this.summaryRemark.Width = 150;
            // 
            // expenseTab
            // 
            this.expenseTab.BackColor = System.Drawing.Color.Blue;
            this.expenseTab.Controls.Add(this.expenseGrid);
            this.expenseTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expenseTab.Location = new System.Drawing.Point(4, 24);
            this.expenseTab.Name = "expenseTab";
            this.expenseTab.Padding = new System.Windows.Forms.Padding(3);
            this.expenseTab.Size = new System.Drawing.Size(849, 498);
            this.expenseTab.TabIndex = 0;
            this.expenseTab.Text = "Expense";
            // 
            // expenseGrid
            // 
            this.expenseGrid.AllowUserToOrderColumns = true;
            this.expenseGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.expenseGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.expenseGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.slno,
            this.expenseTime,
            this.Item,
            this.Amount,
            this.Comment,
            this.id});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.expenseGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.expenseGrid.Location = new System.Drawing.Point(6, 6);
            this.expenseGrid.Name = "expenseGrid";
            this.expenseGrid.RowHeadersWidth = 25;
            this.expenseGrid.Size = new System.Drawing.Size(837, 484);
            this.expenseGrid.TabIndex = 0;
            this.expenseGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.expenseGrid_CellContentClick);
            this.expenseGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.expenseGrid_CellEndEdit);
            this.expenseGrid.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.expenseGrid_CellValidated);
            this.expenseGrid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.expenseGrid_CellValidating);
            this.expenseGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.expenseGrid_EditingControlShowing);
            this.expenseGrid.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.expenseGrid_RowValidated);
            this.expenseGrid.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.expenseGrid_RowValidating);
            this.expenseGrid.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.expenseGrid_UserAddedRow);
            this.expenseGrid.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.expenseGrid_UserDeletedRow);
            // 
            // slno
            // 
            this.slno.DataPropertyName = "ID";
            this.slno.HeaderText = "No.";
            this.slno.Name = "slno";
            this.slno.ReadOnly = true;
            this.slno.Width = 30;
            // 
            // expenseTime
            // 
            this.expenseTime.HeaderText = "Time";
            this.expenseTime.Name = "expenseTime";
            this.expenseTime.ReadOnly = true;
            // 
            // Item
            // 
            this.Item.DataPropertyName = "CustomerName";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.Item.DefaultCellStyle = dataGridViewCellStyle1;
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            this.Item.Width = 130;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.Width = 70;
            // 
            // Comment
            // 
            this.Comment.DataPropertyName = "Remarks";
            this.Comment.HeaderText = "Comment";
            this.Comment.Name = "Comment";
            this.Comment.Width = 350;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // projectsTab
            // 
            this.projectsTab.Controls.Add(this.groupBox6);
            this.projectsTab.Controls.Add(this.label9);
            this.projectsTab.Controls.Add(this.projectList);
            this.projectsTab.Controls.Add(this.projectDetailsGroup);
            this.projectsTab.Location = new System.Drawing.Point(4, 24);
            this.projectsTab.Name = "projectsTab";
            this.projectsTab.Padding = new System.Windows.Forms.Padding(3);
            this.projectsTab.Size = new System.Drawing.Size(849, 498);
            this.projectsTab.TabIndex = 5;
            this.projectsTab.Text = "Projects";
            this.projectsTab.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.projectProfit);
            this.groupBox6.Controls.Add(this.totalProjectIncome);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.projectSaleGrid);
            this.groupBox6.Controls.Add(this.totalProjectCost);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.projectPurchaseGrid);
            this.groupBox6.Location = new System.Drawing.Point(355, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(488, 484);
            this.groupBox6.TabIndex = 15;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Project Calculations";
            // 
            // projectProfit
            // 
            this.projectProfit.AutoSize = true;
            this.projectProfit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectProfit.Location = new System.Drawing.Point(345, 443);
            this.projectProfit.Name = "projectProfit";
            this.projectProfit.Size = new System.Drawing.Size(77, 24);
            this.projectProfit.TabIndex = 8;
            this.projectProfit.Text = "label15";
            this.helpTips.SetToolTip(this.projectProfit, "Profit");
            // 
            // totalProjectIncome
            // 
            this.totalProjectIncome.AutoSize = true;
            this.totalProjectIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalProjectIncome.Location = new System.Drawing.Point(122, 427);
            this.totalProjectIncome.Name = "totalProjectIncome";
            this.totalProjectIncome.Size = new System.Drawing.Size(32, 15);
            this.totalProjectIncome.TabIndex = 7;
            this.totalProjectIncome.Text = "-----";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(35, 427);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 15);
            this.label16.TabIndex = 6;
            this.label16.Text = "Total Income:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(7, 272);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 15);
            this.label14.TabIndex = 5;
            this.label14.Text = "Sale:";
            // 
            // projectSaleGrid
            // 
            this.projectSaleGrid.AllowUserToAddRows = false;
            this.projectSaleGrid.AllowUserToDeleteRows = false;
            this.projectSaleGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.projectSaleGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.projectSaleGrid.Location = new System.Drawing.Point(6, 290);
            this.projectSaleGrid.Name = "projectSaleGrid";
            this.projectSaleGrid.ReadOnly = true;
            this.projectSaleGrid.RowHeadersWidth = 20;
            this.projectSaleGrid.Size = new System.Drawing.Size(475, 134);
            this.projectSaleGrid.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Trans Time";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.ToolTipText = "Transaction time";
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Customer";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.ToolTipText = "Customer\'s Name";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Total";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // totalProjectCost
            // 
            this.totalProjectCost.AutoSize = true;
            this.totalProjectCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalProjectCost.Location = new System.Drawing.Point(122, 255);
            this.totalProjectCost.Name = "totalProjectCost";
            this.totalProjectCost.Size = new System.Drawing.Size(32, 15);
            this.totalProjectCost.TabIndex = 3;
            this.totalProjectCost.Text = "-----";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 255);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 15);
            this.label13.TabIndex = 2;
            this.label13.Text = "Total Project Cost:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(7, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 15);
            this.label12.TabIndex = 1;
            this.label12.Text = "Purchase:";
            // 
            // projectPurchaseGrid
            // 
            this.projectPurchaseGrid.AllowUserToAddRows = false;
            this.projectPurchaseGrid.AllowUserToDeleteRows = false;
            this.projectPurchaseGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.projectPurchaseGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.transTime,
            this.vendorColumn,
            this.total});
            this.projectPurchaseGrid.Location = new System.Drawing.Point(6, 43);
            this.projectPurchaseGrid.Name = "projectPurchaseGrid";
            this.projectPurchaseGrid.ReadOnly = true;
            this.projectPurchaseGrid.RowHeadersWidth = 20;
            this.projectPurchaseGrid.Size = new System.Drawing.Size(475, 209);
            this.projectPurchaseGrid.TabIndex = 0;
            // 
            // transTime
            // 
            this.transTime.HeaderText = "Trans Time";
            this.transTime.Name = "transTime";
            this.transTime.ReadOnly = true;
            this.transTime.ToolTipText = "Transaction time";
            this.transTime.Width = 150;
            // 
            // vendorColumn
            // 
            this.vendorColumn.HeaderText = "Vendor";
            this.vendorColumn.Name = "vendorColumn";
            this.vendorColumn.ReadOnly = true;
            this.vendorColumn.ToolTipText = "Vendor\'s Name";
            this.vendorColumn.Width = 200;
            // 
            // total
            // 
            this.total.HeaderText = "Total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 80;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "Select Project:";
            // 
            // projectList
            // 
            this.projectList.HideSelection = false;
            this.projectList.Location = new System.Drawing.Point(111, 27);
            this.projectList.MultiSelect = false;
            this.projectList.Name = "projectList";
            this.projectList.Size = new System.Drawing.Size(238, 239);
            this.projectList.TabIndex = 0;
            this.projectList.UseCompatibleStateImageBehavior = false;
            this.projectList.View = System.Windows.Forms.View.List;
            this.projectList.SelectedIndexChanged += new System.EventHandler(this.projectList_SelectedIndexChanged);
            // 
            // projectDetailsGroup
            // 
            this.projectDetailsGroup.Controls.Add(this.projectRemarkText);
            this.projectDetailsGroup.Controls.Add(this.projectDelete);
            this.projectDetailsGroup.Controls.Add(this.label3);
            this.projectDetailsGroup.Controls.Add(this.projectUpdate);
            this.projectDetailsGroup.Controls.Add(this.projectNameText);
            this.projectDetailsGroup.Controls.Add(this.projectStatusSelector);
            this.projectDetailsGroup.Controls.Add(this.label7);
            this.projectDetailsGroup.Controls.Add(this.label11);
            this.projectDetailsGroup.Controls.Add(this.label8);
            this.projectDetailsGroup.Controls.Add(this.projectEndDateSelector);
            this.projectDetailsGroup.Controls.Add(this.projectStartDateSelector);
            this.projectDetailsGroup.Controls.Add(this.label10);
            this.projectDetailsGroup.Enabled = false;
            this.projectDetailsGroup.Location = new System.Drawing.Point(8, 272);
            this.projectDetailsGroup.Name = "projectDetailsGroup";
            this.projectDetailsGroup.Size = new System.Drawing.Size(341, 218);
            this.projectDetailsGroup.TabIndex = 16;
            this.projectDetailsGroup.TabStop = false;
            this.projectDetailsGroup.Text = "Project Details";
            // 
            // projectRemarkText
            // 
            this.projectRemarkText.AcceptsReturn = true;
            this.projectRemarkText.Location = new System.Drawing.Point(97, 47);
            this.projectRemarkText.MaxLength = 255;
            this.projectRemarkText.Multiline = true;
            this.projectRemarkText.Name = "projectRemarkText";
            this.projectRemarkText.Size = new System.Drawing.Size(238, 73);
            this.projectRemarkText.TabIndex = 5;
            // 
            // projectDelete
            // 
            this.projectDelete.Location = new System.Drawing.Point(207, 180);
            this.projectDelete.Name = "projectDelete";
            this.projectDelete.Size = new System.Drawing.Size(128, 25);
            this.projectDelete.TabIndex = 14;
            this.projectDelete.Text = "&Delete";
            this.projectDelete.UseVisualStyleBackColor = true;
            this.projectDelete.Click += new System.EventHandler(this.projectDelete_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Project Name:";
            // 
            // projectUpdate
            // 
            this.projectUpdate.Location = new System.Drawing.Point(207, 127);
            this.projectUpdate.Name = "projectUpdate";
            this.projectUpdate.Size = new System.Drawing.Size(128, 47);
            this.projectUpdate.TabIndex = 13;
            this.projectUpdate.Text = "&Update";
            this.projectUpdate.UseVisualStyleBackColor = true;
            this.projectUpdate.Click += new System.EventHandler(this.projectUpdate_Click);
            // 
            // projectNameText
            // 
            this.projectNameText.Location = new System.Drawing.Point(97, 20);
            this.projectNameText.MaxLength = 255;
            this.projectNameText.Name = "projectNameText";
            this.projectNameText.Size = new System.Drawing.Size(238, 21);
            this.projectNameText.TabIndex = 3;
            // 
            // projectStatusSelector
            // 
            this.projectStatusSelector.FormattingEnabled = true;
            this.projectStatusSelector.Items.AddRange(new object[] {
            "Started",
            "InProgress",
            "Completed",
            "OnHold"});
            this.projectStatusSelector.Location = new System.Drawing.Point(97, 182);
            this.projectStatusSelector.Name = "projectStatusSelector";
            this.projectStatusSelector.Size = new System.Drawing.Size(104, 23);
            this.projectStatusSelector.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "Remark:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(47, 185);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 15);
            this.label11.TabIndex = 11;
            this.label11.Text = "Status:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 15);
            this.label8.TabIndex = 6;
            this.label8.Text = "Start Date:";
            // 
            // projectEndDateSelector
            // 
            this.projectEndDateSelector.BackColor = System.Drawing.Color.White;
            this.projectEndDateSelector.Location = new System.Drawing.Point(97, 153);
            this.projectEndDateSelector.Name = "projectEndDateSelector";
            this.projectEndDateSelector.Size = new System.Drawing.Size(104, 21);
            this.projectEndDateSelector.TabIndex = 10;
            // 
            // projectStartDateSelector
            // 
            this.projectStartDateSelector.BackColor = System.Drawing.Color.White;
            this.projectStartDateSelector.Location = new System.Drawing.Point(97, 126);
            this.projectStartDateSelector.Name = "projectStartDateSelector";
            this.projectStartDateSelector.Size = new System.Drawing.Size(104, 21);
            this.projectStartDateSelector.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 157);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "End Date:";
            // 
            // reportsTab
            // 
            this.reportsTab.Controls.Add(this.groupBox5);
            this.reportsTab.Controls.Add(this.groupBox4);
            this.reportsTab.Controls.Add(this.reportText);
            this.reportsTab.Location = new System.Drawing.Point(4, 24);
            this.reportsTab.Name = "reportsTab";
            this.reportsTab.Padding = new System.Windows.Forms.Padding(3);
            this.reportsTab.Size = new System.Drawing.Size(849, 498);
            this.reportsTab.TabIndex = 2;
            this.reportsTab.Text = "Reports";
            this.reportsTab.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox5.Controls.Add(this.reportDate);
            this.groupBox5.Controls.Add(this.eodCashFlow);
            this.groupBox5.Location = new System.Drawing.Point(6, 387);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 103);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Daily";
            // 
            // reportDate
            // 
            this.reportDate.CustomFormat = "dd/MM/yy dddd";
            this.reportDate.Enabled = false;
            this.reportDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.reportDate.Location = new System.Drawing.Point(7, 20);
            this.reportDate.Name = "reportDate";
            this.reportDate.Size = new System.Drawing.Size(178, 21);
            this.reportDate.TabIndex = 2;
            this.helpTips.SetToolTip(this.reportDate, "not yet implemented");
            // 
            // eodCashFlow
            // 
            this.eodCashFlow.Location = new System.Drawing.Point(7, 47);
            this.eodCashFlow.Name = "eodCashFlow";
            this.eodCashFlow.Size = new System.Drawing.Size(154, 37);
            this.eodCashFlow.TabIndex = 1;
            this.eodCashFlow.Text = "End of Day Cash Flow";
            this.eodCashFlow.UseVisualStyleBackColor = true;
            this.eodCashFlow.Click += new System.EventHandler(this.eodCashFlow_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.stockReport);
            this.groupBox4.Controls.Add(this.expenses);
            this.groupBox4.Controls.Add(this.creditors);
            this.groupBox4.Controls.Add(this.endDate);
            this.groupBox4.Controls.Add(this.startDate);
            this.groupBox4.Controls.Add(this.customerWiseSalesAnalysis);
            this.groupBox4.Controls.Add(this.itemWiseSalesAnalysis);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 286);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Time Period Based";
            // 
            // stockReport
            // 
            this.stockReport.Location = new System.Drawing.Point(6, 221);
            this.stockReport.Name = "stockReport";
            this.stockReport.Size = new System.Drawing.Size(179, 37);
            this.stockReport.TabIndex = 5;
            this.stockReport.Text = "Stoc&k Report";
            this.stockReport.UseVisualStyleBackColor = true;
            this.stockReport.Click += new System.EventHandler(this.stockReport_Click);
            // 
            // expenses
            // 
            this.expenses.Location = new System.Drawing.Point(6, 178);
            this.expenses.Name = "expenses";
            this.expenses.Size = new System.Drawing.Size(179, 37);
            this.expenses.TabIndex = 4;
            this.expenses.Text = "&Expenses";
            this.expenses.UseVisualStyleBackColor = true;
            this.expenses.Click += new System.EventHandler(this.expenses_Click);
            // 
            // creditors
            // 
            this.creditors.Location = new System.Drawing.Point(6, 135);
            this.creditors.Name = "creditors";
            this.creditors.Size = new System.Drawing.Size(179, 37);
            this.creditors.TabIndex = 3;
            this.creditors.Text = "&Debtors";
            this.creditors.UseVisualStyleBackColor = true;
            this.creditors.Click += new System.EventHandler(this.creditors_Click);
            // 
            // endDate
            // 
            this.endDate.CustomFormat = "dd/MM/yy";
            this.endDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endDate.Location = new System.Drawing.Point(100, 21);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(87, 21);
            this.endDate.TabIndex = 1;
            // 
            // startDate
            // 
            this.startDate.CustomFormat = "dd/MM/yy";
            this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDate.Location = new System.Drawing.Point(7, 21);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(87, 21);
            this.startDate.TabIndex = 0;
            this.startDate.ValueChanged += new System.EventHandler(this.startDate_ValueChanged);
            // 
            // customerWiseSalesAnalysis
            // 
            this.customerWiseSalesAnalysis.Location = new System.Drawing.Point(6, 91);
            this.customerWiseSalesAnalysis.Name = "customerWiseSalesAnalysis";
            this.customerWiseSalesAnalysis.Size = new System.Drawing.Size(179, 37);
            this.customerWiseSalesAnalysis.TabIndex = 2;
            this.customerWiseSalesAnalysis.Text = "Purchase By Customers";
            this.customerWiseSalesAnalysis.UseVisualStyleBackColor = true;
            this.customerWiseSalesAnalysis.Click += new System.EventHandler(this.customerWiseSalesAnalysis_Click);
            // 
            // itemWiseSalesAnalysis
            // 
            this.itemWiseSalesAnalysis.Location = new System.Drawing.Point(6, 48);
            this.itemWiseSalesAnalysis.Name = "itemWiseSalesAnalysis";
            this.itemWiseSalesAnalysis.Size = new System.Drawing.Size(179, 37);
            this.itemWiseSalesAnalysis.TabIndex = 0;
            this.itemWiseSalesAnalysis.Text = "&Items Sold";
            this.itemWiseSalesAnalysis.UseVisualStyleBackColor = true;
            this.itemWiseSalesAnalysis.Click += new System.EventHandler(this.itemWiseSalesAnalysis_Click);
            // 
            // reportText
            // 
            this.reportText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.reportText.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportText.Location = new System.Drawing.Point(214, 6);
            this.reportText.Multiline = true;
            this.reportText.Name = "reportText";
            this.reportText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.reportText.Size = new System.Drawing.Size(629, 484);
            this.reportText.TabIndex = 3;
            // 
            // maintenanceTab
            // 
            this.maintenanceTab.Controls.Add(this.projectAssembly);
            this.maintenanceTab.Controls.Add(this.dataChange);
            this.maintenanceTab.Controls.Add(this.password);
            this.maintenanceTab.Controls.Add(this.purge);
            this.maintenanceTab.Controls.Add(this.customerEditButton);
            this.maintenanceTab.Controls.Add(this.itemEditButton);
            this.maintenanceTab.Controls.Add(this.mailBackup);
            this.maintenanceTab.Location = new System.Drawing.Point(4, 24);
            this.maintenanceTab.Name = "maintenanceTab";
            this.maintenanceTab.Padding = new System.Windows.Forms.Padding(3);
            this.maintenanceTab.Size = new System.Drawing.Size(849, 498);
            this.maintenanceTab.TabIndex = 4;
            this.maintenanceTab.Text = "Maintenance Tab";
            this.maintenanceTab.UseVisualStyleBackColor = true;
            // 
            // projectAssembly
            // 
            this.projectAssembly.Location = new System.Drawing.Point(703, 20);
            this.projectAssembly.Name = "projectAssembly";
            this.projectAssembly.Size = new System.Drawing.Size(131, 44);
            this.projectAssembly.TabIndex = 6;
            this.projectAssembly.Text = "Manage Pro&ject Assemblies";
            this.projectAssembly.UseVisualStyleBackColor = true;
            this.projectAssembly.Click += new System.EventHandler(this.projectAssembly_Click);
            // 
            // dataChange
            // 
            this.dataChange.Location = new System.Drawing.Point(566, 20);
            this.dataChange.Name = "dataChange";
            this.dataChange.Size = new System.Drawing.Size(131, 44);
            this.dataChange.TabIndex = 5;
            this.dataChange.Text = "Change &Data File";
            this.helpTips.SetToolTip(this.dataChange, "Delete All sale/purchase data before a given date");
            this.dataChange.UseVisualStyleBackColor = true;
            this.dataChange.Click += new System.EventHandler(this.dataChange_Click);
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(429, 20);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(131, 44);
            this.password.TabIndex = 4;
            this.password.Text = "Change Pass&word";
            this.helpTips.SetToolTip(this.password, "Delete All sale/purchase data before a given date");
            this.password.UseVisualStyleBackColor = true;
            this.password.Click += new System.EventHandler(this.password_Click);
            // 
            // purge
            // 
            this.purge.Location = new System.Drawing.Point(292, 20);
            this.purge.Name = "purge";
            this.purge.Size = new System.Drawing.Size(131, 44);
            this.purge.TabIndex = 3;
            this.purge.Text = "&Purge To Date";
            this.helpTips.SetToolTip(this.purge, "Delete All sale/purchase/expense data before a given date");
            this.purge.UseVisualStyleBackColor = true;
            this.purge.Click += new System.EventHandler(this.purge_Click);
            // 
            // customerEditButton
            // 
            this.customerEditButton.Location = new System.Drawing.Point(155, 20);
            this.customerEditButton.Name = "customerEditButton";
            this.customerEditButton.Size = new System.Drawing.Size(131, 44);
            this.customerEditButton.TabIndex = 2;
            this.customerEditButton.Text = "Manage &Customers";
            this.helpTips.SetToolTip(this.customerEditButton, "Edit or delete existing customers");
            this.customerEditButton.UseVisualStyleBackColor = true;
            this.customerEditButton.Click += new System.EventHandler(this.customerEditButton_Click);
            // 
            // itemEditButton
            // 
            this.itemEditButton.Location = new System.Drawing.Point(18, 20);
            this.itemEditButton.Name = "itemEditButton";
            this.itemEditButton.Size = new System.Drawing.Size(131, 44);
            this.itemEditButton.TabIndex = 1;
            this.itemEditButton.Text = "Manage &Items";
            this.helpTips.SetToolTip(this.itemEditButton, "Edit or delete existing items");
            this.itemEditButton.UseVisualStyleBackColor = true;
            this.itemEditButton.Click += new System.EventHandler(this.itemEditButton_Click);
            // 
            // mailBackup
            // 
            this.mailBackup.Enabled = false;
            this.mailBackup.Location = new System.Drawing.Point(18, 70);
            this.mailBackup.Name = "mailBackup";
            this.mailBackup.Size = new System.Drawing.Size(131, 44);
            this.mailBackup.TabIndex = 0;
            this.mailBackup.Text = "Backup To &Mail";
            this.mailBackup.UseVisualStyleBackColor = true;
            this.mailBackup.Click += new System.EventHandler(this.mailBackup_Click);
            // 
            // cashDisplay
            // 
            this.cashDisplay.AutoSize = true;
            this.cashDisplay.Font = new System.Drawing.Font("Engravers MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashDisplay.ForeColor = System.Drawing.Color.DarkRed;
            this.cashDisplay.Location = new System.Drawing.Point(6, 23);
            this.cashDisplay.Name = "cashDisplay";
            this.cashDisplay.Size = new System.Drawing.Size(89, 19);
            this.cashDisplay.TabIndex = 2;
            this.cashDisplay.Text = "wait...";
            this.cashDisplay.Click += new System.EventHandler(this.cashDisplay_Click);
            // 
            // cashbox
            // 
            this.cashbox.Controls.Add(this.cashDisplay);
            this.cashbox.Location = new System.Drawing.Point(325, 12);
            this.cashbox.Name = "cashbox";
            this.cashbox.Size = new System.Drawing.Size(165, 65);
            this.cashbox.TabIndex = 6;
            this.cashbox.TabStop = false;
            this.cashbox.Text = "Cash";
            this.cashbox.MouseCaptureChanged += new System.EventHandler(this.cashbox_MouseCaptureChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.date);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(154, 65);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Entry Date";
            // 
            // date
            // 
            this.date.CustomFormat = "MMM/dd/yyyy";
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date.Location = new System.Drawing.Point(26, 26);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(106, 20);
            this.date.TabIndex = 0;
            this.date.ValueChanged += new System.EventHandler(this.date_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.time);
            this.groupBox3.Location = new System.Drawing.Point(172, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(147, 65);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Time";
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time.Location = new System.Drawing.Point(26, 32);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(0, 13);
            this.time.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Payments received:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Expenses:";
            // 
            // totalPaymentsReceived
            // 
            this.totalPaymentsReceived.AutoSize = true;
            this.totalPaymentsReceived.Location = new System.Drawing.Point(219, 11);
            this.totalPaymentsReceived.Name = "totalPaymentsReceived";
            this.totalPaymentsReceived.Size = new System.Drawing.Size(13, 13);
            this.totalPaymentsReceived.TabIndex = 9;
            this.totalPaymentsReceived.TabStop = true;
            this.totalPaymentsReceived.Text = "0";
            this.helpTips.SetToolTip(this.totalPaymentsReceived, "Total payments received");
            this.totalPaymentsReceived.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.totalSaleForDay_LinkClicked);
            // 
            // totalExpenseForDay
            // 
            this.totalExpenseForDay.AutoSize = true;
            this.totalExpenseForDay.Location = new System.Drawing.Point(219, 50);
            this.totalExpenseForDay.Name = "totalExpenseForDay";
            this.totalExpenseForDay.Size = new System.Drawing.Size(13, 13);
            this.totalExpenseForDay.TabIndex = 9;
            this.totalExpenseForDay.TabStop = true;
            this.totalExpenseForDay.Text = "0";
            this.helpTips.SetToolTip(this.totalExpenseForDay, "Total expense of the day");
            this.totalExpenseForDay.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.totalExpenseForDay_LinkClicked);
            // 
            // totalSaleForDay
            // 
            this.totalSaleForDay.AutoSize = true;
            this.totalSaleForDay.Location = new System.Drawing.Point(67, 16);
            this.totalSaleForDay.Name = "totalSaleForDay";
            this.totalSaleForDay.Size = new System.Drawing.Size(13, 13);
            this.totalSaleForDay.TabIndex = 0;
            this.totalSaleForDay.TabStop = true;
            this.totalSaleForDay.Text = "0";
            this.helpTips.SetToolTip(this.totalSaleForDay, "Total sale of the day");
            this.totalSaleForDay.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.totalSaleForDay_LinkClicked_1);
            // 
            // about
            // 
            this.about.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.about.Location = new System.Drawing.Point(832, 2);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(24, 23);
            this.about.TabIndex = 12;
            this.about.Text = "?";
            this.helpTips.SetToolTip(this.about, "About adGiga");
            this.about.UseVisualStyleBackColor = true;
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // totalPurchaseOfDay
            // 
            this.totalPurchaseOfDay.AutoSize = true;
            this.totalPurchaseOfDay.Location = new System.Drawing.Point(67, 35);
            this.totalPurchaseOfDay.Name = "totalPurchaseOfDay";
            this.totalPurchaseOfDay.Size = new System.Drawing.Size(13, 13);
            this.totalPurchaseOfDay.TabIndex = 14;
            this.totalPurchaseOfDay.TabStop = true;
            this.totalPurchaseOfDay.Text = "0";
            this.helpTips.SetToolTip(this.totalPurchaseOfDay, "Total purchase of the day");
            // 
            // totalPaymentsMade
            // 
            this.totalPaymentsMade.AutoSize = true;
            this.totalPaymentsMade.Location = new System.Drawing.Point(219, 30);
            this.totalPaymentsMade.Name = "totalPaymentsMade";
            this.totalPaymentsMade.Size = new System.Drawing.Size(13, 13);
            this.totalPaymentsMade.TabIndex = 16;
            this.totalPaymentsMade.TabStop = true;
            this.totalPaymentsMade.Text = "0";
            this.helpTips.SetToolTip(this.totalPaymentsMade, "Total payments made against purchases");
            // 
            // secondTimer
            // 
            this.secondTimer.Interval = 1000;
            this.secondTimer.Tick += new System.EventHandler(this.secondTimer_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Sale:";
            // 
            // cacheRefreshTimer
            // 
            this.cacheRefreshTimer.Interval = 10000;
            this.cacheRefreshTimer.Tick += new System.EventHandler(this.cacheRefreshTimer_Tick);
            // 
            // refresh
            // 
            this.refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refresh.Location = new System.Drawing.Point(796, 74);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(57, 28);
            this.refresh.TabIndex = 2;
            this.refresh.Text = "&Refresh";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Purchase:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(115, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Payments Made:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.totalPurchaseOfDay);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.totalPaymentsMade);
            this.groupBox1.Controls.Add(this.totalPaymentsReceived);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.totalExpenseForDay);
            this.groupBox1.Controls.Add(this.totalSaleForDay);
            this.groupBox1.Location = new System.Drawing.Point(496, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 77);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Totals";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 616);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.about);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cashbox);
            this.Controls.Add(this.mainTab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "adGiga";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.mainTab.ResumeLayout(false);
            this.salesTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.saleSummaryGrid)).EndInit();
            this.expenseTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.expenseGrid)).EndInit();
            this.projectsTab.ResumeLayout(false);
            this.projectsTab.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectSaleGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectPurchaseGrid)).EndInit();
            this.projectDetailsGroup.ResumeLayout(false);
            this.projectDetailsGroup.PerformLayout();
            this.reportsTab.ResumeLayout(false);
            this.reportsTab.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.maintenanceTab.ResumeLayout(false);
            this.cashbox.ResumeLayout(false);
            this.cashbox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTab;
        private System.Windows.Forms.TabPage expenseTab;
        private System.Windows.Forms.TabPage salesTab;
        private System.Windows.Forms.Label cashDisplay;
        private System.Windows.Forms.GroupBox cashbox;
        private System.Windows.Forms.DataGridView expenseGrid;
        private System.Windows.Forms.DataGridView saleSummaryGrid;
        private System.Windows.Forms.Button newSale;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button modify;
        private System.Windows.Forms.Button salePayment;
        private System.Windows.Forms.TabPage reportsTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel totalPaymentsReceived;
        private System.Windows.Forms.LinkLabel totalExpenseForDay;
        private System.Windows.Forms.ToolTip helpTips;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Timer secondTimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn slno;
        private System.Windows.Forms.DataGridViewTextBoxColumn expenseTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.Button itemWiseSalesAnalysis;
        private System.Windows.Forms.Button eodCashFlow;
        private System.Windows.Forms.Button customerWiseSalesAnalysis;
        private System.Windows.Forms.TextBox reportText;
        private System.Windows.Forms.TabPage maintenanceTab;
        private System.Windows.Forms.Button mailBackup;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button expenses;
        private System.Windows.Forms.Button creditors;
        private System.Windows.Forms.DateTimePicker reportDate;
        private System.Windows.Forms.LinkLabel totalSaleForDay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.Timer cacheRefreshTimer;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Button about;
        private System.Windows.Forms.DataGridViewTextBoxColumn estimateno;
        private System.Windows.Forms.DataGridViewTextBoxColumn saleTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstimateTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payed;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayPending;
        private System.Windows.Forms.DataGridViewTextBoxColumn summaryRemark;
        private System.Windows.Forms.Button stockReport;
        private System.Windows.Forms.Button paymentMade;
        private System.Windows.Forms.Button newPurchaseButton;
        private System.Windows.Forms.Button itemEditButton;
        private System.Windows.Forms.Button customerEditButton;
        private System.Windows.Forms.Button purge;
        private System.Windows.Forms.Button password;
        private System.Windows.Forms.LinkLabel totalPurchaseOfDay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel totalPaymentsMade;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button dataChange;
        private System.Windows.Forms.Button projectAssembly;
        private System.Windows.Forms.TabPage projectsTab;
        private System.Windows.Forms.ListView projectList;
        private System.Windows.Forms.TextBox projectNameText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox projectStatusSelector;
        private System.Windows.Forms.Label label11;
        private ColorableDatePicker projectEndDateSelector;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private ColorableDatePicker projectStartDateSelector;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox projectRemarkText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button projectDelete;
        private System.Windows.Forms.Button projectUpdate;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView projectPurchaseGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn transTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.Label totalProjectCost;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView projectSaleGrid;
        private System.Windows.Forms.Label projectProfit;
        private System.Windows.Forms.Label totalProjectIncome;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.GroupBox projectDetailsGroup;

    }
}

