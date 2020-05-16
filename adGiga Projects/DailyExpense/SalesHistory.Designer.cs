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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesHistory));
            this.saleGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.totalPurchase = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.totalPaymtRcvd = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pendingAmount = new System.Windows.Forms.Label();
            this.ok = new System.Windows.Forms.Button();
            this.print = new System.Windows.Forms.Button();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.helpTip = new System.Windows.Forms.ToolTip(this.components);
            this.deleteButton = new System.Windows.Forms.Button();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.dateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPaymtMade = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.totalSale = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.saleGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // saleGrid
            // 
            this.saleGrid.AllowUserToAddRows = false;
            this.saleGrid.AllowUserToDeleteRows = false;
            this.saleGrid.AllowUserToOrderColumns = true;
            this.saleGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.saleGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.saleGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.saleGrid.Size = new System.Drawing.Size(782, 358);
            this.saleGrid.TabIndex = 0;
            this.saleGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.saleGrid_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 379);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total Purchase:";
            // 
            // totalPurchase
            // 
            this.totalPurchase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.totalPurchase.AutoSize = true;
            this.totalPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPurchase.Location = new System.Drawing.Point(101, 371);
            this.totalPurchase.Name = "totalPurchase";
            this.totalPurchase.Size = new System.Drawing.Size(83, 24);
            this.totalPurchase.TabIndex = 2;
            this.totalPurchase.Text = "tot.purch";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 379);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Payment Rcvd:";
            // 
            // totalPaymtRcvd
            // 
            this.totalPaymtRcvd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.totalPaymtRcvd.AutoSize = true;
            this.totalPaymtRcvd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPaymtRcvd.Location = new System.Drawing.Point(304, 371);
            this.totalPaymtRcvd.Name = "totalPaymtRcvd";
            this.totalPaymtRcvd.Size = new System.Drawing.Size(113, 24);
            this.totalPaymtRcvd.TabIndex = 4;
            this.totalPaymtRcvd.Text = "tot.pmt.Rcvd";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(416, 379);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Pending:";
            // 
            // pendingAmount
            // 
            this.pendingAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pendingAmount.AutoSize = true;
            this.pendingAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pendingAmount.Location = new System.Drawing.Point(471, 371);
            this.pendingAmount.Name = "pendingAmount";
            this.pendingAmount.Size = new System.Drawing.Size(59, 24);
            this.pendingAmount.TabIndex = 6;
            this.pendingAmount.Text = "pend.";
            // 
            // ok
            // 
            this.ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ok.Location = new System.Drawing.Point(684, 414);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(110, 23);
            this.ok.TabIndex = 7;
            this.ok.Text = "&Ok";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // print
            // 
            this.print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.print.Location = new System.Drawing.Point(575, 414);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(102, 23);
            this.print.TabIndex = 8;
            this.print.Text = "&Print";
            this.print.UseVisualStyleBackColor = true;
            this.print.Click += new System.EventHandler(this.print_Click);
            // 
            // startDate
            // 
            this.startDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.startDate.CustomFormat = "dd/MM/yy";
            this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDate.Location = new System.Drawing.Point(575, 392);
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
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Location = new System.Drawing.Point(683, 389);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(111, 23);
            this.deleteButton.TabIndex = 10;
            this.deleteButton.Text = "&Delete Prev.";
            this.helpTip.SetToolTip(this.deleteButton, "Delete all records\r\nbefore selected date");
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // dateTime
            // 
            this.dateTime.Frozen = true;
            this.dateTime.HeaderText = "Dt & Time";
            this.dateTime.Name = "dateTime";
            this.dateTime.ReadOnly = true;
            this.dateTime.Width = 120;
            // 
            // number
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.number.DefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.rate.DefaultCellStyle = dataGridViewCellStyle2;
            this.rate.HeaderText = "Rate";
            this.rate.Name = "rate";
            this.rate.ReadOnly = true;
            this.rate.Width = 50;
            // 
            // quantity
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.quantity.DefaultCellStyle = dataGridViewCellStyle3;
            this.quantity.HeaderText = "Quantity";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            this.quantity.Width = 60;
            // 
            // unit
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.unit.DefaultCellStyle = dataGridViewCellStyle4;
            this.unit.HeaderText = "Unit";
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            this.unit.Width = 40;
            // 
            // amount
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.amount.DefaultCellStyle = dataGridViewCellStyle5;
            this.amount.HeaderText = "Amount";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            this.amount.Width = 80;
            // 
            // subTotal
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.subTotal.DefaultCellStyle = dataGridViewCellStyle6;
            this.subTotal.HeaderText = "Sub Total";
            this.subTotal.Name = "subTotal";
            this.subTotal.ReadOnly = true;
            // 
            // totalPaymtMade
            // 
            this.totalPaymtMade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.totalPaymtMade.AutoSize = true;
            this.totalPaymtMade.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPaymtMade.Location = new System.Drawing.Point(304, 395);
            this.totalPaymtMade.Name = "totalPaymtMade";
            this.totalPaymtMade.Size = new System.Drawing.Size(118, 24);
            this.totalPaymtMade.TabIndex = 14;
            this.totalPaymtMade.Text = "tot.pmt.Made";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 403);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Payment Made:";
            // 
            // totalSale
            // 
            this.totalSale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.totalSale.AutoSize = true;
            this.totalSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalSale.Location = new System.Drawing.Point(101, 395);
            this.totalSale.Name = "totalSale";
            this.totalSale.Size = new System.Drawing.Size(68, 24);
            this.totalSale.TabIndex = 12;
            this.totalSale.Text = "tot.sale";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 403);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Total Sale:";
            // 
            // SalesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 444);
            this.Controls.Add(this.totalPaymtMade);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.totalSale);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.print);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.pendingAmount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.totalPaymtRcvd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.totalPurchase);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saleGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SalesHistory";
            this.ShowInTaskbar = false;
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
        private System.Windows.Forms.Label totalPaymtRcvd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label pendingAmount;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button print;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.ToolTip helpTip;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn item;
        private System.Windows.Forms.DataGridViewTextBoxColumn rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn subTotal;
        private System.Windows.Forms.Label totalPaymtMade;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label totalSale;
        private System.Windows.Forms.Label label7;
    }
}