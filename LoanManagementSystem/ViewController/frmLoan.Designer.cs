namespace LoanManagementSystem.ViewController
{
    partial class frmLoan
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
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Close = new Guna.UI2.WinForms.Guna2Button();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.lblApplicationId = new System.Windows.Forms.Label();
            this.btn_Compute = new Guna.UI2.WinForms.Guna2Button();
            this.btn_Submit = new Guna.UI2.WinForms.Guna2Button();
            this.loanProcessTabControl = new Guna.UI2.WinForms.Guna2TabControl();
            this.ClientLoanInformation = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtb_ClientName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblClientId = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_PaymentFrequency = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_LoanType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtb_OthersFee = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtb_OriginationFee = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtb_InterestAmount = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtb_LoanTerm = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtb_InterestRate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtb_AmountApplied = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.GuarantorCollateralInformation = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cmb_CollateralType = new System.Windows.Forms.ComboBox();
            this.txtb_CollateralLocation = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtb_CollateralValue = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.gb_GuarantorInformation = new System.Windows.Forms.GroupBox();
            this.guarantorBirthDate = new System.Windows.Forms.DateTimePicker();
            this.label25 = new System.Windows.Forms.Label();
            this.txtb_GuarantorAddress = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtb_GuarantorEmail = new System.Windows.Forms.TextBox();
            this.cmb_GuarantorName = new System.Windows.Forms.ComboBox();
            this.lblGuarantorType = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtb_GuarantorPhone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblGuarantorID = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.LoanAmortization = new System.Windows.Forms.TabPage();
            this.cmb_OfficerName = new System.Windows.Forms.ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lbl_PayoffDate = new System.Windows.Forms.Label();
            this.lbl_ActualAmountReleased = new System.Windows.Forms.Label();
            this.lbl_TotalLoanPayments = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.lbl_TotalDeduction = new System.Windows.Forms.Label();
            this.lbl_TotalInterest = new System.Windows.Forms.Label();
            this.lbl_AmountApplied = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.amortizationDataGridView = new System.Windows.Forms.DataGridView();
            this.paymentNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.principalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.interestDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remainingBalanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loanAmortizationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LoanPlot = new System.Windows.Forms.TabPage();
            this.pnlChartContainer = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.loanProcessTabControl.SuspendLayout();
            this.ClientLoanInformation.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.GuarantorCollateralInformation.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.gb_GuarantorInformation.SuspendLayout();
            this.LoanAmortization.SuspendLayout();
            this.guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amortizationDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loanAmortizationBindingSource)).BeginInit();
            this.LoanPlot.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 53);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Inter", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Loan Process";
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
            this.btn_Close.Location = new System.Drawing.Point(721, 6);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(66, 40);
            this.btn_Close.TabIndex = 4;
            this.btn_Close.Text = "[Close]";
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.White;
            this.pnlContainer.Controls.Add(this.lblApplicationId);
            this.pnlContainer.Controls.Add(this.btn_Compute);
            this.pnlContainer.Controls.Add(this.btn_Submit);
            this.pnlContainer.Controls.Add(this.loanProcessTabControl);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 53);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(800, 547);
            this.pnlContainer.TabIndex = 1;
            // 
            // lblApplicationId
            // 
            this.lblApplicationId.AutoSize = true;
            this.lblApplicationId.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblApplicationId.Location = new System.Drawing.Point(348, 488);
            this.lblApplicationId.Name = "lblApplicationId";
            this.lblApplicationId.Size = new System.Drawing.Size(13, 13);
            this.lblApplicationId.TabIndex = 20;
            this.lblApplicationId.Text = "0";
            // 
            // btn_Compute
            // 
            this.btn_Compute.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.btn_Compute.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Compute.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Compute.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Compute.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Compute.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.btn_Compute.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Compute.ForeColor = System.Drawing.Color.White;
            this.btn_Compute.Location = new System.Drawing.Point(427, 471);
            this.btn_Compute.Name = "btn_Compute";
            this.btn_Compute.Size = new System.Drawing.Size(180, 30);
            this.btn_Compute.TabIndex = 11;
            this.btn_Compute.Text = "Compute";
            this.btn_Compute.Click += new System.EventHandler(this.btn_Compute_Click);
            // 
            // btn_Submit
            // 
            this.btn_Submit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Submit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Submit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Submit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Submit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(168)))), ((int)(((byte)(68)))));
            this.btn_Submit.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Submit.ForeColor = System.Drawing.Color.White;
            this.btn_Submit.Location = new System.Drawing.Point(613, 471);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(180, 30);
            this.btn_Submit.TabIndex = 9;
            this.btn_Submit.Text = "Submit";
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // loanProcessTabControl
            // 
            this.loanProcessTabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.loanProcessTabControl.Controls.Add(this.ClientLoanInformation);
            this.loanProcessTabControl.Controls.Add(this.GuarantorCollateralInformation);
            this.loanProcessTabControl.Controls.Add(this.LoanAmortization);
            this.loanProcessTabControl.Controls.Add(this.LoanPlot);
            this.loanProcessTabControl.Font = new System.Drawing.Font("Inter Italic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loanProcessTabControl.ItemSize = new System.Drawing.Size(180, 40);
            this.loanProcessTabControl.Location = new System.Drawing.Point(8, 6);
            this.loanProcessTabControl.Name = "loanProcessTabControl";
            this.loanProcessTabControl.SelectedIndex = 0;
            this.loanProcessTabControl.Size = new System.Drawing.Size(785, 459);
            this.loanProcessTabControl.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.loanProcessTabControl.TabButtonHoverState.FillColor = System.Drawing.SystemColors.Control;
            this.loanProcessTabControl.TabButtonHoverState.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loanProcessTabControl.TabButtonHoverState.ForeColor = System.Drawing.Color.Silver;
            this.loanProcessTabControl.TabButtonHoverState.InnerColor = System.Drawing.SystemColors.Control;
            this.loanProcessTabControl.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.loanProcessTabControl.TabButtonIdleState.FillColor = System.Drawing.Color.White;
            this.loanProcessTabControl.TabButtonIdleState.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loanProcessTabControl.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.loanProcessTabControl.TabButtonIdleState.InnerColor = System.Drawing.Color.White;
            this.loanProcessTabControl.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.loanProcessTabControl.TabButtonSelectedState.FillColor = System.Drawing.SystemColors.Control;
            this.loanProcessTabControl.TabButtonSelectedState.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loanProcessTabControl.TabButtonSelectedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.loanProcessTabControl.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.loanProcessTabControl.TabButtonSize = new System.Drawing.Size(180, 40);
            this.loanProcessTabControl.TabButtonTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.loanProcessTabControl.TabIndex = 2;
            this.loanProcessTabControl.TabMenuBackColor = System.Drawing.Color.White;
            this.loanProcessTabControl.SelectedIndexChanged += new System.EventHandler(this.loanProcessTabControl_SelectedIndexChanged);
            // 
            // ClientLoanInformation
            // 
            this.ClientLoanInformation.Controls.Add(this.groupBox4);
            this.ClientLoanInformation.Controls.Add(this.groupBox3);
            this.ClientLoanInformation.Controls.Add(this.groupBox2);
            this.ClientLoanInformation.Controls.Add(this.groupBox1);
            this.ClientLoanInformation.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientLoanInformation.Location = new System.Drawing.Point(184, 4);
            this.ClientLoanInformation.Name = "ClientLoanInformation";
            this.ClientLoanInformation.Size = new System.Drawing.Size(597, 451);
            this.ClientLoanInformation.TabIndex = 5;
            this.ClientLoanInformation.Text = "Client Loan Information";
            this.ClientLoanInformation.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.endDateTimePicker);
            this.groupBox4.Controls.Add(this.startDateTimePicker);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(16, 354);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(567, 85);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Loan Maturity";
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Enabled = false;
            this.endDateTimePicker.Location = new System.Drawing.Point(301, 49);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(250, 21);
            this.endDateTimePicker.TabIndex = 16;
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Location = new System.Drawing.Point(18, 49);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(250, 21);
            this.startDateTimePicker.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(298, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 14);
            this.label4.TabIndex = 14;
            this.label4.Text = "End Date";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(15, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 14);
            this.label14.TabIndex = 10;
            this.label14.Text = "Start Date";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtb_ClientName);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.lblClientId);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cmb_PaymentFrequency);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cmb_LoanType);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(16, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(567, 135);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Client Loan Information";
            // 
            // txtb_ClientName
            // 
            this.txtb_ClientName.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_ClientName.Location = new System.Drawing.Point(184, 25);
            this.txtb_ClientName.Name = "txtb_ClientName";
            this.txtb_ClientName.Size = new System.Drawing.Size(367, 21);
            this.txtb_ClientName.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(140, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 14);
            this.label7.TabIndex = 20;
            this.label7.Text = "Name";
            // 
            // lblClientId
            // 
            this.lblClientId.AutoSize = true;
            this.lblClientId.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblClientId.Location = new System.Drawing.Point(78, 28);
            this.lblClientId.Name = "lblClientId";
            this.lblClientId.Size = new System.Drawing.Size(14, 14);
            this.lblClientId.TabIndex = 19;
            this.lblClientId.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(328, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 14);
            this.label5.TabIndex = 18;
            this.label5.Text = "Payment Frequency";
            // 
            // cmb_PaymentFrequency
            // 
            this.cmb_PaymentFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_PaymentFrequency.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_PaymentFrequency.FormattingEnabled = true;
            this.cmb_PaymentFrequency.Items.AddRange(new object[] {
            "Annually",
            "Monthly"});
            this.cmb_PaymentFrequency.Location = new System.Drawing.Point(331, 90);
            this.cmb_PaymentFrequency.Name = "cmb_PaymentFrequency";
            this.cmb_PaymentFrequency.Size = new System.Drawing.Size(220, 22);
            this.cmb_PaymentFrequency.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 14);
            this.label3.TabIndex = 15;
            this.label3.Text = "Loan Type";
            // 
            // cmb_LoanType
            // 
            this.cmb_LoanType.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_LoanType.FormattingEnabled = true;
            this.cmb_LoanType.Location = new System.Drawing.Point(18, 90);
            this.cmb_LoanType.Name = "cmb_LoanType";
            this.cmb_LoanType.Size = new System.Drawing.Size(220, 22);
            this.cmb_LoanType.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "Client ID:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtb_OthersFee);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtb_OriginationFee);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtb_InterestAmount);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(16, 253);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(567, 91);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Loan Deduction";
            // 
            // txtb_OthersFee
            // 
            this.txtb_OthersFee.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_OthersFee.Location = new System.Drawing.Point(391, 55);
            this.txtb_OthersFee.Name = "txtb_OthersFee";
            this.txtb_OthersFee.Size = new System.Drawing.Size(160, 21);
            this.txtb_OthersFee.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(388, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 14);
            this.label11.TabIndex = 14;
            this.label11.Text = "Others";
            // 
            // txtb_OriginationFee
            // 
            this.txtb_OriginationFee.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_OriginationFee.Location = new System.Drawing.Point(208, 55);
            this.txtb_OriginationFee.Name = "txtb_OriginationFee";
            this.txtb_OriginationFee.Size = new System.Drawing.Size(160, 21);
            this.txtb_OriginationFee.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(205, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 14);
            this.label12.TabIndex = 12;
            this.label12.Text = "Origination Fee";
            // 
            // txtb_InterestAmount
            // 
            this.txtb_InterestAmount.Enabled = false;
            this.txtb_InterestAmount.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_InterestAmount.Location = new System.Drawing.Point(18, 55);
            this.txtb_InterestAmount.Name = "txtb_InterestAmount";
            this.txtb_InterestAmount.Size = new System.Drawing.Size(160, 21);
            this.txtb_InterestAmount.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(15, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 14);
            this.label13.TabIndex = 10;
            this.label13.Text = "Interest Amount";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtb_LoanTerm);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtb_InterestRate);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtb_AmountApplied);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 148);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(567, 96);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loan Term && Interest";
            // 
            // txtb_LoanTerm
            // 
            this.txtb_LoanTerm.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_LoanTerm.Location = new System.Drawing.Point(391, 55);
            this.txtb_LoanTerm.Name = "txtb_LoanTerm";
            this.txtb_LoanTerm.Size = new System.Drawing.Size(160, 21);
            this.txtb_LoanTerm.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(388, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 14);
            this.label10.TabIndex = 14;
            this.label10.Text = "Term";
            // 
            // txtb_InterestRate
            // 
            this.txtb_InterestRate.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_InterestRate.Location = new System.Drawing.Point(208, 55);
            this.txtb_InterestRate.Name = "txtb_InterestRate";
            this.txtb_InterestRate.Size = new System.Drawing.Size(160, 21);
            this.txtb_InterestRate.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(205, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 14);
            this.label9.TabIndex = 12;
            this.label9.Text = "Interest Rate (%)";
            // 
            // txtb_AmountApplied
            // 
            this.txtb_AmountApplied.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_AmountApplied.Location = new System.Drawing.Point(18, 55);
            this.txtb_AmountApplied.Name = "txtb_AmountApplied";
            this.txtb_AmountApplied.Size = new System.Drawing.Size(160, 21);
            this.txtb_AmountApplied.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "Amount Applied";
            // 
            // GuarantorCollateralInformation
            // 
            this.GuarantorCollateralInformation.Controls.Add(this.groupBox6);
            this.GuarantorCollateralInformation.Controls.Add(this.gb_GuarantorInformation);
            this.GuarantorCollateralInformation.Location = new System.Drawing.Point(184, 4);
            this.GuarantorCollateralInformation.Name = "GuarantorCollateralInformation";
            this.GuarantorCollateralInformation.Padding = new System.Windows.Forms.Padding(3);
            this.GuarantorCollateralInformation.Size = new System.Drawing.Size(597, 451);
            this.GuarantorCollateralInformation.TabIndex = 1;
            this.GuarantorCollateralInformation.Text = "Guarantor & Collateral Information";
            this.GuarantorCollateralInformation.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cmb_CollateralType);
            this.groupBox6.Controls.Add(this.txtb_CollateralLocation);
            this.groupBox6.Controls.Add(this.label22);
            this.groupBox6.Controls.Add(this.txtb_CollateralValue);
            this.groupBox6.Controls.Add(this.label23);
            this.groupBox6.Controls.Add(this.label24);
            this.groupBox6.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(15, 279);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(567, 155);
            this.groupBox6.TabIndex = 19;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Collateral Information";
            // 
            // cmb_CollateralType
            // 
            this.cmb_CollateralType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_CollateralType.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_CollateralType.FormattingEnabled = true;
            this.cmb_CollateralType.Location = new System.Drawing.Point(18, 54);
            this.cmb_CollateralType.Name = "cmb_CollateralType";
            this.cmb_CollateralType.Size = new System.Drawing.Size(230, 22);
            this.cmb_CollateralType.TabIndex = 29;
            // 
            // txtb_CollateralLocation
            // 
            this.txtb_CollateralLocation.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_CollateralLocation.Location = new System.Drawing.Point(18, 119);
            this.txtb_CollateralLocation.Name = "txtb_CollateralLocation";
            this.txtb_CollateralLocation.Size = new System.Drawing.Size(533, 21);
            this.txtb_CollateralLocation.TabIndex = 28;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(15, 92);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(53, 14);
            this.label22.TabIndex = 25;
            this.label22.Text = "Location";
            // 
            // txtb_CollateralValue
            // 
            this.txtb_CollateralValue.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_CollateralValue.Location = new System.Drawing.Point(321, 55);
            this.txtb_CollateralValue.Name = "txtb_CollateralValue";
            this.txtb_CollateralValue.Size = new System.Drawing.Size(230, 21);
            this.txtb_CollateralValue.TabIndex = 13;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(318, 31);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(92, 14);
            this.label23.TabIndex = 12;
            this.label23.Text = "Collateral Value";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(15, 31);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(88, 14);
            this.label24.TabIndex = 10;
            this.label24.Text = "Collateral Type";
            // 
            // gb_GuarantorInformation
            // 
            this.gb_GuarantorInformation.Controls.Add(this.guarantorBirthDate);
            this.gb_GuarantorInformation.Controls.Add(this.label25);
            this.gb_GuarantorInformation.Controls.Add(this.txtb_GuarantorAddress);
            this.gb_GuarantorInformation.Controls.Add(this.label21);
            this.gb_GuarantorInformation.Controls.Add(this.txtb_GuarantorEmail);
            this.gb_GuarantorInformation.Controls.Add(this.cmb_GuarantorName);
            this.gb_GuarantorInformation.Controls.Add(this.lblGuarantorType);
            this.gb_GuarantorInformation.Controls.Add(this.label20);
            this.gb_GuarantorInformation.Controls.Add(this.txtb_GuarantorPhone);
            this.gb_GuarantorInformation.Controls.Add(this.label8);
            this.gb_GuarantorInformation.Controls.Add(this.lblGuarantorID);
            this.gb_GuarantorInformation.Controls.Add(this.label16);
            this.gb_GuarantorInformation.Controls.Add(this.label17);
            this.gb_GuarantorInformation.Controls.Add(this.label18);
            this.gb_GuarantorInformation.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_GuarantorInformation.Location = new System.Drawing.Point(15, 10);
            this.gb_GuarantorInformation.Name = "gb_GuarantorInformation";
            this.gb_GuarantorInformation.Size = new System.Drawing.Size(567, 250);
            this.gb_GuarantorInformation.TabIndex = 18;
            this.gb_GuarantorInformation.TabStop = false;
            this.gb_GuarantorInformation.Text = "Guarantor Information";
            // 
            // guarantorBirthDate
            // 
            this.guarantorBirthDate.Location = new System.Drawing.Point(20, 145);
            this.guarantorBirthDate.Name = "guarantorBirthDate";
            this.guarantorBirthDate.Size = new System.Drawing.Size(160, 21);
            this.guarantorBirthDate.TabIndex = 33;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(15, 120);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(61, 14);
            this.label25.TabIndex = 32;
            this.label25.Text = "Birth Date";
            // 
            // txtb_GuarantorAddress
            // 
            this.txtb_GuarantorAddress.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_GuarantorAddress.Location = new System.Drawing.Point(18, 212);
            this.txtb_GuarantorAddress.Name = "txtb_GuarantorAddress";
            this.txtb_GuarantorAddress.Size = new System.Drawing.Size(533, 21);
            this.txtb_GuarantorAddress.TabIndex = 29;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(15, 186);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 14);
            this.label21.TabIndex = 26;
            this.label21.Text = "Address";
            // 
            // txtb_GuarantorEmail
            // 
            this.txtb_GuarantorEmail.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_GuarantorEmail.Location = new System.Drawing.Point(204, 145);
            this.txtb_GuarantorEmail.Name = "txtb_GuarantorEmail";
            this.txtb_GuarantorEmail.Size = new System.Drawing.Size(160, 21);
            this.txtb_GuarantorEmail.TabIndex = 25;
            // 
            // cmb_GuarantorName
            // 
            this.cmb_GuarantorName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_GuarantorName.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_GuarantorName.FormattingEnabled = true;
            this.cmb_GuarantorName.Location = new System.Drawing.Point(18, 81);
            this.cmb_GuarantorName.Name = "cmb_GuarantorName";
            this.cmb_GuarantorName.Size = new System.Drawing.Size(533, 22);
            this.cmb_GuarantorName.TabIndex = 24;
            this.cmb_GuarantorName.SelectedIndexChanged += new System.EventHandler(this.cmb_GuarantorName_SelectedIndexChanged);
            // 
            // lblGuarantorType
            // 
            this.lblGuarantorType.AutoSize = true;
            this.lblGuarantorType.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblGuarantorType.Location = new System.Drawing.Point(427, 28);
            this.lblGuarantorType.Name = "lblGuarantorType";
            this.lblGuarantorType.Size = new System.Drawing.Size(14, 14);
            this.lblGuarantorType.TabIndex = 23;
            this.lblGuarantorType.Text = "0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(318, 28);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(94, 14);
            this.label20.TabIndex = 22;
            this.label20.Text = "Guarantor Type:";
            // 
            // txtb_GuarantorPhone
            // 
            this.txtb_GuarantorPhone.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_GuarantorPhone.Location = new System.Drawing.Point(391, 145);
            this.txtb_GuarantorPhone.Name = "txtb_GuarantorPhone";
            this.txtb_GuarantorPhone.Size = new System.Drawing.Size(160, 21);
            this.txtb_GuarantorPhone.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 14);
            this.label8.TabIndex = 20;
            this.label8.Text = "Name";
            // 
            // lblGuarantorID
            // 
            this.lblGuarantorID.AutoSize = true;
            this.lblGuarantorID.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblGuarantorID.Location = new System.Drawing.Point(109, 28);
            this.lblGuarantorID.Name = "lblGuarantorID";
            this.lblGuarantorID.Size = new System.Drawing.Size(14, 14);
            this.lblGuarantorID.TabIndex = 19;
            this.lblGuarantorID.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(388, 120);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 14);
            this.label16.TabIndex = 18;
            this.label16.Text = "Phone";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(201, 120);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(36, 14);
            this.label17.TabIndex = 15;
            this.label17.Text = "Email";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(15, 28);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(79, 14);
            this.label18.TabIndex = 13;
            this.label18.Text = "Guarantor ID:";
            // 
            // LoanAmortization
            // 
            this.LoanAmortization.Controls.Add(this.cmb_OfficerName);
            this.LoanAmortization.Controls.Add(this.label36);
            this.LoanAmortization.Controls.Add(this.guna2GroupBox1);
            this.LoanAmortization.Controls.Add(this.amortizationDataGridView);
            this.LoanAmortization.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoanAmortization.Location = new System.Drawing.Point(184, 4);
            this.LoanAmortization.Name = "LoanAmortization";
            this.LoanAmortization.Size = new System.Drawing.Size(597, 451);
            this.LoanAmortization.TabIndex = 6;
            this.LoanAmortization.Text = "Loan Amortization";
            this.LoanAmortization.UseVisualStyleBackColor = true;
            // 
            // cmb_OfficerName
            // 
            this.cmb_OfficerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_OfficerName.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_OfficerName.FormattingEnabled = true;
            this.cmb_OfficerName.Location = new System.Drawing.Point(354, 421);
            this.cmb_OfficerName.Name = "cmb_OfficerName";
            this.cmb_OfficerName.Size = new System.Drawing.Size(230, 22);
            this.cmb_OfficerName.TabIndex = 30;
            this.cmb_OfficerName.SelectedIndexChanged += new System.EventHandler(this.cmb_OfficerName_SelectedIndexChanged);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(246, 425);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(102, 14);
            this.label36.TabIndex = 23;
            this.label36.Text = "Assigned Officer:";
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.lbl_PayoffDate);
            this.guna2GroupBox1.Controls.Add(this.lbl_ActualAmountReleased);
            this.guna2GroupBox1.Controls.Add(this.lbl_TotalLoanPayments);
            this.guna2GroupBox1.Controls.Add(this.label33);
            this.guna2GroupBox1.Controls.Add(this.label34);
            this.guna2GroupBox1.Controls.Add(this.label35);
            this.guna2GroupBox1.Controls.Add(this.lbl_TotalDeduction);
            this.guna2GroupBox1.Controls.Add(this.lbl_TotalInterest);
            this.guna2GroupBox1.Controls.Add(this.lbl_AmountApplied);
            this.guna2GroupBox1.Controls.Add(this.label27);
            this.guna2GroupBox1.Controls.Add(this.label19);
            this.guna2GroupBox1.Controls.Add(this.label15);
            this.guna2GroupBox1.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(14, 12);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(570, 165);
            this.guna2GroupBox1.TabIndex = 8;
            this.guna2GroupBox1.Text = "Loan Breakdown";
            // 
            // lbl_PayoffDate
            // 
            this.lbl_PayoffDate.AutoSize = true;
            this.lbl_PayoffDate.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbl_PayoffDate.Location = new System.Drawing.Point(469, 132);
            this.lbl_PayoffDate.Name = "lbl_PayoffDate";
            this.lbl_PayoffDate.Size = new System.Drawing.Size(14, 14);
            this.lbl_PayoffDate.TabIndex = 33;
            this.lbl_PayoffDate.Text = "0";
            // 
            // lbl_ActualAmountReleased
            // 
            this.lbl_ActualAmountReleased.AutoSize = true;
            this.lbl_ActualAmountReleased.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbl_ActualAmountReleased.Location = new System.Drawing.Point(469, 92);
            this.lbl_ActualAmountReleased.Name = "lbl_ActualAmountReleased";
            this.lbl_ActualAmountReleased.Size = new System.Drawing.Size(14, 14);
            this.lbl_ActualAmountReleased.TabIndex = 32;
            this.lbl_ActualAmountReleased.Text = "0";
            // 
            // lbl_TotalLoanPayments
            // 
            this.lbl_TotalLoanPayments.AutoSize = true;
            this.lbl_TotalLoanPayments.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbl_TotalLoanPayments.Location = new System.Drawing.Point(469, 49);
            this.lbl_TotalLoanPayments.Name = "lbl_TotalLoanPayments";
            this.lbl_TotalLoanPayments.Size = new System.Drawing.Size(14, 14);
            this.lbl_TotalLoanPayments.TabIndex = 31;
            this.lbl_TotalLoanPayments.Text = "0";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(306, 49);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(118, 14);
            this.label33.TabIndex = 30;
            this.label33.Text = "Total Loan Payments";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(306, 132);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(69, 14);
            this.label34.TabIndex = 29;
            this.label34.Text = "Payoff Date";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(306, 92);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(103, 14);
            this.label35.TabIndex = 28;
            this.label35.Text = "Amount Released";
            // 
            // lbl_TotalDeduction
            // 
            this.lbl_TotalDeduction.AutoSize = true;
            this.lbl_TotalDeduction.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbl_TotalDeduction.Location = new System.Drawing.Point(181, 132);
            this.lbl_TotalDeduction.Name = "lbl_TotalDeduction";
            this.lbl_TotalDeduction.Size = new System.Drawing.Size(14, 14);
            this.lbl_TotalDeduction.TabIndex = 27;
            this.lbl_TotalDeduction.Text = "0";
            // 
            // lbl_TotalInterest
            // 
            this.lbl_TotalInterest.AutoSize = true;
            this.lbl_TotalInterest.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbl_TotalInterest.Location = new System.Drawing.Point(181, 92);
            this.lbl_TotalInterest.Name = "lbl_TotalInterest";
            this.lbl_TotalInterest.Size = new System.Drawing.Size(14, 14);
            this.lbl_TotalInterest.TabIndex = 26;
            this.lbl_TotalInterest.Text = "0";
            // 
            // lbl_AmountApplied
            // 
            this.lbl_AmountApplied.AutoSize = true;
            this.lbl_AmountApplied.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbl_AmountApplied.Location = new System.Drawing.Point(181, 49);
            this.lbl_AmountApplied.Name = "lbl_AmountApplied";
            this.lbl_AmountApplied.Size = new System.Drawing.Size(14, 14);
            this.lbl_AmountApplied.TabIndex = 25;
            this.lbl_AmountApplied.Text = "0";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(18, 49);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(95, 14);
            this.label27.TabIndex = 24;
            this.label27.Text = "Amount Applied";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(18, 132);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(112, 14);
            this.label19.TabIndex = 22;
            this.label19.Text = "Total Interest + Fee";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(18, 92);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 14);
            this.label15.TabIndex = 21;
            this.label15.Text = "Total Interest";
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
            this.paymentNumberDataGridViewTextBoxColumn,
            this.PaymentDate,
            this.paymentAmountDataGridViewTextBoxColumn,
            this.principalDataGridViewTextBoxColumn,
            this.interestDataGridViewTextBoxColumn,
            this.remainingBalanceDataGridViewTextBoxColumn});
            this.amortizationDataGridView.DataSource = this.loanAmortizationBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.amortizationDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.amortizationDataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.amortizationDataGridView.Location = new System.Drawing.Point(14, 194);
            this.amortizationDataGridView.Name = "amortizationDataGridView";
            this.amortizationDataGridView.ReadOnly = true;
            this.amortizationDataGridView.RowHeadersVisible = false;
            this.amortizationDataGridView.RowTemplate.Height = 40;
            this.amortizationDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.amortizationDataGridView.Size = new System.Drawing.Size(570, 217);
            this.amortizationDataGridView.TabIndex = 7;
            // 
            // paymentNumberDataGridViewTextBoxColumn
            // 
            this.paymentNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.paymentNumberDataGridViewTextBoxColumn.DataPropertyName = "PaymentNumber";
            this.paymentNumberDataGridViewTextBoxColumn.HeaderText = "Payment No.";
            this.paymentNumberDataGridViewTextBoxColumn.Name = "paymentNumberDataGridViewTextBoxColumn";
            this.paymentNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // PaymentDate
            // 
            this.PaymentDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PaymentDate.DataPropertyName = "PaymentDate";
            this.PaymentDate.HeaderText = "Payment Date";
            this.PaymentDate.Name = "PaymentDate";
            this.PaymentDate.ReadOnly = true;
            // 
            // paymentAmountDataGridViewTextBoxColumn
            // 
            this.paymentAmountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.paymentAmountDataGridViewTextBoxColumn.DataPropertyName = "PaymentAmount";
            this.paymentAmountDataGridViewTextBoxColumn.HeaderText = "Payment Amount";
            this.paymentAmountDataGridViewTextBoxColumn.Name = "paymentAmountDataGridViewTextBoxColumn";
            this.paymentAmountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // principalDataGridViewTextBoxColumn
            // 
            this.principalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.principalDataGridViewTextBoxColumn.DataPropertyName = "Principal";
            this.principalDataGridViewTextBoxColumn.HeaderText = "Principal";
            this.principalDataGridViewTextBoxColumn.Name = "principalDataGridViewTextBoxColumn";
            this.principalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // interestDataGridViewTextBoxColumn
            // 
            this.interestDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.interestDataGridViewTextBoxColumn.DataPropertyName = "Interest";
            this.interestDataGridViewTextBoxColumn.HeaderText = "Interest";
            this.interestDataGridViewTextBoxColumn.Name = "interestDataGridViewTextBoxColumn";
            this.interestDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // remainingBalanceDataGridViewTextBoxColumn
            // 
            this.remainingBalanceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.remainingBalanceDataGridViewTextBoxColumn.DataPropertyName = "RemainingBalance";
            this.remainingBalanceDataGridViewTextBoxColumn.HeaderText = "Remaining Balance";
            this.remainingBalanceDataGridViewTextBoxColumn.Name = "remainingBalanceDataGridViewTextBoxColumn";
            this.remainingBalanceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // loanAmortizationBindingSource
            // 
            this.loanAmortizationBindingSource.DataSource = typeof(LoanManagementSystem.Models.LoanAmortization);
            // 
            // LoanPlot
            // 
            this.LoanPlot.Controls.Add(this.pnlChartContainer);
            this.LoanPlot.Location = new System.Drawing.Point(184, 4);
            this.LoanPlot.Name = "LoanPlot";
            this.LoanPlot.Size = new System.Drawing.Size(597, 451);
            this.LoanPlot.TabIndex = 7;
            this.LoanPlot.Text = "Loan Plot";
            this.LoanPlot.UseVisualStyleBackColor = true;
            // 
            // pnlChartContainer
            // 
            this.pnlChartContainer.BackColor = System.Drawing.Color.White;
            this.pnlChartContainer.Location = new System.Drawing.Point(3, 3);
            this.pnlChartContainer.Name = "pnlChartContainer";
            this.pnlChartContainer.Size = new System.Drawing.Size(591, 445);
            this.pnlChartContainer.TabIndex = 0;
            // 
            // frmLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLoans";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.loanProcessTabControl.ResumeLayout(false);
            this.ClientLoanInformation.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.GuarantorCollateralInformation.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.gb_GuarantorInformation.ResumeLayout(false);
            this.gb_GuarantorInformation.PerformLayout();
            this.LoanAmortization.ResumeLayout(false);
            this.LoanAmortization.PerformLayout();
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amortizationDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loanAmortizationBindingSource)).EndInit();
            this.LoanPlot.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlContainer;
        private Guna.UI2.WinForms.Guna2Button btn_Close;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TabControl loanProcessTabControl;
        private System.Windows.Forms.TabPage GuarantorCollateralInformation;
        private System.Windows.Forms.TabPage ClientLoanInformation;
        public Guna.UI2.WinForms.Guna2Button btn_Compute;
        public Guna.UI2.WinForms.Guna2Button btn_Submit;
        private System.Windows.Forms.TabPage LoanAmortization;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtb_OthersFee;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtb_OriginationFee;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtb_InterestAmount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtb_LoanTerm;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtb_InterestRate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtb_AmountApplied;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_PaymentFrequency;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtb_ClientName;
        public System.Windows.Forms.ComboBox cmb_LoanType;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox gb_GuarantorInformation;
        public System.Windows.Forms.TextBox txtb_GuarantorPhone;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label lblGuarantorID;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox6;
        public System.Windows.Forms.TextBox txtb_CollateralLocation;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtb_CollateralValue;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        public System.Windows.Forms.TextBox txtb_GuarantorAddress;
        private System.Windows.Forms.Label label21;
        public System.Windows.Forms.TextBox txtb_GuarantorEmail;
        public System.Windows.Forms.ComboBox cmb_GuarantorName;
        public System.Windows.Forms.Label lblGuarantorType;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DateTimePicker guarantorBirthDate;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.BindingSource loanAmortizationBindingSource;
        private System.Windows.Forms.DataGridView amortizationDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn principalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn interestDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remainingBalanceDataGridViewTextBoxColumn;
        public System.Windows.Forms.ComboBox cmb_CollateralType;
        public System.Windows.Forms.ComboBox cmb_OfficerName;
        private System.Windows.Forms.Label label36;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        public System.Windows.Forms.Label lbl_PayoffDate;
        public System.Windows.Forms.Label lbl_ActualAmountReleased;
        public System.Windows.Forms.Label lbl_TotalLoanPayments;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        public System.Windows.Forms.Label lbl_TotalDeduction;
        public System.Windows.Forms.Label lbl_TotalInterest;
        public System.Windows.Forms.Label lbl_AmountApplied;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabPage LoanPlot;
        private System.Windows.Forms.Panel pnlChartContainer;
        public System.Windows.Forms.Label lblClientId;
        public System.Windows.Forms.Label lblApplicationId;
    }
}