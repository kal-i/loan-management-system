namespace LoanManagementSystem.ViewController
{
    partial class frmPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayment));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.PaymentTabControl = new MetroFramework.Controls.MetroTabControl();
            this.LoanPayment = new MetroFramework.Controls.MetroTabPage();
            this.amortizationDataGridView = new System.Windows.Forms.DataGridView();
            this.colPay = new System.Windows.Forms.DataGridViewImageColumn();
            this.TransactionHistory = new System.Windows.Forms.TabPage();
            this.transactHistoryDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_Close = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loanIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.principalAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.interestAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remainingBalanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isPaidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentTabControl.SuspendLayout();
            this.LoanPayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amortizationDataGridView)).BeginInit();
            this.TransactionHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transactHistoryDataGridView)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paymentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // PaymentTabControl
            // 
            this.PaymentTabControl.Controls.Add(this.LoanPayment);
            this.PaymentTabControl.Controls.Add(this.TransactionHistory);
            this.PaymentTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PaymentTabControl.Location = new System.Drawing.Point(0, 50);
            this.PaymentTabControl.Name = "PaymentTabControl";
            this.PaymentTabControl.SelectedIndex = 0;
            this.PaymentTabControl.Size = new System.Drawing.Size(800, 400);
            this.PaymentTabControl.TabIndex = 0;
            this.PaymentTabControl.UseSelectable = true;
            this.PaymentTabControl.SelectedIndexChanged += new System.EventHandler(this.PaymentTabControl_SelectedIndexChanged);
            // 
            // LoanPayment
            // 
            this.LoanPayment.Controls.Add(this.amortizationDataGridView);
            this.LoanPayment.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoanPayment.HorizontalScrollbarBarColor = true;
            this.LoanPayment.HorizontalScrollbarHighlightOnWheel = false;
            this.LoanPayment.HorizontalScrollbarSize = 10;
            this.LoanPayment.Location = new System.Drawing.Point(4, 38);
            this.LoanPayment.Name = "LoanPayment";
            this.LoanPayment.Size = new System.Drawing.Size(792, 358);
            this.LoanPayment.TabIndex = 0;
            this.LoanPayment.Text = "Loan Payment";
            this.LoanPayment.VerticalScrollbarBarColor = true;
            this.LoanPayment.VerticalScrollbarHighlightOnWheel = false;
            this.LoanPayment.VerticalScrollbarSize = 10;
            // 
            // amortizationDataGridView
            // 
            this.amortizationDataGridView.AllowUserToAddRows = false;
            this.amortizationDataGridView.AllowUserToDeleteRows = false;
            this.amortizationDataGridView.AllowUserToResizeColumns = false;
            this.amortizationDataGridView.AllowUserToResizeRows = false;
            this.amortizationDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.amortizationDataGridView.AutoGenerateColumns = false;
            this.amortizationDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.amortizationDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.amortizationDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.amortizationDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.amortizationDataGridView.ColumnHeadersHeight = 30;
            this.amortizationDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.amortizationDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.loanIdDataGridViewTextBoxColumn,
            this.paymentNumberDataGridViewTextBoxColumn,
            this.paymentDateDataGridViewTextBoxColumn,
            this.principalAmountDataGridViewTextBoxColumn,
            this.interestAmountDataGridViewTextBoxColumn,
            this.remainingBalanceDataGridViewTextBoxColumn,
            this.isPaidDataGridViewTextBoxColumn,
            this.colPay});
            this.amortizationDataGridView.DataSource = this.paymentBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.amortizationDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.amortizationDataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.amortizationDataGridView.Location = new System.Drawing.Point(8, 3);
            this.amortizationDataGridView.Name = "amortizationDataGridView";
            this.amortizationDataGridView.ReadOnly = true;
            this.amortizationDataGridView.RowHeadersVisible = false;
            this.amortizationDataGridView.RowTemplate.Height = 40;
            this.amortizationDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.amortizationDataGridView.Size = new System.Drawing.Size(776, 352);
            this.amortizationDataGridView.TabIndex = 8;
            this.amortizationDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.amortizationDataGridView_CellContentClick);
            // 
            // colPay
            // 
            this.colPay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPay.HeaderText = "";
            this.colPay.Image = ((System.Drawing.Image)(resources.GetObject("colPay.Image")));
            this.colPay.Name = "colPay";
            this.colPay.ReadOnly = true;
            this.colPay.Width = 5;
            // 
            // TransactionHistory
            // 
            this.TransactionHistory.BackColor = System.Drawing.Color.White;
            this.TransactionHistory.Controls.Add(this.transactHistoryDataGridView);
            this.TransactionHistory.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransactionHistory.Location = new System.Drawing.Point(4, 38);
            this.TransactionHistory.Name = "TransactionHistory";
            this.TransactionHistory.Size = new System.Drawing.Size(792, 358);
            this.TransactionHistory.TabIndex = 1;
            this.TransactionHistory.Text = "Transaction History";
            // 
            // transactHistoryDataGridView
            // 
            this.transactHistoryDataGridView.AllowUserToAddRows = false;
            this.transactHistoryDataGridView.AllowUserToDeleteRows = false;
            this.transactHistoryDataGridView.AllowUserToResizeColumns = false;
            this.transactHistoryDataGridView.AllowUserToResizeRows = false;
            this.transactHistoryDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.transactHistoryDataGridView.AutoGenerateColumns = false;
            this.transactHistoryDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.transactHistoryDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.transactHistoryDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.transactHistoryDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.transactHistoryDataGridView.ColumnHeadersHeight = 30;
            this.transactHistoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.transactHistoryDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewImageColumn1});
            this.transactHistoryDataGridView.DataSource = this.paymentBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.transactHistoryDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.transactHistoryDataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.transactHistoryDataGridView.Location = new System.Drawing.Point(8, 3);
            this.transactHistoryDataGridView.Name = "transactHistoryDataGridView";
            this.transactHistoryDataGridView.ReadOnly = true;
            this.transactHistoryDataGridView.RowHeadersVisible = false;
            this.transactHistoryDataGridView.RowTemplate.Height = 40;
            this.transactHistoryDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.transactHistoryDataGridView.Size = new System.Drawing.Size(776, 352);
            this.transactHistoryDataGridView.TabIndex = 10;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.btn_Close);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 50);
            this.panel3.TabIndex = 3;
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Close.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Close.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Close.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Close.FillColor = System.Drawing.Color.Transparent;
            this.btn_Close.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.Color.Black;
            this.btn_Close.Location = new System.Drawing.Point(716, 5);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(66, 40);
            this.btn_Close.TabIndex = 5;
            this.btn_Close.Text = "[Close]";
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Inter", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.label1.Location = new System.Drawing.Point(18, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Transaction Process";
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "ID";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 43;
            // 
            // loanIdDataGridViewTextBoxColumn
            // 
            this.loanIdDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.loanIdDataGridViewTextBoxColumn.DataPropertyName = "LoanId";
            this.loanIdDataGridViewTextBoxColumn.HeaderText = "Loan ID";
            this.loanIdDataGridViewTextBoxColumn.Name = "loanIdDataGridViewTextBoxColumn";
            this.loanIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.loanIdDataGridViewTextBoxColumn.Width = 66;
            // 
            // paymentNumberDataGridViewTextBoxColumn
            // 
            this.paymentNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.paymentNumberDataGridViewTextBoxColumn.DataPropertyName = "PaymentNumber";
            this.paymentNumberDataGridViewTextBoxColumn.HeaderText = "Payment Number";
            this.paymentNumberDataGridViewTextBoxColumn.Name = "paymentNumberDataGridViewTextBoxColumn";
            this.paymentNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // paymentDateDataGridViewTextBoxColumn
            // 
            this.paymentDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.paymentDateDataGridViewTextBoxColumn.DataPropertyName = "PaymentDate";
            this.paymentDateDataGridViewTextBoxColumn.HeaderText = "Payment Date";
            this.paymentDateDataGridViewTextBoxColumn.Name = "paymentDateDataGridViewTextBoxColumn";
            this.paymentDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // principalAmountDataGridViewTextBoxColumn
            // 
            this.principalAmountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.principalAmountDataGridViewTextBoxColumn.DataPropertyName = "PrincipalAmount";
            this.principalAmountDataGridViewTextBoxColumn.HeaderText = "Principal Amount";
            this.principalAmountDataGridViewTextBoxColumn.Name = "principalAmountDataGridViewTextBoxColumn";
            this.principalAmountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // interestAmountDataGridViewTextBoxColumn
            // 
            this.interestAmountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.interestAmountDataGridViewTextBoxColumn.DataPropertyName = "InterestAmount";
            this.interestAmountDataGridViewTextBoxColumn.HeaderText = "Interest Amount";
            this.interestAmountDataGridViewTextBoxColumn.Name = "interestAmountDataGridViewTextBoxColumn";
            this.interestAmountDataGridViewTextBoxColumn.ReadOnly = true;
            this.interestAmountDataGridViewTextBoxColumn.Width = 105;
            // 
            // remainingBalanceDataGridViewTextBoxColumn
            // 
            this.remainingBalanceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.remainingBalanceDataGridViewTextBoxColumn.DataPropertyName = "RemainingBalance";
            this.remainingBalanceDataGridViewTextBoxColumn.HeaderText = "Remaining Balance";
            this.remainingBalanceDataGridViewTextBoxColumn.Name = "remainingBalanceDataGridViewTextBoxColumn";
            this.remainingBalanceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isPaidDataGridViewTextBoxColumn
            // 
            this.isPaidDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.isPaidDataGridViewTextBoxColumn.DataPropertyName = "Is_Paid";
            this.isPaidDataGridViewTextBoxColumn.HeaderText = "Status";
            this.isPaidDataGridViewTextBoxColumn.Name = "isPaidDataGridViewTextBoxColumn";
            this.isPaidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // paymentBindingSource
            // 
            this.paymentBindingSource.DataSource = typeof(LoanManagementSystem.Models.Payment);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 43;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "LoanId";
            this.dataGridViewTextBoxColumn2.HeaderText = "Loan ID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 66;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "PaymentNumber";
            this.dataGridViewTextBoxColumn3.HeaderText = "Payment Number";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "PaymentDate";
            this.dataGridViewTextBoxColumn4.HeaderText = "Payment Date";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "PrincipalAmount";
            this.dataGridViewTextBoxColumn5.HeaderText = "Principal Amount";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "InterestAmount";
            this.dataGridViewTextBoxColumn6.HeaderText = "Interest Amount";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 105;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "RemainingBalance";
            this.dataGridViewTextBoxColumn7.HeaderText = "Remaining Balance";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Is_Paid";
            this.dataGridViewTextBoxColumn8.HeaderText = "Status";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // frmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PaymentTabControl);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPayment";
            this.Load += new System.EventHandler(this.frmPayment_Load);
            this.PaymentTabControl.ResumeLayout(false);
            this.LoanPayment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.amortizationDataGridView)).EndInit();
            this.TransactionHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.transactHistoryDataGridView)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paymentBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private MetroFramework.Controls.MetroTabControl PaymentTabControl;
        private MetroFramework.Controls.MetroTabPage LoanPayment;
        private System.Windows.Forms.DataGridView amortizationDataGridView;
        private System.Windows.Forms.BindingSource paymentBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loanIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn principalAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn interestAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remainingBalanceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isPaidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn colPay;
        private System.Windows.Forms.TabPage TransactionHistory;
        private System.Windows.Forms.DataGridView transactHistoryDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2Button btn_Close;
        private System.Windows.Forms.Label label1;
    }
}