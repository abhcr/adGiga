namespace ShopKeeper
{
    partial class ItemEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemEditor));
            this.itemGrid = new System.Windows.Forms.DataGridView();
            this.itemIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.itemNameBox = new System.Windows.Forms.TextBox();
            this.stockTextBox = new System.Windows.Forms.TextBox();
            this.taxRateBox = new System.Windows.Forms.TextBox();
            this.saleRateBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.detailsGroupBox = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.unitBox = new System.Windows.Forms.TextBox();
            this.saveItem = new System.Windows.Forms.Button();
            this.deleteItem = new System.Windows.Forms.Button();
            this.cancelEdit = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.startsWith = new System.Windows.Forms.RadioButton();
            this.contains = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nextResult = new System.Windows.Forms.LinkLabel();
            this.helpTips = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.newButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.itemGrid)).BeginInit();
            this.detailsGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // itemGrid
            // 
            this.itemGrid.AllowUserToAddRows = false;
            this.itemGrid.AllowUserToDeleteRows = false;
            this.itemGrid.AllowUserToResizeRows = false;
            this.itemGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.itemGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemIdColumn,
            this.itemNameColumn});
            this.itemGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.itemGrid.Location = new System.Drawing.Point(12, 25);
            this.itemGrid.MultiSelect = false;
            this.itemGrid.Name = "itemGrid";
            this.itemGrid.RowHeadersWidth = 30;
            this.itemGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.itemGrid.Size = new System.Drawing.Size(292, 446);
            this.itemGrid.TabIndex = 0;
            this.itemGrid.SelectionChanged += new System.EventHandler(this.itemGrid_SelectionChanged);
            // 
            // itemIdColumn
            // 
            this.itemIdColumn.HeaderText = "ID";
            this.itemIdColumn.Name = "itemIdColumn";
            this.itemIdColumn.ReadOnly = true;
            this.itemIdColumn.Width = 35;
            // 
            // itemNameColumn
            // 
            this.itemNameColumn.HeaderText = "Name";
            this.itemNameColumn.Name = "itemNameColumn";
            this.itemNameColumn.ReadOnly = true;
            this.itemNameColumn.Width = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select an Item to Edit:";
            // 
            // itemNameBox
            // 
            this.errorProvider.SetIconPadding(this.itemNameBox, 1);
            this.itemNameBox.Location = new System.Drawing.Point(123, 19);
            this.itemNameBox.Name = "itemNameBox";
            this.itemNameBox.Size = new System.Drawing.Size(100, 20);
            this.itemNameBox.TabIndex = 2;
            this.itemNameBox.TextChanged += new System.EventHandler(this.itemNameBox_TextChanged);
            this.itemNameBox.Validating += new System.ComponentModel.CancelEventHandler(this.itemNameBox_Validating);
            this.itemNameBox.Validated += new System.EventHandler(this.itemNameBox_Validated);
            // 
            // stockTextBox
            // 
            this.stockTextBox.Location = new System.Drawing.Point(123, 97);
            this.stockTextBox.Name = "stockTextBox";
            this.stockTextBox.Size = new System.Drawing.Size(100, 20);
            this.stockTextBox.TabIndex = 5;
            this.stockTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.stockTextBox_Validating);
            this.stockTextBox.Validated += new System.EventHandler(this.stockTextBox_Validated);
            // 
            // taxRateBox
            // 
            this.taxRateBox.Location = new System.Drawing.Point(123, 71);
            this.taxRateBox.Name = "taxRateBox";
            this.taxRateBox.Size = new System.Drawing.Size(100, 20);
            this.taxRateBox.TabIndex = 4;
            this.taxRateBox.Validating += new System.ComponentModel.CancelEventHandler(this.taxRateBox_Validating);
            this.taxRateBox.Validated += new System.EventHandler(this.taxRateBox_Validated);
            // 
            // saleRateBox
            // 
            this.saleRateBox.Location = new System.Drawing.Point(123, 45);
            this.saleRateBox.Name = "saleRateBox";
            this.saleRateBox.Size = new System.Drawing.Size(100, 20);
            this.saleRateBox.TabIndex = 3;
            this.saleRateBox.Validating += new System.ComponentModel.CancelEventHandler(this.saleRateBox_Validating);
            this.saleRateBox.Validated += new System.EventHandler(this.saleRateBox_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Item Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tax Rate:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Stock:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Sale Rate:";
            // 
            // detailsGroupBox
            // 
            this.detailsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.detailsGroupBox.Controls.Add(this.label5);
            this.detailsGroupBox.Controls.Add(this.unitBox);
            this.detailsGroupBox.Controls.Add(this.label2);
            this.detailsGroupBox.Controls.Add(this.label6);
            this.detailsGroupBox.Controls.Add(this.itemNameBox);
            this.detailsGroupBox.Controls.Add(this.label4);
            this.detailsGroupBox.Controls.Add(this.stockTextBox);
            this.detailsGroupBox.Controls.Add(this.label3);
            this.detailsGroupBox.Controls.Add(this.taxRateBox);
            this.detailsGroupBox.Controls.Add(this.saleRateBox);
            this.detailsGroupBox.Location = new System.Drawing.Point(321, 104);
            this.detailsGroupBox.Name = "detailsGroupBox";
            this.detailsGroupBox.Size = new System.Drawing.Size(251, 162);
            this.detailsGroupBox.TabIndex = 11;
            this.detailsGroupBox.TabStop = false;
            this.detailsGroupBox.Text = "Item Details";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(88, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Unit:";
            // 
            // unitBox
            // 
            this.unitBox.Location = new System.Drawing.Point(123, 123);
            this.unitBox.Name = "unitBox";
            this.unitBox.Size = new System.Drawing.Size(100, 20);
            this.unitBox.TabIndex = 11;
            // 
            // saveItem
            // 
            this.saveItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveItem.Location = new System.Drawing.Point(377, 397);
            this.saveItem.Name = "saveItem";
            this.saveItem.Size = new System.Drawing.Size(89, 44);
            this.saveItem.TabIndex = 6;
            this.saveItem.Text = "&Save";
            this.saveItem.UseVisualStyleBackColor = true;
            this.saveItem.Click += new System.EventHandler(this.saveItem_Click);
            // 
            // deleteItem
            // 
            this.deleteItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteItem.Location = new System.Drawing.Point(377, 447);
            this.deleteItem.Name = "deleteItem";
            this.deleteItem.Size = new System.Drawing.Size(89, 24);
            this.deleteItem.TabIndex = 9;
            this.deleteItem.Text = "&Delete";
            this.deleteItem.UseVisualStyleBackColor = true;
            this.deleteItem.Click += new System.EventHandler(this.deleteItem_Click);
            // 
            // cancelEdit
            // 
            this.cancelEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelEdit.Location = new System.Drawing.Point(472, 339);
            this.cancelEdit.Name = "cancelEdit";
            this.cancelEdit.Size = new System.Drawing.Size(100, 52);
            this.cancelEdit.TabIndex = 7;
            this.cancelEdit.Text = "Cancel &Edit";
            this.cancelEdit.UseVisualStyleBackColor = true;
            this.cancelEdit.Click += new System.EventHandler(this.cancelEdit_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(472, 397);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 74);
            this.button4.TabIndex = 8;
            this.button4.Text = "&Close";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBox.Location = new System.Drawing.Point(6, 19);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(239, 20);
            this.searchBox.TabIndex = 1;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // startsWith
            // 
            this.startsWith.AutoSize = true;
            this.startsWith.Location = new System.Drawing.Point(78, 45);
            this.startsWith.Name = "startsWith";
            this.startsWith.Size = new System.Drawing.Size(74, 17);
            this.startsWith.TabIndex = 18;
            this.startsWith.Text = "Starts with";
            this.startsWith.UseVisualStyleBackColor = true;
            // 
            // contains
            // 
            this.contains.AutoSize = true;
            this.contains.Checked = true;
            this.contains.Location = new System.Drawing.Point(6, 45);
            this.contains.Name = "contains";
            this.contains.Size = new System.Drawing.Size(66, 17);
            this.contains.TabIndex = 19;
            this.contains.TabStop = true;
            this.contains.Text = "Contains";
            this.contains.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nextResult);
            this.groupBox2.Controls.Add(this.searchBox);
            this.groupBox2.Controls.Add(this.startsWith);
            this.groupBox2.Controls.Add(this.contains);
            this.groupBox2.Location = new System.Drawing.Point(321, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(251, 73);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search";
            // 
            // nextResult
            // 
            this.nextResult.AutoSize = true;
            this.nextResult.Location = new System.Drawing.Point(218, 47);
            this.nextResult.Name = "nextResult";
            this.nextResult.Size = new System.Drawing.Size(29, 13);
            this.nextResult.TabIndex = 20;
            this.nextResult.TabStop = true;
            this.nextResult.Text = "&Next";
            this.helpTips.SetToolTip(this.nextResult, "Locate Next Search Result in Table");
            this.nextResult.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.nextResult_LinkClicked);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(377, 339);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(89, 52);
            this.newButton.TabIndex = 21;
            this.newButton.Text = "&New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // ItemEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 483);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.cancelEdit);
            this.Controls.Add(this.deleteItem);
            this.Controls.Add(this.saveItem);
            this.Controls.Add(this.detailsGroupBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.itemGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 1000);
            this.MinimumSize = new System.Drawing.Size(600, 519);
            this.Name = "ItemEditor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Editor";
            this.Load += new System.EventHandler(this.ItemEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.itemGrid)).EndInit();
            this.detailsGroupBox.ResumeLayout(false);
            this.detailsGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView itemGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox itemNameBox;
        private System.Windows.Forms.TextBox stockTextBox;
        private System.Windows.Forms.TextBox taxRateBox;
        private System.Windows.Forms.TextBox saleRateBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox detailsGroupBox;
        private System.Windows.Forms.Button saveItem;
        private System.Windows.Forms.Button deleteItem;
        private System.Windows.Forms.Button cancelEdit;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameColumn;
        private System.Windows.Forms.RadioButton startsWith;
        private System.Windows.Forms.RadioButton contains;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel nextResult;
        private System.Windows.Forms.ToolTip helpTips;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox unitBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button newButton;
    }
}