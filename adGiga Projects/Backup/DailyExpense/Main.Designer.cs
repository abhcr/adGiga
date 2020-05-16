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
            this.button1 = new System.Windows.Forms.Button();
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
            this.reportsTab = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.reportDate = new System.Windows.Forms.DateTimePicker();
            this.eodCashFlow = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.expenses = new System.Windows.Forms.Button();
            this.creditors = new System.Windows.Forms.Button();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.customerWiseSalesAnalysis = new System.Windows.Forms.Button();
            this.itemWiseSalesAnalysis = new System.Windows.Forms.Button();
            this.reportText = new System.Windows.Forms.TextBox();
            this.graphs = new System.Windows.Forms.TabPage();
            this.maintenanceTab = new System.Windows.Forms.TabPage();
            this.mailBackup = new System.Windows.Forms.Button();
            this.cashDisplay = new System.Windows.Forms.Label();
            this.cashbox = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.time = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.totalPaymentsForDay = new System.Windows.Forms.LinkLabel();
            this.totalExpenseForDay = new System.Windows.Forms.LinkLabel();
            this.helpTips = new System.Windows.Forms.ToolTip(this.components);
            this.creditDetail = new System.Windows.Forms.LinkLabel();
            this.totalSaleForDay = new System.Windows.Forms.LinkLabel();
            this.secondTimer = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cacheRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.refresh = new System.Windows.Forms.Button();
            this.about = new System.Windows.Forms.Button();
            this.stockReport = new System.Windows.Forms.Button();
            this.mainTab.SuspendLayout();
            this.salesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saleSummaryGrid)).BeginInit();
            this.expenseTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expenseGrid)).BeginInit();
            this.reportsTab.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.maintenanceTab.SuspendLayout();
            this.cashbox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTab
            // 
            this.mainTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTab.Controls.Add(this.salesTab);
            this.mainTab.Controls.Add(this.expenseTab);
            this.mainTab.Controls.Add(this.reportsTab);
            this.mainTab.Controls.Add(this.graphs);
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
            this.salesTab.Controls.Add(this.button1);
            this.salesTab.Controls.Add(this.modify);
            this.salesTab.Controls.Add(this.newSale);
            this.salesTab.Controls.Add(this.saleSummaryGrid);
            this.salesTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salesTab.Location = new System.Drawing.Point(4, 24);
            this.salesTab.Name = "salesTab";
            this.salesTab.Padding = new System.Windows.Forms.Padding(3);
            this.salesTab.Size = new System.Drawing.Size(849, 498);
            this.salesTab.TabIndex = 1;
            this.salesTab.Text = "Sales";
            this.salesTab.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(701, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 66);
            this.button1.TabIndex = 3;
            this.button1.Text = "&Payment";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.newSale.Text = "&New";
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
            this.saleSummaryGrid.Location = new System.Drawing.Point(8, 6);
            this.saleSummaryGrid.MultiSelect = false;
            this.saleSummaryGrid.Name = "saleSummaryGrid";
            this.saleSummaryGrid.ReadOnly = true;
            this.saleSummaryGrid.RowHeadersWidth = 30;
            this.saleSummaryGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.saleSummaryGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.saleSummaryGrid.Size = new System.Drawing.Size(687, 484);
            this.saleSummaryGrid.TabIndex = 0;
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
            this.expenseTab.Controls.Add(this.expenseGrid);
            this.expenseTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expenseTab.Location = new System.Drawing.Point(4, 24);
            this.expenseTab.Name = "expenseTab";
            this.expenseTab.Padding = new System.Windows.Forms.Padding(3);
            this.expenseTab.Size = new System.Drawing.Size(849, 498);
            this.expenseTab.TabIndex = 0;
            this.expenseTab.Text = "Expense";
            this.expenseTab.UseVisualStyleBackColor = true;
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
            this.expenseGrid.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.expenseGrid_UserAddedRow);
            this.expenseGrid.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.expenseGrid_RowValidating);
            this.expenseGrid.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.expenseGrid_CellValidated);
            this.expenseGrid.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.expenseGrid_UserDeletedRow);
            this.expenseGrid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.expenseGrid_CellValidating);
            this.expenseGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.expenseGrid_CellEndEdit);
            this.expenseGrid.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.expenseGrid_RowValidated);
            this.expenseGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.expenseGrid_EditingControlShowing);
            this.expenseGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.expenseGrid_CellContentClick);
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
            // graphs
            // 
            this.graphs.Location = new System.Drawing.Point(4, 24);
            this.graphs.Name = "graphs";
            this.graphs.Padding = new System.Windows.Forms.Padding(3);
            this.graphs.Size = new System.Drawing.Size(849, 498);
            this.graphs.TabIndex = 3;
            this.graphs.Text = "Graphs";
            this.graphs.UseVisualStyleBackColor = true;
            // 
            // maintenanceTab
            // 
            this.maintenanceTab.Controls.Add(this.mailBackup);
            this.maintenanceTab.Location = new System.Drawing.Point(4, 24);
            this.maintenanceTab.Name = "maintenanceTab";
            this.maintenanceTab.Padding = new System.Windows.Forms.Padding(3);
            this.maintenanceTab.Size = new System.Drawing.Size(849, 498);
            this.maintenanceTab.TabIndex = 4;
            this.maintenanceTab.Text = "Maintenance Tab";
            this.maintenanceTab.UseVisualStyleBackColor = true;
            // 
            // mailBackup
            // 
            this.mailBackup.Location = new System.Drawing.Point(29, 40);
            this.mailBackup.Name = "mailBackup";
            this.mailBackup.Size = new System.Drawing.Size(93, 44);
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
            this.label1.Location = new System.Drawing.Point(501, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "DP:";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(501, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "DE:";
            this.label2.Visible = false;
            // 
            // totalPaymentsForDay
            // 
            this.totalPaymentsForDay.AutoSize = true;
            this.totalPaymentsForDay.Location = new System.Drawing.Point(548, 37);
            this.totalPaymentsForDay.Name = "totalPaymentsForDay";
            this.totalPaymentsForDay.Size = new System.Drawing.Size(37, 13);
            this.totalPaymentsForDay.TabIndex = 9;
            this.totalPaymentsForDay.TabStop = true;
            this.totalPaymentsForDay.Text = "12345";
            this.helpTips.SetToolTip(this.totalPaymentsForDay, "Total payments received for the day");
            this.totalPaymentsForDay.Visible = false;
            this.totalPaymentsForDay.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.totalSaleForDay_LinkClicked);
            // 
            // totalExpenseForDay
            // 
            this.totalExpenseForDay.AutoSize = true;
            this.totalExpenseForDay.Location = new System.Drawing.Point(548, 57);
            this.totalExpenseForDay.Name = "totalExpenseForDay";
            this.totalExpenseForDay.Size = new System.Drawing.Size(31, 13);
            this.totalExpenseForDay.TabIndex = 9;
            this.totalExpenseForDay.TabStop = true;
            this.totalExpenseForDay.Text = "1234";
            this.helpTips.SetToolTip(this.totalExpenseForDay, "Total expense of the day");
            this.totalExpenseForDay.Visible = false;
            this.totalExpenseForDay.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.totalExpenseForDay_LinkClicked);
            // 
            // creditDetail
            // 
            this.creditDetail.AutoSize = true;
            this.creditDetail.Location = new System.Drawing.Point(550, 74);
            this.creditDetail.Name = "creditDetail";
            this.creditDetail.Size = new System.Drawing.Size(48, 13);
            this.creditDetail.TabIndex = 11;
            this.creditDetail.TabStop = true;
            this.creditDetail.Text = "not yet...";
            this.helpTips.SetToolTip(this.creditDetail, "Sales minus payments received");
            this.creditDetail.Visible = false;
            this.creditDetail.MouseLeave += new System.EventHandler(this.creditDetail_MouseLeave);
            this.creditDetail.MouseHover += new System.EventHandler(this.creditDetail_MouseHover);
            this.creditDetail.MouseEnter += new System.EventHandler(this.creditDetail_MouseEnter);
            // 
            // totalSaleForDay
            // 
            this.totalSaleForDay.AutoSize = true;
            this.totalSaleForDay.Location = new System.Drawing.Point(548, 19);
            this.totalSaleForDay.Name = "totalSaleForDay";
            this.totalSaleForDay.Size = new System.Drawing.Size(37, 13);
            this.totalSaleForDay.TabIndex = 0;
            this.totalSaleForDay.TabStop = true;
            this.totalSaleForDay.Text = "12345";
            this.helpTips.SetToolTip(this.totalSaleForDay, "Total sale of the day");
            this.totalSaleForDay.Visible = false;
            this.totalSaleForDay.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.totalSaleForDay_LinkClicked_1);
            // 
            // secondTimer
            // 
            this.secondTimer.Interval = 1000;
            this.secondTimer.Tick += new System.EventHandler(this.secondTimer_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(501, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "DS-DP:";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(501, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "DS:";
            this.label4.Visible = false;
            // 
            // cacheRefreshTimer
            // 
            this.cacheRefreshTimer.Interval = 10000;
            this.cacheRefreshTimer.Tick += new System.EventHandler(this.cacheRefreshTimer_Tick);
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(796, 74);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(57, 28);
            this.refresh.TabIndex = 2;
            this.refresh.Text = "&Refresh";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // about
            // 
            this.about.Location = new System.Drawing.Point(832, 2);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(24, 23);
            this.about.TabIndex = 12;
            this.about.Text = "?";
            this.about.UseVisualStyleBackColor = true;
            this.about.Click += new System.EventHandler(this.about_Click);
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
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 616);
            this.Controls.Add(this.about);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.totalSaleForDay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.creditDetail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.totalExpenseForDay);
            this.Controls.Add(this.totalPaymentsForDay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cashbox);
            this.Controls.Add(this.mainTab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShopeKeeper";
            this.Load += new System.EventHandler(this.Main_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.mainTab.ResumeLayout(false);
            this.salesTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.saleSummaryGrid)).EndInit();
            this.expenseTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.expenseGrid)).EndInit();
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
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage reportsTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel totalPaymentsForDay;
        private System.Windows.Forms.LinkLabel totalExpenseForDay;
        private System.Windows.Forms.ToolTip helpTips;
        private System.Windows.Forms.TabPage graphs;
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel creditDetail;
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

    }
}

