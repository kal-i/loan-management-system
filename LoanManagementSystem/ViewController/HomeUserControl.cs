using LoanManagementSystem.Model;
using LoanManagementSystem.Repositories;
using LoanManagementSystem.ViewController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoanManagementSystem
{
    public partial class HomeUserControl : UserControl
    {
        DBConnection dbConnection;

        private ClientRepository clientRepository;
        private LoanApplicationRepository loanApplicationRepository;
        private LoanRepository loanRepository;
        private PaymentRepository paymentRepository;

        private List<LoanApplication> loanApplications;


        // Get the user's data through the constructor
        // Set the user's last name and first name to lblFullName
        public HomeUserControl(User user)
        {
            InitializeComponent();
            
            // ToTitleCase() converts the first character of each word in the string to uppercase, while the remaining to lowercase
            // 'TextInfo.ToTitleCase' method assumes that the words being passed are separated by spaces
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            lblFullName.Text = textInfo.ToTitleCase($"{user.LastName}, {user.FirstName}");

            string connectionString = "Server=PAULJOHN\\SQLEXPRESS;Database=DB_LoanManagement;Integrated Security=SSPI";

            dbConnection = new DBConnection(connectionString);

            clientRepository = new ClientRepository(dbConnection);
            loanApplicationRepository = new LoanApplicationRepository(dbConnection);
            loanRepository = new LoanRepository(dbConnection);
            paymentRepository = new PaymentRepository(dbConnection);

            // Display the no. of Clients
            lblClientCounts.Text = clientRepository.GetNumberOfClients().ToString();

            // Display the no. of Pending Loan Requests
            lblLoanRequests.Text = loanApplicationRepository.GetNumberOfPendingRequests().ToString();

            // Display the no. of Active Loans
            lblActiveLoans.Text = loanRepository.GetNumberOfActiveLoans().ToString();

            // Display the no. of Payments Overdue
            lblOverDue.Text = paymentRepository.GetOverDues().ToString();

            DisplayPendingLoanApplications();
        }

        private void DisplayPendingLoanApplications()
        {
            loanApplications = loanApplicationRepository.GetPendingLoanApplications();

            pendingRequestDataGridView.DataSource = loanApplications;

            pendingRequestDataGridView.Columns[1].Visible = false;
            pendingRequestDataGridView.Columns[3].Visible = false;
            pendingRequestDataGridView.Columns[4].Visible = false;
            pendingRequestDataGridView.Columns[5].Visible = false;
            pendingRequestDataGridView.Columns[6].Visible = false;
            pendingRequestDataGridView.Columns[7].Visible = false;
            pendingRequestDataGridView.Columns[8].Visible = false;
            pendingRequestDataGridView.Columns[9].Visible = false;
            pendingRequestDataGridView.Columns[10].Visible = false;
            pendingRequestDataGridView.Columns[11].Visible = false;
            pendingRequestDataGridView.Columns[12].Visible = false;
            pendingRequestDataGridView.Columns[13].Visible = false;
            pendingRequestDataGridView.Columns[14].Visible = false;
            pendingRequestDataGridView.Columns[15].Visible = false;
            pendingRequestDataGridView.Columns[16].Visible = false;
            pendingRequestDataGridView.Columns[17].Visible = false;
            pendingRequestDataGridView.Columns[18].Visible = false;
            pendingRequestDataGridView.Columns[19].Visible = false;

            pendingRequestDataGridView.ClearSelection();
        }

        private void HomeUserControl_Load(object sender, EventArgs e)
        {
            pendingRequestDataGridView.ClearSelection();
        }
    }
}