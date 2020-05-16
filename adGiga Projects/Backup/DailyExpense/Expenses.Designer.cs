namespace ShopKeeper
{
    partial class Expenses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Expenses));
            this.expenseGrid = new System.Windows.Forms.DataGridView();
            this.sno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expense = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.expenseGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // expenseGrid
            // 
            this.expenseGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.expenseGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sno,
            this.expense,
            this.total});
            this.expenseGrid.Location = new System.Drawing.Point(12, 12);
            this.expenseGrid.Name = "expenseGrid";
            this.expenseGrid.RowHeadersWidth = 20;
            this.expenseGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.expenseGrid.Size = new System.Drawing.Size(339, 547);
            this.expenseGrid.TabIndex = 0;
            this.expenseGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // sno
            // 
            this.sno.Frozen = true;
            this.sno.HeaderText = "No.";
            this.sno.Name = "sno";
            this.sno.ReadOnly = true;
            this.sno.Width = 35;
            // 
            // expense
            // 
            this.expense.Frozen = true;
            this.expense.HeaderText = "Expense";
            this.expense.Name = "expense";
            this.expense.ReadOnly = true;
            this.expense.Width = 160;
            // 
            // total
            // 
            this.total.Frozen = true;
            this.total.HeaderText = "Total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // Expenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 571);
            this.ControlBox = false;
            this.Controls.Add(this.expenseGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Expenses";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Expenses";
            ((System.ComponentModel.ISupportInitialize)(this.expenseGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView expenseGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn sno;
        private System.Windows.Forms.DataGridViewTextBoxColumn expense;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
    }
}