using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LoanManagementSystem
{
    public partial class frmDashboard : Form
    {
        HomeUserControl _usrControlHome;
        ClientGuarantorLenderUserControl _usrControlClientGuarantorLender;
        LoanProcessUserControl _usrControlLoanProcess;
        PaymentUserControl _usrControlPayment;

        private User user;

        public frmDashboard(User user)
        {
            InitializeComponent();
            btn_HideMenu.Hide();
            lbl_Date.Text = DateTime.Now.ToString("D");
            this.user = user;

            // Set HomeControl as the default window
            _usrControlHome = new HomeUserControl(user);
            pnlContainer.Controls.Add(_usrControlHome);
            _usrControlHome.BringToFront();

            // By default, Home button is the active tab
            btn_Home.Checked = true;
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            _usrControlHome = new HomeUserControl(user); // Create an instance of the User Control Home
            pnlContainer.Controls.Clear(); // Clear the pnlContainer 
            pnlContainer.Controls.Add(_usrControlHome); // Add the instance of User Control Home to pnlContainer
            _usrControlHome.BringToFront(); // Bring it to front to make it visible

            // To determine which tab/ window is active
            btn_Home.Checked = true;
            btn_LoanProcess.Checked = false;
            btn_ClientGuarantorLoanOfficer.Checked = false;
            btn_Payment.Checked = false;
            btn_Logout.Checked = false;
        }

        private void btn_Home_MouseHover(object sender, EventArgs e)
        {
            // Set the tooltip text to the desired message
            btnHoverToolTip.SetToolTip(btn_Home, "Home");
        }

        private void btn_LoanProcess_Click(object sender, EventArgs e)
        {
            _usrControlLoanProcess = new LoanProcessUserControl();
            pnlContainer.Controls.Clear(); // Clear the pnlContainer 
            pnlContainer.Controls.Add(_usrControlLoanProcess);
            _usrControlLoanProcess.BringToFront();

            btn_Home.Checked = false;
            btn_LoanProcess.Checked = true;
            btn_ClientGuarantorLoanOfficer.Checked = false;
            btn_Payment.Checked = false;
            btn_Logout.Checked = false;
        }

        private void btn_LoanProcess_MouseHover(object sender, EventArgs e)
        {
            // Set the tooltip text to the desired message
            btnHoverToolTip.SetToolTip(btn_LoanProcess, "Loan Process");
        }

        private void btn_ClientGuarantorLoanOfficer_Click(object sender, EventArgs e)
        {
            _usrControlClientGuarantorLender = new ClientGuarantorLenderUserControl();
            pnlContainer.Controls.Clear(); // Clear the pnlContainer 
            pnlContainer.Controls.Add(_usrControlClientGuarantorLender);
            _usrControlClientGuarantorLender.BringToFront();

            btn_Home.Checked = false;
            btn_LoanProcess.Checked = false;
            btn_ClientGuarantorLoanOfficer.Checked = true;
            btn_Payment.Checked = false;
            btn_Logout.Checked = false;
        }

        private void btn_ClientGuarantorLoanOfficer_MouseHover(object sender, EventArgs e)
        {
            // Set the tooltip text to the desired message
            btnHoverToolTip.SetToolTip(btn_ClientGuarantorLoanOfficer, "Client | Guarantor | Loan Officer");
        }

        private void btn_Payment_Click(object sender, EventArgs e)
        {
            _usrControlPayment = new PaymentUserControl();
            pnlContainer.Controls.Clear();
            pnlContainer.Controls.Add(_usrControlPayment);
            _usrControlPayment.BringToFront();

            btn_Home.Checked = false;
            btn_LoanProcess.Checked = false;
            btn_ClientGuarantorLoanOfficer.Checked = false;
            btn_Payment.Checked = true;
            btn_Logout.Checked = false;
        }

        private void btn_Payment_MouseHover(object sender, EventArgs e)
        {
            // Set the tooltip text to the desired message
            btnHoverToolTip.SetToolTip(btn_Payment, "Payment");
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            btn_Home.Checked = false;
            btn_LoanProcess.Checked = false;
            btn_ClientGuarantorLoanOfficer.Checked = false;
            btn_Payment.Checked = false;
            btn_Logout.Checked = true;

            if (MessageBox.Show("Are you sure you want to logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
            btn_Logout.Checked = false;
        }

        private void btn_Logout_MouseHover(object sender, EventArgs e)
        {
            // Set the tooltip text to the desired message
            btnHoverToolTip.SetToolTip(btn_Logout, "Logout");
        }
    }
}
