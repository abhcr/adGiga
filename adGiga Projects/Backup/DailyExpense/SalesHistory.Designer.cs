namespace ShopKeeper
{
    partial class SalesHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesHistory));
            this.saleGrid = new System.Windows.Forms.DataGridView();
            this.dateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.totalPurchase = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.totalPayment = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pendingAmount = new System.Windows.Forms.Label();
            this.ok = new System.Windows.Forms.Button();
            this.print = new System.Windows.Forms.Button();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.helpTip = new System.Windows.Forms.ToolTip(this.components);
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.deleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.saleGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // saleGrid
            // 
            this.saleGrid.AllowUserToAddRows = false;
            this.saleGrid.AllowUserToDeleteRows = false;
            this.saleGrid.AllowUserToOrderColumns = true;
            this.saleGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.saleGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateTime,
            this.number,
            this.item,
            this.rate,
            this.quantity,
            this.unit,
            this.amount,
            this.subTotal});
            this.saleGrid.Location = new System.Drawing.Point(12, 12);
            this.saleGrid.Name = "saleGrid";
            this.saleGrid.ReadOnly = true;
            this.saleGrid.RowHeadersWidth = 18;
            this.saleGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.saleGrid.Size = new System.Drawing.Size(685, 507);
            this.saleGrid.TabIndex = 0;
            this.saleGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.saleGrid_CellDoubleClick);
            // 
            // dateTime
            // 
            this.dateTime.Frozen = true;
            this.dateTime.HeaderText = "Dt & Time";
            this.dateTime.Name = "dateTime";
            this.dateTime.ReadOnly = true;
            this.dateTime.Width = 125;
            // 
            // number
            // 
            this.number.Frozen = true;
            this.number.HeaderText = "S.No";
            this.number.Name = "number";
            this.number.ReadOnly = true;
            this.number.Width = 35;
            // 
            // item
            // 
            this.item.HeaderText = "Item";
            this.item.Name = "item";
            this.item.ReadOnly = true;
            this.item.Width = 180;
            // 
            // rate
            // 
            this.rate.HeaderText = "Rate";
            this.rate.Name = "rate";
            this.rate.ReadOnly = true;
            this.rate.Width = 50;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Quantity";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            this.quantity.Width = 40;
            // 
            // unit
            // 
            this.unit.HeaderText = "Unit";
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            this.unit.Width = 40;
            // 
            // amount
            // 
            this.amount.HeaderText = "Amount";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            this.amount.Width = 80;
            // 
            // subTotal
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.subTotal.DefaultCellStyle = dataGridViewCellStyle1;
            this.subTotal.HeaderText = "Sub Total";
            this.subTotal.Name = "subTotal";
            this.subTotal.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 553);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total Purchase:";
            // 
            // totalPurchase
            // 
            this.totalPurchase.AutoSize = true;
            this.totalPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPurchase.Location = new System.Drawing.Point(87, 533);
            this.totalPurchase.Name = "totalPurchase";
            this.totalPurchase.Size = new System.Drawing.Size(83, 24);
            this.totalPurchase.TabIndex = 2;
            this.totalPurchase.Text = "tot.purch";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 555);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Total Payment:";
            // 
            // totalPayment
            // 
            this.totalPayment.AutoSize = true;
            this.totalPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPayment.Location = new System.Drawing.Point(248, 533);
            this.totalPayment.Name = "totalPayment";
            this.totalPayment.Size = new System.Drawing.Size(65, 24);
            this.totalPayment.TabIndex = 4;
            this.totalPayment.Text = "tot.pmt";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(335, 556);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Pending:";
            // 
            // pendingAmount
            // 
            this.pendingAmount.AutoSize = true;
            this.pendingAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pendingAmount.Location = new System.Drawing.Point(378, 534);
            this.pendingAmount.Name = "pendingAmount";
            this.pendingAmount.Size = new System.Drawing.Size(59, 24);
            this.pendingAmount.TabIndex = 6;
            this.pendingAmount.Text = "pend.";
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(587, 555);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(110, 23);
            this.ok.TabIndex = 7;
            this.ok.Text = "&Ok";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // print
            // 
            this.print.Location = new System.Drawing.Point(478, 555);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(102, 23);
            this.print.TabIndex = 8;
            this.print.Text = "&Print";
            this.print.UseVisualStyleBackColor = true;
            this.print.Click += new System.EventHandler(this.print_Click);
            // 
            // startDate
            // 
            this.startDate.CustomFormat = "dd/MM/yy";
            this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDate.Location = new System.Drawing.Point(478, 533);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(102, 20);
            this.startDate.TabIndex = 9;
            this.helpTip.SetToolTip(this.startDate, "Report Start Date");
            this.startDate.ValueChanged += new System.EventHandler(this.startDate_ValueChanged);
            // 
            // helpTip
            // 
            this.helpTip.AutoPopDelay = 10000;
            this.helpTip.InitialDelay = 300;
            this.helpTip.IsBalloon = true;
            this.helpTip.ReshowDelay = 100;
            this.helpTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(586, 530);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(111, 23);
            this.deleteButton.TabIndex = 10;
            this.deleteButton.Text = "&Delete Prev.";
            this.helpTip.SetToolTip(this.deleteButton, "Delete all records\r\nbefore selected date");
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // SalesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 585);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.print);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.pendingAmount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.totalPayment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.totalPurchase);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saleGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SalesHistory";
            this.Text = "SalesHistory";
            ((System.ComponentModel.ISupportInitialize)(this.saleGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView saleGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label totalPurchase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label totalPayment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label pendingAmount;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button print;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.ToolTip helpTip;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn item;
        private System.Windows.Forms.DataGridViewTextBoxColumn rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn subTotal;
        private System.Windows.Forms.Button deleteButton;
    }
}