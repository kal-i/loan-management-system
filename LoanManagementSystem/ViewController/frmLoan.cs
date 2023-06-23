using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using LoanManagementSystem.Factories;
using LoanManagementSystem.Model;
using LoanManagementSystem.Models;
using LoanManagementSystem.Repositories;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace LoanManagementSystem.ViewController
{
    public partial class frmLoan : Form
    {
        private readonly DBConnection dbConnection;

        LoanProcessUserControl loanProcessUserControl;

        private GuarantorRepository guarantorRepository;
        private List<Guarantor> guarantorList;

        private LoanOfficerRepository officerRepository;
        private List<LoanOfficer> loanOfficerList;

        private LoanApplicationRepository loanApplicationRepository;

        private List<Payment> payments;

        List<OxyColor> pastelColors;

        // public variables that can be accessed by another class to pass the data on these variables
        public int applicationId;

        public int clientId;
        public string fullName;
        public DateTime birthDate;
        public string address;
        public string phone;
        public string email;

        public string employerName;
        public string jobTitle;
        public DateTime employmentStartDate;
        public string employmentStatus;
        public double incomeAmount;
        public string incomeFrequency;

        public double annualIncome;
        public string incomeSource;
        public double expensesAmount;
        public double assetValue;
        public double liabilitiesAmount;
        public int creditScore;

        public int loanTypeId;
        public string loanTypeName;

        public DateTime applicationDate;
        public string status;

        int officerId;
        DateTime officerBirthDate;
        string officerEmail;
        string officerPhone;
        string officerAddress;

        public frmLoan(LoanProcessUserControl loanProcessUserControl)
        {
            InitializeComponent();

            string connectionString = "Server=PAULJOHN\\SQLEXPRESS;Database=DB_LoanManagement;Integrated Security=SSPI";
            dbConnection = new DBConnection(connectionString);

            this.loanProcessUserControl = loanProcessUserControl;

            guarantorRepository = new GuarantorRepository(dbConnection);
            officerRepository = new LoanOfficerRepository(dbConnection);
            loanApplicationRepository = new LoanApplicationRepository(dbConnection);

            lblApplicationId.Visible = false;

            PopulateGuarantorComboBox();
            PopulateCollateralTypeComboBox();
            PopulateOfficerComboBox();

            payments = new List<Payment>();

            // Create a ist pastel colors
            pastelColors = new List<OxyColor>()
            {
                OxyColor.FromRgb(255, 183, 178), // Pastel Pink
                OxyColor.FromRgb(199, 206, 234), // Pastel Violet
                OxyColor.FromRgb(181, 234, 215) // Pastel Green
            };
        }

        private void ClearAllControls(Control control)
        {
            foreach (Control c in  control.Controls)
            {
                if (c is TextBox textBox)
                {
                    textBox.Text = string.Empty;
                }

                if (c is ComboBox comboBox)
                {
                    comboBox.SelectedIndex = 0;
                }

                if (c is DateTimePicker dateTimePicker)
                {
                    dateTimePicker.Value = DateTime.Now;
                }
            }

            lblGuarantorID.Text = string.Empty;
            lblGuarantorType.Text = string.Empty;
        }

        private void PopulateGuarantorComboBox()
        {
            guarantorList = guarantorRepository.GetGuarantors();

            foreach (Guarantor guarantor in guarantorList)
            {
                cmb_GuarantorName.Items.Add($"{guarantor.LastName + " " + guarantor.FirstName + " " + guarantor.MiddleName}");
            }

            cmb_GuarantorName.Items.Insert(0, "-Select Guarantor-");
            cmb_GuarantorName.SelectedIndex = 0;
        }

        private void PopulateCollateralTypeComboBox()
        {
            List<string> collateralTypes = new List<string>()
            {
                "Real State",
                "Vehicle",
                "Savings or Deposits",
                "Securities",
                "Equipment",
                "Accounts Receivable",
                "Inventory"
            };

            foreach (string collateralType in collateralTypes)
            {
                cmb_CollateralType.Items.Add(collateralType);
            }

            cmb_CollateralType.Items.Insert(0, "-Select Collateral Type-");
            cmb_CollateralType.SelectedIndex = 0;
        }

        private void PopulateOfficerComboBox()
        {
            loanOfficerList = officerRepository.GetOfficers();

            foreach (LoanOfficer officer in loanOfficerList)
            {
                cmb_OfficerName.Items.Add($"{officer.LastName + " " + officer.FirstName + " " + officer.MiddleName}");
            }

            cmb_OfficerName.Items.Insert(0, "-Select Officer-");
            cmb_OfficerName.SelectedIndex = 0;
        }

        private void CalculateMonthlyAmortization()
        {
            double principal = Convert.ToDouble(txtb_AmountApplied.Text);
            double interestRate = Convert.ToDouble(txtb_InterestRate.Text) * 0.01; // annual interest
            int numOfPayments = Convert.ToInt32(txtb_LoanTerm.Text);

            // Calculate the monthly payment amount
            double monthlyInterestRate = interestRate / 12; // to convert to monthly interest
            double monthlyPayment = (principal * monthlyInterestRate) /
                (1 - Math.Pow(1 + monthlyInterestRate, -numOfPayments));

            // Create a List to hold the amortization table rows
            List<LoanAmortization> amortizations = new List<LoanAmortization>();

            // Calculate the amortization table rows
            double balance = principal;
            DateTime paymentStartDate = startDateTimePicker.Value.AddMonths(1);
            double totalInterest = 0;

            for (int paymentNumber = 1; paymentNumber <= numOfPayments; paymentNumber++)
            {
                double monthlyInterestAmount = balance * monthlyInterestRate;
                double monthlyPrincipal = monthlyPayment - monthlyInterestAmount;
                balance -= monthlyPrincipal; // Deduct the monthly payment from balance
                totalInterest += monthlyInterestAmount;

                LoanAmortization row = new LoanAmortization
                {
                    PaymentNumber = paymentNumber,
                    PaymentDate = paymentStartDate.Date,
                    PaymentAmount = Math.Round(monthlyPayment, 2),
                    Principal = Math.Round(monthlyPrincipal, 2),
                    Interest = Math.Round(monthlyInterestAmount, 2),
                    RemainingBalance = Math.Round(balance, 2)
                };

                amortizations.Add(row);

                Payment payment = new Payment
                {
                    PaymentNumber = paymentNumber,
                    PaymentDate = paymentStartDate.Date,
                    PrincipalAmount = Math.Round(monthlyPrincipal, 2),
                    InterestAmount = Math.Round(monthlyInterestAmount, 2),
                    RemainingBalance = Math.Round(balance, 2)
                };

                payments.Add(payment);

                // Move to the next payment date (1 month later)
                paymentStartDate = paymentStartDate.AddMonths(1);
            }

            // Display the total interest
            txtb_InterestAmount.Text = Math.Round(totalInterest, 2).ToString();

            // Calculate the payoff date
            endDateTimePicker.Value = startDateTimePicker.Value.AddMonths(numOfPayments);

            lbl_PayoffDate.Text = endDateTimePicker.Value.ToShortDateString();

            // Display the amortization in a dataGridView
            amortizationDataGridView.DataSource = amortizations;
        }

        private void CalculateAnnualAmortization()
        {
            double principal = Convert.ToDouble(txtb_AmountApplied.Text);
            double interestRate = Convert.ToDouble(txtb_InterestRate.Text) * 0.01; // annual interest
            int numOfPayments = Convert.ToInt32(txtb_LoanTerm.Text);

            // Calculate the annual payment
            double annualPayment = (principal * interestRate) /
                (1 - Math.Pow(1 + interestRate, -numOfPayments));

            // Create a List to hold the amortization table rows
            List<LoanAmortization> amortizations = new List<LoanAmortization>();

            // Calculate the amortization table rows
            double balance = principal;
            DateTime paymentStartDate = startDateTimePicker.Value.AddYears(1);
            double totalInterest = 0;

            // Generate Loan Payment Schedule
            for (int paymentNumber = 1; paymentNumber <= numOfPayments; paymentNumber++)
            {
                double annualInterestAmount = balance * interestRate;
                double annualPrincipal = annualPayment - annualInterestAmount;
                balance -= annualPrincipal;
                totalInterest += annualInterestAmount;

                // Create objects to store the payment details
                LoanAmortization row = new LoanAmortization
                {
                    PaymentNumber = paymentNumber,
                    PaymentDate = paymentStartDate.Date,
                    PaymentAmount = Math.Round(annualPayment, 2),
                    Principal = Math.Round(annualPrincipal, 2),
                    Interest = Math.Round(annualInterestAmount, 2),
                    RemainingBalance = Math.Round(balance, 2)
                };

                amortizations.Add(row);

                Payment payment = new Payment
                {
                    PaymentNumber = paymentNumber,
                    PaymentDate = paymentStartDate.Date,
                    PrincipalAmount = Math.Round(annualPrincipal, 2),
                    InterestAmount = Math.Round(annualInterestAmount, 2),
                    RemainingBalance = Math.Round(balance, 2)
                };

                payments.Add(payment);

                paymentStartDate = paymentStartDate.AddYears(1);
            }

            txtb_InterestAmount.Text = Math.Round(totalInterest, 2).ToString();

            endDateTimePicker.Value = startDateTimePicker.Value.AddYears(numOfPayments);

            lbl_PayoffDate.Text = endDateTimePicker.Value.ToShortDateString();

            amortizationDataGridView.DataSource = amortizations;
        }

        private void DisplayLoanAmortization(ComboBox comboBox)
        {

            if (comboBox.Text == "Monthly")
            {
                CalculateMonthlyAmortization();
            }

            if (comboBox.Text == "Annually")
            {
                CalculateAnnualAmortization();
            }
        }

        private double GetAmountApplied()
        {
            return string.IsNullOrEmpty(txtb_AmountApplied.Text) ? 0 : Convert.ToDouble(txtb_AmountApplied.Text);
        }

        private double GetInterestAmount()
        {
            return string.IsNullOrEmpty(txtb_InterestAmount.Text) ? 0 : Convert.ToDouble(txtb_InterestAmount.Text);
        }

        private double CalculateFees()
        {
            double originationFee = string.IsNullOrEmpty(txtb_OriginationFee.Text) ? 0 : Convert.ToDouble(txtb_OriginationFee.Text);
            double othersFee = string.IsNullOrEmpty(txtb_OthersFee.Text) ? 0 : Convert.ToDouble(txtb_OthersFee.Text);

            return originationFee + othersFee;
        }

        private double CalculateTotalInterestAndFee()
        {
            double interestAmount = GetInterestAmount();
            double fees = CalculateFees();

            return interestAmount + fees;
        }

        private double CalculateTotalLoanPayments()
        {
            double amountApplied = GetAmountApplied();
            double totalDeduction = CalculateTotalInterestAndFee();

            return amountApplied + totalDeduction;
        }

        private void DisplayLoanBreakdown()
        {
            // Get the loan info and store them in variables
            double amountApplied = GetAmountApplied();
            double interestAmount = GetInterestAmount();
            double totalDeduction = CalculateTotalInterestAndFee();
            double totalLoanPayments = CalculateTotalLoanPayments();
            double amountReleased = GetAmountApplied() - CalculateFees();

            // convert those vars' to formatted string and assign to each to a label 
            lbl_AmountApplied.Text = amountApplied.ToString("C2", new CultureInfo("en-US"));
            lbl_TotalInterest.Text = interestAmount.ToString("C2", new CultureInfo("en-US"));
            lbl_TotalDeduction.Text = totalDeduction.ToString("C2", new CultureInfo("en-US"));
            lbl_TotalLoanPayments.Text = totalLoanPayments.ToString("C2", new CultureInfo("en-US"));
            lbl_ActualAmountReleased.Text = amountReleased.ToString("C2", new CultureInfo("en-US"));
        }

        private void DisplayLoanPlot()
        {
            // Create a PlotView object
            PlotView plot = new PlotView();

            // Define its location
            plot.Parent = pnlChartContainer;
            plot.Dock = DockStyle.Fill;

            // Create a PlotModel object
            PlotModel model = new PlotModel { Title = "Payment Breakdown" };

            // Create a PieSeries object
            PieSeries series = new PieSeries()
            {
                StrokeThickness = 0,
                InsideLabelPosition = 0.8,
                AngleSpan = 360,
                StartAngle = 0
            };

            // Add data points to the series with custom pastel colors
            series.Slices.Add(new PieSlice("Loan Amount", GetAmountApplied())
            {
                Fill = pastelColors[2]
            });

            series.Slices.Add(new PieSlice("Interest Amount", GetInterestAmount())
            {
                Fill = pastelColors[0]
            });

            series.Slices.Add(new PieSlice("Deduction Fee", CalculateFees()) 
            {
                Fill = pastelColors[1]
            });

            // Add the series to the model
            model.Series.Add(series);

            // Set the model to the PlotView object
            plot.Model = model;
        }

        private void UpdateLoanPlot()
        {
            // Retrieve existing PlotView and Model objects
            PlotView plot = pnlChartContainer.Controls.OfType<PlotView>().FirstOrDefault();
            PlotModel model = plot?.Model;

            // Checks if plot and model is not equal to null
            if (plot != null && model != null) 
            {
                model.Series.Clear(); // Then clear the series if true

                // Create a list of updated data points
                List<PieSlice> slices = new List<PieSlice>()
                {
                    new PieSlice("Loan Amount", GetAmountApplied())
                    {
                        Fill = pastelColors[2]
                    },
                    new PieSlice("Interest Amount", GetInterestAmount())
                    {
                        Fill = pastelColors[0]
                    },
                    new PieSlice("Deduction Fee", CalculateFees())
                    {
                        Fill = pastelColors[1]
                    }
                };

                // Create a new PieSeries object with the updated data
                PieSeries series = new PieSeries()
                {
                    StrokeThickness = 0,
                    InsideLabelPosition = 0.8,
                    AngleSpan = 360,
                    StartAngle = 0,
                    Slices = slices
                };

                // Add the updated series to the model
                model.Series.Add(series);

                // Refresh the PlotView by setting the updated model
                plot.Model = model;
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close this window?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_Compute_Click(object sender, EventArgs e)
        {
            if (txtb_AmountApplied.Text == "" || txtb_InterestRate.Text == "" || txtb_LoanTerm.Text == "")
            {
                MessageBox.Show("Loan Term & Interest Information cannot be null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 

            if (cmb_PaymentFrequency.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a payment frequency to compute your loan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DisplayLoanAmortization(cmb_PaymentFrequency);
            DisplayLoanBreakdown();
            DisplayLoanPlot();
        }

        private void cmb_GuarantorName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_GuarantorName.SelectedIndex == 0) 
            {
                ClearAllControls(gb_GuarantorInformation);
            }

            guarantorList = guarantorRepository.GetFilteredGuarantors(cmb_GuarantorName.Text);

            foreach (Guarantor guarantor in guarantorList)
            {
                lblGuarantorID.Text = guarantor.ID.ToString();
                lblGuarantorType.Text = guarantor.GuarantorType;
                guarantorBirthDate.Value = guarantor.BirthDate;
                txtb_GuarantorAddress.Text = guarantor.Address;
                txtb_GuarantorEmail.Text = guarantor.Email;
                txtb_GuarantorPhone.Text = guarantor.Phone;
            }
        }

        private void loanProcessTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loanProcessTabControl.SelectedIndex == 2)
            {
                amortizationDataGridView.ClearSelection();
            }

            if (loanProcessTabControl.SelectedIndex == 3)
            {
                UpdateLoanPlot();
            }
        }

        private void cmb_OfficerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_OfficerName.SelectedIndex == 0)
            {
                officerId = 0;
                officerBirthDate = DateTime.MinValue;
                officerEmail = "";
                officerPhone = "";
                officerAddress = "";
            }

            loanOfficerList = officerRepository.GetFilteredOfficers(cmb_OfficerName.Text);

            foreach (LoanOfficer officer in loanOfficerList)
            {
                officerId = officer.ID;
                officerBirthDate = officer.BirthDate;
                officerEmail = officer.Email;
                officerPhone = officer.Phone;
                officerAddress = officer.Address;
            }
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (txtb_AmountApplied.Text == "" || txtb_InterestRate.Text == "" || txtb_LoanTerm.Text == "")
            {
                MessageBox.Show("Loan Term & Interest Information cannot be null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmb_GuarantorName.SelectedIndex == 0|| cmb_CollateralType.SelectedIndex == 0 || cmb_OfficerName.SelectedIndex == 0)
            {
                MessageBox.Show("Please fill the following information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return;
            }

            if (MessageBox.Show("Are you sure you want to approve this loan?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string loanStatus = "Approved";

                // Create objects for the following models
                LoanApplicationFactory factory = null;

                if (cmb_LoanType.Text == "Personal Loan")
                {
                    factory = new PersonalLoanApplicationFactory();
                }

                else if (cmb_LoanType.Text == "Mortgage Loan")
                {
                    factory = new MortgageLoanApplicationFactory();
                }

                else if (cmb_LoanType.Text == "Auto Loan")
                {
                    factory = new AutoLoanApplicationFactory();
                }

                else if (cmb_LoanType.Text == "Student Loan")
                {
                    factory = new StudentLoanApplicationFactory();
                }

                else if (cmb_LoanType.Text == "Small Business Loan")
                {
                    factory = new SmallBusinessLoanApplicationFactory();
                }

                if (factory != null)
                {
                    Client applicant = new Client(clientId, fullName, birthDate, address, phone, email, employerName, jobTitle, employmentStartDate, employmentStatus, incomeAmount, incomeFrequency, annualIncome, incomeSource, expensesAmount, assetValue, liabilitiesAmount, creditScore);
                    LoanType loanType = new LoanType(loanTypeId, loanTypeName);
                    Guarantor guarantor = new Guarantor(Convert.ToInt32(lblGuarantorID.Text), lblGuarantorType.Text, cmb_GuarantorName.Text, guarantorBirthDate.Value, txtb_GuarantorAddress.Text, txtb_GuarantorPhone.Text, txtb_GuarantorEmail.Text);
                    Collateral collateral = new Collateral(cmb_CollateralType.Text, Convert.ToDouble(txtb_CollateralValue.Text), txtb_CollateralLocation.Text);
                    LoanOfficer loanOfficer = new LoanOfficer(officerId, cmb_OfficerName.Text, officerBirthDate, officerAddress, officerPhone, officerEmail);
                    Loan loan = new Loan(applicant, loanType, GetAmountApplied(), Convert.ToDouble(txtb_InterestRate.Text), Convert.ToInt32(txtb_LoanTerm.Text), startDateTimePicker.Value, endDateTimePicker.Value, loanStatus, cmb_PaymentFrequency.Text, guarantor, loanOfficer);

                    LoanApplication loanApplication = factory.CreateLoanApplication();
                    loanApplication.ApplicationId =applicationId;

                    loanApplicationRepository.ApproveLoanProcess(loanApplication, loan, payments, collateral);
                }

                loanProcessUserControl.DisplayPendingLoanApplications();
                loanProcessUserControl.DisplayApprovedLoans();
                this.Close();
            }
        }
    }
}