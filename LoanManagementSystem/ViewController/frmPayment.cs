using LoanManagementSystem.Models;
using LoanManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoanManagementSystem.ViewController
{
    public partial class frmPayment : Form
    {
        private DBConnection dbConnection;

        PaymentUserControl paymentUserControl;

        private PaymentRepository paymentRepository;
        private List<Payment> payments;

        public int loanId;

        public frmPayment(PaymentUserControl paymentUserControl)
        {
            InitializeComponent();

            string connectionString = "Server=PAULJOHN\\SQLEXPRESS;Database=DB_LoanManagement;Integrated Security=SSPI";
            dbConnection = new DBConnection(connectionString);

            paymentRepository = new PaymentRepository(dbConnection);
            this.paymentUserControl = paymentUserControl;

            DisplayLoanToPays();
            DisplayTransactHistory();
        }

        public void DisplayLoanToPays()
        {
            payments = paymentRepository.GetLoanToPay(loanId);

            amortizationDataGridView.DataSource = payments;

            amortizationDataGridView.Columns[0].Visible = false;
            amortizationDataGridView.Columns[1].Visible = false;
            amortizationDataGridView.Columns[7].Visible = false;

            amortizationDataGridView.ClearSelection();
        }

        public void DisplayTransactHistory()
        {
            payments = paymentRepository.GetPaymentsHistory(loanId);

            transactHistoryDataGridView.DataSource = payments;

            transactHistoryDataGridView.Columns[0].Visible = false;
            transactHistoryDataGridView.Columns[1].Visible = false;
            transactHistoryDataGridView.Columns[7].Visible = false;
            transactHistoryDataGridView.Columns[8].Visible = false;

            transactHistoryDataGridView.ClearSelection();
        }

        private void amortizationDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = amortizationDataGridView.Columns[e.ColumnIndex].Name; // Get col name

            if (colName.Equals("colPay"))
            {
                Payment transaction = new Payment();
                transaction.Id = Convert.ToInt32(amortizationDataGridView.Rows[e.RowIndex].Cells[0].Value);
                transaction.LoanId = Convert.ToInt32(amortizationDataGridView.Rows[e.RowIndex].Cells[1].Value);
                transaction.PaymentNumber = Convert.ToInt32(amortizationDataGridView.Rows[e.RowIndex].Cells[2].Value);

                paymentRepository.MakeTransaction(transaction);

                // Refresh the dataGridViews
                DisplayLoanToPays();
                DisplayTransactHistory();
                paymentUserControl.DisplayActiveLoans();
                paymentUserControl.DisplaySettledLoans();
            }
        }

        private void PaymentTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PaymentTabControl.SelectedIndex == 0)
            {
                amortizationDataGridView.ClearSelection();
            }

            if (PaymentTabControl.SelectedIndex == 1)
            {
                transactHistoryDataGridView.ClearSelection();
            }
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            amortizationDataGridView.ClearSelection();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close this window?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
