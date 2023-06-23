using LoanManagementSystem.Factories;
using LoanManagementSystem.Model;
using LoanManagementSystem.Models;
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
using System.Windows.Forms;

namespace LoanManagementSystem
{
    public partial class PaymentUserControl : UserControl
    {
        private readonly DBConnection dbConnection;

        LoanProcessUserControl loanProcessUserControl;

        private LoanRepository loanRepository;
        private List<Loan> loans;

        private PaymentRepository paymentRepository;
        private List<Payment> payments;

        public PaymentUserControl()
        {
            InitializeComponent();

            string connectionString = "Server=PAULJOHN\\SQLEXPRESS;Database=DB_LoanManagement;Integrated Security=SSPI";
            dbConnection = new DBConnection(connectionString);

            loanRepository = new LoanRepository(dbConnection);
            paymentRepository = new PaymentRepository(dbConnection);

            DisplayActiveLoans();
            DisplaySettledLoans();
        }

        public void DisplayActiveLoans()
        {
            loans = loanRepository.GetActiveLoans();

            activeLoanDataGridView.DataSource = loans;

            activeLoanDataGridView.Columns[1].Visible = false;
            activeLoanDataGridView.Columns[3].Visible = false;
            activeLoanDataGridView.Columns[5].Visible = false;
            activeLoanDataGridView.Columns[6].Visible = false;
            activeLoanDataGridView.Columns[7].Visible = false;
            activeLoanDataGridView.Columns[8].Visible = false;
            activeLoanDataGridView.Columns[9].Visible = false;
            activeLoanDataGridView.Columns[10].Visible = false;
            activeLoanDataGridView.Columns[11].Visible = false;
            activeLoanDataGridView.Columns[12].Visible = false;
            activeLoanDataGridView.Columns[13].Visible = false;
            activeLoanDataGridView.Columns[14].Visible = false;
            activeLoanDataGridView.Columns[15].Visible = false;
            activeLoanDataGridView.Columns[16].Visible = false;
            activeLoanDataGridView.Columns[17].Visible = false;
            activeLoanDataGridView.Columns[18].Visible = false;
            activeLoanDataGridView.Columns[19].Visible = false;
            activeLoanDataGridView.Columns[20].Visible = false;
            activeLoanDataGridView.Columns[26].Visible = false;
            activeLoanDataGridView.Columns[28].Visible = false;
            activeLoanDataGridView.Columns[29].Visible = false;
            activeLoanDataGridView.Columns[30].Visible = false;
            activeLoanDataGridView.Columns[32].Visible = false;
            activeLoanDataGridView.Columns[33].Visible = false;
            activeLoanDataGridView.Columns[34].Visible = false;
            activeLoanDataGridView.Columns[35].Visible = false;
            activeLoanDataGridView.Columns[36].Visible = false;

            activeLoanDataGridView.ClearSelection();
        }

        public void DisplaySettledLoans()
        {
            loans = loanRepository.GetSettledLoans();

            settledLoansDataGridView.DataSource = loans;

            settledLoansDataGridView.Columns[1].Visible = false;
            settledLoansDataGridView.Columns[3].Visible = false;
            settledLoansDataGridView.Columns[5].Visible = false;
            settledLoansDataGridView.Columns[6].Visible = false;
            settledLoansDataGridView.Columns[7].Visible = false;
            settledLoansDataGridView.Columns[8].Visible = false;
            settledLoansDataGridView.Columns[9].Visible = false;
            settledLoansDataGridView.Columns[10].Visible = false;
            settledLoansDataGridView.Columns[11].Visible = false;
            settledLoansDataGridView.Columns[12].Visible = false;
            settledLoansDataGridView.Columns[13].Visible = false;
            settledLoansDataGridView.Columns[15].Visible = false;
            settledLoansDataGridView.Columns[16].Visible = false;
            settledLoansDataGridView.Columns[17].Visible = false;
            settledLoansDataGridView.Columns[18].Visible = false;
            settledLoansDataGridView.Columns[19].Visible = false;
            settledLoansDataGridView.Columns[20].Visible = false;
            settledLoansDataGridView.Columns[26].Visible = false;
            settledLoansDataGridView.Columns[28].Visible = false;
            settledLoansDataGridView.Columns[29].Visible = false;
            settledLoansDataGridView.Columns[30].Visible = false;
            settledLoansDataGridView.Columns[32].Visible = false;
            settledLoansDataGridView.Columns[33].Visible = false;
            settledLoansDataGridView.Columns[34].Visible = false;
            settledLoansDataGridView.Columns[35].Visible = false;
            settledLoansDataGridView.Columns[36].Visible = false;

            settledLoansDataGridView.ClearSelection();
        }

        private void activeLoanDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = activeLoanDataGridView.Columns[e.ColumnIndex].Name; // Get col name
                int loanId = Convert.ToInt32(activeLoanDataGridView.Rows[e.RowIndex].Cells[0].Value);

                if (colName.Equals("colView"))
                {
                    loanProcessUserControl = new LoanProcessUserControl();

                    DataGridViewRow row = activeLoanDataGridView.Rows[e.RowIndex]; // Get the row

                    payments = paymentRepository.GetLoanPayments(loanId);

                    // Define the base file path where the PDF file will be saved
                    string basePath = "C:\\Users\\paulm\\Documents\\Records\\ActiveLoans\\LoanForm";
                    string extension = ".pdf";

                    // Generate a unique file path
                    string outputPath = loanProcessUserControl.GenerateUniqueFilePath(basePath, extension);

                    // Generate the PDF
                    loanProcessUserControl.GenerateLoanFormPDF(row, outputPath, payments);
                }

                if (colName.Equals("colPayment"))
                {
                    frmPayment _frmPayment = new frmPayment(this);
                    _frmPayment.loanId = loanId;
                    _frmPayment.DisplayLoanToPays();
                    _frmPayment.DisplayTransactHistory();
                    _frmPayment.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message} \n\n{ex.StackTrace}");
            }
        }

        private void settledLoansDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = settledLoansDataGridView.Columns[e.ColumnIndex].Name; // Get col name
                int loanId = Convert.ToInt32(settledLoansDataGridView.Rows[e.RowIndex].Cells[0].Value);

                if (colName.Equals("colViewLoan"))
                {
                    loanProcessUserControl = new LoanProcessUserControl();

                    DataGridViewRow row = settledLoansDataGridView.Rows[e.RowIndex]; // Get the row

                    payments = paymentRepository.GetLoanPayments(loanId);

                    // Define the base file path where the PDF file will be saved
                    string basePath = "C:\\Users\\paulm\\Documents\\Records\\SettledLoans\\LoanForm";
                    string extension = ".pdf";

                    // Generate a unique file path
                    string outputPath = loanProcessUserControl.GenerateUniqueFilePath(basePath, extension);

                    // Generate the PDF
                    loanProcessUserControl.GenerateLoanFormPDF(row, outputPath, payments);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message} \n\n{ex.StackTrace}");
            }
        }

        private void PaymentTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PaymentTabControl.SelectedIndex == 0)
            {
                activeLoanDataGridView.ClearSelection();
            }

            if (PaymentTabControl.SelectedIndex == 1)
            {
                settledLoansDataGridView.ClearSelection();
            }
        }

        private void PaymentUserControl_Load(object sender, EventArgs e)
        {
            activeLoanDataGridView.ClearSelection();
        }
    }
}