﻿namespace ShopKeeper
{
    partial class CustomerEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerEditor));
            this.itemGrid = new System.Windows.Forms.DataGridView();
            this.itemIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.customerName = new System.Windows.Forms.TextBox();
            this.customerAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.detailsGroupBox = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.phoneNumber = new System.Windows.Forms.TextBox();
            this.saveItem = new System.Windows.Forms.Button();
            this.deleteItem = new System.Windows.Forms.Button();
            this.cancelEdit = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.startsWith = new System.Windows.Forms.RadioButton();
            this.contains = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.exactly = new System.Windows.Forms.RadioButton();
            this.nextResult = new System.Windows.Forms.LinkLabel();
            this.helpTips = new System.Windows.Forms.ToolTip(this.components);
            this.newButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
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
            this.itemGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemGrid_CellContentDoubleClick);
            this.itemGrid.SelectionChanged += new System.EventHandler(this.customerGrid_SelectionChanged);
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
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select a Customer to Edit:";
            // 
            // customerName
            // 
            this.errorProvider.SetIconPadding(this.customerName, 1);
            this.customerName.Location = new System.Drawing.Point(78, 19);
            this.customerName.Name = "customerName";
            this.customerName.Size = new System.Drawing.Size(148, 20);
            this.customerName.TabIndex = 2;
            this.customerName.TextChanged += new System.EventHandler(this.customerName_TextChanged);
            this.customerName.Validating += new System.ComponentModel.CancelEventHandler(this.customerNameBox_Validating);
            this.customerName.Validated += new System.EventHandler(this.customerNameBox_Validated);
            // 
            // customerAddress
            // 
            this.customerAddress.Location = new System.Drawing.Point(78, 45);
            this.customerAddress.Multiline = true;
            this.customerAddress.Name = "customerAddress";
            this.customerAddress.Size = new System.Drawing.Size(148, 72);
            this.customerAddress.TabIndex = 3;
            this.customerAddress.Validating += new System.ComponentModel.CancelEventHandler(this.addressRateBox_Validating);
            this.customerAddress.Validated += new System.EventHandler(this.addressRateBox_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Address:";
            // 
            // detailsGroupBox
            // 
            this.detailsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.detailsGroupBox.Controls.Add(this.label5);
            this.detailsGroupBox.Controls.Add(this.phoneNumber);
            this.detailsGroupBox.Controls.Add(this.label2);
            this.detailsGroupBox.Controls.Add(this.label6);
            this.detailsGroupBox.Controls.Add(this.customerName);
            this.detailsGroupBox.Controls.Add(this.customerAddress);
            this.detailsGroupBox.Location = new System.Drawing.Point(321, 104);
            this.detailsGroupBox.Name = "detailsGroupBox";
            this.detailsGroupBox.Size = new System.Drawing.Size(251, 162);
            this.detailsGroupBox.TabIndex = 11;
            this.detailsGroupBox.TabStop = false;
            this.detailsGroupBox.Text = "Customer Details";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Phone:";
            // 
            // phoneNumber
            // 
            this.phoneNumber.Location = new System.Drawing.Point(78, 123);
            this.phoneNumber.Name = "phoneNumber";
            this.phoneNumber.Size = new System.Drawing.Size(148, 20);
            this.phoneNumber.TabIndex = 11;
            // 
            // saveItem
            // 
            this.saveItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveItem.Location = new System.Drawing.Point(366, 409);
            this.saveItem.Name = "saveItem";
            this.saveItem.Size = new System.Drawing.Size(89, 32);
            this.saveItem.TabIndex = 6;
            this.saveItem.Text = "&Save";
            this.saveItem.UseVisualStyleBackColor = true;
            this.saveItem.Click += new System.EventHandler(this.saveCustomer_Click);
            // 
            // deleteItem
            // 
            this.deleteItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteItem.Location = new System.Drawing.Point(366, 447);
            this.deleteItem.Name = "deleteItem";
            this.deleteItem.Size = new System.Drawing.Size(89, 24);
            this.deleteItem.TabIndex = 9;
            this.deleteItem.Text = "&Delete";
            this.helpTips.SetToolTip(this.deleteItem, "Deletes the displayed customer");
            this.deleteItem.UseVisualStyleBackColor = true;
            this.deleteItem.Click += new System.EventHandler(this.deleteCustomer_Click);
            // 
            // cancelEdit
            // 
            this.cancelEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelEdit.Location = new System.Drawing.Point(472, 351);
            this.cancelEdit.Name = "cancelEdit";
            this.cancelEdit.Size = new System.Drawing.Size(100, 52);
            this.cancelEdit.TabIndex = 7;
            this.cancelEdit.Text = "Cancel &Edit";
            this.helpTips.SetToolTip(this.cancelEdit, "Reverts any changes made");
            this.cancelEdit.UseVisualStyleBackColor = true;
            this.cancelEdit.Click += new System.EventHandler(this.cancelEdit_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(472, 409);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 62);
            this.button4.TabIndex = 8;
            this.button4.Text = "&Close";
            this.helpTips.SetToolTip(this.button4, "Closes this window");
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.close_Click);
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
            this.groupBox2.Controls.Add(this.exactly);
            this.groupBox2.Controls.Add(this.nextResult);
            this.groupBox2.Controls.Add(this.searchBox);
            this.groupBox2.Controls.Add(this.startsWith);
            this.groupBox2.Controls.Add(this.contains);
            this.groupBox2.Location = new System.Drawing.Point(321, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(251, 74);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search";
            // 
            // exactly
            // 
            this.exactly.AutoSize = true;
            this.exactly.Location = new System.Drawing.Point(158, 45);
            this.exactly.Name = "exactly";
            this.exactly.Size = new System.Drawing.Size(52, 17);
            this.exactly.TabIndex = 21;
            this.exactly.Text = "Exact";
            this.exactly.UseVisualStyleBackColor = true;
            // 
            // nextResult
            // 
            this.nextResult.AutoSize = true;
            this.nextResult.Location = new System.Drawing.Point(216, 47);
            this.nextResult.Name = "nextResult";
            this.nextResult.Size = new System.Drawing.Size(29, 13);
            this.nextResult.TabIndex = 20;
            this.nextResult.TabStop = true;
            this.nextResult.Text = "&Next";
            this.helpTips.SetToolTip(this.nextResult, "Locate Next Search Result in Table");
            this.nextResult.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.nextResult_LinkClicked);
            // 
            // newButton
            // 
            this.newButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newButton.Location = new System.Drawing.Point(366, 351);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(89, 52);
            this.newButton.TabIndex = 21;
            this.newButton.Text = "&New";
            this.helpTips.SetToolTip(this.newButton, "Creates a new customer");
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // CustomerEditor
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
            this.Name = "CustomerEditor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Manager";
            this.Load += new System.EventHandler(this.CustomerEditor_Load);
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
        private System.Windows.Forms.TextBox customerName;
        private System.Windows.Forms.TextBox customerAddress;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.TextBox phoneNumber;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.RadioButton exactly;
        private System.Windows.Forms.Button newButton;
    }
}