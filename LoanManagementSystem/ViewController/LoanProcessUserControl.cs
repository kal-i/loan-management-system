using LoanManagementSystem.Factories;
using LoanManagementSystem.Model;
using LoanManagementSystem.Repositories;
using LoanManagementSystem.ViewController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Font = iTextSharp.text.Font;
using Image = iTextSharp.text.Image;
using LoanManagementSystem.Models;

namespace LoanManagementSystem
{
    public partial class LoanProcessUserControl : UserControl
    {
        private readonly DBConnection dbConnection;

        private ClientRepository clientRepository;
        private List<Client> clientList;

        private LoanApplicationRepository applicationRepository;

        private GuarantorRepository guarantorRepository;
        private List<Guarantor> guarantorList;

        private LoanTypeRepository loanTypeRepository;
        private List<LoanType> loanTypeList;

        int loan_type_id;

        private LoanApplicationRepository loanApplicationRepository;
        private List<LoanApplication> loanApplicationList;

        private LoanRepository loanRepository;
        private List<Loan> loanList;

        private LoanApplicationFactory factory;
        private LoanApplication loanApplication;

        private PaymentRepository paymentRepository;
        private List<Payment> payments;

        public LoanProcessUserControl()
        {
            InitializeComponent();

            string connectionString = "Server=PAULJOHN\\SQLEXPRESS;Database=DB_LoanManagement;Integrated Security=SSPI";
            dbConnection = new DBConnection(connectionString);

            clientRepository = new ClientRepository(dbConnection);
            guarantorRepository = new GuarantorRepository(dbConnection);
            loanTypeRepository = new LoanTypeRepository(dbConnection);
            applicationRepository = new LoanApplicationRepository(dbConnection);
            loanApplicationRepository = new LoanApplicationRepository(dbConnection);
            loanRepository = new LoanRepository(dbConnection);
            paymentRepository = new PaymentRepository(dbConnection);
          
            PopulateLoanStatus();
            PopulateClientComboBox();
            PopulateEmploymentStatus();
            PopulateIncomeFrequency();
            PopulateIncomeSource();
            PopulateLoanTypeComboBox();

            DisplayApprovedLoans();
            DisplayPendingLoanApplications();
            DisplayDeniedApplications();
        }

        private void Clear(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox textBox)
                {
                    textBox.Text = string.Empty;
                }

                if (c is DateTimePicker dateTimePicker)
                {
                    dateTimePicker.Value = DateTime.Now;
                }

                // For instance, our parent container is pnlContainer then all the children of that container will be clear recursively
                if (c.HasChildren)
                {
                    Clear(c);
                }
            }

            lblClientID.Text = string.Empty;

            // Each combo box's selected index is set to 0 if there are items in the list, otherwise set to -1 to indicate no selection
            cmb_ClientFullName.SelectedIndex = cmb_ClientFullName.Items.Count > 0 ? 0 : -1;
            cmb_EmploymentStatus.SelectedIndex = cmb_EmploymentStatus.Items.Count > 0 ? 0 : -1;
            cmb_IncomeFrequency.SelectedIndex = cmb_IncomeFrequency.Items.Count > 0 ? 0 : -1;
            cmb_IncomeSource.SelectedIndex = cmb_IncomeSource.Items.Count > 0 ? 0 : -1;
            cmb_LoanType.SelectedIndex = cmb_LoanType.Items.Count > 0 ? 0 : -1;
        }

        private void PopulateLoanStatus()
        {
            List<string> loanStatusList = new List<string>()
            {
                "Pending",
                "Approved",
                "Denied",
                "Active",
                "Settled"
            };

            foreach (string loanStatus in loanStatusList)
            {
                cmb_Status.Items.Add(loanStatus);
            }

            cmb_Status.SelectedIndex = 0;
        }

        private void PopulateClientComboBox()
        {
            clientList = clientRepository.GetClients();

            foreach (Client client in clientList)
            {
                cmb_ClientFullName.Items.Add($"{client.LastName + " " +  client.FirstName + " " + client.MiddleName}");
            }

            cmb_ClientFullName.Items.Insert(0, "-Select Client-");
            cmb_ClientFullName.SelectedIndex = 0;
        }

        private void PopulateEmploymentStatus()
        {
            List<string> statusList = new List<string>()
            {
                "Full-time",
                "Part-time",
                "Self-employment",
                "Freelance or contract work",
                "Seasonal employment",
                "Unemployment"
            };

            foreach (string status in statusList)
            {
                cmb_EmploymentStatus.Items.Add(status);
            }

            cmb_EmploymentStatus.Items.Insert(0, "-Select Employment Status-");
            cmb_EmploymentStatus.SelectedIndex = 0;
        }

        private void PopulateIncomeFrequency()
        {
            List<string> incomeFrequencies = new List<string>()
            {
                "Monthly",
                "Bi-Monthly",
                "Bi-Weekly",
                "Weekly",
                "Quarterly",
                "Annual"
            };

            foreach (string incomeFrequency in  incomeFrequencies)
            {
                cmb_IncomeFrequency.Items.Add(incomeFrequency);
            }

            cmb_IncomeFrequency.Items.Insert(0, "-Select Income Frequency-");
            cmb_IncomeFrequency.SelectedIndex = 0;
        }

        private void PopulateIncomeSource()
        {
            List<string> sources = new List<string>()
            {
                "Employment income",
                "Self-employment income",
                "Rental income",
                "Investment income",
                "Retirement income",
                "Spousal or partner income"
            };

            foreach (string source in sources)
            {
                cmb_IncomeSource.Items.Add(source);
            }

            cmb_IncomeSource.Items.Insert(0, "-Select Income Source-");
            cmb_IncomeSource.SelectedIndex = 0;
        }

        private void PopulateLoanTypeComboBox()
        {
            loanTypeList = loanTypeRepository.GetLoanTypes();

            foreach (LoanType loanType in loanTypeList)
            {
                loan_type_id = loanType.LoanTypeId;
                cmb_LoanType.Items.Add(loanType.LoanName);
            }

            // To set the default value of combo box
            cmb_LoanType.Items.Insert(0, "-Select Loan Type-");
            cmb_LoanType.SelectedIndex = 0;
        }

        // Populate Client Information Based On The Combo Box Selected
        private void cmb_ClientFullName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_ClientFullName.SelectedIndex == 0)
            {
                Clear(pnlApplicationContainer);
            }

            clientList = clientRepository.GetFilteredClients(cmb_ClientFullName.Text);

            foreach (Client client in clientList)
            {
                lblClientID.Text = client.ID.ToString();
                clientDateOfBirthPicker.Value = client.BirthDate;
                txtb_ClientAddress.Text = client.Address;
                txtb_ClientEmail.Text = client.Email;
                txtb_ClientPhone.Text = client.Phone;
                txtb_EmployerName.Text = client.EmployerName;
                txtb_JobTitle.Text = client.JobTitle;
                employeeStartDateTimePicker.Value = client.EmploymentStartDate;
                cmb_EmploymentStatus.Text = client.EmploymentStatus;
                txtb_IncomeAmount.Text = client.IncomeAmount.ToString();
                cmb_IncomeFrequency.Text = client.IncomeFrequency;
                txtb_AnnualIncome.Text = client.AnnualIncome.ToString();
                cmb_IncomeSource.Text = client.IncomeSource;
                txtb_ExpensesAmount.Text = client.ExpensesAmount.ToString();
                txtb_TotalAssets.Text = client.TotalAssets.ToString();
                txtb_TotalLiabilities.Text = client.TotalLiabilities.ToString();
                txtb_CreditScore.Text = client.CreditScore.ToString();
                txtb_CreditHistory.Text = client.CreditHistory;
            }
        }

        private void cmb_LoanType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Status.SelectedIndex == 0)
            {
                loan_type_id = 0;
            }

            loanTypeList = loanTypeRepository.FilteredLoanTypes(cmb_LoanType.Text);

            foreach (LoanType loanType in loanTypeList)
            {
                loan_type_id = loanType.LoanTypeId;
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            Clear(pnlApplicationContainer);
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            // Checks if any of the fields in the condition is empty or has an index of 0, then prompt a message if true. Otherwise, proceed on the next condition.
            if (lblClientID.Text == "" || cmb_LoanType.SelectedIndex == 0 || loan_type_id == 0)
            {
                MessageBox.Show("Fields cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create a Client object that is associated with the loan application
            Client applicant = new Client(Convert.ToInt32(lblClientID.Text), cmb_ClientFullName.Text, clientDateOfBirthPicker.Value, txtb_ClientAddress.Text, txtb_ClientPhone.Text, txtb_ClientEmail.Text, txtb_EmployerName.Text, txtb_JobTitle.Text, employeeStartDateTimePicker.Value, cmb_EmploymentStatus.Text, Convert.ToDouble(txtb_IncomeAmount.Text), cmb_IncomeFrequency.Text, Convert.ToDouble(txtb_AnnualIncome.Text), cmb_IncomeSource.Text, Convert.ToDouble(txtb_ExpensesAmount.Text), Convert.ToDouble(txtb_TotalAssets.Text), Convert.ToDouble(txtb_TotalLiabilities.Text), Convert.ToInt32(txtb_CreditScore.Text));
            LoanType loanType = new LoanType(loan_type_id, cmb_LoanType.Text);

            // The factory determines which subclass to instantiate based on the loan type selected
            factory = null;

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
                loanApplication = factory.CreateLoanApplication();
                loanApplication.Client = applicant;
                loanApplication.LoanType = loanType;
                loanApplication.Status = cmb_Status.Text;
                loanApplication.ApplicationDate = applicationDateTimePicker.Value;

                if (loanApplicationRepository.CheckIfExist(loanApplication))
                {
                    MessageBox.Show("Record has a pending application or an existing loan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    loanApplication.ProcessApplication();

                    // Insert loan application to the database table
                    applicationRepository.Insert(loanApplication);
                }
            }

            Clear(pnlApplicationContainer);
            DisplayPendingLoanApplications();
        }

        // ---------------------------------------------------------- End of Application Process ----------------------------------------------------------

        public void DisplayPendingLoanApplications()
        {
            // Fetches the applicants data by invoking GetLoanApplications() method from LoanApplicationRepository
            loanApplicationList = loanApplicationRepository.GetPendingLoanApplications();

            // Set the DataSource property of the applicationDataGridView
            applicationDataGridView.DataSource = loanApplicationList;

            // To hide columns of dataGridView
            applicationDataGridView.Columns[1].Visible = false;
            applicationDataGridView.Columns[3].Visible = false;
            applicationDataGridView.Columns[4].Visible = false;
            applicationDataGridView.Columns[5].Visible = false;
            applicationDataGridView.Columns[6].Visible = false;
            applicationDataGridView.Columns[7].Visible = false;
            applicationDataGridView.Columns[8].Visible = false;
            applicationDataGridView.Columns[9].Visible = false;
            applicationDataGridView.Columns[10].Visible = false;
            applicationDataGridView.Columns[11].Visible = false;
            applicationDataGridView.Columns[12].Visible = false;
            applicationDataGridView.Columns[13].Visible = false;
            applicationDataGridView.Columns[14].Visible = false;
            applicationDataGridView.Columns[15].Visible = false;
            applicationDataGridView.Columns[16].Visible = false;
            applicationDataGridView.Columns[17].Visible = false;
            applicationDataGridView.Columns[18].Visible = false;
            applicationDataGridView.Columns[19].Visible = false;

            applicationDataGridView.ClearSelection();
        }

        private void applicationDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = applicationDataGridView.Columns[e.ColumnIndex].Name; // Get col name

                object applicationId = applicationDataGridView.Rows[e.RowIndex].Cells[0].Value; 
                object clientId = applicationDataGridView.Rows[e.RowIndex].Cells[1].Value;
                object fullName = applicationDataGridView.Rows[e.RowIndex].Cells[2].Value; 
                object birthDate = applicationDataGridView.Rows[e.RowIndex].Cells[3].Value;
                object address = applicationDataGridView.Rows[e.RowIndex].Cells[4].Value;
                object phone = applicationDataGridView.Rows[e.RowIndex].Cells[5].Value;
                object email = applicationDataGridView.Rows[e.RowIndex].Cells[6].Value;
                object employerName = applicationDataGridView.Rows[e.RowIndex].Cells[7].Value;
                object jobTitle = applicationDataGridView.Rows[e.RowIndex].Cells[8].Value;
                object employmentStartDate = applicationDataGridView.Rows[e.RowIndex].Cells[9].Value;
                object employmentStatus = applicationDataGridView.Rows[e.RowIndex].Cells[10].Value;
                object incomeAmount = applicationDataGridView.Rows[e.RowIndex].Cells[11].Value;
                object incomeFrequency = applicationDataGridView.Rows[e.RowIndex].Cells[12].Value;
                object annualIncome = applicationDataGridView.Rows[e.RowIndex].Cells[13].Value;
                object incomeSource = applicationDataGridView.Rows[e.RowIndex].Cells[14].Value;
                object expensesAmount = applicationDataGridView.Rows[e.RowIndex].Cells[15].Value;
                object assetValue = applicationDataGridView.Rows[e.RowIndex].Cells[16].Value;
                object liabilitiesAmount = applicationDataGridView.Rows[e.RowIndex].Cells[17].Value;
                object creditScore = applicationDataGridView.Rows[e.RowIndex].Cells[18].Value;

                object loanTypeId = applicationDataGridView.Rows[e.RowIndex].Cells[19].Value;
                object loanTypeName = applicationDataGridView.Rows[e.RowIndex].Cells[20].Value;

                object applicationDate = applicationDataGridView.Rows[e.RowIndex].Cells[21].Value;
                object status = applicationDataGridView.Rows[e.RowIndex].Cells[22].Value;

                if (colName.Equals("View"))
                {
                    DataGridViewRow row = applicationDataGridView.Rows[e.RowIndex]; // Get the row

                    // Define the base file path where the PDF file will be saved
                    string basePath = "C:\\Users\\paulm\\Documents\\Records\\PendingLoans\\ApplicationForm";
                    string extension = ".pdf";

                    // Generate a unique file path
                    string outputPath = GenerateUniqueFilePath(basePath, extension);

                    // Generate the PDF
                    GeneratePDF(row, outputPath);
                }

                if (colName.Equals("columnApprove"))
                {
                    if (MessageBox.Show("Do you want to approve this loan application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        frmLoan _frmLoan = new frmLoan(this);
                        _frmLoan.lblApplicationId.Text = applicationId.ToString();
                        _frmLoan.lblClientId.Text = clientId.ToString();
                        _frmLoan.txtb_ClientName.Text = fullName.ToString();
                        _frmLoan.cmb_LoanType.Text = loanTypeName.ToString();

                        // Pass Client information
                        _frmLoan.applicationId = Convert.ToInt32(applicationId);

                        _frmLoan.clientId = Convert.ToInt32(clientId);
                        _frmLoan.fullName = fullName.ToString();
                        _frmLoan.birthDate = Convert.ToDateTime(birthDate);
                        _frmLoan.phone = phone.ToString();
                        _frmLoan.email = email.ToString();
                        _frmLoan.address = address.ToString();

                        _frmLoan.employerName = employerName.ToString();
                        _frmLoan.jobTitle = jobTitle.ToString();
                        _frmLoan.employmentStartDate = Convert.ToDateTime(employmentStartDate);
                        _frmLoan.employmentStatus = employmentStatus.ToString();
                        _frmLoan.incomeAmount = Convert.ToDouble(incomeAmount);
                        _frmLoan.incomeFrequency = incomeFrequency.ToString();

                        _frmLoan.annualIncome = Convert.ToDouble(annualIncome);
                        _frmLoan.incomeSource = incomeSource.ToString();
                        _frmLoan.expensesAmount = Convert.ToDouble(expensesAmount);
                        _frmLoan.assetValue = Convert.ToDouble(assetValue);
                        _frmLoan.liabilitiesAmount = Convert.ToDouble(liabilitiesAmount);
                        _frmLoan.creditScore = Convert.ToInt32(creditScore);

                        _frmLoan.loanTypeId = Convert.ToInt32(loanTypeId);
                        _frmLoan.loanTypeName = loanTypeName.ToString();

                        _frmLoan.applicationDate = Convert.ToDateTime(applicationDate);
                        _frmLoan.status = status.ToString();

                        _frmLoan.ShowDialog();
                    }
                }

                if (colName.Equals("columnDeny"))
                {
                    if (MessageBox.Show("Are you sure you want to deny this application form?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (factory != null)
                        {
                            LoanApplication loanApplication = factory.CreateLoanApplication();
                            loanApplication.ApplicationId = Convert.ToInt32(applicationId);

                            loanApplicationRepository.DenyLoanProcess(loanApplication); 
                        }

                        DisplayDeniedApplications();
                    }
                }

                DisplayPendingLoanApplications(); // Update the pendingLoanApplicationsDataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message} \n\n{ex.StackTrace}");
            }
        }

        // ---------------------------------------------------------- End of Pending Application Process ----------------------------------------------------------

        // ---------------------------------------------------------- Start of Approved Loan Tab ------------------------------------------------------------------

        public void DisplayApprovedLoans()
        {
            loanList = loanRepository.GetApprovedLoans();

            approvedLoanDataGridView.DataSource = loanList;

            approvedLoanDataGridView.Columns[1].Visible = false;
            approvedLoanDataGridView.Columns[3].Visible = false;
            approvedLoanDataGridView.Columns[5].Visible = false;
            approvedLoanDataGridView.Columns[6].Visible = false;
            approvedLoanDataGridView.Columns[7].Visible = false;
            approvedLoanDataGridView.Columns[8].Visible = false;
            approvedLoanDataGridView.Columns[9].Visible = false;
            approvedLoanDataGridView.Columns[10].Visible = false;
            approvedLoanDataGridView.Columns[11].Visible = false;
            approvedLoanDataGridView.Columns[12].Visible = false;
            approvedLoanDataGridView.Columns[13].Visible = false;
            approvedLoanDataGridView.Columns[14].Visible = false;
            approvedLoanDataGridView.Columns[15].Visible = false;
            approvedLoanDataGridView.Columns[16].Visible = false;
            approvedLoanDataGridView.Columns[17].Visible = false;
            approvedLoanDataGridView.Columns[18].Visible = false;
            approvedLoanDataGridView.Columns[19].Visible = false;
            approvedLoanDataGridView.Columns[20].Visible = false;
            approvedLoanDataGridView.Columns[26].Visible = false;
            approvedLoanDataGridView.Columns[28].Visible = false;
            approvedLoanDataGridView.Columns[29].Visible = false;
            approvedLoanDataGridView.Columns[30].Visible = false;
            approvedLoanDataGridView.Columns[32].Visible = false;
            approvedLoanDataGridView.Columns[33].Visible = false;
            approvedLoanDataGridView.Columns[34].Visible = false;
            approvedLoanDataGridView.Columns[35].Visible = false;
            approvedLoanDataGridView.Columns[36].Visible = false;

            approvedLoanDataGridView.ClearSelection();
        }

        private void approvedLoanDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = approvedLoanDataGridView.Columns[e.ColumnIndex].Name; // Get col name
                int loanId = Convert.ToInt32(approvedLoanDataGridView.Rows[e.RowIndex].Cells[0].Value);

                if (colName.Equals("colView"))
                {
                    DataGridViewRow row = approvedLoanDataGridView.Rows[e.RowIndex]; // Get the row

                    payments = paymentRepository.GetLoanPayments(loanId);

                    // Define the base file path where the PDF file will be saved
                    string basePath = "C:\\Users\\paulm\\Documents\\Records\\ApprovedLoans\\LoanForm";
                    string extension = ".pdf";

                    // Generate a unique file path
                    string outputPath = GenerateUniqueFilePath(basePath, extension);

                    // Generate the PDF
                    GenerateLoanFormPDF(row, outputPath, payments);
                }

                if (colName.Equals("colActive"))
                {
                    if (MessageBox.Show("Do you want to set this loan to active state?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        loanRepository.SetLoanToActive(loanId);
                        DisplayApprovedLoans(); // refresh dataGridView
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message} \n\n{ex.StackTrace}");
            }
        }

        // ---------------------------------------------------------- End of Approved Loan Tab --------------------------------------------------------------------

        // ---------------------------------------------------------- Start of Denied Loan Application Tab ----------------------------------------------------------

        public void DisplayDeniedApplications()
        {
            // Fetches the denied applicants data by invoking GetDeniedLoanApplications() method from LoanApplicationRepository class 
            loanApplicationList = loanApplicationRepository.GetDeniedLoanApplications();

            deniedApplicationsDataGridView.DataSource = loanApplicationList;

            // To hide columns of dataGridView
            deniedApplicationsDataGridView.Columns[1].Visible = false;
            deniedApplicationsDataGridView.Columns[3].Visible = false;
            deniedApplicationsDataGridView.Columns[4].Visible = false;
            deniedApplicationsDataGridView.Columns[5].Visible = false;
            deniedApplicationsDataGridView.Columns[6].Visible = false;
            deniedApplicationsDataGridView.Columns[7].Visible = false;
            deniedApplicationsDataGridView.Columns[8].Visible = false;
            deniedApplicationsDataGridView.Columns[9].Visible = false;
            deniedApplicationsDataGridView.Columns[10].Visible = false;
            deniedApplicationsDataGridView.Columns[11].Visible = false;
            deniedApplicationsDataGridView.Columns[12].Visible = false;
            deniedApplicationsDataGridView.Columns[13].Visible = false;
            deniedApplicationsDataGridView.Columns[14].Visible = false;
            deniedApplicationsDataGridView.Columns[15].Visible = false;
            deniedApplicationsDataGridView.Columns[16].Visible = false;
            deniedApplicationsDataGridView.Columns[17].Visible = false;
            deniedApplicationsDataGridView.Columns[18].Visible = false;
            deniedApplicationsDataGridView.Columns[19].Visible = false;

            deniedApplicationsDataGridView.ClearSelection();
        }

        private void deniedApplicationsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = deniedApplicationsDataGridView.Columns[e.ColumnIndex].Name; // Get col name

                if (colName.Equals("ViewDeniedLoanApplication"))
                {
                    DataGridViewRow row = deniedApplicationsDataGridView.Rows[e.RowIndex]; // Get the row

                    // Define the base file path where the PDF file will be saved
                    string basePath = "C:\\Users\\paulm\\Documents\\Records\\DeniedLoans\\ApplicationForm";
                    string extension = ".pdf";

                    // Generate a unique file path
                    string outputPath = GenerateUniqueFilePath(basePath, extension);

                    // Generate the PDF
                    GeneratePDF(row, outputPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        // ---------------------------------------------------------- Generate a PDF for Application Form when a dataGridViewRow is clicked ----------------------------------------------------------

        private void GeneratePDF(DataGridViewRow row, string outputPath)
        {
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outputPath, FileMode.Create));

            // To Create a custom PdfPageEventHelper to add a logo/ header
            LogoHeaderEventHandler eventHandler = new LogoHeaderEventHandler();
            writer.PageEvent = eventHandler;

            document.Open();

            // Set up font styles
            Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
            Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
            Font cellFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);

            // Add title
            Paragraph title = new Paragraph("Application Form", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            document.Add(title);

            document.Add(Chunk.NEWLINE);

            Paragraph applicationInfoHeader = new Paragraph("Loan Information", headerFont);
            applicationInfoHeader.SpacingBefore = 10f;
            applicationInfoHeader.SpacingAfter = 10f;
            document.Add(applicationInfoHeader);

            PdfPTable applicationInfoTable = new PdfPTable(2);
            applicationInfoTable.WidthPercentage = 100;
            applicationInfoTable.DefaultCell.Border = PdfPCell.NO_BORDER;

            applicationInfoTable.AddCell(CreateTableCell("Application ID: ", headerFont, Element.ALIGN_LEFT));
            applicationInfoTable.AddCell(CreateTableCell(row.Cells[0].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            applicationInfoTable.AddCell(CreateTableCell("Application Date: ", headerFont, Element.ALIGN_LEFT));
            applicationInfoTable.AddCell(CreateTableCell(row.Cells[21].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            applicationInfoTable.AddCell(CreateTableCell("Loan Type: ", headerFont, Element.ALIGN_LEFT));
            applicationInfoTable.AddCell(CreateTableCell(row.Cells[20].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            applicationInfoTable.AddCell(CreateTableCell("Status: ", headerFont, Element.ALIGN_LEFT));
            applicationInfoTable.AddCell(CreateTableCell(row.Cells[22].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            document.Add(applicationInfoTable);

            // Add section headers - Personal Information
            Paragraph personalInfoHeader = new Paragraph("Personal Information", headerFont);
            personalInfoHeader.SpacingBefore = 10f;
            personalInfoHeader.SpacingAfter = 10f;
            document.Add(personalInfoHeader);

            // Add personal information
            PdfPTable personalInfoTable = new PdfPTable(2); // no. of columns in the parameter
            personalInfoTable.WidthPercentage = 100;
            personalInfoTable.DefaultCell.Border = PdfPCell.NO_BORDER;

            personalInfoTable.AddCell(CreateTableCell("Applicant ID: ", headerFont, Element.ALIGN_LEFT));
            personalInfoTable.AddCell(CreateTableCell(row.Cells[1].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            personalInfoTable.AddCell(CreateTableCell("Applicant Name: ", headerFont, Element.ALIGN_LEFT));
            personalInfoTable.AddCell(CreateTableCell(row.Cells[2].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            personalInfoTable.AddCell(CreateTableCell("Birth Date: ", headerFont, Element.ALIGN_LEFT));
            personalInfoTable.AddCell(CreateTableCell(row.Cells[3].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            personalInfoTable.AddCell(CreateTableCell("Address: ", headerFont, Element.ALIGN_LEFT));
            personalInfoTable.AddCell(CreateTableCell(row.Cells[4].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            personalInfoTable.AddCell(CreateTableCell("Phone: ", headerFont, Element.ALIGN_LEFT));
            personalInfoTable.AddCell(CreateTableCell(row.Cells[5].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            personalInfoTable.AddCell(CreateTableCell("Email: ", headerFont, Element.ALIGN_LEFT));
            personalInfoTable.AddCell(CreateTableCell(row.Cells[6].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            // To add an element on the document
            document.Add(personalInfoTable);

            Paragraph employmentInfoHeader = new Paragraph("Employment Information", headerFont);
            employmentInfoHeader.SpacingBefore = 10f;
            employmentInfoHeader.SpacingAfter = 10f;
            document.Add(employmentInfoHeader);

            PdfPTable employmentInfoTable = new PdfPTable(2);
            employmentInfoTable.WidthPercentage = 100;
            employmentInfoTable.DefaultCell.Border = PdfPCell.NO_BORDER;

            employmentInfoTable.AddCell(CreateTableCell("Employer Name: ", headerFont, Element.ALIGN_LEFT));
            employmentInfoTable.AddCell(CreateTableCell(row.Cells[7].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            employmentInfoTable.AddCell(CreateTableCell("Job Title: ", headerFont, Element.ALIGN_LEFT));
            employmentInfoTable.AddCell(CreateTableCell(row.Cells[8].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            employmentInfoTable.AddCell(CreateTableCell("Employment Start Date: ", headerFont, Element.ALIGN_LEFT));
            employmentInfoTable.AddCell(CreateTableCell(row.Cells[9].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            employmentInfoTable.AddCell(CreateTableCell("Employment Status: ", headerFont, Element.ALIGN_LEFT));
            employmentInfoTable.AddCell(CreateTableCell(row.Cells[10].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            employmentInfoTable.AddCell(CreateTableCell("Income Amount: ", headerFont, Element.ALIGN_LEFT));
            employmentInfoTable.AddCell(CreateTableCell(row.Cells[11].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            employmentInfoTable.AddCell(CreateTableCell("Income Frequency: ", headerFont, Element.ALIGN_LEFT));
            employmentInfoTable.AddCell(CreateTableCell(row.Cells[12].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            // To add an element on the document
            document.Add(employmentInfoTable);

            Paragraph financialInfoHeader = new Paragraph("Financial Information", headerFont);
            financialInfoHeader.SpacingBefore = 10f;
            financialInfoHeader.SpacingAfter = 10f;
            document.Add(financialInfoHeader);

            PdfPTable financialInfoTable = new PdfPTable(2);
            financialInfoTable.WidthPercentage = 100;
            financialInfoTable.DefaultCell.Border = PdfPCell.NO_BORDER;

            financialInfoTable.AddCell(CreateTableCell("Annual Income: ", headerFont, Element.ALIGN_LEFT));
            financialInfoTable.AddCell(CreateTableCell(row.Cells[13].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            financialInfoTable.AddCell(CreateTableCell("Income Source: ", headerFont, Element.ALIGN_LEFT));
            financialInfoTable.AddCell(CreateTableCell(row.Cells[14].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            financialInfoTable.AddCell(CreateTableCell("Expenses Amount: ", headerFont, Element.ALIGN_LEFT));
            financialInfoTable.AddCell(CreateTableCell(row.Cells[15].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            financialInfoTable.AddCell(CreateTableCell("Asset Value: ", headerFont, Element.ALIGN_LEFT));
            financialInfoTable.AddCell(CreateTableCell(row.Cells[16].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            financialInfoTable.AddCell(CreateTableCell("Liabilities Amount: ", headerFont, Element.ALIGN_LEFT));
            financialInfoTable.AddCell(CreateTableCell(row.Cells[17].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            financialInfoTable.AddCell(CreateTableCell("Credit Score: ", headerFont, Element.ALIGN_LEFT));
            financialInfoTable.AddCell(CreateTableCell(row.Cells[18].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            document.Add(financialInfoTable);

            document.Close();

            // Open the generated PDF file
            System.Diagnostics.Process.Start(outputPath);
        }

        private PdfPCell CreateTableCell(string content, Font font, int alignment)
        {
            PdfPCell cell = new PdfPCell(new Phrase(content, font));
            cell.HorizontalAlignment = alignment;
            cell.PaddingBottom = 5f;
            return cell;
        }

        // A custom class to add a logo/ header to the PDF
        public class LogoHeaderEventHandler : PdfPageEventHelper
        {
            public override void OnStartPage(PdfWriter writer, Document document)
            {
                // Add logo or header
                Image logo = Image.GetInstance("C:\\Users\\paulm\\Documents\\logo.png");
                logo.Alignment = Element.ALIGN_RIGHT;
                logo.ScaleToFit(100f, 100f);
                document.Add(logo);

                base.OnStartPage(writer, document);
            }
        }

        public string GenerateUniqueFilePath(string basePath, string extension)
        {
            int count = 1;
            string filePath = $"{basePath}{extension}";

            // Checks if the file already exists
            while (File.Exists(filePath))
            {
                filePath = $"{basePath}_{count}{extension}";
                count++;
            }

            return filePath;
        }

        // ---------------------------------------------------------- Generate a PDF for Loan Form when a dataGridViewRow is clicked ----------------------------------------------------------

        internal void GenerateLoanFormPDF(DataGridViewRow row, string outputPath, List<Payment> loanPayments)
        {
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outputPath, FileMode.Create));

            // To Create a custom PdfPageEventHelper to add a logo/ header
            LogoHeaderEventHandler eventHandler = new LogoHeaderEventHandler();
            writer.PageEvent = eventHandler;

            document.Open();

            // Set up font styles
            Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
            Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
            Font cellFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);

            // Add title
            Paragraph title = new Paragraph("Loan Form", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            document.Add(title);

            document.Add(Chunk.NEWLINE);

            Paragraph applicationInfoHeader = new Paragraph("Loan Information", headerFont);
            applicationInfoHeader.SpacingBefore = 10f;
            applicationInfoHeader.SpacingAfter = 10f;
            document.Add(applicationInfoHeader);

            PdfPTable loanInfoTable = new PdfPTable(2);
            loanInfoTable.WidthPercentage = 100;
            loanInfoTable.DefaultCell.Border = PdfPCell.NO_BORDER;

            loanInfoTable.AddCell(CreateTableCell("Loan ID: ", headerFont, Element.ALIGN_LEFT));
            loanInfoTable.AddCell(CreateTableCell(row.Cells[0].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            loanInfoTable.AddCell(CreateTableCell("Loan Type: ", headerFont, Element.ALIGN_LEFT));
            loanInfoTable.AddCell(CreateTableCell(row.Cells[2].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            loanInfoTable.AddCell(CreateTableCell("Amount Applied: ", headerFont, Element.ALIGN_LEFT));
            loanInfoTable.AddCell(CreateTableCell(row.Cells[21].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            loanInfoTable.AddCell(CreateTableCell("Interest Rate: ", headerFont, Element.ALIGN_LEFT));
            loanInfoTable.AddCell(CreateTableCell(row.Cells[22].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            loanInfoTable.AddCell(CreateTableCell("Term: ", headerFont, Element.ALIGN_LEFT));
            loanInfoTable.AddCell(CreateTableCell(row.Cells[23].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            loanInfoTable.AddCell(CreateTableCell("Start Date: ", headerFont, Element.ALIGN_LEFT));
            loanInfoTable.AddCell(CreateTableCell(Convert.ToDateTime(row.Cells[24].Value).ToShortDateString(), cellFont, Element.ALIGN_LEFT));

            loanInfoTable.AddCell(CreateTableCell("End Date: ", headerFont, Element.ALIGN_LEFT));
            loanInfoTable.AddCell(CreateTableCell(Convert.ToDateTime(row.Cells[25].Value).ToShortDateString(), cellFont, Element.ALIGN_LEFT));

            loanInfoTable.AddCell(CreateTableCell("Assigned Officers: ", headerFont, Element.ALIGN_LEFT));
            loanInfoTable.AddCell(CreateTableCell(row.Cells[37].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            loanInfoTable.AddCell(CreateTableCell("Status: ", headerFont, Element.ALIGN_LEFT));
            loanInfoTable.AddCell(CreateTableCell(row.Cells[38].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            document.Add(loanInfoTable);

            // Add section headers - Personal Information
            Paragraph personalInfoHeader = new Paragraph("Personal Information", headerFont);
            personalInfoHeader.SpacingBefore = 10f;
            personalInfoHeader.SpacingAfter = 10f;
            document.Add(personalInfoHeader);

            // Add personal information
            PdfPTable personalInfoTable = new PdfPTable(2); // no. of columns in the parameter
            personalInfoTable.WidthPercentage = 100;
            personalInfoTable.DefaultCell.Border = PdfPCell.NO_BORDER;

            personalInfoTable.AddCell(CreateTableCell("Client ID: ", headerFont, Element.ALIGN_LEFT));
            personalInfoTable.AddCell(CreateTableCell(row.Cells[3].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            personalInfoTable.AddCell(CreateTableCell("Name: ", headerFont, Element.ALIGN_LEFT));
            personalInfoTable.AddCell(CreateTableCell(row.Cells[4].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            personalInfoTable.AddCell(CreateTableCell("Birth Date: ", headerFont, Element.ALIGN_LEFT));
            personalInfoTable.AddCell(CreateTableCell(Convert.ToDateTime(row.Cells[5].Value).ToShortDateString(), cellFont, Element.ALIGN_LEFT));

            personalInfoTable.AddCell(CreateTableCell("Address: ", headerFont, Element.ALIGN_LEFT));
            personalInfoTable.AddCell(CreateTableCell(row.Cells[6].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            personalInfoTable.AddCell(CreateTableCell("Phone: ", headerFont, Element.ALIGN_LEFT));
            personalInfoTable.AddCell(CreateTableCell(row.Cells[7].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            personalInfoTable.AddCell(CreateTableCell("Email: ", headerFont, Element.ALIGN_LEFT));
            personalInfoTable.AddCell(CreateTableCell(row.Cells[8].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            // To add an element on the document
            document.Add(personalInfoTable);

            Paragraph collateralInfoHeader = new Paragraph("Collateral Information", headerFont);
            collateralInfoHeader.SpacingBefore = 10f;
            collateralInfoHeader.SpacingAfter = 10f;
            document.Add(collateralInfoHeader);

            PdfPTable collateralInfoTable = new PdfPTable(2); // no. of columns in the parameter
            collateralInfoTable.WidthPercentage = 100;
            collateralInfoTable.DefaultCell.Border = PdfPCell.NO_BORDER;

            collateralInfoTable.AddCell(CreateTableCell("Collateral Type: ", headerFont, Element.ALIGN_LEFT));
            collateralInfoTable.AddCell(CreateTableCell(row.Cells[27].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            collateralInfoTable.AddCell(CreateTableCell("Collateral Value: ", headerFont, Element.ALIGN_LEFT));
            collateralInfoTable.AddCell(CreateTableCell(row.Cells[28].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            collateralInfoTable.AddCell(CreateTableCell("Collateral Location: ", headerFont, Element.ALIGN_LEFT));
            collateralInfoTable.AddCell(CreateTableCell(row.Cells[29].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            // To add an element on the document
            document.Add(collateralInfoTable);

            Paragraph guarantorInfoHeader = new Paragraph("Guarantor Information", headerFont);
            guarantorInfoHeader.SpacingBefore = 10f;
            guarantorInfoHeader.SpacingAfter = 10f;
            document.Add(guarantorInfoHeader);

            // Add personal information
            PdfPTable guarantorInfoTable = new PdfPTable(2); // no. of columns in the parameter
            guarantorInfoTable.WidthPercentage = 100;
            guarantorInfoTable.DefaultCell.Border = PdfPCell.NO_BORDER;

            guarantorInfoTable.AddCell(CreateTableCell("Guarantor Name: ", headerFont, Element.ALIGN_LEFT));
            guarantorInfoTable.AddCell(CreateTableCell(row.Cells[31].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            guarantorInfoTable.AddCell(CreateTableCell("Birth Date: ", headerFont, Element.ALIGN_LEFT));
            guarantorInfoTable.AddCell(CreateTableCell(Convert.ToDateTime(row.Cells[32].Value).ToShortDateString(), cellFont, Element.ALIGN_LEFT));

            guarantorInfoTable.AddCell(CreateTableCell("Address: ", headerFont, Element.ALIGN_LEFT));
            guarantorInfoTable.AddCell(CreateTableCell(row.Cells[33].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            guarantorInfoTable.AddCell(CreateTableCell("Phone: ", headerFont, Element.ALIGN_LEFT));
            guarantorInfoTable.AddCell(CreateTableCell(row.Cells[34].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            guarantorInfoTable.AddCell(CreateTableCell("Email: ", headerFont, Element.ALIGN_LEFT));
            guarantorInfoTable.AddCell(CreateTableCell(row.Cells[35].Value.ToString(), cellFont, Element.ALIGN_LEFT));

            // To add an element on the document
            document.Add(guarantorInfoTable);


            Paragraph amortizationInfoHeader = new Paragraph("Loan Amortization", headerFont);
            amortizationInfoHeader.SpacingBefore = 10f;
            amortizationInfoHeader.SpacingAfter = 10f;
            document.Add(amortizationInfoHeader);

            PdfPTable amortizationInfoTable = new PdfPTable(6);
            amortizationInfoTable.WidthPercentage = 100;
            amortizationInfoTable.DefaultCell.Border = PdfPCell.NO_BORDER;

            amortizationInfoTable.AddCell(CreateTableCell("Payment Number: ", headerFont, Element.ALIGN_LEFT));
            amortizationInfoTable.AddCell(CreateTableCell("Payment Date: ", headerFont, Element.ALIGN_LEFT));
            amortizationInfoTable.AddCell(CreateTableCell("Principal Amount: ", headerFont, Element.ALIGN_LEFT));
            amortizationInfoTable.AddCell(CreateTableCell("Interest Amount: ", headerFont, Element.ALIGN_LEFT));
            amortizationInfoTable.AddCell(CreateTableCell("Remaining Balance: ", headerFont, Element.ALIGN_LEFT));
            amortizationInfoTable.AddCell(CreateTableCell("Status: ", headerFont, Element.ALIGN_LEFT));

            foreach (Payment payment in loanPayments)
            {
                amortizationInfoTable.AddCell(CreateTableCell(payment.PaymentNumber.ToString(), cellFont, Element.ALIGN_LEFT));
                amortizationInfoTable.AddCell(CreateTableCell(payment.PaymentDate.ToShortDateString(), cellFont, Element.ALIGN_LEFT));
                amortizationInfoTable.AddCell(CreateTableCell(payment.PrincipalAmount.ToString(), cellFont, Element.ALIGN_LEFT));
                amortizationInfoTable.AddCell(CreateTableCell(payment.InterestAmount.ToString(), cellFont, Element.ALIGN_LEFT));
                amortizationInfoTable.AddCell(CreateTableCell(payment.RemainingBalance.ToString(), cellFont, Element.ALIGN_LEFT));

                if (payment.Is_Paid == 0)
                {
                    amortizationInfoTable.AddCell(CreateTableCell("No Transaction", cellFont, Element.ALIGN_LEFT));
                }

                if (payment.Is_Paid == 1)
                {
                    amortizationInfoTable.AddCell(CreateTableCell("Transaction Successful", cellFont, Element.ALIGN_LEFT));
                }
            }

            document.Add(amortizationInfoTable);

            document.Close();

            // Open the generated PDF file
            System.Diagnostics.Process.Start(outputPath);
        }

        private void LoanProcessTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LoanProcessTabControl.SelectedIndex == 1)
            {
                applicationDataGridView.ClearSelection();
            }

            if (LoanProcessTabControl.SelectedIndex == 2)
            {
                approvedLoanDataGridView.ClearSelection();
            }

            if (LoanProcessTabControl.SelectedIndex == 3)
            {
                deniedApplicationsDataGridView.ClearSelection();
            }
        }
    }
}